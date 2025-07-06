using System;
using System.Collections.Generic; // Necesario para List<T>

public class ListaUtils
{
    /// <summary>
    /// Calcula el número de elementos en una lista genérica recorriéndola.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la lista.</typeparam>
    /// <param name="lista">La lista de la cual se desea contar los elementos.</param>
    /// <returns>El número de elementos en la lista.</returns>
    public static int ContarElementosLista<T>(List<T> lista)
    {
        int contador = 0;
        foreach (T elemento in lista) // Itera sobre cada elemento de la lista
        {
            contador++; // Incrementa el contador por cada elemento
        }
        return contador;
    }

    // --- Ejemplos de uso ---
    public static void Main(string[] args)
    {
        // Lista de enteros
        List<int> miLista1 = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine($"La lista [{string.Join(", ", miLista1)}] tiene {ContarElementosLista(miLista1)} elementos.");

        // Lista de cadenas de texto
        List<string> miLista2 = new List<string> { "a", "b", "c" };
        Console.WriteLine($"La lista [{string.Join(", ", miLista2)}] tiene {ContarElementosLista(miLista2)} elementos.");

        // Lista vacía
        List<double> miListaVacia = new List<double>();
        Console.WriteLine($"La lista [{string.Join(", ", miListaVacia)}] tiene {ContarElementosLista(miListaVacia)} elementos.");

        // Lista mixta (aunque en C# las listas son de un tipo específico,
        // podemos simular una "mixta" si definimos Object como tipo)
        List<object> miListaMixta = new List<object> { 10, "hola", true, null, 3.14 };
        Console.WriteLine($"La lista [{string.Join(", ", miListaMixta)}] tiene {ContarElementosLista(miListaMixta)} elementos.");
    }
}