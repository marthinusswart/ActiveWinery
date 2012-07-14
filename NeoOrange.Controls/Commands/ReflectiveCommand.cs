﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Input;

namespace NeoOrange.Controls.Commands
{
    public class ReflectiveCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Fields

        private readonly PropertyInfo _canExecute;
        private readonly MethodInfo _execute;
        private readonly object _model;

        #endregion

        #region Constructors

        public ReflectiveCommand(object model, MethodInfo execute, PropertyInfo canExecute)
        {
            _model = model;
            _execute = execute;
            _canExecute = canExecute;

            var notifier = _model as INotifyPropertyChanged;
            if(notifier != null && _canExecute != null)
            {
                notifier.PropertyChanged += (s, e) => {
                                                          if(e.PropertyName == _canExecute.Name)
                                                              CanExecuteChanged(this, EventArgs.Empty);
                };
            }
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
                return (bool)_canExecute.GetValue(_model, null);
            return true;
        }

        public void Execute(object parameter)
        {
            var returnValue = _execute.Invoke(_model, null);
            if(returnValue != null)
                HandleReturnValue(returnValue);
        }

        private static void HandleReturnValue(object returnValue)
        {
            if(returnValue is IResult)
                returnValue = new[]
                                  {
                                      returnValue as IResult
                                  };

            if(returnValue is IEnumerable<IResult>)
                new ResultEnumerator(returnValue as IEnumerable<IResult>).Enumerate();
        }

        #endregion
    }
}