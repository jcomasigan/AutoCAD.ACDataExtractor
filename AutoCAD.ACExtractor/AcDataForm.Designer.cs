namespace AutoCADDataExtractor
{
    partial class AcDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.coordEastingTxtBox = new System.Windows.Forms.TextBox();
            this.coordNorthingTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bboxNumInput = new System.Windows.Forms.NumericUpDown();
            this.getDataButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.imageXinput = new System.Windows.Forms.NumericUpDown();
            this.imageYinput = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bboxNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageXinput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageYinput)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageYinput);
            this.groupBox1.Controls.Add(this.imageXinput);
            this.groupBox1.Controls.Add(this.bboxNumInput);
            this.groupBox1.Controls.Add(this.coordNorthingTxtBox);
            this.groupBox1.Controls.Add(this.coordEastingTxtBox);
            this.groupBox1.Controls.Add(this.addressTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "W";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // addressTxtBox
            // 
            this.addressTxtBox.Location = new System.Drawing.Point(127, 27);
            this.addressTxtBox.Name = "addressTxtBox";
            this.addressTxtBox.Size = new System.Drawing.Size(314, 20);
            this.addressTxtBox.TabIndex = 1;
            this.addressTxtBox.Leave += new System.EventHandler(this.addressTxtBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Coordinates:";
            // 
            // coordEastingTxtBox
            // 
            this.coordEastingTxtBox.Location = new System.Drawing.Point(127, 62);
            this.coordEastingTxtBox.Name = "coordEastingTxtBox";
            this.coordEastingTxtBox.Size = new System.Drawing.Size(158, 20);
            this.coordEastingTxtBox.TabIndex = 1;
            // 
            // coordNorthingTxtBox
            // 
            this.coordNorthingTxtBox.Location = new System.Drawing.Point(291, 62);
            this.coordNorthingTxtBox.Name = "coordNorthingTxtBox";
            this.coordNorthingTxtBox.Size = new System.Drawing.Size(150, 20);
            this.coordNorthingTxtBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Aerials";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Layer:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 82);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Parcel:";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(15, 126);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(70, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Services:";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(96, 135);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(15, 103);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "Contour:";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bounding Box Size(m):";
            // 
            // bboxNumInput
            // 
            this.bboxNumInput.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.bboxNumInput.Location = new System.Drawing.Point(127, 103);
            this.bboxNumInput.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.bboxNumInput.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.bboxNumInput.Name = "bboxNumInput";
            this.bboxNumInput.Size = new System.Drawing.Size(158, 20);
            this.bboxNumInput.TabIndex = 2;
            this.bboxNumInput.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(140, 462);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(233, 23);
            this.getDataButton.TabIndex = 2;
            this.getDataButton.Text = "Get Data";
            this.getDataButton.UseVisualStyleBackColor = true;
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Image Size(pixels):";
            // 
            // imageXinput
            // 
            this.imageXinput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.imageXinput.Location = new System.Drawing.Point(127, 142);
            this.imageXinput.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.imageXinput.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.imageXinput.Name = "imageXinput";
            this.imageXinput.Size = new System.Drawing.Size(75, 20);
            this.imageXinput.TabIndex = 2;
            this.imageXinput.Value = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            // 
            // imageYinput
            // 
            this.imageYinput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.imageYinput.Location = new System.Drawing.Point(210, 142);
            this.imageYinput.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.imageYinput.Minimum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.imageYinput.Name = "imageYinput";
            this.imageYinput.Size = new System.Drawing.Size(75, 20);
            this.imageYinput.TabIndex = 2;
            this.imageYinput.Value = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            // 
            // AcDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 575);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AcDataForm";
            this.Text = "AcDataForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bboxNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageXinput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageYinput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox coordNorthingTxtBox;
        private System.Windows.Forms.TextBox coordEastingTxtBox;
        private System.Windows.Forms.TextBox addressTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown bboxNumInput;
        private System.Windows.Forms.Button getDataButton;
        private System.Windows.Forms.NumericUpDown imageYinput;
        private System.Windows.Forms.NumericUpDown imageXinput;
        private System.Windows.Forms.Label label5;
    }
}