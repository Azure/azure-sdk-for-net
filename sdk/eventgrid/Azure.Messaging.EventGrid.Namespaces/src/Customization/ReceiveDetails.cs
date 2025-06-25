// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSerialization(nameof(Event), SerializationValueHook = nameof(WriteEvent), DeserializationValueHook = nameof(ReadEvent))]
    public partial class ReceiveDetails
    {
        /// <summary> Cloud Event details. </summary>
        public Azure.Messaging.CloudEvent Event { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteEvent(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            JsonSerializer.Serialize(writer, Event);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadEvent(JsonProperty property, ref Azure.Messaging.CloudEvent @event)
        {
            @event = JsonSerializer.Deserialize<Azure.Messaging.CloudEvent>(property.Value.GetRawText(), new JsonSerializerOptions());
        }

        /// <param name="receiveDetails"> The <see cref="ReceiveDetails"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(ReceiveDetails receiveDetails)
        {
            if (receiveDetails == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(receiveDetails, ModelSerializationExtensions.WireOptions);
            return content;
        }

        /// <param name="result"> The <see cref="Response"/> to deserialize the <see cref="ReceiveDetails"/> from. </param>
        public static explicit operator ReceiveDetails(Response result)
        {
            using Response response = result;
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeReceiveDetails(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
