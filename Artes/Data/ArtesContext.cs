using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Artes.Data
{
    public class ArtesContext : IdentityDbContext<Usuario>
    {
        public ArtesContext (DbContextOptions<ArtesContext> options): base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<TipoObra> TipoObras { get; set; }
        public DbSet<Obra> Obras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Cidade>().HasData(new Cidade
            {
                Id = 1,
                Nome = "Barra Bonita",
                Estado = "SP"
            }, new Cidade
            {
                Id = 2,
                Nome = "Igaraçu do Tietê",
                Estado = "SP"
            }, new Cidade
            {
                Id = 3,
                Nome = "Bauru",
                Estado = "SP"
            }, new Cidade
            {
                Id = 4,
                Nome = "Macatuba",
                Estado = "SP"
            }, new Cidade
            {
                Id = 5,
                Nome = "Pederneiras",
                Estado = "SP"
            }, new Cidade
            {
                Id = 6,
                Nome = "Lençois Paulista",
                Estado = "SP"
            });

            modelBuilder.Entity<TipoObra>().HasData(new TipoObra
            {
                Id = 1,
                Nome = "Fotografia"
            }, new TipoObra
            {
                Id = 2,
                Nome = "Artes Plásticas"
            }, new TipoObra
            {
                Id = 3,
                Nome = "Escultura"
            }, new TipoObra
            {
                Id = 4,
                Nome = "Pintura"
            }, new TipoObra
            {
                Id = 5,
                Nome = "Modelagem 3D"
            });

            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            modelBuilder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Artista",
                NormalizedName = "ARTISTA"
            });

            var hasher = new PasswordHasher<Usuario>();
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = ADMIN_ID,
                Nome = "Admin",
                UserName = "admin@arteweb.com.br",
                NormalizedUserName = "ADMIN@ARTEWEB.COM.BR",
                Email = "admin@arteweb.com.br",
                NormalizedEmail = "ADMIN@ARTEWEB.COM.BR",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = hasher.GetHashCode().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }
}
