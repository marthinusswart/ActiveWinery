using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeoOrange.Controls
{
   public class ModalCanvas : Canvas
    {
       #region Fields

       private Action<DialogResult> _action;
       private Action<DialogResult> _callerAction;
       private UIElement _dialog;
       private bool _dragging = false;
       private Point _start;
       private Vector _windowPos;

       #endregion

       #region Constructors

       public ModalCanvas()
       {
           if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
           {
               ClipToBounds = true;
               Background = new SolidColorBrush() { Color = Brushes.Black.Color, Opacity = 0.1 };
               SetZIndex(this, 99);
           }
       }

       #endregion

       #region Methods

       private void DialogClosed(DialogResult dialogResult)
       {
           Children.Remove(_dialog);
           EnableSiblings();
           Visibility = System.Windows.Visibility.Collapsed;
           _callerAction(dialogResult);
       }

       private void DisableSiblings()
       {
           var parent = (Panel) VisualTreeHelper.GetParent(this);

           foreach (UIElement child in parent.Children)
           {
               if (!child.Equals(this))
               {
                   child.IsEnabled = false;
               }
           }
       }

       private void EnableSiblings()
       {
           var parent = (Panel)VisualTreeHelper.GetParent(this);

           foreach (UIElement child in parent.Children)
           {
               if (!child.Equals(this))
               {
                   child.IsEnabled = true;
               }
           }
       }

       protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
       {
           base.OnMouseLeftButtonDown(e);

           if (e.Source.Equals(_dialog))
           {
               var point = e.GetPosition(_dialog);
               _start = point;
               _windowPos = VisualTreeHelper.GetOffset(_dialog);

               _dragging = true;
           }
       }

       protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
       {
           base.OnMouseLeftButtonUp(e);
           _dragging = false;
       }

       protected override void OnMouseMove(MouseEventArgs e)
       {
           base.OnMouseMove(e);
           PositionDialog(e);
       }

       private void PositionDialog(MouseEventArgs e)
       {
           if ((_dragging) && (e.LeftButton == MouseButtonState.Pressed))
           {
               var point = e.GetPosition(_dialog);
               var current = point;

               double newX;
               double newY;

               if (_start.X > current.X)
               {
                   newX = _start.X - current.X;
                   newX = _windowPos.X - newX;
               }
               else
               {
                   newX = current.X - _start.X;
                   newX = _windowPos.X + newX;
               }

               if (_start.Y > current.Y)
               {
                   newY = _start.Y - current.Y;
                   newY = _windowPos.Y - newY;
               }
               else
               {
                   newY = current.Y - _start.Y;
                   newY = _windowPos.Y + newY;

               }

               _windowPos.X = newX;
               _windowPos.Y = newY;

               _dialog.SetValue(Canvas.LeftProperty, newX);
               _dialog.SetValue(Canvas.TopProperty, newY);
           }
       }

       private void RegisterAction(UIElement dialog)
       {
           // First check for view model
           if (!RegisterActionOnViewModel(dialog))
           {
               var properties = dialog.GetType().GetProperties();

               foreach (var property in properties)
               {
                   if (property.PropertyType.Equals(typeof (Action<DialogResult>)))
                   {
                       _action = DialogClosed;
                       property.SetValue(dialog, _action, null);
                       break;
                   }
               }
           }
       }

       private bool RegisterActionOnViewModel(UIElement dialog)
       {
           bool registered = false;

           var dataContextProperty = dialog.GetType().GetProperty("DataContext");
           if (dataContextProperty != null)
           {
               object dataContext = dataContextProperty.GetValue(dialog, null);
               if (dataContext != null)
               {
                   var properties = dataContext.GetType().GetProperties();

                   foreach (var property in properties)
                   {
                       if (property.PropertyType.Equals(typeof (Action<DialogResult>)))
                       {
                           _action = DialogClosed;
                           property.SetValue(dataContext, _action, null);
                           registered = true;
                           break;
                       }
                   }
               }
           }

           return registered;
       }

       public void ShowDialog(UIElement dialog, Action<DialogResult> action)
       {
           _dialog = dialog;
           _callerAction = action;
           Visibility = System.Windows.Visibility.Visible;
           DisableSiblings();
           Children.Add(dialog);
           RegisterAction(dialog);
       }

       #endregion
    }
}
