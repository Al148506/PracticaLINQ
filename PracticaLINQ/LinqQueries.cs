using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ
{
    public class LinqQueries
    {
        private List<Book> _booksList = new List<Book>();
        private List<Animal> _animalList = new List<Animal>();


        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this._booksList = System.Text.Json.JsonSerializer.Deserialize<List<Book>>
                    (json, new System.Text.Json.JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
     
        public IEnumerable<Book> AllCollection() { return _booksList; }

        public IEnumerable<Book> CollectionByYear()
        {
            //extension method
            //return _booksList.Where(p=>p.PublishedDate.Year >= 2000 && p.PageCount > 600); }
            //query expression
            return from l in _booksList where l.PublishedDate.Year > 2000 select l;
        }
        public IEnumerable<Book> CollectionByContent()
        {
            //extension method
            return _booksList.Where(p=>p.Title.Contains("in Action") && p.PageCount > 250); 
           
        }
        // filtra todos los animales que sean de color verde que su nombre inicie con una vocal
        public IEnumerable<Animal> CollectionByColorAndVocal()
        {
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
            Program program = new Program();
            _animalList = program.AddAnimals().ToList();
            //extension method
            var animalesFiltrados = _animalList.Where(p => p.Color.Equals("Gris") && vocales.Contains(char.ToLower(p.Nombre[0])));
            return animalesFiltrados;
        }

    }
}
