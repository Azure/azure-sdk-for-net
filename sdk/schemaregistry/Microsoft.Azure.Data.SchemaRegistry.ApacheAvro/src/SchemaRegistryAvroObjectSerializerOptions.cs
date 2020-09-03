// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// Options for <see cref="SchemaRegistryAvroObjectSerializer"/>.
    /// </summary>
    public class SchemaRegistryAvroObjectSerializerOptions
    {
        /// <summary>
        /// When true, automatically registers the provided schema with the SchemaRegistry during serialization.
        /// When false, the schema is only acquired from the SchemaRegistry.
        /// </summary>
        public bool AutoRegisterSchemas { get; set; }
    }
}
