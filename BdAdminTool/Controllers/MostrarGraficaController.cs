using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminbdTool.Models;
using Newtonsoft.Json;
using System.Collections;

namespace WebAdminbdTool.Controllers
{


    public class MostrarGraficaController : Controller
    {



        private readonly Bdadmincontext _context;

        public MostrarGraficaController(Bdadmincontext context)
        {
            _context = context;

        }

        // GET: Valoresvariables
        //public async Task<IActionResult> Index()
        //{
        //    var bdadmincontext = _context.Valoresvariables.Include(v => v.IdObjetoSistemaNavigation).Include(v => v.IdTemporalidadNavigation).Include(v => v.IdTipoObjetoNavigation).Include(v => v.IdTipoVariableNavigation).Include(v => v.IdVariableNavigation).Include(v => v.IdunidadNavigation);
        //    return View(await bdadmincontext.ToListAsync());
        //}



        // GET: Valoresvariables/Details/5
      //  public IActionResult Index(DateTime fechaInicial, int etapaIni, int etapaFin, int idTemporalidad, int IdVariable, int IdTipoVariable)
        public IActionResult Index(IList fechas, IList datos)
        {
            DateTime fechaFinal = DateTime.Now;

            //switch (idTemporalidad)
            //{
            //    case 1: // Horario
            //        fechaFinal = fechaInicial;
            //        break;
            //    case 2: //Diario
            //        fechaFinal = fechaInicial.AddDays(etapaFin - etapaIni + 1);
            //        break;
            //    case 3: //Mensual
            //        fechaFinal = fechaInicial.AddMonths(etapaFin - etapaIni + 1);
            //        break;

            //}

            //var valoresvariables = _context.Valoresvariables
            //    .Include(v => v.IdObjetoSistemaNavigation)
            //    .Include(v => v.IdTemporalidadNavigation)
            //    .Include(v => v.IdTipoObjetoNavigation)
            //    .Include(v => v.IdTipoVariableNavigation)
            //    .Include(v => v.IdVariableNavigation)
            //    .Include(v => v.IdunidadNavigation)
            //    .Where(m => m.Fecha >= fechaInicial.ToUniversalTime().AddHours(-5) && m.Fecha <= fechaFinal.ToUniversalTime().AddHours(-5) && m.Periodo >= etapaIni && m.Periodo <= etapaFin && m.IdTemporalidad == idTemporalidad && m.IdVariable == IdVariable && m.IdTipoVariable == IdTipoVariable
            //    );



            //valoresvariables = valoresvariables.OrderBy(x => x.Fecha);

            //var valoresvariablesPuntos = _context.Valoresvariables
            //    .Where(m => m.Fecha >= fechaInicial.ToUniversalTime().AddHours(-5) && m.Fecha <= fechaFinal.ToUniversalTime().AddHours(-5) && m.Periodo >= etapaIni && m.Periodo <= etapaFin && m.IdTemporalidad == idTemporalidad && m.IdVariable == IdVariable && m.IdTipoVariable == IdTipoVariable);


            //IList datos = valoresvariables.Select(x => new { x.Valor }).ToList();
            //IList fechas = valoresvariables.Select(x => new { x.Fecha }).ToList();

            var valoresVariablesJson = JsonConvert.SerializeObject(datos);
            var fechasVariablesJson = JsonConvert.SerializeObject(fechas);

            ViewBag.Datos = valoresVariablesJson;
            ViewBag.Fechas = fechasVariablesJson;





            //if (valoresvariables == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: Valoresvariables/Create


        private bool ValoresvariablesExists(int id)
        {
            return _context.Valoresvariables.Any(e => e.IdValorVariable == id);
        }
    }
}
