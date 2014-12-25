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

        #region DesiredPW
        private DataTable DesiredPW;
        // DesiredPW uses B1001 axies
        private const String axis_DesiredPW_col_units = axis_B1001_col_units;
        private const String axis_DesiredPW_row_units = axis_B1001_row_units;
        private static String[] axis_DesiredPW_col = axis_B1001_col;
        private static String[] axis_DesiredPW_row = axis_B1001_row;
        #endregion DesiredPW

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
            B0720 = GenerateTable(axis_B0720_col, axis_B0720_row);
            B1001 = GenerateTable(axis_B1001_col, axis_B1001_row);
            DesiredPW = GenerateTable(axis_DesiredPW_col, axis_DesiredPW_row);
        }

        /// <summary>
        /// Generate a DataTable filled with the specified value (default is 0).
        /// </summary>
        /// <param name="ColLabels">The labels to use for the column axies</param>
        /// <param name="RowLabels">The labels for the rows (just used to generate the correct number of rows)</param>
        /// <param name="Value">The value to put in every cell</param>
        /// <returns>The new DataTable</returns>
        private DataTable GenerateTable(String[] ColLabels, String[] RowLabels, String Value = "0")
        {
            DataTable zero = new DataTable();
            List<object> zeroRow = new List<object>();
            foreach (String col in ColLabels)
            {
                zero.Columns.Add(col, typeof(Double));
                zeroRow.Add(converter.ConvertFrom(Value));
            }
            foreach (String row in RowLabels)
            {
                zero.Rows.Add(zeroRow.ToArray());
            }
            return zero;
        }

        private void buttonPasteB0720_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                // Tab separated array?
                String rawText = Clipboard.GetText();
                String[] rows = rawText.Split('\n');
                if (rows.Length == B0720.Rows.Count)
                {
                    // Process rows
                    for (int row = 0; row < rows.Length; row++)
                    {
                        // Split columns
                        String[] cols = rows[row].Split('\t');
                        if (cols.Length == B0720.Columns.Count)
                        {
                            // Store data
                            for (int col = 0; col < cols.Length; col++)
                            {
                                B0720.Rows[row][col] = converter.ConvertFromString(cols[col]);
                            }
                        }
                        else
                        {
                            // Wrong number of cols. Not {B0720}?
                            MessageBox.Show(
                                "Copied data doesn't have the correct number of columns. Ensure that the copied table was {B0720} from a late-LB7 OS, and copied without labels.",
                                "Unrecognized data on clipboard",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    // Wrong number of rows. Not {B0720}?
                    MessageBox.Show(
                        "Copied data doesn't have the correct number of rows. Ensure that the copied table was {B0720} from a late-LB7 OS, and copied without labels.",
                        "Unrecognized data on clipboard",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(
                    "Clipboard does not contain text data.",
                    "Unrecognized data on clipboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonEditB0720_Click(object sender, EventArgs e)
        {
            using (EditTable editor = new EditTable(B0720, axis_B0720_row, axis_B0720_col_units, axis_B0720_row_units, ref converter))
            {
                editor.ShowDialog();
            }
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
        }

        private void buttonEditDesiredPW_Click(object sender, EventArgs e)
        {
            using (EditTable editor = new EditTable(DesiredPW, axis_DesiredPW_row, axis_DesiredPW_col_units, axis_DesiredPW_row_units, ref converter))
            {
                editor.ShowDialog();
            }
        }
    }
}
