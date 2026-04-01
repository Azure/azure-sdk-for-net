// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("ArcResourceId")]
    [CodeGenSuppress("RemoteSupportNodeSettings", typeof(ResourceIdentifier), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class RemoteSupportNodeSettings
    {
        private string _arcResourceIdString;

        /// <summary> Initializes a new instance of <see cref="RemoteSupportNodeSettings"/>. </summary>
        internal RemoteSupportNodeSettings(string arcResourceId, string state, DateTimeOffset? createdOn, DateTimeOffset? updatedOn, string connectionStatus, string connectionErrorMessage, string transcriptLocation, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            _arcResourceIdString = arcResourceId;
            State = state;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            ConnectionStatus = connectionStatus;
            ConnectionErrorMessage = connectionErrorMessage;
            TranscriptLocation = transcriptLocation;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Arc ResourceId of the Node. </summary>
        [Obsolete("This property returns ResourceIdentifier. The underlying value is a string.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("arcResourceId")]
        public ResourceIdentifier ArcResourceId
        {
            get => throw new NotSupportedException("This property is obsolete. Use the new ArcResourceId property with type string instead.");
            internal set => throw new NotSupportedException("This property is obsolete.");
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RemoteSupportNodeSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RemoteSupportNodeSettings)} does not support writing '{format}' format.");
            }
            if (options.Format != "W" && Optional.IsDefined(_arcResourceIdString))
            {
                writer.WritePropertyName("arcResourceId"u8);
                writer.WriteStringValue(_arcResourceIdString);
            }
            if (options.Format != "W" && Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State);
            }
            if (options.Format != "W" && Optional.IsDefined(CreatedOn))
            {
                writer.WritePropertyName("createdAt"u8);
                writer.WriteStringValue(CreatedOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(UpdatedOn))
            {
                writer.WritePropertyName("updatedAt"u8);
                writer.WriteStringValue(UpdatedOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(ConnectionStatus))
            {
                writer.WritePropertyName("connectionStatus"u8);
                writer.WriteStringValue(ConnectionStatus);
            }
            if (options.Format != "W" && Optional.IsDefined(ConnectionErrorMessage))
            {
                writer.WritePropertyName("connectionErrorMessage"u8);
                writer.WriteStringValue(ConnectionErrorMessage);
            }
            if (options.Format != "W" && Optional.IsDefined(TranscriptLocation))
            {
                writer.WritePropertyName("transcriptLocation"u8);
                writer.WriteStringValue(TranscriptLocation);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }
    }
}
