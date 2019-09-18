using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Abacus
{
    public partial class BeedColumns : UserControl
    {
        [Description("Test text displayed in the textbox"), Category("All")]
        public int columns
        {
            get { return cols; }
            set { cols = value; resizeColumn(); }
        }

        private int cols = 10;
        private int wdotPos = 1, wdotInt = 3;

        private object decimal_place = null;

        private BeedColumn[] beedColumnArray;

        public EventHandler ValueChanged;

        public BeedColumns()
        {
            BeedColumn column;
            int col_width = this.Width / cols;
            int col_height = this.Height;

            beedColumnArray = new BeedColumn[cols];

            for (int i = 0; i < cols; i++ )
            {
                column = new BeedColumn();
                column.Width = col_width;
                column.Height = col_height;
                column.Margin = new Padding(0);
                column.Padding = new Padding(0);
                column.Location = new Point(i * col_width, 0);

                Console.WriteLine(column.Location.ToString() + "," + i);

                beedColumnArray[i] = column;

                column.ColValueChanged += new EventHandler(ColValueChanged);
                column.DecimalPlaceRequest += new EventHandler(DecimalPlaceChanged);

                this.Controls.Add(column);
            }

            putWhiteDots(wdotPos, wdotInt);

            InitializeComponent();
        }

        protected void putWhiteDots(int startIdx, int interval)
        {
            BeedColumn column;
            int j;

            for (int i = 0; i < beedColumnArray.Length; i++)
            {
                j = beedColumnArray.Length - 1 - i;

                column = beedColumnArray[j];
                if ((i - startIdx) % interval == 0)
                {
                    column.WhitePlace = true;
                } else
                {
                    column.WhitePlace = false;
                }
            }
        }

        protected void ColValueChanged(object sender, EventArgs e)
        {
            if (this.ValueChanged != null)
                this.ValueChanged(this, e);
        }

        protected void DecimalPlaceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < beedColumnArray.Length; i++)
            {
                if (sender.Equals(beedColumnArray[i]))
                {
                    decimal_place = i;
                } else
                {
                    beedColumnArray[i].DecimalPlace = false;
                }
            }

            ((BeedColumn)sender).DecimalPlace = true;

            if (this.ValueChanged != null)
                this.ValueChanged(this, e);
        }

        private void resizeColumn()
        {
            BeedColumn[] col_old, col_new;
            BeedColumn column;
            int col_width = this.Width / cols;
            int col_height = this.Height;
            int i;

            col_new = new BeedColumn[cols];
            col_old = beedColumnArray;

            this.Controls.Clear();

            for (i = 0; i < col_new.Length && i < col_old.Length ; i++)
            {
                col_new[i] = col_old[i];
                this.Controls.Add(col_new[i]);
            }

            for (int j = i; j < col_new.Length; j++)
            {
                if (col_new[j] != null)
                    continue;

                column = new BeedColumn();
                column.Width = col_width;
                column.Height = col_height;
                column.Margin = new Padding(0);
                column.Padding = new Padding(0);
                column.Location = new Point(i * col_width, 0);

                column.ColValueChanged += new EventHandler(ColValueChanged);
                column.DecimalPlaceRequest += new EventHandler(DecimalPlaceChanged);

                col_new[j] = column;

                this.Controls.Add(column);
            }

            beedColumnArray = col_new;

            putWhiteDots(wdotPos, wdotInt);
        }

        private void BeedColumns_Resize(object sender, EventArgs e)
        {
            BeedColumn column;
            int col_width = this.Width / cols;
            int col_height = this.Height;

            for (int i = 0; i < cols; i++)
            {
                column = beedColumnArray[i];
                column.Width = col_width;
                column.Height = col_height;
                column.Location = new Point(i * col_width, 0);
            }
        }

        public string getValue()
        {
            string result = "";

            for (int i = 0; i < beedColumnArray.Length; i++)
            {
                result += beedColumnArray[i].getValue().ToString();

                if (decimal_place == null || (int) decimal_place != i)
                    continue;

                result += ".";
            }

            return result;
        }

        public void reset()
        {
            for (int i = 0; i < beedColumnArray.Length; i++)
            {
                beedColumnArray[i].setValue(0);
            }
        }
    }
}
