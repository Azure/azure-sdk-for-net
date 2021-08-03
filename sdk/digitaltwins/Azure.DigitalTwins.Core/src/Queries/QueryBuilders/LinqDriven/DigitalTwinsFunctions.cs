// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// DigitalTwins Query Language <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions">Functions</see>.
    /// </summary>
    public static class DigitalTwinsFunctions
    {
        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as defined.</param>
        /// <returns>True if the specified property is defined within the scope of the query, false if otherwise.</returns>
        public static bool IsDefined(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_number">IS_NUMBER</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as a number.</param>
        /// <returns>True if the specified property is a number within the scope of the query, false if otherwise.</returns>
        public static bool IsNumber(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_primitive">IS_PRIMITIVE</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as primitive.</param>
        /// <returns>True if the specified property is primitive within the scope of the query, false if otherwise.</returns>
        public static bool IsPrimitive(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_bool">IS_BOOL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as boolean.</param>
        /// <returns>True if the specified property is a boolean within the scope of the query, false if otherwise.</returns>
        public static bool IsBool(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_string">IS_STRING</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as a string.</param>
        /// <returns>True if the specified property is a string within the scope of the query, false if otherwise.</returns>
        public static bool IsString(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_object">IS_OBJECT</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as an object.</param>
        /// <returns>True if the specified property is an object within the scope of the query, false if otherwise.</returns>
        public static bool IsObject(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="value">The property that the query is looking for as null.</param>
        /// <returns>True if the specified property is null within the scope of the query, false if otherwise.</returns>
        public static bool IsNull(object value) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model">Model Id to check for.</param>
        /// <param name="exact">Whether or not an exact match is required.</param>
        /// <returns>True if the twin is of the specified model, false if otherwise.</returns>
        public static bool IsOfModel(string model, bool exact) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model">Model Id to check for.</param>
        /// <returns>True if the twin is of the specified model or a model inheriting from it, false if otherwise.</returns>
        public static bool IsOfModel(string model) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#startswith">STARTSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="field">String to check the beginning of.</param>
        /// <param name="prefix">String representing the beginning to check for.</param>
        /// <returns>True if the prefix is found within the specified field, false if otherwise.</returns>
        public static bool StartsWith(string field, string prefix) => throw new NotImplementedException();

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-functions#endswith">ENDSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="field">String to check the beginning of.</param>
        /// <param name="suffix">String representing the beginning to check for.</param>
        /// <returns>True if the suffix is found within the specified field, false if otherwise.</returns>
        public static bool EndsWith(string field, string suffix) => throw new NotImplementedException();

        internal static string Convert(object value, IFormatProvider formatProvider)
        {
            return value switch
            {
                null => "null",
                bool x => x.ToString(formatProvider).ToLowerInvariant(),
                int x => x.ToString(formatProvider),
                double x => x.ToString(formatProvider),
                string x => Quote(x),
                System.Collections.IEnumerable x =>
                    $"[{string.Join(", ", x.OfType<object>().Select(s => Convert(s, formatProvider)))}]",
                _ => throw new ArgumentException($"Unable to convert {value} to query literal")
            };
        }

        private static string Quote(string text)
        {
            if (text == null)
            {
                return "null";
            }

            // Optimistically allocate an extra 5% for escapes
            StringBuilder builder = new StringBuilder(2 + (int)(text.Length * 1.05));
            builder.Append('\'');
            foreach (char ch in text)
            {
                builder.Append(ch);
                if (ch == '\'')
                {
                    builder.Append(ch);
                }
            }
            builder.Append('\'');
            return builder.ToString();
        }
    }
}
