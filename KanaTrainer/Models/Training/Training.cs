using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models.Training
{
    internal class Training
    {
        public TrainingSettings Settings { get; }
        public TrainingData Data { get; }

        

        private int currentKanaIndex;
        public bool IsLastKanaCorrect { get; private set; }
        public Kana LastKana { get; private set; }
        public Kana CurrentKana { get; private set; }

        public bool IsEnded
        {
            get { return Data.IsEnded; }
        }

        public Training(TrainingSettings settings)
        {
            Settings = settings;
            Data = new TrainingData();
        }

        public void Start()
        {
            if (!IsEnded)
            {
                Data.Start();
                NextKana(true);
            }
        }
        public void End()
        {
            if (!IsEnded)
            {
                Data.End();
            }
        }

        public bool Solve(string answer)
        {
            if (GetCurrentAnswer() == answer)
            {
                NextKana(true);
                return true;
            }
            return false;
        }

        public string GetLastTask()
        {
            return GetTask(LastKana);
        }
        public string GetCurrentTask()
        {
            return GetTask(CurrentKana);
        }

        private string GetTask(Kana kana)
        {
            if (kana == null)
                return null;

            switch (Settings.TrainingType)
            {
                case TrainingType.RomajiToKana:
                    return kana.Romaji;
                case TrainingType.KanaToRomaji:
                    return kana.Character;
                default:
                    throw new TrainingTypeException();
            }
        }


        public string GetLastAnswer()
        {
            return GetAnswer(LastKana);
        }
        public string GetCurrentAnswer()
        {
            return GetAnswer(CurrentKana);
        }

        public event Action CurrentKanaChanged;

        private string GetAnswer(Kana kana)
        {
            if (kana == null)
                return null;

            switch (Settings.TrainingType)
            {
                case TrainingType.RomajiToKana:
                    return kana.Character;
                case TrainingType.KanaToRomaji:
                    return kana.Romaji;
                default:
                    throw new TrainingTypeException();
            }
        }

        public void Skip()
        {
            NextKana(false);
        }

        private void NextKana(bool isCorrect)
        {
            int index = Settings.Rand.Next(Settings.KanaSet.Count - 1);
            
            if (index == currentKanaIndex)
            {
                index++;
            }
            currentKanaIndex = index;

            IsLastKanaCorrect = isCorrect;
            LastKana = CurrentKana;
            CurrentKana = Settings.KanaSet[currentKanaIndex];

            Data.IncrementKana(isCorrect);

            CurrentKanaChanged?.Invoke();
        }
    }
}
