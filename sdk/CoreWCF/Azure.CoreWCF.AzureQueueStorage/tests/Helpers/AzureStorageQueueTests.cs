// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF.Channels;
using Azure.Storage.Queues;
using Xunit;

namespace Azure.Storage.CoreWCF.AzureQueueStorage.Tests.Helpers
{
    public class AzureStorageQueueTests : IClassFixture<QueueDeclareConfigurationFixture>
    {
        public QueueDeclareConfigurationFixture _fixture;

        public AzureStorageQueueTests(QueueDeclareConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void AzureQueueStorageBinding_MessageEncoding_IsText()
        {
            Assert.Equal(AzureQueueStorageMessageEncoding.Text, _fixture.azureQueueStorageBinding.MessageEncoding);
        }

        [Fact]
        public void AzureQueueStorageBinding_Scheme()
        {
            Assert.Equal("soap.aqs", _fixture.azureQueueStorageBinding.Scheme);
        }

        [Fact]
        public void AzureQueueStorageBinding_MessageSize()
        {
            Assert.Equal(8000L, _fixture.azureQueueStorageBinding.MaxMessageSize);
        }

        [Fact]
        public void AzureQueueStorageQueueNameConverter_GetEndpointUrl()
        {
            Assert.Equal("net.aqs://account.queue.core.windows.net/Queue", AzureQueueStorageQueueNameConverter.GetEndpointUrl("account", "Queue"));
        }
    }
}
