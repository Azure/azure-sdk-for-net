// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Workaround for generator bug: generated DeserializeDnsForwardingRulesetPatch calls
    // WritableSubResource.DeserializeWritableSubResource which is internal in Azure.ResourceManager.
    [CodeGenSuppress("DeserializeDnsForwardingRulesetPatch", typeof(JsonElement), typeof(System.ClientModel.Primitives.ModelReaderWriterOptions))]
    public partial class DnsForwardingRulesetPatch
    {
        internal static DnsForwardingRulesetPatch DeserializeDnsForwardingRulesetPatch(JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<WritableSubResource> dnsResolverOutboundEndpoints = default;
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("dnsResolverOutboundEndpoints"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WritableSubResource> array = new List<WritableSubResource>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        var wsr = new WritableSubResource();
                        foreach (var innerProp in item.EnumerateObject())
                        {
                            if (innerProp.NameEquals("id"u8))
                            {
                                if (innerProp.Value.ValueKind != JsonValueKind.Null)
                                {
                                    wsr.Id = new ResourceIdentifier(innerProp.Value.GetString());
                                }
                            }
                        }
                        array.Add(wsr);
                    }
                    dnsResolverOutboundEndpoints = array;
                    continue;
                }
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    tags = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DnsForwardingRulesetPatch(dnsResolverOutboundEndpoints ?? new ChangeTrackingList<WritableSubResource>(), tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties);
        }
    }
}
