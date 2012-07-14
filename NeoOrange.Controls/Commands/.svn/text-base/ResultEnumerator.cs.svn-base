using System;
using System.Collections.Generic;
using NeoOrange.Controls.Commands;

namespace NeoOrange.Controls.Commands
{
    public class ResultEnumerator
    {
        #region Fields

        private readonly IEnumerator<IResult> _enumerator;

        #endregion

        #region Constructors

        public ResultEnumerator(IEnumerable<IResult> children)
        {
            _enumerator = children.GetEnumerator();
        }

        #endregion

        #region Methods

        private void ChildCompleted(object sender, EventArgs args)
        {
            var previous = sender as IResult;

            if(previous != null)
                previous.Completed -= ChildCompleted;

            if(!_enumerator.MoveNext())
                return;

            var next = _enumerator.Current;
            next.Completed += ChildCompleted;
            next.Execute();
        }

        public void Enumerate()
        {
            ChildCompleted(null, EventArgs.Empty);
        }

        #endregion
    }
}