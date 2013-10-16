//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Data;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Kinect.Toolkit.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using System.IO;
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class Keyboard
    {
        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
            "PageLeftEnabled", typeof(bool), typeof(Keyboard), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(Keyboard), new PropertyMetadata(false));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        private readonly KinectSensorChooser sensorChooser;

        private HardwareController _hardwareController = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Keyboard"/> class. 
        /// </summary>
        public Keyboard()
        {
            this.InitializeComponent();

            // initialize the sensor chooser and UI
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            // Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            // Clear out placeholder content
            this.wrapPanel.Children.RemoveAt(this.wrapPanel.Children.Count-1);
            
            // Add in display content
            //for (var index = 0; index < 300; ++index)
            //{
            //    var button = new KinectTileButton { Label = (index + 1).ToString(CultureInfo.CurrentCulture) };
            //    this.wrapPanel.Children.Add(button);
            //}

            // Bind listner to scrollviwer scroll position change, and check scroll viewer position
            this.UpdatePagingButtonState();
            scrollViewer.ScrollChanged += (o, e) => this.UpdatePagingButtonState();

            _hardwareController = new HardwareController(6,4,"COM4", "COM3");
            _hardwareController.initialize(true);

            printIsDone();

            AddPredefinedTexts();

            var bc = new BrushConverter();
            lblPrint.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FF4BEF55");
            lblPrint.Content = "Please choose a preset to print or customize using 'Keyboard'";
            lblPrint.Visibility = System.Windows.Visibility.Visible;

        }


        private void AddPredefinedTexts()
        {
               //Label = "I ♥ TUM", Content = "" };
                //this.wrapPanel.Children.Add(buttonPicture);
                //buttonPicture = new KinectTileButton { Label = "I ♥ UIST", Content = "" };


                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(@"./../Images/homer.jpg", UriKind.Relative);
                image.DecodePixelWidth = 140;
                image.EndInit();
                PrintObject myPrintObject = new PrintObject();
                myPrintObject.Txt = "[HOMER]";
                myPrintObject.generatePrintArray();
                KinectTileButton homerButton = new KinectTileButton { Background = new System.Windows.Media.ImageBrush(image), Content = "", Width = 140, Height = 140 };
                homerButton.Tag = myPrintObject;
                this.wrapPanel.Children.Add(homerButton);

                BitmapImage tumsmileimage = new BitmapImage();
                tumsmileimage.BeginInit();
                tumsmileimage.UriSource = new Uri(@"./../Images/tumsmile.jpg", UriKind.Relative);
                tumsmileimage.DecodePixelWidth = 140;
                tumsmileimage.EndInit();
                PrintObject tumSmilePrintObject = new PrintObject();
                tumSmilePrintObject.Txt = "TUM[SMILEY]";
                tumSmilePrintObject.generatePrintArray();
                KinectTileButton tumSmileButton = new KinectTileButton { Background = new System.Windows.Media.ImageBrush(tumsmileimage), Content = "", Width = 140, Height = 140 };
                tumSmileButton.Tag = tumSmilePrintObject;
                this.wrapPanel.Children.Add(tumSmileButton);

                BitmapImage uistheartimage = new BitmapImage();
                uistheartimage.BeginInit();
                uistheartimage.UriSource = new Uri(@"./../Images/uistheart.jpg", UriKind.Relative);
                uistheartimage.DecodePixelWidth = 140;
                uistheartimage.EndInit();
                PrintObject uistheartPrintObject = new PrintObject();
                uistheartPrintObject.Txt = "UIST[HEART]";
                uistheartPrintObject.generatePrintArray();
                KinectTileButton uistHeartButton = new KinectTileButton { Background = new System.Windows.Media.ImageBrush(uistheartimage), Content = "", Width = 140, Height = 140 };
                uistHeartButton.Tag = uistheartPrintObject;
                this.wrapPanel.Children.Add(uistHeartButton);
       
                //this.wrapPanel.Children.Add(generateAppreanceButton("I ♥ TUM"));

        }

        
        private KinectTileButton generateAppreanceButton(string TXT)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                generateImage(TXT).Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                var buttonPicture = new KinectTileButton { Background = new System.Windows.Media.ImageBrush(bitmapImage), Content = "", Width = 140, Height = 140 };
                PrintObject myPrintObject = new PrintObject();
                myPrintObject.Txt = TXT;
                if (myPrintObject.generatePrintArray())
                {
                    lblPrint.Visibility = System.Windows.Visibility.Hidden;
                    buttonPicture.Tag = myPrintObject;
                }
                else
                {
                    var bc = new BrushConverter();
                    lblPrint.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF5CDAB");
                    lblPrint.Content = "Error while generating print array!! Possible reasons: Too many letters !";
                    lblPrint.Visibility = System.Windows.Visibility.Visible;

                    buttonPicture = null;
                }
                return buttonPicture;
            }
        }


        /// <summary>
        /// CLR Property Wrappers for PageLeftEnabledProperty
        /// </summary>
        public bool PageLeftEnabled
        {
            get
            {
                return (bool)GetValue(PageLeftEnabledProperty);
            }

            set
            {
                this.SetValue(PageLeftEnabledProperty, value);
            }
        }

        /// <summary>
        /// CLR Property Wrappers for PageRightEnabledProperty
        /// </summary>
        public bool PageRightEnabled
        {
            get
            {
                return (bool)GetValue(PageRightEnabledProperty);
            }

            set
            {
                this.SetValue(PageRightEnabledProperty, value);
            }
        }

        /// <summary>
        /// Called when the KinectSensorChooser gets a new sensor
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event arguments</param>
        private static void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();

                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
        }

        /// <summary>
        /// Handle a button click from the wrap panel.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void KinectTileButtonClick(object sender, RoutedEventArgs e)
        {
            // Print
            var button = (KinectTileButton)e.OriginalSource;
            //var selectionDisplay = new SelectionDisplay(button.Label as string);
            if (button.Content.ToString() == "Keyboard")
            {
                this.sensorChooser.Stop();
                KeypadWindow keyw = new KeypadWindow();

                // whenever the keyboard windows is closed
                if (keyw.ShowDialog().Value)
                {
                    this.sensorChooser.Start(); // gets back the KInect
                    //var buttonPicture = new KinectTileButton { Label = keyw.textBox1.Text, Content = "" };
                    //this.wrapPanel.Children.Add(buttonPicture);
                    KinectTileButton appButton = generateAppreanceButton(keyw.textBox1.Text);
                    if (appButton != null)
                    {
                        this.wrapPanel.Children.Add(appButton);
                    }
                }
            }
            else if (button.Name.ToString() == "kinectTileButton2")
            {
                giveMeShirtButtonClick();
            }
            else
            {
                // change the texts or symbols into pixels
                waitForPrint();
                PrintObject po = (PrintObject)button.Tag;
                //global::System.Windows.MessageBox.Show("Print will start! " + po.Txt);
                bool generatingOutcome = po.generatePrintArray();
                if (generatingOutcome == true)
                {
                    po.visualizePrintArray();
                    lblPrint.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    Console.Write("Error while generating print array");
                    
                }
                if (_hardwareController != null)
                {
                    _hardwareController.print(po.PrintArray,po.lastVerticalLine);
                }
                printIsDone();
                //global::System.Windows.MessageBox.Show("Print finish!");
              
            }
           // this.kinectRegionGrid.Children.Add(selectionDisplay);
            e.Handled = true;
        }


        private void waitForPrint()
        {
            //lblPrint.Visibility = System.Windows.Visibility.Visible;
        }

        private void printIsDone()
        {
            lblPrint.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + PixelScrollByAmount);
        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - PixelScrollByAmount);
        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            this.PageLeftEnabled = scrollViewer.HorizontalOffset > ScrollErrorMargin;
            this.PageRightEnabled = scrollViewer.HorizontalOffset < scrollViewer.ScrollableWidth - ScrollErrorMargin;
        }

        private Bitmap generateImage(string text)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;
            
            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", 40, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(text, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(text, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new System.Drawing.Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(System.Drawing.Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(text, objFont, new SolidBrush(System.Drawing.Color.FromArgb(102, 102, 102)), 0, 0);
            objGraphics.Flush();
         //   string filepath = "c:\\images" + "\\" + System.IO.Path.GetRandomFileName() + ".bmp";
           // objBmpImage.Save(filepath);
        
            return objBmpImage;
        }

        private void kinectTileButton1_Click(object sender, RoutedEventArgs e)
        {
        }

        private void resetShirtCarrierButtonClick(object sender, RoutedEventArgs e)
        {
            _hardwareController.stepBackShirtCarrier();
            _hardwareController.goToInitialPositionShirtCarrier();
        }

        private void stepBackNozzleCarrierButtonClick(object sender, RoutedEventArgs e)
        {
            _hardwareController.stepBackNozzleCarrier();
        }

        private void resetNozzleCarrierButtonClick(object sender, RoutedEventArgs e)
        {
            
            _hardwareController.goToInitialPositionNozzleCarrier();
        }

        private void giveMeShirtButtonClick()
        {
            //ConsoleSite console = new ConsoleSite();
            _hardwareController.stepBackShirtCarrier();
            
        }
    }
}
