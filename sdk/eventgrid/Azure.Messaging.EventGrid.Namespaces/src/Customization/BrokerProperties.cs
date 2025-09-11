// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    public partial class BrokerProperties
    {
        /// <param name="brokerProperties"> The <see cref="BrokerProperties"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(BrokerProperties brokerProperties)
        {
            if (brokerProperties == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(brokerProperties, ModelSerializationExtensions.WireOptions);
            return content;
        }

        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="BrokerProperties"/> from. </param>
        public static explicit operator BrokerProperties(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeBrokerProperties(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
