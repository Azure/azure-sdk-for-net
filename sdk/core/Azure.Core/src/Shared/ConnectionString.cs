// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Core
{
    internal sealed class ConnectionString
    {
        private readonly Dictionary<string, string> _pairs;
        private readonly string _pairSeparator;
        private readonly string _keyValueSeparator;

        public static ConnectionString Parse(string connectionString, string segmentSeparator = ";", string keyValueSeparator = "=", bool allowEmptyValues = false)
        {
            Validate(connectionString, segmentSeparator, keyValueSeparator, allowEmptyValues);
            return new ConnectionString(ParseSegments(connectionString, segmentSeparator, keyValueSeparator), segmentSeparator, keyValueSeparator);
        }

        private ConnectionString(Dictionary<string, string> pairs, string pairSeparator, string keyValueSeparator)
        {
            _pairs = pairs;
            _pairSeparator = pairSeparator;
            _keyValueSeparator = keyValueSeparator;
        }

        public string GetRequired(string key) =>
            _pairs.TryGetValue(key, out var value) ? value : throw new InvalidOperationException($"Required key '{key}' is missing in connection string.");

        public string GetNonRequired(string key) =>
            _pairs.TryGetValue(key, out var value) ? value : null;

        public void Replace(string key, string value)
        {
            if (_pairs.ContainsKey(key))
            {
                _pairs[key] = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var isFirst = true;
            foreach (KeyValuePair<string, string> segment in _pairs)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    stringBuilder.Append(_pairSeparator);
                }

                stringBuilder.Append(segment.Key);
                if (segment.Value != null)
                {
                    stringBuilder.Append(_keyValueSeparator).Append(segment.Value);
                }
            }

            return stringBuilder.ToString();
        }


        private static Dictionary<string, string> ParseSegments(in string connectionString, in string segmentSeparator, in string keyValueSeparator)
        {
            var segments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var segmentStart = -1;
            var segmentEnd = 0;

            while (TryGetNextSegment(connectionString, segmentSeparator, ref segmentStart, ref segmentEnd))
            {
                var kvSeparatorIndex = connectionString.IndexOf(keyValueSeparator, segmentStart, segmentEnd - segmentStart, StringComparison.Ordinal);
                int keyStart = GetStart(connectionString, segmentStart);
                int keyLength = GetLength(connectionString, keyStart, kvSeparatorIndex);

                var key = connectionString.Substring(keyStart, keyLength);
                if (segments.ContainsKey(key))
                {
                    throw new InvalidOperationException($"Duplicated key '{key}'");
                }

                var valueStart = GetStart(connectionString, kvSeparatorIndex + keyValueSeparator.Length);
                var valueLength = GetLength(connectionString, valueStart, segmentEnd);
                segments.Add(key, connectionString.Substring(valueStart, valueLength));
            }

            return segments;

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

        private static void Validate(string connectionString, string segmentSeparator, string keyValueSeparator, bool allowEmptyValues)
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

                var kvSeparatorIndex = connectionString.IndexOf(keyValueSeparator, segmentStart, segmentEnd - segmentStart, StringComparison.Ordinal);
                if (kvSeparatorIndex == -1)
                {
                    throw new InvalidOperationException($"Connection string doesn't have value for key '{connectionString.Substring(segmentStart, segmentEnd - segmentStart)}'.");
                }

                if (segmentStart == kvSeparatorIndex)
                {
                    throw new InvalidOperationException($"Connection string has value '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' with no key.");
                }

                if (!allowEmptyValues && kvSeparatorIndex + 1 == segmentEnd)
                {
                    throw new InvalidOperationException($"Connection string has key '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' with empty value.");
                }
            }
        }
    }
}
