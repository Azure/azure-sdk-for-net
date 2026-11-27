// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Text.Json;

namespace Azure.Generator.Management.Providers;

/// <summary>
/// Exposes the serialization writer hook of an existing ARM framework base to MTG.
/// </summary>
/// <remarks>
/// MTG's SystemObjectModelProvider maps the input model to its CLR type, but does not expose
/// the CLR methods. Its serialization generator therefore cannot discover the protected
/// JsonModelWriteCore hook on ResourceData and TrackedResourceData, and would generate a new
/// virtual writer without a base call, losing inherited properties during serialization.
/// Describe that hook only when reflection confirms that the CLR method can be overridden.
/// Do not advertise full MRW support: these bases do not expose the other MRW core methods,
/// so doing so would also generate overrides of nonexistent methods.
/// This provider represents an existing type and is never emitted. Supplying method metadata
/// lets MTG generate writer chaining itself instead of repairing generated method bodies in a visitor.
/// </remarks>
internal sealed class MgmtObjectModelProvider : SystemObjectModelProvider
{
    public MgmtObjectModelProvider(CSharpType systemType, InputModelType inputModel)
        : base(systemType, inputModel)
    {
    }

    protected override MethodProvider[] BuildMethods()
    {
        var method = SystemType.FrameworkType.GetMethod(
            "JsonModelWriteCore",
            genericParameterCount: 0,
            bindingAttr: BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.ExactBinding,
            binder: null,
            types: [typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions)],
            modifiers: null);
        if (method is not { IsFamily: true, IsVirtual: true, IsFinal: false, IsStatic: false }
            || method.ReturnType != typeof(void))
        {
            return [];
        }

        return
        [
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
}
