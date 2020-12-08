using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adm_csharp.Models
{
    public class Conexao : DbContext
    {
        public Conexao(DbContextOptions<Conexao> opcoes) : base(opcoes)
        {

        }

        public DbSet<GrupoPessoa> GrupoPessoas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Formulario> Formularios { get; set; }

        public DbSet<PermissaoTela> PermissaoTelas { get; set; }

        public DbSet<Configuracao> Configuracaos { get; set; }

        public DbSet<Opcao> Opcaos { get; set; }

    }
}
