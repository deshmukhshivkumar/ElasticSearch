using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ElasticSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Id = "1",
                Firstname = "john",
                Lastname = "Snow"
            };

            //var response = Index(person);
            //Console.WriteLine(response ? "Indexed Succssfully." : "Indexing Error.");
            var searchRespone = Search(person.Firstname);
            Console.WriteLine("ElapsedMilliseconds : " + searchRespone.ElapsedMilliseconds);
            foreach (var document in searchRespone.Documents)
            {
                Console.WriteLine("Id "  + document.Id );
                Console.WriteLine("Firstname " + document.Firstname);
                Console.WriteLine("Lastname " + document.Lastname);
            }
            Console.ReadLine();
        }

        public static bool Index(Person person)
        {
            var client = new ElasticClient(Setting.ConnectionSettings);
            
            if (client.IndexExists("Person").Exists)
            {
                Console.WriteLine("Index already exists.");
            }
            Console.WriteLine("Trying to add index");
            try
            {
                var index = client.Index(person);
                Console.WriteLine(" Connection status : " + index.ConnectionStatus);    
                return index.Created;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Excepton Message : " + ex.Message);
            }
            return false;
        }

        public static ISearchResponse<Person> Search(string firstName )
        {
            var client = new ElasticClient(Setting.ConnectionSettings);
            if (client.IndexExists("Person").Exists)
            {
                Console.WriteLine("Index exists.");
            }

            var searchResults = client.Search<Person>(s => s.From(0)
                .Size(10)
                .Query(q => q.Term(p => p.Firstname, firstName)
                ));

            return searchResults;            
        }
    }
}
