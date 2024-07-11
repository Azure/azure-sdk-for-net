// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Moq;
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };
            Assert.That(() => new AmqpMessageBatch(mockMessageConverter, null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheMaximumSize()
        {
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };
            Assert.That(() => new AmqpMessageBatch(mockMessageConverter, new CreateMessageBatchOptions { MaxSizeInBytes = null }), Throws.ArgumentNullException);
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };

            var batch = new AmqpMessageBatch(mockMessageConverter, options);
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };
            var batch = new AmqpMessageBatch(mockMessageConverter, new CreateMessageBatchOptions { MaxSizeInBytes = 25 });
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };
            var batch = new AmqpMessageBatch(mockMessageConverter, new CreateMessageBatchOptions { MaxSizeInBytes = 25 });

            batch.Dispose();

            Assert.That(() => batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Throws.InstanceOf<ObjectDisposedException>());
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
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => mockMessage.Object
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(maximumSize);

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

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
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => mockMessage.Object
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True);
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
            var currentIndex = -1;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };
            var messages = new AmqpMessage[3];
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(40);

            for (var index = 0; index < messages.Length; ++index)
            {
                var size = 40;
                var messageToAdd = new Mock<AmqpMessage>();
                messageToAdd.Setup(messageToAdd => messageToAdd.SerializedMessageSize).Returns(size);
                messages[index] = messageToAdd.Object;
            }

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

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
        public void TryAdRespectsTheMaximumMessageCount()
        {
            var maximumCount = 5;
            var currentIndex = -1;
            var messages = new AmqpMessage[maximumCount + 1];
            var mockMessage = new Mock<AmqpMessage>();

            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(40);

            var options = new CreateMessageBatchOptions
            {
                MaxSizeInBytes = 50000,
                MaxMessageCount = maximumCount
            };

            for (var index = 0; index < messages.Length; ++index)
            {
                var size = 40;
                var messageToAdd = new Mock<AmqpMessage>();
                messageToAdd.Setup(messageToAdd => messageToAdd.SerializedMessageSize).Returns(size);
                messages[index] = messageToAdd.Object;
            }

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

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
            var currentIndex = -1;
            var messages = new AmqpMessage[5];
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter()
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(messages.Length), "The count should have been set when the batch was updated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.AsList{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyValidatesTheTypeParameter()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };

            var batch = new AmqpMessageBatch(mockMessageConverter, options);
            Assert.That(() => batch.AsReadOnly<AmqpMessageBatch>(), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.AsList{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyReturnsTheMessages()
        {
            var maximumSize = 5000;
            var currentIndex = -1;
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = maximumSize };
            var amqpMessages = new AmqpMessage[5];
            var serviceBusMessages = new ServiceBusMessage[5];
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => amqpMessages[++currentIndex]
            };

            mockMessage.Setup(message => message.SerializedMessageSize).Returns(0);

            for (var index = 0; index < amqpMessages.Length; ++index)
            {
                var messageToAdd = new Mock<AmqpMessage>();
                messageToAdd.Setup(message => message.SerializedMessageSize).Returns(50);
                amqpMessages[index] = messageToAdd.Object;
            }

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < serviceBusMessages.Length; ++index)
            {
                var serviceBusMessage = new ServiceBusMessage(Array.Empty<byte>());
                serviceBusMessages[index] = serviceBusMessage;
                batch.TryAddMessage(serviceBusMessage);
            }

            var batchReadOnly = batch.AsReadOnly<AmqpMessage>();
            Assert.That(batchReadOnly, Is.Not.Null, "The batch enumerable should have been populated.");
            Assert.That(batchReadOnly.Count, Is.EqualTo(batch.Count), "The wrong number of messages was in the enumerable.");

            for (var index = 0; index < amqpMessages.Length; ++index)
            {
                Assert.That(batchReadOnly.Contains(amqpMessages[index]), $"The message at index: { index } was not in the enumerable.");
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, $"The addition for index: { index } should fit and be accepted.");
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
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>()
            };

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.SizeInBytes, Is.GreaterThan(0), "The size should have been set when the batch was updated.");

            batch.Clear();
            Assert.That(batch.SizeInBytes, Is.EqualTo(0));
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
            var currentIndex = -1;
            var messages = new AmqpMessage[5];
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, $"The addition for index: { index } should fit and be accepted.");
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
            var currentIndex = -1;
            var mockMessage = new Mock<AmqpMessage>();
            var mockMessageConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < messages.Length; ++index)
            {
                var size = 10;
                var messageToAdd = new Mock<AmqpMessage>();
                messageToAdd.Setup(messageToAdd => messageToAdd.SerializedMessageSize).Returns(size);
                messages[index] = messageToAdd.Object;
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockMessageConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(Array.Empty<byte>())), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.SizeInBytes, Is.GreaterThan(0), "The size should have been set when the batch was updated.");

            batch.Dispose();
            Assert.That(batch.SizeInBytes, Is.EqualTo(0));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeCleansUpBatchMessages()
        {
            var options = new CreateMessageBatchOptions { MaxSizeInBytes = 5000 };
            var messages = new AmqpMessage[5];
            var currentIndex = -1;
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                BuildBatchFromAmqpMessagesHandler = (_s) => mockMessage.Object,
                BuildAmqpMessageFromSBMessageHandler = (_s) => messages[++currentIndex]
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < messages.Length; ++index)
            {
                messages[index] = AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpMessageBatch(mockConverter, options);

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(batch.TryAddMessage(new ServiceBusMessage(new byte[0])), Is.True, $"The addition for index: {index} should fit and be accepted.");
            }

            // Validate that the AMQP messages have not been disposed.

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(() => messages[index].ThrowIfDisposed(), Throws.Nothing, $"The message at index: {index} should not have been disposed.");
            }

            // Dispose the batch and verify that the messages held by the batch have been disposed.

            batch.Dispose();

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(() => messages[index].ThrowIfDisposed(), Throws.InstanceOf<ObjectDisposedException>(), $"The message at index: {index} should have been disposed.");
            }
        }

        /// <summary>
        ///   Allows for control over AMQP message conversion for testing purposes.
        /// </summary>
        ///
        private class InjectableMockConverter : AmqpMessageConverter
        {
            public Func<ServiceBusMessage, AmqpMessage> BuildAmqpMessageFromSBMessageHandler = (_s) => Mock.Of<AmqpMessage>();
            public Func<IEnumerable<ServiceBusMessage>, bool, AmqpMessage> BuildBatchFromSBMessagesHandler = (_s, _f) => Mock.Of<AmqpMessage>();
            public Func<IEnumerable<AmqpMessage>, AmqpMessage> BuildBatchFromAmqpMessagesHandler = (_s) => Mock.Of<AmqpMessage>();
            public override AmqpMessage SBMessageToAmqpMessage(ServiceBusMessage source) => BuildAmqpMessageFromSBMessageHandler(source);
            public override AmqpMessage BuildAmqpBatchFromMessages(IReadOnlyCollection<AmqpMessage> source, bool forceBatch) => BuildBatchFromAmqpMessagesHandler(source);
            public override AmqpMessage BatchSBMessagesAsAmqpMessage(IReadOnlyCollection<ServiceBusMessage> source, bool forceBatch) => BuildBatchFromSBMessagesHandler(source, forceBatch);
            public override AmqpMessage BatchSBMessagesAsAmqpMessage(ServiceBusMessage source, bool forceBatch = false) => BuildAmqpMessageFromSBMessageHandler(source);
        }
    }
}
