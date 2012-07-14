using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using NeoOrange.Controls.Commands;

namespace ActiveWinery.Services
{
    public class Binder : IBinder
    {
        #region Fields

        private static readonly BooleanToVisibilityConverter _booleanToVisibilityConverter = new BooleanToVisibilityConverter();
        private static readonly Dictionary<Type, DependencyProperty> _boundProperties =
           new Dictionary<Type, DependencyProperty>
            {
                { typeof(TextBox), TextBox.TextProperty },
                { typeof(TextBlock), TextBlock.TextProperty },
                { typeof(Border), Border.VisibilityProperty }
            };

        #endregion

        #region Methods

        public void Bind(object view, object viewModel)
        {
            var element = view as FrameworkElement;
            if (element == null)
                return;

            if (viewModel == null)
                return;

            var viewType = viewModel.GetType();
            var properties = viewType.GetProperties();
            var methods = viewType.GetMethods();

            BindCommands(viewModel, element, methods, properties);
            BindProperties(element, properties);

            element.DataContext = viewModel;
        }

        private static void BindCommands(object viewModel, FrameworkElement view, IEnumerable<MethodInfo> methods, IEnumerable<PropertyInfo> properties)
        {
            foreach (var method in methods)
            {
                var foundControl = view.FindName(method.Name);
                if (foundControl == null)
                    continue;

                var foundProperty = properties
                    .FirstOrDefault(x => x.Name == "Can" + method.Name);

                var command = new ReflectiveCommand(viewModel, method, foundProperty);
                TrySetCommand(foundControl, command);
            }
        }

        private static void BindProperties(FrameworkElement view, IEnumerable<PropertyInfo> properties)
        {
            foreach (var property in properties)
            {
                var foundControl = view.FindName(property.Name) as DependencyObject;
                if (foundControl != null)
                {
                    DependencyProperty boundProperty;

                    if (!_boundProperties.TryGetValue(foundControl.GetType(), out boundProperty))
                        continue;
                    if (((FrameworkElement)foundControl).GetBindingExpression(boundProperty) != null)
                        continue;

                    var binding = new Binding(property.Name)
                                      {
                                          Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                                          //ValidatesOnDataErrors = Attribute.GetCustomAttributes(property, typeof(ValidationAttribute), true).Any()
                                      };

                    if (boundProperty == UIElement.VisibilityProperty &&
                        typeof(bool).IsAssignableFrom(property.PropertyType))
                        binding.Converter = _booleanToVisibilityConverter;
                    else if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                        binding.StringFormat = "{0:MM/dd/yyyy}";

                    BindingOperations.SetBinding(foundControl, boundProperty, binding);
                }
                else if (property.Name.StartsWith("Can"))
                {
                    string controlName = property.Name.Replace("Can", "");
                    foundControl = view.FindName(controlName) as DependencyObject;

                    if (foundControl != null)
                    {
                        if (foundControl is Button)
                        {
                            var binding = new Binding(property.Name)
                                              {
                                                  Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                                              };

                            BindingOperations.SetBinding(foundControl, Button.IsEnabledProperty, binding);
                        }
                    }
                }
            }
        }

        private static void TrySetCommand(object control, ICommand command)
        {
            if (!TrySetCommandBinding<ButtonBase>(control, ButtonBase.CommandProperty, command))
                TrySetCommandBinding<Hyperlink>(control, Hyperlink.CommandProperty, command);
        }

        private static bool TrySetCommandBinding<T>(object control, DependencyProperty property, ICommand command)
            where T : DependencyObject
        {
            var commandSource = control as T;
            if (commandSource == null)
                return false;

            BindingOperations.SetBinding(commandSource, property, new Binding
            {
                Source = command
            });

            return true;
        }

        #endregion
    }
}
