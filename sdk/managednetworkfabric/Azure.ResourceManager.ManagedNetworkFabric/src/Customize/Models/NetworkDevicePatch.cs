// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkDevicePatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkDevicePatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkDevicePatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Network Device Patch Parameters defines the patch parameters of the resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkDevicePatchContent instead.")]
    public partial class NetworkDevicePatch : NetworkRackPatch, IJsonModel<NetworkDevicePatch>, IPersistableModel<NetworkDevicePatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDevicePatch"/>. </summary>
        public NetworkDevicePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkDevicePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Device Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkDevicePatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkDevicePatchParametersProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Device Patch properties. </summary>
        internal NetworkDevicePatchParametersProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get
            {
                return Properties is null ? default : Properties.Annotation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> The host name of the device. </summary>
        public string HostName
        {
            get
            {
                return Properties is null ? default : Properties.HostName;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.HostName = value;
            }
        }

        /// <summary> Serial number of the device. Format of serial Number - Make;Model;HardwareRevisionId;SerialNumber. </summary>
        public string SerialNumber
        {
            get
            {
                return Properties is null ? default : Properties.SerialNumber;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.SerialNumber = value;
            }
        }

        /// <summary> The selection of the managed identity to use with this storage account. The identity type must be either system assigned or user assigned. </summary>
        public NetworkFabricIdentitySelectorPatch IdentitySelector
        {
            get
            {
                return Properties is null ? default : Properties.IdentitySelector;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkDevicePatchParametersProperties();
                }
                Properties.IdentitySelector = value;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDevicePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkDevicePatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkDevicePatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDevicePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkDevicePatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkDevicePatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkDevicePatch IPersistableModel<NetworkDevicePatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkDevicePatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkDevicePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkDevicePatch"> The <see cref="NetworkDevicePatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkDevicePatch networkDevicePatch)
        {
            if (networkDevicePatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkDevicePatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkDevicePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDevicePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkDevicePatch)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                writer.WriteObjectValue(Identity, options);
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkDevicePatch IJsonModel<NetworkDevicePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkDevicePatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDevicePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkDevicePatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkDevicePatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkDevicePatch DeserializeNetworkDevicePatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            NetworkDevicePatchParametersProperties properties = default;
            NetworkFabricManagedServiceIdentityPatch identity = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    tags = dictionary;
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = NetworkDevicePatchParametersProperties.DeserializeNetworkDevicePatchParametersProperties(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("identity"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = NetworkFabricManagedServiceIdentityPatch.DeserializeNetworkFabricManagedServiceIdentityPatch(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new NetworkDevicePatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties, identity);
        }
    }
}
