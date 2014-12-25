namespace PW_Target
{
    partial class LB7
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
            this.groupBoxGenerateB1001 = new System.Windows.Forms.GroupBox();
            this.buttonEditB1001 = new System.Windows.Forms.Button();
            this.buttonCopyB1001 = new System.Windows.Forms.Button();
            this.buttonGenerateB1001 = new System.Windows.Forms.Button();
            this.labelMaxFRPUnits = new System.Windows.Forms.Label();
            this.numericUpDownMaxFRP = new System.Windows.Forms.NumericUpDown();
            this.labelMaxFRP = new System.Windows.Forms.Label();
            this.labelMinFRPUnits = new System.Windows.Forms.Label();
            this.labelMinFRP = new System.Windows.Forms.Label();
            this.numericUpDownMinFRP = new System.Windows.Forms.NumericUpDown();
            this.groupBoxB0720 = new System.Windows.Forms.GroupBox();
            this.buttonEditB0720 = new System.Windows.Forms.Button();
            this.buttonPasteB0720 = new System.Windows.Forms.Button();
            this.groupBoxDesiredPW = new System.Windows.Forms.GroupBox();
            this.buttonEditDesiredPW = new System.Windows.Forms.Button();
            this.groupBoxGenerateB1001.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFRP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinFRP)).BeginInit();
            this.groupBoxB0720.SuspendLayout();
            this.groupBoxDesiredPW.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGenerateB1001
            // 
            this.groupBoxGenerateB1001.Controls.Add(this.buttonEditB1001);
            this.groupBoxGenerateB1001.Controls.Add(this.buttonCopyB1001);
            this.groupBoxGenerateB1001.Controls.Add(this.buttonGenerateB1001);
            this.groupBoxGenerateB1001.Controls.Add(this.labelMaxFRPUnits);
            this.groupBoxGenerateB1001.Controls.Add(this.numericUpDownMaxFRP);
            this.groupBoxGenerateB1001.Controls.Add(this.labelMaxFRP);
            this.groupBoxGenerateB1001.Controls.Add(this.labelMinFRPUnits);
            this.groupBoxGenerateB1001.Controls.Add(this.labelMinFRP);
            this.groupBoxGenerateB1001.Controls.Add(this.numericUpDownMinFRP);
            this.groupBoxGenerateB1001.Location = new System.Drawing.Point(12, 243);
            this.groupBoxGenerateB1001.Name = "groupBoxGenerateB1001";
            this.groupBoxGenerateB1001.Size = new System.Drawing.Size(290, 130);
            this.groupBoxGenerateB1001.TabIndex = 1;
            this.groupBoxGenerateB1001.TabStop = false;
            this.groupBoxGenerateB1001.Text = "Generate {B1001} Fuel Pressure Base";
            // 
            // buttonEditB1001
            // 
            this.buttonEditB1001.Enabled = false;
            this.buttonEditB1001.Location = new System.Drawing.Point(87, 71);
            this.buttonEditB1001.Name = "buttonEditB1001";
            this.buttonEditB1001.Size = new System.Drawing.Size(75, 23);
            this.buttonEditB1001.TabIndex = 8;
            this.buttonEditB1001.Text = "View/Edit";
            this.buttonEditB1001.UseVisualStyleBackColor = true;
            this.buttonEditB1001.Click += new System.EventHandler(this.buttonEditB1001_Click);
            // 
            // buttonCopyB1001
            // 
            this.buttonCopyB1001.Enabled = false;
            this.buttonCopyB1001.Location = new System.Drawing.Point(6, 71);
            this.buttonCopyB1001.Name = "buttonCopyB1001";
            this.buttonCopyB1001.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyB1001.TabIndex = 7;
            this.buttonCopyB1001.Text = "Copy";
            this.buttonCopyB1001.UseVisualStyleBackColor = true;
            this.buttonCopyB1001.Click += new System.EventHandler(this.buttonCopyB1001_Click);
            // 
            // buttonGenerateB1001
            // 
            this.buttonGenerateB1001.Location = new System.Drawing.Point(6, 19);
            this.buttonGenerateB1001.Name = "buttonGenerateB1001";
            this.buttonGenerateB1001.Size = new System.Drawing.Size(75, 46);
            this.buttonGenerateB1001.TabIndex = 6;
            this.buttonGenerateB1001.Text = "Generate";
            this.buttonGenerateB1001.UseVisualStyleBackColor = true;
            this.buttonGenerateB1001.Click += new System.EventHandler(this.buttonGenerateB1001_Click);
            // 
            // labelMaxFRPUnits
            // 
            this.labelMaxFRPUnits.AutoSize = true;
            this.labelMaxFRPUnits.Location = new System.Drawing.Point(200, 47);
            this.labelMaxFRPUnits.Name = "labelMaxFRPUnits";
            this.labelMaxFRPUnits.Size = new System.Drawing.Size(29, 13);
            this.labelMaxFRPUnits.TabIndex = 5;
            this.labelMaxFRPUnits.Text = "MPa";
            // 
            // numericUpDownMaxFRP
            // 
            this.numericUpDownMaxFRP.Location = new System.Drawing.Point(144, 45);
            this.numericUpDownMaxFRP.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownMaxFRP.Name = "numericUpDownMaxFRP";
            this.numericUpDownMaxFRP.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownMaxFRP.TabIndex = 4;
            this.numericUpDownMaxFRP.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // labelMaxFRP
            // 
            this.labelMaxFRP.AutoSize = true;
            this.labelMaxFRP.Location = new System.Drawing.Point(87, 47);
            this.labelMaxFRP.Name = "labelMaxFRP";
            this.labelMaxFRP.Size = new System.Drawing.Size(51, 13);
            this.labelMaxFRP.TabIndex = 3;
            this.labelMaxFRP.Text = "Maximum";
            // 
            // labelMinFRPUnits
            // 
            this.labelMinFRPUnits.AutoSize = true;
            this.labelMinFRPUnits.Location = new System.Drawing.Point(200, 21);
            this.labelMinFRPUnits.Name = "labelMinFRPUnits";
            this.labelMinFRPUnits.Size = new System.Drawing.Size(29, 13);
            this.labelMinFRPUnits.TabIndex = 2;
            this.labelMinFRPUnits.Text = "MPa";
            // 
            // labelMinFRP
            // 
            this.labelMinFRP.AutoSize = true;
            this.labelMinFRP.Location = new System.Drawing.Point(87, 21);
            this.labelMinFRP.Name = "labelMinFRP";
            this.labelMinFRP.Size = new System.Drawing.Size(48, 13);
            this.labelMinFRP.TabIndex = 1;
            this.labelMinFRP.Text = "Minimum";
            // 
            // numericUpDownMinFRP
            // 
            this.numericUpDownMinFRP.Location = new System.Drawing.Point(144, 19);
            this.numericUpDownMinFRP.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownMinFRP.Name = "numericUpDownMinFRP";
            this.numericUpDownMinFRP.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownMinFRP.TabIndex = 0;
            this.numericUpDownMinFRP.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // groupBoxB0720
            // 
            this.groupBoxB0720.Controls.Add(this.buttonEditB0720);
            this.groupBoxB0720.Controls.Add(this.buttonPasteB0720);
            this.groupBoxB0720.Location = new System.Drawing.Point(12, 12);
            this.groupBoxB0720.Name = "groupBoxB0720";
            this.groupBoxB0720.Size = new System.Drawing.Size(168, 48);
            this.groupBoxB0720.TabIndex = 2;
            this.groupBoxB0720.TabStop = false;
            this.groupBoxB0720.Text = "{B0720} Main Injection Pulse";
            // 
            // buttonEditB0720
            // 
            this.buttonEditB0720.Location = new System.Drawing.Point(87, 19);
            this.buttonEditB0720.Name = "buttonEditB0720";
            this.buttonEditB0720.Size = new System.Drawing.Size(75, 23);
            this.buttonEditB0720.TabIndex = 1;
            this.buttonEditB0720.Text = "Edit";
            this.buttonEditB0720.UseVisualStyleBackColor = true;
            this.buttonEditB0720.Click += new System.EventHandler(this.buttonEditB0720_Click);
            // 
            // buttonPasteB0720
            // 
            this.buttonPasteB0720.Location = new System.Drawing.Point(6, 19);
            this.buttonPasteB0720.Name = "buttonPasteB0720";
            this.buttonPasteB0720.Size = new System.Drawing.Size(75, 23);
            this.buttonPasteB0720.TabIndex = 0;
            this.buttonPasteB0720.Text = "Paste";
            this.buttonPasteB0720.UseVisualStyleBackColor = true;
            this.buttonPasteB0720.Click += new System.EventHandler(this.buttonPasteB0720_Click);
            // 
            // groupBoxDesiredPW
            // 
            this.groupBoxDesiredPW.Controls.Add(this.buttonEditDesiredPW);
            this.groupBoxDesiredPW.Location = new System.Drawing.Point(12, 137);
            this.groupBoxDesiredPW.Name = "groupBoxDesiredPW";
            this.groupBoxDesiredPW.Size = new System.Drawing.Size(200, 100);
            this.groupBoxDesiredPW.TabIndex = 3;
            this.groupBoxDesiredPW.TabStop = false;
            this.groupBoxDesiredPW.Text = "Desired Pulsewidth";
            // 
            // buttonEditDesiredPW
            // 
            this.buttonEditDesiredPW.Location = new System.Drawing.Point(6, 19);
            this.buttonEditDesiredPW.Name = "buttonEditDesiredPW";
            this.buttonEditDesiredPW.Size = new System.Drawing.Size(75, 23);
            this.buttonEditDesiredPW.TabIndex = 0;
            this.buttonEditDesiredPW.Text = "Edit";
            this.buttonEditDesiredPW.UseVisualStyleBackColor = true;
            this.buttonEditDesiredPW.Click += new System.EventHandler(this.buttonEditDesiredPW_Click);
            // 
            // LB7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 406);
            this.Controls.Add(this.groupBoxDesiredPW);
            this.Controls.Add(this.groupBoxB0720);
            this.Controls.Add(this.groupBoxGenerateB1001);
            this.Name = "LB7";
            this.Text = "Pulsewidth Target (LB7)";
            this.groupBoxGenerateB1001.ResumeLayout(false);
            this.groupBoxGenerateB1001.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxFRP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinFRP)).EndInit();
            this.groupBoxB0720.ResumeLayout(false);
            this.groupBoxDesiredPW.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGenerateB1001;
        private System.Windows.Forms.Button buttonEditB1001;
        private System.Windows.Forms.Button buttonCopyB1001;
        private System.Windows.Forms.Button buttonGenerateB1001;
        private System.Windows.Forms.Label labelMaxFRPUnits;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxFRP;
        private System.Windows.Forms.Label labelMaxFRP;
        private System.Windows.Forms.Label labelMinFRPUnits;
        private System.Windows.Forms.Label labelMinFRP;
        private System.Windows.Forms.NumericUpDown numericUpDownMinFRP;
        private System.Windows.Forms.GroupBox groupBoxB0720;
        private System.Windows.Forms.Button buttonEditB0720;
        private System.Windows.Forms.Button buttonPasteB0720;
        private System.Windows.Forms.GroupBox groupBoxDesiredPW;
        private System.Windows.Forms.Button buttonEditDesiredPW;
    }
}

