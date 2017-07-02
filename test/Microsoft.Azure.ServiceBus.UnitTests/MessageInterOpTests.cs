// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Extensions;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Xunit;

    public class MessageInterOpTests
    {
        public static IEnumerable<object> TestSerializerPermutations => new object[]
        {
            new object[] { new DataContractBinarySerializer(typeof(Book)) },
            new object[] { new DataContractSerializer(typeof(Book)) },
        };

        public static IEnumerable<object> TestEnd2EndEntityPermutations => new object[]
        {
            new object[] { TestConstants.NonPartitionedQueueName },
            new object[] { TestConstants.PartitionedQueueName}
        };

        [Theory]
        [MemberData(nameof(TestSerializerPermutations))]
        [DisplayTestMethodName]
        void RunSerializerTests(XmlObjectSerializer serializer)
        {
            Book book = new Book("contoso", 1, 5);
            Message message = GetBrokeredMessage(serializer, book);

            Book returnedBookObject = message.GetBody<Book>(serializer);
            VerifyReturnedObject(book, returnedBookObject);
        }

        [Theory]
        [MemberData(nameof(TestEnd2EndEntityPermutations))]
        [DisplayTestMethodName]
        async Task RunEnd2EndSerializerTests(string queueName)
        {
            MessageSender messageSender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
            MessageReceiver messageReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                DataContractBinarySerializer serializer = new DataContractBinarySerializer(typeof(Book));
                Book book = new Book("contoso", 1, 5);
                await messageSender.SendAsync(GetBrokeredMessage(serializer, book));

                Message message = await messageReceiver.ReceiveAsync();
                Book returnedBookObject = message.GetBody<Book>(serializer);
                VerifyReturnedObject(book, returnedBookObject);
            }
            finally
            {
                await messageReceiver.CloseAsync();
                await messageSender.CloseAsync();
            }
        }

        Message GetBrokeredMessage(XmlObjectSerializer serializer, Book bookObject)
        {
            byte[] payload = null;
            using (MemoryStream stream = new MemoryStream(10))
            {
                serializer.WriteObject(stream, bookObject);
                stream.Flush();
                stream.Position = 0;
                payload = stream.ToArray();
            };

            return new Message(payload);
        }

        void VerifyReturnedObject(Book originalObject, Book returnedObject)
        {
            Assert.True(string.Equals(returnedObject.Name, originalObject.Name));
            Assert.True(originalObject.Id == returnedObject.Id);
            Assert.True(originalObject.Count == returnedObject.Count);
        }

        [DataContract(Name = "Library", Namespace = "Books")]
        class Book
        {
            [DataMember(Name = "Name")]
            public string Name;

            [DataMember(Name = "Count")]
            public int Count;

            [DataMember(Name = "Id")]
            public int Id;

            public Book(string name, int id, int count)
            {
                this.Count = count;
                this.Id = id;
                this.Name = name;
            }
        }
    }
}
