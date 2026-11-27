// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.Generator.Management.Providers;

internal sealed class MgmtObjectModelProvider : SystemObjectModelProvider
{
    public MgmtObjectModelProvider(CSharpType systemType, InputModelType inputModel)
        : base(systemType, inputModel)
    {
    }

    protected override MethodProvider[] BuildMethods() =>
    [
        // ARM framework bases expose this overridable hook, but not the full MRW contract.
        // Describe it so MTG can generate writer chaining without rewriting serialization bodies.
        // This provider represents an existing type and is never emitted.
        new MethodProvider(
            new MethodSignature(
                "JsonModelWriteCore",
                null,
                MethodSignatureModifiers.Protected | MethodSignatureModifiers.Virtual,
                null,
                null,
                [
                    new ParameterProvider("writer", $"The JSON writer.", typeof(Utf8JsonWriter)),
                    new ParameterProvider("options", $"The model serialization options.", typeof(ModelReaderWriterOptions))
                ]),
            MethodBodyStatement.Empty,
            this)
    ];
}
