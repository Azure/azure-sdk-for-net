// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues
{
    /// <summary>
    /// Class to configure the binding security.
    /// </summary>
    public class AzureQueueStorageSecurity
    {
        private AzureQueueStorageTransportSecurity _transport;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureQueueStorageSecurity"/> class.
        /// </summary>
        public AzureQueueStorageSecurity() : this(new AzureQueueStorageTransportSecurity()) { }

        private AzureQueueStorageSecurity(AzureQueueStorageTransportSecurity azureQueueStorageTransportSecurity)
        {
            Transport = azureQueueStorageTransportSecurity;
        }

        /// <summary>
        /// Gets an object that contains the transport-level security settings for this binding.
        /// </summary>
        public AzureQueueStorageTransportSecurity Transport
        {
            get => _transport;
            set
            {
                _transport = value ?? throw new ArgumentNullException(nameof(Transport));
            }
        }
    }
}
