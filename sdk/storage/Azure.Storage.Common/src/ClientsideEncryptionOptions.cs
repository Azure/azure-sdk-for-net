// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Cryptography;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Blob using clientside encryption.
    /// </summary>
    public class ClientSideEncryptionOptions
    {
        // NOTE there is a non-public Clone method for this class, compile-included into relevant packages from
        // Shared/ClientsideEncryption/ClientSideEncryptionOptionsExtensions.cs

        /// <summary>
        /// The version of clientside encryption to use.
        /// </summary>
        public ClientSideEncryptionVersion EncryptionVersion { get; }

        /// <summary>
        /// Required for upload operations.
        /// The key used to wrap the generated content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKey KeyEncryptionKey { get; set; }

        /// <summary>
        /// Required for download operations.
        /// Fetches the correct key encryption key to unwrap the downloaded content encryption key.
        /// For more information, see https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption.
        /// </summary>
        public IKeyEncryptionKeyResolver KeyResolver { get; set; }

        /// <summary>
        /// Required for upload operations.
        /// The algorithm identifier to use when wrapping the content encryption key. This is passed into
        /// <see cref="IKeyEncryptionKey.WrapKey(string, ReadOnlyMemory{byte}, System.Threading.CancellationToken)"/>
        /// and its async counterpart.
        /// </summary>
        public string KeyWrapAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSideEncryptionOptions"/> class.
        /// </summary>
        /// <param name="version">The version of clientside encryption to use.</param>
        public ClientSideEncryptionOptions(ClientSideEncryptionVersion version)
        {
            EncryptionVersion = version;
        }
    }
}
