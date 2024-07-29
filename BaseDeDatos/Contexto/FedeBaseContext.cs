using System;
using System.Collections.Generic;
using BaseDeDatos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BaseDeDatos.Contexto;

public partial class FedeBaseContext : DbContext
{
    public FedeBaseContext()
    {
    }

    public FedeBaseContext(DbContextOptions<FedeBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<ClienteProveedor> ClienteProveedores { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<MovimientoDet> MovimientoDets { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ResponsabilidadFiscal> ResponsabilidadFiscales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FedeBase;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C528D8963C");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteProveedor>(entity =>
        {
            entity.HasKey(e => e.ClienteProveedorId).HasName("PK__ClienteP__2199C72B7735130E");

            entity.ToTable("ClienteProveedor");

            entity.Property(e => e.ClienteProveedorId).HasColumnName("ClienteProveedorID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cuit)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ResponsabilidadFiscalId).HasColumnName("ResponsabilidadFiscalID");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ResponsabilidadFiscal).WithMany(p => p.ClienteProveedors)
                .HasForeignKey(d => d.ResponsabilidadFiscalId)
                .HasConstraintName("FK__ClientePr__Respo__49C3F6B7");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__Movimien__BF923FCC9927F133");

            entity.ToTable("Movimiento");

            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.ClienteProveedorId).HasColumnName("ClienteProveedorID");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.ClienteProveedor).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.ClienteProveedorId)
                .HasConstraintName("FK__Movimient__Clien__4CA06362");
        });

        modelBuilder.Entity<MovimientoDet>(entity =>
        {
            entity.HasKey(e => e.MovimientoDetId).HasName("PK__Movimien__C5252DFB00870F2C");

            entity.ToTable("MovimientoDet");

            entity.Property(e => e.MovimientoDetId).HasColumnName("MovimientoDetID");
            entity.Property(e => e.MovimientoId).HasColumnName("MovimientoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Movimiento).WithMany(p => p.MovimientoDets)
                .HasForeignKey(d => d.MovimientoId)
                .HasConstraintName("FK__Movimient__Movim__5441852A");

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientoDets)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Movimient__Produ__5535A963");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE832948AE93");

            entity.ToTable("Producto");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioDolar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioPeso).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Producto__Catego__5165187F");
        });

        modelBuilder.Entity<ResponsabilidadFiscal>(entity =>
        {
            entity.HasKey(e => e.ResponsabilidadFiscalId).HasName("PK__Responsa__E1324E8E10DC5B71");

            entity.ToTable("ResponsabilidadFiscal");

            entity.Property(e => e.ResponsabilidadFiscalId).HasColumnName("ResponsabilidadFiscalID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
