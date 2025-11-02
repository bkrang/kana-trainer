using KanaTrainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Stores
{
    internal class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
