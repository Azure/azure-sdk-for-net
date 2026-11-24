// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Primitives;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
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

    protected override MethodBodyStatement? VisitStatements(MethodBodyStatements statements, MethodProvider method)
    {
        if (method.EnclosingType is MrwSerializationTypeDefinition serializationType
            && method.Signature.Name == "JsonModelWriteCore"
            && method.Signature.Parameters is [_, var options]
            && ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(serializationType.Type, out var provider)
            && provider is ManagementModelProvider { HasPersistenceOnlyExtensions: true } model
            && statements.Statements.Any(statement => IsStatusExtensionWrite(statement, model)))
        {
            // Closed ARM ErrorDetail accepts extension data from responses for JSON persistence,
            // but these extensions are not fields in the request contract.
            var persist = ((VariableExpression)options).Property(nameof(ModelReaderWriterOptions.Format)).NotEqual(Literal("W"));
            return new MethodBodyStatements(statements.Statements.Select(statement =>
                IsStatusExtensionWrite(statement, model) && statement is ForEachStatement loop
                    ? GuardStatusExtensionWrite(loop, model, persist)
                    : statement).ToArray());
        }

        return base.VisitStatements(statements, method);
    }

    private static IfStatement GuardStatusExtensionWrite(ForEachStatement loop, ManagementModelProvider model, ValueExpression persist)
    {
        // A caller can populate the synthetic extension bag. Only the typed property
        // owns its wire name, even if its value is absent.
        var declaredNames = model.CanonicalView.Properties
            .Where(property => !property.IsAdditionalProperties && property.WireInfo is { IsHttpMetadata: false })
            .Select(property => (property.WireInfo!.SerializationOptions as ScmSerializationOptions)?.Json?.Name ?? property.WireInfo.SerializedName)
            .Distinct(StringComparer.Ordinal);
        var key = loop.ItemVariable.Property("Key");
        var filter = declaredNames.Select(name => key.Equal(Literal(name)))
            .Aggregate((ValueExpression?)null, (condition, equal) => condition is null ? equal : condition.As<bool>().Or(equal));
        if (filter is not null)
        {
            loop.Body.Insert(0, new IfStatement(filter) { Continue });
        }
        return new IfStatement(persist) { loop };
    }

    private static bool IsStatusExtensionWrite(MethodBodyStatement statement, ManagementModelProvider model)
        => statement is ForEachStatement { Enumerable: DictionaryExpression { Original: MemberExpression { Inner: null, MemberName: var name } } }
            && model.Properties.Any(property => property.IsAdditionalProperties && property.Name == name);

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
