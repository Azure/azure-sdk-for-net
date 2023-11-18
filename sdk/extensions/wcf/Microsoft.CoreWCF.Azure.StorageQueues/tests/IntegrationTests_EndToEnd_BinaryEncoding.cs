// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER

using Contracts;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WCF.Azure.StorageQueues;
using NUnit.Framework;
using System;
using Microsoft.WCF.Azure;

namespace CoreWCF
{
    public class IntegrationTests_EndToEnd_BinaryEncoding
    {
        private IWebHost host;

        [SetUp]
        public void Setup()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup_EndToEnd_BinaryEncoding>().Build();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public void DefaultQueueConfiguration_ReceiveBinaryMessage_Success_EndToEnd()
        {
            var queueName = Startup_EndToEnd_BinaryEncoding.QueueName;
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;

            AzureQueueStorageBinding azureQueueStorageBinding = new();
            azureQueueStorageBinding.MessageEncoding = AzureQueueStorageMessageEncoding.Binary;
            azureQueueStorageBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.ConnectionString;
            var channelFactory = new System.ServiceModel.ChannelFactory<ITestContract_EndToEndTest>(
                azureQueueStorageBinding,
                new System.ServiceModel.EndpointAddress(endpointUrlString));

            var credentials = channelFactory.UseAzureCredentials();
            credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };
            credentials.ConnectionString = connectionString;

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService_EndToEnd");

            var testService = host.Services.GetRequiredService<TestService_EndToEnd>();
            Assert.True(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
            Assert.AreEqual("TestService_EndToEnd", testService.ReceivedName);
        }

        [Test]
        public void DefaultQueueConfiguration_ReceiveBinaryMessage_Success_EndToEnd_conflict()
        {
            var queueName = Startup_EndToEnd_BinaryEncoding.QueueName;
            var azuriteFixture = AzuriteNUnitFixture.Instance;
            var connectionString = azuriteFixture.GetAzureAccount().ConnectionString;
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName)
            {
                Scheme = "net.aqs"
            };
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;

            AzureQueueStorageBinding azureQueueStorageBinding = new();
            azureQueueStorageBinding.Security.Transport.ClientCredentialType = AzureClientCredentialType.ConnectionString;
            azureQueueStorageBinding.MessageEncoding = AzureQueueStorageMessageEncoding.Text;
            var channelFactory = new System.ServiceModel.ChannelFactory<ITestContract_EndToEndTest>(
                azureQueueStorageBinding,
                new System.ServiceModel.EndpointAddress(endpointUrlString));

            var credentials = channelFactory.UseAzureCredentials();
            credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };
            credentials.ConnectionString = connectionString;

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService_EndToEnd");

            var testService = host.Services.GetRequiredService<TestService_EndToEnd>();
            Assert.False(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
        }
    }
}
#endif