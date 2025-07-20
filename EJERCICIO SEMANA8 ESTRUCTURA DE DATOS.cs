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

// Clase Atraccion: Gestiona la cola de personas y la asignaci�n de asientos
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

    // M�todo para que una persona se una a la fila
    public void UnirseAFila(Persona persona)
    {
        _filaDeEspera.Enqueue(persona);
        Console.WriteLine($"{persona.Nombre} se ha unido a la fila.");
    }

    // M�todo para asignar asientos hasta que se llenen o no haya m�s personas
    public void AsignarAsientos()
    {
        Console.WriteLine("\n--- Iniciando Asignaci�n de Asientos ---");
        int asientosDisponibles = CapacidadMaximaAsientos - _asientosAsignados.Count;

        while (_filaDeEspera.Count > 0 && asientosDisponibles > 0)
        {
            Persona personaAsignada = _filaDeEspera.Dequeue();
            _asientosAsignados.Add(personaAsignada);
            Console.WriteLine($"Asiento asignado a: {personaAsignada.Nombre}. Asientos restantes: {--asientosDisponibles}");
        }

        if (_asientosAsignados.Count == CapacidadMaximaAsientos)
        {
            Console.WriteLine("�Todos los 30 asientos han sido asignados!");
        }
        else if (_filaDeEspera.Count == 0 && _asientosAsignados.Count < CapacidadMaximaAsientos)
        {
            Console.WriteLine($"No hay m�s personas en la fila. Se han asignado {_asientosAsignados.Count} de {CapacidadMaximaAsientos} asientos.");
        }
        Console.WriteLine("--- Asignaci�n de Asientos Finalizada ---\n");
    }

    // Reporter�a: Visualizar el estado actual de la fila
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
            Console.WriteLine("La fila de espera est� vac�a.");
        }
        Console.WriteLine("---------------------------------\n");
    }

    // Reporter�a: Visualizar los asientos ya asignados
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
            Console.WriteLine("No se han asignado asientos a�n.");
        }
        Console.WriteLine("------------------------------------\n");
    }

    // Consulta espec�fica: Buscar una persona en la fila
    public Persona ConsultarPersonaEnFila(int id)
    {
        return _filaDeEspera.FirstOrDefault(p => p.Id == id);
    }

    // Consulta espec�fica: Buscar una persona en los asientos asignados
    public Persona ConsultarPersonaEnAsientos(int id)
    {
        return _asientosAsignados.FirstOrDefault(p => p.Id == id);
    }
}

// Clase principal para ejecutar la simulaci�n
public class Program
{
    public static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion();
        Stopwatch stopwatch = new Stopwatch();

        // --- Simulaci�n de la llegada de personas ---
        Console.WriteLine("--- Simulaci�n de Llegada de Personas ---");
        stopwatch.Start();
        for (int i = 1; i <= 40; i++) // Simular 40 personas llegando
        {
            atraccion.UnirseAFila(new Persona($"Persona_{i}", i));
        }
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecuci�n para \"UnirseAFila\" (40 personas): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Reporter�a inicial ---
        atraccion.ReportarEstadoFila();
        atraccion.ReportarAsientosAsignados();

        // --- Asignaci�n de asientos ---
        Console.WriteLine("\n--- Simulaci�n de Asignaci�n de Asientos ---");
        stopwatch.Start();
        atraccion.AsignarAsientos(); // Asigna los primeros 30 asientos
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecuci�n para \"AsignarAsientos\": {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Reporter�a despu�s de la primera asignaci�n ---
        atraccion.ReportarEstadoFila();
        atraccion.ReportarAsientosAsignados();

        // --- Simular m�s personas llegando despu�s de la primera tanda ---
        Console.WriteLine("--- Simulaci�n de M�s Personas Uni�ndose a la Fila ---");
        stopwatch.Start();
        for (int i = 41; i <= 45; i++)
        {
            atraccion.UnirseAFila(new Persona($"Persona_{i}", i));
        }
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecuci�n para \"UnirseAFila\" (5 personas adicionales): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        atraccion.ReportarEstadoFila();

        // --- Intentar asignar m�s asientos (no habr�, ya est�n llenos) ---
        Console.WriteLine("\n--- Intentando Asignar m�s Asientos (Atracci�n llena) ---");
        stopwatch.Start();
        atraccion.AsignarAsientos();
        stopwatch.Stop();
        Console.WriteLine($"Tiempo de ejecuci�n para \"AsignarAsientos\" (atracci�n llena): {stopwatch.Elapsed.TotalMilliseconds} ms");
        stopwatch.Reset();

        // --- Consultas espec�ficas ---
        Console.WriteLine("\n--- Consultas Espec�ficas ---");
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

        int idConsulta3 = 50; // Una persona que nunca lleg�
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