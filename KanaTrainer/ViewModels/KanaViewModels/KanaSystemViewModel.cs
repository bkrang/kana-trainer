using KanaTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.ViewModels.KanaViewModels
{
    internal class KanaSystemViewModel : ViewModelBase
    {
        private readonly KanaSystem _kanaSystem;

        public string Name
        {
            get { return _kanaSystem.Name; }
        }
        public bool IsSelected
        {
            get { return _kanaSystem.IsSelected; }
            set
            {
                if (value)
                    _kanaSystem.Select();
                else
                    _kanaSystem.Deselect();

                OnPropertyChanged();
            }
        }

        public ObservableCollection<KanaGroupViewModel> System { get; }

        public KanaSystemViewModel DakutenSystem { get; }
        public KanaSystemViewModel HandakutenSystem { get; }

        public KanaSystemViewModel(KanaSystem kanaSystem)
        {
            _kanaSystem = kanaSystem;
            System = new ObservableCollection<KanaGroupViewModel>(
                _kanaSystem.System.Select(g => new KanaGroupViewModel(g)));
            _kanaSystem.IsSelectedChanged += OnIsSelectedChanged;

            if (kanaSystem.DakutenSystem != null)
            {
                DakutenSystem = new KanaSystemViewModel(kanaSystem.DakutenSystem);
            }

            if (kanaSystem.HandakutenSystem != null)
            {
                HandakutenSystem = new KanaSystemViewModel(kanaSystem.HandakutenSystem);
            }
        }

        public override void Dispose()
        {
            _kanaSystem.IsSelectedChanged -= OnIsSelectedChanged;

            base.Dispose();
        }

        private void OnIsSelectedChanged()
        {
            OnPropertyChanged(nameof(IsSelected));
        }
    }
}
