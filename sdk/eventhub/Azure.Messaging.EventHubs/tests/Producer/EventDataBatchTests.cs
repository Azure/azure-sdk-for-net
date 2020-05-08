// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventDataBatch" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventDataBatchTests
    {
        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorVerifiesTheTransportBatch()
        {
            Assert.That(() => new EventDataBatch(null, "ns", "eh", new SendEventOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorVerifiesTheFullyQualifiedNamespace(string fullyQualifiedNamespace)
        {
            Assert.That(() => new EventDataBatch(new MockTransportBatch(), fullyQualifiedNamespace, "eh", new SendEventOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorVerifiesTheEventHubName(string eventHubName)
        {
            Assert.That(() => new EventDataBatch(new MockTransportBatch(), "ns", eventHubName, new SendEventOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorVerifiesTheSendOptions()
        {
            Assert.That(() => new EventDataBatch(new MockTransportBatch(), "ns", "eh", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorUpdatesState()
        {
            var sendOptions = new SendEventOptions();
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", sendOptions);

            Assert.That(batch.SendOptions, Is.SameAs(sendOptions), "The send options should have been set.");
            Assert.That(GetInnerBatch(batch), Is.SameAs(mockBatch), "The inner transport batch should have been set.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch" />
        ///   class.
        /// </summary>
        ///
        [Test]
        public void PropertyAccessIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());

            Assert.That(batch.MaximumSizeInBytes, Is.EqualTo(mockBatch.MaximumSizeInBytes), "The maximum size should have been delegated.");
            Assert.That(batch.SizeInBytes, Is.EqualTo(mockBatch.SizeInBytes), "The size should have been delegated.");
            Assert.That(batch.Count, Is.EqualTo(mockBatch.Count), "The count should have been delegated.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(eventData), Is.True, "The event should have been accepted.");
            Assert.That(mockBatch.TryAddCalledWith.IsEquivalentTo(eventData), Is.True, "The event data should have been passed with delegation.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddClonesTheEvent()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(eventData), Is.True, "The event should have been accepted.");
            Assert.That(mockBatch.TryAddCalledWith.IsEquivalentTo(eventData), Is.True, "The event data should have been passed with delegation.");
            Assert.That(mockBatch.TryAddCalledWith, Is.Not.SameAs(eventData), "The event data should have been cloned.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.AsEnumerable" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsEnumerableIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());

            batch.AsEnumerable<string>();
            Assert.That(mockBatch.AsEnumerableCalledWith, Is.EqualTo(typeof(string)), "The enumerable should delegated the requested type parameter.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());

            batch.Dispose();
            Assert.That(mockBatch.DisposeInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearIsDelegatedToTheTransportClient()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());

            batch.Clear();
            Assert.That(mockBatch.ClearInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(new EventData(new byte[] { 0x21 })), Is.True, "The event should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.TryAdd(new EventData(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept events when locked.");

            batch.Unlock();
            Assert.That(batch.TryAdd(new EventData(Array.Empty<byte>())), Is.True, "The event should have been accepted after unlocking.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(new EventData(new byte[] { 0x21 })), Is.True, "The event should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.Clear(), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept events when locked.");
            Assert.That(mockBatch.ClearInvoked, Is.False, "The batch should not have permitted the operation while locked.");

            batch.Unlock();
            batch.Clear();

            Assert.That(mockBatch.ClearInvoked, Is.True, "The batch should have been cleared after unlocking.");
        }

        /// <summary>
        ///   Verifies property accessors for the <see cref="EventDataBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeRespectsTheBatchLock()
        {
            var mockBatch = new MockTransportBatch();
            var batch = new EventDataBatch(mockBatch, "ns", "eh", new SendEventOptions());
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(new EventData(new byte[] { 0x21 })), Is.True, "The event should have been accepted before locking.");

            batch.Lock();
            Assert.That(() => batch.Dispose(), Throws.InstanceOf<InvalidOperationException>(), "The batch should not accept events when locked.");
            Assert.That(mockBatch.DisposeInvoked, Is.False, "The batch should not have permitted the operation while locked.");

            batch.Unlock();
            batch.Dispose();

            Assert.That(mockBatch.DisposeInvoked, Is.True, "The batch should have been disposed after unlocking.");
        }

        /// <summary>
        ///   Retrieves the inner transport batch from an <see cref="EventDataBatch" />
        ///   using its private accessors.
        /// </summary>
        ///
        /// <param name="batch">The batch to retrieve the inner transport batch from.</param>
        ///
        /// <returns>The inner transport batch.</returns>
        ///
        private static TransportEventBatch GetInnerBatch(EventDataBatch batch) =>
            (TransportEventBatch)
                typeof(EventDataBatch)
                    .GetProperty("InnerBatch", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Allows for the transport event batch created by a client to be injected for testing purposes.
        /// </summary>
        ///
        private class MockTransportBatch : TransportEventBatch
        {
            public bool DisposeInvoked = false;
            public bool ClearInvoked = false;
            public Type AsEnumerableCalledWith = null;
            public EventData TryAddCalledWith = null;

            public override long MaximumSizeInBytes { get; } = 200;
            public override long SizeInBytes { get; } = 100;
            public override int Count { get; } = 300;

            public override void Clear() => ClearInvoked = true;

            public override void Dispose() => DisposeInvoked = true;

            public override bool TryAdd(EventData eventData)
            {
                TryAddCalledWith = eventData;
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
