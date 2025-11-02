using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models.Training
{
    internal class TrainingData
    {
        public int TotalKanas { get; private set; }
        public int TotalWrongKanas { get; private set; }
        public DateTime StartTime {  get; private set; }
        public DateTime EndTime { get; private set; }
        public TimeSpan Length => EndTime.Subtract(StartTime);
        public bool IsEnded { get; private set; }
        
        public TrainingData()
        {
            TotalKanas = 0;
            IsEnded = false;
        }

        public void Start()
        {
            if (!IsEnded)
            {
                StartTime = DateTime.Now;
            }
        }

        public void End()
        {
            if (!IsEnded)
            {
                EndTime = DateTime.Now;

                IsEnded = true;
            }
        }

        public void IncrementKana(bool isCorrect)
        {
            if (!isCorrect)
            {
                TotalWrongKanas++;
            }
            TotalKanas++;
        }
    }
}
