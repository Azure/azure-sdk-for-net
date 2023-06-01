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

            // TODO: refactor for efficiency once proven
            if (replacesJsonElement)
            {
                // Go ahead and serialize so we can throw if not supported
                if (Value is JsonElement element)
                {
                    _serializedValue = element;
                }
                else
                {
                    byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value, _serializerOptions);
                    _serializedValue = JsonDocument.Parse(bytes).RootElement;
                }
            }
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

            // TODO: If it is a MutableJsonDocument, we need to account for changes
            // TODO: What if it is an object that changes after assignment?

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
