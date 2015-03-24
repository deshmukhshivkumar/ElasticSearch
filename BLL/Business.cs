using System.Collections.Generic;
using DBProvider;
using DBProvider.Models;
using ElasticSearchProvider;
using Utility;

namespace BLL
{
    public class Business
    {
        private List<PersonDetail> _personList = new List<PersonDetail>();
        
        PersonDbProvider dbProvider = new PersonDbProvider();
        
        ESProvider esProvider = new ESProvider();

        public void AddToDb()
        {
            _personList = Util.Get10000PersonDetails();

            foreach (var personDetail in _personList)
            {
                dbProvider.AddPerson(personDetail);
            }
        }

        public void AddToElasticIndex()
        {
            _personList = Util.Get10000PersonDetailsWithID();
            foreach (var personDetail in _personList)
            {
                esProvider.Index(personDetail);
            }
        }

        public List<PersonDetail> GetFromDB()
        {
            return dbProvider.GetAllPersonDetails();
        }

        public List<PersonDetail> GetFromES()
        {
            return esProvider.GetAll();
        }

    }
}
