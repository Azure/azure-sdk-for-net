// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;

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
    }
}
