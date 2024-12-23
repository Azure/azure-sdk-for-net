// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;

namespace Azure.Generator
{
    internal class AzureVisitor : ScmLibraryVisitor
    {
        /// <inheritdoc/>
        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (type is ClientProvider clientProvider)
            {
                type.Update(modifiers: TypeSignatureModifiers.Internal);
                return type;
            }
            return type;
        }
    }
}
