// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Management
{
    // only apply for MPG
    internal class RestClientVisitor : ScmLibraryVisitor
    {
        /// <inheritdoc/>
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is not null && type is ClientProvider client)
            {
                // omit methods for ClientProvider, MPG will implement its own client methods
                // put create request methods to client directly and remove RestClientProvider
                type.Update(methods: [.. client.RestClient.Methods], modifiers: TransfromPublicModifiersToInternal(type), relativeFilePath: TransformRelativeFilePathForClient(type));
            }

            if (type is RestClientProvider)
            {
                return null;
            }

            return type;
        }

        private static string TransformRelativeFilePathForClient(TypeProvider type)
            => Path.Combine("src", "Generated", "RestOperations", $"{type.Name}RestOperations.cs");

        private static TypeSignatureModifiers TransfromPublicModifiersToInternal(TypeProvider type)
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
}
