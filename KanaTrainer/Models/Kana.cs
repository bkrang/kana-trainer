using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace KanaTrainer.Models
{
    internal class Kana : KanaContainer
    {
        public string Character { get; }
        public string Romaji { get; }
        public Kana Dakuten { get; }
        public Kana Handakuten { get; }

        public Kana(string character, string romaji, Kana dakuten = null, Kana handakuten = null, bool isAlowed = true)
        {
            Character = character;
            Romaji = romaji;

            Dakuten = dakuten;
            Handakuten = handakuten;

            IsSelected = true;
        }

        public override IEnumerable<Kana> GetSelectedKanas()
        {
            return (new List<Kana>(){
                this,
                Dakuten,
                Handakuten,
            }).Where(k => k?.IsSelected ?? false);
        }
    }
}
