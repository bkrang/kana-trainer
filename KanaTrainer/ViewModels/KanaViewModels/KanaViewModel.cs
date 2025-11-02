using KanaTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.ViewModels.KanaViewModels
{
    internal class KanaViewModel : ViewModelBase
    {
        private readonly Kana _kana;
        public string Character
        {
            get {  return _kana.Character; }
        }
        public string Romaji
        {
            get { return _kana.Romaji; }
        }

        public KanaViewModel Dakuten { get; }
        public KanaViewModel Handakuten { get; }

        public bool IsSelected
        {
            get { return _kana.IsSelected; }
            set
            {
                if (value)
                    _kana.Select();
                else
                    _kana.Deselect();

                OnPropertyChanged();
            }
        }

        public KanaViewModel(Kana kana)
        {
            _kana = kana;
            _kana.IsSelectedChanged += OnIsSelectedChanged;

            if (kana.Dakuten != null)
            {
                Dakuten = new KanaViewModel(kana.Dakuten);
            }
            
            if (kana.Handakuten != null)
            {
                Handakuten = new KanaViewModel(kana.Handakuten);
            }
        }

        public override void Dispose()
        {
            _kana.IsSelectedChanged -= OnIsSelectedChanged;

            base.Dispose();
        }

        private void OnIsSelectedChanged()
        {
            OnPropertyChanged(nameof(IsSelected));
        }
    }
}
