using System;

public class Estudiante
{
    // Atributos privados para encapsular los datos del estudiante
    private int id;
    private string nombres;
    private string apellidos;
    private string direccion;
    private string[] telefonos; // Array para almacenar los teléfonos

    // Constructor para inicializar los datos del estudiante
    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        this.id = id;
        this.nombres = nombres;
        this.apellidos = apellidos;
        this.direccion = direccion;

        // Validamos que el array tenga exactamente 3 teléfonos
        if (telefonos.Length == 3)
        {
            this.telefonos = telefonos;
        }
        else
        {
            throw new ArgumentException("El estudiante debe tener exactamente 3 teléfonos.");
        }
    }

    // Método para mostrar la información del estudiante
    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Nombre: {nombres} {apellidos}");
        Console.WriteLine($"Dirección: {direccion}");
        Console.WriteLine("Teléfonos:");

        // Recorrer el array de teléfonos y mostrarlos
        foreach (string telefono in telefonos)
        {
            Console.WriteLine($"- {telefono}");
        }
    }
}

// Clase principal para probar la clase Estudiante
class Program
{
    static void Main()
    {
        // Definir un array con los 3 teléfonos
        string[] telefonos = { "0987654321", "0998765432", "0976543210" };

        // Crear un objeto Estudiante
        Estudiante estudiante = new Estudiante(1, "Roberto", "Zambrano", "Calle Los olivos 123", telefonos);

        // Mostrar la información del estudiante
        estudiante.MostrarInformacion();
    }
}