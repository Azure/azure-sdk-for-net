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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ValidationMode), DeserializationValueHook = nameof(ReadValidationMode))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(DetectDataType), DeserializationValueHook = nameof(ReadDetectDataType))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Namespaces), DeserializationValueHook = nameof(ReadNamespaces))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(NamespacePrefixes), DeserializationValueHook = nameof(ReadNamespacePrefixes))]
    public partial class XmlReadSettings
    {
        internal static void ReadValidationMode(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadDetectDataType(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadNamespaces(JsonProperty property, ref DataFactoryElement<bool> value)
            => value = DataFactoryExpressionSerialization.ReadElement<bool>(property);

        internal static void ReadNamespacePrefixes(JsonProperty property, ref DataFactoryElement<IDictionary<string, string>> value)
            => value = DataFactoryExpressionSerialization.ReadElement<IDictionary<string, string>>(property);
    }
}
