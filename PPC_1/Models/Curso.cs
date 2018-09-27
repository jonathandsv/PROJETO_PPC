using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string TipoDeCurso { get; set; }
        public string Modalidade { get; set; }
        public string DenominacaoCurso { get; set; }
        public string Habilitacao { get; set; }
        public string LocalDeOferta { get; set; }
        public string TurnosDeFuncionamento { get; set; }
        public int NumerosDeVagasCadaTurno { get; set; }
        public int CargaHorariaDoCurso { get; set; }
        public int EstruturaCurricular { get; set; }
        public string RegimeLetivo { get; set; }
        public int Periodos { get; set; }
        public int CoordenadorCurso { get; set; }
    }
}