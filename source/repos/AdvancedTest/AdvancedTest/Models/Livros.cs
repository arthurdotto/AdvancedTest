using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdvancedTest.Models
{
    [Table("Livros")]
    public class Livros
    {
        [Key]
        public int Numero_cadastro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Numero_de_paginas { get; set; }
        public string Ilustrado { get; set; }

    }
}