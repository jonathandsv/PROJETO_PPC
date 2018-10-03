using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Ppc
    {
        public int Id { get; set; }
        public string Perfil_Do_Curso { get; set; }
        public string Perfil_Do_Egresso { get; set; }
        public string Forma_De_Acesso { get; set; }
        public int Represetacao_Grafica { get; set; }
        public string Sistema_Avaliacao { get; set; }
        public string TCC { get; set; }
        public string EstagioCurricular { get; set; }
        public string Pratica_Aten_PCD { get; set; }
    }
}