using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Edicao { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }
        public string Editora { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}