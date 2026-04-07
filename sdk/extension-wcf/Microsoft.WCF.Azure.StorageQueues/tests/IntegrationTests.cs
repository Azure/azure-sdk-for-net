// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Security;
using Azure.Storage.Queues.Models;
using Azure.Storage.Test.Shared;

namespace Microsoft.WCF.Azure.StorageQueues.Tests
{
    public class IntegrationTests
    {
        [Test]
        public async Task DefaultQueueConfiguration_SendReceiveTextMessage_Success()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            QueueClient queueClient = CreateQueueClient(azuriteFixture, queueName, QueueMessageEncoding.None);

            string endpointUrlString = CreateTestService(azuriteFixture, queueName, AzureQueueStorageMessageEncoding.Text);

            string inputMessage = $"<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action><a:To s:mustUnderstand=\"1\">{endpointUrlString}</a:To></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>TestService</name></Create></s:Body></s:Envelope>";
            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(5));
            QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.AreEqual(inputMessage, message.MessageText.ToString());
        }

        [Test]
        public async Task DefaultQueueConfiguration_SendReceiveBinaryMessage_Success()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            QueueClient queueClient = CreateQueueClient(azuriteFixture, queueName, QueueMessageEncoding.Base64);

            CreateTestService(azuriteFixture, queueName, AzureQueueStorageMessageEncoding.Binary);

            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(5));
            QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.IsNotNull(message.MessageText);
        }

        [Test]
        public async Task DefaultQueueConfiguration_SendBinaryReceiveTextMessage_Success()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            QueueClient queueClient = CreateQueueClient(azuriteFixture, queueName, QueueMessageEncoding.None);

            CreateTestService(azuriteFixture, queueName, AzureQueueStorageMessageEncoding.Binary);

            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(5));
            QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.IsNotNull(message.MessageText);
        }

        [Test]
        public void DefaultQueueConfiguration_SendTextReceiveBinaryMessage_Failure()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            QueueClient queueClient = CreateQueueClient(azuriteFixture, queueName, QueueMessageEncoding.Base64);

            CreateTestService(azuriteFixture, queueName, AzureQueueStorageMessageEncoding.Text);

            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(5));
            var exception = Assert.ThrowsAsync<FormatException>(async () =>
            {
                QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            });
            Assert.That(exception.Message, Is.EqualTo("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters."));
        }

        private static QueueClient CreateQueueClient(
            AzuriteFixture azuriteFixture,
            string queueName,
            QueueMessageEncoding queueMessageEncoding)
        {
            var transport = azuriteFixture.GetTransport();
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport, MessageEncoding = queueMessageEncoding });
            queueClient.CreateIfNotExists();
            return queueClient;
        }

        private static string CreateTestService(
            AzuriteFixture azuriteFixture,
            string queueName,
            AzureQueueStorageMessageEncoding azureQueueStorageMessageEncoding)
        {
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            AzureQueueStorageBinding azureQueueStorageBinding = new()
            {
                Security = new()
                {
                    Transport = new()
                    {
                        ClientCredentialType = AzureClientCredentialType.ConnectionString
                    }
                },
                MessageEncoding = azureQueueStorageMessageEncoding
            };
            var channelFactory = new ChannelFactory<ITestContract>(azureQueueStorageBinding, new EndpointAddress(endpointUrlString));
            channelFactory.UseAzureCredentials(creds =>
            {
                creds.ConnectionString = connectionString;
                creds.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication
                {
                    CertificateValidationMode = X509CertificateValidationMode.None
                };
            });

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService");
            return endpointUrlString;
        }
    }
}
