using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveWinery.Services
{
    public interface IBinder
    {
        #region Methods

        void Bind(object view, object viewmodel);

        #endregion
    }
}
