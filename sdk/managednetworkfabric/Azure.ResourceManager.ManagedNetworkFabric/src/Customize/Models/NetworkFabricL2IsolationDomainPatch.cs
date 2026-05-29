// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricL2IsolationDomainPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricL2IsolationDomainPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricL2IsolationDomainPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The L2 Isolation Domain patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricL2IsolationDomainPatchContent instead.")]
    public partial class NetworkFabricL2IsolationDomainPatch : NetworkRackPatch, IJsonModel<NetworkFabricL2IsolationDomainPatch>, IPersistableModel<NetworkFabricL2IsolationDomainPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricL2IsolationDomainPatch"/>. </summary>
        public NetworkFabricL2IsolationDomainPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricL2IsolationDomainPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> L2 Isolation Domain resource patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricL2IsolationDomainPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, L2IsolationDomainPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> L2 Isolation Domain resource patch properties. </summary>
        internal L2IsolationDomainPatchProperties Properties { get; set; }

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
                    Properties = new L2IsolationDomainPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Maximum transmission unit. Default value is 1500. </summary>
        public int? Mtu
        {
            get
            {
                return Properties is null ? default : Properties.Mtu;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L2IsolationDomainPatchProperties();
                }
                Properties.Mtu = value;
            }
        }

        /// <summary> Extended VLAN status. </summary>
        public NetworkFabricExtendedVlan? ExtendedVlan
        {
            get
            {
                return Properties is null ? default : Properties.ExtendedVlan;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L2IsolationDomainPatchProperties();
                }
                Properties.ExtendedVlan = value;
            }
        }

        /// <summary> ARM Resource ID of the networkToNetworkInterconnectId of the L2 ISD resource. </summary>
        public ResourceIdentifier NetworkToNetworkInterconnectId
        {
            get
            {
                return Properties is null ? default : Properties.NetworkToNetworkInterconnectId;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new L2IsolationDomainPatchProperties();
                }
                Properties.NetworkToNetworkInterconnectId = value;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricL2IsolationDomainPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricL2IsolationDomainPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricL2IsolationDomainPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricL2IsolationDomainPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricL2IsolationDomainPatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkFabricL2IsolationDomainPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricL2IsolationDomainPatch IPersistableModel<NetworkFabricL2IsolationDomainPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkFabricL2IsolationDomainPatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkFabricL2IsolationDomainPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkFabricL2IsolationDomainPatch"> The <see cref="NetworkFabricL2IsolationDomainPatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkFabricL2IsolationDomainPatch networkFabricL2IsolationDomainPatch)
        {
            if (networkFabricL2IsolationDomainPatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkFabricL2IsolationDomainPatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkFabricL2IsolationDomainPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricL2IsolationDomainPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricL2IsolationDomainPatch)} does not support writing '{format}' format.");
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
        NetworkFabricL2IsolationDomainPatch IJsonModel<NetworkFabricL2IsolationDomainPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkFabricL2IsolationDomainPatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricL2IsolationDomainPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricL2IsolationDomainPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricL2IsolationDomainPatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkFabricL2IsolationDomainPatch DeserializeNetworkFabricL2IsolationDomainPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            L2IsolationDomainPatchProperties properties = default;
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
                    properties = L2IsolationDomainPatchProperties.DeserializeL2IsolationDomainPatchProperties(prop.Value, options);
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
            return new NetworkFabricL2IsolationDomainPatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties, identity);
        }
    }
}
