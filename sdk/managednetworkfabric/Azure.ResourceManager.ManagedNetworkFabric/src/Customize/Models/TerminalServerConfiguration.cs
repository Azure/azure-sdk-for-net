// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the TypeSpec migration. The current generated property
    // is TerminalServerSettings and uses NetworkFabricTerminalServerConfiguration.
    /// <summary> Network and credentials configuration currently applied to terminal server. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
    public partial class TerminalServerConfiguration : TerminalServerPatchableProperties, IJsonModel<TerminalServerConfiguration>, IPersistableModel<TerminalServerConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="TerminalServerConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
        public TerminalServerConfiguration()
        {
            throw new NotSupportedException("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.");
        }

        /// <summary> Initializes a new instance of <see cref="TerminalServerConfiguration"/>. </summary>
        /// <param name="primaryIPv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="secondaryIPv4Prefix"> Secondary IPv4 Address Prefix. </param>
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
        public TerminalServerConfiguration(string primaryIPv4Prefix, string secondaryIPv4Prefix)
        {
            throw new NotSupportedException("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.");
        }

        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
        internal TerminalServerConfiguration(string username, string password, string serialNumber, IDictionary<string, BinaryData> additionalBinaryDataProperties, string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, ResourceIdentifier networkDeviceId, IReadOnlyList<NetworkFabricSecretRotationStatus> secretRotationStatus)
            : base(username, password, serialNumber, additionalBinaryDataProperties)
        {
            PrimaryIPv4Prefix = primaryIPv4Prefix;
            PrimaryIPv6Prefix = primaryIPv6Prefix;
            SecondaryIPv4Prefix = secondaryIPv4Prefix;
            SecondaryIPv6Prefix = secondaryIPv6Prefix;
            NetworkDeviceId = networkDeviceId;
            SecretRotationStatus = secretRotationStatus ?? new ChangeTrackingList<NetworkFabricSecretRotationStatus>();
        }

        /// <summary> IPv4 Address Prefix. </summary>
        public string PrimaryIPv4Prefix { get; set; }

        /// <summary> IPv6 Address Prefix. </summary>
        public string PrimaryIPv6Prefix { get; set; }

        /// <summary> Secondary IPv4 Address Prefix. </summary>
        public string SecondaryIPv4Prefix { get; set; }

        /// <summary> Secondary IPv6 Address Prefix. </summary>
        public string SecondaryIPv6Prefix { get; set; }

        /// <summary> ARM Resource ID used for the NetworkDevice. </summary>
        public ResourceIdentifier NetworkDeviceId { get; }

        /// <summary> Secret rotation status for the terminal server's secrets. </summary>
        public IReadOnlyList<NetworkFabricSecretRotationStatus> SecretRotationStatus { get; }

        void IJsonModel<TerminalServerConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        TerminalServerConfiguration IJsonModel<TerminalServerConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (TerminalServerConfiguration)JsonModelCreateCore(ref reader, options);

        BinaryData IPersistableModel<TerminalServerConfiguration>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        TerminalServerConfiguration IPersistableModel<TerminalServerConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (TerminalServerConfiguration)PersistableModelCreateCore(data, options);

        string IPersistableModel<TerminalServerConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Writes this <see cref="TerminalServerConfiguration"/> instance as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TerminalServerConfiguration)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(PrimaryIPv4Prefix))
            {
                writer.WritePropertyName("primaryIpv4Prefix"u8);
                writer.WriteStringValue(PrimaryIPv4Prefix);
            }
            if (Optional.IsDefined(PrimaryIPv6Prefix))
            {
                writer.WritePropertyName("primaryIpv6Prefix"u8);
                writer.WriteStringValue(PrimaryIPv6Prefix);
            }
            if (Optional.IsDefined(SecondaryIPv4Prefix))
            {
                writer.WritePropertyName("secondaryIpv4Prefix"u8);
                writer.WriteStringValue(SecondaryIPv4Prefix);
            }
            if (Optional.IsDefined(SecondaryIPv6Prefix))
            {
                writer.WritePropertyName("secondaryIpv6Prefix"u8);
                writer.WriteStringValue(SecondaryIPv6Prefix);
            }
            if (options.Format != "W" && Optional.IsDefined(NetworkDeviceId))
            {
                writer.WritePropertyName("networkDeviceId"u8);
                writer.WriteStringValue(NetworkDeviceId);
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(SecretRotationStatus))
            {
                writer.WritePropertyName("secretRotationStatus"u8);
                writer.WriteStartArray();
                foreach (NetworkFabricSecretRotationStatus item in SecretRotationStatus)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
        }

        /// <summary> Reads a <see cref="TerminalServerConfiguration"/> instance from JSON. </summary>
        protected override TerminalServerPatchableProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TerminalServerConfiguration)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTerminalServerConfiguration(document.RootElement, options);
        }

        /// <summary> Reads a <see cref="TerminalServerConfiguration"/> instance from binary data. </summary>
        protected override TerminalServerPatchableProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeTerminalServerConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TerminalServerConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Writes this <see cref="TerminalServerConfiguration"/> instance as binary data. </summary>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(TerminalServerConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        internal NetworkFabricTerminalServerConfiguration ToNetworkFabricTerminalServerConfiguration()
            => new NetworkFabricTerminalServerConfiguration(
                Username,
                Password,
                SerialNumber,
                PrimaryIPv4Prefix,
                PrimaryIPv6Prefix,
                SecondaryIPv4Prefix,
                SecondaryIPv6Prefix,
                NetworkDeviceId,
                SecretRotationStatus,
                additionalBinaryDataProperties: null);

        internal static TerminalServerConfiguration FromNetworkFabricTerminalServerConfiguration(NetworkFabricTerminalServerConfiguration value)
            => value is null ? null : new TerminalServerConfiguration(
                value.Username,
                value.Password,
                value.SerialNumber,
                additionalBinaryDataProperties: null,
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix,
                value.NetworkDeviceId,
                value.SecretRotationStatus);

        internal static TerminalServerConfiguration DeserializeTerminalServerConfiguration(JsonElement element, ModelReaderWriterOptions options)
            => FromNetworkFabricTerminalServerConfiguration(NetworkFabricTerminalServerConfiguration.DeserializeNetworkFabricTerminalServerConfiguration(element, options));
    }
}
