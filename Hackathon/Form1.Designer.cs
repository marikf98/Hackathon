﻿namespace Hackathon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown numberOfProducersNumericUpDown;
        private System.Windows.Forms.NumericUpDown numberOfConsumersNumericUpDown;
        private System.Windows.Forms.NumericUpDown producerRateNumericUpDown;
        private System.Windows.Forms.NumericUpDown consumerRateNumericUpDown;
        private System.Windows.Forms.Label numberOfProducersLabel;
        private System.Windows.Forms.Label numberOfConsumersLabel;
        private System.Windows.Forms.Label producerRateLabel;
        private System.Windows.Forms.Label consumerRateLabel;
        private System.Windows.Forms.Button startSimulationButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

