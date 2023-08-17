using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;

namespace SyncFusionMauiBlankApp;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiControls(this MauiAppBuilder builder)
    {
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your_Key");
        return builder
        .UseMauiCommunityToolkit()
                    .ConfigureSyncfusionCore();
    }
}