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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Query), DeserializationValueHook = nameof(ReadQuery))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PageSize), DeserializationValueHook = nameof(ReadPageSize))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(PreferredRegions), DeserializationValueHook = nameof(ReadPreferredRegions))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(DetectDatetime), DeserializationValueHook = nameof(ReadDetectDatetime))]
    public partial class CosmosDBSqlApiSource
    {
        internal static void ReadQuery(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadPageSize(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadPreferredRegions(JsonProperty property, ref DataFactoryElement<IList<string>> value)
            => value = DataFactoryExpressionSerialization.ReadElement<IList<string>>(property);

        internal static void ReadDetectDatetime(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);
    }
}
