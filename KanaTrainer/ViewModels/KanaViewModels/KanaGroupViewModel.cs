using KanaTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.ViewModels.KanaViewModels
{
    internal class KanaGroupViewModel : ViewModelBase
    {
        private readonly KanaGroup _kanaGroup;

        public string Name
        {
            get {  return _kanaGroup.Name; }
        }
        public bool IsSelected
        {
            get { return _kanaGroup.IsSelected; }
            set
            {
                if (value)
                    _kanaGroup.Select();
                else
                    _kanaGroup.Deselect();

                OnPropertyChanged();
            }
        }

        public ObservableCollection<KanaViewModel> Group { get; }

        public KanaGroupViewModel DakutenGroup { get; }
        public KanaGroupViewModel HandakutenGroup { get; }

        public KanaGroupViewModel(KanaGroup kanaGroup)
        {
            _kanaGroup = kanaGroup;
            Group = new ObservableCollection<KanaViewModel>(
                _kanaGroup.Group.Select(k => new KanaViewModel(k)));
            _kanaGroup.IsSelectedChanged += OnIsSelectedChanged;

            if (kanaGroup.DakutenGroup != null)
            {
                DakutenGroup = new KanaGroupViewModel(_kanaGroup.DakutenGroup);
            }

            if (kanaGroup.HandakutenGroup != null)
            {
                HandakutenGroup = new KanaGroupViewModel(_kanaGroup.HandakutenGroup);
            }
        }

        public override void Dispose()
        {
            _kanaGroup.IsSelectedChanged -= OnIsSelectedChanged;

            base.Dispose();
        }

        private void OnIsSelectedChanged()
        {
            OnPropertyChanged(nameof(IsSelected));
        }
    }
}
