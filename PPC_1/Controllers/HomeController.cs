using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PPC_1.Models;

namespace PPC_1.Controllers
{
    public class HomeController : Controller
    {
        //Chamada de páginas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro_de_Curso()
        {

            PreencheViewBagListaCoordenadores();
            return View();
        }

        private void PreencheViewBagListaCoordenadores()
        {
            PPCDB coordenadores = new PPCDB();

            List<Coordenador> ListaDeCoodenadores = coordenadores.BuscarCoordenadores();

            ViewBag.ListaDeCoordenadores = ListaDeCoodenadores;
        }

        private void PreencheViewBagListaCursos()
        {
            PPCDB cursos = new PPCDB();

            List<Curso> ListaDecursos = cursos.BuscarCursos();
            ViewBag.ListaDeCursos = ListaDecursos;
        }

        private void PreencheViewBagListaPPCs()
        {
            PPCDB ppcs = new PPCDB();
            List<Ppc> ListaDePpcs = ppcs.BuscarPpcs();
            ViewBag.ListaDePpcs = ListaDePpcs;
        }

        private void PreencheViewBagListaDisciplinas()
        {
            PPCDB disciplinas = new PPCDB();
            List<Disciplina> ListaDeDisciplinas = disciplinas.BuscarDisciplinas();
            ViewBag.ListaDeDisciplinas = ListaDeDisciplinas;
        }

        private void PreencheViewBagListaCronogramas()
        {
            PPCDB cronograma = new PPCDB();
            List<Cronograma> ListaDeCronogramas = cronograma.BuscarCronogramas();
            ViewBag.ListaDeCronogramas = ListaDeCronogramas;
        }

        private void PreencheViewBagListaDisciplinasFiltradas()
        {
            PPCDB disciplinas = new PPCDB();
            List<Disciplina> ListaDeDisciplinas = disciplinas.BuscarDisciplinasFiltradas();
            ViewBag.ListaDeDisciplinasF = ListaDeDisciplinas;
        }
        public ActionResult ConsultarCurso()
        {
            PreencheViewBagListaCursos();
            return View();
        }

        public ActionResult CadastroPPC()
        {
            PreencheViewBagListaCursos();
            return View();
        }

        public ActionResult PPC()
        {
            PreencheViewBagListaPPCs();
            return View();
        }

        public ActionResult CadastroProfessor()
        {
            PreencheViewBagListaDisciplinasFiltradas();
            return View();
        }

        public ActionResult ConsultarProfessor()
        {
            return View();
        }

        public ActionResult CadastroDisciplina()
        {
            PreencheViewBagListaCursos();
            return View();
        }

        public ActionResult ConsultarDisciplina()
        {
            PreencheViewBagListaCursos();
            PreencheViewBagListaDisciplinas();
            return View();
        }

        public ActionResult MatrizCurricular()
        {
            PreencheViewBagListaDisciplinasFiltradas();
            PreencheViewBagListaCursos();
            return View();
        }

        public ActionResult CadastrarBibliografia()
        {
            PreencheViewBagListaCursos();
            PreencheViewBagListaDisciplinas();
            return View();
        }

        public ActionResult CadastrarCronograma()
        {

            return View();
        }

        public ActionResult ConsultarCronograma()
        {
            PreencheViewBagListaCronogramas();

            return View();
        }

        //Fim da chamada de páginas 

        public ActionResult NovoCurso(Curso curso)
        {
            PPCDB pPCDB = new PPCDB();
            curso = pPCDB.InserirCurso(curso);
            PreencheViewBagListaCursos();
            return View("ConsultarCurso");
        }

        public ActionResult AtualizarCurso(Curso curso)
        {
            PPCDB pPCDB = new PPCDB();
            curso = pPCDB.atualizarCurso(curso);
            PreencheViewBagListaCursos();
            return View ("ConsultarCurso");
        }
        
        public ActionResult excluirCurso(int id)
        {
            PPCDB pPCDB = new PPCDB();
            pPCDB.excluirCurso(id);
            PreencheViewBagListaCursos();
            return View("ConsultarCurso");
        }

