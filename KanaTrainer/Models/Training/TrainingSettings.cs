using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models.Training
{
    public enum TrainingType
    {
        KanaToRomaji,
        RomajiToKana
    }
    class TrainingTypeException : Exception
    {

    }
    internal class TrainingSettings
    {
        private readonly KanaSystem _kanaSystem;
        public Random Rand { get; }
        public List<Kana> KanaSet { get; }
        public TrainingType TrainingType { get; }
        public TrainingSettings(List<Kana> kanaSet, TrainingType trainingType = TrainingType.KanaToRomaji)
        {
            KanaSet = kanaSet;
            TrainingType = trainingType;

            Rand = new Random();
        }
    }
}
