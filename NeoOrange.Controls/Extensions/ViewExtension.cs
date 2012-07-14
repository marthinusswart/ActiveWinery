using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using NeoOrange.Infrastructure;

namespace NeoOrange.Controls.Extensions
{
    public static class ViewExtension
    {
        #region Methods

        public static T FindVisualParent<T>(this IView view) where T : DependencyObject
        {
            var viewObj = (DependencyObject) view;
            DependencyObject parent = VisualTreeHelper.GetParent(viewObj);
            while (parent != null)
            {
                T typed = parent as T;
                if (typed != null)
                {
                    return typed;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        #endregion
    }
}