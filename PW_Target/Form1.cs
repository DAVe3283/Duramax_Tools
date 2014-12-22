﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PW_Target
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable newTable = new DataTable();
            newTable.Columns.Add("10 RPM", typeof(Double));
            newTable.Columns.Add("100 RPM", typeof(Double));
            newTable.Columns.Add("1000 RPM", typeof(Double));
            newTable.Columns.Add("10000 RPM", typeof(Double));
            newTable.Rows.Add(1, 10, 100, 1000);
            newTable.Rows.Add(2, 20, 200, 2000);
            
            EditTable editor = new EditTable(newTable);
            editor.ShowDialog();
            editor.Dispose();
            editor = null;

            MessageBox.Show("First cell = " + newTable.Rows[0][0].ToString());
        }
    }
}
