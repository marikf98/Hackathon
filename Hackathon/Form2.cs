using Car_park_producer_consumer_problem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ThreadState = System.Threading.ThreadState;

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
        private List<PictureBox> chefPictureBoxes;
        private List<PictureBox> orderPictureBoxes2;
        private SoundPlayer restaurantSoundPlayer2;
        private SoundPlayer restaurantSoundPlayer3;
        private PictureBox smokePictureBox;


        public Form2(int orders, int chefs, int production_rate, int chefs_rate)
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            Orders = orders;
            Chefs = chefs;
            this.production_rate = production_rate;
            this.chefs_rate = chefs_rate;
            producerConsumer = new ProducerConsumer(chefs, orders, chefs_rate, orders);
            chefPictureBoxes = new List<PictureBox>();
            orderPictureBoxes2=new List<PictureBox>();
            smokePictureBox = pictureBox5;
            smokePictureBox.Visible = false;

            orderPictureBoxes2.Add(pictureBox11);
            orderPictureBoxes2.Add(pictureBox7);
            orderPictureBoxes2.Add(pictureBox6);
            orderPictureBoxes2.Add(pictureBox2);
            orderPictureBoxes2.Add(pictureBox9);
            orderPictureBoxes2.Add(pictureBox8);
            orderPictureBoxes2.Add(pictureBox3);
            orderPictureBoxes2.Add(pictureBox12);
            orderPictureBoxes2.Add(pictureBox10);
            orderPictureBoxes2.Add(pictureBox4);
            for (int i = 0; i < orderPictureBoxes2.Count; i++)
            {
                PictureBox chefPictureBox =  orderPictureBoxes2[i];
                chefPictureBox.Visible = false;

            }


                // Calculate the size and spacing for each chef image
                int imageSize = 200; // Set the desired size of the chef image
            int spacing = 20; // Set the desired spacing between chef images
            int totalWidth = chefs * (imageSize + spacing) - spacing; // Calculate the total width required for all chef images






            
        













            // Calculate the starting X position for the first chef image
            Point point = new Point(400,300);
            int spacer = 40;
            int startX = 400;

            for (int i = 0; i < chefs; i++)
            {




                Image image = Properties.Resources.alien1;
                // Create and configure the PictureBox control
                PictureBox chefPictureBox = new PictureBox();
                chefPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                chefPictureBox.Size = new Size(40, 40);
                point.X = 600 + (spacer * i);



                chefPictureBox.Location = point;
                chefPictureBox.Image= image;
                chefPictureBox.BorderStyle = BorderStyle.Fixed3D;
                chefPictureBox.BackColor = Color.Transparent;




                // Add the PictureBox control to the panel and the list

                chefPictureBoxes.Add(chefPictureBox);
                this.Controls.Add(chefPictureBox);
                chefPictureBox.BringToFront();
               









            }
            restaurantSoundPlayer2 = new SoundPlayer(Properties.Resources.chattering_in_a_restaurant_6718);

            // Set the sound player to loop
            restaurantSoundPlayer2.PlayLooping();

           

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
            restaurantSoundPlayer2.Stop();
            restaurantSoundPlayer3 = new SoundPlayer(Properties.Resources.kl_peach_game_over_iii_142453);
            restaurantSoundPlayer3.Play();
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
            Thread.Sleep(3000);
           

            // Set the sound player to loop

            Application.Exit();

            // Optionally, you can hide the current form if needed
            this.Hide();
            
            

            // Set the sound player to loop

            

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
            textBox7.Text = producerConsumer.numberOfCustomersWaitingToTakeDish.ToString();
            textBox6.Text = producerConsumer.exponentialMean.ToString();
            textBox11.Text = producerConsumer.exponentialVariance.ToString();
            textBox13.Text = producerConsumer.normalVariance.ToString();
            textBox15.Text = producerConsumer.normalMean.ToString();
            textBox19.Text = producerConsumer.poissonMean.ToString();
            textBox17.Text = producerConsumer.poissonVariance.ToString();
            int eater = this.producerConsumer.get_treds_id();
            // int eater = producerConsumer.order;
            
            for(int i=0; i < this.orderPictureBoxes2.Count; i++)
            {
                eater -= i;
                
                if (eater>0)
                {
                    orderPictureBoxes2[i].Visible = true;
                }
                else
                {
                    orderPictureBoxes2[i].Visible = false;
                }
            }
         

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private async void StartSmokeAnimation()
        {
            Label gameOverLabel = new Label();
            gameOverLabel.Text = "Game Over";
            gameOverLabel.Font = new Font("Arial", 100, FontStyle.Bold);
            gameOverLabel.ForeColor = Color.White;
            gameOverLabel.BackColor = Color.Black;
            gameOverLabel.AutoSize = false;
            gameOverLabel.Size = ClientSize;
            gameOverLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(gameOverLabel);
            gameOverLabel.BringToFront();
        }








    }
}
