// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        private JsonElement? _serializedValue;
        private readonly JsonSerializerOptions _serializerOptions;

        public MutableJsonChange(string path,
            int index,
            object? value,
            JsonSerializerOptions options,
            MutableJsonChangeKind changeKind,
            string? addedPropertyName)
        {
            Path = path;
            Index = index;
            Value = value;
            _serializerOptions = options;
            ChangeKind = changeKind;
            AddedPropertyName = addedPropertyName;

            if (value is JsonElement element)
            {
                _serializedValue = element;
            }

            if (value is JsonDocument doc)
            {
                _serializedValue = doc.RootElement;
            }
        }

        public string Path { get; }

        public int Index { get; }

        public object? Value { get; }

        public string? AddedPropertyName { get; }

        public MutableJsonChangeKind ChangeKind { get; }

        public JsonValueKind ValueKind => GetSerializedValue().ValueKind;

        internal JsonElement GetSerializedValue()
        {
            if (_serializedValue != null)
            {
                return _serializedValue.Value;
            }

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value, _serializerOptions);
            _serializedValue = JsonDocument.Parse(bytes).RootElement;
            return _serializedValue.Value;
        }

        internal bool IsDescendant(string path)
        {
            return IsDescendant(path.AsSpan());
        }

        internal bool IsDescendant(ReadOnlySpan<char> path)
        {
            if (path.Length == 0)
            {
                return Path.Length > 0;
            }

            // Restrict matches (e.g. so we don't think 'a' is a parent of 'abc').
            Span<char> copy = stackalloc char[path.Length + 1];
            path.CopyTo(copy);
            copy[path.Length] = MutableJsonDocument.ChangeTracker.Delimiter;

            return Path.AsSpan().StartsWith(copy, StringComparison.Ordinal);
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
            return GetSerializedValue().ToString() ?? "null";
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; Kind={ValueKind}; ChangeKind={ChangeKind}";
        }
    }
}
