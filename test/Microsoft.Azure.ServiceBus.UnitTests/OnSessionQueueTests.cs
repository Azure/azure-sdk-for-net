// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class OnSessionQueueTests
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { TestConstants.SessionNonPartitionedQueueName, 1 },
            new object[] { TestConstants.SessionNonPartitionedQueueName, 5 },
            new object[] { TestConstants.SessionPartitionedQueueName, 1 },
            new object[] { TestConstants.SessionPartitionedQueueName, 5 },
        };

        public static IEnumerable<object> PartitionedNonPartitionedTestPermutations => new object[]
        {
            new object[] { TestConstants.SessionNonPartitionedQueueName, 5 },
            new object[] { TestConstants.SessionPartitionedQueueName, 5 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnSessionPeekLockWithAutoCompleteTrue(string queueName, int maxConcurrentCalls)
        {
            await this.OnSessionTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnSessionPeekLockWithAutoCompleteFalse(string queueName, int maxConcurrentCalls)
        {
            await this.OnSessionTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Theory]
        [MemberData(nameof(PartitionedNonPartitionedTestPermutations))]
        [DisplayTestMethodName]
        async Task OnSessionReceiveDelete(string queueName, int maxConcurrentCalls)
        {
            await this.OnSessionTestAsync(queueName, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task OnSessionCanStartWithNullMessageButReturnSessionLater()
        {
            var queueClient = new QueueClient(
                        TestUtility.NamespaceConnectionString,
                        TestConstants.SessionNonPartitionedQueueName,
                        ReceiveMode.PeekLock);
            try
            {
                SessionHandlerOptions handlerOptions =
                    new SessionHandlerOptions(ExceptionReceivedHandler)
                    {
                        MaxConcurrentSessions = 5,
                        MessageWaitTimeout = TimeSpan.FromSeconds(5),
                        AutoComplete = true
                    };

                TestSessionHandler testSessionHandler = new TestSessionHandler(
                    queueClient.ReceiveMode,
                    handlerOptions,
                    queueClient.InnerSender,
                    queueClient.SessionPumpHost);

                // Register handler first without any messages
                testSessionHandler.RegisterSessionHandler(handlerOptions);

                // Send messages to Session
                await testSessionHandler.SendSessionMessages();

                // Verify messages were received.
                await testSessionHandler.VerifyRun();

                // Clear the data and re-run the scenario.
                testSessionHandler.ClearData();
                await testSessionHandler.SendSessionMessages();

                // Verify messages were received.
                await testSessionHandler.VerifyRun();
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task OnSessionExceptionHandlerCalledWhenRegisteredOnNonSessionFulQueue()
        {
            bool exceptionReceivedHandlerCalled = false;
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName);

            SessionHandlerOptions sessionHandlerOptions = new SessionHandlerOptions(
            (eventArgs) =>
            {
                Assert.NotNull(eventArgs);
                Assert.NotNull(eventArgs.Exception);
                if (eventArgs.Exception is InvalidOperationException)
                {
                    exceptionReceivedHandlerCalled = true;
                }
                return Task.CompletedTask;
            })
            { MaxConcurrentSessions = 1 };

            queueClient.RegisterSessionHandler(
               (session, message, token) =>
               {
                   return Task.CompletedTask;
               },
               sessionHandlerOptions);

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 10)
            {
                if (exceptionReceivedHandlerCalled)
                {
                    break;
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Assert.True(exceptionReceivedHandlerCalled);
            await queueClient.CloseAsync();
        }

        async Task OnSessionTestAsync(string queueName, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            TestUtility.Log($"Queue: {queueName}, MaxConcurrentCalls: {maxConcurrentCalls}, Receive Mode: {mode.ToString()}, AutoComplete: {autoComplete}");
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, mode);
            try
            {
                SessionHandlerOptions handlerOptions =
                    new SessionHandlerOptions(ExceptionReceivedHandler)
                    {
                        MaxConcurrentSessions = maxConcurrentCalls,
                        MessageWaitTimeout = TimeSpan.FromSeconds(5),
                        AutoComplete = autoComplete
                    };

                TestSessionHandler testSessionHandler = new TestSessionHandler(
                    queueClient.ReceiveMode,
                    handlerOptions,
                    queueClient.InnerSender,
                    queueClient.SessionPumpHost);

                // Send messages to Session first
                await testSessionHandler.SendSessionMessages();

                // Register handler
                testSessionHandler.RegisterSessionHandler(handlerOptions);

                // Verify messages were received.
                await testSessionHandler.VerifyRun();
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs eventArgs)
        {
            TestUtility.Log($"Exception Received: ClientId: {eventArgs.ExceptionReceivedContext.ClientId}, EntityPath: {eventArgs.ExceptionReceivedContext.EntityPath}, Exception: {eventArgs.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}