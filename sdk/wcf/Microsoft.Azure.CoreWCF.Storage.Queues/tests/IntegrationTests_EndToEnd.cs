// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER

using Contracts;
using CoreWCF.AzureQueueStorage.Tests;
using CoreWCF.AzureQueueStorage.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

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
            var endpointUriBuilder = new UriBuilder(azuriteFixture.GetAzureAccount().QueueEndpoint + "/" + queueName);
            endpointUriBuilder.Scheme = "net.aqs";
            var endpointUrlString = endpointUriBuilder.Uri.AbsoluteUri;

            Azure.Storage.WCF.AzureQueueStorageBinding azureQueueStorageBinding = new Azure.Storage.WCF.AzureQueueStorageBinding(connectionString, Azure.Storage.WCF.AzureQueueStorageMessageEncoding.Text);
            var channelFactory = new System.ServiceModel.ChannelFactory<ITestContract_EndToEndTest>(azureQueueStorageBinding, new System.ServiceModel.EndpointAddress(endpointUrlString));

            channelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
            };

            var channel = channelFactory.CreateChannel();
            ((System.ServiceModel.Channels.IChannel)channel).Open();
            channel.Create("TestService_EndToEnd");

            var testService = host.Services.GetRequiredService<TestService_EndToEnd>();
            Assert.True(testService.ManualResetEvent.Wait(System.TimeSpan.FromSeconds(5)));
            Assert.AreEqual("TestService_EndToEnd", testService.ReceivedName);
        }
    }
}
#endif