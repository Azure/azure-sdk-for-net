// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility alias for firewall packet capture request content. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This model is obsolete. Please use FirewallPacketCaptureContent instead.")]
    public partial class FirewallPacketCaptureRequestContent : FirewallPacketCaptureContent, IJsonModel<FirewallPacketCaptureRequestContent>, IPersistableModel<FirewallPacketCaptureRequestContent>
    {
        /// <summary> Initializes a new instance of <see cref="FirewallPacketCaptureRequestContent"/>. </summary>
        public FirewallPacketCaptureRequestContent()
        {
        }

        private FirewallPacketCaptureRequestContent(FirewallPacketCaptureContent content, IDictionary<string, BinaryData> additionalProperties)
            : base(content.Id, additionalProperties, content.DurationInSeconds, content.NumberOfPacketsToCapture, content.SasUri, content.FileName, content.Protocol, content.Flags, content.Filters, content.Operation)
        {
        }

        FirewallPacketCaptureRequestContent IJsonModel<FirewallPacketCaptureRequestContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement, options);
        }
        void IJsonModel<FirewallPacketCaptureRequestContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            base.JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }
        FirewallPacketCaptureRequestContent IPersistableModel<FirewallPacketCaptureRequestContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return Deserialize(document.RootElement, options);
        }
        string IPersistableModel<FirewallPacketCaptureRequestContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<FirewallPacketCaptureRequestContent>.Write(ModelReaderWriterOptions options) => base.PersistableModelWriteCore(options);

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => base.JsonModelWriteCore(writer, options);

        private static FirewallPacketCaptureRequestContent Deserialize(JsonElement element, ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(FirewallPacketCaptureRequestContent)} does not support reading '{options.Format}' format.");
            }
            FirewallPacketCaptureContent content = DeserializeFirewallPacketCaptureContent(element, options);
            if (content is null)
            {
                return null;
            }
            var additionalProperties = new Dictionary<string, BinaryData>();
            if (options.Format != "W")
            {
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    switch (property.Name)
                    {
                        case "id":
                        case "durationInSeconds":
                        case "numberOfPacketsToCapture":
                        case "sasUrl":
                        case "fileName":
                        case "protocol":
                        case "flags":
                        case "filters":
                        case "operation":
                            break;
                        default:
                            additionalProperties[property.Name] = BinaryData.FromString(property.Value.GetRawText());
                            break;
                    }
                }
            }
            return new FirewallPacketCaptureRequestContent(content, additionalProperties);
        }
    }
}
