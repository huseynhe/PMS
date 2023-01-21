using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PMS.UI
{
    public class QueryService
    {
       private static readonly PersonRepository repository;
        static QueryService() {
            repository = new PersonRepository();
        }
        public QueryService() { }
        
        public static string AddPerson() {
            Person peron = new Person();

            Random random = new Random();
            peron.PersonNumber = random.Next(1, 100);

            Console.WriteLine("Iscinin adini giriniz: ");
            peron.Name = Console.ReadLine();
            Console.WriteLine("Iscinin soyadini giriniz: ");
            peron.Surname = Console.ReadLine();
            Console.WriteLine("Iscinin ise daxil olma tarixini girini (MM/dd/yyyy) giriniz");
            string enterDate = Console.ReadLine();
            peron.EnterDate = DateTime.Parse(enterDate, new CultureInfo("en-US", true));
            Console.WriteLine("Iscinin adresini giriniz");
            peron.Address = Console.ReadLine();
            Console.WriteLine("Iscinin Əmək haqqı əmsalı giriniz");
            peron.SalaryRate = float.Parse(Console.ReadLine());
            peron.TotalWorkTime = 0;
          
            int flag = repository.AddPerson(peron);
            if (flag == 1)
            {
                return "operation succeeded";
            }
            else {
                return "operation fail";
            }
        }

        internal static string UpdatePerson()
        {
            Console.WriteLine("Deyismek istediyiniz iscini nomreisni giriniz:");
            int personNumber = int.Parse(Console.ReadLine());
            Person currentPerson = findPersonByNumber(personNumber);
            if (currentPerson!=null)
            {

            }

            throw new NotImplementedException();
        }
        internal static Person findPersonByNumber(int personNumber) {
            Person person = repository.findPersonByNumber(personNumber);

            return person;
        }
    }
}
