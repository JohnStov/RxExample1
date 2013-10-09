using System;
using System.Reactive;
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
                clickEvent => DrawCircle(Colors.Red, 10, clickEvent.EventArgs.GetPosition(canvas)));

            drags.Subscribe(
                moveEvent => DrawCircle(Colors.Green, 3, moveEvent.EventArgs.GetPosition(canvas)));
        }

        private void DrawCircle(Color colour, int diameter, Point position)
        {
            EventPattern<MouseButtonEventArgs> clickEvent;
            var circle = new Ellipse { Width = diameter, Height = diameter };
            var brush = new SolidColorBrush(colour);
            circle.Fill = brush;
            Canvas.SetLeft(circle, position.X);
            Canvas.SetTop(circle, position.Y);
            canvas.Children.Add(circle);
        }
    }
}
