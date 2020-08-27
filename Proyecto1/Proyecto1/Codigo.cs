using MongoDB.Driver;
using Proyecto1.Model;
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
                    case "2":
                        InsertarAdministrativo();
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

        private void InsertarAdministrativo()
        {
            Console.Write("Digite la institucion: ");
            var institution = Console.ReadLine();
            Console.Write("Digite el nombre: ");
            var name = Console.ReadLine();
            Console.Write("Digite la ciudad: ");
            var city = Console.ReadLine();
            Console.Write("Digite el email: ");
            var email = Console.ReadLine();
            Console.Write("Digite el lenguaje: ");
            var lenguage = Console.ReadLine();
            Console.Write("Digite la profesion: ");
            var profession = Console.ReadLine();
            Console.Write("Digite la edad: ");
            var age = Console.ReadLine();
            Console.Write("Digite el rol: ");
            var roles = Console.ReadLine();

            var administrativo = new Administrativos();
            administrativo.institution = institution;
            administrativo.information = new Information();
            administrativo.information.name = name;
            administrativo.information.city = city;
            administrativo.information.contacto = new List<Contacto>();
            var elContacto = new Contacto();
            elContacto.email = email;
            administrativo.lenguages = new string[] { lenguage };
            administrativo.profession = profession;
            administrativo.age = int.Parse(age);
            administrativo.roles = new string[] { roles };

            administrativo.information.contacto.Add(elContacto);
            var client = new Proyecto1.AccesoDatos.Conexion();
            client.InsertarAdministrativo(administrativo);



        }

        private void DesplegarMenu()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Listar las colecciones.");
            Console.WriteLine("2. Insertar administrativo.");
            Console.WriteLine("X.  Salir");
        }

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }
    }
}
