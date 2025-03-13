// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator
{
    // only apply for MPG
    internal class RestClientVisitor : ScmLibraryVisitor
    {
        /// <inheritdoc/>
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is not null && type is ClientProvider)
            {
                type.Update(modifiers: TransfromPublicModifiersToInternal(type), relativeFilePath: TransformRelativeFilePathForClient(type));
            }
            // TODO: uncomment this once resources are generated
            //if (type is RestClientProvider)
            //{
            //    type.Update(modifiers: TransfromPublicModifiersToInternal(type), relativeFilePath: TransformRelativeFilePathForRestClient(type));
            //}
            return type;
        }

        private static string TransformRelativeFilePathForClient(TypeProvider type)
            => Path.Combine("src", "Generated", "RestOperations", $"{type.Name}RestOperations.cs");

        private static string TransformRelativeFilePathForRestClient(TypeProvider type)
            => Path.Combine("src", "Generated", "RestOperations", $"{type.Name}.RestClient.cs");

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
