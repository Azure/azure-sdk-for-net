// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    internal class LroVisitor : ScmLibraryVisitor
    {
        protected override ScmMethodProviderCollection? Visit(InputServiceMethod serviceMethod,
            TypeProvider enclosingType,
            ScmMethodProviderCollection? methodProviderCollection)
        {
            if (serviceMethod is InputLongRunningServiceMethod lroServiceMethod)
            {
                return new LroMethodProviderCollection(
                    serviceMethod,
                    enclosingType);
            }

            return methodProviderCollection;
        }
    }
}