// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Collections.Generic
{
    /// <summary>
    /// Temporary helper extensions for dictionary conversions during migration.
    /// </summary>
    internal static partial class DictionaryExtensions
    {
        /// <summary>
        /// Converts a Dictionary&lt;string, object&gt; to Dictionary&lt;string, BinaryData&gt;.
        /// </summary>
        /// <param name="source">The source dictionary to convert.</param>
        /// <returns>A new dictionary with BinaryData values, or null if source is null.</returns>
        public static Dictionary<string, BinaryData> ToBinaryDataDictionary(this Dictionary<string, object> source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Dictionary<string, BinaryData>(source.Count);
            foreach (var kvp in source)
            {
                result[kvp.Key] = kvp.Value != null
                    ? BinaryData.FromObjectAsJson(kvp.Value)
                    : null;
            }

            return result;
        }

        /// <summary>
        /// Converts an IDictionary&lt;string, object&gt; to Dictionary&lt;string, BinaryData&gt;.
        /// </summary>
        /// <param name="source">The source dictionary to convert.</param>
        /// <returns>A new dictionary with BinaryData values, or null if source is null.</returns>
        public static Dictionary<string, BinaryData> ToBinaryDataDictionary(this IDictionary<string, object> source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Dictionary<string, BinaryData>(source.Count);
            foreach (var kvp in source)
            {
                result[kvp.Key] = kvp.Value != null
                    ? BinaryData.FromObjectAsJson(kvp.Value)
                    : null;
            }

            return result;
        }

        /// <summary>
        /// Converts an IReadOnlyDictionary&lt;string, object&gt; to Dictionary&lt;string, BinaryData&gt;.
        /// </summary>
        /// <param name="source">The source dictionary to convert.</param>
        /// <returns>A new dictionary with BinaryData values, or null if source is null.</returns>
        public static Dictionary<string, BinaryData> ToBinaryDataDictionary(this IReadOnlyDictionary<string, object> source)
        {
            if (source == null)
            {
                return null;
            }

            var result = new Dictionary<string, BinaryData>();
            foreach (var kvp in source)
            {
                result[kvp.Key] = kvp.Value != null
                    ? BinaryData.FromObjectAsJson(kvp.Value)
                    : null;
            }

            return result;
        }
    }
}
