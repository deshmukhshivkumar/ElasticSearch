using System;
using System.Diagnostics;
using BLL;

namespace PerfTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*Program Started : "  + DateTime.Now);
            var business = new Business();

            var swRead = new Stopwatch();
            swRead.Start();
            business.AddToDb();
            swRead.Stop();
            Console.WriteLine("DB write Time  : " + swRead.ElapsedMilliseconds);

            swRead.Reset();
            swRead.Start();
            business.AddToElasticIndex();
            swRead.Stop();
            Console.WriteLine("ES write Time  : " + swRead.ElapsedMilliseconds);
            
            var sw = new Stopwatch();
            sw.Start();
            var personsFromDB = business.GetFromDB();
            sw.Stop();
            Console.WriteLine("DB Read Time  : " + sw.ElapsedMilliseconds);
            
            sw.Reset();
            sw.Start();
            var personsFromEs = business.GetFromES();
            sw.Stop();
            Console.WriteLine("ES Read Time  : " + sw.ElapsedMilliseconds);

            Console.ReadLine();
            /*
                DB write Time  : 40255
                ES write Time  : 7923
                DB Read Time  : 597
                ES Read Time  : 522
             */
        }
    }
}
