// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.ServiceBus.Triggers;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.InteropExtensions;
using NUnit.Framework;

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

            Message message = new Message(bytes);
            message.ContentType = contentType;

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
            Message message = new Message(value == null ? null : Encoding.UTF8.GetBytes(value));
            message.ContentType = contentType;

            MessageToStringConverter converter = new MessageToStringConverter();
            string result = await converter.ConvertAsync(message, CancellationToken.None);
            Assert.AreEqual(value, result);
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

            Message message = new Message(bytes);

            MessageToStringConverter converter = new MessageToStringConverter();
            string result = await converter.ConvertAsync(message, CancellationToken.None);
            Assert.AreEqual(Encoding.UTF8.GetString(message.Body), result);
        }

        [Serializable]
        public class TestObject
        {
            public string Text { get; set; }
        }
    }
}
