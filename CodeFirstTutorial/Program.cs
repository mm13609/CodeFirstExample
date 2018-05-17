using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTutorial
{
    class Program
    {
        private static string continueProcess = "y";\

        static void Main(string[] args)
        {
            Console.WriteLine("These are the all the trains. Would like to add trains? (Y/N)");

            foreach (var train in ListTrains())
            {
                Console.WriteLine($"Symbol: {train.TrainSymbol}, Speed: {train.Speed}, Description: {train.Description}");
            }

            continueProcess = Console.ReadLine();

            if (continueProcess.ToLower() == "y" || continueProcess.ToLower() == "yes")
            {
                AddTrains();

                Console.WriteLine("Exiting the process. Please enter Enter to add trains");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    continueProcess = "y";
                    Console.Clear();
                    AddTrains();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static IEnumerable<Train> ListTrains()
        {
            using (var db = new TrainContext())
            {
                return db.Trains.AsNoTracking().ToList();
            }
        }

        private static void AddTrains()
        {
            while (continueProcess.ToLower() == "y" || continueProcess.ToLower() == "yes")
            {
                Console.WriteLine("Please enter train symbol");
                var trainSymbol = Console.ReadLine();
                Console.WriteLine("Please enter train speed");
                var speed = Console.ReadLine();
                Console.WriteLine("Please enter train description");
                var trainDescription = Console.ReadLine();
                Console.WriteLine("Please enter train station name");
                var trainStationName = Console.ReadLine();
                Console.WriteLine("Please enter train station address");
                var trainStationAddress = Console.ReadLine();
                
                Add(trainSymbol, Convert.ToInt32(speed), trainStationName, trainStationAddress);

                Console.WriteLine("Do you wish to continue ? Type (Y/N)");
                continueProcess = Console.ReadLine();
            }
        }

        public static void DeleteAllTrains()
        {
            using (var db = new TrainContext())
            {
                db.Trains.ToList().ForEach(x => db.Trains.Remove(x));
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var db = new TrainContext())
            {
                var trains = db.Trains.Where(x => x.TrainSymbol == "Mustafa Train");
                db.Trains.RemoveRange(trains);
                db.SaveChanges();
            }
        }

        public static void Edit(string oldTrainSymbol, string trainSymbol, int speed = 0, string description = "")
        {
            using (var db = new TrainContext())
            {
               var train = db.Trains.FirstOrDefault(x => x.TrainSymbol == oldTrainSymbol);

                if (train != null)
                {
                    train.TrainSymbol = trainSymbol;
                    train.Speed = speed;
                    train.Description = description;
                    db.SaveChanges();
                }
            }
        }

        public static void Add(string trainSymbol, int speed, string stationName, string stationAddress, string description = "")
        {
            using (var db = new TrainContext())
            {
                db.Trains.Add(new Train { TrainSymbol = trainSymbol, Speed = speed, Description = description });
                db.TrainStations.Add(new TrainStation { StationName = stationName, StationAddress = stationAddress });
                db.SaveChanges();
            }
        }
    }
}
