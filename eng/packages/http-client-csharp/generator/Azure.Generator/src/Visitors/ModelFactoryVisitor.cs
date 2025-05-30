// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    internal class ModelFactoryVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider && type.CustomCodeView == null)
            {
                type.Type.Update(name: $"{TypeNameUtilities.GetResourceProviderName(type.Type.Namespace)}ModelFactory");
            }

            return type;
        }
    }
}