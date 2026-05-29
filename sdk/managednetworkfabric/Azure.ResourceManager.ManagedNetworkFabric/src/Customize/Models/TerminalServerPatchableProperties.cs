// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Network and credentials configuration already applied to terminal server. </summary>
    public partial class TerminalServerPatchableProperties : IJsonModel<TerminalServerPatchableProperties>, IPersistableModel<TerminalServerPatchableProperties>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="TerminalServerPatchableProperties"/>. </summary>
        public TerminalServerPatchableProperties()
        {
        }

        internal TerminalServerPatchableProperties(string username, string password, string serialNumber, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Username = username;
            Password = password;
            SerialNumber = serialNumber;
            this.additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Username for the terminal server connection. </summary>
        public string Username { get; set; }

        /// <summary> Password for the terminal server connection. </summary>
        public string Password { get; set; }

        /// <summary> Serial Number of Terminal server. </summary>
        public string SerialNumber { get; set; }

        /// <summary> Writes this <see cref="TerminalServerPatchableProperties"/> instance as binary data. </summary>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerPatchableProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(TerminalServerPatchableProperties)} does not support writing '{options.Format}' format.");
            }
        }

        /// <summary> Reads a <see cref="TerminalServerPatchableProperties"/> instance from binary data. </summary>
        protected virtual TerminalServerPatchableProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerPatchableProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeTerminalServerPatchableProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TerminalServerPatchableProperties)} does not support reading '{options.Format}' format.");
            }
        }

        BinaryData IPersistableModel<TerminalServerPatchableProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        TerminalServerPatchableProperties IPersistableModel<TerminalServerPatchableProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<TerminalServerPatchableProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<TerminalServerPatchableProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes this <see cref="TerminalServerPatchableProperties"/> instance as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerPatchableProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TerminalServerPatchableProperties)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Username))
            {
                writer.WritePropertyName("username"u8);
                writer.WriteStringValue(Username);
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password"u8);
                writer.WriteStringValue(Password);
            }
            if (Optional.IsDefined(SerialNumber))
            {
                writer.WritePropertyName("serialNumber"u8);
                writer.WriteStringValue(SerialNumber);
            }
            if (options.Format != "W" && additionalBinaryDataProperties != null)
            {
                foreach (var item in additionalBinaryDataProperties)
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

        TerminalServerPatchableProperties IJsonModel<TerminalServerPatchableProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Reads a <see cref="TerminalServerPatchableProperties"/> instance from JSON. </summary>
        protected virtual TerminalServerPatchableProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerPatchableProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TerminalServerPatchableProperties)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTerminalServerPatchableProperties(document.RootElement, options);
        }

        internal static TerminalServerPatchableProperties DeserializeTerminalServerPatchableProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string username = default;
            string password = default;
            string serialNumber = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("username"u8))
                {
                    username = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("password"u8))
                {
                    password = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("serialNumber"u8))
                {
                    serialNumber = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new TerminalServerPatchableProperties(username, password, serialNumber, additionalBinaryDataProperties);
        }
    }
}
