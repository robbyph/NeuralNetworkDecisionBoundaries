namespace NeuralNetworkFromScratch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            graphDisplay = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            trackBar6 = new TrackBar();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)graphDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            SuspendLayout();
            // 
            // graphDisplay
            // 
            graphDisplay.Location = new Point(2, 1);
            graphDisplay.Name = "graphDisplay";
            graphDisplay.Size = new Size(1679, 1000);
            graphDisplay.TabIndex = 0;
            graphDisplay.TabStop = false;
            graphDisplay.Click += graphDisplay_Click;
            graphDisplay.Paint += graphDisplay_Paint;
            graphDisplay.MouseDown += graphDisplay_MouseDown;
            graphDisplay.MouseMove += graphDisplay_MouseMove;
            graphDisplay.MouseUp += graphDisplay_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1749, 9);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 1;
            label1.Text = "Weights";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1749, 135);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 2;
            label2.Text = "Biases";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1687, 37);
            trackBar1.Maximum = 1000;
            trackBar1.Minimum = -1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 3;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(1687, 78);
            trackBar2.Maximum = 1000;
            trackBar2.Minimum = -1000;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(104, 45);
            trackBar2.TabIndex = 4;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(1788, 37);
            trackBar3.Maximum = 1000;
            trackBar3.Minimum = -1000;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(104, 45);
            trackBar3.TabIndex = 5;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(1788, 78);
            trackBar4.Maximum = 1000;
            trackBar4.Minimum = -1000;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(104, 45);
            trackBar4.TabIndex = 6;
            // 
            // trackBar5
            // 
            trackBar5.Location = new Point(1687, 174);
            trackBar5.Maximum = 1000;
            trackBar5.Minimum = -1000;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(104, 45);
            trackBar5.TabIndex = 7;
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(1788, 174);
            trackBar6.Maximum = 1000;
            trackBar6.Minimum = -1000;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(104, 45);
            trackBar6.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(1739, 260);
            button1.Name = "button1";
            button1.Size = new Size(104, 38);
            button1.TabIndex = 9;
            button1.Text = "Boundary Mode";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1003);
            Controls.Add(button1);
            Controls.Add(trackBar6);
            Controls.Add(trackBar5);
            Controls.Add(trackBar4);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(graphDisplay);
            MaximumSize = new Size(1920, 1042);
            MinimumSize = new Size(1918, 1038);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)graphDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox graphDisplay;
        private Label label1;
        private Label label2;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private TrackBar trackBar6;
        private Button button1;
    }
}