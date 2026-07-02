// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

internal class SerializationVisitor : ScmLibraryVisitor
{
    internal const string ToRequestContentMethodName = "ToRequestContent";
    internal const string FromResponseMethodName = "FromResponse";

    /// <inheritdoc/>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is MrwSerializationTypeDefinition serializationType)
        {
            foreach (var method in serializationType.Methods)
            {
                TryUpdateExplicitCreateMethod(method);
            }
        }

        return base.VisitType(type);
    }

    /// <inheritdoc/>
    protected override MethodProvider? VisitMethod(MethodProvider method)
    {
        TryUpdateExplicitCreateMethod(method);

        if (method.EnclosingType is MrwSerializationTypeDefinition serializationType && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator))
        {
            var modifiers = method.Signature.Modifiers & ~MethodSignatureModifiers.Operator & ~MethodSignatureModifiers.Public | MethodSignatureModifiers.Internal;
            if (modifiers.HasFlag(MethodSignatureModifiers.Implicit))
            {
                modifiers &= ~MethodSignatureModifiers.Implicit;
                method.Signature.Update(modifiers: modifiers, name: ToRequestContentMethodName);
            }
            else if (modifiers.HasFlag(MethodSignatureModifiers.Explicit))
            {
                modifiers &= ~MethodSignatureModifiers.Explicit;
                if (HasBaseFromResponse(serializationType))
                {
                    // Static FromResponse methods hide by name and parameter list; the return type is not
                    // considered. Make the intended hiding explicit when the base model also has one.
                    modifiers |= MethodSignatureModifiers.New;
                }
                method.Signature.Update(modifiers: modifiers, name: FromResponseMethodName);
            }
        }
        return base.VisitMethod(method);
    }

    private static bool HasBaseFromResponse(MrwSerializationTypeDefinition serializationType)
    {
        if (!ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(serializationType.Type, out var typeProvider)
            || typeProvider is not ModelProvider model)
        {
            return false;
        }

        var current = model.BaseModelProvider;
        while (current is not null)
        {
            if (current.SerializationProviders
                .OfType<MrwSerializationTypeDefinition>()
                .SelectMany(provider => provider.Methods)
                .Any(IsFromResponseMethod))
            {
                return true;
            }

            current = current.BaseModelProvider;
        }

        return false;
    }

    private static bool IsFromResponseMethod(MethodProvider method)
    {
        // SerializationVisitor rewrites the explicit Response conversion operator to FromResponse.
        // Depending on visitor ordering, base methods may still be in their pre-rewrite operator form.
        if (method.Signature.Parameters is not [var parameter] || !parameter.Type.AreNamesEqual(typeof(Response)))
        {
            return false;
        }

        return method.Signature.Name == FromResponseMethodName
            || (method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator)
                && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit));
    }

    private static bool TryUpdateExplicitCreateMethod(MethodProvider method)
    {
        // TODO: Move this to Microsoft.TypeSpec.Generator.ClientModel, which owns MRW serialization method emission.
        // See https://github.com/microsoft/typespec/issues/10780.
        // MPG can have ResourceData unknown discriminator models where the concrete unknown type implements
        // IJsonModel<BaseResourceData>. CreateCore dispatch may return any derived base type, so cast to the interface
        // return type instead of the concrete unknown type.
        if (method.EnclosingType is not MrwSerializationTypeDefinition
            || method.Signature.Name != nameof(IJsonModel<object>.Create)
            || method.Signature.ExplicitInterface is null
            || method.Signature.ReturnType is not { } returnType
            || method.Signature.Parameters.Count != 2
            || returnType.AreNamesEqual(method.EnclosingType.Type))
        {
            return false;
        }

        var firstParameter = method.Signature.Parameters[0];
        var createCoreMethodName = firstParameter.Type.AreNamesEqual(typeof(BinaryData))
            ? "PersistableModelCreateCore"
            : "JsonModelCreateCore";
        var arguments = method.Signature.Parameters.Select(p => p.AsArgument()).ToArray();
        var body = This.Invoke(createCoreMethodName, arguments).CastTo(returnType);
        method.Update(signature: method.Signature, bodyStatements: new MethodBodyStatement[] { Return(body) });
        return true;
    }
}
