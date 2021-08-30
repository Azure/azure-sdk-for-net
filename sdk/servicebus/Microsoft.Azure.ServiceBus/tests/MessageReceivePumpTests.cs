// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class MessageReceivePumpTests : IDisposable
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task CompleteMessageIfNeededAsync_should_complete_with_autocomplete()
        {
            var (completeCalled, abandonCalled) = await CheckMessageResolution(true, false);
            Assert.True(completeCalled);
            Assert.False(abandonCalled);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task CompleteMessageIfNeededAsync_should_not_complete_without_autocomplete()
        {
            var (completeCalled, abandonCalled) = await CheckMessageResolution(false, false);
            Assert.False(completeCalled);
            Assert.False(abandonCalled);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task AbandonMessageIfNeededAsync_should_abandon_on_exception_with_autocomplete()
        {
            var (completeCalled, abandonCalled) = await CheckMessageResolution(true, true);
            Assert.False(completeCalled);
            Assert.True(abandonCalled);
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task AbandonMessageIfNeededAsync_should_not_abandon_on_exception_without_autocomplete()
        {
            var (completeCalled, abandonCalled) = await CheckMessageResolution(false, true);
            Assert.False(completeCalled);
            Assert.False(abandonCalled);
        }

        private async Task<(bool completeCalled, bool abandonCalled)> CheckMessageResolution(bool autoComplete, bool throwException)
        {
            var receiverCalled = false;
            var completeCalled = false;
            var abandonCalled = false;
            var exceptionReceived = false;

            var lockTokenGuid = new Guid("00000000-0000-0000-0000-000000000001");
            var receiver = new FakeMessageReceiver(
                async (int maxMessageCount, TimeSpan serverWaitTime) =>
                {
                    await Task.Delay(1); // Force the pump to release the thread

                    if (receiverCalled)
                    {
                        return Enumerable.Empty<Message>()
                            .ToList();
                    }

                    receiverCalled = true;

                    return new List<Message> { new Message { SystemProperties = new Message.SystemPropertiesCollection { SequenceNumber = 1, LockTokenGuid = lockTokenGuid } } };
                },
                (lockTokens) =>
                {
                    Assert.Contains(lockTokenGuid.ToString(), lockTokens);
                    completeCalled = true;
                    return Task.CompletedTask;
                },
                (lockToken, propertiesToModify) =>
                {
                    Assert.Equal(lockTokenGuid.ToString(), lockToken);
                    abandonCalled = true;
                    return Task.CompletedTask;
                });

            var exception = new Exception("Test exception");

            var pump = new MessageReceivePump(
                receiver,
                new MessageHandlerOptions(
                    (eventArgs) =>
                    {
                        if (eventArgs.Exception == exception)
                        {
                            exceptionReceived = true;
                        }
                        return Task.CompletedTask;
                    })
                {
                    AutoComplete = autoComplete
                },
                (message, cancellationToken) =>
                {
                    if (throwException)
                    {
                        throw exception;
                    }
                    return Task.CompletedTask;
                },
                new Uri("http://blah.com"),
                cancellationTokenSource.Token,
                default);

            pump.StartPump();

            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 8)
            {
                if (completeCalled)
                {
                    TestUtility.Log($"Complete Called.");
                    break;
                }
                if (exceptionReceived)
                {
                    TestUtility.Log($"Exception Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return (completeCalled, abandonCalled);
        }
    }
}
