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
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Password), DeserializationValueHook = nameof(ReadPassword))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(UserName), DeserializationValueHook = nameof(ReadUserName))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Uri), DeserializationValueHook = nameof(ReadUri))]
    public partial class TeamDeskLinkedService
    {
        internal static void ReadPassword(JsonProperty property, ref DataFactorySecret value)
            => value = DataFactoryExpressionSerialization.ReadSecret(property);

        internal static void ReadUserName(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);

        internal static void ReadUri(JsonProperty property, ref DataFactoryElement<string> value)
            => value = DataFactoryExpressionSerialization.ReadElement<string>(property);
    }
}
