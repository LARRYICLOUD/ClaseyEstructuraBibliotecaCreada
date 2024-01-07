using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseyEstructuraBibliotecaCreada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YO SOY UN PROGRAMADOR Y EXPERTO EN REDES EXCELENTE Y RECONOCIDO");

            //Variables locales
            bool repetir = true; //Se encargara de repetir el menu hasta que nosotros decidamos salir del prograna
            string opcion;
            //Creamos una instancia de la clase Biblioteca
            Biblioteca biblioteca1 = new Biblioteca();

            do
            {
                Console.WriteLine("\nBiblioteca\n");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Mostrar todos los libros");
                Console.WriteLine("3. Busqueda exacta de un libro");
                Console.WriteLine("4. Busqueda parcial de un libro");
                Console.WriteLine("5. Eliminar un libro");
                Console.WriteLine("6. Salir");

                Console.Write("\nIngresar una opcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1": //Agregar un nuevo libro
                        biblioteca1.AgregarLibro();
                        break;
                        case "2": //Mostrar una lista de libros
                        biblioteca1.MostrarLibros();
                        break;
                    case "3": //Busqueda exacta
                        biblioteca1.BuscarLibro();
                        break;
                        case "4": //Busqueda parcial d eun libro
                        biblioteca1.BusquedaParcial();
                        break;
                    case "5": //Eliminar libro
                        biblioteca1.EliminarLibro();
                        break; 
                        
                        case "6": // Finalizar el programa
                        repetir = false;  // El bucle se repite mientras "repetir == true", por lo tanto, esta instruccion nos sacara del programa
                        break;
                    default:
                        Console.WriteLine("\n¡Opcion invalida, intenta de nuevo!\n");
                        break;



                }



            } while (repetir);
        }
    }
    class Biblioteca
    {
        //Campos
        Libro[] libros; //Declaramos una matriz de tipo struct "Libro"       
        int cantidadLibros = 0; //No existen libros al inicio del programa
        string buscarLibro;
        bool libroEncontrado;
        int posicionLibroEliminar;

        //Constructor
        public Biblioteca() //Constructor siempre debe ser publico para poder acceder a el
        {
            libros = new Libro[1000]; //Inicializamos la matriz con una capacida de mil elementos
        }
         //metodos para interactuar con los libros
         public void AgregarLibro()
        {
            if(cantidadLibros < libros.Length) //Verificar si podemos ingresar un nuevo libro en la matriz
            {
                Console.Clear();

                Console.WriteLine($"Ingresar informacion para el libro {cantidadLibros + 1}\n");//Decimos +1 para mostrar un indice que el usuario entienda

                Console.Write("Ingresa el nombre del libro: ");
                libros[cantidadLibros].Titulo = Console.ReadLine();
                Console.Write("Ingresa el autor: ");
                libros[cantidadLibros].Autor = Console.ReadLine();
                Console.Write("Ingresa el año: ");
                libros[cantidadLibros].Año = Console.ReadLine();

                cantidadLibros++; //Aumentamos la cantidad de libros existentes

                Console.Clear();
                Console.WriteLine("¡Libro agregado correctamente!\n");
            }
            else 
            {
                //En caso que excedamos el numero de libros, mostramos este mensaje
                Console.WriteLine("¡Biblioteca llena! Intenta eliminar un libro");
            }


         }

        public void MostrarLibros()
        {
            Console.Clear();

            if(cantidadLibros == 0)
            {
                //Si no existe ningun libro, mostramos el siguiente mensaje
                Console.WriteLine("¡Biblioteca vacia! Agrega libros para poder  visualizar");

            }
            else
            {
                for(int i=0; i < cantidadLibros; i++) //Si existe al menos uno mostramos su informacion
                {
                    Console.WriteLine($"{i + 1}.- Titulo = {libros[i].Titulo}, Autor = {libros[i].Autor}, Año = {libros[i].Año }");

                }
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();

                Console.WriteLine();
            }
        }

        public void BuscarLibro()
        {
            Console.Clear();
            Console.Write("Ingresa el nombre del libro para buscarlo: ");
            buscarLibro = Console.ReadLine();
            libroEncontrado = false; //Iniciamos al campo en "false" para indicar que al iniciar el recorrido por la matriz no hemos encontrado un libro
            for(int i = 0; i < cantidadLibros; i++)
            {
                if (libros[i].Titulo.Equals(buscarLibro))
                {
                    Console.WriteLine($"El libro \"{libros[i].Titulo}\" del autor(a): \"{libros[i].Autor}\" se encuentra disponible en la biblioteca en el indice; {i+1}");
                    libroEncontrado = true; //Asignamos "true" para indicar que hemos encontrado el libro, y asi evitar en el siguiente "if"                                         
                }
                
            }
            if (!libroEncontrado) //Lo mismo que colocar if(libroEncontrado == false)
            {
                Console.WriteLine("¡Libro no encontrado!\n");
            }

        }

        public void BusquedaParcial()
        {
            Console.Clear();

            Console.Write("Ingresa al menos una parte del titulo o del nombre del autor de un libro para buscarlo:  ");
            buscarLibro = Console.ReadLine().ToLower();
                libroEncontrado = false; //Inicializamos la variable en "false" para indicar que al iniciar el recorrido por la matriz no hemos encontrado un libro ;
            for(int i = 0;i < cantidadLibros; i++)
            {
                if (libros[i].Titulo.ToLower().Contains(buscarLibro) || libros[i].Autor.ToLower().Contains(buscarLibro))
                        
                {
                    Console.WriteLine($"La palabra\"{buscarLibro}\"Fue encontrada en el libro: \"{libros[i].Titulo}\" del autor(a) \" {libros[i].Autor}\" en el indice: {i + 1}");
                    libroEncontrado = true; //Asignamos "true" para indicar que hemos encontrado el libro, y asi evitar entrar en el siguiente "if"
                }

            }
     
        
        
        }

        public void EliminarLibro()
        {
            Console.Clear();
            if(cantidadLibros == 0)
            {
                Console.WriteLine("!La biblioteca esta vacia, no hay nada que eliminar!");
            }
            else
            {
                Console.WriteLine($"Ingrese el numero de libro que desea eliminar (Del 1 al {cantidadLibros}): ");
                posicionLibroEliminar = Convert.ToInt32(Console.ReadLine()) - 1; //Decimos que es -1 para que el indice ingresado por el usuario coincuida con el indice real de la matriz
                //Verificamos que el numero ingresado sea valido
                if(posicionLibroEliminar >= 0 && posicionLibroEliminar < cantidadLibros)
                {
                    //Confirmamos si el libro que ingreso es el que quiere eliminar
                    Console.Write($"¿El libro que deseas eliminar es: \"{libros[posicionLibroEliminar].Titulo}\"?(Si/No):");
                    string opcion = Console.ReadLine().ToLower();

                    if(opcion == "si")
                    {
                        //Variables para mostrar un mensaje de cual fue el libro eliminado
                        string tituloEliminado = libros[posicionLibroEliminar].Titulo;
                        string autorEliminado = libros[posicionLibroEliminar].Autor;

                        for(int i = posicionLibroEliminar; i< cantidadLibros; i++)
                        {
                            libros[i] = libros[i + 1];
                        }
                        cantidadLibros--; //Reducimos la cantidad de libros en uno, por el que acabamos de eliminar

                        //le mkostramos al usuario el libro que se elimino
                        Console.WriteLine($"\n¡El libro \"{tituloEliminado}\" del autor(a): \"{autorEliminado}\"fue eliminado!");


                    }
                    else
                    {
                        Console.WriteLine("operacion \"eliminar libro\"cancelada");
                    }


                }
                else
                {
                    Console.WriteLine("¡El numero del libro no es valido!");
                }
            }

        }



    }

}

    struct Libro
    {
        //Campos
        string titulo;
        string autor;
        string año;

        //Propiedades
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Año { get => año; set => año = value; }
        

    }

