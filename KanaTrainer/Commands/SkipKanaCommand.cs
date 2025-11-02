using KanaTrainer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Commands
{
    internal class SkipKanaCommand : CommandBase
    {
        private TrainingStore _trainingStore;

        public SkipKanaCommand(TrainingStore trainingStore)
        {
            _trainingStore = trainingStore;
        }
        public override void Execute(object parameter)
        {
            _trainingStore.Training.Skip();
        }
    }
}
