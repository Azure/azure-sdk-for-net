// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Executors;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessageProcessorTests
    {
        private readonly MessageProcessor _processor;

        public MessageProcessorTests()
        {
            var client = new ServiceBusClient("Endpoint = sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=");
            var processor = client.CreateProcessor("test-entity");
            processor.ProcessErrorAsync += ExceptionReceivedHandler;
            _processor = new MessageProcessor(processor);
        }

        [Test]
        public void CompleteProcessingMessageAsync_Failure_PropagatesException()
        {
            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage();
            var functionException = new InvalidOperationException("Kaboom!");
            FunctionResult result = new FunctionResult(functionException);
            var client = new ServiceBusClient("Endpoint = sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=");
            var actions = new ServiceBusMessageActions(client.CreateReceiver("test-entity"));
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _processor.CompleteProcessingMessageAsync(actions, message, result, CancellationToken.None);
            });

            Assert.AreSame(functionException, ex);
        }

        [Test]
        public async Task CompleteProcessingMessageAsync_DefaultOnMessageOptions()
        {
            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage();
            FunctionResult result = new FunctionResult(true);
            var client = new ServiceBusClient("Endpoint = sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=");
            var actions = new ServiceBusMessageActions(client.CreateReceiver("test-entity"));
            await _processor.CompleteProcessingMessageAsync(actions, message, result, CancellationToken.None);
        }

        private Task ExceptionReceivedHandler(ProcessErrorEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }
    }
}