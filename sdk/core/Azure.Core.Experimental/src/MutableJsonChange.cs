// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    internal struct MutableJsonChange
    {
        public string Path { get; set; }

        public int Index { get; set; }

        public object? Value { get; set; }

        /// <summary>
        /// The change invalidates the existing node's JsonElement
        /// due to changes in JsonValueKind or path structure.
        /// If this is true, Value holds a new JsonElement.
        /// </summary>
        public bool ReplacesJsonElement { get; set; }

        internal Utf8JsonReader GetReader()
        {
            if (!ReplacesJsonElement)
            {
                // This change doesn't represent a new node, so we shouldn't need a new reader.
                throw new InvalidOperationException("Unable to get Utf8JsonReader for this change.");
            }

            return MutableJsonElement.GetReaderForElement(AsJsonElement());
        }

        internal JsonElement AsJsonElement()
        {
            if (Value is JsonElement)
            {
                return (JsonElement)Value;
            }

            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(Value);
            return JsonDocument.Parse(bytes).RootElement;
        }

        public override string ToString()
        {
            return $"Path={Path}; Value={Value}; ReplacesJsonElement={ReplacesJsonElement}";
        }
    }
}
