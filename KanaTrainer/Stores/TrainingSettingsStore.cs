using KanaTrainer.Models;
using KanaTrainer.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Stores
{
    internal class TrainingSettingsStore
    {
        private TrainingType _currentTrainingType;
        public TrainingType CurrentTrainingType
        {
            get { return _currentTrainingType; }
            set
            {
                _currentTrainingType = value;
                UpdateTrainingSettings();
            }
        }

        private KanaSystem _currentKanaSystem;
        public KanaSystem CurrentKanaSystem
        {
            get { return _currentKanaSystem; }
            set
            {
                if (_currentKanaSystem != null)
                {
                    _currentKanaSystem.IsSelectedChanged -= UpdateTrainingSettings;
                }
                
                _currentKanaSystem = value;

                // Update Training Settings (primarly KanaSet) each time,
                // when some Kana inside current Kana System changes.
                _currentKanaSystem.IsSelectedChanged += UpdateTrainingSettings;

                UpdateTrainingSettings();
            }
        }

        private TrainingSettings _currentTrainingSettings;
        public TrainingSettings CurrentTrainingSettings
        {
            get { return _currentTrainingSettings; }
            private set
            {
                _currentTrainingSettings = value;
                CurrentTrainingSettingsChanged?.Invoke();
            }
        }
        public event Action CurrentTrainingSettingsChanged;

        public TrainingSettingsStore(KanaSystem currentKanaSystem, TrainingType currentTrainingType = TrainingType.KanaToRomaji)
        {
            CurrentKanaSystem = currentKanaSystem;
            _currentTrainingType = currentTrainingType;

            UpdateTrainingSettings();
        }

        public void UpdateTrainingSettings()
        {
            CurrentTrainingSettings = CreateTrainingSettings();
        }
        private TrainingSettings CreateTrainingSettings()
        {
                return new TrainingSettings(
                CurrentKanaSystem.GetSelectedKanas().ToList(),
                CurrentTrainingType);
        }
    }
}
