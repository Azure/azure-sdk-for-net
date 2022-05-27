// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class ServiceBusMessageConverter : JsonConverter<ServiceBusMessage>
    {
        public override ServiceBusMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var message = new ServiceBusMessage();
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                if (property.Name.Equals(nameof(ServiceBusMessage.Body), StringComparison.OrdinalIgnoreCase))
                {
                    // Body must be a string. For binary payloads, customers can base64 encode the data.
                    message.Body = new BinaryData(property.Value.GetString());
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.ContentType), StringComparison.OrdinalIgnoreCase))
                {
                    message.ContentType = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.CorrelationId), StringComparison.OrdinalIgnoreCase))
                {
                    message.CorrelationId = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.MessageId), StringComparison.OrdinalIgnoreCase))
                {
                    message.MessageId = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.PartitionKey), StringComparison.OrdinalIgnoreCase))
                {
                    message.PartitionKey = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.ReplyTo), StringComparison.OrdinalIgnoreCase))
                {
                    message.ReplyTo = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.ReplyToSessionId), StringComparison.OrdinalIgnoreCase))
                {
                    message.ReplyToSessionId = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.SessionId), StringComparison.OrdinalIgnoreCase))
                {
                    message.SessionId = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.ScheduledEnqueueTime), StringComparison.OrdinalIgnoreCase))
                {
                    message.ScheduledEnqueueTime = DateTimeOffset.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.TimeToLive), StringComparison.OrdinalIgnoreCase))
                {
                    message.TimeToLive = TimeSpan.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.To), StringComparison.OrdinalIgnoreCase))
                {
                    message.To = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.TransactionPartitionKey), StringComparison.OrdinalIgnoreCase))
                {
                    message.TransactionPartitionKey = property.Value.GetString();
                }
                else if (property.Name.Equals(nameof(ServiceBusMessage.ApplicationProperties), StringComparison.OrdinalIgnoreCase))
                {
                    foreach (JsonProperty applicationProperty in property.Value.EnumerateObject())
                    {
                        switch (applicationProperty.Value.ValueKind)
                        {
                            case JsonValueKind.Null:
                            case JsonValueKind.Undefined:
                                message.ApplicationProperties[applicationProperty.Name] = null;
                                break;
                            case JsonValueKind.Number:
                                message.ApplicationProperties[applicationProperty.Name] = GetNumber(applicationProperty.Value);
                                break;
                            case JsonValueKind.True:
                                message.ApplicationProperties[applicationProperty.Name] = true;
                                break;
                            case JsonValueKind.False:
                                message.ApplicationProperties[applicationProperty.Name] = false;
                                break;
                            case JsonValueKind.String:
                                message.ApplicationProperties[applicationProperty.Name] = applicationProperty.Value.GetString();
                                break;
                            default:
                                throw new InvalidOperationException(
                                    $"{applicationProperty.Value.ValueKind} is not a valid ApplicationProperty value.");
                        }
                    }
                }
            }

            return message;
        }

        public override void Write(Utf8JsonWriter writer, ServiceBusMessage value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private static object GetNumber(in JsonElement element)
        {
            if (element.TryGetInt32(out int intValue))
            {
                return intValue;
            }
            if (element.TryGetInt64(out long longValue))
            {
                return longValue;
            }
            return element.GetDouble();
        }
    }
}