namespace WhenFresh.Utilities.Collections;

public static class IDictionaryExtensionMethods
{
#if NET20
        public static bool NotContainsKey<TKey, TValue>(IDictionary<TKey, TValue> obj, 
                                                        TKey key)
#else
    public static bool NotContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> obj,
                                                    TKey key)
#endif
    {
        if (null == obj)
        {
            throw new ArgumentNullException("obj");
        }

        return !obj.ContainsKey(key);
    }

    public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> obj,
                                            KeyValuePair<TKey, TValue> item)
    {
        if (null == obj)
        {
            throw new ArgumentNullException("obj");
        }

        if (obj.ContainsKey(item.Key))
        {
            return false;
        }

        obj.Add(item.Key, item.Value);
        return true;
    }
}