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
    //    C# patch shape is renamed to NetworkFabricIPExtendedCommunityPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricIPExtendedCommunityPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricIPExtendedCommunityPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The IP Extended Communities patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricIPExtendedCommunityPatchContent instead.")]
    public partial class NetworkFabricIPExtendedCommunityPatch : NetworkRackPatch, IJsonModel<NetworkFabricIPExtendedCommunityPatch>, IPersistableModel<NetworkFabricIPExtendedCommunityPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPExtendedCommunityPatch"/>. </summary>
        public NetworkFabricIPExtendedCommunityPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPExtendedCommunityPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> IP Extended Community patchable properties. </param>
        internal NetworkFabricIPExtendedCommunityPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, IpExtendedCommunityPatchProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> IP Extended Community patchable properties. </summary>
        internal IpExtendedCommunityPatchProperties Properties { get; set; }

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
                    Properties = new IpExtendedCommunityPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> List of IP Extended Community Rules. </summary>
        public IList<IPExtendedCommunityRule> IPExtendedCommunityRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new IpExtendedCommunityPatchProperties();
                }
                return Properties.IPExtendedCommunityRules;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricIPExtendedCommunityPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricIPExtendedCommunityPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricIPExtendedCommunityPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricIPExtendedCommunityPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricIPExtendedCommunityPatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkFabricIPExtendedCommunityPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricIPExtendedCommunityPatch IPersistableModel<NetworkFabricIPExtendedCommunityPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkFabricIPExtendedCommunityPatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkFabricIPExtendedCommunityPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkFabricIPExtendedCommunityPatch"> The <see cref="NetworkFabricIPExtendedCommunityPatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkFabricIPExtendedCommunityPatch networkFabricIPExtendedCommunityPatch)
        {
            if (networkFabricIPExtendedCommunityPatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkFabricIPExtendedCommunityPatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkFabricIPExtendedCommunityPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricIPExtendedCommunityPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricIPExtendedCommunityPatch)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkFabricIPExtendedCommunityPatch IJsonModel<NetworkFabricIPExtendedCommunityPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkFabricIPExtendedCommunityPatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricIPExtendedCommunityPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricIPExtendedCommunityPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricIPExtendedCommunityPatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkFabricIPExtendedCommunityPatch DeserializeNetworkFabricIPExtendedCommunityPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            IpExtendedCommunityPatchProperties properties = default;
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
                    properties = IpExtendedCommunityPatchProperties.DeserializeIpExtendedCommunityPatchProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new NetworkFabricIPExtendedCommunityPatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties);
        }
    }
}
