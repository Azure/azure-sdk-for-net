using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace Azure.AI.OpenAI.Tests
{
    internal static class Extensions
    {
#if NETFRAMEWORK
        public static TValue? GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
            => GetValueOrDefault<TKey, TValue>(dictionary, key, default(TValue)!);

        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (!dictionary.TryGetValue(key, out TValue? value))
            {
                return defaultValue;
            }

            return value;
        }
#endif

        public static TValue? GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            => GetValueOrDefault(dictionary, key, default!);

        public static TValue? GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (!dictionary.TryGetValue(key, out TValue? value))
            {
                return defaultValue;
            }

            return value;
        }

        public static TValue? GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TKey : notnull
            => ((IReadOnlyDictionary<TKey, TValue>)dictionary).GetValueOrDefault(key);

        public static TValue? GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) where TKey : notnull
            => ((IReadOnlyDictionary<TKey, TValue>)dictionary).GetValueOrDefault(key, defaultValue);

        public static string? GetFirstValueOrDefault(this PipelineResponseHeaders headers, string key)
        {
            IEnumerable<string>? values = null;
            if (key != null)
            {
                headers?.TryGetValues(key, out values);
            }

            return values?.FirstOrDefault(v => v != null)
                ?? null;
        }
    }
}
