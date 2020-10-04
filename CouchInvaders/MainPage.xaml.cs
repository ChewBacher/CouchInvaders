using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CouchInvaders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // UI Thread
        private void MainCanvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {

        }

        // Game Thread
        private void MainCanvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            CanvasDrawingSession ds = args.DrawingSession;

            Size rtSize = sender.Size;
            Size pixelSize = new Size(
                sender.ConvertDipsToPixels((float)rtSize.Width, CanvasDpiRounding.Floor), 
                sender.ConvertDipsToPixels((float)rtSize.Height, CanvasDpiRounding.Floor));

            // Background gradient.
            using (var brush = CanvasRadialGradientBrush.CreateRainbow(ds, 0))
            {
                brush.Center = rtSize.ToVector2() / 2;

                brush.RadiusX = (float)rtSize.Width;
                brush.RadiusY = (float)rtSize.Height;

                ds.FillRectangle(0, 0, (float)rtSize.Width, (float)rtSize.Height, brush);
            }

            // Text label.
            var label = string.Format("{0}\n{1:0} x {2:0}", "Couch Invaders by Dad and Riker!!!", pixelSize.Width, pixelSize.Height);

            ds.DrawText(label, rtSize.ToVector2() / 2, Colors.Black);

        }

        // Game Thread
        private void MainCanvas_GameLoopStarting(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, object args)
        {

        }

        // Game Thread
        private void MainCanvas_GameLoopStopped(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, object args)
        {

        }

        // Game Thread
        private void MainCanvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {

        }

        // UI Thread
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += KeyDown_UIThread;
        }

        // UI Thread
        private void KeyDown_UIThread(CoreWindow sender, KeyEventArgs args)
        {
            args.Handled = true;

            // extract the data from the args before marshaling it to the
            // game loop thread
            var virtualKey = args.VirtualKey;

            var action = MainCanvas.RunOnGameLoopThreadAsync(() => KeyDown_GameLoopThread(virtualKey));
        }

        // UI Thread
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown -= KeyDown_UIThread;
        }

        private void KeyDown_GameLoopThread(VirtualKey virtualKey)
        {
            // ...
        }
    }
}
