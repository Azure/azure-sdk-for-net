using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ApiManagementManagement.Tests.Helpers
{
    public static class Extensions
    {
        public static bool DictionaryEqual<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
        {
            return first.DictionaryEqual(second, null);
        }

        public static bool DictionaryEqual<TKey, TValue>(
            this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second,
            IEqualityComparer<TValue> valueComparer)
        {
            if (first == second) return true;
            if ((first == null) || (second == null)) return false;
            if (first.Count != second.Count) return false;

            valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;

            foreach (var kvp in first)
            {
                TValue secondValue;
                if (!second.TryGetValue(kvp.Key, out secondValue)) return false;
                if (!valueComparer.Equals(kvp.Value, secondValue)) return false;
            }
            return true;
        }

        public static Stream ToStream(this XDocument doc)
        {
            var stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;
            return stream;
        }

        public static IEnumerable<T> ToIEnumerable<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static string ToLowerAndRemoveWhiteSpaces(this string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
            {
                return candidate;
            }

            return candidate.Replace(" ", string.Empty).ToLowerInvariant();
        }
    }
}
