// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class AzureQueueStorageSecurity
    {
        private AzureQueueStorageTransportSecurity _transportSecurity;
        private string _connectionString;
        private string _queueName;

        public AzureQueueStorageSecurity(string connectionString, string queueName)
         : this(connectionString, queueName, null )
        {
        }
        public AzureQueueStorageSecurity(string connectionString, string queueName, AzureQueueStorageTransportSecurity azureQueueStorageTransportSecurity)
        {
            _connectionString = connectionString;
            _queueName = queueName;
            _transportSecurity = azureQueueStorageTransportSecurity;
        }

        public AzureQueueStorageTransportSecurity Transport
        {
            get { return _transportSecurity; }
            set
            {
                _transportSecurity = (value == null) ? new AzureQueueStorageTransportSecurity(_connectionString, _queueName) : value;
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Connection string cannot be empty.");
                }
                _connectionString = value;
            }
        }

        public string QueueName
        {
            get { return _queueName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Queue Name cannot be empty.");
                }
                _queueName = value;
            }
        }
    }
}
