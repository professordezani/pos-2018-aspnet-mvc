using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarefaWeb.Models;

namespace TarefaWeb.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet]
        // GET: Tarefa
        public ActionResult Index()
        {
            using (TarefaModel model = new TarefaModel())
            {
                List<Tarefa> lista = model.Read();                
                return View(lista);

            } //model.Dispose();
        }

        [HttpPost]
        [Route("/teste")]
        // GET: Tarefa
        public ActionResult Index(int id)
        {
            using (TarefaModel model = new TarefaModel())
            {
                List<Tarefa> lista = model.Read();
                return View(lista);

            } //model.Dispose();
        }
    }
}