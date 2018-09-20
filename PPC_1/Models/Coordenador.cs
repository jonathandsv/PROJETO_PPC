using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Coordenador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string MaiorTitulacao { get; set; }
        public string AreaFormacao { get; set; }
        public string Curriculo { get; set; }
        public int DataAtualizacaoCurriculo { get; set; }
        public int IdPerfil { get; set; }
        public string Senha { get; set; }
    }
}