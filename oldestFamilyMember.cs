namespace softUniClassesBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family()
            {
                people = new List<Person>()
            };
            for(int i = 1; i <= n; i++)
            {
                string[] data = Console.ReadLine().Split(' ').ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person()
                {
                    Name = name,
                    Age = age
                };
                family.people.Add(person);
            }

            foreach(Person person in family.people)
            {
                if(person == family.GetOldestMember())
                {
                    Console.WriteLine($"{person.Name} {person.Age}");
                    break;
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public List<Person> people { get; set; }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = new Person();
            int maxAge = 0;

            foreach(Person member in people)
            {
                if(member.Age >= maxAge)
                {
                    oldestPerson = member;
                    maxAge = member.Age;
                }
            }
            return oldestPerson;
        }
    }
}