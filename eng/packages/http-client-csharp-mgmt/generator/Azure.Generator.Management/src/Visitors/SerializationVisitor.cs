// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.Generator.Management.Visitors;

internal class SerializationVisitor : ScmLibraryVisitor
{
    internal const string ToRequestContentMethodName = "ToRequestContent";
    internal const string FromResponseMethodName = "FromResponse";

    /// <inheritdoc/>
    protected override MethodProvider? VisitMethod(MethodProvider method)
    {
        if (method.EnclosingType is MrwSerializationTypeDefinition && method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator))
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
                method.Signature.Update(modifiers: modifiers, name: FromResponseMethodName);
            }
        }
        return base.VisitMethod(method);
    }

    protected override ValueExpression? VisitInvokeMethodExpression(InvokeMethodExpression expression, MethodProvider method)
    {
        if (expression is { InstanceReference: TypeReferenceExpression typeReference, MethodName: { } methodName } &&
            methodName.StartsWith("Deserialize", StringComparison.Ordinal) &&
            typeReference.Type is not null &&
            KnownManagementTypes.TryGetSystemType(typeReference.Type, out var systemType) &&
            expression.Arguments.Count > 1)
        {
            var element = new ScopedApi<JsonElement>(expression.Arguments[0]);
            var options = new ScopedApi<ModelReaderWriterOptions>(expression.Arguments[1]);
            return ManagementClientGenerator.Instance.TypeFactory.DeserializeJsonValue(
                systemType,
                element,
                element.GetUtf8Bytes(),
                options,
                SerializationFormat.Default);
        }

        return base.VisitInvokeMethodExpression(expression, method);
    }
}
