// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;
using Azure.Core;
using System.Globalization;
using System.IO;
using System.Text;
using System;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// The ClientConnectionFilter class is used to help construct valid OData filter
    /// parameter to be used by Send* APIs by automatically replacing, quoting, and escaping interpolated
    /// parameters.
    /// For more information, see <see href="https://aka.ms/awps/filter-syntax">Filters in Azure Web PubSub</see>.
    /// </summary>
    public static class ClientConnectionFilter
    {
        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The
        /// interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <returns>A valid OData filter expression.</returns>
        public static string Create(FormattableString filter) =>
            Create(filter, null);

        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The
        /// interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <param name="formatProvider">
        /// Format provider used to convert values to strings.
        /// <see cref="CultureInfo.InvariantCulture"/> is used as a default.
        /// </param>
        /// <returns>A valid OData filter expression.</returns>
        public static string Create(FormattableString filter, IFormatProvider formatProvider)
        {
            if (filter == null)
            { return null; }
            formatProvider ??= CultureInfo.InvariantCulture;

            string[] args = new string[filter.ArgumentCount];
            for (int i = 0; i < filter.ArgumentCount; i++)
            {
                args[i] = filter.GetArgument(i) switch
                {
                    // Null
                    null => "null",

                    // Boolean
                    bool x => x.ToString(formatProvider).ToLowerInvariant(),

                    // Numeric
                    sbyte x => x.ToString(formatProvider),
                    byte x => x.ToString(formatProvider),
                    short x => x.ToString(formatProvider),
                    ushort x => x.ToString(formatProvider),
                    int x => x.ToString(formatProvider),
                    uint x => x.ToString(formatProvider),
                    long x => x.ToString(formatProvider),
                    ulong x => x.ToString(formatProvider),

                    // Text
                    string x => Quote(x),
                    char x => Quote(x.ToString(formatProvider)),
                    StringBuilder x => Quote(x.ToString()),

                    // Everything else
                    object x => throw new ArgumentException(
                        $"Unable to convert argument {i} from type {x.GetType()} to a suppported OData filter string.")
                };
            }
            string text = string.Format(formatProvider, filter.Format, args);
            return text;
        }

        /// <summary>
        /// Quote and escape OData strings.
        /// </summary>
        /// <param name="text">The text to quote.</param>
        /// <returns>The quoted text.</returns>
        private static string Quote(string text)
        {
            if (text == null)
            { return "null"; }

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
