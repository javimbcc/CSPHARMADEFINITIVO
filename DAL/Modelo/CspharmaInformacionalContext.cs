using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Modelo;

public partial class CspharmaInformacionalContext : DbContext
{
    public CspharmaInformacionalContext()
    {
    }

    public CspharmaInformacionalContext(DbContextOptions<CspharmaInformacionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DlkCatAccEmpleado> DlkCatAccEmpleados { get; set; }

    public virtual DbSet<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedidos { get; set; }

    public virtual DbSet<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedidos { get; set; }

    public virtual DbSet<TdcCatLineasDistribucion> TdcCatLineasDistribucions { get; set; }

    public virtual DbSet<TdcTchEstadoPedido> TdcTchEstadoPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_informacional;User Id=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DlkCatAccEmpleado>(entity =>
        {
            entity.HasKey(e => e.CodEmpleado).HasName("dlk_cat_acc_empleado_pkey");

            entity.ToTable("dlk_cat_acc_empleado", "dlk_informacional");

            entity.Property(e => e.CodEmpleado)
                .UseIdentityAlwaysColumn()
                .HasColumnName("cod_empleado");
            entity.Property(e => e.ClaveEmpleado)
                .HasColumnType("character varying")
                .HasColumnName("clave_empleado");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
            entity.Property(e => e.NivelAccesoEmpleado).HasColumnName("nivel_acceso_empleado");
        });

        modelBuilder.Entity<TdcCatEstadosDevolucionPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoDevolucion).HasName("tdc_cat_estados_devolucion_pedido_pkey");

            entity.ToTable("tdc_cat_estados_devolucion_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.DesEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_devolucion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosEnvioPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoEnvio).HasName("tdc_cat_estados_envio_pedido_pkey");

            entity.ToTable("tdc_cat_estados_envio_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.DesEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_envio");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatEstadosPagoPedido>(entity =>
        {
            entity.HasKey(e => e.CodEstadoPago).HasName("tdc_cat_estados_pago_envio_pkey");

            entity.ToTable("tdc_cat_estados_pago_pedido", "dwh_torrecontrol");

            entity.Property(e => e.CodEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.DesEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("des_estado_pago");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcCatLineasDistribucion>(entity =>
        {
            entity.HasKey(e => e.CodLinea).HasName("tdc_cat_lineas_distribucion_pkey");

            entity.ToTable("tdc_cat_lineas_distribucion", "dwh_torrecontrol");

            entity.Property(e => e.CodLinea)
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodBarrio)
                .HasColumnType("character varying")
                .HasColumnName("cod_barrio");
            entity.Property(e => e.CodMunicipio)
                .HasColumnType("character varying")
                .HasColumnName("cod_municipio");
            entity.Property(e => e.CodProvincia)
                .HasColumnType("character varying")
                .HasColumnName("cod_provincia");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
        });

        modelBuilder.Entity<TdcTchEstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tdc_tch_estado_pedidos_pkey");

            entity.ToTable("tdc_tch_estado_pedidos", "dwh_torrecontrol");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CodEstadoDevolucion)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_devolucion");
            entity.Property(e => e.CodEstadoEnvio)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_envio");
            entity.Property(e => e.CodEstadoPago)
                .HasColumnType("character varying")
                .HasColumnName("cod_estado_pago");
            entity.Property(e => e.CodLinea)
                .HasColumnType("character varying")
                .HasColumnName("cod_linea");
            entity.Property(e => e.CodPedido)
                .HasColumnType("character varying")
                .HasColumnName("cod_pedido");
            entity.Property(e => e.MdDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_date");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");

            entity.HasOne(d => d.CodEstadoDevolucionNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoDevolucion)
                .HasConstraintName("cod_estado_devolucion");

            entity.HasOne(d => d.CodEstadoEnvioNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoEnvio)
                .HasConstraintName("cod_estado_envio");

            entity.HasOne(d => d.CodEstadoPagoNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodEstadoPago)
                .HasConstraintName("cod_estado_pago");

            entity.HasOne(d => d.CodLineaNavigation).WithMany(p => p.TdcTchEstadoPedidos)
                .HasForeignKey(d => d.CodLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cod_linea");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
