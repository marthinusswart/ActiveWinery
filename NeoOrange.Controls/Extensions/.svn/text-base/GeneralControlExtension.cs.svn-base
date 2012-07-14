using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NeoOrange.Controls.Extensions
{
    public class GeneralControlExtension
    {
        #region Properties

        public static readonly DependencyProperty ImageProperty;
        public static readonly DependencyProperty IsDirtyProperty;

        #endregion

        #region Constructors

        static GeneralControlExtension()
        {
            //register attached dependency property
            var boolMetadata = new FrameworkPropertyMetadata(false);
            var imageMetadata = new FrameworkPropertyMetadata((ImageSource)null);

            IsDirtyProperty = DependencyProperty.RegisterAttached("IsDirty",
                                                                  typeof(Boolean),
                                                                  typeof(GeneralControlExtension), boolMetadata);
            ImageProperty = DependencyProperty.RegisterAttached("Image",
                                                                typeof(ImageSource),
                                                                typeof(GeneralControlExtension), imageMetadata);
        }

        #endregion

        #region Methods

        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(ImageProperty);
        }

        public static Boolean GetIsDirty(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(IsDirtyProperty);
        }

        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static void SetIsDirty(DependencyObject obj, Boolean value)
        {
            obj.SetValue(IsDirtyProperty, value);
        }

        #endregion
    }
}
