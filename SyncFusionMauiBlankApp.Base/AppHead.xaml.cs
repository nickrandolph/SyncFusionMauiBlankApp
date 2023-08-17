using System;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Uno.Resizetizer;

namespace SyncFusionMauiBlankApp;

public sealed partial class AppHead : App
{
	static AppHead() =>
		InitializeLogging();

	/// <summary>
	/// Initializes the singleton application object. This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public AppHead()
	{
		this.InitializeComponent();

        //this.Resources.AddLibraryResources("MicrosoftMauiCoreIncluded", "ms-appx:///Microsoft.Maui/Platform/Windows/Styles/Resources.xbf");

    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
	{
		base.OnLaunched(args);

		MainWindow.SetWindowIcon();
	}

	/// <summary>
	/// Configures global Uno Platform logging
	/// </summary>
	private static void InitializeLogging()
	{
#if DEBUG
		// Logging is disabled by default for release builds, as it incurs a significant
		// initialization cost from Microsoft.Extensions.Logging setup. If startup performance
		// is a concern for your application, keep this disabled. If you're running on the web or
		// desktop targets, you can use URL or command line parameters to enable it.
		//
		// For more performance documentation: https://platform.uno/docs/articles/Uno-UI-Performance.html

		var factory = LoggerFactory.Create(builder =>
		{
#if __WASM__
			builder.AddProvider(new global::Uno.Extensions.Logging.WebAssembly.WebAssemblyConsoleLoggerProvider());
#elif __IOS__ || __MACCATALYST__
			builder.AddProvider(new global::Uno.Extensions.Logging.OSLogLoggerProvider());
#elif NETFX_CORE
			builder.AddDebug();
#else
			builder.AddConsole();
#endif

			// Exclude logs below this level
			builder.SetMinimumLevel(LogLevel.Information);

			// Default filters for Uno Platform namespaces
			builder.AddFilter("Uno", LogLevel.Warning);
			builder.AddFilter("Windows", LogLevel.Warning);
			builder.AddFilter("Microsoft", LogLevel.Warning);

			// Generic Xaml events
			// builder.AddFilter("Microsoft.UI.Xaml", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.VisualStateGroup", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.StateTriggerBase", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.UIElement", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.FrameworkElement", LogLevel.Trace );

			// Layouter specific messages
			// builder.AddFilter("Microsoft.UI.Xaml.Controls", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.Controls.Layouter", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.Controls.Panel", LogLevel.Debug );

			// builder.AddFilter("Windows.Storage", LogLevel.Debug );

			// Binding related messages
			// builder.AddFilter("Microsoft.UI.Xaml.Data", LogLevel.Debug );
			// builder.AddFilter("Microsoft.UI.Xaml.Data", LogLevel.Debug );

			// Binder memory references tracking
			// builder.AddFilter("Uno.UI.DataBinding.BinderReferenceHolder", LogLevel.Debug );

			// RemoteControl and HotReload related
			// builder.AddFilter("Uno.UI.RemoteControl", LogLevel.Information);

			// Debug JS interop
			// builder.AddFilter("Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug );
		});

		global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory = factory;

#if HAS_UNO
		global::Uno.UI.Adapter.Microsoft.Extensions.Logging.LoggingAdapter.Initialize();
#endif
#endif
	}
}


internal static class ResourceDictionaryExtensions
{
    public static T? TryGet<T>(this Microsoft.UI.Xaml.ResourceDictionary? resources, string key)
    {
        if (resources?.ContainsKey(key) == true && resources[key] is T typed)
            return typed;
        return default;
    }

    public static void AddLibraryResources(this Microsoft.UI.Xaml.ResourceDictionary? resources, string key, string uri)
    {
        if (resources == null)
            return;

        var dictionaries = resources.MergedDictionaries;
        if (dictionaries == null)
            return;

        if (!resources.ContainsKey(key))
        {
            dictionaries.Add(new Microsoft.UI.Xaml.ResourceDictionary
            {
                Source = new Uri(uri)
            });
        }
    }

    public static void AddLibraryResources<T>(this Microsoft.UI.Xaml.ResourceDictionary? resources)
        where T : Microsoft.UI.Xaml.ResourceDictionary, new()
    {
        var dictionaries = resources?.MergedDictionaries;
        if (dictionaries == null)
            return;

        var found = false;
        foreach (var dic in dictionaries)
        {
            if (dic is T)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            var dic = new T();
            dictionaries.Add(dic);
        }
    }

    internal static void RemoveKeys(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys)
    {
        foreach (string key in keys)
        {
            resources.Remove(key);
        }
    }

    internal static void SetValueForAllKey(this Microsoft.UI.Xaml.ResourceDictionary resources, IEnumerable<string> keys, object? value)
    {
        foreach (string key in keys)
        {
            resources[key] = value;
        }
    }
}
