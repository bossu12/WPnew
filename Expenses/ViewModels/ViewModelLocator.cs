using Expenses.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Expenses.ViewModels
{
	public class ViewModelLocator
	{
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			var navigationService = CreateNavigationService();
			SimpleIoc.Default.Register<MainPageViewModel>();
			SimpleIoc.Default.Register<AlterPageViewModel>();
			SimpleIoc.Default.Register<IDialogService, DialogService>();
			SimpleIoc.Default.Register(() => navigationService);
		}

		private INavigationService CreateNavigationService()
		{
			var navigationService = new NavigationService();
			navigationService.Configure("AlterPage", typeof(AlterPage));
			navigationService.Configure("MainPage", typeof(MainPage));

			return navigationService;
		}

		public MainPageViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainPageViewModel>();
			}
		}

		public AlterPageViewModel Alter
		{
			get
			{
				return ServiceLocator.Current.GetInstance<AlterPageViewModel>();
			}
		}
		
		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}