using System;

public class Cuadrado
{
    // Propiedad privada para almacenar la longitud del lado
    private double lado;

    // Constructor que inicializa el lado del cuadrado
    public Cuadrado(double ladoInicial)
    {
        lado = ladoInicial;
    }

    // Método para calcular el área del cuadrado
    public double CalcularArea()
    {
        return lado * lado; // Área = lado^2
    }

    // Método para calcular el perímetro del cuadrado
    public double CalcularPerimetro()
    {
        return 4 * lado; // Perímetro = 4 * lado
    }
}

public class Rectangulo
{
    // Propiedades privadas para almacenar la base y la altura
    private double baseRectangulo;
    private double altura;

    // Constructor que inicializa la base y altura del rectángulo
    public Rectangulo(double baseInicial, double alturaInicial)
    {
        baseRectangulo = baseInicial;
        altura = alturaInicial;
    }

    // Método para calcular el área del rectángulo
    public double CalcularArea()
    {
        return baseRectangulo * altura; // Área = base * altura
    }

    // Método para calcular el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura); // Perímetro = 2 * (base + altura)
    }
}

// Ejemplo de uso
class Program
{
    static void Main()
    {
        // Crear un cuadrado con lado 5
        Cuadrado miCuadrado = new Cuadrado(5);
        Console.WriteLine("Área del cuadrado: " + miCuadrado.CalcularArea());
        Console.WriteLine("Perímetro del cuadrado: " + miCuadrado.CalcularPerimetro());

        // Crear un rectángulo con base 4 y altura 6
        Rectangulo miRectangulo = new Rectangulo(4, 6);
        Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
    }
}
