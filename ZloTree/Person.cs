using System.Collections.Generic;

namespace ZloTree
{
    public class Person
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Person InvitedBy { get; set; }

        public List<Person> InviteList { get; set; }
    }
}
