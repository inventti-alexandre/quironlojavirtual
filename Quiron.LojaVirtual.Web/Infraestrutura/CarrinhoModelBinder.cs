using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder: System.Web.Mvc.IModelBinder
    {
        private const string SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            // obtenho o carrinho da sessao

            Carrinho carrinho = null;

            // obtenho o carrinho da sessao
            if (controllerContext.HttpContext.Session[SessionKey] != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }

            // crio o carrinho se nao tenho na sessao
            if (carrinho == null)
            {
                // o carrinho ainda nao existe na sessao
                carrinho = new Carrinho();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            // retorno o carrinho
            return carrinho;
        }
    }
}