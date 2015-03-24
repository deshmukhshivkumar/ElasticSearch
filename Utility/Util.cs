using System;
using System.Collections.Generic;
using DBProvider.Models;

namespace Utility
{
    public static class Util
    {
        public static List<PersonDetail> Get10000PersonDetails()
        {
            var personDetailsList = new List<PersonDetail>();
            
            for (int i = 0; i < 10000; i++)
            {
                personDetailsList.Add(new PersonDetail()
                {
                    FirstName = "FN" + new Random().Next(int.MaxValue),
                    LastName = "LN"  + new Random().Next(int.MaxValue)
                });
            }
            return personDetailsList;
        }

        public static List<PersonDetail> Get10000PersonDetailsWithID()
        {
            var personDetailsList = new List<PersonDetail>();
            
            for (int i = 0; i < 10000; i++)
            {
                personDetailsList.Add(new PersonDetail()
                {
                    Id = i * new Random().Next(99),
                    FirstName = "FN" + new Random().Next(int.MaxValue),
                    LastName = "LN" + new Random().Next(int.MaxValue)
                });
            }
            return personDetailsList;
        }

    }
}
