// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.WebJobs.ServiceBus.Config;

namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    public class MessageInteropTests
    {
        private static IDictionary<string, XmlObjectSerializer> SerializerTestCases = new XmlObjectSerializer[]
        {
           new DataContractBinarySerializer(typeof(TestBook)),
           new DataContractSerializer(typeof(TestBook))
        }.ToDictionary(item => item.ToString(), item => item);

        public static IEnumerable<object[]> SerializerTestCaseNames => SerializerTestCases.Select(testCase => new[] { testCase.Key });

        [Test]
        [TestCaseSource(nameof(SerializerTestCaseNames))]
        public void RunSerializerTests(string testCaseName)
        {
            var serializer = SerializerTestCases[testCaseName];
            var book = new TestBook("contoso", 1, 5);
            var message = GetBrokeredMessage(serializer, book);
            var returned = (TestBook)serializer.ReadObject(message.Body.ToStream());
            Assert.AreEqual(book, returned);
        }

        [Test]
        public void ParameterBindingDataTest()
        {
            var lockToken = Guid.NewGuid();
            var message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                body: BinaryData.FromString("body"),
                messageId: "messageId",
                correlationId: "correlationId",
                sessionId: "sessionId",
                replyTo: "replyTo",
                replyToSessionId: "replyToSessionId",
                contentType: "contentType",
                subject: "label",
                to: "to",
                partitionKey: "partitionKey",
                viaPartitionKey: "viaPartitionKey",
                deadLetterSource: "deadLetterSource",
                enqueuedSequenceNumber: 1,
                lockTokenGuid: lockToken);

            var bindingData = ServiceBusExtensionConfigProvider.ConvertReceivedMessageToBindingData(message);
            Assert.AreEqual("application/octet-stream", bindingData.ContentType);
            Assert.AreEqual("1.0", bindingData.Version);
            Assert.AreEqual("AzureServiceBusReceivedMessage", bindingData.Source);

            var bytes = bindingData.Content.ToMemory();
            var lockTokenBytes = bytes.Slice(0, 16).ToArray();
            Assert.AreEqual(lockToken.ToByteArray(), lockTokenBytes);

            var deserialized = ServiceBusReceivedMessage.FromAmqpMessage(
                AmqpAnnotatedMessage.FromBytes(
                    BinaryData.FromBytes(bytes.Slice(16, bytes.Length - 16))),
                BinaryData.FromBytes(lockTokenBytes));

            Assert.AreEqual(message.Body.ToArray(), deserialized.Body.ToArray());
            Assert.AreEqual(message.MessageId, deserialized.MessageId);
            Assert.AreEqual(message.CorrelationId, deserialized.CorrelationId);
            Assert.AreEqual(message.SessionId, deserialized.SessionId);
            Assert.AreEqual(message.ReplyTo, deserialized.ReplyTo);
            Assert.AreEqual(message.ReplyToSessionId, deserialized.ReplyToSessionId);
            Assert.AreEqual(message.ContentType, deserialized.ContentType);
            Assert.AreEqual(message.Subject, deserialized.Subject);
            Assert.AreEqual(message.To, deserialized.To);
            Assert.AreEqual(message.PartitionKey, deserialized.PartitionKey);
            Assert.AreEqual(message.TransactionPartitionKey, deserialized.TransactionPartitionKey);
            Assert.AreEqual(message.DeadLetterSource, deserialized.DeadLetterSource);
            Assert.AreEqual(message.EnqueuedSequenceNumber, deserialized.EnqueuedSequenceNumber);
            Assert.AreEqual(message.LockToken, deserialized.LockToken);
        }

        private ServiceBusMessage GetBrokeredMessage(XmlObjectSerializer serializer, TestBook book)
        {
            byte[] payload = null;
            using (var memoryStream = new MemoryStream(10))
            {
                serializer.WriteObject(memoryStream, book);
                memoryStream.Flush();
                memoryStream.Position = 0;
                payload = memoryStream.ToArray();
            };

            return new ServiceBusMessage(payload);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class TestBook
#pragma warning restore SA1402 // File may only contain a single type
    {
        public TestBook() { }

        public TestBook(string name, int id, int count)
        {
            Name = name;
            Count = count;
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var testBook = (TestBook)obj;

            return
                Name.Equals(testBook.Name, StringComparison.OrdinalIgnoreCase) &&
                Count == testBook.Count &&
                Id == testBook.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string Name { get; set; }

        public int Count { get; set; }

        public int Id { get; set; }
    }
}