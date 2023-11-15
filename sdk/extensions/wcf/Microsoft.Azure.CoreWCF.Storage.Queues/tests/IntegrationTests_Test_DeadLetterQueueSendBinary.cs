// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Contracts;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class IntegrationTests_Test_DeadLetterQueueSendBinary
    {
        private IWebHost host;

        [SetUp]
        public void Setup()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup_BinaryServiceQueueTextClientQueue>().Build();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public async Task Test_DeadLetterQueueBinaryServiceQueueTextClientQueue()
        {
            var queue = host.Services.GetRequiredService<QueueClient>();
            string inputMessage = "\"<s:Envelope xmlns:s=\\\"http://www.w3.org/2003/05/soap-envelope\\\" xmlns:a=\\\"http://www.w3.org/2005/08/addressing\\\"><s:Header><a:Action s:mustUnderstand=\\\"1\\\">http://tempuri.org/ITestContract/Create</a:Action></s:Header><s:Body><Create xmlns=\\\"http://tempuri.org/\\\"><name>test</name></Create></s:Body></s:Envelope>\"";
            var a = await queue.SendMessageAsync(inputMessage);

            var testService = host.Services.GetRequiredService<TestService>();
            Assert.False(testService.ManualResetEvent.Wait(System.TimeSpan.FromSeconds(5)));
            var connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            QueueClient queueClient = TestHelper.GetQueueClient(AzuriteNUnitFixture.Instance.GetTransport(),connectionString, "deadletter-queue-name", QueueMessageEncoding.None);
            QueueMessage message = await queueClient.ReceiveMessageAsync();
            Assert.AreEqual(inputMessage, message.MessageText);
        }
    }
}
