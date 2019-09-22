using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AbacusMobile
{
    class AbacusSet : StackLayout
    {
        const int COLS = 9;

        BeedColumn[] beedcols = new BeedColumn[COLS];
        public AbacusSet()
        {
            /* to fill 1 pixel width gaps */
            this.Spacing = -1;
            this.Orientation = StackOrientation.Horizontal;

            for (int i = 0; i < COLS; i++)
            {
                beedcols[i] = new BeedColumn();
                beedcols[i].HorizontalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(beedcols[i]);
            }

            this.SizeChanged += AbacusSet_SizeChanged;
        }

        private void AbacusSet_SizeChanged(object sender, EventArgs e)
        {
            double col_height = this.Height;
            double col_width = col_height / 5;

            for(int i = 0; i < COLS; i++)
            {
                beedcols[i].WidthRequest = col_width;
                beedcols[i].HeightRequest = col_height;
            }
        }
    }
}
