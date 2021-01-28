// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.Executors;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessageProcessorTests
    {
        private readonly MessageProcessor _processor;
        private readonly MessageHandlerOptions _options;

        public MessageProcessorTests()
        {
            _options = new MessageHandlerOptions(ExceptionReceivedHandler);
            MessageReceiver receiver = new MessageReceiver("Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=", "test-entity");
            _processor = new MessageProcessor(receiver, _options);
        }

        [Test]
        public void CompleteProcessingMessageAsync_Failure_PropagatesException()
        {
            _options.AutoComplete = false;

            Message message = new Message();
            var functionException = new InvalidOperationException("Kaboom!");
            FunctionResult result = new FunctionResult(functionException);
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);
            });

            Assert.AreSame(functionException, ex);
        }

        [Test]
        public async Task CompleteProcessingMessageAsync_DefaultOnMessageOptions()
        {
            Message message = new Message();
            FunctionResult result = new FunctionResult(true);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);
        }

        [Test]
        public void MessageOptions_ReturnsOptions()
        {
            Assert.AreSame(_options, _processor.MessageOptions);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            return Task.CompletedTask;
        }
    }
}