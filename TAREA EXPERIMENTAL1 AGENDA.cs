using System;
using System.Collections.Generic;

// Definición de estructuras y clases
struct Telefono
{
    public string Tipo;
    public string Numero;
}

record Persona(string Nombre, string Apellido, string Direccion, string Ciudad);

class Contacto
{
    public Persona Identidad { get; set; }
    public Telefono[] Telefonos { get; set; }

    public Contacto(Persona persona, Telefono[] telefonos)
    {
        Identidad = persona;
        Telefonos = telefonos;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Nombre: {Identidad.Nombre} {Identidad.Apellido}");
        Console.WriteLine($"Dirección: {Identidad.Direccion}, Ciudad: {Identidad.Ciudad}");
        foreach (var tel in Telefonos)
        {
            Console.WriteLine($"  {tel.Tipo}: {tel.Numero}");
        }
    }
}

class AgendaTelefonica
{
    private List<Contacto> contactos = new List<Contacto>();

    public void AgregarContacto(Contacto c)
    {
        contactos.Add(c);
    }

    public void MostrarTodos()
    {
        Console.WriteLine("📒 Lista de contactos:");
        foreach (var c in contactos)
        {
            c.Mostrar();
        }
    }

    public void BuscarPorNombre(string nombre)
    {
        Console.WriteLine($"🔍 Resultados para: {nombre}");
        foreach (var c in contactos)
        {
            if (c.Identidad.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                c.Mostrar();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        AgendaTelefonica agenda = new AgendaTelefonica();

        var tel1 = new Telefono { Tipo = "Móvil", Numero = "0991234567" };
        var tel2 = new Telefono { Tipo = "Casa", Numero = "042567890" };

        Contacto contacto1 = new Contacto(
            new Persona("Mario", "Zambrano", "Av. 9 de Octubre y Boyacá", "Guayaquil"),
            new Telefono[] { tel1, tel2 }
        );

        agenda.AgregarContacto(contacto1);
        agenda.MostrarTodos();
        agenda.BuscarPorNombre("Mario");
    }
}