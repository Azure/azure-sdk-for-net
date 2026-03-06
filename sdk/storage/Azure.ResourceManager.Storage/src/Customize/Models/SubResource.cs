// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Workaround for generator bug: the generated NspAccessRuleProperties.Serialization.cs calls
// SubResource.DeserializeSubResource() which is internal to the Azure.ResourceManager assembly.
// This class shadows the ARM SubResource type within the Storage.Models namespace, providing
// a public DeserializeSubResource method while maintaining full API compatibility.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using ArmSubResource = Azure.ResourceManager.Resources.Models.SubResource;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Workaround for generator bug: shadows ARM SubResource to provide DeserializeSubResource. </summary>
    public class SubResource : ArmSubResource, IJsonModel<SubResource>, IPersistableModel<SubResource>
    {
        private readonly ResourceIdentifier _id;

        internal SubResource() { }

        internal SubResource(ResourceIdentifier id)
        {
            _id = id;
        }

        /// <inheritdoc />
        public override ResourceIdentifier Id => _id ?? base.Id;

        internal static SubResource DeserializeSubResource(JsonElement element, ModelReaderWriterOptions options)
        {
            ResourceIdentifier id = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    break;
                }
            }
            return new SubResource(id);
        }

        SubResource IJsonModel<SubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSubResource(doc.RootElement, options);
        }

        void IJsonModel<SubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ArmSubResource>)this).Write(writer, options);
        }

        SubResource IPersistableModel<SubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeSubResource(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }

        BinaryData IPersistableModel<SubResource>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ArmSubResource>)this).Write(options);
        }

        string IPersistableModel<SubResource>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<ArmSubResource>)this).GetFormatFromOptions(options);
        }
    }
}
