using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ActiveWinery.ViewModels;
using ActiveWinery.Views;
using Microsoft.Practices.Unity;
using NeoOrange.Infrastructure.Services;

namespace ActiveWinery.Services
{
    public class ViewModelLocator : IViewModelLocator
    {
        #region Fields

        private Dictionary<string, Type> _availableViewModels = new Dictionary<string, Type>();
        private IUnityContainer _container;

        #endregion

        #region Constructors

        public ViewModelLocator(IUnityContainer container)
        {
            _container = container;
        }

        #endregion

        #region Methods

        private Type GetTypeFromAssembly(Assembly assembly, string typeName, bool checkReferencedAssemblies)
        {
            var types = assembly.GetExportedTypes();

            foreach (var type in types)
            {
                if (type.Name.Equals(typeName))
                {
                    return type;
                }
            }

            if (checkReferencedAssemblies)
            {
                // Go through all the assemblies now
                var assemblies = assembly.GetReferencedAssemblies();

                foreach (var refAssemblyName in assemblies)
                {
                    var refAssembly = Assembly.Load(refAssemblyName);
                    var type = GetTypeFromAssembly(refAssembly, typeName, false);

                    if (type != null)
                    {
                        return type;
                    }
                }
            }

            return null;
        }

        private object GetViewModel(object view)
        {
            string typeName = view.GetType().Name;
            string viewModelName = string.Format("{0}Model", typeName);

            if (_availableViewModels.ContainsKey(viewModelName))
            {
                Type viewModelType = _availableViewModels[viewModelName];
                return _container.Resolve(viewModelType);
            }
            else
            {
                Type viewModelType = GetTypeFromAssembly(Assembly.GetCallingAssembly(), viewModelName, true);
                _availableViewModels.Add(viewModelName, viewModelType);
                return _container.Resolve(viewModelType);
            }
        }

        public void LocateViewModel(object view)
        {
            var binder = _container.Resolve<IBinder>();
            var viewModel = GetViewModel(view);

            binder.Bind(view, viewModel);
        }

        #endregion
    }
}
