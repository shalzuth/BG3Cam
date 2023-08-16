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
            checkBox1 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            cameraHeightVal = new NumericUpDown();
            tacticalZoomMaxVal = new NumericUpDown();
            labelCameraHeight = new Label();
            labelTactMaxZoom = new Label();
            labelTactMinZoom = new Label();
            tacticalZoomMinVal = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)maxZoomVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minZoomVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panSpeedVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraDistanceVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scrollSpeedVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fovVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraHeightVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tacticalZoomMaxVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tacticalZoomMinVal).BeginInit();
            SuspendLayout();
            // 
            // maxZoomVal
            // 
            maxZoomVal.DecimalPlaces = 1;
            maxZoomVal.Location = new Point(131, 18);
            maxZoomVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            maxZoomVal.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            maxZoomVal.Name = "maxZoomVal";
            maxZoomVal.Size = new Size(120, 23);
            maxZoomVal.TabIndex = 1;
            maxZoomVal.Value = new decimal(new int[] { 24, 0, 0, 0 });
            maxZoomVal.ValueChanged += maxZoomVal_ValueChanged;
            // 
            // minZoomVal
            // 
            minZoomVal.DecimalPlaces = 1;
            minZoomVal.Location = new Point(131, 47);
            minZoomVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
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
            panSpeedVal.Location = new Point(131, 132);
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
            cameraDistanceVal.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            cameraDistanceVal.Location = new Point(131, 190);
            cameraDistanceVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            cameraDistanceVal.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            cameraDistanceVal.Name = "cameraDistanceVal";
            cameraDistanceVal.Size = new Size(120, 23);
            cameraDistanceVal.TabIndex = 8;
            cameraDistanceVal.Value = new decimal(new int[] { 50, 0, 0, 0 });
            cameraDistanceVal.ValueChanged += cameraDistanceVal_ValueChanged;
            // 
            // scrollSpeedVal
            // 
            scrollSpeedVal.DecimalPlaces = 1;
            scrollSpeedVal.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            scrollSpeedVal.Location = new Point(131, 219);
            scrollSpeedVal.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            scrollSpeedVal.Name = "scrollSpeedVal";
            scrollSpeedVal.Size = new Size(120, 23);
            scrollSpeedVal.TabIndex = 9;
            scrollSpeedVal.Value = new decimal(new int[] { 8, 0, 0, 65536 });
            scrollSpeedVal.ValueChanged += scrollSpeedVal_ValueChanged;
            // 
            // fovVal
            // 
            fovVal.DecimalPlaces = 1;
            fovVal.Location = new Point(131, 161);
            fovVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            fovVal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fovVal.Name = "fovVal";
            fovVal.Size = new Size(120, 23);
            fovVal.TabIndex = 10;
            fovVal.Value = new decimal(new int[] { 30, 0, 0, 0 });
            fovVal.ValueChanged += fovVal_ValueChanged;
            // 
            // labelMax
            // 
            labelMax.AutoSize = true;
            labelMax.Location = new Point(60, 18);
            labelMax.Name = "labelMax";
            labelMax.Size = new Size(65, 15);
            labelMax.TabIndex = 3;
            labelMax.Text = "Max Zoom";
            // 
            // labelMin
            // 
            labelMin.AutoSize = true;
            labelMin.Location = new Point(62, 47);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(63, 15);
            labelMin.TabIndex = 4;
            labelMin.Text = "Min Zoom";
            // 
            // labelPan
            // 
            labelPan.AutoSize = true;
            labelPan.Location = new Point(67, 132);
            labelPan.Name = "labelPan";
            labelPan.Size = new Size(58, 15);
            labelPan.TabIndex = 6;
            labelPan.Text = "Tilt Speed";
            // 
            // labelFOV
            // 
            labelFOV.AutoSize = true;
            labelFOV.Location = new Point(96, 161);
            labelFOV.Name = "labelFOV";
            labelFOV.Size = new Size(29, 15);
            labelFOV.TabIndex = 11;
            labelFOV.Text = "FOV";
            // 
            // labelCameraDistance
            // 
            labelCameraDistance.AutoSize = true;
            labelCameraDistance.Location = new Point(32, 190);
            labelCameraDistance.Name = "labelCameraDistance";
            labelCameraDistance.Size = new Size(96, 15);
            labelCameraDistance.TabIndex = 12;
            labelCameraDistance.Text = "Camera Distance";
            // 
            // labelScrollSpeed
            // 
            labelScrollSpeed.AutoSize = true;
            labelScrollSpeed.Location = new Point(54, 219);
            labelScrollSpeed.Name = "labelScrollSpeed";
            labelScrollSpeed.Size = new Size(71, 15);
            labelScrollSpeed.TabIndex = 13;
            labelScrollSpeed.Text = "Scroll Speed";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(103, 277);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(148, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Combat Camera Zoom";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 309);
            label1.Name = "label1";
            label1.Size = new Size(184, 15);
            label1.TabIndex = 15;
            label1.Text = "shalzuth - squyd - ch4nkyy - ssltg";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(12, 294);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 16;
            label2.Text = "Authors";
            // 
            // cameraHeightVal
            // 
            cameraHeightVal.DecimalPlaces = 5;
            cameraHeightVal.Increment = new decimal(new int[] { 2, 0, 0, 262144 });
            cameraHeightVal.Location = new Point(131, 248);
            cameraHeightVal.Minimum = new decimal(new int[] { 85, 0, 0, 327680 });
            cameraHeightVal.Name = "cameraHeightVal";
            cameraHeightVal.Size = new Size(120, 23);
            cameraHeightVal.TabIndex = 17;
            cameraHeightVal.Value = new decimal(new int[] { 85, 0, 0, 327680 });
            cameraHeightVal.ValueChanged += cameraHeightVal_ValueChanged;
            // 
            // tacticalZoomMaxVal
            // 
            tacticalZoomMaxVal.DecimalPlaces = 1;
            tacticalZoomMaxVal.Location = new Point(131, 76);
            tacticalZoomMaxVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            tacticalZoomMaxVal.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            tacticalZoomMaxVal.Name = "tacticalZoomMaxVal";
            tacticalZoomMaxVal.Size = new Size(120, 23);
            tacticalZoomMaxVal.TabIndex = 18;
            tacticalZoomMaxVal.Value = new decimal(new int[] { 100, 0, 0, 0 });
            tacticalZoomMaxVal.ValueChanged += tacticalZoomVal_ValueChanged;
            // 
            // labelCameraHeight
            // 
            labelCameraHeight.AutoSize = true;
            labelCameraHeight.Location = new Point(38, 248);
            labelCameraHeight.Name = "labelCameraHeight";
            labelCameraHeight.Size = new Size(87, 15);
            labelCameraHeight.TabIndex = 19;
            labelCameraHeight.Text = "Camera Height";
            // 
            // labelTactMaxZoom
            // 
            labelTactMaxZoom.AutoSize = true;
            labelTactMaxZoom.Location = new Point(18, 76);
            labelTactMaxZoom.Name = "labelTactMaxZoom";
            labelTactMaxZoom.Size = new Size(107, 15);
            labelTactMaxZoom.TabIndex = 20;
            labelTactMaxZoom.Text = "Tactical Max Zoom";
            // 
            // labelTactMinZoom
            // 
            labelTactMinZoom.AutoSize = true;
            labelTactMinZoom.Location = new Point(20, 103);
            labelTactMinZoom.Name = "labelTactMinZoom";
            labelTactMinZoom.Size = new Size(105, 15);
            labelTactMinZoom.TabIndex = 22;
            labelTactMinZoom.Text = "Tactical Min Zoom";
            // 
            // tacticalZoomMinVal
            // 
            tacticalZoomMinVal.DecimalPlaces = 1;
            tacticalZoomMinVal.Location = new Point(131, 103);
            tacticalZoomMinVal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            tacticalZoomMinVal.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            tacticalZoomMinVal.Name = "tacticalZoomMinVal";
            tacticalZoomMinVal.Size = new Size(120, 23);
            tacticalZoomMinVal.TabIndex = 21;
            tacticalZoomMinVal.Value = new decimal(new int[] { 5, 0, 0, 0 });
            tacticalZoomMinVal.ValueChanged += tacticalZoomMinVal_ValueChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(263, 329);
            Controls.Add(labelTactMinZoom);
            Controls.Add(tacticalZoomMinVal);
            Controls.Add(labelTactMaxZoom);
            Controls.Add(labelCameraHeight);
            Controls.Add(tacticalZoomMaxVal);
            Controls.Add(cameraHeightVal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox1);
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
            ((System.ComponentModel.ISupportInitialize)cameraHeightVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)tacticalZoomMaxVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)tacticalZoomMinVal).EndInit();
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
        private CheckBox checkBox1;
        private Label label1;
        private Label label2;
        private NumericUpDown cameraHeightVal;
        private NumericUpDown tacticalZoomMaxVal;
        private Label labelCameraHeight;
        private Label labelTactMaxZoom;
        private Label labelTactMinZoom;
        private NumericUpDown tacticalZoomMinVal;
    }
}
