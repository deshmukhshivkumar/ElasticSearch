using System;
using System.Collections.Generic;
using System.Linq;
using DBProvider.Models;

namespace DBProvider
{
    public class PersonDbProvider
    {
        public bool AddPerson(PersonDetail personDetail)
        {
            try
            {
                using (var db = new PersonContext())
                {
                    db.PersonDetails.Add(personDetail);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PersonDetail> GetAllPersonDetails()
        {
            try
            {
                using (var db = new PersonContext())
                {
                    return db.PersonDetails.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
