// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System.IO;

namespace Azure.Generator
{
    // only apply for MPG
    internal class AzureArmVisitor : ScmLibraryVisitor
    {
        /// <inheritdoc/>
        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (type is ClientProvider)
            {
                type.Update(modifiers: TransfromPublicModifiersToInternal(type), relativeFilePath: TransformRelativeFilePathForClient(type));
            }
            // TODO: uncomment this once resources are generated
            //if (type is RestClientProvider)
            //{
            //    type.Update(modifiers: TransfromModifiers(type), relativeFilePath: TransformRelativeFilePathForRestClient(type));
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
