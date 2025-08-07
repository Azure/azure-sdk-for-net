// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.CoreWCF.Azure
{
    /// <summary>
    /// Represents the types of credentials that can be passed to authenticate with Azure
    /// </summary>
    public enum AzureClientCredentialType
    {
        /// <summary>
        /// Use the <see href="https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential">Azure.Identity.DefaultAzureCredential</see> credential
        /// </summary>
        Default,

        /// <summary>
        /// Use a <see href="https://learn.microsoft.com/dotnet/api/azure.azuresascredential">Azure.AzureSasCredential</see> credential
        /// </summary>
        Sas,

        /// <summary>
        /// Use a <see href="https://learn.microsoft.com/dotnet/api/azure.storage.storagesharedkeycredential">Azure.Storage.StorageSharedKeyCredential</see> credential
        /// </summary>
        StorageSharedKey,

        /// <summary>
        /// Use a <see href="https://learn.microsoft.com/dotnet/api/azure.core.tokencredential">Azure.Core.TokenCredential</see> credential
        /// </summary>
        Token,

        /// <summary>
        /// Use a connection string to provide credentials. See how to <see href="https://learn.microsoft.com/azure/storage/common/storage-configure-connection-string">Configure Azure Storage connection strings</see>.
        /// </summary>
        ConnectionString
    }
}