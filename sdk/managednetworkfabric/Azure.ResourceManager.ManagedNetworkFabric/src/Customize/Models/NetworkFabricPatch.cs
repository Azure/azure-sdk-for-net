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
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Network Fabric resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricPatchContent instead.")]
    public partial class NetworkFabricPatch : NetworkRackPatch, IJsonModel<NetworkFabricPatch>, IPersistableModel<NetworkFabricPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricPatchContent instead.")]
        public NetworkFabricPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Fabric Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkFabricPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Fabric Patch properties. </summary>
        internal NetworkFabricPatchProperties Properties { get; set; }

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
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Number of compute racks associated to Network Fabric. </summary>
        public int? RackCount
        {
            get
            {
                return Properties is null ? default : Properties.RackCount;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.RackCount = value;
            }
        }

        /// <summary> Number of servers.Possible values are from 1-16. </summary>
        public int? ServerCountPerRack
        {
            get
            {
                return Properties is null ? default : Properties.ServerCountPerRack;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.ServerCountPerRack = value;
            }
        }

        /// <summary> IPv4Prefix for Management Network. Example: 10.1.0.0/19. </summary>
        public string IPv4Prefix
        {
            get
            {
                return Properties is null ? default : Properties.IPv4Prefix;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.IPv4Prefix = value;
            }
        }

        /// <summary> IPv6Prefix for Management Network. Example: 3FFE:FFFF:0:CD40::/59. </summary>
        public string IPv6Prefix
        {
            get
            {
                return Properties is null ? default : Properties.IPv6Prefix;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.IPv6Prefix = value;
            }
        }

        /// <summary> ASN of CE devices for CE/PE connectivity. </summary>
        public long? FabricAsn
        {
            get
            {
                return Properties is null ? default : Properties.FabricAsn;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.FabricAsn = value;
            }
        }

        /// <summary> Network and credentials configuration already applied to terminal server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use TerminalServerSettings instead.")]
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration
        {
            get
            {
                return Properties is null ? default : NetworkFabricPatchablePropertiesTerminalServerConfiguration.FromNetworkFabricTerminalServerPatchConfiguration(Properties.TerminalServerSettings);
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.TerminalServerSettings = value?.ToNetworkFabricTerminalServerPatchConfiguration();
            }
        }

        /// <summary> Configuration to be used to setup the management network. </summary>
        public ManagementNetworkConfigurationPatchableProperties ManagementNetworkConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.ManagementNetworkConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.ManagementNetworkConfiguration = value;
            }
        }

        /// <summary> Bring your own storage account configurations for Network Fabric. </summary>
        public StorageAccountPatchConfiguration StorageAccountConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.StorageAccountConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.StorageAccountConfiguration = value;
            }
        }

        /// <summary> Hardware alert threshold percentage. Possible values are from 20 to 100. </summary>
        public int? HardwareAlertThreshold
        {
            get
            {
                return Properties is null ? default : Properties.HardwareAlertThreshold;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.HardwareAlertThreshold = value;
            }
        }

        /// <summary> Control Plane Access Control List ARM resource IDs. </summary>
        public IList<ResourceIdentifier> ControlPlaneAcls
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.ControlPlaneAcls;
            }
        }

        /// <summary> Trusted IP Prefix ARM resource IDs. </summary>
        public IList<ResourceIdentifier> TrustedIPPrefixes
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.TrustedIPPrefixes;
            }
        }

        /// <summary> Unique Route Distinguisher configuration. </summary>
        public UniqueRouteDistinguisherPatchProperties UniqueRdConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.UniqueRdConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.UniqueRdConfiguration = value;
            }
        }

        /// <summary> NetworkFabric feature flag configuration information. </summary>
        public IList<NetworkFabricFeatureFlag> FeatureFlags
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.FeatureFlags;
            }
        }

        /// <summary> Authorized transciever configuration for NetworkFabric. </summary>
        public AuthorizedTransceiverPatchProperties AuthorizedTransceiver
        {
            get
            {
                return Properties is null ? default : Properties.AuthorizedTransceiver;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.AuthorizedTransceiver = value;
            }
        }

        /// <summary> QoS configuration state. Default is Disabled. </summary>
        public NetworkFabricQosConfigurationState? QosConfigurationState
        {
            get
            {
                return Properties is null ? default : Properties.QosConfigurationState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.QosConfigurationState = value;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricPatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkFabricPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricPatch IPersistableModel<NetworkFabricPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkFabricPatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkFabricPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkFabricPatch"> The <see cref="NetworkFabricPatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkFabricPatch networkFabricPatch)
        {
            if (networkFabricPatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkFabricPatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkFabricPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricPatch)} does not support writing '{format}' format.");
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
        NetworkFabricPatch IJsonModel<NetworkFabricPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkFabricPatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricPatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkFabricPatch DeserializeNetworkFabricPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            NetworkFabricPatchProperties properties = default;
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
                    properties = NetworkFabricPatchProperties.DeserializeNetworkFabricPatchProperties(prop.Value, options);
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
            return new NetworkFabricPatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties, identity);
        }
    }
}
