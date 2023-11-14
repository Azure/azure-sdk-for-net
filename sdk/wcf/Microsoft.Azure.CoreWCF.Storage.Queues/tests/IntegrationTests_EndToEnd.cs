// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Contracts;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WCF.Azure.StorageQueues;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CoreWCF
{
    public class IntegrationTests_EndToEnd
    {
        private IWebHost host;

        [SetUp]
        public void Setup()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup_EndToEnd>().Build();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public void DefaultQueueConfiguration_ReceiveMessage_Success_EndToEnd()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;

            AzureQueueStorageBinding azureQueueStorageBinding = new(connectionString, AzureQueueStorageMessageEncoding.Text);
            var channelFactory = new System.ServiceModel.ChannelFactory<ITestContract_EndToEndTest>(
                azureQueueStorageBinding,
                new System.ServiceModel.EndpointAddress(endpointUrlString));

            channelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService_EndToEnd");

            var testService = host.Services.GetRequiredService<TestService_EndToEnd>();
            Assert.True(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
            Assert.AreEqual("TestService_EndToEnd", testService.ReceivedName);
        }

        [Test]
        public async Task DefaultQueueConfiguration_ReceiveMessage_Success_EndToEnd_DeadLetterQueue()
        {
            var queueName = "azure-queue";
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;

            AzureQueueStorageBinding azureQueueStorageBinding = new(connectionString, AzureQueueStorageMessageEncoding.Binary);
            var channelFactory = new System.ServiceModel.ChannelFactory<ITestContract_EndToEndTest>(
                azureQueueStorageBinding,
                new System.ServiceModel.EndpointAddress(endpointUrlString));

            channelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService_EndToEnd");

            var testService = host.Services.GetRequiredService<TestService_EndToEnd>();
            Assert.False(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
            QueueClient queueClient = TestHelper.GetQueueClient(azuriteFixture.GetTransport(), connectionString, "deadletter-queue-name", QueueMessageEncoding.Base64);
            QueueMessage message = await queueClient.ReceiveMessageAsync();
            Assert.IsNotNull(message.MessageText);
        }
    }
}
#endif