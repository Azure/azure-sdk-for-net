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
                // When the enclosing model derives from another generated model in this library,
                // the base class will also emit a `static FromResponse(Response)` helper. The C#
                // compiler treats the derived helper as hiding the base one (CS0108). Emit the
                // `new` modifier so the derived helper is well-formed without SDK-side
                // [CodeGenSuppress] customizations.
                if (BaseHasFromResponse(method.EnclosingType))
                {
                    modifiers |= MethodSignatureModifiers.New;
                }
                method.Signature.Update(modifiers: modifiers, name: FromResponseMethodName);
            }
        }
        return base.VisitMethod(method);
    }

    private static bool BaseHasFromResponse(TypeProvider enclosingType)
    {
        // The MrwSerializationTypeDefinition is a partial of the underlying model. Its
        // CSharpType.BaseType reflects the model's declared base class. Any non-framework
        // base is another generated model in the same library that also emits the static
        // FromResponse(Response) helper via this same visitor.
        var baseType = enclosingType.Type.BaseType;
        return baseType is not null && !baseType.IsFrameworkType;
    }
}
