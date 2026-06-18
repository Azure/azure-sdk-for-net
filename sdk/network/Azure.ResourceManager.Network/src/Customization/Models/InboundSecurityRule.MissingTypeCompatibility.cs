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

        /// <summary> Converts the compatibility model to the generated resource data model. </summary>
        public static implicit operator InboundSecurityRuleData(InboundSecurityRule rule) => default;

        InboundSecurityRule IJsonModel<InboundSecurityRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new InboundSecurityRule();
        void IJsonModel<InboundSecurityRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        InboundSecurityRule IPersistableModel<InboundSecurityRule>.Create(BinaryData data, ModelReaderWriterOptions options) => new InboundSecurityRule();
        string IPersistableModel<InboundSecurityRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<InboundSecurityRule>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }
}
