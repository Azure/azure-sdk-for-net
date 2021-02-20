// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    // Convert from Message --> T
    internal class MessageToPocoConverter<TElement> : IConverter<ServiceBusReceivedMessage, TElement>
    {
        public MessageToPocoConverter()
        {
        }

        public TElement Convert(ServiceBusReceivedMessage message)
        {
            // 1. If ContentType is "application/json" deserialize as JSON
            // 2. If ContentType is not "application/json" attempt to deserialize using Message.GetBody, which will handle cases like XML object serialization
            // 3. If this deserialization fails, do a final attempt at JSON deserialization to catch cases where the content type might be incorrect

            if (message.ContentType == ContentTypes.ApplicationJson)
            {
                return DeserializeJsonObject(message);
            }
            else
            {
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
        }

        private static TElement DeserializeJsonObject(ServiceBusReceivedMessage message)
        {
            string contents = StrictEncodings.Utf8.GetString(message.Body.ToArray());

            try
            {
                return JsonConvert.DeserializeObject<TElement>(contents, Constants.JsonSerializerSettings);
            }
            catch (JsonException e)
            {
                // Easy to have the queue payload not deserialize properly. So give a useful error.
                string msg = string.Format(
                    CultureInfo.InvariantCulture,
@"Binding parameters to complex objects (such as '{0}') uses Json.NET serialization or XML object serialization. 
 1. If ContentType is 'application/json' deserialize as JSON
 2. If ContentType is not 'application/json' attempt to deserialize using Message.GetBody, which will handle cases like XML object serialization
 3. If this deserialization fails, do a final attempt at JSON deserialization to catch cases where the content type might be incorrect
The JSON parser failed: {1}
", typeof(TElement).Name, e.Message);
                throw new InvalidOperationException(msg);
            }
        }
    }
}
