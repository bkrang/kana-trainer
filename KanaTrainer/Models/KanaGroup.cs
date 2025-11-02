using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models
{
    internal class KanaGroup : KanaContainer
    {
        public string Name { get; }
        public List<Kana> Group { get; }
        
        public KanaGroup DakutenGroup { get; }
        public KanaGroup HandakutenGroup { get; }

        public event Action KanaIsSelectedChanged;

        public KanaGroup( string groupName, List<Kana> group, string dakutenGroupName = null, string handakutenGroupName = null)
        {
            Name = groupName;
            Group = group;

            // Needed to propagate kana's IsSelectedChanged further
            foreach (Kana kana in Group.Where(k => k != null))
            {
                kana.IsSelectedChanged += OnIsSelectedChanged;
            }

            // Create Dakuten Group from Dakutents in Kanas of main Group.
            if (dakutenGroupName != null)
            {
                DakutenGroup = new KanaGroup(
                    dakutenGroupName,
                    Group.Select(k => k.Dakuten).ToList());
            }

            // Create Handakuten Group from Handakutents in Kanas of main Group.
            if (handakutenGroupName != null)
            {
                HandakutenGroup = new KanaGroup(
                    handakutenGroupName,
                    Group.Select(k => k.Handakuten).ToList());
            }

            UpdateIsSelected();
        }

        public override IEnumerable<Kana> GetSelectedKanas()
        {
            return Group.SelectMany(k => k.GetSelectedKanas());
        }

        public override void Select()
        {
            foreach (Kana kana in Group)
            {
                kana?.Select();
            }

            DakutenGroup?.Select();
            HandakutenGroup?.Select();

            base.Select();
        }

        public override void Deselect()
        {
            foreach (Kana kana in Group)
            {
                kana?.Deselect();
            }

            DakutenGroup?.Deselect();
            HandakutenGroup?.Deselect();

            base.Deselect();
        }

        private void UpdateIsSelected()
        {
            bool _isSelected = true;
            foreach (Kana kana in Group)
            {
                if (!kana.IsSelected)
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
    }
}
