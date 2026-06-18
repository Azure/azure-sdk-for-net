// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("EffectiveNetworkSecurityGroup", typeof(NetworkSubResource), typeof(EffectiveNetworkSecurityGroupAssociation), typeof(IReadOnlyList<EffectiveNetworkSecurityRule>), typeof(string), typeof(IDictionary<string, BinaryData>))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("TagMap")]
    public partial class EffectiveNetworkSecurityGroup
    {
        [Azure.ResourceManager.Network.WirePath("tagMap")]
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public string TagMap { get; }

        public global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Collections.Generic.IList<global::System.String>> TagToIPAddresses => default;

        // The generated constructor and writer must reference the obsolete TagMap compatibility property.
        // TODO: Remove this SDK-side workaround after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        internal EffectiveNetworkSecurityGroup(NetworkSubResource networkSecurityGroup, EffectiveNetworkSecurityGroupAssociation association, IReadOnlyList<EffectiveNetworkSecurityRule> effectiveSecurityRules, string tagMap, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            NetworkSecurityGroup = networkSecurityGroup;
            Association = association;
            EffectiveSecurityRules = effectiveSecurityRules;
            TagMap = tagMap;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EffectiveNetworkSecurityGroup>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EffectiveNetworkSecurityGroup)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(NetworkSecurityGroup))
            {
                writer.WritePropertyName("networkSecurityGroup"u8);
                writer.WriteObjectValue(NetworkSecurityGroup, options);
            }
            if (Optional.IsDefined(Association))
            {
                writer.WritePropertyName("association"u8);
                writer.WriteObjectValue(Association, options);
            }
            if (Optional.IsCollectionDefined(EffectiveSecurityRules))
            {
                writer.WritePropertyName("effectiveSecurityRules"u8);
                writer.WriteStartArray();
                foreach (EffectiveNetworkSecurityRule item in EffectiveSecurityRules)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TagMap))
            {
                writer.WritePropertyName("tagMap"u8);
                writer.WriteStringValue(TagMap);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }
    }
}
