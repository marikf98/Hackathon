﻿using System.Windows.Forms;
using System;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Hackathon
{
    public partial class Form1 : Form
    {
        private SoundPlayer restaurantSoundPlayer;
        //private ProducerConsumer producerConsumer;
        public Form1()
        {
            InitializeComponent();
            // Initialize the restaurant sound player with the sound file from resources
            restaurantSoundPlayer = new SoundPlayer(Properties.Resources.spaceship);

            // Set the sound player to loop
            restaurantSoundPlayer.PlayLooping();

            //producerConsumer = new ProducerConsumer();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            restaurantSoundPlayer.Stop();
            restaurantSoundPlayer = new SoundPlayer(Properties.Resources.dorm_door_opening_6038);
            restaurantSoundPlayer.Play();
           


            Form2 form2 = new Form2((int)numericUpDown2.Value, (int)numericUpDown1.Value, ((int)numericUpDown3.Value * 1000), ((int)numericUpDown4.Value) * 1000);


            // Display the new form
            form2.Show();

            // Optionally, you can hide the current form if needed
            this.Hide();
        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}