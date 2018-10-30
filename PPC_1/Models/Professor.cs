using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_1.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string MaiorTitulacao { get; set; }
        public string AreaFormacao { get; set; }
        public string CurriculoLattos { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int HorasNde { get; set; }
        public int OrientacaoTcc { get; set; }
        public int AtividadesExtraClasseNoCurso { get; set; }
        public int AtividadesExtraClasseOutrosCursos { get; set; }
        public int CoordenacaoCurso { get; set; }
        public int CoordenacaoOutrosCursos { get; set; }
        public int QtdeHorasCurso { get; set; }
        public int QtdeHorasOutrosCursos { get; set; }
        public int Pesquisa { get; set; }
        public int IdDisciplina { get; set; }
        public int IdDisciplinaOutrosCursos { get; set; }
        public bool MembroNde { get; set; }
        public bool MembroColegiado { get; set; }
        public bool DocenteFormacao { get; set; }
        public bool TempoDeVinculoIniterrupto { get; set; }
        public bool TempoMagisterioSuperior { get; set; }
        public bool ExperienciaEmCursoADistacia { get; set; }
        public bool TempoExperienciaProfissional { get; set; }
        public int QtdeParticipacoesEventos { get; set; }
        public int ArtigosPublicadosPeriodosCientikficosNaArea { get; set; }
        public int ArtigosPublicadosPeriodosCientificosOutrasAreas { get; set; }
        public int LivrosPublicadosNaArea { get; set; }
        public int LivrosPublicadosEmOutrasAreas { get; set; }
        public int TrabalhosCompletosPublicadosAnuaisNaArea { get; set; }
        public int TrabalhosResumosPublicadosAnuaisNaArea { get; set; }
        public int PropriedadeintelectualDepositado { get; set; }
        public int PropriedadeIntelectualRegistrado { get; set; }
        public int TraducaoDeLivrosCapitulosArtigosPublicados { get; set; }
        public int ProjetosProducoesTecnicosArtisticosCulturais { get; set; }
        public int ProducaoDidaticoPedagogicoRelevante { get; set; }
    }
}