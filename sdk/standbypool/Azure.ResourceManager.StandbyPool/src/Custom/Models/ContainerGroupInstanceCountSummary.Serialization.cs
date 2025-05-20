// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.StandbyPool.Models
{
    [CodeGenSerialization(nameof(StandbyContainerGroupInstanceCountsByState), SerializationValueHook = nameof(InstanceCountsByStateSerial))]
    public partial class ContainerGroupInstanceCountSummary
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InstanceCountsByStateSerial(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (StandbyContainerGroupInstanceCountsByState == null)
            {
                writer.WriteStartArray();
                foreach (var item in InstanceCountsByState)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in StandbyContainerGroupInstanceCountsByState)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }
    }
}
