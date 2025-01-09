using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Citas.Administrador.Modelos;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Citas.Administrador.DAL
{
    // Solo una clase BDConexion, asegúrate de no duplicarla
    public class BDConexion : DbContext
    {
        // Define las entidades del modelo
        public DbSet<Clientes> Clientes { get; set; } = null!;  // Añadido null! para suprimir el aviso de CS8618
        public DbSet<CitasModel> Citas { get; set; } = default!;
        public DbSet<AsesoresModel> Asesores { get; set; } = default!;
        public DbSet<empresaModel> Empresas { get; set; } = default!;
        public DbSet<ProductosModel> Productos { get; set; } = default!;
        public DbSet<CitasDetModel> CitasDet { get; set; } = default!;
        public DbSet<userModel> registeredusers { get; set; }

        // Constructor: asegurate de no tener más de un constructor con los mismos parámetros
        public BDConexion(DbContextOptions<BDConexion> options) : base(options) { }

        // Método OnModelCreating: asegurate de que solo haya una definición
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de las tablas y relaciones
            modelBuilder.Entity<Clientes>().ToTable("clientes", schema: "dbo");
            modelBuilder.Entity<empresaModel>().ToTable("empresas", schema: "dbo");

            modelBuilder.Entity<ProductosModel>().ToTable("productos", schema: "dbo")
                .HasOne(c => c.Empresa)
                .WithMany()
                .HasForeignKey(c => c.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AsesoresModel>().ToTable("Asesores", schema: "dbo");

            modelBuilder.Entity<CitasModel>()
                .HasOne(c => c.Asesor)
                .WithMany()
                .HasForeignKey(c => c.AsesorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CitasDetModel>()
                .HasOne(c => c.Citas)
                .WithMany()
                .HasForeignKey(c => c.IdCitaDet)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CitasDetModel>()
                .HasOne(c => c.Productos)
                .WithMany()
                .HasForeignKey(c => c.Producto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
