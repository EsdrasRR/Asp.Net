using EcommerceOsorioManha.Models;

namespace EcommerceOsorioManha.DAL
{
    public class SingletonContext
    {
        private static Context ctx;
        private SingletonContext() { }

        public static Context GetInstance()
        {
            if ( ctx == null)
            {
                ctx = new Context();
            }
            return ctx;
        }
    }
}