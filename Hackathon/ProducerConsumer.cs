using System.Linq;

namespace Car_park_producer_consumer_problem
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    internal  class ProducerConsumer
    {
        public Queue<int> dishes = new Queue<int>();
        public int counterSize = 10;
        public int totalDishesOnTheCounter = 0;
        public int totalDishesServed = 0;
        public List<int> waitingTimes = new List<int>();
        public int maxWaitingTime = 0;
        public Random random = new Random();

        public ProducerConsumer(int chefs,int order, int cook_rate,int ordersrate)
        {
            this.dishes = dishes;
            this.counterSize = counterSize;
            for (int i = 0; i < chefs; i++)
            {
                Thread producerThread = new Thread(() => Producer(ordersrate, false));
                producerThread.Start();
            }

            // Create customer threads
            for (int i = 0; i < order; i++)
            {
                Thread consumerThread = new Thread(() =>Consumer(cook_rate, false));
                consumerThread.Start();
            }

            // Create statistical analysis thread
            Thread statisticsThread = new Thread(Statistics);
            statisticsThread.Start();


        }





        

        public void Producer(int productionRate, bool enableRandomness)
        {
            while (true)
            {
                // Produce an empty space
                ProduceNewDish();

                // Sleep for the specified production rate with randomness if enabled
                int sleepDuration = enableRandomness ? PoissonRandom(productionRate) : productionRate;
                Thread.Sleep(sleepDuration);
                dishes.Enqueue(0);
            }
        }
        
        /*static void Consumer(int consumptionRate, bool enableRandomness)
        {
            while (true)
            {
                // Consume a space if available, otherwise wait
                if (TakeDishFromCounter())
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
                    DishTaken();
                }
            }
        }*/
        
        /*static void Consumer(int consumptionRate, bool enableRandomness)
        {
            while (true)
            {
                lock (dishes)
                {
                    // Wait until a dish is available on the counter
                    while (dishes.Count == 0)
                    {
                        Monitor.Wait(dishes);
                    }

                    // Consume a dish
                    dishes.Dequeue();
                    Console.WriteLine("Dish taken from the counter. Total dishes on the counter: " + dishes.Count + " Remaining space on the counter " + (counterSize - dishes.Count));

                    // Notify waiting producers that a dish has been taken
                    Monitor.Pulse(dishes);
                }

                // Start measuring waiting time
                DateTime startTime = DateTime.Now;

                // Simulate consumption time
                Thread.Sleep(consumptionRate);

                // Calculate waiting time
                int waitingTime = (int)(DateTime.Now - startTime).TotalMilliseconds;

                // Record the waiting time
                RecordWaitingTime(waitingTime);

                // Car exits the parking lot
                DishTaken();
            }
        }*/
        
        public void Consumer(int consumptionRate, bool enableRandomness)
        {
            while (true)
            {
                int dishCount;
                lock (dishes)
                {
                    dishCount = dishes.Count;
                }

                if (dishCount > 0)
                {
                    lock (dishes)
                    {
                        if (dishes.Count > 0)
                        {
                            // Consume an empty space
                            dishes.Dequeue();
                            Console.WriteLine("Dish taken. Remaining free spaces on the counter: " + (counterSize - dishes.Count) + " remaining dishes " + dishes.Count);

                            // Notify waiting producers that an empty space is available
                            Monitor.Pulse(dishes);
                        }
                    }

                    // Start measuring waiting time
                    DateTime startTime = DateTime.Now;

                    // Simulate consuming time
                    Thread.Sleep(consumptionRate);

                    // Calculate waiting time
                    int waitingTime = (int)(DateTime.Now - startTime).TotalMilliseconds;

                    // Record the waiting time
                    RecordWaitingTime(waitingTime);
                }
            }
        }

        public void RecordWaitingTime(int waitingTime)
        {
            lock (dishes)
            {
                waitingTimes.Add(waitingTime);
            }
        }
        
        public void ProduceNewDish()
        {
            lock (dishes)
            {
                // If parking lot is full, wait for a consumer to create empty space
                while (dishes.Count >= counterSize)
                {
                    Monitor.Wait(dishes);
                }

                // Producer creates an empty space
                dishes.Enqueue(0);
                Console.WriteLine("New dish produced. Total dishes on the counter: " + dishes.Count + " Remaining space on the counter " + (counterSize -dishes.Count));

                // Notify waiting consumers that an empty space is available
                Monitor.Pulse(dishes);
            }
        }
        
        public bool TakeDishFromCounter()
        {
            lock (dishes)
            {
                /*// If parking lot is empty, wait for a producer to create an empty space
                while (dishes.Count == 0)
                {
                    Monitor.Wait(dishes);
                }*/
                
                if (dishes.Count == 0)
                {
                    return false;
                }

                // Consume an empty space
                dishes.Dequeue();
                Console.WriteLine("Dish taken from the counter. Total dishes on the counter: " + dishes.Count + " Remaining space on the counter " + (counterSize - dishes.Count));

                // Notify waiting producers that an empty space is available
                Monitor.Pulse(dishes);

                return true;
            }
        }
        
        
        public void DishTaken()
        {
            lock (dishes)
            {
                if (dishes.Count == 0)
                {
                    return;
                }
                totalDishesServed++;
                Console.WriteLine("Dish taken. Remaining free spaces on the counter: " + (counterSize - dishes.Count) + "remaining dishes " + dishes.Count);

                // Notify waiting producers that a space is available after a dish was taken
                Monitor.Pulse(dishes);
            }
        }
        

        
    public void Statistics()
    {
        while (true)
        {
            List<int> waitingTimesCopy;
            lock (dishes)
            {
                // Calculate capacity percentage

                double capacityPercentage = ((double)(dishes.Count) / counterSize) * 100;
                int numberOfCustomersWaitingToTakeDish = totalDishesOnTheCounter - dishes.Count;

                Console.WriteLine($"Capacity Percentage: {capacityPercentage:F2}%");
                Console.WriteLine($"Number of Customers waiting to get a dish: {numberOfCustomersWaitingToTakeDish}");

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

    public int PoissonRandom(double lambda)
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