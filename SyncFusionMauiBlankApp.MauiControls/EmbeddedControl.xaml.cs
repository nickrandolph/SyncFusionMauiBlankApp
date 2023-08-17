using System.Reflection;
using Font = Microsoft.Maui.Graphics.Font;
using IImage = Microsoft.Maui.Graphics.IImage;
#if IOS || ANDROID || MACCATALYST
using Microsoft.Maui.Graphics.Platform;
#elif WINDOWS
using Microsoft.Maui.Graphics.Win2D;
#endif

using Syncfusion.Maui.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;

namespace SyncFusionMauiBlankApp.MauiControls;

public partial class EmbeddedControl : ContentView
{
	public EmbeddedControl()
	{
		InitializeComponent();

#if WINDOWS
        try
        {
            W2DGraphicsView w2DGraphicsView = new W2DGraphicsView();
        }
        catch(Exception ex)
        {

        }
#endif
    }
}

public class ChartDataModel
{
    public string? Name { get; set; }

    public double Data { get; set; }

    public string? Label { get; set; }
    public DateTime Date { get; set; }

    public double Value { get; set; }

    public double Value1 { get; set; }

    public double Size { get; set; }

    public double High { get; set; }

    public double Low { get; set; }

    public bool IsSummary { get; set; }

    public string? Department { get; set; }

    public string? Image { get; set; }

    public List<double>? EmployeeAges { get; set; }

    public Brush? Color { get; set; }

    public double Percentage { get; set; }

    public ChartDataModel(string department, List<double> employeeAges)
    {
        Department = department;
        EmployeeAges = employeeAges;
    }

    public ChartDataModel(string name, double value)
    {
        Name = name;
        Value = value;
    }

    public ChartDataModel(string name, double value, Brush color, double percentage)
    {
        Name = name;
        Value = value;
        Color = color;
        Percentage = percentage;
    }

    public ChartDataModel(string name, double value, string image)
    {
        Name = name;
        Value = value;
        Image = image;
    }

    public ChartDataModel(string name, double value, double horizontalErrorValue, double verticalErrorValue)
    {
        Name = name;
        Value = value;
        High = horizontalErrorValue;
        Low = verticalErrorValue;
    }

    public ChartDataModel(string name, double value, double size)
    {
        Name = name;
        Value = value;
        Size = size;
    }

    public ChartDataModel()
    {

    }
    public ChartDataModel(DateTime date, double value, double size)
    {
        Date = date;
        Value = value;
        Size = size;
    }

    public ChartDataModel(double value, double value1, double size)
    {
        Value1 = value;
        Value = value1;
        Size = size;
    }

    public ChartDataModel(double value1, double value, double size, string label)
    {
        Value1 = value1;
        Value = value;
        Size = size;
        Label = label;
    }

    public ChartDataModel(string name, double high, double low, double open, double close)
    {
        Name = name;
        High = high;
        Low = low;
        Value = open;
        Size = close;
    }

    public ChartDataModel(double name, double high, double low, double open, double close)
    {
        Data = name;
        High = high;
        Low = low;
        Value = open;
        Size = close;
    }

    public ChartDataModel(DateTime date, double high, double low, double open, double close)
    {
        Date = date;
        High = high;
        Low = low;
        Value = open;
        Size = close;
    }
    public ChartDataModel(double value, double size)
    {
        Value = value;
        Size = size;
    }
    public ChartDataModel(DateTime dateTime, double value)
    {
        Date = dateTime;
        Value = value;
    }

    public ChartDataModel(string name, double value, bool isSummary)
    {
        Name = name;
        Value = value;
        IsSummary = isSummary;
    }
}
public class PieSeriesViewModel : BaseViewModel
{
    public ObservableCollection<ChartDataModel> PieSeriesData { get; set; }
    public ObservableCollection<ChartDataModel> SemiCircularData { get; set; }
    public ObservableCollection<ChartDataModel> GroupToData { get; set; }

    public PieSeriesViewModel()
    {
        PieSeriesData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("David", 16.6),
                new ChartDataModel("Steve", 14.6),
                new ChartDataModel("Jack", 18.6),
                new ChartDataModel("John", 20.5),
                new ChartDataModel("Regev", 39.5),
           };

