using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Common.Collections
{
    /// <summary>
    /// An IDictionary that only gets the value the first time it is referenced.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class LazyDictionary<TKey, TValue> : BaseDictionary<TKey, TValue>
    {
        private Func<TKey, TValue> _valueFactory;
        public LazyDictionary(Func<TKey, TValue> valueFactory)
        {
            _valueFactory = valueFactory;
        }

        public override TValue this[TKey key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    var value = _valueFactory(key);
                    base[key] = value;
                }
                return base[key];
            }

            set
            {
                base[key] = value;
            }
        }
    }
}
