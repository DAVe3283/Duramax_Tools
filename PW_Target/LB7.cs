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

        public LB7()
        {
            InitializeComponent();
            B0720 = GenerateTable(axis_B0720_col, axis_B0720_row);
            B1001 = GenerateTable(axis_B1001_col, axis_B1001_row);
            DesiredPW = GenerateTable(axis_DesiredPW_col, axis_DesiredPW_row);
        }

        private void CalculateB1001()
        {
            // Row (mm³)
            for (int row = 0; row < B1001.Rows.Count; row++)
            {
                Double mm3 = Convert.ToDouble(axis_B1001_row[row]);

                // Find mm³ interpolation points on B0720
                int m0 = FindIndex(mm3, axis_B0720_row);
                int m1 = (m0 == axis_B0720_row.Length - 1) ? m0 : m0 + 1;

                // Build B0720 pulsewidth array for the given mm³
                List<Double> pwInterpolated = new List<Double>();
                for (int col = 0; col < B0720.Columns.Count; col++)
                {
                    // Verify we aren't at the end of the table
                    if (m0 == m1)
                    {
                        pwInterpolated.Add((Double)B0720.Rows[m0][col]);
                    }
                    else
                    {
                        Double vol0 = Convert.ToDouble(axis_B0720_row[m0]);
                        Double vol1 = Convert.ToDouble(axis_B0720_row[m1]);
                        Double pw0 = (Double)B0720.Rows[m0][col];
                        Double pw1 = (Double)B0720.Rows[m1][col];
                        Double pw = Interpolate(mm3, vol0, vol1, pw0, pw1);
                        pwInterpolated.Add(pw);
                    }
                }

                // B1001 Column (RPM)
                for (int col = 0; col < B1001.Columns.Count; col++)
                {
                    Double rpm = Convert.ToDouble(axis_B1001_col[col]);
                    Double desiredPW = (Double)DesiredPW.Rows[row][col];

                    // Find ideal fuel pressure (back-interpolate off B0720)
                    int p0 = FindPWIndex(desiredPW, pwInterpolated);
                    int p1 = (p0 == axis_B0720_col.Length - 1) ? p0 : p0 + 1;
                    Double frp;
                    if (p0 == p1)
                    {
                        frp = Convert.ToDouble(axis_B0720_col[p0]);
                    }
                    else
                    {
                        Double pw0 = pwInterpolated[p0];
                        Double pw1 = pwInterpolated[p1];
                        Double frp0 = Convert.ToDouble(axis_B0720_col[p0]);
                        Double frp1 = Convert.ToDouble(axis_B0720_col[p1]);
                        frp = Interpolate(desiredPW, pw0, pw1, frp0, frp1);
                    }

                    // Limit pressure to user selected range
                    if (frp < (Double)numericUpDownMinFRP.Value)
                    {
                        frp = (Double)numericUpDownMinFRP.Value;
                    }
                    else if (frp > (Double)numericUpDownMaxFRP.Value)
                    {
                        frp = (Double)numericUpDownMaxFRP.Value;
                    }

                    // Store ideal pressure
                    B1001.Rows[row][col] = frp;
                }
            }
        }

        /// <summary>
        /// Find the index lower or equal to a value in an array
        /// </summary>
        /// <param name="desired">The target value</param>
        /// <param name="values">The array of values</param>
        /// <returns>Index into the array</returns>
        private int FindIndex(Double desired, String[] values)
        {
            int i = values.Length - 1;
            for (; i >= 0; i--)
            {
                Double val = Convert.ToDouble(values[i]);
                if (val <= desired)
                {
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// Find the pulsewidth index from the pulsewidth row
        /// </summary>
        /// <param name="desired">The target value</param>
        /// <param name="values">The array of values</param>
        /// <returns>Index into the array</returns>
        private int FindPWIndex(Double desired, List<Double> values)
        {
            // Skip the first column if its value is 0
            int firstIndex = 0;
            if (values[firstIndex] == 0)
            {
                firstIndex = 1;
            }

            // Find the best index
            int i = firstIndex;
            for (; i < values.Count - 1; i++)
            {
                if (values[i] <= desired)
                {
                    if (i > firstIndex)
                    {
                        i--;
                    }
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// Linear interpolation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="x0">Known X point 0</param>
        /// <param name="x1">Known X point 1</param>
        /// <param name="y0">Y value at X0</param>
        /// <param name="y1">Y value at X1</param>
        /// <returns>Y value at X</returns>
        private Double Interpolate(Double x, Double x0, Double x1, Double y0, Double y1)
        {
            return y0 + (y1 - y0) * (x - x0) / (x1 - x0);
        }

        /// <summary>
        /// Generate a DataTable filled with the specified value (default is 0).
        /// </summary>
        /// <param name="ColLabels">The labels to use for the column axies</param>
        /// <param name="RowLabels">The labels for the rows (just used to generate the correct number of rows)</param>
        /// <param name="Value">The value to put in every cell</param>
        /// <returns>The new DataTable</returns>
        private DataTable GenerateTable(String[] ColLabels, String[] RowLabels, Double Value = 0)
        {
            DataTable zero = new DataTable();
            List<object> zeroRow = new List<object>();
            foreach (String col in ColLabels)
            {
                zero.Columns.Add(col, typeof(Double));
                zeroRow.Add(Value);
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
                                B0720.Rows[row][col] = Convert.ToDouble(cols[col]);
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
            using (EditTable editor = new EditTable(B0720, axis_B0720_row, axis_B0720_col_units, axis_B0720_row_units))
            {
                editor.ShowDialog();
            }
        }

        private void buttonGenerateB1001_Click(object sender, EventArgs e)
        {
            CalculateB1001();
            buttonCopyB1001.Enabled = true;
            buttonEditB1001.Enabled = true;
        }

        private void buttonEditB1001_Click(object sender, EventArgs e)
        {
            using (EditTable editor = new EditTable(B1001, axis_B1001_row, axis_B1001_col_units, axis_B1001_row_units))
            {
                editor.ShowDialog();
            }
        }

        private void buttonCopyB1001_Click(object sender, EventArgs e)
        {
            // Build EFILive-style string
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < B1001.Rows.Count; row++)
            {
                for (int col = 0; col < B1001.Columns.Count; col++)
                {
                    // Store cell value
                    sb.Append(String.Format("{0}", B1001.Rows[row][col]));

                    // Append tab (except for last column)
                    if (col < B1001.Columns.Count - 1)
                    {
                        sb.Append('\t');
                    }
                }

                // Append new line (except for last row)
                if (row < B1001.Rows.Count - 1)
                {
                    sb.Append('\n');
                }
            }

            // Copy string to clipboard
            Clipboard.Clear();
            Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
        }

        private void buttonEditDesiredPW_Click(object sender, EventArgs e)
        {
            using (EditTable editor = new EditTable(DesiredPW, axis_DesiredPW_row, axis_DesiredPW_col_units, axis_DesiredPW_row_units))
            {
                editor.ShowDialog();
            }
        }
    }
}
