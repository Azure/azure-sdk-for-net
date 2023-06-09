// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Json
{
    internal struct MutableJsonChange
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public MutableJsonChange(string path,
            int index,
            object? value,
            bool replacesJsonElement,
            JsonSerializerOptions options,
            // TODO: once proven, reorder parameters
            bool isAddition)
        {
            Path = path;
            Index = index;
            Value = value;
            ReplacesJsonElement = replacesJsonElement;
            _serializerOptions = options;
            IsAddition = isAddition;
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

        /// <summary>
        /// Indicates this is a new property added to its parent object.
        /// </summary>
        public bool IsAddition {  get; }

        internal JsonElement AsJsonElement()
        {
            if (Value is JsonElement element)
            {
                return element;
            }

            // TODO: If it is a MutableJsonDocument, we need to account for changes
            // TODO: What if it is an object that changes after assignment?

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value, _serializerOptions);
            return JsonDocument.Parse(bytes).RootElement;
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
