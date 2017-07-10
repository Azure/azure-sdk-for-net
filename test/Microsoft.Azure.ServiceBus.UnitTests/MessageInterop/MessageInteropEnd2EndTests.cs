// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET46
namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    using Microsoft.Azure.ServiceBus.InteropExtensions;
    using Microsoft.ServiceBus.Messaging;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using System;

    public class MessageInteropEnd2EndTests
    {
        public static IEnumerable<object> TestEnd2EndEntityPermutations => new object[]
        {
            new object[] { TransportType.NetMessaging },
            new object[] { TransportType.Amqp }
        };

        [Theory]
        [MemberData(nameof(TestEnd2EndEntityPermutations))]
        [DisplayTestMethodName]
        async Task RunEnd2EndSerializerTests(TransportType transportType)
        {
            string queueName = TestConstants.NonPartitionedQueueName;

            // Override and Create a new ConnectionString with SbmpConnection Endpoint scheme
            string[] temp = TestUtility.NamespaceConnectionString.Split(':');
            string sbConnectionString = "Endpoint=sb:" + temp[1];

            if(transportType == TransportType.Amqp)
            {
                sbConnectionString += ';' + nameof(TransportType) + '=' + TransportType.Amqp.ToString();
            }

            MessagingFactory messagingFactory = MessagingFactory.CreateFromConnectionString(sbConnectionString);
            MessageSender fullFrameWorkClientSender = messagingFactory.CreateMessageSender(queueName);

            // Create a full framework MessageReceiver
            Core.MessageReceiver dotNetStandardMessageReceiver = new Core.MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ServiceBus.ReceiveMode.ReceiveAndDelete);

            try
            {
                // Send using a full framework MessageSender
                // Plain string
                string message1Body = "contosoString";
                var message1 = new BrokeredMessage(message1Body);
                await fullFrameWorkClientSender.SendAsync(message1);

                // Custom object
                var book = new TestBook("contosoBook", 1, 5);
                var message2 = new BrokeredMessage(book);
                await fullFrameWorkClientSender.SendAsync(message2);

                // UTF8 encoded byte array object
                string message3Body = "contosoBytes";
                var message3 = new BrokeredMessage(Encoding.UTF8.GetBytes(message3Body));
                await fullFrameWorkClientSender.SendAsync(message3);

                // Stream Object
                string message4Body = "contosoStreamObject";
                var message4 = new BrokeredMessage(new MemoryStream(Encoding.UTF8.GetBytes(message4Body)));
                await fullFrameWorkClientSender.SendAsync(message4);

                // Now Receive using this clients MessageReceiver
                // Plain string
                var returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                TestUtility.Log($"Message1 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                var serializer = new DataContractBinarySerializer(typeof(string));
                var returnedBody1 = returnedMessage.GetBody<string>(serializer);
                TestUtility.Log($"Message1: {returnedBody1}");
                Assert.True(string.Equals(message1Body, returnedBody1));

                // Custom object
                returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                TestUtility.Log($"Message2 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                serializer = new DataContractBinarySerializer(typeof(TestBook));
                var returnedBody2 = returnedMessage.GetBody<TestBook>(serializer);
                TestUtility.Log($"Message2: {returnedBody2}");
                Assert.Equal(book, returnedBody2);

                // UTF8 encoded byte array object
                returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                TestUtility.Log($"Message3 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                serializer = new DataContractBinarySerializer(typeof(byte[]));
                var returnedBody3 = Encoding.UTF8.GetString(returnedMessage.GetBody<byte[]>(serializer));
                TestUtility.Log($"Message1: {returnedBody3}");
                Assert.True(string.Equals(message3Body, returnedBody3));

                // Stream Object
                returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                TestUtility.Log($"Message3 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                var returnedBody4 = Encoding.UTF8.GetString(returnedMessage.Body);
                TestUtility.Log($"Message4: {returnedBody4}");
                Assert.True(string.Equals(message4Body, returnedBody4));
            }
            finally
            {
                await dotNetStandardMessageReceiver.CloseAsync();
                await fullFrameWorkClientSender.CloseAsync();
            }
        }
    }
}
#endif