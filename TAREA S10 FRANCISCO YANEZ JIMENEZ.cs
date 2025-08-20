using System;
using System.Collections.Generic;
using System.Linq;

public class Ciudadano
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // Podrían añadirse más propiedades como Cédula, Edad, etc.
}

public class CampanaVacunacion
{
    public static void Main(string[] args)
    {
        // 1. Crear conjuntos ficticios
        var universoCiudadanos = new HashSet<Ciudadano>();
        for (int i = 1; i <= 500; i++)
        {
            universoCiudadanos.Add(new Ciudadano { Id = i, Nombre = $"Ciudadano_{i}" });
        }

        var vacunadosPfizer = new HashSet<Ciudadano>();
        // Asumiendo que los primeros 75 ciudadanos se vacunaron con Pfizer
        var ciudadanosPfizer = universoCiudadanos.Take(75).ToList();
        foreach (var c in ciudadanosPfizer)
        {
            vacunadosPfizer.Add(c);
        }

        var vacunadosAstraZeneca = new HashSet<Ciudadano>();
        // Asumiendo que los ciudadanos 51 a 125 se vacunaron con AstraZeneca (para crear una intersección)
        var ciudadanosAstraZeneca = universoCiudadanos.Skip(50).Take(75).ToList();
        foreach (var c in ciudadanosAstraZeneca)
        {
            vacunadosAstraZeneca.Add(c);
        }

        // 2. Aplicar operaciones de teoría de conjuntos
        Console.WriteLine("Generando listados de vacunación...\n");

        // Listado 1: Ciudadanos que no se han vacunado
        var vacunadosUnion = new HashSet<Ciudadano>(vacunadosPfizer);
        vacunadosUnion.UnionWith(vacunadosAstraZeneca);
        var noVacunados = new HashSet<Ciudadano>(universoCiudadanos);
        noVacunados.ExceptWith(vacunadosUnion);

        Console.WriteLine($"1. Ciudadanos que no se han vacunado ({noVacunados.Count}):");
        foreach (var c in noVacunados.Take(5)) // Mostrar solo los primeros 5 para ejemplo
        {
            Console.WriteLine($"- {c.Nombre}");
        }
        Console.WriteLine("...");

        // Listado 2: Ciudadanos que han recibido ambas dosis
        var ambasDosis = new HashSet<Ciudadano>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);

        Console.WriteLine($"\n2. Ciudadanos que han recibido ambas dosis ({ambasDosis.Count}):");
        foreach (var c in ambasDosis.Take(5))
        {
            Console.WriteLine($"- {c.Nombre}");
        }
        Console.WriteLine("...");
        
        // Listado 3: Ciudadanos que solo han recibido la vacuna de Pfizer
        var soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer);
        soloPfizer.ExceptWith(ambasDosis);

        Console.WriteLine($"\n3. Ciudadanos que solo han recibido la vacuna de Pfizer ({soloPfizer.Count}):");
        foreach (var c in soloPfizer.Take(5))
        {
            Console.WriteLine($"- {c.Nombre}");
        }
        Console.WriteLine("...");

        // Listado 4: Ciudadanos que solo han recibido la vacuna de AstraZeneca
        var soloAstraZeneca = new HashSet<Ciudadano>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(ambasDosis);

        Console.WriteLine($"\n4. Ciudadanos que solo han recibido la vacuna de AstraZeneca ({soloAstraZeneca.Count}):");
        foreach (var c in soloAstraZeneca.Take(5))
        {
            Console.WriteLine($"- {c.Nombre}");
        }
        Console.WriteLine("...");
    }
}