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
    using System;

    public class MessageInteropTests
    {
        public static IEnumerable<object> TestSerializerPermutations => new object[]
        {
            new object[] { new DataContractBinarySerializer(typeof(Book)) },
            new object[] { new DataContractSerializer(typeof(Book)) }
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
            var book = new Book("contoso", 1, 5);
            var message = GetBrokeredMessage(serializer, book);

            var returned = message.GetBody<Book>(serializer);
            Assert.Equal(book, returned);
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
                var serializer = new DataContractBinarySerializer(typeof(Book));
                var book = new Book("contoso", 1, 5);
                await messageSender.SendAsync(GetBrokeredMessage(serializer, book));

                var message = await messageReceiver.ReceiveAsync();
                var returned = message.GetBody<Book>(serializer);
                Assert.Equal(book, returned);
            }
            finally
            {
                await messageReceiver.CloseAsync();
                await messageSender.CloseAsync();
            }
        }

        Message GetBrokeredMessage(XmlObjectSerializer serializer, Book book)
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

        public class Book
        {
            public Book() { }

            public Book(string name, int id, int count)
            {
                this.Name = name;
                this.Count = count;
                this.Id = id;
            }

            public override bool Equals(Object obj)
            {
                if(obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Book book = (Book)obj;

                return 
                    this.Name.Equals(book.Name, StringComparison.OrdinalIgnoreCase) &&
                    this.Count == book.Count &&
                    this.Id == book.Id;
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
}
