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
    //    C# patch shape is renamed to NetworkFabricControllerPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricControllerPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricControllerPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Network Fabric Controller Patch payload definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricControllerPatchContent instead.")]
    public partial class NetworkFabricControllerPatch : NetworkRackPatch, IJsonModel<NetworkFabricControllerPatch>, IPersistableModel<NetworkFabricControllerPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricControllerPatch"/>. </summary>
        public NetworkFabricControllerPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricControllerPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Fabric Controller patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricControllerPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkFabricControllerPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Fabric Controller patch properties. </summary>
        internal NetworkFabricControllerPatchProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> As part of an update, the Infrastructure ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Infrastructure services. (This is a Mandatory attribute). </summary>
        public IList<ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricControllerPatchProperties();
                }
                return Properties.InfrastructureExpressRouteConnections;
            }
        }

        /// <summary> As part of an update, the workload ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Workload services. (This is a Mandatory attribute). </summary>
        public IList<ExpressRouteConnectionInformation> WorkloadExpressRouteConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricControllerPatchProperties();
                }
                return Properties.WorkloadExpressRouteConnections;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricControllerPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkFabricControllerPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricControllerPatch IPersistableModel<NetworkFabricControllerPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkFabricControllerPatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkFabricControllerPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkFabricControllerPatch"> The <see cref="NetworkFabricControllerPatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkFabricControllerPatch networkFabricControllerPatch)
        {
            if (networkFabricControllerPatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkFabricControllerPatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkFabricControllerPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support writing '{format}' format.");
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
        NetworkFabricControllerPatch IJsonModel<NetworkFabricControllerPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkFabricControllerPatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricControllerPatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkFabricControllerPatch DeserializeNetworkFabricControllerPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            NetworkFabricControllerPatchProperties properties = default;
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
                    properties = NetworkFabricControllerPatchProperties.DeserializeNetworkFabricControllerPatchProperties(prop.Value, options);
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
            return new NetworkFabricControllerPatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties, identity);
        }
    }
}
