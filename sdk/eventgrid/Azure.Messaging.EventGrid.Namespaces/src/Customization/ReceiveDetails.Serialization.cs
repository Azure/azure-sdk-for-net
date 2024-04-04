// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class ReceiveDetails
    {
        internal static ReceiveDetails DeserializeReceiveDetails(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BrokerProperties brokerProperties = default;
            Azure.Messaging.CloudEvent @event = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("brokerProperties"u8))
                {
                    brokerProperties = BrokerProperties.DeserializeBrokerProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("event"u8))
                {
                    @event = JsonSerializer.Deserialize<Azure.Messaging.CloudEvent>(property.Value.GetRawText(), new JsonSerializerOptions());
                    continue;
                }
            }
            return new ReceiveDetails(brokerProperties, @event);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ReceiveDetails FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeReceiveDetails(document.RootElement);
        }
    }
}