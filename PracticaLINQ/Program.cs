using PracticaLINQ;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();
        Program program = new Program();
        program.PrintValues(queries.AllCollection());
        Console.WriteLine("\nLibros del 2000 en adelante\n");
        program.PrintValues(queries.CollectionByYear());
        Console.WriteLine("\nLibros con mas de 250 paginas con las palablas in Action\n");
        program.PrintValues(queries.CollectionByContent());
        //program.AddAnimals();
        program.PrintAnimals(queries.CollectionByColorAndVocal());




    }
    void PrintValues(IEnumerable<Book> booklist)
    {
        Console.WriteLine("{0,-60}{1,15}{2,15}\n","Title","N. Pages","Publish Date");
        foreach(var item in booklist)
        {
            Console.WriteLine("{0,-60}{1,15}{2,15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
        }
        Console.WriteLine("\nLibros totales: " + booklist.LongCount());
    }

    public IEnumerable<Animal> AddAnimals()
    {
        // Lista de animales
        List<Animal> animales = new List<Animal>
        {
            new Animal() { Nombre = "Hormiga", Color = "Rojo" },
            new Animal() { Nombre = "Lobo", Color = "Gris" },
            new Animal() { Nombre = "Elefante", Color = "Gris" },
            new Animal() { Nombre = "Pantegra", Color = "Negro" },
            new Animal() { Nombre = "Gato", Color = "Negro" },
            new Animal() { Nombre = "Iguana", Color = "Verde" },
            new Animal() { Nombre = "Sapo", Color = "Verde" },
            new Animal() { Nombre = "Camaleon", Color = "Verde" },
            new Animal() { Nombre = "Gallina", Color = "Blanco" }
        };
        return animales;
    }

    public void PrintAnimals(IEnumerable<Animal> animales)
    {
        Console.WriteLine("Animales de color verde cuyo nombre inicia con una vocal:");
        foreach (var animal in animales)
        {
            Console.WriteLine($"Nombre: {animal.Nombre}, Color: {animal.Color}");
        }
    }
}