// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Visitors;

internal class RestClientVisitor : ScmLibraryVisitor
{
    /// <inheritdoc/>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is ClientProvider client)
        {
            // Management output discovery uses the convenience methods before visitors run.
            // Replace them with request methods only after that discovery is complete.
            type.Update(
                methods: [.. client.RestClient.Methods],
                modifiers: TransformPublicModifiersToInternal(type));

            if (client.ClientOptions is not null)
            {
                foreach (var property in type.Properties)
                {
                    if (property.Modifiers.HasFlag(MethodSignatureModifiers.Virtual))
                    {
                        property.Update(modifiers: property.Modifiers & ~MethodSignatureModifiers.Virtual);
                    }
                }
            }
        }

        if (type is RestClientProvider)
        {
            return null;
        }

        return type;
    }

    private static TypeSignatureModifiers TransformPublicModifiersToInternal(TypeProvider type)
    {
        var modifiers = type.DeclarationModifiers;
        if (modifiers.HasFlag(TypeSignatureModifiers.Public))
        {
            modifiers &= ~TypeSignatureModifiers.Public;
            modifiers |= TypeSignatureModifiers.Internal;
        }

        return modifiers;
    }
}
