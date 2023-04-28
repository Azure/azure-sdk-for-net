// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// The class storing transport security information.
    /// </summary>
    public sealed class AzureQueueStorageTransportSecurity
    {
        internal const AzureQueueStorageCredentialType DefaultClientCredentialType = AzureQueueStorageCredentialType.None;

        private AzureQueueStorageCredentialType _clientCredentialType;
        private string _connectionString;
        private string _queueName;

        /// <summary>
        /// Creates an instance of the AzureQueueStorageTransportSecurity class with the provided parameters.
        /// </summary>
        public AzureQueueStorageTransportSecurity(string connectionString, string queueName)
        {
            _clientCredentialType = DefaultClientCredentialType;
            _connectionString = connectionString;
            _queueName = queueName;
        }

        /// <summary>
        /// Gets or sets the type of credential used by the Azure Queue Storage client.
        /// </summary>
        public AzureQueueStorageCredentialType ClientCredentialType
        {
            get { return _clientCredentialType; }
            set
            {
                if (!AzureQueueStorageCredentialTypeHelper.IsDefined(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Enum Value not found");
                }

                _clientCredentialType = value;
            }
        }

        private void ConfigureAuthentication(AzureQueueStorageTransportBindingElement aqsBindingElement)
        {
            aqsBindingElement.ConnectionString = _connectionString;
            aqsBindingElement.QueueName = _queueName;
        }
    }
}