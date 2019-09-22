using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbacusMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.abacusView.SizeChanged += AbacusView_SizeChanged;
        }

        private void AbacusView_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void StackLayout_SizeChanged(object sender, EventArgs e)
        {
            double height = Math.Min(((StackLayout)sender).Width, ((StackLayout)sender).Height);
            abacusView.HeightRequest = height;
            abacusSet.HeightRequest = height;
        }
    }
}
