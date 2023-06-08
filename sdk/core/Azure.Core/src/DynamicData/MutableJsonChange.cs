// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        private readonly JsonSerializerOptions _serializerOptions;
        private JsonElement? _serializedValue;

        public MutableJsonChange(string path, int index, object? value, bool replacesJsonElement, JsonSerializerOptions options)
        {
            Path = path;
            Index = index;
            Value = value;
            ReplacesJsonElement = replacesJsonElement;
            _serializerOptions = options;
        }

        public string Path { get; }

        public int Index { get; }

        public object? Value { get; }

        /// <summary>
        /// The change invalidates the existing node's JsonElement
        /// due to changes in JsonValueKind or path structure.
        /// If this is true, Value holds a new JsonElement.
        /// </summary>
        public bool ReplacesJsonElement { get; }

        internal JsonElement AsJsonElement()
        {
            if (_serializedValue != null)
            {
                return _serializedValue.Value;
            }

            if (Value is JsonElement element)
            {
                _serializedValue = element;
                return element;
            }

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value, _serializerOptions);
            _serializedValue = JsonDocument.Parse(bytes).RootElement;
            return _serializedValue.Value;
        }

        internal string AsString()
        {
            return AsJsonElement().ToString() ?? "null";
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; ReplacesJsonElement={ReplacesJsonElement}";
        }
    }
}
