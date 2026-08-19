// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Batch
{
    [CodeGenSerialization(nameof(Location), SerializationValueHook = nameof(SerializeLocation))]
    public partial class BatchAccountData
    {
        // The hierarchy customization generates mutable tags, but the shipped API exposes a read-only dictionary.
        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        // The hierarchy customization generates a required location, but the shipped API allows it to be omitted.
        /// <summary> The geo-location where the resource lives. </summary>
        public AzureLocation? Location { get; set; }

        private void SerializeLocation(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Location.HasValue)
            {
                writer.WriteStringValue(Location.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
