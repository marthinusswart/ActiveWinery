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
using ActiveWinery.ViewModels;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Views
{
    /// <summary>
    /// Interaction logic for ToolbarView.xaml
    /// </summary>
    public partial class ToolbarView : UserControl
    {
        public ToolbarView(IViewModelLocator viewModelLocator)
        {
            InitializeComponent();
            viewModelLocator.LocateViewModel(this);
        }
    }
}
