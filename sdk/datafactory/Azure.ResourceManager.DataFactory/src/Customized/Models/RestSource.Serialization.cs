// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(HttpRequestTimeout), DeserializationValueHook = nameof(ReadHttpRequestTimeout))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RequestMethod), DeserializationValueHook = nameof(ReadRequestMethod))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(RequestBody), DeserializationValueHook = nameof(ReadRequestBody))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AdditionalHeaders), DeserializationValueHook = nameof(ReadAdditionalHeaders))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PaginationRules), DeserializationValueHook = nameof(ReadPaginationRules))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AdditionalColumns), DeserializationValueHook = nameof(ReadAdditionalColumns))]
    public partial class RestSource
    {
        internal static void ReadHttpRequestTimeout(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadRequestMethod(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadRequestBody(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadAdditionalHeaders(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadPaginationRules(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadAdditionalColumns(JsonProperty property, ref DataFactoryElement<IDictionary<string, string>> value)
            => value = DataFactoryExpressionSerialization.ReadElement<IDictionary<string, string>>(property);
    }
}
