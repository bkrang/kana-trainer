using KanaTrainer.Commands;
using KanaTrainer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanaTrainer.ViewModels
{
    internal class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateTrainingSettingsCommand { get; }
        public string Test1 { get; }

        public NavigationBarViewModel(INavigationService trainingSettingsNavigationService)
        {
            NavigateTrainingSettingsCommand = new NavigateCommand(trainingSettingsNavigationService);
        }
    }
}
