using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAdminbdTool.Models;

namespace WebAdminbdTool.Controllers
{
    public class DatosGraficasController : Controller
    {

        private readonly Bdadmincontext _context;

        public DatosGraficasController(Bdadmincontext context)
        {
            _context = context;

        }

        //public struct RegistroGraficos
        //{
            
        //    public double valor;
        //    public int vble;
        //    public int tipo;
        //    public DateTime fecha;
        //}

        public struct RegistroGraficos
        {
            public String nombre;
            public List<object> datos;
            
        }

        public IActionResult Index()
        {
            var Conficaso = _context.Configuracioncasobasica;

            //Conficaso.

          


        var FechaInicial = Conficaso.Select(c => new {c.FechaInicial}).ToList();

            var DatosCaso = Conficaso.Select(c => new { c.FechaInicial,c.EtapaInicial,c.EtapaFinal,c.IdTemporalidad }).ToList();

            //String Fec3 = null;

            String Fec3 = DatosCaso[0].FechaInicial.ToShortDateString();
            DateTime fecha =DateTime.Parse(Fec3);

            int IdTemporalidad = DatosCaso[0].IdTemporalidad;
            int etapaIni = DatosCaso[0].EtapaInicial;
            int etapaFin = DatosCaso[0].EtapaFinal;

            DateTime fechaFinal=fecha;
            string Formatofecha = null;

            //int IdVariable = 2;
            //int IdTipoVariable = 5;

            switch (IdTemporalidad)
            {
                case 1: // Horario
                    fechaFinal = fecha;
                    break;
                case 2: //Diario
                    fechaFinal = fecha.AddDays(etapaFin - etapaIni + 1);
                    Formatofecha = "MM/dd/yyyy";
                    break;
                case 3: //Mensual
                    fechaFinal = fecha.AddMonths(etapaFin - etapaIni + 1);
                    Formatofecha = "MM/yyyy";
                    break;

            }
            
            var DetallesCaso = _context.Detalleconfiguracioncasobasica;

           
        var valoresvariables = _context.Valoresvariables
               .Where(m => m.Fecha >= fecha.ToUniversalTime().AddHours(-5) && m.Fecha <= fechaFinal.ToUniversalTime().AddHours(-5) && m.Periodo >= etapaIni && m.Periodo <= etapaFin && m.IdTemporalidad == IdTemporalidad);

            var variablesaGraficar = valoresvariables.Select(x => new {  x.IdTipoVariable, x.IdVariable}).Distinct();
            var graficas = new List<object>();

            foreach (var item in variablesaGraficar)
            {
                valoresvariables = _context.Valoresvariables
               .Include(v => v.IdObjetoSistemaNavigation)
               .Include(v => v.IdTemporalidadNavigation)
               .Include(v => v.IdTipoObjetoNavigation)
               .Include(v => v.IdTipoVariableNavigation)
               .Include(v => v.IdVariableNavigation)
               .Include(v => v.IdunidadNavigation)
             .Where(m => m.Fecha >= fecha.ToUniversalTime().AddHours(-5) && m.Fecha <= fechaFinal.ToUniversalTime().AddHours(-5) && m.Periodo >= etapaIni && m.Periodo <= etapaFin && m.IdTemporalidad == IdTemporalidad && m.IdVariable == item.IdVariable && m.IdTipoVariable == item.IdTipoVariable);
                 var datos = valoresvariables.Select(x =>  new { x.IdTipoVariableNavigation.NombreTipoVariable, x.Fecha, x.Valor }).ToList();

                List<string> fechas = new List<string>(); 
                List<float> valores = new List<float>();
                
                foreach (var dato in datos)
                {
                    fechas.Add( dato.Fecha.ToString());
                    valores.Add(dato.Valor);
                }

                var nombreGrafico = datos[0].NombreTipoVariable;
                var fechasGrafico = JsonConvert.SerializeObject(fechas);
                var valoresGrafico = JsonConvert.SerializeObject(valores);

                graficas.Add((nombreGrafico, fechasGrafico, valoresGrafico));
            }

            ViewBag.Graficos = graficas;

            if (valoresvariables == null)
            {
                return NotFound();
            }

            return View(ViewBag);
        }
    }
}