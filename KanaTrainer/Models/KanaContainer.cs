using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Models
{
    internal abstract class KanaContainer : Selectable
    {
        public virtual IEnumerable<Kana> GetSelectedKanas()
        {
            return Enumerable.Empty<Kana>();
        }
    }
}
