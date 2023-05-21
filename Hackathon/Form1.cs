using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackathon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            // Retrieve the input values
            int numberOfProducers = (int)numberOfProducersNumericUpDown.Value;
            int numberOfConsumers = (int)numberOfConsumersNumericUpDown.Value;
            int producerRate = (int)producerRateNumericUpDown.Value;
            int consumerRate = (int)consumerRateNumericUpDown.Value;

            // Validate the input values (you can add your own validation logic)
            if (numberOfProducers <= 0 || numberOfConsumers <= 0 || producerRate <= 0 || consumerRate <= 0)
            {
                MessageBox.Show("Please enter valid simulation data.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pass the simulation data to the next screen or initiate the simulation
            // You can open the next screen or start the simulation based on your implementation
            // For example, you can create a new instance of the simulation form and pass the data to it
            

            // Close the current input form (optional)
            this.Hide();
        }


    }
}
