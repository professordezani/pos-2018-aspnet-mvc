using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarefaWeb.Models;

namespace TarefaWeb.Controllers
{
    public class TarefasController : ApiController
    {
        public List<Tarefa> Get()
        {
            using(TarefaModel model = new TarefaModel())
            {
                return model.Read();
            }
        }

        public HttpResponseMessage Post([FromBody]Tarefa t)
        {
            if (ModelState.IsValid)
            {
                using (TarefaModel model = new TarefaModel())
                {
                    t.Data = DateTime.Now;
                    model.Create(t);
                    return Request.CreateResponse(HttpStatusCode.OK, "Cadastrado com sucesso");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, ModelState.Values);
            }
        }

        public Tarefa Get(int id)
        {
            using(TarefaModel model = new TarefaModel())
            {
                return model.Read(id);
            }
        }

        [HttpGet]
        [Route("api/tarefas/obtem/{id}")]
        public Tarefa Obtem(int id)
        {
            using (TarefaModel model = new TarefaModel())
            {
                return model.Read(id);
            }
        }
    }
}
