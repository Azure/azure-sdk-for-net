// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility type for inbound security rules. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This model is obsolete. Please use InboundSecurityRuleData instead.")]
    public partial class InboundSecurityRule : NetworkResourceData, IJsonModel<InboundSecurityRule>, IPersistableModel<InboundSecurityRule>
    {
        private readonly InboundSecurityRuleProperties _properties;

        /// <summary> Initializes a new instance of <see cref="InboundSecurityRule"/>. </summary>
        public InboundSecurityRule() : this(default, default, default, default, new InboundSecurityRuleProperties(), default)
        {
        }

        internal InboundSecurityRule(ResourceIdentifier id, string name, ResourceType? resourceType, ETag? etag, InboundSecurityRuleProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(id, additionalBinaryDataProperties, name, resourceType)
        {
            ETag = etag;
            _properties = properties ?? new InboundSecurityRuleProperties();
        }

        /// <summary> The rule type. </summary>
        public InboundSecurityRuleType? RuleType
        {
            get => _properties.RuleType;
            set => _properties.RuleType = value;
        }

        /// <summary> Inbound security rules. </summary>
        public IList<InboundSecurityRules> Rules => _properties.Rules;

        /// <summary> Provisioning state. </summary>
        public NetworkProvisioningState? ProvisioningState => _properties.ProvisioningState;

        /// <summary> Entity tag. </summary>
        public ETag? ETag { get; }

        /// <summary> Converts the compatibility model to the generated resource data model. </summary>
        public static implicit operator InboundSecurityRuleData(InboundSecurityRule rule)
        {
            if (rule is null)
            {
                return null;
            }
            var additionalProperties = rule._additionalBinaryDataProperties is null
                ? new Dictionary<string, BinaryData>()
                : new Dictionary<string, BinaryData>(rule._additionalBinaryDataProperties);
            // The current resource schema omits etag; retain the released metadata in persisted JSON and conversion.
            if (rule.ETag.HasValue)
            {
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStringValue(rule.ETag.Value.ToString());
                }
                additionalProperties["etag"] = BinaryData.FromBytes(stream.ToArray());
            }
            return new InboundSecurityRuleData(rule.Id, additionalProperties, rule.Name, rule.ResourceType, rule._properties);
        }

        InboundSecurityRule IJsonModel<InboundSecurityRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (InboundSecurityRule)JsonModelCreateCore(ref reader, options);

        void IJsonModel<InboundSecurityRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }
        InboundSecurityRule IPersistableModel<InboundSecurityRule>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (InboundSecurityRule)PersistableModelCreateCore(data, options);

        string IPersistableModel<InboundSecurityRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<InboundSecurityRule>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            // Serialize a distinct native instance, not this derived model through a covariant interface.
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write<InboundSecurityRuleData>(this, options, AzureResourceManagerNetworkContext.Default));
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }

        /// <inheritdoc/>
        protected override NetworkSubResource JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement, options);
        }

        /// <inheritdoc/>
        protected override NetworkSubResource PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return Deserialize(document.RootElement, options);
        }

        /// <inheritdoc/>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write<InboundSecurityRuleData>(this, options, AzureResourceManagerNetworkContext.Default);

        private static InboundSecurityRule Deserialize(JsonElement element, ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(InboundSecurityRule)} does not support reading '{options.Format}' format.");
            }
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            // Reuse the generated resource/property readers for rules, provisioning state, unknown fields and wire formats.
            InboundSecurityRuleData data = InboundSecurityRuleData.DeserializeInboundSecurityRuleData(element, options);
            ETag? etag = element.TryGetProperty("etag", out JsonElement etagElement) && etagElement.ValueKind != JsonValueKind.Null
                ? new ETag(etagElement.GetString()) : default;
            var additionalProperties = new Dictionary<string, BinaryData>();
            if (options.Format != "W")
            {
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    if (property.Name != "id" && property.Name != "name" && property.Name != "type" && property.Name != "properties")
                    {
                        additionalProperties[property.Name] = BinaryData.FromString(property.Value.GetRawText());
                    }
                }
            }
            return new InboundSecurityRule(data.Id, data.Name, data.ResourceType, etag, data.Properties, additionalProperties);
        }
    }
}
