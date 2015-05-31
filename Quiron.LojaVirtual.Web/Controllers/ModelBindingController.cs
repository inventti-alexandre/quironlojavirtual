using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar()
        {
            var produto = new Produto();
            TryUpdateModel(produto);
            if (ModelState.IsValid)
            {
                ViewBag.Status = "Produto válido";
            }
            else
            {
                ViewBag.Status = "Produtos inválido";
            }
            return RedirectToAction("Index");
        }
    }
}