using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RxExample4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mouseDown = Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
                handler => MouseDown += handler,
                handler => MouseDown -= handler);

            var mouseUp = Observable.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
                handler => MouseUp += handler,
                handler => MouseUp -= handler);

            var mouseMove = Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
                handler => MouseMove += handler,
                handler => MouseMove -= handler);

            var drags = mouseMove.SkipUntil(mouseDown).TakeUntil(mouseUp).Repeat();

            var leftClicks = mouseDown.Where(x => x.EventArgs.LeftButton == MouseButtonState.Pressed);

            leftClicks.Subscribe(
                clickEvent =>
                    {
                        var circle = new Ellipse {Width = 10, Height = 10};
                        var brush = new SolidColorBrush(Colors.Red);
                        circle.Fill = brush;
                        Canvas.SetLeft(circle, clickEvent.EventArgs.GetPosition(canvas).X);
                        Canvas.SetTop(circle, clickEvent.EventArgs.GetPosition(canvas).Y);
                        canvas.Children.Add(circle);
                    });

            drags.Subscribe(
                moveEvent =>
                {
                    var circle = new Ellipse { Width = 3, Height = 3 };
                    var brush = new SolidColorBrush(Colors.Green);
                    circle.Fill = brush;
                    Canvas.SetLeft(circle, moveEvent.EventArgs.GetPosition(canvas).X);
                    Canvas.SetTop(circle, moveEvent.EventArgs.GetPosition(canvas).Y);
                    canvas.Children.Add(circle);
                });
        }
    }
}
