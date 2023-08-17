// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        public MutableJsonChange(string path,
            int index,
            object? value,
            MutableJsonChangeKind changeKind,
            string? addedPropertyName)
        {
            Path = path;
            Index = index;
            Value = value;
            ChangeKind = changeKind;
            AddedPropertyName = addedPropertyName;
        }

        public string Path { get; }

        public int Index { get; }

        public object? Value { get; }

        public string? AddedPropertyName { get; }

        public MutableJsonChangeKind ChangeKind { get; }

        public readonly JsonValueKind ValueKind => Value switch
        {
            bool b => b ? JsonValueKind.True : JsonValueKind.False,
            string => JsonValueKind.String,
            DateTime => JsonValueKind.String,
            DateTimeOffset => JsonValueKind.String,
            Guid => JsonValueKind.String,
            byte => JsonValueKind.Number,
            sbyte => JsonValueKind.Number,
            short => JsonValueKind.Number,
            ushort => JsonValueKind.Number,
            int => JsonValueKind.Number,
            uint => JsonValueKind.Number,
            long => JsonValueKind.Number,
            ulong => JsonValueKind.Number,
            float => JsonValueKind.Number,
            double => JsonValueKind.Number,
            decimal => JsonValueKind.Number,
            null => JsonValueKind.Null,
            JsonElement e => e.ValueKind,
            _ => throw new InvalidCastException() // TODO: fix exception
        };

        private void EnsureArray()
        {
            if (Value is JsonElement e && e.ValueKind == JsonValueKind.Array)
            {
                return;
            }

            // TODO: improve exception
            throw new InvalidOperationException($"Expected an 'Array' type for item.");
        }

        internal int GetArrayLength()
        {
            EnsureArray();

            if (Value is JsonElement e)
            {
                return e.GetArrayLength();
            }

            //TODO
            throw new InvalidOperationException();
        }

        internal static JsonElement ConvertToJsonElement(MutableJsonChange change, JsonSerializerOptions options)
        {
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(change.Value, options);

            // Most JsonDocument.Parse calls return a that is backed by one or more ArrayPool
            // arrays.  Those arrays are not returned until the instance is disposed.
            // This is a workaround that allows us to dispose the JsonDocument so that we
            // don't leak ArrayPool arrays.
#if NET6_0_OR_GREATER
            Utf8JsonReader reader = new(bytes);
            return JsonElement.ParseValue(ref reader);
#else
            using JsonDocument doc = JsonDocument.Parse(bytes);
            return doc.RootElement.Clone();
#endif
        }

        internal bool IsDescendant(string path)
        {
            return IsDescendant(path.AsSpan());
        }

        internal bool IsDescendant(ReadOnlySpan<char> ancestorPath)
        {
            return IsDescendant(ancestorPath, Path.AsSpan());
        }

        internal static bool IsDescendant(ReadOnlySpan<char> ancestorPath, ReadOnlySpan<char> descendantPath)
        {
            if (ancestorPath.Length == 0)
            {
                return descendantPath.Length > 0;
            }

            return descendantPath.Length > ancestorPath.Length &&
                descendantPath.StartsWith(ancestorPath) &&
                // Restrict matches (e.g. so we don't think 'a' is a parent of 'abc').
                descendantPath[ancestorPath.Length] == MutableJsonDocument.ChangeTracker.Delimiter;
        }

        internal bool IsDirectDescendant(string path)
        {
            if (!IsDescendant(path))
            {
                return false;
            }

            string[] ancestorPath = path.Split(MutableJsonDocument.ChangeTracker.Delimiter);
            int ancestorPathLength = string.IsNullOrEmpty(ancestorPath[0]) ? 0 : ancestorPath.Length;
            int descendantPathLength = Path.Split(MutableJsonDocument.ChangeTracker.Delimiter).Length;

            return ancestorPathLength == (descendantPathLength - 1);
        }

        internal bool IsLessThan(ReadOnlySpan<char> otherPath)
        {
            return Path.AsSpan().SequenceCompareTo(otherPath) < 0;
        }

        internal bool IsGreaterThan(ReadOnlySpan<char> otherPath)
        {
            return Path.AsSpan().SequenceCompareTo(otherPath) > 0;
        }

        internal string AsString()
        {
            if (Value is null)
            {
                return "null";
            }

            return Value.ToString()!;
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; Kind={ValueKind}; ChangeKind={ChangeKind}";
        }
    }
}
