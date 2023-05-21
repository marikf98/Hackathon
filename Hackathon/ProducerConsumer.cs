using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hackathon
{
    internal class Order
    {
        public int Id { get; }

        public Order(int id)
        {
            Id = id;
        }
    }

    internal class ProducerConsumer
    {
        private int orders;
        private int chefs;
        private int rate_cook;
        private int rate_eating;
        private int bufferSize;
        private Queue<Order> ordersQueue;
        private object lockObject = new object();

        public ProducerConsumer(int orders, int chefs, int rate_cook, int rate_eating)
        {
            this.orders = orders;
            this.chefs = chefs;
            this.rate_cook = rate_cook;
            this.rate_eating = rate_eating;
            this.bufferSize = chefs * 2;
            ordersQueue = new Queue<Order>();
        }

        public void Start()
        {
            Task.Run(Produce);
            Task.Run(Consume);
        }

        private void Produce()
        {
            for (int i = 0; i < orders; i++)
            {
                // Produce an order
                Order order = new Order(i + 1);

                // Add the order to the buffer
                AddToBuffer(order);

                // Sleep for a while before producing the next order
                Thread.Sleep(rate_cook);
            }
        }

        private void Consume()
        {
            int consumedOrders = 0;

            while (consumedOrders < orders)
            {
                Order order = null;

                lock (lockObject)
                {
                    if (ordersQueue.Count > 0)
                        order = ordersQueue.Dequeue();
                }

                if (order != null)
                {
                    // Process the order (e.g., chefs start cooking or customers start eating)
                    Console.WriteLine("Order {0} is being consumed.", order.Id);

                    // Sleep for a while before consuming the next order
                    Thread.Sleep(rate_eating);

                    consumedOrders++;
                }
            }
        }

        private void AddToBuffer(Order order)
        {
            lock (lockObject)
            {
                // Wait until there is space in the buffer
                while (ordersQueue.Count >= bufferSize)
                {
                    Monitor.Wait(lockObject);
                }

                // Add the order to the buffer
                ordersQueue.Enqueue(order);

                // Notify waiting threads that an order is added to the buffer
                Monitor.PulseAll(lockObject);
            }
        }

        public double CalculateOrderPercentage()
        {
            lock (lockObject)
            {
                int bufferCount = ordersQueue.Count;
                double percentage = (double)bufferCount / bufferSize * 100;
                return percentage;
            }
        }


    }
}
