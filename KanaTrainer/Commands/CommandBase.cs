using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanaTrainer.Commands
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
        public virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
