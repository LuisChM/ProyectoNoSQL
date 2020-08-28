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
                    case "3":
                        ActualizarCityAdministrativo();
                        break;
                    case "4":
                        ListarTodosLoAdministrativos();
                        break;
                    case "5":
                        ListarEmail();
                        break;
                    case "6":
                        ListeAdministrativosPorProfesion();
                        break;
                    case "7":
                        BorrarAdministrativo();
                        break;
                    case "8":
                        ListeProfesoresPorProfesion();
                        break;
                    case "9":
                        ListarNacimiento();
                        break;
                    default:
                        break;
                }
            }
        }

        //Listar todas las colecciones
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
        //Eliminar todo el registro de un administrativo
        private void BorrarAdministrativo()
        {
            Console.Write("Digite el nombre del admin: ");
            var elNombreDelAdministrativos = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            client.BorrarAdministrativo(elNombreDelAdministrativos);
        }



        //Insertar en la coleccion de Administrativos
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

        //Actualizar ciudad de coleccion administrativos
        private void ImprimirListadoDeAdministrativos(IList<Administrativos> laListaDeAdministrativos)
        {
            if (laListaDeAdministrativos.Count > 0)
            {
                Console.WriteLine("Lista de todos los administrativos:");
                var contador = 0;
                foreach (var admin in laListaDeAdministrativos)
                {
                    Console.WriteLine(string.Format("Administrativo número {3}: Id: {2}; Nombre: {0}; Ciudad: {1}; ", admin.information.name, admin.information.city, admin.AdminId, contador++.ToString()));
                }
            }
            else
                Console.WriteLine("No se encontró ningún administrativo.");
        }

        private void ActualizarCityAdministrativo()
        {
            Console.Write("Digite el nombre del admin: ");
            var elNombreDelAnimalito = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDeAdministrativos = client.ListarAdministrativosPorNombre(elNombreDelAnimalito);
            ImprimirListadoDeAdministrativos(laListaDeAdministrativos);
            Console.Write("Seleccione el número admin cuya ciudad desea cambiar: ");
            var elAdminSeleccionado = Console.ReadLine();
            var elNumeroDeAdministrativo = 0;
            if (int.TryParse(elAdminSeleccionado, out elNumeroDeAdministrativo))
            {
                if (elNumeroDeAdministrativo >= 0 && elNumeroDeAdministrativo < laListaDeAdministrativos.Count)
                {
                    var elRegistroDelAdministrativo = laListaDeAdministrativos[elNumeroDeAdministrativo];
                    Console.Write(string.Format("La ciudad actual del admin es [{0}]. Digite la nueva ciudad: ", elRegistroDelAdministrativo.information.city));
                    var elNuevoNombreDelAdmin = Console.ReadLine();
                    client.ActualizarCityAdministrativo(elRegistroDelAdministrativo.AdminId, elNuevoNombreDelAdmin);
                }
            }
        }


        private void ImprimirListadoDeAdministrativos2(IList<Administrativos> laListaDeAdministrativos)
        {
            if (laListaDeAdministrativos.Count > 0)
            {
                Console.WriteLine("Lista de todos los administrativos:");
                var contador = 0;
                foreach (var admin in laListaDeAdministrativos)
                {
                    Console.WriteLine(string.Format("Administrativo número {4}: Id: {3}; Age: {2}; Profession: {1}; Institucion: {0}; ", admin.institution, admin.profession, admin.age, admin.AdminId, contador++.ToString()));
                }
            }
            else
                Console.WriteLine("No se encontró ningún administrativo.");
        }
        private void ListarTodosLoAdministrativos()
        {
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDeAnimalitos = client.ListarTodosLoAdministrativos();
            ImprimirListadoDeAdministrativos2(laListaDeAnimalitos);
        }



        private void ImprimirListadoDeProfesores(IList<Profesores> laListaDeProfesores)
        {
            if (laListaDeProfesores.Count > 0)
            {
                Console.WriteLine("Lista de todos los profesores:");
                var contador = 0;
                foreach (var profe in laListaDeProfesores)
                {
                    Console.WriteLine(string.Format("Administrativo número {4}: Id: {3}; Age: {2}; Profession: {1}; Institucion: {0}; ", profe.work, profe.country, profe.email, profe.id, contador++.ToString()));
                }
            }
            else
                Console.WriteLine("No se encontró ningún profesor.");
        }

        private void ListeProfesoresPorProfesion()
        {
            Console.Write("Digite nombre de la profesion: ");
            var laProfesion = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDeProfesores = client.ListarProfesoresPorProfesion(laProfesion);
            ImprimirListadoDeProfesores(laListaDeProfesores);
        }

        //Coleccion Alumnos
        private void ImprimirListarEmail(IList<Alumnos> laListaDeEmail)
        {
            if (laListaDeEmail.Count > 0)
            {
                Console.WriteLine("Lista de emails:");
                var contador = 0;
                foreach (var correo in laListaDeEmail)
                {
                    Console.WriteLine(string.Format("Correo número {2}: Id: {1};  Email: {0} ", correo.email, correo.id.ToString(), contador++.ToString()));
                }
            }
            else
                Console.WriteLine("No se encontró ningún email.");
        }

        private void ListarEmail()
        {
            Console.Write("Digite el email: ");
            var elEmail = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDeEmail = client.ListarEmail(elEmail);
            ImprimirListarEmail(laListaDeEmail);
        }

        private void ImprimirListarNacimiento(IList<Alumnos> laListadenacimiento)
        {
            if (laListadenacimiento.Count > 0)
            {
                Console.WriteLine("Lista de Alumnos:");
                var contador = 0;
                foreach (var nacimiento in laListadenacimiento)
                {
                    Console.WriteLine(string.Format("Alumno número {2}: Id: {1};  Fecha de Nacimiento: {0} ", nacimiento.birth, nacimiento.id.ToString(), contador++.ToString()));
                }
            }
            else
                Console.WriteLine("No se encontró ningún Alumno.");
        }

        private void ListarNacimiento()
        {
            Console.Write("Digite la fecha de nacimiento: ");
            var nacimiento = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDenacimiento = client.ListarNacimiento(nacimiento);
            ImprimirListarNacimiento(laListaDenacimiento);
        }


        private void ListeAdministrativosPorProfesion()
        {
            Console.Write("Digite nombre del usuario: ");
            var laProfesion = Console.ReadLine();
            var client = new Proyecto1.AccesoDatos.Conexion();
            var laListaDeAdministrativos = client.ListarAdministrativosPorProfesion(laProfesion);
            ImprimirListadoDeAdministrativos(laListaDeAdministrativos);
        }



        private void DesplegarMenu()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Listar las colecciones.");
            Console.WriteLine("2. Insertar administrativo.");
            Console.WriteLine("3. Actualizar administrativo.");
            Console.WriteLine("4. Listar todo administrativo.");
            Console.WriteLine("5. Listar alumno por email.");
            Console.WriteLine("6. Listar los administrativos por profesion.");
            Console.WriteLine("7. Borrar registro de administrativos");
            Console.WriteLine("8. Listar profesores por profesion");
            Console.WriteLine("9. Listar alumno por fecha de nacimiento.");
            Console.WriteLine("X.  Salir");
        }

        private string LeaLaOpcion()
        {
            string elResultado = Console.ReadLine();
            return elResultado;
        }
    }
}
