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
    /// <summary> Encryption settings for a virtual network. </summary>
    [CodeGenSuppress("DeserializeVirtualNetworkEncryption", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class VirtualNetworkEncryption
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="IsEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsEnabled instead.")]
        public bool Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }

        // The preserved constructor parameter name differs from the renamed property.
        internal static VirtualNetworkEncryption DeserializeVirtualNetworkEncryption(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            bool isEnabled = default;
            VirtualNetworkEncryptionEnforcement? enforcement = default;
            var additionalProperties = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"))
                {
                    isEnabled = property.Value.GetBoolean();
                }
                else if (property.NameEquals("enforcement"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        enforcement = new VirtualNetworkEncryptionEnforcement(property.Value.GetString());
                    }
                }
                else if (options?.Format != "W")
                {
                    additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new VirtualNetworkEncryption(isEnabled, enforcement, additionalProperties);
        }
    }
}
