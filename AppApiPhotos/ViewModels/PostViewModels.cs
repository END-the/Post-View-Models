
using CommunityToolkit.Mvvm.ComponentModel;
using AppApiPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace AppApiPhotos.ViewModels
{
    public partial class PostViewModels : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts; //CUIDADE é umalisa de POST nao POST.S
        //é uma lista
        public ICommand getPostsCommand { get; }

        public PostViewModels()
        {
            getPostsCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            RestService restService = new RestService();
            posts = await restService.GetPostsAsync();

        }
    }
}
