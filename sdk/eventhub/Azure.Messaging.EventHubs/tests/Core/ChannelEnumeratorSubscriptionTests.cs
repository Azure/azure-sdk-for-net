// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ChannelEnumerableSubscription{T}" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class ChannelEnumeratorSubscriptionTests
    {
        /// <summary>
        ///   A delegate signature for use as a callback when mocking methods, such as
        ///   <see cref="ChannelReader{T}.TryRead(out T)"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of parameter being used for the out parameter.</typeparam>
        ///
        /// <param name="item">The item to modify.</param>
        ///
        private delegate void ReturnOutParam<T>(out T item);

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheReader()
        {
            Assert.That(() => new ChannelEnumerableSubscription<int>(null, TimeSpan.FromSeconds(1), () => Task.CompletedTask, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheWaitTime()
        {
            Assert.That(() => new ChannelEnumerableSubscription<int>(Mock.Of<ChannelReader<int>>(), TimeSpan.FromSeconds(-1), () => Task.CompletedTask, CancellationToken.None), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheUnsubscribeCallback()
        {
            Assert.That(() => new ChannelEnumerableSubscription<int>(Mock.Of<ChannelReader<int>>(), TimeSpan.FromSeconds(1), null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorAllowsNullWaitTime()
        {
            Assert.That(() => new ChannelEnumerableSubscription<int>(Mock.Of<ChannelReader<int>>(), null, () => Task.CompletedTask, CancellationToken.None), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorAllowsZeroWaitTime()
        {
            Assert.That(() => new ChannelEnumerableSubscription<int>(Mock.Of<ChannelReader<int>>(), TimeSpan.Zero, () => Task.CompletedTask, CancellationToken.None), Throws.Nothing);
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorInvokesUnsubscribeOnDispose()
        {
            var unsubscribeCalled = false;
            var mockReader = Mock.Of<ChannelReader<int>>();

            Func<Task> unsubscribeAsync = () =>
            {
                unsubscribeCalled = true;
                return Task.CompletedTask;
            };

            var subscription = new ChannelEnumerableSubscription<int>(mockReader, null, unsubscribeAsync, CancellationToken.None);
            await subscription.DisposeAsync();

            Assert.That(unsubscribeCalled, Is.True);
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorDoesNotCreateEnumerableIfDisposed()
        {
            var mockReader = Mock.Of<ChannelReader<int>>();
            var subscription = new ChannelEnumerableSubscription<int>(mockReader, null, () => Task.CompletedTask, CancellationToken.None);

            await subscription.DisposeAsync();
            Assert.That(() => subscription.GetAsyncEnumerator(), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorCreatesEnumerable()
        {
            var mockReader = Mock.Of<ChannelReader<int>>();

            await using (var subscription = new ChannelEnumerableSubscription<int>(mockReader, null, () => Task.CompletedTask, CancellationToken.None))
            await using (var enumerator = subscription.GetAsyncEnumerator())
            {

                Assert.That(enumerator, Is.Not.Null);
            }
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task DisposingEnumeratorDisposesEnumerable()
        {
            var unsubscribeCalled = false;
            var mockReader = Mock.Of<ChannelReader<int>>();

            Func<Task> unsubscribeAsync = () =>
            {
                unsubscribeCalled = true;
                return Task.CompletedTask;
            };

            await using (var subscription = new ChannelEnumerableSubscription<int>(mockReader, null, unsubscribeAsync, CancellationToken.None))
            {
                var enumerator = subscription.GetAsyncEnumerator();
                await enumerator.DisposeAsync();

                Assert.That(unsubscribeCalled, Is.True, "The unsubscribe callback should have been invoked.");
                Assert.That(() => subscription.GetAsyncEnumerator(), Throws.InstanceOf<ObjectDisposedException>(), "The enumerable should have been disposed.");
            }
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorReadsChannel()
        {
            var disposed = false;
            var channelIndex = -1;
            var readIndex = 0;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var readItems = new List<int>();
            var mockReader = new Mock<ChannelReader<int>>();

            Func<Task> disposeCallback = () =>
            {
                disposed = true;
                return Task.CompletedTask;
            };

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(() => Thread.Sleep(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback((ReturnOutParam<int>)((out int current) => current = channelItems[++channelIndex]))
                .Returns(() => channelIndex < channelItems.Length);

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var subscription = new ChannelEnumerableSubscription<int>(mockReader.Object, null, disposeCallback, CancellationToken.None);

            await foreach (var item in subscription)
            {
                readItems.Add(item);
                ++readIndex;

                if (readIndex >= channelItems.Length)
                {
                    break;
                }
            }

            Assert.That(readItems, Is.EquivalentTo(channelItems), "The items read should match the channel items.");
            Assert.That(disposed, Is.True, "The subscription should have been disposed.");
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorRespectsTheCancellationToken()
        {
            var disposed = false;
            var channelIndex = -1;
            var readIndex = 0;
            var maxReadItems = 1;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var readCancellation = new CancellationTokenSource();
            var mockReader = new Mock<ChannelReader<int>>();

            Func<Task> disposeCallback = () =>
            {
                disposed = true;
                return Task.CompletedTask;
            };

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(() => Thread.Sleep(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback((ReturnOutParam<int>)((out int current) => current = channelItems[++channelIndex]))
                .Returns(() => (channelIndex < channelItems.Length));

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var subscription = new ChannelEnumerableSubscription<int>(mockReader.Object, null, disposeCallback, readCancellation.Token);

            await foreach (var item in subscription)
            {
                ++readIndex;

                if (readIndex >= maxReadItems)
                {
                    readCancellation.Cancel();
                }

                if (readIndex >= channelItems.Length)
                {
                    break;
                }
            }

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.True, "Cancellation should have been requested.");
            Assert.That(readIndex, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
            Assert.That(disposed, Is.True, "The subscription should have been disposed.");
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorRespectsTheMaximumWaitTime()
        {
            var disposed = false;
            var forcedAbort = false;
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 2;
            var currentItem = 0;
            var maxWaitTime = TimeSpan.FromMilliseconds(25);
            var cancelTimeout = TimeSpan.FromMilliseconds(280);
            var abortTimeout = cancelTimeout.Add(TimeSpan.FromSeconds(1));
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

            Func<Task> disposeCallback = () =>
            {
                disposed = true;
                return Task.CompletedTask;
            };

            var channelReadCallback = (ReturnOutParam<int>)((out int current) =>
            {
                if (channelIndex < channelItems.Length - 1)
                {
                    ++channelIndex;
                }

                current = channelItems[channelIndex];
            });

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(async () => await Task.Delay(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback(channelReadCallback)
                .Returns(() =>
                {
                    Thread.Sleep(maxWaitTime);
                    return channelIndex < maxReadItems;
                });

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var readCancellation = new CancellationTokenSource(cancelTimeout);
            var subscription = new ChannelEnumerableSubscription<int>(mockReader.Object, maxWaitTime, disposeCallback, readCancellation.Token);
            var stopWatch = Stopwatch.StartNew();

            await foreach (var item in subscription)
            {
                ++iterateCount;

                if (item != default)
                {
                    ++readCount;
                }

                if (stopWatch.Elapsed > abortTimeout)
                {
                    forcedAbort = true;
                    break;
                }
            }

            stopWatch.Stop();

            // Due to the random delay applied while waiting for items without the maximum wait time, the
            // actual iteration count is non-deterministic.  It is known, however, that it will be greater than the
            // channel read count, as the wait time accounts for the maximum random period; at least one default item
            // will be emitted.

            Assert.That(forcedAbort, Is.False, "The timeout should have occurred due to the cancellation token, not have been forced.");
            Assert.That(readCancellation.Token.IsCancellationRequested, Is.True, "Cancellation should have been requested.");
            Assert.That(readCount, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
            Assert.That(iterateCount, Is.GreaterThan(readCount), "There should have been default items returned due to the wait time expiring.");
            Assert.That(stopWatch.Elapsed, Is.EqualTo(cancelTimeout).Within(TimeSpan.FromSeconds(2)), "The elapsed time should be close to the duration set for the cancel timeout.");
            Assert.That(disposed, Is.True, "The subscription should have been disposed.");
        }

        /// <summary>
        ///     Verifies functionality of the subscription's
        ///     enumerator.
        /// </summary>
        ///
        [Test]
        public async Task EnumeratorRespectsWhenThereIsNoMaximumWaitTime()
        {
            var disposed = false;
            var forcedAbort = false;
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 2;
            var currentItem = 0;
            var cancelTimeout = TimeSpan.FromMilliseconds(280);
            var abortTimeout = cancelTimeout.Add(TimeSpan.FromSeconds(1));
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

            Func<Task> disposeCallback = () =>
            {
                disposed = true;
                return Task.CompletedTask;
            };

            var channelReadCallback = (ReturnOutParam<int>)((out int current) =>
            {
                if (channelIndex < channelItems.Length - 1)
                {
                    ++channelIndex;
                }

                current = channelItems[channelIndex];
            });

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(() => Thread.Sleep(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback(channelReadCallback)
                .Returns(() => channelIndex < maxReadItems);

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var readCancellation = new CancellationTokenSource(cancelTimeout);
            var subscription = new ChannelEnumerableSubscription<int>(mockReader.Object, null, disposeCallback, readCancellation.Token);
            var stopWatch = Stopwatch.StartNew();

            await foreach (var item in subscription)
            {
                ++iterateCount;

                if (item != default)
                {
                    ++readCount;
                }

                if (stopWatch.Elapsed > abortTimeout)
                {
                    forcedAbort = true;
                    break;
                }
            }

            stopWatch.Stop();

            Assert.That(forcedAbort, Is.False, "The timeout should have occurred due to the cancellation token, not have been forced.");
            Assert.That(readCancellation.Token.IsCancellationRequested, Is.True, "Cancellation should have been requested.");
            Assert.That(readCount, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
            Assert.That(iterateCount, Is.EqualTo(readCount), "There should have been no items returned; all iterations should have been reading actual values.");
            Assert.That(stopWatch.Elapsed, Is.EqualTo(cancelTimeout).Within(TimeSpan.FromSeconds(2)), "The elapsed time should be close to the duration set for the cancel timeout.");
            Assert.That(disposed, Is.True, "The subscription should have been disposed.");
        }
    }
}
