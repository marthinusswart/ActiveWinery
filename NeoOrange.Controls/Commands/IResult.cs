using System;

namespace NeoOrange.Controls.Commands
{
    public interface IResult
    {
        #region Events

        event EventHandler Completed;

        #endregion

        #region Methods

        void Execute();

        #endregion
    }
}