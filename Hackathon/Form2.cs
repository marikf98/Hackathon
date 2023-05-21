using Car_park_producer_consumer_problem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Hackathon
{
    public partial class Form2 : Form
    {
        private Stopwatch stopwatch;
        private int Orders;
        private int Chefs;
        private int production_rate;
        private int chefs_rate;
        private ProducerConsumer producerConsumer;


        public Form2(int orders, int chefs, int production_rate, int chefs_rate)
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            Orders = orders;
            Chefs = chefs;
            this.production_rate = production_rate;
            this.chefs_rate = chefs_rate;
            producerConsumer = new ProducerConsumer(chefs,orders, chefs_rate, orders);

            stopwatch.Start();

            // Start the Timer
            timer1.Start();
         
        }

    



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            // Your simulation or program code goes here
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Calculate the elapsed time in seconds
            double seconds = stopwatch.Elapsed.TotalSeconds;

            // Display the elapsed time in the textBox10
            textBox10.Text = seconds.ToString("F2");
            textBox9.Text = producerConsumer.capacityPercentage.ToString();

            textBox7.Text= producerConsumer.dishes.Count.ToString();
        }
    }
}