        SemiCircularData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel("Product A", 750),
                new ChartDataModel("Product B", 463),
                new ChartDataModel("Product C", 389),
                new ChartDataModel("Product D", 697),
                new ChartDataModel("Product E", 251)
            };

        GroupToData = new ObservableCollection<ChartDataModel>
            {
                new ChartDataModel( "US",22.90,0.244),
                new ChartDataModel("China",16.90,0.179),
                new ChartDataModel( "Japan",5.10,0.054),
                new ChartDataModel("Germany",4.20,0.045),
                new ChartDataModel("UK",3.10,0.033),
                new ChartDataModel("India",2.90,0.031),
                new ChartDataModel("France",2.90,0.031),
                new ChartDataModel( "Italy",2.10,0.023),
                new ChartDataModel( "Canada",2.00,0.021),
                new ChartDataModel( "Korea",1.80,0.019),
                new ChartDataModel("Russia",1.60,0.017),
                new ChartDataModel("Brazil",1.60,0.017),
                new ChartDataModel("Australia",1.60,0.017),
                new ChartDataModel("Spain",1.40,0.015),
                new ChartDataModel("Mexico",1.30,0.014),
                new ChartDataModel("Indonesia",1.20,0.012),
                new ChartDataModel("Iran",1.10,0.011),
                new ChartDataModel("Netherlands",1.00,0.011),
                new ChartDataModel("Saudi Arabia",0.80,0.009),
                new ChartDataModel("Switzerland",0.80,0.009),
                new ChartDataModel("Turkey",0.80,0.008),
                new ChartDataModel("Taiwan",0.80,0.008),
                new ChartDataModel("Poland",0.70,0.007),
                new ChartDataModel("Sweden",0.60,0.007),
                new ChartDataModel("Belgium",0.60,0.006),
                new ChartDataModel("Thailand",0.50,0.006),
                new ChartDataModel("Ireland",0.50,0.005),
                new ChartDataModel("Austria",0.50,0.005),
                new ChartDataModel("Nigeria",0.50,0.005),
                new ChartDataModel("Israel",0.50,0.005),
                new ChartDataModel("Argentina",0.50,0.005),
                new ChartDataModel("Norway",0.40,0.005),
                new ChartDataModel("South Africa",0.40,0.004),
                new ChartDataModel("UAE",0.40,0.004),
                new ChartDataModel("Denmark",0.40,0.004),
                new ChartDataModel("Egypt",0.40,0.004),
                new ChartDataModel("Philippines",0.40,0.004),
                new ChartDataModel("Singapore",0.40,0.004),
                new ChartDataModel("Malaysia",0.40,0.004),
                new ChartDataModel("Hong Kong SAR",0.40,0.004),
                new ChartDataModel("Vietnam",0.40,0.004),
                new ChartDataModel("Bangladesh",0.40,0.004),
                new ChartDataModel("Chile",0.30,0.004),
                new ChartDataModel("Colombia",0.30,0.003),
                new ChartDataModel("Finland",0.30,0.003),
                new ChartDataModel("Romania",0.30,0.003),
                new ChartDataModel("Czech Republic",0.30,0.003),
                new ChartDataModel("Portugal",0.30,0.003),
                new ChartDataModel("Pakistan",0.30,0.003),
                new ChartDataModel("New Zealand",0.20,0.003),
            };
    }
}



