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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SourceRetryCount), DeserializationValueHook = nameof(ReadSourceRetryCount))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(SourceRetryWait), DeserializationValueHook = nameof(ReadSourceRetryWait))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(MaxConcurrentConnections), DeserializationValueHook = nameof(ReadMaxConcurrentConnections))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(DisableMetricsCollection), DeserializationValueHook = nameof(ReadDisableMetricsCollection))]
    public partial class CopyActivitySource
    {
        internal static void ReadSourceRetryCount(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadSourceRetryWait(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadMaxConcurrentConnections(JsonProperty property, ref DataFactoryElement<int> value)
            => value = DataFactoryExpressionSerialization.ReadElement<int>(property);

        internal static void ReadDisableMetricsCollection(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);
    }
}
