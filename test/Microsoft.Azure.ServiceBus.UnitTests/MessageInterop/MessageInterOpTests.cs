// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using Xunit;
    using InteropExtensions;

    public class MessageInteropTests
    {
        public static IEnumerable<object> TestSerializerPermutations => new object[]
        {
            new object[] { new DataContractBinarySerializer(typeof(TestBook)) },
            new object[] { new DataContractSerializer(typeof(TestBook)) }
        };

        [Theory]
        [MemberData(nameof(TestSerializerPermutations))]
        [DisplayTestMethodName]
        void RunSerializerTests(XmlObjectSerializer serializer)
        {
            var book = new TestBook("contoso", 1, 5);
            var message = GetBrokeredMessage(serializer, book);

            var returned = message.GetBody<TestBook>(serializer);
            Assert.Equal(book, returned);
        }

        Message GetBrokeredMessage(XmlObjectSerializer serializer, TestBook book)
        {
            byte[] payload = null;
            using (MemoryStream stream = new MemoryStream(10))
            {
                serializer.WriteObject(stream, book);
                stream.Flush();
                stream.Position = 0;
                payload = stream.ToArray();
            };

            return new Message(payload);
        }
    }
}