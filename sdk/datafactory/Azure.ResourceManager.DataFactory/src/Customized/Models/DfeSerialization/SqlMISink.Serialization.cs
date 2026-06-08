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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PreCopyScript), DeserializationValueHook = nameof(ReadPreCopyScript))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SqlWriterStoredProcedureName), DeserializationValueHook = nameof(ReadSqlWriterStoredProcedureName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SqlWriterTableType), DeserializationValueHook = nameof(ReadSqlWriterTableType))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(StoredProcedureTableTypeParameterName), DeserializationValueHook = nameof(ReadStoredProcedureTableTypeParameterName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(TableOption), DeserializationValueHook = nameof(ReadTableOption))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SqlWriterUseTableLock), DeserializationValueHook = nameof(ReadSqlWriterUseTableLock))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(WriteBehavior), DeserializationValueHook = nameof(ReadWriteBehavior))]
    public partial class SqlMISink
    {
        internal static void ReadPreCopyScript(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadSqlWriterStoredProcedureName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadSqlWriterTableType(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadStoredProcedureTableTypeParameterName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadTableOption(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadSqlWriterUseTableLock(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadWriteBehavior(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }
}
