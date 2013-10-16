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
    using System.Windows.Data;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Kinect.Toolkit.Controls;

    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class KeypadWindow
    {
        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
            "PageLeftEnabled", typeof(bool), typeof(KeypadWindow), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(KeypadWindow), new PropertyMetadata(false));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        private readonly KinectSensorChooser sensorChooser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class. 
        /// </summary>
        public KeypadWindow()
        {
            this.InitializeComponent();
           // this.WindowStyle = WindowStyle.None;
            // initialize the sensor chooser and UI
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            // Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

            // Clear out placeholder content
           // this.wrapPanel.Children.Clear();
            
            // Add in display content
            //for (var index = 0; index < 26; ++index)
            //{
            //    var button = new KinectTileButton { Label = (Convert.ToChar(index + 1 + 64)) };
            //    button.MaxHeight = 100;
            //    button.MaxWidth = 120;

            //    this.wrapPanel.Children.Add(button);
            //}


            // Bind listner to scrollviwer scroll position change, and check scroll viewer position
            this.UpdatePagingButtonState();
            //scrollViewer.ScrollChanged += (o, e) => this.UpdatePagingButtonState();
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
            var button = (KinectTileButton)e.OriginalSource;
            //var selectionDisplay = new SelectionDisplay(button.Label as string);
           
            if (Convert.ToString(button.Content) == "Backspace")
            {
                if (textBox1.Text.Length!=0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length-1,1);
            }

            else if (Convert.ToString(button.Content) == "Enter")
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                { DialogResult = false; this.Close(); }
                else
                {
                    DialogResult = true;
                    this.Close();
                }
                //this.Hide();
                //Window wd1 = new Window();
                //wd1.Show();
               // System.Windows.Controls.Label newlbl = new System.Windows.Controls.Label();
                //newlbl.Content = "Label Test";
                
                // MOHSEN SHOULD PASS THE TEXTBox1.Text to SOME FUNCTION
            }
            
            else if (Convert.ToString(button.Content) == "Delete All")
            {
                textBox1.Text = "";
            }
            else if (Convert.ToString(button.Content) == "Text + :-)")
            {
                textBox1.Text += "[SMILEY]";
            }
            else if (Convert.ToString(button.Content) == "Text + ♥")
            {
                textBox1.Text += "[HEART]";
            }
            else
                textBox1.Text += button.Content;

            
            //this.kinectRegionGrid.Children.Add(selectionDisplay);
            e.Handled = true;
        }

        /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {
            //scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + PixelScrollByAmount);
        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            //scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - PixelScrollByAmount);
        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            //this.PageLeftEnabled = scrollViewer.HorizontalOffset > ScrollErrorMargin;
            //this.PageRightEnabled = scrollViewer.HorizontalOffset < scrollViewer.ScrollableWidth - ScrollErrorMargin;
        }

        private void KinectTileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void scrollViewer_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {

        }

        private void ControlsBasicsWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton13_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void ControlsBasicsWindow_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton28_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton37_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kinectTileButton27_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void textAndSmilie(object sender, RoutedEventArgs e)
        {
            //textBox1.Text = textBox1.Text + "[Smilie]";
        }
        
    }
}