        public JsonResult BuscarCursos(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Curso curso = pPCDB.BuscarCursos(id);
            return Json(curso, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarCursosT()
        {
            PPCDB pPCDB = new PPCDB();
            List<Curso> cursos = pPCDB.BuscarCursos();
            return Json(cursos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NovoPPC(Ppc ppc)
        {
            PPCDB pPCDB = new PPCDB();
            ppc = pPCDB.InserirPpc(ppc);
            PreencheViewBagListaCursos();
            return  View("PPC");
        }

        public ActionResult excluirPPC(int id)
        {
            PPCDB pPCDB = new PPCDB();
            pPCDB.excluirPPC(id);
            PreencheViewBagListaPPCs();
            return View("PPC");
        }
        public JsonResult BuscarPpc(int id)
        {
            Ppc retorno = new Ppc();
           PPCDB pPCDB = new PPCDB();
            Ppc ppc = new Ppc();
            ppc = pPCDB.BuscarPpcs(id);
            var ppcid = ppc.IdCurso; 
            if (id == ppcid)
            {
               retorno.Id = 1;
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuscarPpcT(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Ppc ppc = new Ppc();
            ppc = pPCDB.BuscarPpcs(id);

            return Json(ppc, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AtualizarPPC(Ppc ppc)
        {
            PPCDB pPCDB = new PPCDB();
            ppc = pPCDB.atualizarPpc(ppc);
            PreencheViewBagListaCursos();
            PreencheViewBagListaPPCs();
            return View("PPC");
        }
        public JsonResult BuscarCoordenador(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Coordenador coordenador = new Coordenador();
            coordenador = pPCDB.BuscarCoordenadores(id);

            return Json(coordenador, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarCoordenadores()
        {
            PPCDB pPCDB = new PPCDB();
            List<Coordenador> coordenadores = new List<Coordenador>();
            coordenadores = pPCDB.BuscarCoordenadores();

            return Json(coordenadores, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NovaDisciplina(Disciplina dis)
        {
            PPCDB pPCDB = new PPCDB();
            Disciplina disciplina = pPCDB.InserirDisciplina(dis);

            PreencheViewBagListaCursos();
            PreencheViewBagListaDisciplinas();
            return View("ConsultarDisciplina");
        }

        public ActionResult excluirDisciplina(int id)
        {
            PPCDB pPCDB = new PPCDB();
            pPCDB.excluirDisciplina(id);
            PreencheViewBagListaCursos();
            PreencheViewBagListaDisciplinas();
            return View("ConsultarDisciplina");
        }

        public  JsonResult NovaDisciplinaMatriz(int idDisciplina, int idCurso)
        {
            PPCDB pPCDB = new PPCDB();
            List<CursoDisciplina> disciplinas = pPCDB.BuscarDisciplinasVinculadas(idDisciplina, idCurso);
            

            bool retorno = false;
            int tamanho = disciplinas.Count;
            if (tamanho == 0)
            {
                CursoDisciplina cursoDisciplina1 = new CursoDisciplina();
                cursoDisciplina1.IdDisciplina = idDisciplina;
                cursoDisciplina1.IdCurso = idCurso;
                CursoDisciplina cursoDisciplina = pPCDB.VincularDisciplinaCurso(cursoDisciplina1);

                retorno = true;
            }

            //for (int i = 0; i < disciplinas.Count; i++)
            //{
            //    if (disciplinas[i].IdCurso != idCurso)
            //    {

            //    }

            //}

            //bool retorno = false;
            //if (disciplina.IdCurso != idCurso)
            //{
            //    disciplina.IdCurso = idCurso;
            //    pPCDB.InserirDisciplina(disciplina);
            //    retorno = true;
            //}

            return Json(retorno);
        }

        public JsonResult BuscarDisciplinas(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Disciplina disciplina = new Disciplina();
            disciplina = pPCDB.BuscarDisciplinas(id);

            return Json(disciplina, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AtualizarDisciplina(Disciplina disciplina)
        {
            PPCDB pPCDB = new PPCDB();
            disciplina = pPCDB.atualizarDisciplina(disciplina);
            PreencheViewBagListaCursos();
            return View("ConsultarDisciplina");
        }

        public JsonResult BuscarDisciplinaVinculadaCurso(int idC, int idD)
        {
            PPCDB pPCDB = new PPCDB();
            List<CursoDisciplina> cursodisciplinas = pPCDB.BuscarDisciplinasVinculadas(idC, idD);
            //precisa chamar os outro método para saber o nome da disciplina
            List<Disciplina> disciplinas = pPCDB.BuscarPropriedadesDasDisciplinasVinculadas(cursodisciplinas);

            return Json(disciplinas);
        }

        public ActionResult NovoCronograma(Cronograma cronograma)
        {
            PPCDB pPCDB = new PPCDB();
            Cronograma InserirCronograma = pPCDB.InserirCronograma(cronograma);
            PreencheViewBagListaCronogramas();

            return View("ConsultarCronograma");
        }

        public JsonResult BuscarCronograma(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Cronograma cronograma = new Cronograma();
            cronograma = pPCDB.BuscarCronograma(id);

            return Json(cronograma, JsonRequestBehavior.AllowGet);
        }

        public ActionResult excluirCronograma(int id)
        {
            PPCDB pPCDB = new PPCDB();
            pPCDB.excluirCronograma(id);
            PreencheViewBagListaCronogramas();
            return View("ConsultarCronograma");
        }

        public ActionResult AtualizarCronograma(Cronograma cronograma)
        {
            PPCDB pPCDB = new PPCDB();
            cronograma = pPCDB.atualizarCronograma(cronograma);
            PreencheViewBagListaCronogramas();
            return View("ConsultarCronograma");
        }

        public JsonResult CadastrarProfessorAtuacaoIesDadosPessoais(string professor)
        {
            PPCDB pPCDB = new PPCDB();

            var ProfessorConvertido = JsonConvert.DeserializeObject<Professor>(professor);

            string nome = ProfessorConvertido.Nome;

            Professor professorB = new Professor();

            professorB = pPCDB.BuscarUsuarioNome(nome);

            Professor professorRetorno = new Professor();

            if (professorB.Nome == null)
            {
                professorB = pPCDB.InserirProfessor(ProfessorConvertido);
            }

            professorRetorno = pPCDB.BuscarUsuarioNome(ProfessorConvertido.Nome);

            return Json(professorRetorno);

        }

        public JsonResult CadastrarProfessorAtuacaoIesGeral(string professor)
        {
            PPCDB pPCDB = new PPCDB();

            var ProfessorConvertido = JsonConvert.DeserializeObject<Professor>(professor);

            Professor professorB = new Professor();

            professorB = pPCDB.InserirProfessorIesAtuacaoGeral(ProfessorConvertido);


            return (null);
        }

        public JsonResult CadastrarProfessorAtuacaoIesAtuacaoProfissional(string professor)
        {
            PPCDB pPCDB = new PPCDB();

            var ProfessorConvertido = JsonConvert.DeserializeObject<Professor>(professor);





            return (null);
        }
    }
}