using System;
using System.Collections.Generic;
using System.Linq;
using DBProvider.Models;
using Nest;

namespace ElasticSearchProvider
{
    public class ESProvider
    {
        public bool Index(PersonDetail person)
        {
            var client = new ElasticClient(Setting.ConnectionSettings);
            try
            {
                var index = client.Index(person);            
                return index.Created;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Excepton Message : " + ex.Message);
            }
            return false;
        }


        public List<PersonDetail> GetAll()
        {
            var client = new ElasticClient(Setting.ConnectionSettings);
            var searchResults = client.Search<PersonDetail>(s => s
                .From(0)
                .Size(10000)            
                );            
            return searchResults.Documents.ToList();
        }

    }
}
