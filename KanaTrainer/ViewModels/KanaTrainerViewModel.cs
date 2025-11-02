using KanaTrainer.Commands;
using KanaTrainer.Models;
using KanaTrainer.Models.Training;
using KanaTrainer.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KanaTrainer.ViewModels
{
    internal class KanaTrainerViewModel : ViewModelBase
    {
        private readonly TrainingStore _trainingStore;

        private string _answerInput;

        public string AnswerInput
        {
            get { return _answerInput; }
            set
            {
                _answerInput = value;
                OnPropertyChanged();

                OnAnswer();
            }
        }

        public string Task
        {
            get { return _trainingStore.Training.GetCurrentTask(); }
        }
        public string Answer
        {
            get { return _trainingStore.Training.GetCurrentAnswer(); }
        }

        public bool IsLastKanaCorrect
        {
            get { return _trainingStore.Training.IsLastKanaCorrect; }
        }
        public string LastTask
        {
            get { return _trainingStore.Training.GetLastTask(); }
        }
        public string LastAnswer
        {
            get { return _trainingStore.Training.GetLastAnswer(); }
        }

        public int TotalKanas
        {
            get { return _trainingStore.Training.Data.TotalKanas; }
        }

        public ICommand SkipKanaCommand { get; }

        public KanaTrainerViewModel(TrainingStore trainingStore)
        {
            _trainingStore = trainingStore;
            SkipKanaCommand = new SkipKanaCommand(_trainingStore);

            _trainingStore.Training.CurrentKanaChanged += OnNextKana;
            _trainingStore.Training.Start();
        }

        
        
        public override void Dispose()
        {
            _trainingStore.Training.End();

            base.Dispose();
        }

        public void OnAnswer()
        {
            _trainingStore.Training.Solve(AnswerInput);
        }

        private void OnNextKana()
        {
            AnswerInput = "";

            OnPropertyChanged(nameof(Task));
            OnPropertyChanged(nameof(Answer));

            OnPropertyChanged(nameof(IsLastKanaCorrect));
            OnPropertyChanged(nameof(LastTask));
            OnPropertyChanged(nameof(LastAnswer));

            OnPropertyChanged(nameof(TotalKanas));
        }
    }
}
