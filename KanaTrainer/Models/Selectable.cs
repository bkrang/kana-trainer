using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models
{
    internal abstract class Selectable
    {
        protected bool _isSelected;

        public bool IsSelected { get; protected set; }
        public event Action IsSelectedChanged;

        public virtual void Select()
        {
            IsSelected = true;
            OnIsSelectedChanged();
        }

        public virtual void Deselect()
        {
            IsSelected = false;
            OnIsSelectedChanged();
        }

        protected virtual void OnIsSelectedChanged()
        {
            IsSelectedChanged?.Invoke();
        }
    }
}
