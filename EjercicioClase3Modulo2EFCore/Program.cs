using Microsoft.EntityFrameworkCore;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            ActorContext context = new ActorContext();

            
            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            
            var actores = context.Actores.ToList();
            
            Console.WriteLine("Listado de actores y actrices");
            foreach (var actor in actores)
            {
                Console.WriteLine($"{actor.Nombre} {actor.Apellido}");
            }

            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor
            
            var actrices = context.Actores.Where(a => a.Genero == "F").ToList();

            Console.WriteLine("Listado de actrices");
            foreach (var actriz in actrices)
            {
                Console.WriteLine($"{actriz.Nombre} {actriz.Apellido}");
            }
            #endregion

            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor

            var actoresMayores50 = context.Actores.Where(a => a.Edad > 50).ToList();
            
            Console.WriteLine("Listado de actores y actrices mayores de 50 años");
            foreach (var actor in actoresMayores50)
            {
                Console.WriteLine($"{actor.Nombre} {actor.Apellido}");
            }
            
            #endregion

            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"
            
            var edadJuliaRoberts = context.Actores.Where(a => a.Nombre == "Julia" && a.Apellido == "Roberts").Select(a => a.Edad).FirstOrDefault();

            Console.WriteLine($"La edad de Julia Roberts es {edadJuliaRoberts}");
            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.
            
            Actor nuevoActor = new Actor
            {
                Nombre = "Ricardo",
                Apellido = "Darin",
                Edad = 67,
                NombreArtistico = "Ricardo Darin",
                Nacionalidad = "Argentina",
                Genero = "M"
            };
            
            context.Actores.Add(nuevoActor);

            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.

            var cantidadActoresNoEstadounidenses = context.Actores.Where(a => a.Nacionalidad != "USA").Count();
            
             Console.WriteLine($"La cantidad de actores y actrices que no son de Estados Unidos es {cantidadActoresNoEstadounidenses}");
            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.
            
            var nombresActoresMasculinos = context.Actores.Where(a => a.Genero == "M").Select(a => new { a.Nombre, a.Apellido }).ToList();
            
            Console.WriteLine("Listado de actores masculinos");
            foreach (var actor in nombresActoresMasculinos)
            {
                Console.WriteLine($"{actor.Nombre} {actor.Apellido}");
            }
            
            #endregion
        }
    }
}