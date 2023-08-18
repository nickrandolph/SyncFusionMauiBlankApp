using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;

namespace SyncFusionMauiBlankApp;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiControls(this MauiAppBuilder builder)
    {
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your_Key");
        return builder
        //.UseMauiCommunityToolkit()
                    .ConfigureSyncfusionCore()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("SyncFusionMauiBlankApp/Assets/Fonts/OpenSans-Regular.ttf", "OpenSansRegular");
                        fonts.AddFont("SyncFusionMauiBlankApp/Assets/Fonts/OpenSans-Semibold.ttf", "OpenSansSemibold");
                    });
    }
}