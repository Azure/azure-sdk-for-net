// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.Azure.Messaging
{
    using System;
    using Microsoft.Azure.Messaging.Amqp;

    static class BrokeredMessageEncoder
    {
        // order MUST match the values in BrokeredMessageFormat!!
        static IBrokeredMessageEncoder[] encoders = new IBrokeredMessageEncoder[]
        {
            new NullMessageEncoder(),
            new AmqpMessageEncoder(),
            new NullMessageEncoder(),
            new NullMessageEncoder(),
        };

        public static IBrokeredMessageEncoder GetEncoder(BrokeredMessageFormat format)
        {
            int index = (int)format;
            if (index >= encoders.Length)
            {
                throw new NotSupportedException(format.ToString());
            }

            return encoders[index];
        }

        sealed class NullMessageEncoder : IBrokeredMessageEncoder
        {
            public long WriteHeader(System.Xml.XmlWriter writer, BrokeredMessage brokeredMessage, SerializationTarget serializationTarget)
            {
                return 0;
            }

            public long ReadHeader(System.Xml.XmlReader reader, BrokeredMessage brokeredMessage, SerializationTarget serializationTarget)
            {
                return 0;
            }
        }
    }
}
