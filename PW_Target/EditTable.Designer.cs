namespace PW_Target
{
    partial class EditTable
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxSetTo = new System.Windows.Forms.GroupBox();
            this.buttonSetSelection = new System.Windows.Forms.Button();
            this.buttonSetAll = new System.Windows.Forms.Button();
            this.textBoxSetTo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxSetTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 93);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(760, 457);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBoxSetTo
            // 
            this.groupBoxSetTo.Controls.Add(this.buttonSetSelection);
            this.groupBoxSetTo.Controls.Add(this.buttonSetAll);
            this.groupBoxSetTo.Controls.Add(this.textBoxSetTo);
            this.groupBoxSetTo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSetTo.Name = "groupBoxSetTo";
            this.groupBoxSetTo.Size = new System.Drawing.Size(113, 75);
            this.groupBoxSetTo.TabIndex = 1;
            this.groupBoxSetTo.TabStop = false;
            this.groupBoxSetTo.Text = "Set To";
            // 
            // buttonSetSelection
            // 
            this.buttonSetSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetSelection.AutoSize = true;
            this.buttonSetSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetSelection.Location = new System.Drawing.Point(46, 46);
            this.buttonSetSelection.Name = "buttonSetSelection";
            this.buttonSetSelection.Size = new System.Drawing.Size(61, 23);
            this.buttonSetSelection.TabIndex = 2;
            this.buttonSetSelection.Text = "Selection";
            this.buttonSetSelection.UseVisualStyleBackColor = true;
            this.buttonSetSelection.Click += new System.EventHandler(this.buttonSetSelection_Click);
            // 
            // buttonSetAll
            // 
            this.buttonSetAll.AutoSize = true;
            this.buttonSetAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetAll.Location = new System.Drawing.Point(7, 46);
            this.buttonSetAll.Name = "buttonSetAll";
            this.buttonSetAll.Size = new System.Drawing.Size(28, 23);
            this.buttonSetAll.TabIndex = 1;
            this.buttonSetAll.Text = "All";
            this.buttonSetAll.UseVisualStyleBackColor = true;
            this.buttonSetAll.Click += new System.EventHandler(this.buttonSetAll_Click);
            // 
            // textBoxSetTo
            // 
            this.textBoxSetTo.Location = new System.Drawing.Point(7, 20);
            this.textBoxSetTo.Name = "textBoxSetTo";
            this.textBoxSetTo.Size = new System.Drawing.Size(100, 20);
            this.textBoxSetTo.TabIndex = 0;
            this.textBoxSetTo.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSetTo_Validating);
            // 
            // EditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBoxSetTo);
            this.Controls.Add(this.dataGridView);
            this.MinimumSize = new System.Drawing.Size(153, 200);
            this.Name = "EditTable";
            this.Text = "Edit Table";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxSetTo.ResumeLayout(false);
            this.groupBoxSetTo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBoxSetTo;
        private System.Windows.Forms.TextBox textBoxSetTo;
        private System.Windows.Forms.Button buttonSetSelection;
        private System.Windows.Forms.Button buttonSetAll;
    }
}