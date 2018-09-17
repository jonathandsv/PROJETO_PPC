using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PPC_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cadastro_de_Curso()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ConsultarCurso()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CadastroPPC()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PPC()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CadastroProfessor()
        {
            ViewBag.Message = "Your contact page.";

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
    }
}