using System;
using System.Collections.Generic;

class Traductor
{
    static void Main()
    {
        // Diccionario base (Inglés -> Español y Español -> Inglés)
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese una frase: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].Trim(new char[] { '.', ',', ';', '!', '?' });
            string signo = palabras[i].Length > palabraLimpia.Length ? palabras[i].Substring(palabraLimpia.Length) : "";

            if (diccionario.ContainsKey(palabraLimpia))
            {
                palabras[i] = diccionario[palabraLimpia] + signo;
            }
        }

        Console.WriteLine("\nTraducción: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en idioma original: ");
        string palabraOrigen = Console.ReadLine();

        Console.Write("Ingrese la traducción: ");
        string traduccion = Console.ReadLine();

        if (!diccionario.ContainsKey(palabraOrigen))
        {
            diccionario[palabraOrigen] = traduccion;
            Console.WriteLine("Palabra agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}