using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinGram
{
    public partial class App : Application
    {
        public static WordPressPCL.WordPressClient WPClient;
        public App()
        {
            InitializeComponent();

            WPClient = new WordPressPCL.WordPressClient("http://itworldcanada.com/wp-json/");
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
