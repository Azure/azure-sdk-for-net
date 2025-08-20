// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.InteropExtensions
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// A Message Extension Class that provides extension methods to deserialize
    /// the body of a message that was serialized and sent to ServiceBus Queue/Topic
    /// using the WindowsAzure.Messaging client library. The WindowsAzure.Messaging
    /// client library serializes objects using the
    /// <see cref="DataContractBinarySerializer"/> (default serializer) or <see cref="DataContractSerializer"/>
    /// when sending message. This class provides extension methods to deserialize
    /// and retrieve the body of such messages.
    /// </summary>
    /// <remarks>
    /// 1. If a message is only being sent and received using this Microsoft.Azure.ServiceBus
    /// client library, then the below extension methods are not relevant and should not be used.
    ///
    /// 2. If this client library will be used to receive messages that were sent using both
    /// WindowsAzure.Messaging client library and this (Microsoft.Azure.ServiceBus) library,
    /// then the Users need to add a User property <see cref="Message.UserProperties"/>
    /// while sending the message. On receiving the message, this property can be examined to
    /// determine if the message was from WindowsAzure.Messaging client library and if so
    /// use the message.GetBody() extension method to get the actual body associated with the message.
    ///
    /// ----------------------------------------------
    /// Scenarios to use the GetBody Extension method:
    /// ----------------------------------------------
    /// If message was constructed using the WindowsAzure.Messaging client library as follows:
    /// <code>
    ///     var message1 = new BrokeredMessage("contoso"); // Sending a plain string
    ///     var message2 = new BrokeredMessage(sampleObject); // Sending an actual customer object
    ///     var message3 = new BrokeredMessage(Encoding.UTF8.GetBytes("contoso")); // Sending a UTF8 encoded byte array object
    ///
    ///     await messageSender.SendAsync(message1);
    ///     await messageSender.SendAsync(message2);
    ///     await messageSender.SendAsync(message3);
    /// </code>
    ///
    /// Then retrieve the original objects using this client library as follows:
    /// (By default <see cref="DataContractBinarySerializer"/> will be used to deserialize and retrieve the body.
    ///  If a serializer other than that was used, pass in the serializer explicitly.)
    /// <code>
    ///     var message1 = await messageReceiver.ReceiveAsync();
    ///     var returnedData1 = message1.GetBody&lt;string&gt;();
    ///
    ///     var message2 = await messageReceiver.ReceiveAsync();
    ///     var returnedData2 = message1.GetBody&lt;SampleObject&gt;();
    ///
    ///     var message3 = await messageReceiver.ReceiveAsync();
    ///     var returnedData3Bytes = message1.GetBody&lt;byte[]&gt;();
    ///     Console.WriteLine($"Message3 String: {Encoding.UTF8.GetString(returnedData3Bytes)}");
    /// </code>
    ///
    /// -------------------------------------------------
    /// Scenarios to NOT use the GetBody Extension method:
    /// -------------------------------------------------
    ///  If message was sent using the WindowsAzure.Messaging client library as follows:
    ///     var message4 = new BrokeredMessage(new MemoryStream(Encoding.UTF8.GetBytes("contoso")));
    ///     await messageSender.SendAsync(message4);
    ///
    ///  Then retrieve the original objects using this client library as follows:
    ///     var message4 = await messageReceiver.ReceiveAsync();
    ///     string returned = Encoding.UTF8.GetString(message4.Body); // Since message was sent as Stream, no deserialization required here.
    ///
    /// </remarks>
    public static class MessageInteropExtensions
    {
        /// <summary>
        /// Deserializes the body of a message that was serialized using XmlObjectSerializer
        /// </summary>
        public static T GetBody<T>(this Message message, XmlObjectSerializer serializer = null)
        {
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if(message.SystemProperties.BodyObject != null)
            {
                return (T)message.SystemProperties.BodyObject;
            }

            if(message.Body == null || message.Body.Length == 0)
            {
                return default;
            }

            if(serializer == null)
            {
                serializer = DataContractBinarySerializer<T>.Instance;
            }

            using (var memoryStream = new MemoryStream(message.Body.Length))
            {
                memoryStream.Write(message.Body, 0, message.Body.Length);
                memoryStream.Flush();
                memoryStream.Position = 0;
                return (T)serializer.ReadObject(memoryStream);
            }
        }
    }
}
