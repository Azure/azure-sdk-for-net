// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Destination of a routing rule. </summary>
    [CodeGenSuppress("DeserializeRoutingRuleRouteDestination", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class RoutingRuleRouteDestination
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="DestinationType"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use DestinationType instead.")]
        public RoutingRuleDestinationType Type
        {
            get => DestinationType;
            set => DestinationType = value;
        }

        // The preserved constructor parameter name differs from the renamed property.
        internal static RoutingRuleRouteDestination DeserializeRoutingRuleRouteDestination(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            RoutingRuleDestinationType destinationType = default;
            string destinationAddress = default;
            var additionalProperties = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    destinationType = new RoutingRuleDestinationType(property.Value.GetString());
                }
                else if (property.NameEquals("destinationAddress"))
                {
                    destinationAddress = property.Value.GetString();
                }
                else if (options?.Format != "W")
                {
                    additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new RoutingRuleRouteDestination(destinationType, destinationAddress, additionalProperties);
        }
    }
}
