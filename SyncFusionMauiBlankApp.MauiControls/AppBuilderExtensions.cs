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
                        fonts.AddFont("SyncFusionMauiBlankApp/Assets/Fonts/regular.ttf", "OpenSansRegular");
                        fonts.AddFont("SyncFusionMauiBlankApp/Assets/Fonts/semibold.ttf", "OpenSansSemibold");
                    });
    }
}