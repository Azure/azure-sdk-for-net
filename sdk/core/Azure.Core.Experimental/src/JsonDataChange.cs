// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.Core.Dynamic
{
    internal struct JsonDataChange
    {
        public string Path { get; set; }

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

            JsonElement jsonElement = (JsonElement)Value!;

            // TODO: This is super inefficient, come back to and optimize
            BinaryData data = new BinaryData(jsonElement.ToString());

            return new Utf8JsonReader(data.ToMemory().Span);
        }
    }
}
