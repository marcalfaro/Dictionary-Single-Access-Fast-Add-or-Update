using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DictionaryFastFix2
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Tries to add the value if it doesn't exist in the dictionary, otherwise returns the existing value. The advantage is that it only accesses the dictionary once.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue? GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue? value)
            where TKey : notnull
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(dict, key, out var exists);
            if (exists)
            {
                return val;
            }

            val = value;
            return value;
        }


        /// <summary>
        /// Tries to update the dictionary value if it exists, otherwise returns false. The advantage is that it only accesses the dictionary once.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
            where TKey : notnull
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrNullRef(dict, key);

            if (Unsafe.IsNullRef(ref val))
            { return false; }

            val = value;
            return true;
        }


    }
}
