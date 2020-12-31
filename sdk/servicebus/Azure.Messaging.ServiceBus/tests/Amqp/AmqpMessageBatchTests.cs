// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpMessageBatch" />
    ///   class.
    /// </summary>
    [TestFixture]
    public class AmqpMessageBatchTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new AmqpMessageBatch(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheMaximumSize()
        {
            Assert.That(() => new AmqpMessageBatch(new CreateMessageBatchOptions { MaxSizeInBytes = null }), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheMaximumSize()
        {
            var maximumSize = 9943;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };

            var batch = new AmqpMessageBatch(options);
            Assert.That(batch.MaxSizeInBytes, Is.EqualTo(maximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesTheMessage()
        {
            var batch = new AmqpMessageBatch(new CreateMessageBatchOptions { MaxSizeInBytes = 25 });
            Assert.That(() => batch.TryAddMessage(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesNotDisposed()
        {
            var batch = new AmqpMessageBatch(new CreateMessageBatchOptions { MaxSizeInBytes = 25 });
            batch.Dispose();

            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddDoesNotAcceptAMessageBiggerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };
            var batch = new AmqpMessageBatch(options);

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[50])), Is.False, "A message of the maximum size is too large due to the reserved overhead.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptsAMessageSmallerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };

            var batch = new AmqpMessageBatch(options);

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptMessagesUntilTheMaximumSizeIsReached()
        {
            var maximumSize = 100;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };
            var messages = new AmqpMessage[3];

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                if (index == messages.Length - 1)
                {
                    Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[10])), Is.False, "The final addition should not fit in the available space.");
                }
                else
                {
                    Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[10])), Is.True, $"The addition for index: { index } should fit and be accepted.");
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAddMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddSetsTheCount()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(messages.Length), "The count should have been set when the batch was updated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.AsEnumerable{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsEnumerableValidatesTheTypeParameter()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };

            var batch = new AmqpMessageBatch(options);
            Assert.That(() => batch.AsEnumerable<AmqpMessage>(), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.AsEnumerable{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsEnumerableReturnsTheMessages()
        {
            var maximumSize = 5000;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };
            var batchMessages = new ServiceBusMessage[5];

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < batchMessages.Length; ++index)
            {
                batchMessages[index] = new ServiceBusMessage(new byte[0]);
                batch.TryAddMessage(batchMessages[index]);
            }

            IEnumerable<ServiceBusMessage> batchEnumerable = batch.AsEnumerable<ServiceBusMessage>();
            Assert.That(batchEnumerable, Is.Not.Null, "The batch enumerable should have been populated.");

            var batchEnumerableList = batchEnumerable.ToList();
            Assert.That(batchEnumerableList.Count, Is.EqualTo(batch.Count), "The wrong number of messages was in the enumerable.");

            for (var index = 0; index < batchMessages.Length; ++index)
            {
                Assert.That(batchEnumerableList.Contains(batchMessages[index]), $"The message at index: { index } was not in the enumerable.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearClearsTheCount()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(messages.Length), "The count should have been set when the batch was updated.");

            batch.Clear();
            Assert.That(batch.Count, Is.Zero, "The count should have been set when the batch was cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearClearsTheSize()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.SizeInBytes, Is.GreaterThan(0), "The size should have been set when the batch was updated.");

            batch.Clear();
            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)), "The size should have been reset when the batch was cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheCount()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(messages.Length), "The count should have been set when the batch was updated.");

            batch.Dispose();
            Assert.That(batch.Count, Is.Zero, "The count should have been set when the batch was cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheSize()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.SizeInBytes, Is.GreaterThan(0), "The size should have been set when the batch was updated.");

            batch.Dispose();
            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)), "The size should have been reset when the batch was cleared.");
        }

        // <summary>
        ///   Reads the size reserved for AMQP message overhead in a batch using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        /// <returns>The reserved size of the batch.</returns>
        ///
        private static long GetReservedSize(AmqpMessageBatch instance) =>
            (long)
                typeof(AmqpMessageBatch)
                    .GetField("_reservedSize", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(instance);
    }
}
