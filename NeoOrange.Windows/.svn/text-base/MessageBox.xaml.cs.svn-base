using System;
using System.Collections.Generic;
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
using NeoOrange.Controls;

namespace NeoOrange.Windows
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : UserControl
    {
        private MessageBoxButtons _defaultButton;
        private Button _defaultButtonInstance;

        public Action<DialogResult> Selection { get; set; }

        public MessageBox()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Clear();

            Loaded += (s, e) =>_defaultButtonInstance.Focus();
        }

        public static void ShowMessage(ModalCanvas modalCanvas, Action<DialogResult> action, string title, string message, 
            MessageBoxButtons buttons, MessageBoxButtons defaultButton)
        {
            var messageBox = new MessageBox();
            messageBox.ShowMessageInternal(modalCanvas, action,  title,  message,  buttons, defaultButton);
        }

        private void ShowMessageInternal(ModalCanvas modalCanvas, Action<DialogResult> action, string title, string message, 
            MessageBoxButtons buttons, MessageBoxButtons defaultButton)
        {
         
            InitializeButtons(buttons);
            InitializeDialog(title, message, action);

            _defaultButton = defaultButton;
            _defaultButtonInstance = GetDefaultButton(_defaultButton);

            CenterDialog(this, modalCanvas);

            modalCanvas.ShowDialog(this, action);
        }

        private void CenterDialog(UserControl dialog, ModalCanvas canvas)
        {
            var posX = (GetWidth(canvas) / 2) - (dialog.Width / 2);
            var posY = (GetHeight(canvas) / 2) - (dialog.Height / 2) - 25;
            
            dialog.SetValue(Canvas.LeftProperty, posX);
            dialog.SetValue(Canvas.TopProperty, posY);
        }

        private double GetHeight(FrameworkElement element)
        {
            if (!element.Height.Equals(double.NaN))
            {
                return element.ActualHeight;
            }
            else
            {
                return GetHeight((FrameworkElement)element.Parent);
            }
        }

        private double GetWidth(FrameworkElement element)
        {
            if (!element.Width.Equals(double.NaN))
            {
                return element.ActualWidth;
            }
            else
            {
                return GetWidth((FrameworkElement)element.Parent);
            }
        }

        private void InitializeDialog(string title, string message, Action<DialogResult> action)
        {
            Title.Text = title;
            Message.Text = message;
            Selection = action;
        }

        private void InitializeButtons(MessageBoxButtons buttons)
        {
            if ((buttons & MessageBoxButtons.OK) != MessageBoxButtons.OK)
            {
                OkButton.Visibility = System.Windows.Visibility.Collapsed;
            }
            if ((buttons & MessageBoxButtons.Cancel) != MessageBoxButtons.Cancel)
            {
                CancelButton.Visibility = System.Windows.Visibility.Collapsed;
            }
            if ((buttons & MessageBoxButtons.Yes) != MessageBoxButtons.Yes)
            {
                YesButton.Visibility = System.Windows.Visibility.Collapsed;
            }
            if ((buttons & MessageBoxButtons.No) != MessageBoxButtons.No)
            {
                NoButton.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private Button GetDefaultButton(MessageBoxButtons button)
        {
            switch (_defaultButton)
            {
                case MessageBoxButtons.OK:
                    return OkButton;
                case MessageBoxButtons.Cancel:
                    return CancelButton;
                case MessageBoxButtons.Yes:
                    return YesButton;
                case MessageBoxButtons.No:
                    return NoButton;
            }

            return null;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Selection(DialogResult.OK);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Selection(DialogResult.Cancel);
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Selection(DialogResult.Yes);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Selection(DialogResult.No);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);

            if (e.Key == Key.Enter)
            {
                switch (_defaultButton)
                {
                    case MessageBoxButtons.OK:
                        Selection(DialogResult.OK);
                        break;
                    case MessageBoxButtons.Cancel:
                        Selection(DialogResult.Cancel);
                        break;
                    case MessageBoxButtons.Yes:
                        Selection(DialogResult.Yes);
                        break;
                    case MessageBoxButtons.No:
                        Selection(DialogResult.No);
                        break;
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Selection(DialogResult.Cancel);
        }
        
    }
}
