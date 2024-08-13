using AppApiPhotos.ViewModels;

namespace AppApiPhotos.Views;

public partial class PostsView : ContentPage
{
	public PostsView()
	{
		BindingContext = new PostViewModels();
		InitializeComponent();
	}
}