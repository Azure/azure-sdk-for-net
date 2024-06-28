using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (!dictionary.TryGetValue(key, out TValue? value))
            {
                value = valueFactory(key);
                dictionary[key] = value;
            }

            return value!;
        }

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
        
        public static ValueTask<T> FirstOrDefaultAsync<T>(this IAsyncEnumerable<T> enumerable)
            => FirstOrDefaultAsync<T>(enumerable, _ => true);

        public static async ValueTask<T> FirstOrDefaultAsync<T>(this IAsyncEnumerable<T> enumerable, Predicate<T> predicate)
        {
            await foreach (T item in enumerable)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default!;
        }
    }
}
