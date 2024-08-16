// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApplicationInsights
{
    /// <summary>
    /// A class representing the ApplicationInsightsWorkbook data model.
    /// A workbook definition.
    /// </summary>
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(DeserializeTypeValue))]
    public partial class ApplicationInsightsWorkbookData : TrackedResourceData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeTypeValue(JsonProperty property, ref ResourceType type)
        {
            var propVal = property.Value.GetString();
            type = string.IsNullOrEmpty(propVal) ? ApplicationInsightsWorkbookResource.ResourceType : new ResourceType(propVal);
        }
    }
}
