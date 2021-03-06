﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
using Common.Models;
using Newtonsoft.Json;

namespace PhoneClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            

        }

        public static Post selectedPost;

        public void GetPosts()
        {
            var client = new HttpClient();
            var result = client
                .GetAsync("http://knkolorblog.azurewebsites.net/api/blog")
                .Result.Content.ReadAsStringAsync();
            var res = result.Result;
            var posts = JsonConvert.DeserializeObject<List<Post>>(res);
            ListBoxPost.ItemsSource = posts;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             GetPosts();
            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (Dodaj));
        }

        private void ListBoxPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPost = (Post)ListBoxPost.SelectedItem;
            Frame.Navigate(typeof (Szczegoly));

        }
    }
}
