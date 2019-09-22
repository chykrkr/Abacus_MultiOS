using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AbacusMobile
{
    class Beed : ImageButton
    {
        const int posCountMax = 7;
        //const String imgBeedSet = "image/beed.png";
        static int[] unsetValues = new int[posCountMax] { 5, 0, 0, 1, 2, 3, 4};

        int unsetValue = 0;
        int pos = 0;
        bool empty = true;

        static Beed()
        {
        }

        public Beed() : this(false)
        {
        }

        public Beed(bool empty) : this(empty, 0)
        {
        }

        public Beed(bool empty, int pos)
        {
            this.Empty = empty;
            this.Pos = pos;
            this.Source = ImageSource.FromResource("AbacusMobile.images.beed.png");
            this.Aspect = Aspect.Fill;
            this.BackgroundColor = Color.Transparent;
        }

        public bool Empty {
            get => empty;
            set {
                empty = value;
                this.IsVisible = !empty;
            }
        }

        public int Pos {
            get => pos;
            set
            {
                if (value < 0 || value >= posCountMax)
                {
                    throw new IndexOutOfRangeException();
                }
                pos = value;
                unsetValue = unsetValues[pos];
            }
        }
    }
}
