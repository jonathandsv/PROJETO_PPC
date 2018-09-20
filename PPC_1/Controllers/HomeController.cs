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
            

            return View();
        }

        public ActionResult ConsultarCurso()
        {

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
    }
}