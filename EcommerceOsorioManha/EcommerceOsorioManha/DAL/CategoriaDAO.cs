using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class CategoriaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static List<Categoria> RetornarCategorias()
        {
            return ctx.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {

                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static void RemoverCategoria(int? id)
        {
            try
            {
                ctx.Categorias.Remove(BuscarCategoriaPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return ctx.Categorias.Find(id);

        }

        public static void AlterarCategoria(Categoria categoria)
        {

            try
            {
                ctx.Entry(categoria).State = EntityState.Modified;
                ctx.SaveChanges();

            }
            catch (Exception)
            {
            }
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return ctx.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }

    }
}