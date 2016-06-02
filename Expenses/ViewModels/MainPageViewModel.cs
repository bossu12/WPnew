using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Expenses.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using PropertyChanged;

namespace Expenses.ViewModels
{
	[ImplementPropertyChanged]
	public class MainPageViewModel : ViewModelBase
	{
		public MainPageViewModel(INavigationService navigationService)
		{
			this.navigationService = navigationService;
			Changes = new ObservableCollection<Change>
			{
				new Change() {Name = "Biceps", Value = 322},
				new Change() {Name = "Tricpes", Value = 666},
				new Change() {Name = "Biceps", Value = 322},
				new Change() {Name = "Tricpes", Value = 666},
				new Change() {Name = "Biceps", Value = 322},
				new Change() {Name = "Tricpes", Value = 666}
			};

			DeleteSelectedItemCommand = new RelayCommand(DeleteSelectedItem, () => SelectedChange != null);
			AddNewItemCommand = new RelayCommand(AddNewItem);
			EditItemCommand = new RelayCommand(EditItem, () => SelectedChange != null);

			UpdateBalance(null, null);
			Changes.CollectionChanged += UpdateBalance;
		}
		public ObservableCollection<Change> Changes { get; set; }
		public decimal Balance { get; set; }
		public AlterPageViewModel AlterPageViewModel { get; set; }
		private readonly INavigationService navigationService;
		private Change selectedChange;


		public Change SelectedChange
		{
			get { return selectedChange; }
			set
			{
				selectedChange = value;
				DeleteSelectedItemCommand.RaiseCanExecuteChanged();
				EditItemCommand.RaiseCanExecuteChanged();
			}
		}

		public RelayCommand DeleteSelectedItemCommand { get; private set; }
		public ICommand AddNewItemCommand { get; private set; }
		public RelayCommand EditItemCommand { get; private set; }

		private void UpdateBalance(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
		{
			Balance = Changes.Sum(c => c.Value);
		}

		private void DeleteSelectedItem()
		{
			if (SelectedChange != null)
				Changes.Remove(SelectedChange);
		}

		private void AddNewItem()
		{
			navigationService.NavigateTo("AlterPage", new Change());
		}

		private void EditItem()
		{
			navigationService.NavigateTo("AlterPage", SelectedChange);
		}
	}
}