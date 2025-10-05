using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 

// ====================================================================
// 1. CLASE VUELO: Representa la estructura de un registro de vuelo.
// ====================================================================
public class Vuelo
{
    public string NumeroVuelo { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTime FechaSalida { get; set; }
    public decimal Precio { get; set; }

    // Método para imprimir el detalle del vuelo de forma clara.
    public override string ToString()
    {
        // El formato C2 usa la moneda local (ej: $1,200.00)
        return $"Vuelo: {NumeroVuelo} | De: {Origen} a {Destino} | Salida: {FechaSalida:yyyy-MM-dd} | Precio: {Precio:C2}";
    }
}

// ====================================================================
// 2. CLASE GESTORVUELOS: Contiene la 'base de datos' y la lógica.
// ====================================================================
public class GestorVuelos
{
    // Estructura de datos que simula la Base de Datos
    private List<Vuelo> baseDeVuelos;

    public GestorVuelos()
    {
        baseDeVuelos = new List<Vuelo>();
        CargarDatosFicticios();
    }

    // Carga inicial de datos para simular registros.
    private void CargarDatosFicticios()
    {
        Console.WriteLine("Cargando base de datos ficticia de vuelos...");
        baseDeVuelos.AddRange(new List<Vuelo>
        {
            new Vuelo { NumeroVuelo = "AV101", Origen = "BOG", Destino = "MIA", FechaSalida = new DateTime(2025, 12, 1), Precio = 1200.00M },
            new Vuelo { NumeroVuelo = "AV102", Origen = "BOG", Destino = "MIA", FechaSalida = new DateTime(2025, 12, 10), Precio = 950.50M },
            new Vuelo { NumeroVuelo = "LA500", Origen = "SCL", Destino = "MAD", FechaSalida = new DateTime(2025, 11, 25), Precio = 850.75M },
            new Vuelo { NumeroVuelo = "LA501", Origen = "SCL", Destino = "MAD", FechaSalida = new DateTime(2025, 11, 26), Precio = 1500.00M },
            new Vuelo { NumeroVuelo = "IB870", Origen = "MAD", Destino = "BOG", FechaSalida = new DateTime(2025, 12, 5), Precio = 780.99M }, // Vuelo Barato!
            new Vuelo { NumeroVuelo = "IB871", Origen = "MAD", Destino = "BOG", FechaSalida = new DateTime(2025, 12, 15), Precio = 1100.00M },
            new Vuelo { NumeroVuelo = "AD042", Origen = "GRU", Destino = "NYC", FechaSalida = new DateTime(2025, 11, 1), Precio = 2100.00M },
            new Vuelo { NumeroVuelo = "AD043", Origen = "GRU", Destino = "NYC", FechaSalida = new DateTime(2025, 11, 1), Precio = 1999.00M },
            new Vuelo { NumeroVuelo = "AA333", Origen = "MIA", Destino = "BOG", FechaSalida = new DateTime(2025, 12, 1), Precio = 1000.00M },
            new Vuelo { NumeroVuelo = "UX001", Origen = "BOG", Destino = "MIA", FechaSalida = new DateTime(2025, 12, 20), Precio = 890.00M }
        });
        Console.WriteLine($"Carga completada. Total de vuelos: {baseDeVuelos.Count}.\n");
    }

    // Reportería: Visualizar todos los elementos de la estructura.
    public void MostrarTodosLosVuelos()
    {
        Console.WriteLine("--- REPORTE COMPLETO DE VUELOS ---");
        foreach (var vuelo in baseDeVuelos)
        {
            Console.WriteLine(vuelo.ToString());
        }
        Console.WriteLine("------------------------------------\n");
    }

    // Consulta: Encontrar vuelos baratos y medir el rendimiento.
    public List<Vuelo> EncontrarVuelosBaratos(string origen, string destino, decimal precioMaximo)
    {
        // 🚨 INICIO DE MEDICIÓN DEL TIEMPO DE EJECUCIÓN
        var stopwatch = Stopwatch.StartNew();
        
        // Lógica de consulta (Búsqueda y Filtrado) usando LINQ
        var vuelosEncontrados = baseDeVuelos
            .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase) && 
                        v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase) && 
                        v.Precio <= precioMaximo)
            .OrderBy(v => v.Precio) // Ordena por precio para mostrar los más baratos primero
            .ToList();
        
        // 🚨 FIN DE MEDICIÓN DEL TIEMPO DE EJECUCIÓN
        stopwatch.Stop();
        
        // Mostrar el tiempo de ejecución (Reportería de rendimiento)
        Console.WriteLine($"\n✅ Búsqueda finalizada. Tiempo de ejecución: {stopwatch.Elapsed.TotalMilliseconds:F6} ms.");
        
        return vuelosEncontrados;
    }
}

// ====================================================================
// 3. CLASE PROGRAM: Punto de entrada y análisis.
// ====================================================================
public class Program
{
    public static void Main(string[] args)
    {
        var gestor = new GestorVuelos();

        // 1. Reportería: Mostrar todos los vuelos
        gestor.MostrarTodosLosVuelos();

        // ---

        // 2. Consulta: Encontrar vuelos baratos
        Console.WriteLine("--- CONSULTA: ENCONTRAR VUELOS BARATOS ---");
        
        string origenBuscado = "BOG";
        string destinoBuscado = "MIA";
        // Definimos un coste máximo por vuelo, no por día (ajustando el filtro)
        decimal precioLimite = 1000.00M; 
        
        Console.WriteLine($"Buscando vuelos de **{origenBuscado}** a **{destinoBuscado}** con precio <= {precioLimite:C2}...");

        List<Vuelo> vuelosBaratos = gestor.EncontrarVuelosBaratos(origenBuscado, destinoBuscado, precioLimite);

        Console.WriteLine($"\n--- RESULTADOS DE VUELOS BARATOS ({vuelosBaratos.Count} encontrados) ---");
        if (vuelosBaratos.Any())
        {
            foreach (var vuelo in vuelosBaratos)
            {
                Console.WriteLine(vuelo.ToString());
            }
        }
        else
        {
            Console.WriteLine("No se encontraron vuelos que cumplan con los criterios.");
        }
        Console.WriteLine("----------------------------------------------------------------\n");

        // ---

        // 3. Análisis de la Estructura de Datos (List<T>)
        RealizarAnalisisEstructura();
    }
    
    // Función de análisis solicitada
    public static void RealizarAnalisisEstructura()
    {
        Console.WriteLine("\n==================================================");
     }
}
