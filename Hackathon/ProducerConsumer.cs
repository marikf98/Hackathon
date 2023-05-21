using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon
{
    internal class ProducerConsumer
    {

        public static Queue<int> tables = new Queue<int>();
        public static int numOfTables = 10;
        public static Random random = new Random();
        public static int totalSittingClients = 0;
        public static int totalClientsFinished = 0;
        public static List<int> waitingTimes = new List<int>();
        public static int maxWaitingTime = 0;
        public static int numProducers;
        public static int numConsumers;
        public static int productionRate;
        public static int consumptionRate;
        public static bool enableProducerRandomness;
        public static bool enableConsumerRandomness;


        static void StartSimulation()
        {
            /*            Console.Write("Enter the number of producers: ");
                        int numProducers = int.Parse(Console.ReadLine());

                        Console.Write("Enter the number of consumers: ");
                        int numConsumers = int.Parse(Console.ReadLine());

                        Console.Write("Enter the base rate of production (in milliseconds): ");
                        int productionRate = int.Parse(Console.ReadLine());

                        Console.Write("Enter the base rate of consumption (in milliseconds): ");
                        int consumptionRate = int.Parse(Console.ReadLine());*/

            Console.Write("Enable randomness in producer rate? (Y/N): ");
            bool enableProducerRandomness = Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase);

            Console.Write("Enable randomness in consumer rate? (Y/N): ");
            bool enableConsumerRandomness = Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase);

            // Create producer threads
            for (int i = 0; i < numProducers; i++)
            {
                Thread producerThread = new Thread(() => Producer(productionRate, enableProducerRandomness));
                producerThread.Start();
            }

            // Create consumer threads
            for (int i = 0; i < numConsumers; i++)
            {
                Thread consumerThread = new Thread(() => Consumer(consumptionRate, enableConsumerRandomness));
                consumerThread.Start();
            }

            // Create statistical analysis thread
            Thread statisticsThread = new Thread(Statistics);
            statisticsThread.Start();

            Console.ReadLine();
        }

        static void Producer(int productionRate, bool enableRandomness)
        {
            while (true)
            {
                // Produce an empty space
                ProduceEmptySpace();

                // Sleep for the specified production rate with randomness if enabled
                int sleepDuration = enableRandomness ? PoissonRandom(productionRate) : productionRate;
                Thread.Sleep(sleepDuration);
            }
        }

        static void Consumer(int consumptionRate, bool enableRandomness)
        {
            while (true)
            {
                // Consume a space if available, otherwise wait
                if (ConsumeEmptySpace())
                {
                    // Start measuring waiting time
                    DateTime startTime = DateTime.Now;

                    // Simulate parking time
                    Thread.Sleep(consumptionRate);

                    // Calculate waiting time
                    int waitingTime = (int)(DateTime.Now - startTime).TotalMilliseconds;

                    // Record the waiting time
                    RecordWaitingTime(waitingTime);

                    // Car exits the parking lot
                    CarExits();
                }
            }
        }

        static void RecordWaitingTime(int waitingTime)
        {
            lock (tables)
            {
                waitingTimes.Add(waitingTime);
            }
        }

        static void ProduceEmptySpace()
        {
            lock (tables)
            {
                // If parking lot is full, wait for a consumer to create empty space
                while (tables.Count >= numOfTables)
                {
                    Monitor.Wait(tables);
                }

                // Producer creates an empty space
                tables.Enqueue(0);
                Console.WriteLine("Empty space produced. Total spaces: " + tables.Count);

                // Notify waiting consumers that an empty space is available
                Monitor.Pulse(tables);
            }
        }

        static bool ConsumeEmptySpace()
        {
            lock (tables)
            {
                // If parking lot is empty, wait for a producer to create an empty space
                while (tables.Count == 0)
                {
                    Monitor.Wait(tables);
                }

                // Consume an empty space
                tables.Dequeue();
                Console.WriteLine("Car parked. Remaining spaces: " + tables.Count);

                // Notify waiting producers that an empty space is available
                Monitor.Pulse(tables);

                return true;
            }
        }

        static void CarExits()
        {
            lock (tables)
            {
                totalClientsFinished++;
                Console.WriteLine("Car exited. Remaining spaces: " + tables.Count);

                // Notify waiting producers that a space is available after car exit
                Monitor.Pulse(tables);
            }
        }

        static void Statistics()
        {
            while (true)
            {
                List<int> waitingTimesCopy;
                lock (tables)
                {
                    // Calculate capacity percentage
                    double capacityPercentage = (double)tables.Count / numOfTables * 100;

                    // Calculate number of cars waiting
                    int numCarsWaiting = totalSittingClients - totalClientsFinished;

                    // Calculate average waiting time
                    double averageWaitingTime = waitingTimes.Count > 0 ? waitingTimes.Average() : 0;

                    // Calculate maximum waiting time
                    int maxTime = waitingTimes.Count > 0 ? waitingTimes.Max() : 0;

                    Console.WriteLine($"Capacity Percentage: {capacityPercentage:F2}%");
                    Console.WriteLine($"Number of Cars Waiting: {numCarsWaiting}");
                    Console.WriteLine($"Average Waiting Time: {averageWaitingTime:F2} milliseconds");
                    Console.WriteLine($"Maximum Waiting Time: {maxTime} milliseconds");

                    // Create a copy of waitingTimes list before clearing it
                    waitingTimesCopy = new List<int>(waitingTimes);

                    // Reset waiting times
                    waitingTimes.Clear();
                }

                // Perform Poisson distribution analysis
                Console.WriteLine("\n--- Poisson Distribution Analysis ---");
                double poissonMean = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average() : 0;
                double poissonVariance = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average(t => Math.Pow(t - poissonMean, 2)) : 0;
                Console.WriteLine($"Mean: {poissonMean:F2}");
                Console.WriteLine($"Variance: {poissonVariance:F2}");
                Console.WriteLine($"Standard Deviation: {Math.Sqrt(poissonVariance):F2}");

                // Perform Normal distribution analysis
                Console.WriteLine("\n--- Normal Distribution Analysis ---");
                double normalMean = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average() : 0;
                double normalVariance = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average(t => Math.Pow(t - normalMean, 2)) : 0;
                Console.WriteLine($"Mean: {normalMean:F2}");
                Console.WriteLine($"Variance: {normalVariance:F2}");
                Console.WriteLine($"Standard Deviation: {Math.Sqrt(normalVariance):F2}");

                // Perform Exponential distribution analysis
                Console.WriteLine("\n--- Exponential Distribution Analysis ---");
                double exponentialMean = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average() : 0;
                double exponentialVariance = waitingTimesCopy.Count > 0 ? waitingTimesCopy.Average(t => Math.Pow(t - exponentialMean, 2)) : 0;
                Console.WriteLine($"Mean: {exponentialMean:F2}");
                Console.WriteLine($"Variance: {exponentialVariance:F2}");
                Console.WriteLine($"Standard Deviation: {Math.Sqrt(exponentialVariance):F2}");

                // Wait for 5 seconds before displaying statistics again
                Thread.Sleep(5000);
            }
        }

        static int PoissonRandom(double lambda)
        {
            double L = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;

            do
            {
                k++;
                p *= random.NextDouble();
            } while (p > L);

            return k - 1;
        }
    }
}   