public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Brush> PaletteBrushes { get; set; }
    public ObservableCollection<Brush> SelectionBrushes { get; set; }
    public ObservableCollection<Brush> CustomColor1 { get; set; }

    public ObservableCollection<Brush> CustomColor2 { get; set; }
    public ObservableCollection<Brush> AlterColor1 { get; set; }
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public Array PieGroupMode
    {
        get { return Enum.GetValues(typeof(PieGroupMode)); }
    }

    private bool enableAnimation = true;
    public bool EnableAnimation
    {
        get { return enableAnimation; }
        set
        {
            enableAnimation = value;
            OnPropertyChanged("EnableAnimation");
        }
    }

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public BaseViewModel()
    {
        PaletteBrushes = new ObservableCollection<Brush>()
            {
               new SolidColorBrush(Color.FromArgb("#314A6E")),
                 new SolidColorBrush(Color.FromArgb("#48988B")),
                 new SolidColorBrush(Color.FromArgb("#5E498C")),
                 new SolidColorBrush(Color.FromArgb("#74BD6F")),
                 new SolidColorBrush(Color.FromArgb("#597FCA"))
            };

        SelectionBrushes = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#40314A6E")),
                new SolidColorBrush(Color.FromArgb("#4048988B")),
                new SolidColorBrush(Color.FromArgb("#405E498C")),
                new SolidColorBrush(Color.FromArgb("#4074BD6F")),
                new SolidColorBrush(Color.FromArgb("#40597FCA"))
            };

        CustomColor2 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#519085")),
                new SolidColorBrush(Color.FromArgb("#F06C64")),
                new SolidColorBrush(Color.FromArgb("#FDD056")),
                new SolidColorBrush(Color.FromArgb("#81B589")),
                new SolidColorBrush(Color.FromArgb("#88CED2"))
            };

        CustomColor1 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#95DB9C")),
                new SolidColorBrush(Color.FromArgb("#B95375")),
                new SolidColorBrush(Color.FromArgb("#56BBAF")),
                new SolidColorBrush(Color.FromArgb("#606D7F")),
                new SolidColorBrush(Color.FromArgb("#E99941")),
                new SolidColorBrush(Color.FromArgb("#327DBE")),
                new SolidColorBrush(Color.FromArgb("#E7695A")),
            };

        AlterColor1 = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#346bf5")),
                new SolidColorBrush(Color.FromArgb("#ff9d00")),
            };
    }
}


public class CornerRadiusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            return new CornerRadius((double)value / 2);
        }

        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}




internal class LineDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 6;
        // canvas.StrokeDashPattern = new float[] { 2, 2 };
        canvas.DrawLine(10, 10, 90, 100);
    }
}

internal class EllipseDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.DrawEllipse(10, 10, 150, 50);
    }
}

internal class FilledEllipseDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Red;
        canvas.FillEllipse(10, 10, 100, 50);
    }
}

internal class CircleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.DrawEllipse(10, 10, 100, 100);
    }
}

internal class RectangleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.DarkBlue;
        canvas.StrokeSize = 4;
        canvas.DrawRectangle(10, 10, 100, 50);
    }
}

internal class SquareDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.DarkBlue;
        canvas.StrokeSize = 4;
        canvas.DrawRectangle(10, 10, 100, 100);
    }
}

internal class FilledRectangleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.DarkBlue;
        canvas.FillRectangle(10, 10, 100, 50);
    }
}

internal class RoundedRectangleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 4;
        canvas.DrawRoundedRectangle(10, 10, 100, 50, 12);
    }
}

internal class FilledRoundedRectangleDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Green;
        canvas.FillRoundedRectangle(10, 10, 100, 50, 12);
    }
}

internal class ArcDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Teal;
        canvas.StrokeSize = 4;
        canvas.DrawArc(10, 10, 100, 100, 0, 180, true, false);
    }
}

internal class FilledArcDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Teal;
        canvas.FillArc(10, 10, 100, 100, 0, 180, true);
    }
}

internal class PathDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        PathF path = new PathF();
        path.MoveTo(40, 10);
        path.LineTo(70, 80);
        path.LineTo(10, 50);
        path.Close();
        canvas.StrokeColor = Colors.Green;
        canvas.StrokeSize = 6;
        canvas.DrawPath(path);
    }
}

internal class FilledPathDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        PathF path = new PathF();
        path.MoveTo(40, 10);
        path.LineTo(70, 80);
        path.LineTo(10, 50);
        canvas.FillColor = Colors.SlateBlue;
        canvas.FillPath(path);
    }
}

internal class ImageDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        IImage? image = default;
        Assembly assembly = GetType().GetTypeInfo().Assembly;
        using (Stream stream = assembly.GetManifestResourceStream("GraphicsViewDemos.Resources.Images.dotnet_bot.png"))
        {
#if IOS || ANDROID || MACCATALYST
                // PlatformImage isn't currently supported on Windows.
                image = PlatformImage.FromStream(stream);
#elif WINDOWS
            image = new W2DImageLoadingService().FromStream(stream);
#endif
        }

        if (image != null)
        {
            canvas.DrawImage(image, 10, 10, image.Width, image.Height);
        }
    }
}

