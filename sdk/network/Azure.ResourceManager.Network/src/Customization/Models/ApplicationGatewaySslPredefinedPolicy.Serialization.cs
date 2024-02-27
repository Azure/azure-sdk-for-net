// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        internal static ApplicationGatewaySslPredefinedPolicy DeserializeApplicationGatewaySslPredefinedPolicy(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            Optional<IList<ApplicationGatewaySslCipherSuite>> cipherSuites = default;
            Optional<ApplicationGatewaySslProtocol> minProtocolVersion = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("cipherSuites"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationGatewaySslCipherSuite> array = new List<ApplicationGatewaySslCipherSuite>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new ApplicationGatewaySslCipherSuite(item.GetString()));
                            }
                            cipherSuites = array;
                            continue;
                        }
                        if (property0.NameEquals("minProtocolVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            minProtocolVersion = new ApplicationGatewaySslProtocol(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ApplicationGatewaySslPredefinedPolicy(id.Value, name.Value, Optional.ToNullable(type), serializedAdditionalRawData, Optional.ToList(cipherSuites), Optional.ToNullable(minProtocolVersion));
        }
    }
}
