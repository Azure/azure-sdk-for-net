// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class IntegrationTests_ReceiveMessage_Success
    {
        private IHost host;

        [SetUp]
        public void Setup()
        {
            host = ServiceHelper.CreateHost<Startup_ReceiveMessage_Success>();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public async Task DefaultQueueConfiguration_ReceiveMessage_Success()
        {
            var queue = host.Services.GetRequiredService<QueueClient>();
            await queue.SendMessageAsync("<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://tempuri.org/ITestContract/Create</a:Action></s:Header><s:Body><Create xmlns=\"http://tempuri.org/\"><name>test</name></Create></s:Body></s:Envelope>");

            var testService = host.Services.GetRequiredService<TestService>();
            Assert.True(testService.ManualResetEvent.Wait(System.TimeSpan.FromSeconds(5)));
        }
    }
}
