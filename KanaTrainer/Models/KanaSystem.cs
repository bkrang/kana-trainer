using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models
{
    internal class KanaSystem : KanaContainer
    {
        public string Name { get; }
        public List<KanaGroup> System { get; }

        public KanaSystem DakutenSystem { get; }
        public KanaSystem HandakutenSystem {  get; }
        public KanaSystem(string name, List<KanaGroup> groups, bool isSubsystem = false)
        {
            Name = name;
            System = groups;

            // Needed to propagate kana's IsSelectedChanged further
            foreach (KanaGroup group in System)
            {
                group.IsSelectedChanged += OnIsSelectedChanged;
            }


            if (!isSubsystem)
            {
                DakutenSystem = new KanaSystem($"{Name} Dakutens",
                    System.Select(g => g.DakutenGroup).Where(g => g != null).ToList(), true);
                DakutenSystem.IsSelectedChanged += OnIsSelectedChanged;

                HandakutenSystem = new KanaSystem($"{Name} Handakutens",
                    System.Select(g => g.HandakutenGroup).Where(g => g != null).ToList(), true);
                HandakutenSystem.IsSelectedChanged += OnIsSelectedChanged;
            }

            UpdateIsSelected();
        }

        public override IEnumerable<Kana> GetSelectedKanas()
        {
            return System.SelectMany(g => g.GetSelectedKanas());
        }

        public override void Select()
        {
            foreach (KanaGroup group in System)
            {
                group?.Select();
            }

            DakutenSystem?.Select();
            HandakutenSystem?.Select();

            base.Select();
        }

        public override void Deselect()
        {
            foreach (KanaGroup group in System)
            {
                group?.Deselect();
            }

            DakutenSystem?.Deselect();
            HandakutenSystem?.Deselect();

            base.Deselect();
        }

        private void UpdateIsSelected()
        {
            bool _isSelected = true;
            foreach (KanaGroup group in System)
            {
                if (!group.IsSelected)
                {
                    _isSelected = false;
                    break;
                }
            }
            IsSelected = _isSelected;
        }

        protected override void OnIsSelectedChanged()
        {
            UpdateIsSelected();

            base.OnIsSelectedChanged();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
