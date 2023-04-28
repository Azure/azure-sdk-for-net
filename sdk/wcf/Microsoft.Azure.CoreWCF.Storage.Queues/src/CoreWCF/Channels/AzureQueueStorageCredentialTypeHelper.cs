// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// The enum for Azure storage credentials
    /// </summary>
    public enum AzureQueueStorageCredentialType
    {
        /// <summary>
        /// No specific credentials are provided.
        /// </summary>
        None,
        /// <summary>
        /// Connection string is used as the credential for Azure Queue Storage.
        /// </summary>
        ConnectionString
    }
    internal static class AzureQueueStorageCredentialTypeHelper
    {
        internal static bool IsDefined(AzureQueueStorageCredentialType value)
        {
            return (value == AzureQueueStorageCredentialType.None ||
                value == AzureQueueStorageCredentialType.ConnectionString);
        }
    }
}