// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF.Channels;
using Azure.Storage.Queues;
using NUnit.Framework;
using NUnit;

namespace Azure.Storage.CoreWCF.AzureQueueStorage.Tests.Helpers
{
    [TestFixture]
    public class AzureStorageQueueTests
    {
        public QueueDeclareConfigurationFixture _fixture;

        public AzureStorageQueueTests(QueueDeclareConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [Test]
        public void AzureQueueStorageBinding_MessageEncoding_IsText()
        {
            Assert.Equals(AzureQueueStorageMessageEncoding.Text, _fixture.azureQueueStorageBinding.MessageEncoding);
        }

        [Test]
        public void AzureQueueStorageBinding_Scheme()
        {
            Assert.Equals("soap.aqs", _fixture.azureQueueStorageBinding.Scheme);
        }

        [Test]
        public void AzureQueueStorageBinding_MessageSize()
        {
            Assert.Equals(8000L, _fixture.azureQueueStorageBinding.MaxMessageSize);
        }

        [Test]
        public void AzureQueueStorageQueueNameConverter_GetEndpointUrl()
        {
            Assert.Equals("net.aqs://account.queue.core.windows.net/Queue", AzureQueueStorageQueueNameConverter.GetEndpointUrl("account", "Queue"));
        }
    }
}
