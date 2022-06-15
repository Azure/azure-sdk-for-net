// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using Azure.Data.Tables.Queryable;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The <see cref="TableOdataFilter"/> class is used to help construct valid OData filter
    /// expressions, like the kind used by <see cref="TableClient.Query{T}(string,System.Nullable{int},System.Collections.Generic.IEnumerable{string},System.Threading.CancellationToken)"/>,
    /// <see cref="TableClient.QueryAsync{T}(string,System.Nullable{int},System.Collections.Generic.IEnumerable{string},System.Threading.CancellationToken)"/>,
    /// <see cref="TableServiceClient.Query(string,System.Nullable{int},System.Threading.CancellationToken)"/>, and
    /// <see cref="TableServiceClient.QueryAsync(string,System.Nullable{int},System.Threading.CancellationToken)"/>,
    /// by automatically replacing, quoting, and escaping interpolated parameters.
    /// For more information, see <see href="https://docs.microsoft.com/rest/api/storageservices/querying-tables-and-entities#constructing-filter-strings">Constructing Filter Strings</see>.
    /// </summary>
    internal static class TableOdataFilter
    {
        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <returns>A valid OData filter expression.</returns>
        public static string Create(FormattableString filter)
        {
            if (filter == null) { return null; }

            string[] args = new string[filter.ArgumentCount];
            for (int i = 0; i < filter.ArgumentCount; i++)
            {
                args[i] = filter.GetArgument(i) switch
                {
                    // Null
                    null => "null",

                    // Boolean
                    bool x => x.ToString(CultureInfo.InvariantCulture).ToLowerInvariant(),

                    // Numeric
                    sbyte x => x.ToString(CultureInfo.InvariantCulture),
                    byte x => x.ToString(CultureInfo.InvariantCulture),
                    short x => x.ToString(CultureInfo.InvariantCulture),
                    ushort x => x.ToString(CultureInfo.InvariantCulture),
                    int x => x.ToString(CultureInfo.InvariantCulture),
                    uint x => x.ToString(CultureInfo.InvariantCulture),
                    decimal x => x.ToString(CultureInfo.InvariantCulture),
                    float x => x.ToString(CultureInfo.InvariantCulture),
                    double x => x.ToString(CultureInfo.InvariantCulture),

                    // Int64
                    long x => x.ToString(CultureInfo.InvariantCulture) + "L",
                    ulong x => x.ToString(CultureInfo.InvariantCulture) + "L",

                    // Guid
                    Guid x => $"{XmlConstants.LiteralPrefixGuid}'{x.ToString()}'",

                    // binary
                    byte[] x => $"X'{string.Join(string.Empty, x.Select(b => b.ToString("X2", CultureInfo.InvariantCulture)))}'",
                    BinaryData x => $"X'{string.Join(string.Empty, x.ToArray().Select(b => b.ToString("X2", CultureInfo.InvariantCulture)))}'",

                    // Dates as 8601 with a time zone
                    DateTimeOffset x => $"{XmlConstants.LiteralPrefixDateTime}'{XmlConvert.ToString(x.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind)}'",
                    DateTime x => $"{XmlConstants.LiteralPrefixDateTime}'{XmlConvert.ToString(x.ToUniversalTime(), XmlDateTimeSerializationMode.RoundtripKind)}'",

                    // Text
                    string x => $"'{EscapeStringValue(x)}'",
                    char x => $"'{EscapeStringValue(x)}'",
                    StringBuilder x => $"'{EscapeStringValue(x)}'",

                    // Everything else
                    object x => throw new ArgumentException(
                        $"Unable to convert argument {i} from type {x.GetType()} to an OData literal.")
                };
            }

            return string.Format(CultureInfo.InvariantCulture, filter.Format, args);
        }

        internal static string EscapeStringValue(string s) => s.Replace("'", "''");
        internal static StringBuilder EscapeStringValue(StringBuilder s) => s.Replace("'", "''");

        internal static string EscapeStringValue(char s) =>
            s switch
            {
                _ when s == '\'' => "''",
                _ => s.ToString()
            };
    }
}
