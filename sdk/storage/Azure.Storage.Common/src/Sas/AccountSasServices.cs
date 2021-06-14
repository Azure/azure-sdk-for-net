// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage.Sas
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// Specifies the services accessible from an account level shared access
    /// signature.
    /// </summary>
    [Flags]
    public enum AccountSasServices
    {
        /// <summary>
        /// Indicates whether Azure Blob Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Blobs = 1,

        /// <summary>
        /// Indicates whether Azure Queue Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Queues = 2,

        /// <summary>
        /// Indicates whether Azure File Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Files = 4,

        /// <summary>
        /// Indicates whether Azure Table Storage resources are
        /// accessible from the shared access signature.
        /// </summary>
        Tables = 8,

        /// <summary>
        /// Indicates all services are accessible from the shared
        /// access signature.
        /// </summary>
        All = ~0
    }
}
