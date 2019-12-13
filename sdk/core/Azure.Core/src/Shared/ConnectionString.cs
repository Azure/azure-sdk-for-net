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
        private readonly Dictionary<string, string> _segments;
        private readonly string _segmentSeparator;
        private readonly string _keyValueSeparator;

        public static ConnectionString Parse(string connectionString, string segmentSeparator = ";", string keyValueSeparator = "=", bool allowFlags = false, bool allowEmptyValues = false, bool allowWhitespaces = false)
        {
            Validate(connectionString, segmentSeparator, keyValueSeparator, allowFlags, allowEmptyValues, allowWhitespaces);
            return new ConnectionString(ParseSegments(connectionString, segmentSeparator, keyValueSeparator), segmentSeparator, keyValueSeparator);
        }

        private ConnectionString(Dictionary<string, string> pairs, string segmentSeparator, string keyValueSeparator)
        {
            _segments = pairs;
            _segmentSeparator = segmentSeparator;
            _keyValueSeparator = keyValueSeparator;
        }

        public string GetRequired(string key)
        {
            if (_segments.TryGetValue(key, out var value))
            {
                return value ?? throw new InvalidOperationException($"Required segment with the key '{key}' is declared as flag.");
            }

            throw new InvalidOperationException($"Required segment with the key '{key}' is missing in connection string.");
        }

        public bool HasFlag(string key)
        {
            if (!_segments.TryGetValue(key, out var value))
            {
                return false;
            }

            if (value != null)
            {
                throw new InvalidOperationException($"Required segment with the key '{key}' isn't a flag and has value '{value}'.");
            }

            return true;
        }

        public string GetNonRequired(string key) => _segments.TryGetValue(key, out var value) ? value : null;

        public void Replace(string key, string value)
        {
            if (_segments.ContainsKey(key))
            {
                _segments[key] = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var isFirst = true;
            foreach (KeyValuePair<string, string> segment in _segments)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    stringBuilder.Append(_segmentSeparator);
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
                int keyStart, keyLength;
                if (kvSeparatorIndex != -1)
                {
                    keyStart = GetStart(connectionString, segmentStart);
                    keyLength = GetLength(connectionString, keyStart, kvSeparatorIndex);
                }
                else
                {
                    keyStart = GetStart(connectionString, segmentStart);
                    keyLength = GetLength(connectionString, keyStart, segmentEnd);
                }

                var key = connectionString.Substring(keyStart, keyLength);
                if (segments.ContainsKey(key))
                {
                    throw new InvalidOperationException($"Duplicated key '{key}'");
                }

                if (kvSeparatorIndex != -1)
                {
                    var valueStart = GetStart(connectionString, kvSeparatorIndex + keyValueSeparator.Length);
                    var valueLength = GetLength(connectionString, valueStart, segmentEnd);
                    segments.Add(key, connectionString.Substring(valueStart, valueLength));
                }
                else
                {
                    segments.Add(key, null);
                }
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

        private static void Validate(string connectionString, string segmentSeparator, string keyValueSeparator, bool allowFlags, bool allowEmptyValues, bool allowWhitespaces)
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
                if (kvSeparatorIndex != -1)
                {
                    ValidateKeyValue(connectionString, segmentStart, segmentEnd, allowEmptyValues, allowWhitespaces, kvSeparatorIndex);
                }
                else
                {
                    if (allowFlags)
                    {
                        ValidateWhitespaces(connectionString, segmentStart, segmentEnd, allowWhitespaces, "key");
                    }
                    else
                    {
                        throw new InvalidOperationException($"Connection string segment '{connectionString.Substring(segmentStart, segmentEnd - segmentStart)}' should have a value.");
                    }
                }
            }
        }

        private static void ValidateKeyValue(string connectionString, int segmentStart, int segmentEnd, bool allowEmptyValues, bool allowWhitespaces, int kvSeparatorIndex)
        {
            if (segmentStart == kvSeparatorIndex)
            {
                throw new InvalidOperationException($"Segment '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' has no key.");
            }

            if (!allowEmptyValues && kvSeparatorIndex + 1 == segmentEnd)
            {
                throw new InvalidOperationException($"Key '{connectionString.Substring(segmentStart, kvSeparatorIndex - segmentStart)}' has no value.");
            }

            ValidateWhitespaces(connectionString, segmentStart, kvSeparatorIndex, allowWhitespaces, "key");
            ValidateWhitespaces(connectionString, kvSeparatorIndex + 1, segmentEnd, allowWhitespaces, "value");
        }

        private static void ValidateWhitespaces(string connectionString, int start, int end, bool allowWhitespaces, string name)
        {
            if (allowWhitespaces)
            {
                return;
            }

            if (char.IsWhiteSpace(connectionString[start]))
            {
                throw new InvalidOperationException($"Start of the {name} '{connectionString.Substring(start, end - start)}' shouldn't contain spaces.");
            }

            if (char.IsWhiteSpace(connectionString[end - 1]))
            {
                throw new InvalidOperationException($"End of the {name} '{connectionString.Substring(start, end - start)}' shouldn't contain spaces.");
            }
        }
    }
}
