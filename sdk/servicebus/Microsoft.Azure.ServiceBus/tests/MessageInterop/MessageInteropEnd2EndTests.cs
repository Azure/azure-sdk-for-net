// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if FullNetFx
namespace Microsoft.Azure.ServiceBus.UnitTests.MessageInterop
{
    using Microsoft.ServiceBus.Messaging;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using InteropExtensions;

    public class MessageInteropEnd2EndTests
    {
        public static IEnumerable<object[]> TestEnd2EndEntityPermutations => new object[][]
        {
            new object[] { TransportType.NetMessaging, MessageInteropEnd2EndTests.GetSbConnectionString(TransportType.NetMessaging) },
            new object[] { TransportType.Amqp, MessageInteropEnd2EndTests.GetSbConnectionString(TransportType.Amqp) }
        };

        [Theory]
        [MemberData(nameof(TestEnd2EndEntityPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task RunEnd2EndSerializerTests(TransportType transportType, string sbConnectionString)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                // Create a full framework MessageSender
                var csb = new Microsoft.ServiceBus.ServiceBusConnectionStringBuilder(sbConnectionString)
                {
                    TransportType = transportType
                };
                var messagingFactory = MessagingFactory.CreateFromConnectionString(csb.ToString());
                var fullFrameWorkClientSender = messagingFactory.CreateMessageSender(queueName);

                // Create a .NetStandard MessageReceiver
                var dotNetStandardMessageReceiver = new Core.MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ServiceBus.ReceiveMode.ReceiveAndDelete);

                try
                {
                    // Send Plain string
                    var message1Body = "contosoString";
                    var message1 = new BrokeredMessage(message1Body);
                    await fullFrameWorkClientSender.SendAsync(message1);

                    // Receive Plain string
                    var returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                    TestUtility.Log($"Message1 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                    var returnedBody1 = returnedMessage.GetBody<string>();
                    TestUtility.Log($"Message1: {returnedBody1}");
                    Assert.Equal(message1Body, returnedBody1);

                    // Send Custom object
                    var book = new TestBook("contosoBook", 1, 5);
                    var message2 = new BrokeredMessage(book);
                    await fullFrameWorkClientSender.SendAsync(message2);

                    // Receive Custom object
                    returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                    TestUtility.Log($"Message2 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                    var returnedBody2 = returnedMessage.GetBody<TestBook>();
                    TestUtility.Log($"Message2: {returnedBody2}");
                    Assert.Equal(book, returnedBody2);

                    // Send UTF8 encoded byte array object
                    var message3Body = "contosoBytes";
                    var message3 = new BrokeredMessage(Encoding.UTF8.GetBytes(message3Body));
                    await fullFrameWorkClientSender.SendAsync(message3);

                    // Receive UTF8 encoded byte array object
                    returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                    TestUtility.Log($"Message3 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                    var returnedBody3 = Encoding.UTF8.GetString(returnedMessage.GetBody<byte[]>());
                    TestUtility.Log($"Message1: {returnedBody3}");
                    Assert.Equal(message3Body, returnedBody3);

                    // Send Stream Object
                    var message4Body = "contosoStreamObject";
                    var message4 = new BrokeredMessage(new MemoryStream(Encoding.UTF8.GetBytes(message4Body)));
                    await fullFrameWorkClientSender.SendAsync(message4);

                    // Receive Stream Object
                    returnedMessage = await dotNetStandardMessageReceiver.ReceiveAsync();
                    TestUtility.Log($"Message3 SequenceNumber: {returnedMessage.SystemProperties.SequenceNumber}");
                    var returnedBody4 = Encoding.UTF8.GetString(returnedMessage.Body);
                    TestUtility.Log($"Message4: {returnedBody4}");
                    Assert.Equal(message4Body, returnedBody4);
                }
                finally
                {
                    await dotNetStandardMessageReceiver.CloseAsync();
                    await fullFrameWorkClientSender.CloseAsync();
                }
            });
        }

        internal static string GetSbConnectionString(TransportType transportType)
        {
            // Override and Create a new ConnectionString with SbmpConnection Endpoint scheme
            string[] parts = TestUtility.NamespaceConnectionString.Split(':');
            var sbConnectionString = "Endpoint=sb:" + parts[1];

            if (transportType == TransportType.Amqp)
            {
                sbConnectionString += ';' + nameof(TransportType) + '=' + TransportType.Amqp.ToString();
            }

            return sbConnectionString;
        }
    }
}
#endif