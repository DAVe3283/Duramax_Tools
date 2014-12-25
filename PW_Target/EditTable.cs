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
        /// The names of the rows to display
        /// </summary>
        private String[] rowNames = null;
        
        /// <summary>
        /// Column units
        /// </summary>
        private String colUnits;

        /// <summary>
        /// Row units
        /// </summary>
        private String rowUnits;

        /// <summary>
        /// Type converter to put things in the appropriate format
        /// </summary>
        private TypeConverter converter;

        /// <summary>
        /// Edits a DataTable.
        /// Assumes the table is ALL ONE DATA TYPE!
        /// </summary>
        /// <param name="Table">The table to edit</param>
        /// <param name="RowNames">The names of the rows</param>
        /// <param name="ColUnits">The units for the column axis labels</param>
        /// <param name="RowUnits">The units for the row axis labels</param>
        /// <param name="Converter">A TypeConverter to convert things to the appropriate type</param>
        public EditTable(DataTable Table, String[] RowNames, String ColUnits, String RowUnits, ref TypeConverter Converter)
        {
            InitializeComponent();
            data = Table;
            rowNames = RowNames;
            colUnits = ColUnits;
            rowUnits = RowUnits;
            dataGridView.DataSource = data;
            object firstCell = data.Rows[0][0];
            converter = Converter;
        }

        private void EditTable_Load(object sender, EventArgs e)
        {
            // Add row labels
            if ((rowNames != null) && (rowNames.Length >= dataGridView.Rows.Count))
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].HeaderCell.Value = rowNames[i];
                }
                dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }

            // Auto-size columns & disable sorting
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Column units
            labelColUnits.Text = colUnits;

            // Row Units
            labelRowUnits.Text = ""; // Clear normal text, or it will also be drawn
            labelRowUnits.NewText = rowUnits;
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
            UseWaitCursor = true;
            Enabled = false;
            object value = converter.ConvertFromString(textBoxSetTo.Text);
            foreach (DataRow row in data.Rows)
            {
                foreach (DataColumn col in data.Columns)
                {
                    row[col] = value;
                }
            }
            Enabled = true;
            UseWaitCursor = false;
        }

        private void buttonSetSelection_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Enabled = false;
            object value = converter.ConvertFromString(textBoxSetTo.Text);
            DataGridViewSelectedCellCollection selected = dataGridView.SelectedCells;
            for (int i = 0; i < selected.Count; i++)
            {
                selected[i].Value = value;
            }
            Enabled = true;
            UseWaitCursor = false;
        }

        private void labelRowUnits_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;

            float vlblControlWidth;
            float vlblControlHeight;
            float vlblTransformX;
            float vlblTransformY;

            Color controlBackColor = lbl.BackColor;
            Pen labelBorderPen = new Pen(controlBackColor);
            SolidBrush labelBackColorBrush = new SolidBrush(controlBackColor);

            SolidBrush labelForeColorBrush = new SolidBrush(lbl.ForeColor);
            base.OnPaint(e);
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0,
                                     vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0,
                                     vlblControlWidth, vlblControlHeight);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault; // this._renderMode;
            e.Graphics.SmoothingMode =
                       System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            vlblTransformX = 0;
            vlblTransformY = vlblControlHeight;
            e.Graphics.TranslateTransform(vlblTransformX, vlblTransformY);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString(lbl.Text, Font, labelForeColorBrush, 0, 0);
        }
    }

    // From http://stackoverflow.com/a/5261648
    // Modified to work at -90 deg rotation ONLY
    public class myLabel : System.Windows.Forms.Label
    {
        public int RotateAngle { get; set; }  // to rotate your text
        public string NewText { get; set; }   // to draw text
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            SizeF size = e.Graphics.MeasureString(this.NewText, this.Font);
            Brush b = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            e.Graphics.TranslateTransform((this.Width - size.Height) / 2, (this.Height - size.Width) / 2);
            e.Graphics.RotateTransform(this.RotateAngle);
            e.Graphics.DrawString(this.NewText, this.Font, b, 0, 0, sf);
            base.OnPaint(e);
        }
    }
}
