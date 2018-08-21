using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Utils
{
    public class Sessao
    {
        private static string Nome_Sessao = "CarrinhoId";

        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session[Nome_Sessao] == null )
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[Nome_Sessao] = guid.ToString();
            }
            return HttpContext.Current.Session[Nome_Sessao].ToString();
        }
    }
}