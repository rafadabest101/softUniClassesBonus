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
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionPerKilometer = double.Parse(data[2]);
                double traveledDistance = 0.0;

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer, traveledDistance);
                if(!cars.Contains(car)) cars.Add(car);
            }

            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] data = command.Split().ToArray();
                string model = data[1];
                double distanceInKM = double.Parse(data[2]);

                foreach(Car car in cars)
                {
                    if(car.Model == model)
                    {
                        if(car.FuelAmount >= car.NeededFuel(distanceInKM))
                        {
                            car.FuelAmount -= car.NeededFuel(distanceInKM);
                            car.TraveledDistance += distanceInKM;
                        }
                        else Console.WriteLine("Insufficient fuel for the drive");
                    }
                }

                command = Console.ReadLine();
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.TraveledDistance}"));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public double NeededFuel(double distance)
        {
            return FuelConsumptionPerKilometer * distance;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double traveledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = traveledDistance;
        }
    }
}