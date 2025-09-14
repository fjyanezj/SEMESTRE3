// Archivo: CatalogoRevistas.cs

using System;
using System.Collections.Generic;
using System.Linq;

// Clase principal del programa
public class CatalogoRevistas
{
    // Método para la búsqueda iterativa de una revista en la lista
    public static bool BuscarRevistaIterativo(List<string> catalogo, string tituloBuscado)
    {
        // Se itera sobre cada título en el catálogo
        foreach (string titulo in catalogo)
        {
            // Se compara el título actual con el título buscado, ignorando mayúsculas y minúsculas
            if (titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                // Si se encuentra, retorna verdadero
                return true;
            }
        }
        // Si no se encuentra después de revisar todo el catálogo, retorna falso
        return false;
    }

    // Método principal de la aplicación
    public static void Main(string[] args)
    {
        // Se crea una lista de strings para almacenar los títulos de las revistas
        List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Wired",
            "Forbes",
            "Time",
            "The New Yorker",
            "Vogue",
            "Scientific American",
            "Reader's Digest",
            "Rolling Stone",
            "PC Magazine"
        };

        Console.WriteLine("Bienvenido al Catálogo de Revistas.");

        while (true)
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Buscar una revista por título");
            Console.WriteLine("2. Salir");
            Console.Write("Por favor, seleccione una opción: ");

            // Se lee la opción del usuario
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("\nIngrese el título de la revista a buscar: ");
                    string tituloABuscar = Console.ReadLine();

                    // Se llama al método de búsqueda iterativa
                    bool encontrado = BuscarRevistaIterativo(catalogo, tituloABuscar);

                    // Se muestra el resultado de la búsqueda
                    if (encontrado)
                    {
                        Console.WriteLine($"\nEl título '{tituloABuscar}' ha sido encontrado en el catálogo.");
                    }
                    else
                    {
                        Console.WriteLine($"\nEl título '{tituloABuscar}' no ha sido encontrado en el catálogo.");
                    }
                    break;

                case "2":
                    Console.WriteLine("\nGracias por usar el catálogo. ¡Hasta luego!");
                    return; // Sale del programa

                default:
                    Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }
}
