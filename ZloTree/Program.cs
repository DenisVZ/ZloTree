using System;
using System.Collections.Generic;
using System.Linq;

namespace ZloTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = ExcelUtil.ReadCsv<CsvRowItem>($@"data.csv", ";", false);

            List<Person> persons = items.Select(x => new Person() { Name = x.C, Year = Convert.ToInt32(x.A) }).ToList();

            foreach(var item in items)
            {
                var person = persons.Single(x => x.Name == item.C);
                var invitedByPerson = persons.SingleOrDefault(x => x.Name == item.B);

                person.InvitedBy = invitedByPerson;
            }

            foreach (var person in persons.Where( x => x.InvitedBy == null))
            {
                Update(person, persons);
            }

            foreach (var person in persons.Where(x => x.InvitedBy == null).OrderBy( z => z.Name ))
            {
                Show(person, persons, "");

            }

            Console.WriteLine("Hello World!");
        }
        public static void Update(Person person, List<Person> persons)
        {
            person.InviteList = persons.Where(x => x.InvitedBy == person).ToList();

            foreach(var p in person.InviteList)
            {
                Update(p, persons);
            }

            return;
        }

        public static void Show(Person person, List<Person> persons, string increment)
        {
            if (person.Name == "по объявлению")
            { }
            else if (person.Name == "основали команду")
            { }
            else if (person.InvitedBy?.Name == "по объявлению")
                Console.WriteLine($"{increment}{person.Name} пришел по объявлению в {person.Year}");
            else if (person.InvitedBy?.Name == "основали команду")
                Console.WriteLine($"{increment}{person.Name} основал команду в {person.Year}");
            else
                Console.WriteLine($"{increment}{person.InvitedBy?.Name} привел {person.Name} в {person.Year}");


            foreach (var p in person.InviteList.OrderBy( x => x.Year ))
            {
                Show(p, persons, increment + "    ");
            }

            return;
        }
    }
}
