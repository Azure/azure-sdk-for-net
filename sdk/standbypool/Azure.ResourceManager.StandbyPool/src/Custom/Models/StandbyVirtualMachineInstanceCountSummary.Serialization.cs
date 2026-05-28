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
    [CodeGenSerialization(nameof(StandbyVirtualMachineInstanceCountsByState), SerializationValueHook = nameof(InstanceCountsByStateSerial))]
    public partial class StandbyVirtualMachineInstanceCountSummary
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void InstanceCountsByStateSerial(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (StandbyVirtualMachineInstanceCountsByState == null)
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
                foreach (var item in StandbyVirtualMachineInstanceCountsByState)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }
    }
}
