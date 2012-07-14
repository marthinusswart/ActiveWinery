using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NeoOrange.Controls.Extensions
{
    public class ButtonExtension
    {
        #region Properties

        public static readonly DependencyProperty HasOpenWindowsProperty;

        /// <summary>
        /// An attached dependency property which provides an
        /// <see cref="ImageSource" /> for arbitrary WPF elements.
        /// </summary>
        public static readonly DependencyProperty ImageProperty;

        public static readonly DependencyProperty OpenWindowsCountProperty;

        #endregion

        #region Constructors

        static ButtonExtension()
        {
            //register attached dependency property
            var imageMetadata = new FrameworkPropertyMetadata((ImageSource)null);
            var intMetadata = new FrameworkPropertyMetadata(0);
            var boolMetadata = new FrameworkPropertyMetadata(false);
            ImageProperty = DependencyProperty.RegisterAttached("Image",
                                                                typeof(ImageSource),
                                                                typeof(ButtonExtension), imageMetadata);
            OpenWindowsCountProperty = DependencyProperty.RegisterAttached("OpenWindowsCount",
                                                                           typeof(Int32),
                                                                           typeof(ButtonExtension), intMetadata);
            HasOpenWindowsProperty = DependencyProperty.RegisterAttached("HasOpenWindows",
                                                                         typeof(Boolean),
                                                                         typeof(ButtonExtension), boolMetadata);
        }

        #endregion

        #region Methods

        public static Boolean GetHasOpenWindows(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(OpenWindowsCountProperty);
        }

        /// <summary>
        /// Gets the <see cref="ImageProperty"/> for a given
        /// <see cref="DependencyObject"/>, which provides an
        /// <see cref="ImageSource" /> for arbitrary WPF elements.
        /// </summary>
        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(ImageProperty);
        }

        public static Int32 GetOpenWindowsCount(DependencyObject obj)
        {
            return (Int32)obj.GetValue(OpenWindowsCountProperty);
        }

        public static void SetHasOpenWindows(DependencyObject obj, Boolean value)
        {
            obj.SetValue(OpenWindowsCountProperty, value);
        }

        /// <summary>
        /// Sets the attached <see cref="ImageProperty"/> for a given
        /// <see cref="DependencyObject"/>, which provides an
        /// <see cref="ImageSource" /> for arbitrary WPF elements.
        /// </summary>
        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static void SetOpenWindowsCount(DependencyObject obj, Int32 value)
        {
            obj.SetValue(OpenWindowsCountProperty, value);
        }

        #endregion
    }

}
