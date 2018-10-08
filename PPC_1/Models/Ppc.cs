using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Ppc
    {
        public int Id { get; set; }
        public string PerfilDoCurso { get; set; }
        public string PerfilDoEgresso { get; set; }
        public string FormaDeAcesso { get; set; }
        public string RepresentacaoGrafica { get; set; }
        public string SistemaAvaliacaoEnsinoAprendizagem { get; set; }
        public string SistemaAvaliacaoCurso { get; set; }
        public string TCC { get; set; }
        public string EstagioCurricular { get; set; }
        public string PraticaAtenPCD { get; set; }
        public int IdCurso { get; set; }
    }
}