// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.WCF.Azure.StorageQueues.Channels;
using System;

namespace Microsoft.WCF.Azure.StorageQueues
{
    /// <summary>
    /// Represents the transport security settings for AzureQueueStorageBinding.
    /// </summary>
    public class AzureQueueStorageTransportSecurity
    {
        internal const AzureClientCredentialType DefaultClientCredentialType = AzureClientCredentialType.Default;
        private AzureClientCredentialType _clientCredentialType = DefaultClientCredentialType;

        /// <summary>
        /// Gets or sets the type of client credential used for authentication.
        /// </summary>
        /// <value>The client credential type.</value>
        public AzureClientCredentialType ClientCredentialType
        {
            get { return _clientCredentialType; }
            set
            {
                if (!AzureClientCredentialTypeHelper.IsDefined(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _clientCredentialType = value;
            }
        }

        internal void ConfigureTransportSecurity(AzureQueueStorageTransportBindingElement transport)
        {
            transport.ClientCredentialType = ClientCredentialType;
        }
    }
}