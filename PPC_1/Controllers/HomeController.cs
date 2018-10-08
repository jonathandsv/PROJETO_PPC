using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            return View();
        }

        public ActionResult ConsultarProfessor()
        {
            return View();
        }

        public ActionResult CadastroDisciplina()
        {
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
    }
}