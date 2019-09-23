using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAdminbdTool.Models
{
    public partial class Bdadmincontext : DbContext
    {
        public Bdadmincontext()
        {
        }

        public Bdadmincontext(DbContextOptions<Bdadmincontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configuracioncasobasica> Configuracioncasobasica { get; set; }
        public virtual DbSet<Costoscombustiblesbasica> Costoscombustiblesbasica { get; set; }
        public virtual DbSet<Detalleconfiguracioncasobasica> Detalleconfiguracioncasobasica { get; set; }
        public virtual DbSet<Objetossistemabasica> Objetossistemabasica { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Regioneshidrologicasbasica> Regioneshidrologicasbasica { get; set; }
        public virtual DbSet<Relacionesobjetosbasica> Relacionesobjetosbasica { get; set; }
        public virtual DbSet<Temporalidadesbasica> Temporalidadesbasica { get; set; }
        public virtual DbSet<Tiposobjetosbasica> Tiposobjetosbasica { get; set; }
        public virtual DbSet<Tiposrelacionesbasica> Tiposrelacionesbasica { get; set; }
        public virtual DbSet<Tipovariables> Tipovariables { get; set; }
        public virtual DbSet<Unidadesbasica> Unidadesbasica { get; set; }
        public virtual DbSet<Valoresvariables> Valoresvariables { get; set; }
        public virtual DbSet<Variables> Variables { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=Basicas;uid=consulta;pwd=consulta");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Configuracioncasobasica>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionCasobasica);

                entity.ToTable("configuracioncasobasica", "basicas");

                entity.HasIndex(e => e.IdTemporalidad)
                    .HasName("FK_Temporalidades_idx");

                entity.Property(e => e.IdConfiguracionCasobasica)
                    .HasColumnName("idConfiguracionCasobasica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.EtapaFinal).HasColumnType("int(11)");

                entity.Property(e => e.EtapaInicial).HasColumnType("int(11)");

                entity.Property(e => e.IdTemporalidad).HasColumnType("int(11)");

                //entity.HasOne(d => d.IdTemporalidadNavigation)
                //    .WithMany(p => p.Configuracioncasobasica)
                //    .HasForeignKey(d => d.IdTemporalidad)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Temporalidades");
            });

            modelBuilder.Entity<Costoscombustiblesbasica>(entity =>
            {
                entity.HasKey(e => e.Idcostoscombustibles);

                entity.ToTable("costoscombustiblesbasica", "basicas");

                entity.Property(e => e.Idcostoscombustibles)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Centroscombustible)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Ramal)
                    .IsRequired()
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.Recurso)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detalleconfiguracioncasobasica>(entity =>
            {
                entity.HasKey(e => e.Iddetalleconfiguracioncaso);

                entity.ToTable("detalleconfiguracioncasobasica", "basicas");

                entity.HasIndex(e => e.IdConfiguracionCasobasica)
                    .HasName("FK_DetalleConficaso_IDX");

                entity.HasIndex(e => e.IdTemporalidad)
                    .HasName("FK_DetalleTemporalidades_idx");

                entity.HasIndex(e => e.IdTipoObjeto)
                    .HasName("FK_DetalleObjetos_idx");

                entity.HasIndex(e => e.IdTipoVariable)
                    .HasName("FK_DetalleTipoVariables_idx");

                entity.HasIndex(e => e.IdVariable)
                    .HasName("IDX_VariablesID");

                entity.HasIndex(e => e.Idobjeto)
                    .HasName("FK_DetalleTiposObjetos_idx");

                entity.Property(e => e.Iddetalleconfiguracioncaso).HasColumnType("int(11)");

                entity.Property(e => e.IdConfiguracionCasobasica)
                    .HasColumnName("idConfiguracionCasobasica")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTemporalidad).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoObjeto).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoVariable).HasColumnType("int(11)");

                entity.Property(e => e.IdVariable).HasColumnType("int(11)");

                entity.Property(e => e.Idobjeto).HasColumnType("int(11)");

                entity.Property(e => e.TipoDia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConfiguracionCasobasicaNavigation)
                    .WithMany(p => p.Detalleconfiguracioncasobasica)
                    .HasForeignKey(d => d.IdConfiguracionCasobasica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleConficaso");

                entity.HasOne(d => d.IdTipoObjetoNavigation)
                    .WithMany(p => p.Detalleconfiguracioncasobasica)
                    .HasForeignKey(d => d.IdTipoObjeto)
                    .HasConstraintName("FK_DetalleObjetos");

                entity.HasOne(d => d.IdTipoVariableNavigation)
                    .WithMany(p => p.Detalleconfiguracioncasobasica)
                    .HasForeignKey(d => d.IdTipoVariable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleTipoVariables");

                entity.HasOne(d => d.IdVariableNavigation)
                    .WithMany(p => p.Detalleconfiguracioncasobasica)
                    .HasForeignKey(d => d.IdVariable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleVariables");

                entity.HasOne(d => d.IdobjetoNavigation)
                    .WithMany(p => p.Detalleconfiguracioncasobasica)
                    .HasForeignKey(d => d.Idobjeto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleTiposObjetos");
            });

            modelBuilder.Entity<Objetossistemabasica>(entity =>
            {
                entity.HasKey(e => e.IdobjetoSistema);

                entity.ToTable("objetossistemabasica", "basicas");

                entity.HasIndex(e => e.IdTipoObjeto)
                    .HasName("IDX_TiposObjetos");

                entity.Property(e => e.IdobjetoSistema)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFinal).HasColumnType("datetime(6)");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime(6)");

                entity.Property(e => e.IdTipoObjeto).HasColumnType("int(11)");

                entity.Property(e => e.NombreObjeto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoObjetoNavigation)
                    .WithMany(p => p.Objetossistemabasica)
                    .HasForeignKey(d => d.IdTipoObjeto)
                    .HasConstraintName("FK_ObjetoyTipoObjeto");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.IdPaises);

                entity.ToTable("paises", "basicas");

                entity.Property(e => e.IdPaises)
                    .HasColumnName("idPaises")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regioneshidrologicasbasica>(entity =>
            {
                entity.HasKey(e => e.IdregionesHidrologicas);

                entity.ToTable("regioneshidrologicasbasica", "basicas");

                entity.Property(e => e.IdregionesHidrologicas)
                    .HasColumnName("IDRegionesHidrologicas")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreRegionHidrologica)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relacionesobjetosbasica>(entity =>
            {
                entity.HasKey(e => e.Idrelacion);

                entity.ToTable("relacionesobjetosbasica", "basicas");

                entity.HasIndex(e => e.IdObjeto1)
                    .HasName("FK_RelacionObjetos_idx");

                entity.HasIndex(e => e.IdTiporelacion)
                    .HasName("FK_RelacionobjetoTipoRelacion_idx");

                entity.Property(e => e.Idrelacion).HasColumnType("int(11)");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime(6)");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime(6)");

                entity.Property(e => e.IdObjeto1).HasColumnType("int(11)");

                entity.Property(e => e.IdObjeto2).HasColumnType("int(11)");

                entity.Property(e => e.IdTiporelacion).HasColumnType("int(11)");

                entity.HasOne(d => d.IdTiporelacionNavigation)
                    .WithMany(p => p.Relacionesobjetosbasica)
                    .HasForeignKey(d => d.IdTiporelacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelacionobjetoTipoRelacion");
            });

            modelBuilder.Entity<Temporalidadesbasica>(entity =>
            {
                entity.HasKey(e => e.Idtemporalidad);

                entity.ToTable("temporalidadesbasica", "basicas");

                entity.Property(e => e.Idtemporalidad)
                    .HasColumnName("IDTemporalidad")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreTemporalidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tiposobjetosbasica>(entity =>
            {
                entity.HasKey(e => e.IdTipoObjeto);

                entity.ToTable("tiposobjetosbasica", "basicas");

                entity.HasIndex(e => e.IdTipoObjeto)
                    .HasName("IdTipoObjeto_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTipoObjeto)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFinal).HasColumnType("datetime(6)");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime(6)");

                entity.Property(e => e.NombreTabla)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoObjeto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tiposrelacionesbasica>(entity =>
            {
                entity.HasKey(e => e.IdTiporelacion);

                entity.ToTable("tiposrelacionesbasica", "basicas");

                entity.HasIndex(e => e.IdTipoObjeto1)
                    .HasName("IDX_TipoObjeto1");

                entity.HasIndex(e => e.IdTipoObjeto2)
                    .HasName("IDX_TipoObjeto2");

                entity.Property(e => e.IdTiporelacion)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFinal).HasColumnType("datetime(6)");

                entity.Property(e => e.FechaInicial).HasColumnType("datetime(6)");

                entity.Property(e => e.IdTipoObjeto1).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoObjeto2).HasColumnType("int(11)");

                entity.Property(e => e.NombreTablaObjeto1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTablaObjeto2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoRelacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoObjeto1Navigation)
                    .WithMany(p => p.TiposrelacionesbasicaIdTipoObjeto1Navigation)
                    .HasForeignKey(d => d.IdTipoObjeto1)
                    .HasConstraintName("FK_TiposObjetos1");

                entity.HasOne(d => d.IdTipoObjeto2Navigation)
                    .WithMany(p => p.TiposrelacionesbasicaIdTipoObjeto2Navigation)
                    .HasForeignKey(d => d.IdTipoObjeto2)
                    .HasConstraintName("FK_TiposObjetos2");
            });

            modelBuilder.Entity<Tipovariables>(entity =>
            {
                entity.HasKey(e => e.IdTipoVariable);

                entity.ToTable("tipovariables", "basicas");

                entity.HasIndex(e => e.IdTipoVariable)
                    .HasName("IdTipoVariable_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdVariable)
                    .HasName("FK_TipoVariables_idx");

                entity.Property(e => e.IdTipoVariable)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicial).HasColumnType("date");

                entity.Property(e => e.IdVariable).HasColumnType("int(11)");

                entity.Property(e => e.NombreTipoVariable)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdVariableNavigation)
                    .WithMany(p => p.Tipovariables)
                    .HasForeignKey(d => d.IdVariable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoVariables");
            });

            modelBuilder.Entity<Unidadesbasica>(entity =>
            {
                entity.HasKey(e => e.IdUnidad);

                entity.ToTable("unidadesbasica", "basicas");

                entity.Property(e => e.IdUnidad)
                    .HasColumnName("idUnidad")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreUnidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Valoresvariables>(entity =>
            {
                entity.HasKey(e => e.IdValorVariable);

                entity.ToTable("valoresvariables", "basicas");

                entity.HasIndex(e => e.IdObjetoSistema)
                    .HasName("IDX_Objetos");

                entity.HasIndex(e => e.IdTemporalidad)
                    .HasName("FK_Temporaalidades_idx");

                entity.HasIndex(e => e.IdTipoObjeto)
                    .HasName("FK_TipoObjetos_idx");

                entity.HasIndex(e => e.IdTipoVariable)
                    .HasName("FK-Tipovbles_idx");

                entity.HasIndex(e => e.IdVariable)
                    .HasName("FK_Varibles_idx");

                entity.HasIndex(e => e.Idunidad)
                    .HasName("FK_Unidades_idx");

                entity.Property(e => e.IdValorVariable).HasColumnType("int(11)");

                entity.Property(e => e.Fuente)
                    .HasColumnName("Fuente")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdObjetoSistema).HasColumnType("int(11)");

                entity.Property(e => e.IdTemporalidad).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoObjeto).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoVariable).HasColumnType("int(11)");

                entity.Property(e => e.IdVariable).HasColumnType("int(11)");

                entity.Property(e => e.Idunidad).HasColumnType("int(11)");

                entity.Property(e => e.Periodo).HasColumnType("int(11)");

                entity.Property(e => e.TipoDia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("float(24,0)");

                entity.HasOne(d => d.IdObjetoSistemaNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.IdObjetoSistema)
                    .HasConstraintName("FK_Objetos");

                entity.HasOne(d => d.IdTemporalidadNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.IdTemporalidad)
                    .HasConstraintName("FK_Temporaalidades");

                entity.HasOne(d => d.IdTipoObjetoNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.IdTipoObjeto)
                    .HasConstraintName("FK_TipoObjetos");

                entity.HasOne(d => d.IdTipoVariableNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.IdTipoVariable)
                    .HasConstraintName("FK-Tipovbles");

                entity.HasOne(d => d.IdVariableNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.IdVariable)
                    .HasConstraintName("FK_Varibles");

                entity.HasOne(d => d.IdunidadNavigation)
                    .WithMany(p => p.Valoresvariables)
                    .HasForeignKey(d => d.Idunidad)
                    .HasConstraintName("FK_Unidades");
            });

            modelBuilder.Entity<Variables>(entity =>
            {
                entity.HasKey(e => e.IdVariable);

                entity.ToTable("variables", "basicas");

                entity.HasIndex(e => e.IdVariable)
                    .HasName("IdVariable_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdVariable)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFinal).HasColumnType("date");

                entity.Property(e => e.FechaInicial).HasColumnType("date");

                entity.Property(e => e.NombreVariable)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
