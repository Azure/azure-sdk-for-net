// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Amqp;
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
            Assert.That(() => new ServiceBusMessageBatch(null, null), Throws.ArgumentNullException);
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
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);

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
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);

            Assert.That(batch.MaxSizeInBytes, Is.EqualTo(mockBatch.MaxSizeInBytes), "The maximum size should have been delegated.");
            Assert.That(batch.SizeInBytes, Is.EqualTo(mockBatch.SizeInBytes), "The size should have been delegated.");
            Assert.That(batch.Count, Is.EqualTo(mockBatch.Count), "The count should have been delegated.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);
            var message = new ServiceBusMessage(new byte[] { 0x21 });

            Assert.That(batch.TryAddMessage(message), Is.True, "The message should have been accepted.");
            Assert.That(mockBatch.TryAddCalledWith, Is.SameAs(message), "The message should have been passed with delegation.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.AsReadOnly{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);

            batch.AsReadOnly<string>();
            Assert.That(mockBatch.AsReadOnlyCalledWith, Is.EqualTo(typeof(string)), "The enumerable should delegated the requested type parameter.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="ServiceBusMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);

            batch.Dispose();
            Assert.That(mockBatch.DisposeInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);
            var message = new ServiceBusMessage(new byte[] { 0x21 });

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x21 })), Is.True, "The message should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept messages when locked.");

            batch.Unlock();
            Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, "The message should have been accepted after unlocking.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="AmqpMessageBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);
            var messageData = new ServiceBusMessage(new byte[] { 0x21 });

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x21 })), Is.True, "The message should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.Clear(), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept messages when locked.");

            batch.Unlock();
            batch.Clear();

            Assert.That(mockBatch.ClearInvoked, Is.True, "The batch should have been cleared after unlocking.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="AmqpMessageBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var mockDiagnostics = new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock");

            var batch = new ServiceBusMessageBatch(mockBatch, mockDiagnostics);

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[] { 0x21 })), Is.True, "The message should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.Dispose(), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept messages when locked.");

            batch.Unlock();
            batch.Dispose();

            Assert.That(mockBatch.DisposeInvoked, Is.True, "The batch should have been disposed after unlocking.");
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
                    .GetField("_innerBatch", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Allows for the transport message batch created by a client to be injected for testing purposes.
        /// </summary>
        ///
        private class MockTransportBatch : TransportMessageBatch
        {
            public bool DisposeInvoked = false;
            public bool ClearInvoked = false;
            public Type AsReadOnlyCalledWith = null;
            public ServiceBusMessage TryAddCalledWith = null;

            public override long MaxSizeInBytes { get; } = 200;
            public override long SizeInBytes { get; } = 100;
            public override int Count { get; } = 300;
            public override void Dispose() => DisposeInvoked = true;
            public override void Clear() => ClearInvoked = true;

            public override bool TryAddMessage(ServiceBusMessage message)
            {
                TryAddCalledWith = message;
                return true;
            }

            public override IReadOnlyCollection<T> AsReadOnly<T>()
            {
                AsReadOnlyCalledWith = typeof(T);
                return default;
            }
        }
    }
}
