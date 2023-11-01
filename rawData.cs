namespace softUniClassesBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for(int i = 1; i <= n; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();
                string model = data[0];
                int speed = int.Parse(data[1]);
                int power = int.Parse(data[2]);
                int weight = int.Parse(data[3]);
                string type = data[4];

                Car car = new Car(model, new Engine(speed, power), new Cargo(weight, type));
                cars.Add(car);
            }

            string printType = Console.ReadLine();
            foreach(Car car in cars)
            {
                if(car.cargo.Type == printType)
                {
                    if((printType == "fragile" && car.cargo.Weight < 1000)
                        || (printType == "flamable" && car.engine.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine engine { get; set; }
        public Cargo cargo { get; set; }

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            this.engine = engine;
            this.cargo = cargo;
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}