using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page());

            var tabbedPage = new TabbedPage();
            tabbedPage.Children.Add(new Page1());
            tabbedPage.Children.Add(new Page2());
            tabbedPage.Children.Add(new Page3());

            MainPage = new NavigationPage(tabbedPage);
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
