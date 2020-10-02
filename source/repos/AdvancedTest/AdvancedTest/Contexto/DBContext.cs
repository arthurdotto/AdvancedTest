using AdvancedTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AdvancedTest.Contexto
{
    public class DBContext : DbContext
    {

        public DbSet<Livros> Livros { get; set; }

    }
}