using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeoOrange.Infrastructure.Services
{
    public interface IWindowsManager
    {
        #region Methods

        void CloseWindow(string targetRegion);
        void MoveWindowTo(string currentRegion, string targetRegion);
        Guid OpenWindow<T>(string targetRegion, string name);
        Guid OpenWindow<T>(string targetRegion, string name, bool singleton);

        #endregion
    }
}