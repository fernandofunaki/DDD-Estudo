using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Adm.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Teste teste)
        {
            return View(teste);
        }


    }

    public class Teste
    {
        [Required(ErrorMessage="Informe o valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
    }
}
