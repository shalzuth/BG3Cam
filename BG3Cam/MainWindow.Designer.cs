namespace BG3Cam
{
    partial class MainWindow
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
            maxZoomVal = new NumericUpDown();
            minZoomVal = new NumericUpDown();
            labelMax = new Label();
            labelMin = new Label();
            mouseTiltTask = new System.ComponentModel.BackgroundWorker();
            note = new Label();
            ((System.ComponentModel.ISupportInitialize)maxZoomVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minZoomVal).BeginInit();
            SuspendLayout();
            // 
            // maxZoomVal
            // 
            maxZoomVal.DecimalPlaces = 1;
            maxZoomVal.Location = new Point(170, 12);
            maxZoomVal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            maxZoomVal.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            maxZoomVal.Name = "maxZoomVal";
            maxZoomVal.Size = new Size(120, 23);
            maxZoomVal.TabIndex = 1;
            maxZoomVal.Value = new decimal(new int[] { 12, 0, 0, 0 });
            maxZoomVal.ValueChanged += maxZoomVal_ValueChanged;
            // 
            // minZoomVal
            // 
            minZoomVal.DecimalPlaces = 1;
            minZoomVal.Location = new Point(170, 41);
            minZoomVal.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            minZoomVal.Name = "minZoomVal";
            minZoomVal.Size = new Size(120, 23);
            minZoomVal.TabIndex = 2;
            minZoomVal.Value = new decimal(new int[] { 35, 0, 0, 65536 });
            minZoomVal.ValueChanged += minZoomVal_ValueChanged;
            // 
            // labelMax
            // 
            labelMax.AutoSize = true;
            labelMax.Location = new Point(102, 14);
            labelMax.Name = "labelMax";
            labelMax.Size = new Size(65, 15);
            labelMax.TabIndex = 3;
            labelMax.Text = "Max Zoom";
            // 
            // labelMin
            // 
            labelMin.AutoSize = true;
            labelMin.Location = new Point(104, 43);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(63, 15);
            labelMin.TabIndex = 4;
            labelMin.Text = "Min Zoom";
            // 
            // note
            // 
            note.AutoSize = true;
            note.Location = new Point(25, 69);
            note.Name = "note";
            note.Size = new Size(259, 30);
            note.TabIndex = 5;
            note.Text = "Note - when moving the camera up and down,\r\nthe camera pans slowly due to the game engine";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 111);
            Controls.Add(note);
            Controls.Add(labelMin);
            Controls.Add(labelMax);
            Controls.Add(minZoomVal);
            Controls.Add(maxZoomVal);
            Name = "MainWindow";
            Text = "Baldur's Gate 3 Camera Mod";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)maxZoomVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)minZoomVal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown maxZoomVal;
        private NumericUpDown minZoomVal;
        private Label labelMax;
        private Label labelMin;
        private System.ComponentModel.BackgroundWorker mouseTiltTask;
        private Label note;
    }
}