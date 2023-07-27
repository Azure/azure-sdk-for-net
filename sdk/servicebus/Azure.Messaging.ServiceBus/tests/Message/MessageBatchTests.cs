// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Message
{
    public class MessageBatchTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusModelFactory.ServiceBusMessageBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataBatchRespectsTheTryAddCallback()
        {
            var eventLimit = 3;
            var store = new List<ServiceBusMessage>();
            var batch = ServiceBusModelFactory.ServiceBusMessageBatch(5, store, tryAddCallback: _ => store.Count < eventLimit);

            while (store.Count < eventLimit)
            {
                Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new BinaryData("Test"))), Is.True, $"The batch contains { store.Count } events; adding another should be permitted.");
            }

            Assert.That(store.Count, Is.EqualTo(eventLimit), "The batch should be at its limit.");
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new BinaryData("Too many"))), Is.False, "The batch is full; it should not be possible to add a new event.");
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new BinaryData("Too many"))), Is.False, "The batch is full; a second attempt to add a new event should not succeed.");

            Assert.That(store.Count, Is.EqualTo(eventLimit), "The batch should be at its limit after the failed TryAdd attempts.");
            Assert.That(batch.AsReadOnly<ServiceBusMessage>(), Is.EquivalentTo(store), "The batch enumerable should reflect the events in the backing store.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusModelFactory.ServiceBusMessageBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void EventDataBatchIsSafeToDispose()
        {
            var size = 1024;
            var store = new List<ServiceBusMessage> { new ServiceBusMessage(Array.Empty<byte>()), new ServiceBusMessage(Array.Empty<byte>()) };
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 2048 };
            var batch = ServiceBusModelFactory.ServiceBusMessageBatch(size, store, options, _ => false);

            Assert.That(() => batch.Dispose(), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusModelFactory.ServiceBusMessageBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ServiceBusMessageBatchRespectsTheTryAddCallback()
        {
            var numMessages = 3;
            var converter = new AmqpMessageConverter();
            var store = new List<ServiceBusMessage>();
            var amqpMessages = new List<AmqpMessage>();
            var batch = ServiceBusModelFactory.ServiceBusMessageBatch(500, store, tryAddCallback: _ => store.Count < numMessages);

            while (store.Count < numMessages)
            {
                var serviceBusMessage = new ServiceBusMessage(new BinaryData("Test"));
                Assert.That(() => batch.TryAddMessage(serviceBusMessage), Is.True, $"The batch contains {store.Count} events; adding another should be permitted.");

                amqpMessages.Add(converter.SBMessageToAmqpMessage(serviceBusMessage));
            }

            Assert.That(store.Count, Is.EqualTo(numMessages), "The batch should be at its limit.");
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new BinaryData("Too many"))), Is.False, "The batch is full; it should not be possible to add a new event.");
            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new BinaryData("Too many"))), Is.False, "The batch is full; a second attempt to add a new event should not succeed.");

            Assert.That(store.Count, Is.EqualTo(numMessages), "The batch should be at its limit after the failed TryAdd attempts.");
            Assert.That(batch.AsReadOnly<AmqpMessage>().Count, Is.EqualTo(numMessages), "The messages produced by the batch should match the limit.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusModelFactory.ServiceBusMessageBatch" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ServiceBusMessageBatchIsSafeToDispose()
        {
            var size = 1024;
            var store = new List<ServiceBusMessage> { new ServiceBusMessage(new BinaryData(Array.Empty<byte>())), new ServiceBusMessage(new BinaryData(Array.Empty<byte>())) };
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 2048 };
            var batch = ServiceBusModelFactory.ServiceBusMessageBatch(size, store, options, _ => false);

            Assert.That(() => batch.Dispose(), Throws.Nothing);
        }
    }
}
