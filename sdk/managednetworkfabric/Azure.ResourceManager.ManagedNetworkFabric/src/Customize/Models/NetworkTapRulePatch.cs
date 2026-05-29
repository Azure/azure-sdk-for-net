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
    //    C# patch shape is renamed to NetworkTapRulePatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkTapRulePatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkTapRulePatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The NetworkTapRule resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkTapRulePatchContent instead.")]
    public partial class NetworkTapRulePatch : NetworkRackPatch, IJsonModel<NetworkTapRulePatch>, IPersistableModel<NetworkTapRulePatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapRulePatch"/>. </summary>
        public NetworkTapRulePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapRulePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Tap Rule Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkTapRulePatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkTapRulePatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Tap Rule Patch properties. </summary>
        internal NetworkTapRulePatchProperties Properties { get; set; }

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
                    Properties = new NetworkTapRulePatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Input method to configure Network Tap Rule. </summary>
        public NetworkFabricConfigurationType? ConfigurationType
        {
            get
            {
                return Properties is null ? default : Properties.ConfigurationType;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRulePatchProperties();
                }
                Properties.ConfigurationType = value;
            }
        }

        /// <summary> Network Tap Rules file URL. </summary>
        public Uri TapRulesUri
        {
            get
            {
                return Properties is null ? default : Properties.TapRulesUri;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRulePatchProperties();
                }
                Properties.TapRulesUri = value;
            }
        }

        /// <summary> List of match configurations. </summary>
        public IList<NetworkTapRuleMatchConfiguration> MatchConfigurations
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRulePatchProperties();
                }
                return Properties.MatchConfigurations;
            }
        }

        /// <summary> List of dynamic match configurations. </summary>
        public IList<CommonDynamicMatchConfiguration> DynamicMatchConfigurations
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRulePatchProperties();
                }
                return Properties.DynamicMatchConfigurations;
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
                    Properties = new NetworkTapRulePatchProperties();
                }
                Properties.IdentitySelector = value;
            }
        }

        /// <summary> Global network tap rule actions. </summary>
        public GlobalNetworkTapRuleActionPatchProperties GlobalNetworkTapRuleActions
        {
            get
            {
                return Properties is null ? default : Properties.GlobalNetworkTapRuleActions;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapRulePatchProperties();
                }
                Properties.GlobalNetworkTapRuleActions = value;
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkTapRulePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkTapRulePatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkTapRulePatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkTapRulePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkTapRulePatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkTapRulePatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkTapRulePatch IPersistableModel<NetworkTapRulePatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkTapRulePatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkTapRulePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkTapRulePatch"> The <see cref="NetworkTapRulePatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkTapRulePatch networkTapRulePatch)
        {
            if (networkTapRulePatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkTapRulePatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkTapRulePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkTapRulePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkTapRulePatch)} does not support writing '{format}' format.");
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
        NetworkTapRulePatch IJsonModel<NetworkTapRulePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkTapRulePatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkTapRulePatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkTapRulePatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkTapRulePatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkTapRulePatch DeserializeNetworkTapRulePatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            NetworkTapRulePatchProperties properties = default;
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
                    properties = NetworkTapRulePatchProperties.DeserializeNetworkTapRulePatchProperties(prop.Value, options);
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
            return new NetworkTapRulePatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties, identity);
        }
    }
}
