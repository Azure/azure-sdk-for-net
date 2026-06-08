// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(BatchSize), DeserializationValueHook = nameof(ReadBatchSize))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(CustomRfcReadTableFunctionModule), DeserializationValueHook = nameof(ReadCustomRfcReadTableFunctionModule))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SapDataColumnDelimiter), DeserializationValueHook = nameof(ReadSapDataColumnDelimiter))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RowCount), DeserializationValueHook = nameof(ReadRowCount))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RowSkips), DeserializationValueHook = nameof(ReadRowSkips))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RfcTableFields), DeserializationValueHook = nameof(ReadRfcTableFields))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RfcTableOptions), DeserializationValueHook = nameof(ReadRfcTableOptions))]
    public partial class SapTableSource
    {
        internal static void ReadBatchSize(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadCustomRfcReadTableFunctionModule(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadSapDataColumnDelimiter(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadRowCount(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadRowSkips(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadRfcTableFields(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadRfcTableOptions(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }
}
