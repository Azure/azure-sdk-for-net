// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator
{
    internal class NamespaceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? Visit(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                UpdateNamespace(type);
            }
            return type;
        }

        protected override TypeProvider? Visit(InputEnumType enumType, TypeProvider? type)
        {
            if (enumType.Usage.HasFlag(InputModelTypeUsage.ApiVersionEnum))
            {
                return type;
            }

            if (type is not null)
            {
                UpdateNamespace(type);
            }
            return type;
        }

        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (type is EnumProvider && type.Name == "ServiceVersion")
            {
                return type;
            }

            if (type is ModelProvider || type is EnumProvider || type is ModelFactoryProvider
                || type is MrwSerializationTypeDefinition || type is FixedEnumSerializationProvider || type is ExtensibleEnumSerializationProvider)
            {
                UpdateNamespace(type);
            }
            return type;
        }

        private static void UpdateNamespace(TypeProvider type)
        {
            // TODO: need to take consideration of model-namespace configuration
            // if model-namespace is false, keep the default namespace
            // if model-namespace is true, append ".Models" to the namespace
            if (!type.Type.Namespace.EndsWith("Models"))
            {
                type.Type.Namespace = $"{type.Type.Namespace}.Models";
            }
        }
    }
}
