// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
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
            // if (serviceMethod is InputLongRunningServiceMethod lroServiceMethod)
            // {
            //     foreach (var method in methodProviderCollection!.ToArray())
            //     {
            //         // wrap each return type in an Operation
            //         var returnType = method.Signature.ReturnType;
            //         method.Signature.Update(returnType: new CSharpType(typeof(Operation<>), returnType!));
            //     }
            // }

            return methodProviderCollection;
        }
    }
}