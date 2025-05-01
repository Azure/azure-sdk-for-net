// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    internal class NamespaceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                UpdateModelsNamespace(type);
            }
            return type;
        }

        protected override EnumProvider? PreVisitEnum(InputEnumType enumType, EnumProvider? type)
        {
            if (enumType.Usage.HasFlag(InputModelTypeUsage.ApiVersionEnum))
            {
                return type;
            }

            if (type is not null)
            {
                UpdateModelsNamespace(type);
            }
            return type;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is EnumProvider && type.Name == "ServiceVersion")
            {
                return type;
            }

            if (type is ModelProvider || type is EnumProvider || type is ModelFactoryProvider
                || type is MrwSerializationTypeDefinition || type is FixedEnumSerializationProvider || type is ExtensibleEnumSerializationProvider)
            {
                UpdateModelsNamespace(type);
            }
            else
            {
                type.Type.Update(@namespace: AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace);
            }
            return type;
        }

        private static void UpdateModelsNamespace(TypeProvider type)
        {
            if (AzureClientGenerator.Instance.Configuration.UseModelNamespace())
            {
                type.Type.Update(
                    @namespace: AzureClientGenerator.Instance.TypeFactory.GetCleanNameSpace(
                        $"{AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models"));
            }
        }
    }
}