using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PW_Target
{
    public partial class EditTable : Form
    {
        /// <summary>
        /// The data we are editing
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Type converter to put things in the appropriate format
        /// </summary>
        private TypeConverter converter;

        /// <summary>
        /// Edits a DataTable.
        /// Assumes the table is ALL ONE DATA TYPE!
        /// </summary>
        /// <param name="Table">The table to edit</param>
        public EditTable(DataTable Table)
        {
            InitializeComponent();
            data = Table;
            dataGridView.DataSource = data;
            object firstCell = data.Rows[0][0];
            converter = TypeDescriptor.GetConverter(firstCell);
        }

        private void textBoxSetTo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                converter.ConvertFromString(textBoxSetTo.Text);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Can't convert '" + textBoxSetTo.Text + "' to the correct type:\n" + ex.Message,
                    "Parse error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonSetAll_Click(object sender, EventArgs e)
        {
            object value = converter.ConvertFromString(textBoxSetTo.Text);
            foreach (DataRow row in data.Rows)
            {
                foreach (DataColumn col in data.Columns)
                {
                    row[col] = value;
                }
            }
        }

        private void buttonSetSelection_Click(object sender, EventArgs e)
        {
            object value = converter.ConvertFromString(textBoxSetTo.Text);
            DataGridViewSelectedCellCollection selected = dataGridView.SelectedCells;
            for (int i = 0; i < selected.Count; i++)
            {
                selected[i].Value = value;
            }
        }
    }
}
