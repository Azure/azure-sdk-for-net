// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using Azure.Storage.WCF;
using System.ServiceModel.Security;
using Azure.Storage.Queues.Models;

namespace WCF.AzureQueueStorage.Tests
{
    public class IntegrationTests
    {
        [Test]
        public async Task DefaultQueueConfiguration_ReceiveMessage_Success()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var transport = azuriteFixture.GetTransport();
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            var queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport });
            queueClient.CreateIfNotExists();

            queueClient.SendMessageAsync("test").Wait();
            var m = queueClient.ReceiveMessageAsync().Result;
            Assert.AreEqual(m.Value.MessageText, "test");

            AzureQueueStorageBinding azureQueueStorageBinding = new AzureQueueStorageBinding(connectionString, AzureQueueStorageMessageEncoding.Text);
            var channelFactory = new ChannelFactory<ITestContract>(azureQueueStorageBinding, new EndpointAddress(endpointUrlString));

            channelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = X509CertificateValidationMode.None
            };

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService");

            string inputMessage = $"<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action><a:To s:mustUnderstand=\"1\">{endpointUrlString}</a:To></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>TestService</name></Create></s:Body></s:Envelope>";
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            QueueMessage message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.AreEqual(inputMessage, message.MessageText.ToString());
        }
    }
}
