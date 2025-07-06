using System;

public class Node
{
    /// <summary>
    /// Representa un nodo individual en la lista enlazada.
    /// Cada nodo contiene un dato y una referencia al siguiente nodo.
    /// </summary>
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    /// <summary>
    /// Representa una lista enlazada simple.
    /// </summary>
    public Node Head { get; private set; } // La cabeza de la lista, accesible pero solo modificable internamente

    public LinkedList()
    {
        Head = null;
    }

    /// <summary>
    /// Agrega un nuevo nodo al final de la lista enlazada.
    /// </summary>
    /// <param name="data">El valor a agregar al final de la lista.</param>
    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            return;
        }

        Node lastNode = Head;
        while (lastNode.Next != null)
        {
            lastNode = lastNode.Next;
        }
        lastNode.Next = newNode;
    }

    /// <summary>
    /// Imprime los elementos de la lista enlazada.
    /// </summary>
    public void Display()
    {
        Node current = Head;
        if (current == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null)
            {
                Console.Write(" -> ");
            }
            current = current.Next;
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Invierte la lista enlazada.
    /// Cambia los punteros de los nodos para que el último sea el primero
    /// y así sucesivamente.
    /// </summary>
    public void Reverse()
    {
        Node prev = null;
        Node current = Head;
        Node nextNode = null;

        while (current != null)
        {
            nextNode = current.Next; // Guarda el siguiente nodo
            current.Next = prev;     // Invierte el puntero del nodo actual
            prev = current;          // Mueve 'prev' un paso adelante
            current = nextNode;      // Mueve 'current' un paso adelante
        }
        Head = prev; // 'prev' será la nueva cabeza de la lista
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LinkedList myList = new LinkedList();
        myList.Append(1);
        myList.Append(2);
        myList.Append(3);
        myList.Append(4);

        Console.WriteLine("Lista original:");
        myList.Display(); // Salida esperada: 1 -> 2 -> 3 -> 4

        myList.Reverse();
        Console.WriteLine("Lista invertida:");
        myList.Display(); // Salida esperada: 4 -> 3 -> 2 -> 1

        Console.WriteLine("\n--- Pruebas adicionales ---");

        LinkedList myEmptyList = new LinkedList();
        Console.WriteLine("Lista vacía original:");
        myEmptyList.Display();
        myEmptyList.Reverse();
        Console.WriteLine("Lista vacía invertida:");
        myEmptyList.Display();

        LinkedList mySingleElementList = new LinkedList();
        mySingleElementList.Append(100);
        Console.WriteLine("\nLista con un solo elemento original:");
        mySingleElementList.Display();
        mySingleElementList.Reverse();
        Console.WriteLine("Lista con un solo elemento invertida:");
        mySingleElementList.Display();
    }
}