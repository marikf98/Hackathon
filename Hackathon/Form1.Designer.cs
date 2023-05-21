namespace Hackathon
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
            this.numberOfProducersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfConsumersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.producerRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.consumerRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfProducersLabel = new System.Windows.Forms.Label();
            this.numberOfConsumersLabel = new System.Windows.Forms.Label();
            this.producerRateLabel = new System.Windows.Forms.Label();
            this.consumerRateLabel = new System.Windows.Forms.Label();
            this.startSimulationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfProducersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfConsumersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producerRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consumerRateNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // numberOfProducersNumericUpDown
            this.numberOfProducersNumericUpDown.Location = new System.Drawing.Point(220, 30);
            this.numberOfProducersNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numberOfProducersNumericUpDown.Name = "numberOfProducersNumericUpDown";
            this.numberOfProducersNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.numberOfProducersNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // numberOfConsumersNumericUpDown
            this.numberOfConsumersNumericUpDown.Location = new System.Drawing.Point(220, 80);
            this.numberOfConsumersNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numberOfConsumersNumericUpDown.Name = "numberOfConsumersNumericUpDown";
            this.numberOfConsumersNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.numberOfConsumersNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // producerRateNumericUpDown
            this.producerRateNumericUpDown.Location = new System.Drawing.Point(220, 130);
            this.producerRateNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.producerRateNumericUpDown.Name = "producerRateNumericUpDown";
            this.producerRateNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.producerRateNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // consumerRateNumericUpDown
            this.consumerRateNumericUpDown.Location = new System.Drawing.Point(220, 180);
            this.consumerRateNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.consumerRateNumericUpDown.Name = "consumerRateNumericUpDown";
            this.consumerRateNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.consumerRateNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // numberOfProducersLabel
            this.numberOfProducersLabel.AutoSize = true;
            this.numberOfProducersLabel.Location = new System.Drawing.Point(40, 35);
            this.numberOfProducersLabel.Name = "numberOfProducersLabel";
            this.numberOfProducersLabel.Size = new System.Drawing.Size(136, 15);
            this.numberOfProducersLabel.Text = "Number of Producers:";

            // numberOfConsumersLabel
            this.numberOfConsumersLabel.AutoSize = true;
            this.numberOfConsumersLabel.Location = new System.Drawing.Point(40, 85);
            this.numberOfConsumersLabel.Name = "numberOfConsumersLabel";
            this.numberOfConsumersLabel.Size = new System.Drawing.Size(137, 15);
            this.numberOfConsumersLabel.Text = "Number of Consumers:";

            // producerRateLabel
            this.producerRateLabel.AutoSize = true;
            this.producerRateLabel.Location = new System.Drawing.Point(40, 135);
            this.producerRateLabel.Name = "producerRateLabel";
            this.producerRateLabel.Size = new System.Drawing.Size(92, 15);
            this.producerRateLabel.Text = "Producer Rate:";

            // consumerRateLabel
            this.consumerRateLabel.AutoSize = true;
            this.consumerRateLabel.Location = new System.Drawing.Point(40, 185);
            this.consumerRateLabel.Name = "consumerRateLabel";
            this.consumerRateLabel.Size = new System.Drawing.Size(98, 15);
            this.consumerRateLabel.Text = "Consumer Rate:";

            // startSimulationButton
            this.startSimulationButton.Location = new System.Drawing.Point(160, 240);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(120, 30);
            this.startSimulationButton.Text = "Start Simulation";
            this.startSimulationButton.Click += new System.EventHandler(this.startSimulationButton_Click);

            // SimulationDataInputForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.startSimulationButton);
            this.Controls.Add(this.consumerRateLabel);
            this.Controls.Add(this.producerRateLabel);
            this.Controls.Add(this.numberOfConsumersLabel);
            this.Controls.Add(this.numberOfProducersLabel);
            this.Controls.Add(this.consumerRateNumericUpDown);
            this.Controls.Add(this.producerRateNumericUpDown);
            this.Controls.Add(this.numberOfConsumersNumericUpDown);
            this.Controls.Add(this.numberOfProducersNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimulationDataInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cosmic Cafe: Simulation Data Input";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfProducersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfConsumersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producerRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consumerRateNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

