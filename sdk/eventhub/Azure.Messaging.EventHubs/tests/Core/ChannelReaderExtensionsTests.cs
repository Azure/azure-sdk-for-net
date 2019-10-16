// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ChannelReaderExtensionsTests" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ChannelReaderExtensionsTests
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
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelValidatesTheReader()
        {
            await using IAsyncEnumerator<int> enumerator = ChannelReaderExtensions.EnumerateChannel<int>(null, TimeSpan.FromSeconds(1), CancellationToken.None).GetAsyncEnumerator();
            Assert.That(() => enumerator.MoveNextAsync(), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelValidatesTheWaitTime()
        {
            await using IAsyncEnumerator<int> enumerator = ChannelReaderExtensions.EnumerateChannel<int>(Mock.Of<ChannelReader<int>>(), TimeSpan.FromSeconds(-1), CancellationToken.None).GetAsyncEnumerator();
            Assert.That(() => enumerator.MoveNextAsync(), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelAllowsNullWaitTime()
        {
            await using IAsyncEnumerator<int> enumerator = ChannelReaderExtensions.EnumerateChannel<int>(Mock.Of<ChannelReader<int>>(), null, CancellationToken.None).GetAsyncEnumerator();
            Assert.That(() => enumerator.MoveNextAsync(), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelAllowsZeroWaitTime()
        {
            await using IAsyncEnumerator<int> enumerator = ChannelReaderExtensions.EnumerateChannel<int>(Mock.Of<ChannelReader<int>>(), TimeSpan.Zero, CancellationToken.None).GetAsyncEnumerator();
            Assert.That(() => enumerator.MoveNextAsync(), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelCreatesEnumerable()
        {
            ChannelReader<int> mockReader = Mock.Of<ChannelReader<int>>();
            IAsyncEnumerable<int> subscription = mockReader.EnumerateChannel<int>(null, CancellationToken.None);

            await using (IAsyncEnumerator<int> enumerator = subscription.GetAsyncEnumerator())
            {
                Assert.That(enumerator, Is.Not.Null);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task EnumerateChannelReadsChannel()
        {
            var channelIndex = -1;
            var readIndex = 0;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var readItems = new List<int>();
            var mockReader = new Mock<ChannelReader<int>>();

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(() => Thread.Sleep(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback((ReturnOutParam<int>)((out int current) => current = channelItems[++channelIndex]))
                .Returns(() => channelIndex < channelItems.Length);

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel<int>(null, CancellationToken.None);

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
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EnumerateChannelRespectsTheCancellationToken()
        {
            var channelIndex = -1;
            var readIndex = 0;
            var maxReadItems = 1;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var readCancellation = new CancellationTokenSource();
            var mockReader = new Mock<ChannelReader<int>>();

            mockReader
              .SetupGet(reader => reader.Completion)
              .Returns(new Task(() => Thread.Sleep(5)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback((ReturnOutParam<int>)((out int current) => current = channelItems[++channelIndex]))
                .Returns(() => (channelIndex < channelItems.Length));

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel(null, readCancellation.Token);

            Assert.That(async () =>
            {
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
            }, Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should result in an exception");

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.True, "Cancellation should have been requested.");
            Assert.That(readIndex, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EnumerateChannelRespectsTheMaximumWaitTime()
        {
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 2;
            var currentItem = 0;
            var maxWaitTime = TimeSpan.FromMilliseconds(1);
            var abortTimeout = TimeSpan.FromSeconds(15);
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

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
              .Returns(new Task(async () => await Task.Delay(10)));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback(channelReadCallback)
                .Returns(() =>
                {
                    return channelIndex < maxReadItems;
                });

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var readCancellation = new CancellationTokenSource(abortTimeout);
            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel(maxWaitTime, readCancellation.Token);

            Assert.That(async () =>
            {
                await foreach (var item in subscription)
                {
                    ++iterateCount;

                    if (item != default)
                    {
                        ++readCount;
                    }

                    if (iterateCount > maxReadItems)
                    {
                        break;
                    }
                }
            }, Throws.Nothing, "Iteration should have ended naturally, rather than by cancellation.");

            // Due to the random delay applied while waiting for items without the maximum wait time, the
            // actual iteration count is non-deterministic.  It is known, however, that it will be greater than the
            // channel read count, as the wait time accounts for the maximum random period; at least one default item
            // will be emitted.

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(readCount, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
            Assert.That(iterateCount, Is.GreaterThan(readCount), "There should have been default items returned due to the wait time expiring.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EnumerateChannelRespectsWhenThereIsNoMaximumWaitTime()
        {
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 3;
            var currentItem = 0;
            var cancelTimeout = TimeSpan.FromMilliseconds(300);
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

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
            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel(null, readCancellation.Token);

            Assert.That(async () =>
            {
                await foreach (var item in subscription)
                {
                    ++iterateCount;

                    if (item != default)
                    {
                        ++readCount;
                    }
                }
            }, Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should result in an exception");

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.True, "Cancellation should have been requested.");
            Assert.That(readCount, Is.EqualTo(maxReadItems), "The number of items read should have stopped increasing when cancellation was requested.");
            Assert.That(iterateCount, Is.EqualTo(readCount), "There should have been no items returned; all iterations should have been reading actual values.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(typeof(ChannelClosedException))]
        [TestCase(typeof(ArithmeticException))]
        [TestCase(typeof(IndexOutOfRangeException))]
        [TestCase(typeof(OperationCanceledException))]
        public void EnumerateChannelPropagatesChannelExceptions(Type exceptionType)
        {
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 2;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

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
                    if (channelIndex < maxReadItems)
                    {
                        return true;
                    };

                    throw (Exception)Activator.CreateInstance(exceptionType);
                });

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var readCancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel(null, readCancellation.Token);

            Assert.That(async () =>
            {
                await foreach (var item in subscription)
                {
                    ++iterateCount;

                    if (item != default)
                    {
                        ++readCount;
                    }
                }
            }, Throws.TypeOf(exceptionType), "Exceptions while reading the channel should propagate.");

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.False, "Iteration should have ended normally");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ChannelReaderExtensions.EnumerateChannel" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EnumerateChannelSurfacesChannelCancellation()
        {
            var channelIndex = -1;
            var readCount = 0;
            var iterateCount = 0;
            var maxReadItems = 2;
            var currentItem = 0;
            var channelItems = new[] { 1, 4, 7, 9 };
            var mockReader = new Mock<ChannelReader<int>>();

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
                .Returns(Task.FromException(new TaskCanceledException()));

            mockReader
                .Setup(reader => reader.TryRead(out currentItem))
                .Callback(channelReadCallback)
                .Returns(() =>
                {
                    return channelIndex < maxReadItems;
                });

            // Create the subscription and deliberately do not dispose; the common usage will be in immediate foreach call,
            // which should trigger disposal after iterating.

            var readCancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            IAsyncEnumerable<int> subscription = mockReader.Object.EnumerateChannel(null, readCancellation.Token);

            Assert.That(async () =>
            {
                await foreach (var item in subscription)
                {
                    ++iterateCount;

                    if (item != default)
                    {
                        ++readCount;
                    }
                }
            }, Throws.InstanceOf<TaskCanceledException>(), "Cancellation of the read operation should have been surfaced.");

            Assert.That(readCancellation.Token.IsCancellationRequested, Is.False, "Iteration should stopped due to exception.");
            Assert.That(readCount, Is.EqualTo(maxReadItems), "The items emitted before the exception should have been read.");
        }
    }
}
