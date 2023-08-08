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
        internal const string SerializationRequiresUnreferencedCode = "This method utilizes reflection-based JSON serialization which is not compatible with trimming.";

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

        public JsonValueKind ValueKind
        {
#if NET6_0_OR_GREATER
           [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
#endif
            get
            {
                return GetSerializedValue().ValueKind;
            }
        }

#if NET6_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
#endif
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
            if (path.Length > 0)
            {
                // Restrict matches (e.g. so we don't think 'a' is a parent of 'abc').
                path += MutableJsonDocument.ChangeTracker.Delimiter;
            }

            return Path.StartsWith(path, StringComparison.Ordinal);
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

#if NET6_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.RequiresUnreferencedCode(SerializationRequiresUnreferencedCode)]
#endif
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
