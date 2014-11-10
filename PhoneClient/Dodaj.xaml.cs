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
    public sealed partial class Dodaj : Page
    {
        public Dodaj()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ZapiszBtnClick(object sender, RoutedEventArgs e)
        {
            
            var newPost = new Post();
            newPost.Id = Guid.NewGuid().ToString();
            newPost.Title = TitleTextBox.Text;
            newPost.Content = ContenTextBox.Text;
            newPost.Author = AuthorTextBox.Text;

            var client = new HttpClient();

            var httpContent = new StringContent(JsonConvert.SerializeObject(newPost), Encoding.UTF8, "application/json");
            var result = client.PostAsync("http://knkolorblog.azurewebsites.net/api/post", httpContent).Result;
            
        }
    }
}
