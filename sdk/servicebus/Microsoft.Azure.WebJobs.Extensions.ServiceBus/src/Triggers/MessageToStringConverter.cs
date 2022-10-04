// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class MessageToStringConverter : IConverter<ServiceBusReceivedMessage, string>
    {
        public string Convert(ServiceBusReceivedMessage input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var body = input.GetRawAmqpMessage().Body;
            if (body.BodyType == AmqpMessageBodyType.Data)
            {
                if (input.Body == null)
                {
                    return null;
                }

                try
                {
                    return StrictEncodings.Utf8.GetString(input.Body.ToArray());
                }
                catch (DecoderFallbackException)
                {
                    // we'll try again below
                }

                // We may get here if the message is a string yet was DataContract-serialized when created.
                try
                {
                    using Stream stream = input.Body.ToStream();
                    var serializer = DataContractBinarySerializer<string>.Instance;
                    stream.Position = 0;
                    return (string) serializer.ReadObject(stream);
                }
                catch
                {
                    // always possible to get a valid string from the message
                    return input.Body.ToString();
                }
            }
            else if (body.BodyType == AmqpMessageBodyType.Value)
            {
                body.TryGetValue(out object value);
                if (value is string stringValue)
                {
                    return stringValue;
                }

                throw new NotSupportedException(
                    $"A message with a value type of {value?.GetType()} cannot be bound to a string.");
            }
            else
            {
                throw new NotSupportedException("A sequence body message cannot be bound to a string.");
            }
        }
    }
}