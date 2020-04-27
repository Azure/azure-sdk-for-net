// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.Extensions;
using Microsoft.Azure.ServiceBus.UnitTests.Infrastructure;

namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Xunit;

    public class MessageInteropTests
    {
        private static IDictionary<string, XmlObjectSerializer> _serializerTestCases = new XmlObjectSerializer[]
        {
           new DataContractBinarySerializer(typeof(TestBook)),
           new DataContractSerializer(typeof(TestBook))

        }.ToDictionary(item => item.ToString(), item => item);

        public static IEnumerable<object[]> SerializerTestCaseNames => _serializerTestCases.Select(testCase => new[] { testCase.Key });

        [Theory]
        [MemberData(nameof(SerializerTestCaseNames))]
        [DisplayTestMethodName]
        public void RunSerializerTests(string testCaseName)
        {
            var serializer = _serializerTestCases[testCaseName];
            var book = new TestBook("contoso", 1, 5);
            var message = GetBrokeredMessage(serializer, book);

            var returned = message.GetBody<TestBook>(serializer);
            Assert.Equal(book, returned);
        }

        private Message GetBrokeredMessage(XmlObjectSerializer serializer, TestBook book)
        {
            byte[] payload = null;
            using (var memoryStream = new MemoryStream(10))
            {
                serializer.WriteObject(memoryStream, book);
                memoryStream.Flush();
                memoryStream.Position = 0;
                payload = memoryStream.ToArray();
            };

            return new Message(payload);
        }
    }
}