// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using NUnit.Framework;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests
{
    public class MessageToStringConverterTests
    {
        private const string TestString = "This is a test!";
        private const string TestJson = "{ value: 'This is a test!' }";

        [Test]
        [TestCase(ContentTypes.TextPlain, TestString)]
        [TestCase(ContentTypes.ApplicationJson, TestJson)]
        [TestCase(ContentTypes.ApplicationOctetStream, TestString)]
        [TestCase(null, TestJson)]
        [TestCase("application/xml", TestJson)]
        [TestCase(ContentTypes.TextPlain, null)]
        public async Task ConvertAsync_ReturnsExpectedResult_WithBinarySerializer(string contentType, string value)
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractBinarySerializer<string>.Instance.WriteObject(ms, value);
                bytes = ms.ToArray();
            }

            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(body: new BinaryData(bytes), contentType: contentType);

            MessageToStringConverter converter = new MessageToStringConverter();
            string result = await converter.ConvertAsync(message, CancellationToken.None);

            Assert.AreEqual(value, result);
        }

        [Theory]
        [TestCase(ContentTypes.TextPlain, TestString)]
        [TestCase(ContentTypes.ApplicationJson, TestJson)]
        [TestCase(ContentTypes.ApplicationOctetStream, TestString)]
        [TestCase(null, TestJson)]
        [TestCase("application/xml", TestJson)]
        [TestCase(ContentTypes.TextPlain, null)]
        [TestCase(ContentTypes.TextPlain, "")]
        public async Task ConvertAsync_ReturnsExpectedResult_WithSerializedString(string contentType, string value)
        {
            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(
                body: value == null ? null : new BinaryData(value),
                contentType: contentType);

            MessageToStringConverter converter = new MessageToStringConverter();
            string result = await converter.ConvertAsync(message, CancellationToken.None);
            // A received message will never have a null body as a body section is required when sending even if it
            // is empty. This was true in Track 1 as well, but in Track 1 the actual body property could be null when
            // constructing the message, but in practice it wouldn't be null when receiving.
            if (value == null)
            {
                Assert.AreEqual("", result);
            }
            else
            {
                Assert.AreEqual(value, result);
            }
        }

        [Test]
        public async Task ConvertAsync_ReturnsExpectedResult_WithSerializedObject()
        {
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractBinarySerializer<TestObject>.Instance.WriteObject(ms, new TestObject() { Text = "Test" });
                bytes = ms.ToArray();
            }

            ServiceBusReceivedMessage message = ServiceBusModelFactory.ServiceBusReceivedMessage(body: new BinaryData(bytes));

            MessageToStringConverter converter = new MessageToStringConverter();
            string result = await converter.ConvertAsync(message, CancellationToken.None);
            Assert.AreEqual(message.Body.ToString(), result);
        }

        [Serializable]
        public class TestObject
        {
            public string Text { get; set; }
        }
    }
}
