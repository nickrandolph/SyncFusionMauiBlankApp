#if ANDROID
using Android.Content;
using Android.Runtime;
#endif
using CommunityToolkit.Maui;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Hosting;
using Uno.UI;

namespace SyncFusionMauiBlankApp;
#if WINDOWS
public class App : MauiWinUIApplication
#else
public class App : Application
#endif
{
	protected Window? MainWindow { get; private set; }

#if WINDOWS
	protected override MauiApp CreateMauiApp()
    {
        throw new NotImplementedException();
    }
#endif
	protected override void OnLaunched(LaunchActivatedEventArgs args)
	{
#if NET6_0_OR_GREATER && WINDOWS && !HAS_UNO
		MainWindow = new Window();
#else
		MainWindow = Microsoft.UI.Xaml.Window.Current;
#endif

		this.UseMauiEmbedding<MauiControls.App>(
			 configure: builder =>
			 {
#if ANDROID
builder.Services.AddTransient<Context>(_ => ContextHelper.Current);
#endif

                 builder.UseMauiControls();
			 }
#if WINDOWS
             ,appAction: mauiApp => {
				 this.Services = mauiApp.Services;
				 this.Application = mauiApp.Services.GetRequiredService<IApplication>();
			 }
#elif ANDROID
             , appAction: mauiApp => {
				 var mock = new MockMauiApplication(0, default, mauiApp);
             }
#elif __IOS__
             , appAction: mauiApp => {
				 var mock = new MockMauiApplication(mauiApp);
             }

#endif
             );

		// Do not repeat app initialization when the Window already has content,
		// just ensure that the window is active
		if (MainWindow.Content is not Frame rootFrame)
		{
			// Create a Frame to act as the navigation context and navigate to the first page
			rootFrame = new Frame();

			// Place the frame in the current Window
			MainWindow.Content = rootFrame;

			rootFrame.NavigationFailed += OnNavigationFailed;
		}

		if (rootFrame.Content == null)
		{
			// When the navigation stack isn't restored navigate to the first page,
			// configuring the new page by passing required information as a navigation
			// parameter
			rootFrame.Navigate(typeof(MainPage), args.Arguments);
		}

		// Ensure the current window is active
		MainWindow.Activate();
	}

	/// <summary>
	/// Invoked when Navigation to a certain page fails
	/// </summary>
	/// <param name="sender">The Frame which failed navigation</param>
	/// <param name="e">Details about the navigation failure</param>
	void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
	{
		throw new InvalidOperationException($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
	}
}

#if ANDROID
public class MockMauiApplication : Microsoft.Maui.MauiApplication
{
    public MockMauiApplication(nint handle, JniHandleOwnership ownership, MauiApp mauiApp) : base(handle, ownership)
    {
        this.Services = mauiApp.Services;
        this.Application = mauiApp.Services.GetRequiredService<IApplication>();
    }

    protected override MauiApp CreateMauiApp()
    {
        throw new NotImplementedException();
    }
}
#endif



#if __IOS__
public class MockMauiApplication : Microsoft.Maui.MauiUIApplicationDelegate
{
    public MockMauiApplication(MauiApp mauiApp) : base()
    {
        this.Services = mauiApp.Services;
        this.Application = mauiApp.Services.GetRequiredService<IApplication>();
    }

    protected override MauiApp CreateMauiApp()
    {
        throw new NotImplementedException();
    }
}
#endif
