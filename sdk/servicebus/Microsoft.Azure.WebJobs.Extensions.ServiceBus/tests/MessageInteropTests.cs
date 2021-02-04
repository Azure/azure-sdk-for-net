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