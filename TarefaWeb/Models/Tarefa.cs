using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarefaWeb.Models
{
    using inteiro = System.Int32;

    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a descrição de sua tarefa")]
        [Display(Name ="Descrição")]
        public string Nome { get; set; }

        public bool Concluida { get; set; } = false;

        public DateTime Data { get; set; }
    }
}