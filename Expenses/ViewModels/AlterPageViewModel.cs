using System.Windows.Input;
using Expenses.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PropertyChanged;

namespace Expenses.ViewModels
{
	[ImplementPropertyChanged]
	public class AlterPageViewModel
	{
		private readonly INavigationService _navigationService;
		public Change Change { get; set; }
		public ICommand AcceptCommand { get; set; }
		public ICommand RejectCommand { get; set; }

		public AlterPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			AcceptCommand = new RelayCommand(Accept);
			RejectCommand = new RelayCommand(Reject);
		}

		private void Accept()
		{
			_navigationService.NavigateTo("MainPage", Change);
		}

		private void Reject()
		{
			_navigationService.NavigateTo("MainPage", null);
		}

	}

}