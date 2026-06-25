// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.DataFactory;
using Microsoft.TypeSpec.Generator.Customizations;
using System;
using System.ClientModel.Primitives;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // The MPG generator emits <ExternalType>.Deserialize<ExternalType>(element, options) for properties whose
    // type is an Azure.Core.Expressions.DataFactory type (mapped via @@alternateType identity), but those static
    // Deserialize overloads do not exist (CS0117). Each property below redirects deserialization to a shared,
    // correct ModelReaderWriter-based reader via [CodeGenSerialization].
    // TODO: remove once the generator emits correct deserialization for identity-aliased types (#59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SchemaColumnName), DeserializationValueHook = nameof(ReadSchemaColumnName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SchemaColumnType), DeserializationValueHook = nameof(ReadSchemaColumnType))]
    public partial class DatasetSchemaDataElement
    {
        internal static void ReadSchemaColumnName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadSchemaColumnType(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }

    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/58691 :
    // CodeGenMember restores the mutable AdditionalProperties API surface, but the generator then emits a
    // Deserialize catch-all that writes to the undeclared dditionalBinaryDataProperties local (CS0103).
    // TODO: remove once the generator emits a consistent additional-properties local name (#58691).
    [CodeGenSuppress("DeserializeDatasetSchemaDataElement", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class DatasetSchemaDataElement
    {
        internal static DatasetSchemaDataElement DeserializeDatasetSchemaDataElement(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataFactoryElement<string> schemaColumnName = default;
            DataFactoryElement<string> schemaColumnType = default;
            ChangeTrackingDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    ReadSchemaColumnName(prop, ref schemaColumnName);
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    ReadSchemaColumnType(prop, ref schemaColumnType);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DatasetSchemaDataElement(schemaColumnName, schemaColumnType, new ReadOnlyDictionary<string, BinaryData>(additionalProperties));
        }
    }
}
