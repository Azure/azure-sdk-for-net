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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(EncodingName), DeserializationValueHook = nameof(ReadEncodingName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ColumnDelimiter), DeserializationValueHook = nameof(ReadColumnDelimiter))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RowDelimiter), DeserializationValueHook = nameof(ReadRowDelimiter))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(EscapeChar), DeserializationValueHook = nameof(ReadEscapeChar))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(QuoteChar), DeserializationValueHook = nameof(ReadQuoteChar))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(NullValue), DeserializationValueHook = nameof(ReadNullValue))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(FirstRowAsHeader), DeserializationValueHook = nameof(ReadFirstRowAsHeader))]
    internal partial class DelimitedTextDatasetTypeProperties
    {
        internal static void ReadEncodingName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadColumnDelimiter(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadRowDelimiter(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadEscapeChar(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadQuoteChar(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadNullValue(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadFirstRowAsHeader(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);
    }
}
