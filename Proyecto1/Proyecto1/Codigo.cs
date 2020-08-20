using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Proyecto1.Model;
//using Proyecto1.Model.Model;

namespace Proyecto1
{
   public class Codigo
    {
        public void Codigo01()
        {
            var laOpcion = string.Empty;
            while (laOpcion != "X")
            {
                DesplegarMenu();
                laOpcion = LeaLaOpcion();
                switch (laOpcion)
                {
                    case "1":
                        ListaColecciones();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ListaColecciones()
        {
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laBaseDeDatos = client.ConectarDB();
            var laListaDeColecciones = client.ListarTodasLasColeciones(laBaseDeDatos);

            Console.WriteLine("Lista de colecciones in the database:");
            foreach (var collection in laListaDeColecciones.ToList())
            {
                Console.WriteLine(collection.ToString());
            }
        }

        private void DesplegarMenu()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Listar las colecciones.");
            Console.WriteLine("X.  Salir");
        }

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }
    }
}
