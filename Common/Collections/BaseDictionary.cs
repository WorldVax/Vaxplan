using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxplan.Common.Collections
{
    /// <summary>
    /// An IDictionary that can be extended.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BaseDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected readonly IDictionary<TKey, TValue> Target = new Dictionary<TKey, TValue>();

        public virtual TValue this[TKey key]
        {
            get
            {
                return Target[key];
            }

            set
            {
                Target[key] = value;
            }
        }

        public virtual int Count => Target.Count;

        public virtual bool IsReadOnly => Target.IsReadOnly;

        public virtual ICollection<TKey> Keys => Target.Keys;

        public virtual ICollection<TValue> Values => Target.Values;

        public virtual void Add(KeyValuePair<TKey, TValue> item)
        {
            Target.Add(item);
        }

        public virtual void Add(TKey key, TValue value)
        {
            Target.Add(key, value);
        }

        public virtual void Clear()
        {
            Target.Clear();
        }

        public virtual bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Target.Contains(item);
        }

        public virtual bool ContainsKey(TKey key)
        {
            return Target.ContainsKey(key);
        }

        public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Target.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Target.GetEnumerator();
        }

        public virtual bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Target.Remove(item);
        }

        public virtual bool Remove(TKey key)
        {
            return Target.Remove(key);
        }

        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            return Target.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Target.GetEnumerator();
        }
    }
}
