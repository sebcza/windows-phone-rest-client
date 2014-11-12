using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using Common.Models;
using Newtonsoft.Json;

namespace PhoneClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Szczegoly : Page
    {
        public Szczegoly()
        {
            this.InitializeComponent();
        }

        private Post activePost;

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            activePost = MainPage.selectedPost;

            TitleTextBlock.Text = activePost.Title;
            AuthorTextBlock.Text = activePost.Author;
            ContenTextBlock.Text = activePost.Content;
        }

        private void UsunBtnClick(object sender, RoutedEventArgs e)
        {

            var client = new HttpClient();
            var result = client.DeleteAsync("http://knkolorblog.azurewebsites.net/api/blog/"+activePost.Id).Result;
            Frame.Navigate(typeof (MainPage));
        }

        private void EdytujBtnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (Edytuj));
        }


    }
}
