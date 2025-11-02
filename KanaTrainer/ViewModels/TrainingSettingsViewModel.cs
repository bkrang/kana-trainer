using KanaTrainer.Commands;
using KanaTrainer.Models;
using KanaTrainer.Models.Training;
using KanaTrainer.Services;
using KanaTrainer.Stores;
using KanaTrainer.ViewModels.KanaViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanaTrainer.ViewModels
{
    internal class TrainingSettingsViewModel : ViewModelBase
    {
        private readonly TrainingSettingsStore _trainingSettingsStore;
        private readonly KanaSystemsStore _kanaSystemsStore;

        public IEnumerable<TrainingType> AvailableTrainingTypes
        {
            get
            {
                return Enum.GetValues(typeof(TrainingType))
                    .Cast<TrainingType>();
            }
        }
        public TrainingType CurrentTrainingType
        {
            get { return _trainingSettingsStore.CurrentTrainingType; }
            set
            {
                _trainingSettingsStore.CurrentTrainingType = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<KanaSystem> AvailableKanaSystems
        {
            get
            {
                return _kanaSystemsStore.KanaSystems;
            }
        }
        public KanaSystem SelectedKanaSystem
        {
            get
            {
                return _trainingSettingsStore.CurrentKanaSystem;
            }
            set
            {
                _trainingSettingsStore.CurrentKanaSystem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentKanaSystem));
            }
        }

        public KanaSystemViewModel CurrentKanaSystem
        {
            get
            {
                return new KanaSystemViewModel(_trainingSettingsStore.CurrentKanaSystem);
            }
        }

        public ICommand NavigateKanaTrainingCommand { get; }

        public TrainingSettingsViewModel(
            TrainingSettingsStore trainingSettingsStore,
            KanaSystemsStore kanaSystemsStore,
            INavigationService kanaTrainingNavigationService)
        {
            _kanaSystemsStore = kanaSystemsStore;
            _trainingSettingsStore = trainingSettingsStore;

            NavigateKanaTrainingCommand = new NavigateCommand(kanaTrainingNavigationService);

            //_trainingSettingsStore.CurrentKanaSystem = trainingSettingsStore.CurrentKanaSystem;
        }
    }
}
