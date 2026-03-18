// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceBus.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceBus.Models
{
    [CodeGenSuppress("DeserializeServiceBusNamespacePatch", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class ServiceBusNamespacePatch
    {
        /// <summary> Initializes a new instance of <see cref="ServiceBusNamespacePatch"/>. </summary>
        /// <param name="location"> The resource location. </param>
        public ServiceBusNamespacePatch(AzureLocation location) : this()
        {
            Location = location.Name;
        }

        internal static ServiceBusNamespacePatch DeserializeServiceBusNamespacePatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            AzureLocation location = default;
            IDictionary<string, string> tags = default;
            ServiceBusSku sku = default;
            SBNamespaceUpdateProperties properties = default;
            ManagedServiceIdentity identity = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerServiceBusContext.Default);
                    continue;
                }
                if (prop.NameEquals("location"u8))
                {
                    location = new AzureLocation(prop.Value.GetString());
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
                if (prop.NameEquals("sku"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sku = ServiceBusSku.DeserializeServiceBusSku(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = SBNamespaceUpdateProperties.DeserializeSBNamespaceUpdateProperties(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("identity"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerServiceBusContext.Default);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ServiceBusNamespacePatch(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                properties,
                sku,
                identity);
        }
    }
}
