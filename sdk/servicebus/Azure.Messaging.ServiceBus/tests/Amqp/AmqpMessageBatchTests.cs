// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.That(() => new AmqpMessageBatch(new CreateBatchOptions { MaximumSizeInBytes = null }), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheMaximumSize()
        {
            var maximumSize = 9943;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };

            var batch = new AmqpMessageBatch(options);
            Assert.That(batch.MaximumSizeInBytes, Is.EqualTo(maximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesTheMessage()
        {
            var batch = new AmqpMessageBatch(new CreateBatchOptions { MaximumSizeInBytes = 25 });
            Assert.That(() => batch.TryAdd(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesNotDisposed()
        {
            var batch = new AmqpMessageBatch(new CreateBatchOptions { MaximumSizeInBytes = 25 });
            batch.Dispose();

            Assert.That(() => batch.TryAdd(new ServiceBusMessage(new byte[0])), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddDoesNotAcceptAMessageBiggerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var batch = new AmqpMessageBatch(options);

            Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[50])), Is.False, "A message of the maximum size is too large due to the reserved overhead.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptsAMessageSmallerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };

            var batch = new AmqpMessageBatch(options);

            Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[0])), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptMessagesUntilTheMaximumSizeIsReached()
        {
            var maximumSize = 100;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var messages = new AmqpMessage[3];

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                if (index == messages.Length - 1)
                {
                    Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[10])), Is.False, "The final addition should not fit in the available space.");
                }
                else
                {
                    Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[10])), Is.True, $"The addition for index: { index } should fit and be accepted.");
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddSetsTheCount()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
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
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };

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
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var batchMessages = new ServiceBusMessage[5];

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < batchMessages.Length; ++index)
            {
                batchMessages[index] = new ServiceBusMessage(new byte[0]);
                batch.TryAdd(batchMessages[index]);
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
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheCount()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Dispose the batch and verify that each message has also been disposed.

            batch.Dispose();
            Assert.That(batch.Count, Is.EqualTo(0), "The count should have been cleared when the batch was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheSize()
        {
            var batch = new AmqpMessageBatch(new CreateBatchOptions { MaximumSizeInBytes = 99 });
            Assert.That(batch.TryAdd(new ServiceBusMessage(new byte[10])), Is.True);

            batch.Dispose();

            Assert.That(batch.SizeInBytes, Is.EqualTo(0));
        }
    }
}
