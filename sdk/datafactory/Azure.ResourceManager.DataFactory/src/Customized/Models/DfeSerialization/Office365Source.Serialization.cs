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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(AllowedGroups), DeserializationValueHook = nameof(ReadAllowedGroups))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(UserScopeFilterUri), DeserializationValueHook = nameof(ReadUserScopeFilterUri))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(DateFilterColumn), DeserializationValueHook = nameof(ReadDateFilterColumn))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(StartOn), DeserializationValueHook = nameof(ReadStartOn))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(EndOn), DeserializationValueHook = nameof(ReadEndOn))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(OutputColumns), DeserializationValueHook = nameof(ReadOutputColumns))]
    public partial class Office365Source
    {
        internal static void ReadAllowedGroups(JsonProperty property, ref DataFactoryElement<IList<string>> value)
            => value = DataFactoryExpressionSerialization.ReadElement<IList<string>>(property);

        internal static void ReadUserScopeFilterUri(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadDateFilterColumn(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadStartOn(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadEndOn(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadOutputColumns(JsonProperty property, ref DataFactoryElement<IList<Office365TableOutputColumn>> value)
            => value = DataFactoryExpressionSerialization.ReadElement<IList<Office365TableOutputColumn>>(property);
    }
}
