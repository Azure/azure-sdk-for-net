// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayAvailableSslOptionsInfo
    {
        internal static ApplicationGatewayAvailableSslOptionsInfo DeserializeApplicationGatewayAvailableSslOptionsInfo(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            Optional<AzureLocation> location = default;
            Optional<IDictionary<string, string>> tags = default;
            Optional<IList<WritableSubResource>> predefinedPolicies = default;
            Optional<ApplicationGatewaySslPolicyName> defaultPolicy = default;
            Optional<IList<ApplicationGatewaySslCipherSuite>> availableCipherSuites = default;
            Optional<IList<ApplicationGatewaySslProtocol>> availableProtocols = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    // Wrokaround for issue https://github.com/Azure/azure-sdk-for-net/issues/27102 to ensure the id is a valid ResourceIdentifier
                    string val = property.Value.GetString();
                    if (val.Contains("resourceGroups//"))
                    {
                        val = val.Replace("resourceGroups//", string.Empty);
                    }
                    id = new ResourceIdentifier(val);
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("predefinedPolicies"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                // Wrokaround for issue https://github.com/Azure/azure-sdk-for-net/issues/27102 to ensure the id is a valid ResourceIdentifier
                                string val = item.ToString();
                                if (val.Contains("resourceGroups//"))
                                {
                                    val = val.Replace("resourceGroups//", string.Empty);
                                }
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(val));
                            }
                            predefinedPolicies = array;
                            continue;
                        }
                        if (property0.NameEquals("defaultPolicy"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            defaultPolicy = new ApplicationGatewaySslPolicyName(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("availableCipherSuites"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<ApplicationGatewaySslCipherSuite> array = new List<ApplicationGatewaySslCipherSuite>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new ApplicationGatewaySslCipherSuite(item.GetString()));
                            }
                            availableCipherSuites = array;
                            continue;
                        }
                        if (property0.NameEquals("availableProtocols"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<ApplicationGatewaySslProtocol> array = new List<ApplicationGatewaySslProtocol>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new ApplicationGatewaySslProtocol(item.GetString()));
                            }
                            availableProtocols = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ApplicationGatewayAvailableSslOptionsInfo(id.Value, name.Value, Optional.ToNullable(type), Optional.ToNullable(location), Optional.ToDictionary(tags), Optional.ToList(predefinedPolicies), Optional.ToNullable(defaultPolicy), Optional.ToList(availableCipherSuites), Optional.ToList(availableProtocols));
        }
    }
}
