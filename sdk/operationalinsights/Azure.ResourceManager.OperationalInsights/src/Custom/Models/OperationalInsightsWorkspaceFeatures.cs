// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: preserve the GA AdditionalProperties catch-all bag for unknown root-level JSON properties.
    // The GA SDK also shipped [WirePath("AdditionalProperties")] on this member; keep that metadata for ApiCompat and tooling
    // even though serialization does not treat it as a nested "AdditionalProperties" wire property.
    public partial class OperationalInsightsWorkspaceFeatures
    {
        /// <summary> Gets the AdditionalProperties. </summary>
        [WirePath("AdditionalProperties")]
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;

        internal static OperationalInsightsWorkspaceFeatures DeserializeOperationalInsightsWorkspaceFeatures(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? isDataExportEnabled = default;
            bool? immediatePurgeDataOn30Days = default;
            bool? isLogAccessUsingOnlyResourcePermissionsEnabled = default;
            ResourceIdentifier clusterResourceId = default;
            bool? isLocalAuthDisabled = default;
            bool? isUnifiedSentinelBillingOnly = default;
            IReadOnlyList<string> associations = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("enableDataExport"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        isDataExportEnabled = null;
                        continue;
                    }
                    isDataExportEnabled = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("immediatePurgeDataOn30Days"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        immediatePurgeDataOn30Days = null;
                        continue;
                    }
                    immediatePurgeDataOn30Days = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("enableLogAccessUsingOnlyResourcePermissions"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        isLogAccessUsingOnlyResourcePermissionsEnabled = null;
                        continue;
                    }
                    isLogAccessUsingOnlyResourcePermissionsEnabled = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("clusterResourceId"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        clusterResourceId = null;
                        continue;
                    }
                    clusterResourceId = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("disableLocalAuth"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        isLocalAuthDisabled = null;
                        continue;
                    }
                    isLocalAuthDisabled = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("unifiedSentinelBillingOnly"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        isUnifiedSentinelBillingOnly = null;
                        continue;
                    }
                    isUnifiedSentinelBillingOnly = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("associations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    associations = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new OperationalInsightsWorkspaceFeatures(
                isDataExportEnabled,
                immediatePurgeDataOn30Days,
                isLogAccessUsingOnlyResourcePermissionsEnabled,
                clusterResourceId,
                isLocalAuthDisabled,
                isUnifiedSentinelBillingOnly,
                associations ?? new ChangeTrackingList<string>(),
                additionalProperties);
        }
    }
}
