// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using NUnit.Framework;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues.Tests
{
    public class QueueClientConfigurationTests
    {
        [Test]
        public async Task QueueClient_ManualConfigurationDelegate_Called()
        {
            var queueName = Guid.NewGuid().ToString("D").ToLowerInvariant();
            IClientChannel channel = CreateChannel(queueName);
            var channelParameters = channel.GetProperty<ChannelParameterCollection>();
            channelParameters.Add(new Func<QueueClient, QueueClient>(ConfigureQueueClient));
            bool configureQueueClientCalled = false;
            Task assertionChecks = null;
            channel.Open();
            Assert.IsTrue(configureQueueClientCalled);
            Assert.IsNotNull(assertionChecks);
            assertionChecks.RunSynchronously();
            await assertionChecks;

            QueueClient ConfigureQueueClient(QueueClient queueClient)
            {
                configureQueueClientCalled = true;
                assertionChecks = new Task(() =>
                {
                    Assert.AreEqual(queueName, queueClient.Name);
                    Assert.AreEqual(AzuriteNUnitFixture.Instance.GetAzureAccount().Name, queueClient.AccountName);
                });
                return queueClient;
            }
        }

        [Test]
        public void QueueClient_MismatachedAccountName_Fails()
        {
            var queueName = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var accountName = Guid.NewGuid().ToString("D").ToLowerInvariant().Substring(5);
            IClientChannel channel = CreateChannel(queueName, accountName);
            Assert.Throws<ArgumentException>(() => channel.Open());
        }

        private IClientChannel CreateChannel(string queueName, string accountName = null)
        {
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var queueEndpoint = azuriteFixture.GetAzureAccount().QueueEndpoint;
            if (!queueEndpoint.EndsWith('/'))
            {
                queueEndpoint += "/";
            }

            Uri baseUri = new Uri(queueEndpoint);
            Uri endpointUri;
            if (string.IsNullOrEmpty(accountName))
            {
                var endpointUriBuilder = new UriBuilder(new Uri(baseUri, queueName))
                {
                    Scheme = "net.aqs"
                };
                endpointUri = endpointUriBuilder.Uri;
            }
            else
            {
                var endpointUriBuilder = new UriBuilder(baseUri)
                {
                    Scheme = "net.aqs",
                    Path = $"/{accountName}/{queueName}"
                };
                endpointUri = endpointUriBuilder.Uri;
            }

            var endpointUrlString = endpointUri.AbsoluteUri;
            AzureQueueStorageBinding azureQueueStorageBinding = new();
            azureQueueStorageBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.ConnectionString;

            var channelFactory = new ChannelFactory<IOutputChannel>(azureQueueStorageBinding, new EndpointAddress(endpointUrlString));
            channelFactory.UseAzureCredentials(creds =>
            {
                creds.ConnectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            });

            return channelFactory.CreateChannel() as IClientChannel;
        }
    }
}
