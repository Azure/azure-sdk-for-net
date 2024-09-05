// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HDInsight.Models
{
    /// <summary>
    /// HDInsightStorageAccountInfo
    /// </summary>
    [CodeGenSerialization(nameof(ResourceId), DeserializationValueHook = nameof(DeserializeResourceId))]
    public partial class HDInsightStorageAccountInfo
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeResourceId(JsonProperty property, ref ResourceIdentifier resourceId)
        {
            // If the property is null or empty, set the resourceId to null. Issue link: https://github.com/Azure/azure-sdk-for-net/issues/45709
            if (property.Value.ValueKind == JsonValueKind.Null || string.IsNullOrEmpty(property.Value.GetString()))
            {
                resourceId = null;
                return;
            }
            resourceId = new ResourceIdentifier(property.Value.GetString());
        }
    }
}
