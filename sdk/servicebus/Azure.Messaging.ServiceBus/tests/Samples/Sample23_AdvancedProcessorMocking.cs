// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Plugins;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample23_AdvancedProcessorMocking
    {
        [Test]
        public async Task RaiseProcessorEvents()
        {
            #region Snippet:ServiceBus_AdvancedProcessorMocking
            TestableServiceBusProcessor processor = new();
            string processedMessageId = null;
            bool errorHandled = false;

            Task MessageHandler(ProcessMessageEventArgs args)
            {
                processedMessageId = args.Message.MessageId;
                return Task.CompletedTask;
            }

            Task ErrorHandler(ProcessErrorEventArgs args)
            {
                errorHandled = true;
                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                ServiceBusReceivedMessage message =
                    ServiceBusModelFactory.ServiceBusReceivedMessage(messageId: "message-id");
                Mock<ServiceBusReceiver> receiver = new();

                ProcessMessageEventArgs messageArgs = new(
                    message,
                    receiver.Object,
                    CancellationToken.None);

                ProcessErrorEventArgs errorArgs = new(
                    new InvalidOperationException("Simulated processor error"),
                    ServiceBusErrorSource.Receive,
                    "namespace.servicebus.windows.net",
                    "queue-name",
                    CancellationToken.None);

                await processor.RaiseProcessMessageAsync(messageArgs);
                await processor.RaiseProcessErrorAsync(errorArgs);

                Assert.That(processedMessageId, Is.EqualTo("message-id"));
                Assert.That(errorHandled, Is.True);
            }
            finally
            {
                processor.ProcessMessageAsync -= MessageHandler;
                processor.ProcessErrorAsync -= ErrorHandler;
            }
            #endregion
        }

        [Test]
        public async Task RaiseSessionProcessorEvents()
        {
            #region Snippet:ServiceBus_AdvancedSessionProcessorMocking
            TestableServiceBusSessionProcessor processor = new();
            List<string> invokedHandlers = new();

            Task MessageHandler(ProcessSessionMessageEventArgs args)
            {
                invokedHandlers.Add($"message:{args.Message.MessageId}");
                return Task.CompletedTask;
            }

            Task ErrorHandler(ProcessErrorEventArgs args)
            {
                invokedHandlers.Add("error");
                return Task.CompletedTask;
            }

            Task SessionInitializingHandler(ProcessSessionEventArgs args)
            {
                invokedHandlers.Add($"opening:{args.SessionId}");
                return Task.CompletedTask;
            }

            Task SessionClosingHandler(ProcessSessionEventArgs args)
            {
                invokedHandlers.Add($"closing:{args.SessionId}");
                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                processor.SessionInitializingAsync += SessionInitializingHandler;
                processor.SessionClosingAsync += SessionClosingHandler;

                Mock<ServiceBusSessionReceiver> receiver = new();
                receiver.SetupGet(value => value.SessionId).Returns("session-id");

                ServiceBusReceivedMessage message =
                    ServiceBusModelFactory.ServiceBusReceivedMessage(
                        messageId: "message-id",
                        sessionId: "session-id");

                ProcessSessionMessageEventArgs messageArgs = new(
                    message,
                    receiver.Object,
                    CancellationToken.None);

                ProcessErrorEventArgs errorArgs = new(
                    new InvalidOperationException("Simulated processor error"),
                    ServiceBusErrorSource.Receive,
                    "namespace.servicebus.windows.net",
                    "queue-name",
                    CancellationToken.None);

                ProcessSessionEventArgs sessionArgs = new(
                    receiver.Object,
                    CancellationToken.None);

                await processor.RaiseSessionInitializingAsync(sessionArgs);
                await processor.RaiseProcessMessageAsync(messageArgs);
                await processor.RaiseProcessErrorAsync(errorArgs);
                await processor.RaiseSessionClosingAsync(sessionArgs);

                Assert.That(
                    invokedHandlers,
                    Is.EqualTo(new[]
                    {
                        "opening:session-id",
                        "message:message-id",
                        "error",
                        "closing:session-id"
                    }));
            }
            finally
            {
                processor.ProcessMessageAsync -= MessageHandler;
                processor.ProcessErrorAsync -= ErrorHandler;
                processor.SessionInitializingAsync -= SessionInitializingHandler;
                processor.SessionClosingAsync -= SessionClosingHandler;
            }
            #endregion
        }
    }
}
