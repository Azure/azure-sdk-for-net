// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Globalization;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    // Convert from Message --> T
    internal class MessageToPocoConverter<TElement> : IConverter<ServiceBusReceivedMessage, TElement>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private const string TroubleshootingLink =
            "For more information on how to avoid this error, see https://aka.ms/azsdk/net/servicebus/messagebody.";

        public MessageToPocoConverter(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public TElement Convert(ServiceBusReceivedMessage message)
        {
            // 1. If ContentType is "application/json" or binding to a JObject deserialize as JSON
            // 2. If ContentType is not "application/json" and it is a Data body message, attempt to deserialize using DataContractSerializer, which will handle cases like XML object serialization
            // 3. If this deserialization fails, do a final attempt at JSON deserialization to catch cases where the content type might be incorrect

            if (message.ContentType == ContentTypes.ApplicationJson ||
                typeof(TElement) == typeof(JObject))
            {
                return DeserializeJsonObject(message);
            }

            if (message.GetRawAmqpMessage().Body.BodyType != AmqpMessageBodyType.Data)
            {
                return DeserializeJsonObject(message);
            }

            try
            {
                var serializer = DataContractBinarySerializer<TElement>.Instance;
                return (TElement)serializer.ReadObject(message.Body.ToStream());
            }
            catch (SerializationException)
            {
                return DeserializeJsonObject(message);
            }
        }

        private TElement DeserializeJsonObject(ServiceBusReceivedMessage message)
        {
            AmqpMessageBody body = message.GetRawAmqpMessage().Body;
            string contents;

            if (body.BodyType == AmqpMessageBodyType.Data)
            {
                contents = StrictEncodings.Utf8.GetString(message.Body.ToArray());
            }
            else if (body.TryGetValue(out var value))
            {
                if (value is string stringVal)
                {
                    contents = stringVal;
                }
                else
                {
                    throw new NotSupportedException(
                        $"A message with a value type of {value?.GetType()} cannot be bound to a POCO. {TroubleshootingLink}");
                }
            }
            else
            {
                throw new NotSupportedException($"A sequence body message cannot be bound to a POCO. {TroubleshootingLink}");
            }

            try
            {
                return JsonConvert.DeserializeObject<TElement>(contents, _jsonSerializerSettings);
            }
            catch (JsonException e)
            {
                // Easy to have the queue payload not deserialize properly. So give a useful error.
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
@"Binding parameters to complex objects (such as '{0}') uses Json.NET serialization or XML object serialization. 
 1. If ContentType is 'application/json' deserialize as JSON
 2. If ContentType is not 'application/json' and it is a Data body message, attempt to deserialize using DataContractSerializer, which will handle cases like XML object serialization
 3. If this deserialization fails, do a final attempt at JSON deserialization to catch cases where the content type might be incorrect
 {1}
The JSON parser failed: {2}
", typeof(TElement).Name, TroubleshootingLink, e.Message);
                throw new InvalidOperationException(msg);
            }
        }
    }
}
