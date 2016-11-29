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
    public  class BaseDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IDictionary<TKey, TValue> target = new Dictionary<TKey, TValue>();
        
        public  virtual TValue this[TKey key]
        {
            get
            {
                return target[key];
            }

            set
            {
                target[key] = value;
            }
        }

        public  virtual int Count
        {
            get
            {
                return target.Count;
            }
        }

        public  virtual bool IsReadOnly
        {
            get
            {
                return target.IsReadOnly;
            }
        }

        public  virtual ICollection<TKey> Keys
        {
            get
            {
                return target.Keys;
            }
        }

        public  virtual ICollection<TValue> Values
        {
            get
            {
                return target.Values;
            }
        }

        public  virtual void Add(KeyValuePair<TKey, TValue> item)
        {
            target.Add(item);
        }

        public  virtual void Add(TKey key, TValue value)
        {
            target.Add(key, value);
        }

        public  virtual void Clear()
        {
            target.Clear();
        }

        public  virtual bool Contains(KeyValuePair<TKey, TValue> item)
        {
          return  target.Contains(item);
        }

        public  virtual bool ContainsKey(TKey key)
        {
            return target.ContainsKey(key);
        }

        public  virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            target.CopyTo(array, arrayIndex);
        }

        public  virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return target.GetEnumerator();
        }

        public  virtual bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return target.Remove(item);
        }

        public  virtual bool Remove(TKey key)
        {
            return target.Remove(key);
        }

        public  virtual bool TryGetValue(TKey key, out TValue value)
        {
            return target.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return target.GetEnumerator();
        }
    }
}
