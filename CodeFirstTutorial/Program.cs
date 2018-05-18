using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainData;
using Unity;

namespace CodeFirstTutorial
{
    class Program
    {
        private static ITrainRepository _trainRepository;
        private static string continueProcess = "y";
       
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ITrainRepository, TrainRepository>();
            _trainRepository = container.Resolve<TrainRepository>();

            Console.WriteLine("These are the all the trains. Would like to add trains? (Y/N)");

            foreach (var train in _trainRepository.ListTrains())
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

                _trainRepository.Add(trainSymbol, Convert.ToInt32(speed), trainStationName, trainStationAddress);

                Console.WriteLine("Do you wish to continue ? Type (Y/N)");
                continueProcess = Console.ReadLine();
            }
        }
    }
}
