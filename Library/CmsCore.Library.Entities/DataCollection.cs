using System.Collections;
using System.Collections.Generic;

namespace CmsCore.Library.Entities
{
    public class DataCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly IDictionary<TKey, TValue> _innerDictionary = new Dictionary<TKey, TValue>();

        public int Count => _innerDictionary.Count;

        public bool Contains(TKey key)
        {
            return _innerDictionary.ContainsKey(key);
        }

        public void Clear()
        {
            _innerDictionary.Clear();
        }

        public void Add(TKey key, TValue value)
        {
            _innerDictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> keyValue)
        {
            _innerDictionary.Add(keyValue);
        }

        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            foreach (var item in collection)
            {
                _innerDictionary.Add(item);
            }
        }

        public TValue this[TKey key]
        {
            get => _innerDictionary[key];
            set => _innerDictionary[key] = value;
        }

        public ICollection<TKey> Keys => _innerDictionary.Keys;

        public ICollection<TValue> Values => _innerDictionary.Values;

        public IEnumerator GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }
    }
}