// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF.Channels;
using Azure.Storage.Queues;
using Xunit;

namespace Azure.Storage.CoreWCF.AzureQueueStorage.Tests.Helpers
{
    public class QueueDeclareConfigurationFixture
    {
        public AzureQueueStorageBinding azureQueueStorageBinding;
        public QueueClient queueClient;
        public AzureQueueStorageQueueNameConverter azureQueueStorageQueueNameConverter;

        public QueueDeclareConfigurationFixture()
        {
            azureQueueStorageBinding = new AzureQueueStorageBinding();
        }
    }
}
