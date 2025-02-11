// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    internal class AzureVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (type is ModelProvider || type is EnumProvider || type is ModelFactoryProvider
                || type is MrwSerializationTypeDefinition || type is FixedEnumSerializationProvider || type is ExtensibleEnumSerializationProvider)
            {
                if (!type.Type.Namespace.EndsWith("Models"))
                {
                    type.Type.Namespace = $"{type.Type.Namespace}.Models";
                }
            }
            return type;
        }
    }
}
