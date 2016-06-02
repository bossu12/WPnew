using Windows.UI.Xaml.Navigation;
using Expenses.Models;
using Expenses.ViewModels;

namespace Expenses.Views
{
	public sealed partial class AlterPage
	{
		public AlterPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var parameter = e.Parameter as Change;
			var context = (AlterPageViewModel) DataContext;
			context.Change = parameter;
		}
	}
}
