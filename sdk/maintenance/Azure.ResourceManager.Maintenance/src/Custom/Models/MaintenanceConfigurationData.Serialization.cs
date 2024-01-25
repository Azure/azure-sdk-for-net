// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Maintenance
{
    public partial class MaintenanceConfigurationData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeStartOn(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(StartOn.Value, "yyyy-MM-dd HH:mm");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeExpireOn(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(ExpireOn.Value, "yyyy-MM-dd HH:mm");
        }
    }
}
