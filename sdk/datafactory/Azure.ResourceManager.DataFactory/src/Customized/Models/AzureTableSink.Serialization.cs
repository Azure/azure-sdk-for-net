// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // The MPG generator emits <ExternalType>.Deserialize<ExternalType>(element, options) for properties whose
    // type is an Azure.Core.Expressions.DataFactory type (mapped via @@alternateType identity), but those static
    // Deserialize overloads do not exist (CS0117). Each property below redirects deserialization to a shared,
    // correct ModelReaderWriter-based reader via [CodeGenSerialization].
    // TODO: remove once the generator emits correct deserialization for identity-aliased types (#59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AzureTableDefaultPartitionKeyValue), DeserializationValueHook = nameof(ReadAzureTableDefaultPartitionKeyValue))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AzureTablePartitionKeyName), DeserializationValueHook = nameof(ReadAzureTablePartitionKeyName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AzureTableRowKeyName), DeserializationValueHook = nameof(ReadAzureTableRowKeyName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AzureTableInsertType), DeserializationValueHook = nameof(ReadAzureTableInsertType))]
    public partial class AzureTableSink
    {
        internal static void ReadAzureTableDefaultPartitionKeyValue(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadAzureTablePartitionKeyName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadAzureTableRowKeyName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadAzureTableInsertType(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }
}
