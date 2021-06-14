// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
    /// <summary>
    /// The version of clientside encryption to use.
    /// </summary>
    public enum ClientSideEncryptionVersion
    {
        /// <summary>
        /// 1.0
        /// </summary>
        V1_0 = 1
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
