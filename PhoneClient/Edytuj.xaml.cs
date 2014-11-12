﻿using System;
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
    public sealed partial class Edytuj : Page
    {
        public Edytuj()
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
            TitleTextBox.Text = activePost.Title;
            ContenTextBox.Text = activePost.Content;
            AuthorTextBox.Text = activePost.Author;
        }

        private void ZapiszBtnClick(object sender, RoutedEventArgs e)
        {
            
            activePost.Title = TitleTextBox.Text;
            activePost.Content = ContenTextBox.Text;
            activePost.Author = AuthorTextBox.Text;

            var client = new HttpClient();

            var httpContent = new StringContent(JsonConvert.SerializeObject(activePost), Encoding.UTF8, "application/json");
            var result = client.PutAsync("http://knkolorblog.azurewebsites.net/api/blog/"+activePost.Id, httpContent).Result;

            Frame.Navigate(typeof (MainPage));

        }
    }
}
