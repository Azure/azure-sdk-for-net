// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

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
}
