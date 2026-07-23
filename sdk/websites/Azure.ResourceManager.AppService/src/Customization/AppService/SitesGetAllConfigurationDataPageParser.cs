// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.AppService
{
    // Helper for parsing the paged response of WebApps_ListConfigurations[Slot]. The generator emits the
    // REST methods but no list-result model, so we deserialize the {value:[], nextLink:""} envelope here.
    internal static class SitesGetAllConfigurationDataPageParser
    {
        public static (IReadOnlyList<SiteConfigData> Values, Uri NextLink) Parse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            JsonElement root = document.RootElement;
            List<SiteConfigData> values = new List<SiteConfigData>();
            if (root.TryGetProperty("value", out JsonElement valueElement) && valueElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in valueElement.EnumerateArray())
                {
                    values.Add(SiteConfigData.DeserializeSiteConfigData(item, ModelSerializationExtensions.WireOptions));
                }
            }
            Uri nextLink = null;
            if (root.TryGetProperty("nextLink", out JsonElement nextLinkElement) && nextLinkElement.ValueKind == JsonValueKind.String)
            {
                string nextLinkString = nextLinkElement.GetString();
                if (!string.IsNullOrEmpty(nextLinkString))
                {
                    nextLink = new Uri(nextLinkString);
                }
            }
            return (values, nextLink);
        }
    }
}
