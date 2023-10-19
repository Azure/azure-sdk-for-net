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
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName);
            endpointUriBuilder.Scheme = "net.aqs";
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;
            var queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions { Transport = transport });
            queueClient.CreateIfNotExists();

            AzureQueueStorageBinding azureQueueStorageBinding = new AzureQueueStorageBinding(AzureQueueStorageMessageEncoding.Text);
            var channelFactory = new ChannelFactory<ITestContract>(azureQueueStorageBinding, new EndpointAddress(endpointUrlString));
            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("test");

            string inputMessage = "<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>test</name></Create></s:Body></s:Envelope>";
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(20));
            var message = await queueClient.ReceiveMessageAsync(null, cancellationTokenSource.Token);
            Assert.Equals(message.ToString(), inputMessage);
        }
    }
}
