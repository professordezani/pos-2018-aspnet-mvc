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

        public JsonResult Lista()
        {
            using (TarefaModel model = new TarefaModel())
                return Json(model.Read(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tarefa t)
        {
            if (ModelState.IsValid)
            {
                t.Concluida = false;
                t.Data = DateTime.Now;

                using (TarefaModel model = new TarefaModel())
                {
                    model.Create(t);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Erro = "Preencha a descrição da tarefa.";
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            using(TarefaModel model = new TarefaModel())
            {
                return View(model.Read(id));
            }
        }

        [HttpPost]
        public ActionResult Update(int id, Tarefa t)
        {
            if(ModelState.IsValid)
            {
                using(TarefaModel model = new TarefaModel())
                {
                    model.Update(t);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(t);
            }
        }

        public ActionResult Delete(int id)
        {
            using(TarefaModel model = new TarefaModel())
            {
                model.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}