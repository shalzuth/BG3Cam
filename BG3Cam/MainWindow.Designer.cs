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
            panSpeedVal = new NumericUpDown();
            cameraDistanceVal = new NumericUpDown();
            scrollSpeedVal = new NumericUpDown();
            fovVal = new NumericUpDown();
            labelMax = new Label();
            labelMin = new Label();
            labelPan = new Label();
            labelFOV = new Label();
            labelCameraDistance = new Label();
            labelScrollSpeed = new Label();
            mouseTiltTask = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)maxZoomVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minZoomVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panSpeedVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraDistanceVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scrollSpeedVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fovVal).BeginInit();
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
            // panSpeedVal
            // 
            panSpeedVal.DecimalPlaces = 1;
            panSpeedVal.Location = new Point(170, 70);
            panSpeedVal.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            panSpeedVal.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            panSpeedVal.Name = "panSpeedVal";
            panSpeedVal.Size = new Size(120, 23);
            panSpeedVal.TabIndex = 5;
            panSpeedVal.Value = new decimal(new int[] { 30, 0, 0, 0 });
            panSpeedVal.ValueChanged += panSpeedVal_ValueChanged;
            // 
            // cameraDistanceVal
            // 
            cameraDistanceVal.DecimalPlaces = 1;
            cameraDistanceVal.Location = new Point(170, 128);
            cameraDistanceVal.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            cameraDistanceVal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            cameraDistanceVal.Name = "cameraDistanceVal";
            cameraDistanceVal.Size = new Size(120, 23);
            cameraDistanceVal.TabIndex = 8;
            cameraDistanceVal.Value = new decimal(new int[] { 30, 0, 0, 0 });
            cameraDistanceVal.ValueChanged += cameraDistanceVal_ValueChanged;
            // 
            // scrollSpeedVal
            // 
            scrollSpeedVal.DecimalPlaces = 1;
            scrollSpeedVal.Location = new Point(170, 157);
            scrollSpeedVal.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            scrollSpeedVal.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            scrollSpeedVal.Name = "scrollSpeedVal";
            scrollSpeedVal.Size = new Size(120, 23);
            scrollSpeedVal.TabIndex = 9;
            scrollSpeedVal.Value = new decimal(new int[] { 10, 0, 0, 0 });
            scrollSpeedVal.ValueChanged += scrollSpeedVal_ValueChanged;
            // 
            // fovVal
            // 
            fovVal.DecimalPlaces = 1;
            fovVal.Location = new Point(170, 99);
            fovVal.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            fovVal.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            fovVal.Name = "fovVal";
            fovVal.Size = new Size(120, 23);
            fovVal.TabIndex = 10;
            fovVal.Value = new decimal(new int[] { 30, 0, 0, 0 });
            fovVal.ValueChanged += fovVal_ValueChanged;
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
            // labelPan
            // 
            labelPan.AutoSize = true;
            labelPan.Location = new Point(102, 70);
            labelPan.Name = "labelPan";
            labelPan.Size = new Size(62, 15);
            labelPan.TabIndex = 6;
            labelPan.Text = "Pan Speed";
            // 
            // labelFOV
            // 
            labelFOV.AutoSize = true;
            labelFOV.Location = new Point(135, 99);
            labelFOV.Name = "labelFOV";
            labelFOV.Size = new Size(29, 15);
            labelFOV.TabIndex = 11;
            labelFOV.Text = "FOV";
            // 
            // labelCameraDistance
            // 
            labelCameraDistance.AutoSize = true;
            labelCameraDistance.Location = new Point(71, 128);
            labelCameraDistance.Name = "labelCameraDistance";
            labelCameraDistance.Size = new Size(96, 15);
            labelCameraDistance.TabIndex = 12;
            labelCameraDistance.Text = "Camera Distance";
            // 
            // labelScrollSpeed
            // 
            labelScrollSpeed.AutoSize = true;
            labelScrollSpeed.Location = new Point(93, 157);
            labelScrollSpeed.Name = "labelScrollSpeed";
            labelScrollSpeed.Size = new Size(71, 15);
            labelScrollSpeed.TabIndex = 13;
            labelScrollSpeed.Text = "Scroll Speed";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 197);
            Controls.Add(labelScrollSpeed);
            Controls.Add(labelCameraDistance);
            Controls.Add(labelFOV);
            Controls.Add(fovVal);
            Controls.Add(scrollSpeedVal);
            Controls.Add(cameraDistanceVal);
            Controls.Add(labelPan);
            Controls.Add(panSpeedVal);
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
            ((System.ComponentModel.ISupportInitialize)panSpeedVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)cameraDistanceVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)scrollSpeedVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)fovVal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown maxZoomVal;
        private NumericUpDown minZoomVal;
        private NumericUpDown panSpeedVal;
        private NumericUpDown scrollSpeedVal;
        private NumericUpDown cameraDistanceVal;
        private NumericUpDown fovVal;
        private Label labelMax;
        private Label labelMin;
        private Label labelPan;
        private Label labelFOV;
        private Label labelCameraDistance;
        private Label labelScrollSpeed;
        private System.ComponentModel.BackgroundWorker mouseTiltTask;
    }
}