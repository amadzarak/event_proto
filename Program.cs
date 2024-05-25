using System;

namespace Sandbox
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person aperson = new Person("John", "Mi", "Doe", "555-555-5555", "amad");
            Venue myvenue = new Venue("My Venue", new AddressObject("456 Elm St", "Apt 3", "Springfield", "IL", "62701"));

            myvenue.AddPerson(aperson);

            myvenue.GetKeyPersonnel();

            EventObject newevent = new EventObject("My Event", myvenue);

            newevent.PrintAddress();
        }
    }
}

