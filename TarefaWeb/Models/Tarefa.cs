using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarefaWeb.Models
{
    using inteiro = System.Int32;

    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        public DateTime Data { get; set; }
    }
}