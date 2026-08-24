// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.ResourceManager.ManufacturingPlatform;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManufacturingPlatform.Models
{
    // The generated public model flattens BrokerResources onto ManufacturingDataServiceProperties,
    // but service payloads still require the internal managedOnBehalfOfConfiguration envelope.
    [CodeGenSerialization(nameof(BrokerResources), SerializationValueHook = nameof(SerializeBrokerResources))]
    internal partial class ManagedOnBehalfOfConfiguration
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeBrokerResources(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartArray();
            foreach (ManagedOnBehalfOfBrokerResourceInfo item in BrokerResources ?? Array.Empty<ManagedOnBehalfOfBrokerResourceInfo>())
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }
    }
}
