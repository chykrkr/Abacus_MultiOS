using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Abacus
{
    public partial class ColorCircleControl : PictureBox
    {
        private Color color = Color.Transparent;

        [Description("Circle Color"), Category("All") ]
        public Color CircleColor
        {
            get { return this.color; }
            set {
                this.color = value;
                /* crucial */
                this.Invalidate();
            }
        }
        public ColorCircleControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            g.FillEllipse(new SolidBrush(color), 0, 0, this.Width, this.Height);
        }
    }
}
