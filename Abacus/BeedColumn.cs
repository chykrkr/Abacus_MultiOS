using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Abacus
{
    public partial class BeedColumn : UserControl
    {
        private PictureBox[] beedButtonArray;
        public event EventHandler ColValueChanged;
        public event EventHandler DecimalPlaceRequest;

        private bool decimalPlace = false;
        private bool whitePlace = false;


        public bool DecimalPlace {
            set {
                decimalPlace = value;
                dotIndicator.Visible = decimalPlace || whitePlace;
                dotIndicator.CircleColor = (decimalPlace) ? Color.Red : (whitePlace)? Color.White : Color.Transparent;
            }
            get { return decimalPlace;  }

        }

        public bool WhitePlace
        {
            set
            {
                whitePlace = value;
                dotIndicator.Visible = whitePlace;
                dotIndicator.CircleColor = (decimalPlace) ? Color.Red : (whitePlace) ? Color.White : Color.Transparent;
            }
            get { return whitePlace; }
        }

        public BeedColumn()
        {
            InitializeComponent();

            beedButtonArray = new PictureBox[5] { beed0, beed1, beed2, beed3, beed4};

            for (int i = 0; i < beedButtonArray.Length; i++)
            {
                beedButtonArray[i].Click += new EventHandler(LowBeed_Click);
            }

            //beed5off.Parent = vertBar;
            dotIndicator.Parent = horzBar;
        }

        private void setAllVisible()
        {
            for (int i = 0; i < beedButtonArray.Length; i++)
            {
                beedButtonArray[i].Visible = true;
            }
        }

        private void Beed5off_Click(object sender, EventArgs e)
        {
            if (!beed5off.Visible)
                return;

            beed5off.Visible = false;
            beed5on.Visible = true;

            if (this.ColValueChanged != null)
                this.ColValueChanged(this, e);
        }

        private void Beed5on_Click(object sender, EventArgs e)
        {
            if (!beed5on.Visible)
                return;

            beed5off.Visible = true;
            beed5on.Visible = false;

            if (this.ColValueChanged != null)
                this.ColValueChanged(this, e);
        }

        private void LowBeed_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Visible == false)
                return;

            setAllVisible();
            ((PictureBox)sender).Visible = false;

            if (this.ColValueChanged != null)
                this.ColValueChanged(this, e);
        }

        private void HorzBar_Click(object sender, EventArgs e)
        {
            if (this.DecimalPlaceRequest != null)
                this.DecimalPlaceRequest(this, e);
        }

        private void DotIndicator_Click(object sender, EventArgs e)
        {
            if (this.DecimalPlaceRequest != null)
                this.DecimalPlaceRequest(this, e);
        }

        private void BeedColumn_Resize(object sender, EventArgs e)
        {
            if (beedButtonArray == null)
                return;

            rearrangeBeed();
        }

        private void rearrangeBeed()
        {
            /*
             * 5px (1)
             * beed_off
             * 3px (1)
             * beed_on
             * 3px (2)
             * 20px picturebox
             * 3px (3)
             * beed_0
             * 3px (4)
             * beed_1
             * 3px (5)
             * beed_2
             * 3px (6)
             * beed_3
             * 3px (7)
             * beed_4
             * 5px (2)
             */
            int beed_height, beed_width;
            int mleft = 2, mright = 2;
            int mtop = 1, mbottom = 1;
            int beed_space = 1;
            int horz_height = 10;

            beed_height = (this.Height - (5 * 2 + 3 * 7 + 20)) / 7;
            beed_width = this.Width - (mleft + mright);

            beed5off.Width = beed_width;
            beed5off.Height = beed_height;
            beed5off.Location = new Point(mleft, mtop);
            //beed5off.Location = vertBar.PointToClient(this.PointToScreen(beed5off.Location));

            beed5on.Width = beed_width;
            beed5on.Height = beed_height;
            beed5on.Location = new Point(mleft, beed5off.Location.Y + beed_height + beed_space) ;

            horzBar.Width = this.Width;
            horzBar.Height = horz_height;
            horzBar.Location = new Point(0, beed5on.Location.Y + beed_height + beed_space);

            dotIndicator.Width = horzBar.Height;
            dotIndicator.Height = horzBar.Height;
            dotIndicator.Location = new Point((horzBar.Width - dotIndicator.Width) / 2, 0);

            beed0.Width = beed_width;
            beed0.Height = beed_height;
            beed0.Location = new Point(mleft, horzBar.Location.Y + horz_height + beed_space);

            beed1.Width = beed_width;
            beed1.Height = beed_height;
            beed1.Location = new Point(mleft, beed0.Location.Y + beed_height + beed_space);

            beed2.Width = beed_width;
            beed2.Height = beed_height;
            beed2.Location = new Point(mleft, beed1.Location.Y + beed_height + beed_space);

            beed3.Width = beed_width;
            beed3.Height = beed_height;
            beed3.Location = new Point(mleft, beed2.Location.Y + beed_height + beed_space);

            beed4.Width = beed_width;
            beed4.Height = beed_height;
            beed4.Location = new Point(mleft, beed3.Location.Y + beed_height + beed_space);

            /*
            vertBar.Width = 6;
            vertBar.Height = this.Height;
            vertBar.Location = new Point((this.Width - vertBar.Width) / 2, 0);
            */

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.BurlyWood), (this.Width - 6) / 2, 0, 6, this.Height);
        }

        public int getValue()
        {
            int value, i;

            value = beed5on.Visible ? 5 : 0;

            for (i = 0; i < beedButtonArray.Length; i++)
            {
                if (beedButtonArray[i].Visible == false)
                    break;
            }

            value += i;

            return value;
        }

        public void setValue(int value)
        {
            int num5;
            int numLess5;

            if (value > 9)
                throw new ArgumentOutOfRangeException();

            num5 = value / 5;
            numLess5 = value % 5;

            beed5on.Visible = (num5 > 0) ? true : false;
            beed5off.Visible = !beed5on.Visible;

            for (int i = 0; i < beedButtonArray.Length; i++)
            {
                beedButtonArray[i].Visible = true;
            }

            beedButtonArray[numLess5].Visible = false;
        }
    }
}
