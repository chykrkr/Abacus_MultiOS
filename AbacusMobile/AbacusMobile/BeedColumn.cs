using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AbacusMobile
{
    class BeedColumn : AbsoluteLayout 
    {
        const int COUNT = 7;         // 16

        Beed[] beeds = new Beed[COUNT];
        Image vertbar;
        HorzBar horzbar;

        public BeedColumn()
        {
            int i = 0;

            vertbar = new Image();
            vertbar.Source = ImageSource.FromResource("AbacusMobile.images.vertbar.png");
            vertbar.Aspect = Aspect.Fill;
            this.Children.Add(vertbar);

            horzbar = new HorzBar();
            this.Children.Add(horzbar);

            beeds[i] = new Beed(false, i);
            this.Children.Add(beeds[i]);
            i++;
            beeds[i] = new Beed(true, i);
            this.Children.Add(beeds[i]);
            i++;

            beeds[i] = new Beed(true, i);
            this.Children.Add(beeds[i]);
            i++;
            beeds[i] = new Beed(false, i);
            this.Children.Add(beeds[i]);
            i++;
            beeds[i] = new Beed(false, i);
            this.Children.Add(beeds[i]);
            i++;
            beeds[i] = new Beed(false, i);
            this.Children.Add(beeds[i]);
            i++;
            beeds[i] = new Beed(false, i);
            this.Children.Add(beeds[i]);
            i++;

            prepareBeedEvent();

            this.SizeChanged += BeedColumn_SizeChanged;
        }

        public void prepareBeedEvent()
        {
            for (int i = 0; i < beeds.Length; i++)
            {
                beeds[i].Clicked += beedClicked;
            }
        }

        private void beedClicked(object sender, EventArgs e)
        {
            Beed beed = (Beed)sender;

            if (beed.Empty)
                return;

            if (beed.Pos == 0)
            {
                beeds[1].Empty = false;
                beed.Empty = true;
                return;
            }

            if (beed.Pos == 1)
            {
                beeds[0].Empty = false;
                beed.Empty = true;
                return;
            }

            for (int i = 2; i < beeds.Length ; i++)
            {
                if (beeds[i].Empty)
                {
                    beeds[i].Empty = false;
                    break;
                }
            }

            beed.Empty = true;
        }

        private void BeedColumn_SizeChanged(object sender, EventArgs e)
        {
            double horzbarHeight = this.Height / (7 * 5 + 1);
            double beedWidth =  this.Width;
            double vertbarWidth = beedWidth / 5;
            double beedHeight = (this.Height - horzbarHeight) / COUNT;

            Rectangle bounds;
            int i = 0;

            /* vertical bar */
            bounds = new Rectangle((beedWidth - vertbarWidth) / 2, 0, vertbarWidth, this.Height);
            AbsoluteLayout.SetLayoutBounds(vertbar, bounds);

            /* upper beeds */
            bounds = new Rectangle(0, i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
            bounds = new Rectangle(0, i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;

            /* horizontal bar */
            bounds = new Rectangle(0, i * beedHeight, beedWidth, horzbarHeight);
            AbsoluteLayout.SetLayoutBounds(horzbar, bounds);

            /* below beeds */
            bounds = new Rectangle(0, horzbarHeight + i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
            bounds = new Rectangle(0, horzbarHeight + i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
            bounds = new Rectangle(0, horzbarHeight + i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
            bounds = new Rectangle(0, horzbarHeight + i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
            bounds = new Rectangle(0, horzbarHeight + i * beedHeight, beedWidth, beedHeight);
            AbsoluteLayout.SetLayoutBounds(beeds[i], bounds);
            i++;
        }
    }
}
