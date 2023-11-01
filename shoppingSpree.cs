namespace softUniClassesBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleNamesAndMoney = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach(string info in peopleNamesAndMoney)
            {
                string name = info.Split('=')[0];
                double money = double.Parse(info.Split('=')[1]);

                Person person = new Person(name, money, new List<Product>());
                people.Add(person);
            }

            string[] productsNameAndCost = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach(string info in productsNameAndCost)
            {
                string name = info.Split('=')[0];
                double cost = double.Parse(info.Split('=')[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }

            string command = Console.ReadLine();
            while(command != "END")
            {
                string[] personAndProduct = command.Split().ToArray();
                string personName = personAndProduct[0];
                string productName = personAndProduct[1];

                foreach(Person person in people)
                {
                    if(person.Name == personName)
                    {
                        foreach(Product product in products)
                        {
                            if(product.Name == productName)
                            {
                                if(person.Money >= product.Cost)
                                {
                                    person.bagOfProducts.Add(product);
                                    person.Money -= product.Cost;
                                    Console.WriteLine($"{person.Name} bought {product.Name}");
                                }
                                else Console.WriteLine($"{person.Name} can't afford {product.Name}");
                            }
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            foreach(Person person in people)
            {
                if(person.bagOfProducts.Count > 0)
                {
                    List<string> productNames = new List<string>();
                    foreach(Product product in person.bagOfProducts)
                    {
                        productNames.Add(product.Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", productNames)}");
                }
                else Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> bagOfProducts { get; set; }

        public Person(string name, double money, List<Product> bagOfProducts)
        {
            Name = name;
            Money = money;
            this.bagOfProducts = bagOfProducts;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}