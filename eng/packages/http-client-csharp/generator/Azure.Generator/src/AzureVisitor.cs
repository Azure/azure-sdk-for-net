// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Providers;

namespace Azure.Generator
{
    internal class AzureVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (type is ModelProvider || type is EnumProvider || type is ModelFactoryProvider)
            {
                type.Namespace = $"{type.Namespace}.Models";
                type.Type.Namespace = $"{type.Type.Namespace}.Models";
            }
            return type;
        }
    }
}
