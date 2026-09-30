// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    // Keep the released model in Models: only the replacement InboundSecurityRuleData resource type is generated.
    // The adapters below repair ResourceType forwarding, not complete legacy rule-payload conversion.
    /// <summary> Compatibility type for inbound security rules. </summary>
    public partial class InboundSecurityRule : NetworkResourceData, IJsonModel<InboundSecurityRule>, IPersistableModel<InboundSecurityRule>
    {
        /// <summary> Initializes a new instance of <see cref="InboundSecurityRule"/>. </summary>
        public InboundSecurityRule()
        {
            Rules = new List<InboundSecurityRules>();
        }

        /// <summary> The rule type. </summary>
        public InboundSecurityRuleType? RuleType { get; set; }

        /// <summary> Inbound security rules. </summary>
        public IList<InboundSecurityRules> Rules { get; }

        /// <summary> Provisioning state. </summary>
        public NetworkProvisioningState? ProvisioningState { get; }

        /// <summary> Entity tag. </summary>
        public ETag? ETag { get; }

        // Do not discard native metadata when adapting the legacy type; other rule fields remain outside this repair.
        /// <summary> Converts the compatibility model to the generated resource data model. </summary>
        public static implicit operator InboundSecurityRuleData(InboundSecurityRule rule)
            => rule is null ? null : new InboundSecurityRuleData { ResourceType = rule.ResourceType };

        // The legacy type has no generated reader; reuse the base reader to retain ResourceType.
        InboundSecurityRule IJsonModel<InboundSecurityRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromMetadata(((IJsonModel<NetworkResourceData>)new NetworkResourceData()).Create(ref reader, options));

        // Call the base core directly: covariant interface delegation would re-enter this writer recursively.
        void IJsonModel<InboundSecurityRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            base.JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }
        // Reuse the generated base persistence reader; the legacy adapter currently restores only ResourceType.
        InboundSecurityRule IPersistableModel<InboundSecurityRule>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromMetadata(ModelReaderWriter.Read<NetworkResourceData>(data, options, AzureResourceManagerNetworkContext.Default));

        string IPersistableModel<InboundSecurityRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        // Preserve native metadata persistence and the base writer's read-only wire visibility rules.
        BinaryData IPersistableModel<InboundSecurityRule>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write<NetworkResourceData>(this, options, AzureResourceManagerNetworkContext.Default);

        // Transfer only the repaired ResourceType path; this is not full legacy-payload deserialization.
        private static InboundSecurityRule FromMetadata(NetworkResourceData metadata)
            => metadata is null ? null : new InboundSecurityRule { ResourceType = metadata.ResourceType };

        // Let the generated base serialize metadata and decide which fields belong in persisted versus wire JSON.
        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => base.JsonModelWriteCore(writer, options);
    }
}
