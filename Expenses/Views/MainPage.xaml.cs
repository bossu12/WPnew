using Windows.UI.Xaml.Navigation;
using Expenses.Models;
using Expenses.ViewModels;

namespace Expenses.Views
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
			NavigationCacheMode = NavigationCacheMode.Required;
		}

		
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var parameter = e.Parameter as Change;
			var context = (MainPageViewModel)DataContext;
			
			if(parameter!=null)
				context.Changes.Add(parameter);
		}
	}
}
