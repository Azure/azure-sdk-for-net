// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;
using Azure.Generator.Visitors.Utilities;

namespace Azure.Generator.Visitors
{
    internal class ModelFactoryRenamerVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ModelFactoryProvider && type.CustomCodeView == null)
            {
                // Reset the type provider so that all the methods will be recomputed after the name change.
                // This is necessary because the name change will impact the custom code view calculation.
                type.Update(name: $"{TypeNameUtilities.GetResourceProviderName()}ModelFactory", reset: true);
            }

            return type;
        }
    }
}