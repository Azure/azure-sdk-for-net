// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    internal sealed class ConnectionString
    {
        private readonly Dictionary<string, string> _pairs;
        private readonly string _pairSeparator;
        private readonly string _keywordValueSeparator;

        public static ConnectionString Parse(string connectionString, string segmentSeparator = ";", string keywordValueSeparator = "=", bool allowEmptyValues = false)
        {
            Validate(connectionString, segmentSeparator, keywordValueSeparator, allowEmptyValues);
            return new ConnectionString(ParseSegments(connectionString, segmentSeparator, keywordValueSeparator), segmentSeparator, keywordValueSeparator);
        }

        public static ConnectionString Empty(string segmentSeparator = ";", string keywordValueSeparator = "=") =>
            new ConnectionString(new Dictionary<string, string>(), segmentSeparator, keywordValueSeparator);

        private ConnectionString(Dictionary<string, string> pairs, string pairSeparator, string keywordValueSeparator)
        {
            _pairs = pairs;
            _pairSeparator = pairSeparator;
            _keywordValueSeparator = keywordValueSeparator;
        }

        public string GetRequired(string keyword) =>
            _pairs.TryGetValue(keyword, out var value) ? value : throw new InvalidOperationException($"Required keyword '{keyword}' is missing in connection string.");

        public string? GetNonRequired(string keyword) =>
            _pairs.TryGetValue(keyword, out var value) ? value : null;

        public bool TryGetSegmentValue(string keyword, out string? value) =>
            _pairs.TryGetValue(keyword, out value);

        public bool ContainsSegmentKey(string keyword) =>
            _pairs.ContainsKey(keyword);

        public void Replace(string keyword, string value)
        {
            if (_pairs.ContainsKey(keyword))
            {
                _pairs[keyword] = value;
            }
        }

        public void Add(string keyword, string value) =>
            _pairs.Add(keyword, value);

        public override string ToString()
        {
            if (_pairs.Count == 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            var isFirst = true;
            foreach (KeyValuePair<string, string> pair in _pairs)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    stringBuilder.Append(_pairSeparator);
                }

                stringBuilder.Append(pair.Key);
                if (pair.Value != null)
                {
                    stringBuilder.Append(_keywordValueSeparator).Append(pair.Value);
                }
            }

            return stringBuilder.ToString();
        }

        private static Dictionary<string, string> ParseSegments(in string connectionString, in string separator, in string keywordValueSeparator)
        {
            var pairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var segmentStart = -1;
            var segmentEnd = 0;

            while (TryGetNextSegment(connectionString, separator, ref segmentStart, ref segmentEnd))
            {
                var kvSeparatorIndex = connectionString.IndexOf(keywordValueSeparator, segmentStart, segmentEnd - segmentStart, StringComparison.Ordinal);
                int keywordStart = GetStart(connectionString, segmentStart);
                int keyLength = GetLength(connectionString, keywordStart, kvSeparatorIndex);

                var keyword = connectionString.Substring(keywordStart, keyLength);
                if (pairs.ContainsKey(keyword))
                {
                    throw new InvalidOperationException($"Duplicated keyword '{keyword}'");
                }

                var valueStart = GetStart(connectionString, kvSeparatorIndex + keywordValueSeparator.Length);
                var valueLength = GetLength(connectionString, valueStart, segmentEnd);
                pairs.Add(keyword, connectionString.Substring(valueStart, valueLength));
            }

            return pairs;

            static int GetStart(in string str, int start)
            {
                while (start < str.Length && char.IsWhiteSpace(str[start]))
                {
                    start++;
                }

                return start;
            }

            static int GetLength(in string str, in int start, int end)
            {
                while (end > start && char.IsWhiteSpace(str[end - 1]))
                {
                    end--;
                }

                return end - start;
            }
        }

        private static bool TryGetNextSegment(in string str, in string separator, ref int start, ref int end)
        {
            if (start == -1)
            {
                start = 0;
            }
            else
            {
                start = end + separator.Length;
                if (start >= str.Length)
                {
                    return false;
                }
            }

            end = str.IndexOf(separator, start, StringComparison.Ordinal);
            if (end == -1)
            {
                end = str.Length;
            }

            return true;
        }

        private static void Validate(string connectionString, string segmentSeparator, string keywordValueSeparator, bool allowEmptyValues)
        {
            var segmentStart = -1;
            var segmentEnd = 0;

            while (TryGetNextSegment(connectionString, segmentSeparator, ref segmentStart, ref segmentEnd))
            {
                if (segmentStart == segmentEnd)
                {
                    if (segmentStart == 0)
                    {
                        throw new InvalidOperationException($"Connection string starts with separator '{segmentSeparator}'.");
                    }

                    throw new InvalidOperationException($"Connection string contains two following separators '{segmentSeparator}'.");
                }

                var kvSeparatorIndex = connectionString.IndexOf(keywordValueSeparator, segmentStart, segmentEnd - segmentStart, StringComparison.Ordinal);
                if (kvSeparatorIndex == -1)
                {
                    throw new InvalidOperationException($"Connection string doesn't have value for keyword '{connectionString.Substring(segmentStart, segmentEnd - segmentStart)}'.");
                }

                if (segmentStart == kvSeparatorIndex)
                {
                    throw new InvalidOperationException($"Connection string has value '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' with no keyword.");
                }

                if (!allowEmptyValues && kvSeparatorIndex + 1 == segmentEnd)
                {
                    throw new InvalidOperationException($"Connection string has keyword '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' with empty value.");
                }
            }
        }
    }
}
