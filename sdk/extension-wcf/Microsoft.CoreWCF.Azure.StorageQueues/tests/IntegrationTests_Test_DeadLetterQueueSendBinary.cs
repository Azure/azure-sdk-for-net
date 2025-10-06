// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using CoreWCF;
using CoreWCF.Channels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class IntegrationTests_Test_DeadLetterQueueSendBinary
    {
        private IWebHost host;

        [SetUp]
        public void Setup()
        {
            host = ServiceHelper.CreateWebHostBuilder<Startup_TextServiceQueueBinaryClientQueue>().Build();
            host.Start();
        }

        [TearDown]
        public void TearDown()
        {
            host.StopAsync().Wait();
            host.Dispose();
        }

        [Test]
        public async Task Test_DeadLetterQueueTextServiceQueueBinaryClientQueue()
        {
            var queue = host.Services.GetRequiredService<QueueClient>();
            var body = XDocument.Parse("<Create xmlns=\"http://tempuri.org/\"><name>test</name></Create>");
            var message = Message.CreateMessage(MessageVersion.CreateVersion(EnvelopeVersion.Soap12), "http://tempuri.org/ITestContract/Create", body.CreateReader());
            var bmebe = new BinaryMessageEncodingBindingElement();
            var encoderFactory = bmebe.CreateMessageEncoderFactory();
            var bufferManager = BufferManager.CreateBufferManager(64 * 1024, 64 * 1024);
            ReadOnlyMemory<byte> encodedMessage = encoderFactory.Encoder.WriteMessage(message, int.MaxValue, bufferManager);
            BinaryData queueBody = new BinaryData(encodedMessage);
            var receipt = await queue.SendMessageAsync(queueBody);
            var testService = host.Services.GetRequiredService<TestService>();
            Assert.False(testService.ManualResetEvent.Wait(TimeSpan.FromSeconds(5)));
            var connectionString = AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString;
            QueueClient queueClient = TestHelper.GetQueueClient(AzuriteNUnitFixture.Instance.GetTransport(), connectionString, Startup_TextServiceQueueBinaryClientQueue.DlqQueueName, QueueMessageEncoding.Base64);
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var response = await queueClient.ReceiveMessageAsync(default, cts.Token);
            Assert.NotNull(response.Value);
            Assert.AreEqual(queueBody.ToArray(), response.Value.Body.ToArray());
        }
    }
}