internal class StringDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FontColor = Colors.Blue;
        canvas.FontSize = 18;

        canvas.Font = Font.Default;
        canvas.DrawString("Text is left aligned.", 20, 20, 380, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
        canvas.DrawString("Text is centered.", 20, 60, 380, 100, HorizontalAlignment.Center, VerticalAlignment.Top);
        canvas.DrawString("Text is right aligned.", 20, 100, 380, 100, HorizontalAlignment.Right, VerticalAlignment.Top);

        canvas.Font = Font.DefaultBold;
        canvas.DrawString("This text is displayed using the bold system font.", 20, 140, 350, 100, HorizontalAlignment.Left, VerticalAlignment.Top);

        canvas.Font = new Font("Arial");
        canvas.FontColor = Colors.Black;
        canvas.SetShadow(new SizeF(6, 6), 4, Colors.Gray);
        canvas.DrawString("This text has a shadow.", 20, 200, 300, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
    }
}

internal class AttributedTextDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        //canvas.FontName = "Arial";
        //canvas.FontSize = 18;
        //canvas.FontColor = Colors.Blue;

        //string markdownText = @"This is *italic text*, **bold text**, __underline text__, and ***bold italic text***.";
        //IAttributedText attributedText = MarkdownAttributedTextReader.Read(markdownText); // Requires the Microsoft.Maui.Graphics.Text.Markdig package
        //canvas.DrawText(attributedText, 10, 10, 400, 400);
    }
}

internal class FillAndStrokeDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 4;

        PathF path = new PathF();
        path.AppendCircle(dirtyRect.Center.X, dirtyRect.Center.Y, radius);

        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeSize = 10;
        canvas.FillColor = Colors.Red;

        canvas.FillPath(path);
        canvas.DrawPath(path);
    }
}

internal class ShadowDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Red;
        canvas.SetShadow(new SizeF(10, 10), 4, Colors.Grey);
        canvas.FillRectangle(10, 10, 90, 100);

        canvas.FillColor = Colors.Green;
        canvas.SetShadow(new SizeF(10, -10), 4, Colors.Grey);
        canvas.FillEllipse(110, 10, 90, 100);

        canvas.FillColor = Colors.Blue;
        canvas.SetShadow(new SizeF(-10, 10), 4, Colors.Grey);
        canvas.FillRoundedRectangle(210, 10, 90, 100, 25);
    }
}

internal class RegularDashedObjectDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.StrokeDashPattern = new float[] { 2, 2 };
        canvas.DrawRectangle(10, 10, 90, 100);
    }
}

internal class IrregularDashedObjectDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 4;
        canvas.StrokeDashPattern = new float[] { 4, 4, 1, 4 };
        canvas.DrawRectangle(10, 10, 90, 100);
    }
}

internal class LineEndsDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 10;
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeLineCap = LineCap.Round;
        canvas.DrawLine(10, 10, 110, 110);
    }
}

internal class LineJoinsDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        PathF path = new PathF();
        path.MoveTo(10, 10);
        path.LineTo(110, 50);
        path.LineTo(10, 110);

        canvas.StrokeSize = 20;
        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeLineJoin = LineJoin.Round;
        canvas.DrawPath(path);
    }
}

internal class ClippingDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        IImage? image = default;

        var assembly = GetType().GetTypeInfo().Assembly;
        using (var stream = assembly.GetManifestResourceStream("GraphicsViewDemos.Resources.Images.dotnet_bot.png"))
        {
#if IOS || ANDROID || MACCATALYST
                // PlatformImage isn't currently supported on Windows.
                image = PlatformImage.FromStream(stream);
#elif WINDOWS
            image = new W2DImageLoadingService().FromStream(stream);
#endif
        }

        if (image != null)
        {
            PathF path = new PathF();
            path.AppendCircle(100, 90, 80);
            canvas.ClipPath(path);  // Must be called before DrawImage
            canvas.DrawImage(image, 10, 10, image.Width, image.Height);
        }
    }
}

internal class SubtractClippingDrawable : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        IImage? image = default;
        var assembly = GetType().GetTypeInfo().Assembly;
        using (var stream = assembly.GetManifestResourceStream("GraphicsViewDemos.Resources.Images.dotnet_bot.png"))
        {
#if IOS || ANDROID || MACCATALYST
                // PlatformImage isn't currently supported on Windows.
                image = PlatformImage.FromStream(stream);
#elif WINDOWS
            image = new W2DImageLoadingService().FromStream(stream);
#endif
        }

        if (image != null)
        {
            canvas.SubtractFromClip(60, 60, 90, 90);
            canvas.DrawImage(image, 10, 10, image.Width, image.Height);
        }
    }
}