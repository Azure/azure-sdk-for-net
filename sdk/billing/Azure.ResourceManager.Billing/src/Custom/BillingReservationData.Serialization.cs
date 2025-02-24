// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Billing.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Billing
{
    [CodeGenSerialization(nameof(InstanceFlexibility), DeserializationValueHook = nameof(DeserializeInstanceFlexibilityValue))]
    public partial class BillingReservationData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeInstanceFlexibilityValue(JsonProperty property0, ref InstanceFlexibility? instanceFlexibility)
        {
            if (property0.Value.ValueKind == JsonValueKind.Null)
            {
                instanceFlexibility = null;
                return;
            }
            int numericValue = property0.Value.GetInt32();
            instanceFlexibility = numericValue switch
            {
                1 => "On",
                2 => "Off",
                _ => throw new InvalidOperationException($"Unexpected value for instanceFlexibility: {numericValue}")
            };
        }
    }
}
