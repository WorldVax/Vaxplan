using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Common.Collections
{
    public class MultiValueDictionary<TKey, TValue> : BaseDictionary<TKey, IEnumerable<TValue>>
    {
        public override IEnumerable<TValue> this[TKey key]
        {
            get
            {
                return Target[key];
            }

            set
            {
                throw new InvalidOperationException();
            }
        }

        public void Add(TKey key, TValue item)
        {
            if (!ContainsKey(key))
            {
                Add(new KeyValuePair<TKey, IEnumerable<TValue>>(key, new List<TValue>()));
            }
            ((IList<TValue>)base[key]).Add(item);
        }
    }
}
