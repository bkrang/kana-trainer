using KanaTrainer.Models.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Stores
{
    internal class TrainingStore
    {
        private readonly TrainingSettingsStore _trainingSettingsStore;

        private Training _training;
        public Training Training
        {
            get
            {
                if (_training.IsEnded)
                {
                    UpdateTraining();
                }

                return _training;
            }
            private set
            {
                _training = value;
                TrainingChanged?.Invoke();
            }
        }
        public event Action TrainingChanged;
        public TrainingStore(TrainingSettingsStore trainingSettingsStore)
        {
            _trainingSettingsStore = trainingSettingsStore;
            UpdateTraining();

            _trainingSettingsStore.CurrentTrainingSettingsChanged += UpdateTraining;
        }
        public void UpdateTraining()
        {
            Training = CreateTraining();
        }
        private Training CreateTraining()
        {
            return new Training(_trainingSettingsStore.CurrentTrainingSettings);
        }
    }
}
