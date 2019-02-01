using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinGram.ViewModels;

namespace XamarinGram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<PostViewModel> Posts = new ObservableCollection<PostViewModel>();
        private int CurrentPage = 1;
        public HomePage()
        {
            InitializeComponent();
            GetNews();

            listview.ItemsSource = Posts;
            listview.ItemAppearing += Listview_ItemAppearing;
        }

        private void Listview_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                if (Posts.Any() && !listview.IsRefreshing && !BusyIndicator.IsRunning)
                {
                    if (Posts.Count > 12 && e.Item == Posts[Posts.Count - 10])
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            BusyIndicator.IsRunning = true;
                            await Task.Delay(500);
                            GetNews(CurrentPage + 1);
                        });
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }

        public async void GetNews(int Page = 1, int PerPage = 20)
        {
            try
            {
                var WPPosts = await App.WPClient.Posts.Query(new WordPressPCL.Utility.PostsQueryBuilder
                {
                    Page = Page,
                    PerPage = PerPage
                });

                if (WPPosts != null)
                {
                    List<int> MediaIds = new List<int>();
                    foreach (var Post in WPPosts)
                        MediaIds.Add(Post.FeaturedMedia ?? 0);

                    var Media = await App.WPClient.Media.Query(new WordPressPCL.Utility.MediaQueryBuilder
                    {
                        Include = MediaIds.ToArray()
                    });

                    foreach (var Post in WPPosts)
                    {
                        var Postvm = Helpers.Clonner.Clone<PostViewModel>(Post);
                        Postvm.Media = Helpers.Clonner.Clone<MediaViewModel>(Media.FirstOrDefault(m => m.Id == Post.FeaturedMedia.Value));
                        Posts.Add(Postvm);
                    }

                    CurrentPage = Page;
                }

                BusyIndicator.IsRunning = false;
                listview.IsRefreshing = false;
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }
    }
}