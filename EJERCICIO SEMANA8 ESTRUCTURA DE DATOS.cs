using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Clase Persona: Representa a una persona en la fila
public class Persona
{
    public string Nombre { get; private set; }
    public int Id { get; private set; }

    public Persona(string nombre, int id)
    {
        Nombre = nombre;
        Id = id;
    }

    public override string ToString()
    {
        return $"[ID: {Id}, Nombre: {Nombre}]";
    }
}

// Clase Atraccion: Gestiona la cola de personas y la asignación de asientos
public class Atraccion
{
    private Queue<Persona> _filaDeEspera;
    private const int CapacidadMaximaAsientos = 30;
    private List<Persona> _asientosAsignados;

    public Atraccion()
    {
        _filaDeEspera = new Queue<Persona>();
        _asientosAsignados = new List<Persona>();
    }

    // Método para que una persona se una a la fila
    public void UnirseAFila(Persona persona)
    {
        _filaDeEspera.Enqueue(persona);
        Console.WriteLine($"{persona.Nombre} se ha unido a la fila.");
    }

    // Método para asignar asientos hasta que se llenen o no haya más personas
    public void AsignarAsientos()
    {
        Console.WriteLine("\n--- Iniciando Asignación de Asientos ---");
        int asientosDisponibles = CapacidadMaximaAsientos - _asientosAsignados.Count;

        while (_filaDeEspera.Count > 0 && asientosDisponibles > 0)
        {
            Persona personaAsignada = _filaDeEspera.Dequeue();
            _asientosAsignados.Add(personaAsignada);
            Console.WriteLine($"Asiento asignado a: {personaAsignada.Nombre}. Asientos restantes: {--asientosDisponibles}");
        }

        if (_asientosAsignados.Count == CapacidadMaximaAsientos)
        {
            Console.WriteLine("¡Todos los 30 asientos han sido asignados!");
        }
        else if (_filaDeEspera.Count == 0 && _asientosAsignados.Count < CapacidadMaximaAsientos)
        {
            Console.WriteLine($"No hay más personas en la fila. Se han asignado {_asientosAsignados.Count} de {CapacidadMaximaAsientos} asientos.");
        }
        Console.WriteLine("--- Asignación de Asientos Finalizada ---\n");
    }

    // Reportería: Visualizar el estado actual de la fila
    public void ReportarEstadoFila()
    {
        Console.WriteLine("\n--- Reporte de Fila de Espera ---");
        if (_filaDeEspera.Any())
        {
            Console.WriteLine($"Personas en fila ({_filaDeEspera.Count}):");
            foreach (var persona in _filaDeEspera)
            {
                Console.WriteLine($"- {persona}");
            }
        }
        else
        {
            Console.WriteLine("La fila de espera está vacía.");
        }
        Console.WriteLine("---------------------------------\n");
    }

    // Reportería: Visualizar los asientos ya asignados
    public void ReportarAsientosAsignados()
    {
        Console.WriteLine("\n--- Reporte de Asientos Asignados ---");
        if (_asientosAsignados.Any())
        {
            Console.WriteLine($"Asientos asignados ({_asientosAsignados.Count} de {CapacidadMaximaAsientos}):");
            foreach (var persona in _asientosAsignados)
            {
                Console.WriteLine($"- {persona}");
            }
        }
        else
        {
            Console.WriteLine("No se han asignado asientos aún.");
        }
        Console.WriteLine("------------------------------------\n");
    }

    // Consulta específica: Buscar una persona en la fila
    public Persona ConsultarPersonaEnFila(int id)
    {
        return _filaDeEspera.FirstOrDefault(p => p.Id == id);
    }

    // Consulta específica: Buscar una persona en los asientos asignados
    public Persona ConsultarPersonaEnAsientos(int id)
    {
        return _asientosAsignados.FirstOrDefault(p => p.Id == id);
    }
}

// Clase principal para ejecutar la simulación
public class Program
{
    public static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion();
        Stopwatch stopwatch = new Stopwatch();

        // --- Simulación de la llegada de personas ---
        Console.WriteLine("--- Simulación de Llegada de Personas ---");
        stopwatch.Start();
        for (int i = 1; i <= 40; i++) // Simular 40 personas llegando
        {
            atraccion.UnirseAFila(new Persona($"Persona_{i}", i));
        }
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecución para \"UnirseAFila\" (40 personas): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Reportería inicial ---
        atraccion.ReportarEstadoFila();
        atraccion.ReportarAsientosAsignados();

        // --- Asignación de asientos ---
        Console.WriteLine("\n--- Simulación de Asignación de Asientos ---");
        stopwatch.Start();
        atraccion.AsignarAsientos(); // Asigna los primeros 30 asientos
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecución para \"AsignarAsientos\": {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Reportería después de la primera asignación ---
        atraccion.ReportarEstadoFila();
        atraccion.ReportarAsientosAsignados();

        // --- Simular más personas llegando después de la primera tanda ---
        Console.WriteLine("--- Simulación de Más Personas Uniéndose a la Fila ---");
        stopwatch.Start();
        for (int i = 41; i <= 45; i++)
        {
            atraccion.UnirseAFila(new Persona($"Persona_{i}", i));
        }
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecución para \"UnirseAFila\" (5 personas adicionales): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        atraccion.ReportarEstadoFila();

        // --- Intentar asignar más asientos (no habrá, ya están llenos) ---
        Console.WriteLine("\n--- Intentando Asignar más Asientos (Atracción llena) ---");
        stopwatch.Start();
        atraccion.AsignarAsientos();
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecución para \"AsignarAsientos\" (atracción llena): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Consultas específicas ---
        Console.WriteLine("\n--- Consultas Específicas ---");
        int idConsulta1 = 15;
        Persona p1 = atraccion.ConsultarPersonaEnAsientos(idConsulta1);
        if (p1 != null)
        {
            Console.WriteLine($"Persona con ID {idConsulta1} encontrada en asientos asignados: {p1.Nombre}");
        }
        else
        {
            Console.WriteLine($"Persona con ID {idConsulta1} no encontrada en asientos asignados.");
        }

        int idConsulta2 = 35;
        Persona p2 = atraccion.ConsultarPersonaEnFila(idConsulta2);
        if (p2 != null)
        {
            Console.WriteLine($"Persona con ID {idConsulta2} encontrada en la fila: {p2.Nombre}");
        }
        else
        {
            Console.WriteLine($"Persona con ID {idConsulta2} no encontrada en la fila.");
        }

        int idConsulta3 = 50; // Una persona que nunca llegó
        Persona p3 = atraccion.ConsultarPersonaEnFila(idConsulta3);
        if (p3 != null)
        {
            Console.WriteLine($"Persona con ID {idConsulta3} encontrada en la fila: {p3.Nombre}");
        }
        else
        {
            Console.WriteLine($"Persona con ID {idConsulta3} no encontrada en la fila.");
        }
    }
}