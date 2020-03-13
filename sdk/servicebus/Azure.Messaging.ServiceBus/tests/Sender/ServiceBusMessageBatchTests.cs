// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.ServiceBus.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Sender
{
    /// <summary>
    ///   The suite of tests for the <see cref="ServiceBusMessageBatch" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ServiceBusMessageBatchTests
    {
        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorVerifiesTheTransportBatch()
        {
            Assert.That(() => new ServiceBusMessageBatch(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorUpdatesState()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new ServiceBusMessageBatch(mockBatch);

            Assert.That(GetInnerBatch(batch), Is.SameAs(mockBatch), "The inner transport batch should have been set.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public void PropertyAccessIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new ServiceBusMessageBatch(mockBatch);

            Assert.That(batch.MaximumSizeInBytes, Is.EqualTo(mockBatch.MaximumSizeInBytes), "The maximum size should have been delegated.");
            Assert.That(batch.SizeInBytes, Is.EqualTo(mockBatch.SizeInBytes), "The size should have been delegated.");
            Assert.That(batch.Count, Is.EqualTo(mockBatch.Count), "The count should have been delegated.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new ServiceBusMessageBatch(mockBatch);
            var message = new ServiceBusMessage(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(message), Is.True, "The message should have been accepted.");
            Assert.That(mockBatch.TryAddCalledWith, Is.SameAs(message), "The message should have been passed with delegation.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.AsEnumerable" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsEnumerableIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new ServiceBusMessageBatch(mockBatch);

            batch.AsEnumerable<string>();
            Assert.That(mockBatch.AsEnumerableCalledWith, Is.EqualTo(typeof(string)), "The enumerable should delegated the requested type parameter.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new ServiceBusMessageBatch(mockBatch);

            batch.Dispose();
            Assert.That(mockBatch.DisposeInvoked, Is.True);
        }

        /// <summary>
        ///   Retrieves the inner transport batch from an <see cref="ServiceBusMessageBatch" />
        ///   using its private accessors.
        /// </summary>
        ///
        /// <param name="batch">The batch to retrieve the inner transport batch from.</param>
        ///
        /// <returns>The inner transport batch.</returns>
        ///
        private static TransportMessageBatch GetInnerBatch(ServiceBusMessageBatch batch) =>
            (TransportMessageBatch)
                typeof(ServiceBusMessageBatch)
                    .GetProperty("InnerBatch", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Allows for the transport message batch created by a client to be injected for testing purposes.
        /// </summary>
        ///
        private class MockTransportBatch : TransportMessageBatch
        {
            public bool DisposeInvoked = false;
            public Type AsEnumerableCalledWith = null;
            public ServiceBusMessage TryAddCalledWith = null;

            public override long MaximumSizeInBytes { get; } = 200;
            public override long SizeInBytes { get; } = 100;
            public override int Count { get; } = 300;

            public override void Dispose()
            {
                DisposeInvoked = true;
            }

            public override bool TryAdd(ServiceBusMessage message)
            {
                TryAddCalledWith = message;
                return true;
            }

            public override IEnumerable<T> AsEnumerable<T>()
            {
                AsEnumerableCalledWith = typeof(T);
                return default;
            }
        }
    }
}
