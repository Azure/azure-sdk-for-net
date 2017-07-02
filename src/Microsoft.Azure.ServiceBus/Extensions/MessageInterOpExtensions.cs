// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Extensions
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// A Message Extension Class that provides extension methods to deserialize 
    /// the body of a message that was serialized and sent to ServiceBus Queue/Topic
    /// using the WindowsAzure.Messaging client library. The WindowsAzure.Messaging
    /// client libary serializes objects using the 
    /// <see cref="DataContractBinarySerializer"/> or <see cref="DataContractSerializer"/>
    /// when sending message. This class provides extension methods to deserialize
    /// and retrieve the body of such messages.
    /// </summary>
    /// <remarks>If a message is only being sent and received using this 
    /// Microsoft.Azure.ServiceBus client library, then the below extension methods are not
    /// relevant.</remarks>
    public static class MessageInteropExtensions
    {
        /// <summary>
        /// Deserializes the body of a message that was serialized using DataContractBinarySerializer
        /// </summary>
        public static T GetBody<T>(this Message message)
        {
            return GetBody<T>(message, new DataContractBinarySerializer(typeof(T)));
        }

        /// <summary>
        /// Deserializes the body of a message that was serialized using XmlObjectSerializer
        /// </summary>
        public static T GetBody<T>(this Message message, XmlObjectSerializer serializer)
        {
            if(message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if(message.Body == null || message.Body.Length == 0)
            {
                throw new ArgumentException(nameof(message.Body));
            }

            using (MemoryStream stream = new MemoryStream(256))
            {
                stream.Write(message.Body, 0, message.Body.Length);
                stream.Flush();
                stream.Position = 0;
                return (T)serializer.ReadObject(stream); 
            }
        }
    }
}
