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
        public ActionResult ConsultarCurso()
        {
            PreencheViewBagListaCursos();
            return View();
        }

        public ActionResult CadastroPPC()
        {

            return View();
        }

        public ActionResult PPC()
        {

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
            return(null);
        }

        public JsonResult BuscarCoordenador(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Coordenador coordenador = new Coordenador();
            coordenador = pPCDB.BuscarCoordenadores(id);

            return Json(coordenador, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarCursos(int id)
        {
            PPCDB pPCDB = new PPCDB();
            Curso curso = pPCDB.BuscarCursos(id);
            return Json(curso, JsonRequestBehavior.AllowGet);
        }
    }
}