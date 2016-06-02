using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Expenses.Views;

namespace Expenses
{
	public sealed partial class App
	{
		private TransitionCollection transitions;

		public App()
		{
			InitializeComponent();
			Suspending += OnSuspending;
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{

			Frame rootFrame = Window.Current.Content as Frame;

			if (rootFrame == null)
			{
				rootFrame = new Frame {CacheSize = 1};

				// TODO: change this value to a cache size that is appropriate for your application

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					// TODO: Load state from previously suspended application
				}

				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{
				if (rootFrame.ContentTransitions != null)
				{
					transitions = new TransitionCollection();
					foreach (var c in rootFrame.ContentTransitions)
					{
						transitions.Add(c);
					}
				}

				rootFrame.ContentTransitions = null;
				rootFrame.Navigated += RootFrame_FirstNavigated;

				if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
				{
					throw new Exception("Failed to create initial page");
				}
			}

			Window.Current.Activate();
		}

		private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
		{
			var rootFrame = sender as Frame;
			rootFrame.ContentTransitions = transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
			rootFrame.Navigated -= RootFrame_FirstNavigated;
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();

			// TODO: Save application state and stop any background activity
			deferral.Complete();
		}



	}
}