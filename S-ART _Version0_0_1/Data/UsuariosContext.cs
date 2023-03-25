using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_ART__Version0_0_1.Models;
using System.Collections.Generic;

namespace S_ART__Version0_0_1.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
