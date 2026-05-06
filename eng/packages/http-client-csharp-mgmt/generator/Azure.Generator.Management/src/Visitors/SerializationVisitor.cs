// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Snippets;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

internal class SerializationVisitor : ScmLibraryVisitor
{
    internal const string ToRequestContentMethodName = "ToRequestContent";
    internal const string FromResponseMethodName = "FromResponse";
    private static readonly CSharpType _userAssignedIdentityType = typeof(UserAssignedIdentity);

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
        if (expression is { MethodName: "DeserializeUserAssignedIdentity", InstanceReference: TypeReferenceExpression typeReference } &&
            typeReference.Type?.Name == nameof(UserAssignedIdentity) &&
            expression.Arguments.Count > 0)
        {
            var element = expression.Arguments[0];
            return Static(typeof(ModelReaderWriter)).Invoke(
                nameof(ModelReaderWriter.Read),
                [
                    New.Instance(
                        typeof(BinaryData),
                        [
                            new MemberExpression(typeof(Encoding), nameof(Encoding.UTF8)).Invoke(
                                nameof(UTF8Encoding.GetBytes),
                                [element.Invoke(nameof(JsonElement.GetRawText))])
                        ]),
                    ModelSerializationExtensionsSnippets.Wire,
                    ModelReaderWriterContextSnippets.Default
                ],
                [_userAssignedIdentityType],
                false);
        }

        return base.VisitInvokeMethodExpression(expression, method);
    }
}
