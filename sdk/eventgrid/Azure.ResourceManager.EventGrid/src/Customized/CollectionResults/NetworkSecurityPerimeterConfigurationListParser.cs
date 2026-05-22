// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358 — see
    // NetworkSecurityPerimeterConfigurationsGetAllAsyncCollectionResultOfT.cs for context.
    // The NSP list response model is not emitted by the generator (because the per-parent
    // Collection itself is not emitted), so we hand-parse the {value, nextLink} envelope.
    internal static class NetworkSecurityPerimeterConfigurationListParser
    {
        internal static (IReadOnlyList<NetworkSecurityPerimeterConfigurationData> Values, Uri NextLink) ParsePage(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content);
            JsonElement root = document.RootElement;
            var items = new List<NetworkSecurityPerimeterConfigurationData>();
            if (root.TryGetProperty("value", out JsonElement arr) && arr.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in arr.EnumerateArray())
                {
                    items.Add(NetworkSecurityPerimeterConfigurationData.DeserializeNetworkSecurityPerimeterConfigurationData(item, ModelSerializationExtensions.WireOptions));
                }
            }
            Uri nextLink = null;
            if (root.TryGetProperty("nextLink", out JsonElement nl) && nl.ValueKind == JsonValueKind.String)
            {
                string nlStr = nl.GetString();
                if (!string.IsNullOrEmpty(nlStr))
                {
                    nextLink = new Uri(nlStr);
                }
            }
            return (items, nextLink);
        }
    }
}
