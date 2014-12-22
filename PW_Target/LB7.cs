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
    public partial class LB7 : Form
    {
        #region Tables

        #region B0720
        private DataTable B0720;
        private const String axis_B0720_col_units = "MPa";
        private const String axis_B0720_row_units = "mm³";
        private static String[] axis_B0720_col = { "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "110", "120", "130", "140", "150", "160", "170", "180", "190" };
        private static String[] axis_B0720_row = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };
        #endregion B0720

        #region B1001
        private DataTable B1001;
        private const String axis_B1001_col_units = "RPM";
        private const String axis_B1001_row_units = "mm³";
        private static String[] axis_B1001_col = { "0", "200", "400", "600", "800", "1000", "1200", "1400", "1600", "1800", "2000", "2200", "2400", "2600", "2800", "3000", "3100", "3250", "3400", "3600", "3800", "4000", "4200", "4400", "4600", "4800" };
        private static String[] axis_B1001_row = { "0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60", "65", "70", "75", "80", "85", "90", "95", "100", "105", "110" };
        #endregion B1001

        #endregion Tables

        /// <summary>
        /// Type of the value to use in the table cells
        /// </summary>
        private Type cellType = typeof(Double);

        /// <summary>
        /// A converter to convert data to the cellType
        /// </summary>
        private TypeConverter converter;

        public LB7()
        {
            InitializeComponent();
            converter = TypeDescriptor.GetConverter(cellType);
            B0720 = GenerateZeroTable(axis_B0720_col, axis_B0720_row);
            B1001 = GenerateZeroTable(axis_B1001_col, axis_B1001_row);
        }

        /// <summary>
        /// Generate a DataTable filled with 0's.
        /// </summary>
        /// <param name="ColLabels">The labels to use for the column axies</param>
        /// <param name="RowLabels">The labels for the rows (just used to generate the correct number of rows)</param>
        /// <returns>The new DataTable</returns>
        private DataTable GenerateZeroTable(String[] ColLabels, String[] RowLabels)
        {
            DataTable zero = new DataTable();
            List<object> zeroRow = new List<object>();
            foreach (String col in ColLabels)
            {
                zero.Columns.Add(col, typeof(Double));
                zeroRow.Add(converter.ConvertFrom("0"));
            }
            foreach (String row in RowLabels)
            {
                zero.Rows.Add(zeroRow.ToArray());
            }
            return zero;
        }

        private void buttonGenerateB1001_Click(object sender, EventArgs e)
        {
            // TODO: generate the resulting table
            buttonCopyB1001.Enabled = true;
            buttonEditB1001.Enabled = true;
        }

        private void buttonEditB1001_Click(object sender, EventArgs e)
        {
            using (EditTable editor = new EditTable(B1001, axis_B1001_row, axis_B1001_col_units, axis_B1001_row_units, ref converter))
            {
                editor.ShowDialog();
            }
            MessageBox.Show("First cell = " + B1001.Rows[0][0].ToString());
        }
    }
}
