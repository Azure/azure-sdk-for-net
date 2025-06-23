// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
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

            return type;
        }

        private static void UpdateModelsNamespace(TypeProvider type)
        {
            if (AzureClientGenerator.Instance.Configuration.UseModelNamespace())
            {
                if (type.CustomCodeView == null)
                {
                    // If the type is customized, then we don't want to override the namespace.
                    type.Update(
                        @namespace: AzureClientGenerator.Instance.TypeFactory.GetCleanNameSpace(
                            $"{AzureClientGenerator.Instance.TypeFactory.PrimaryNamespace}.Models"));
                }
            }
            else
            {
                // TODO - remove this once all libraries have been migrated to the new generator. Leaving this
                // here to make diffs easier to review while migrating. Calculate the fileName as it won't always match the Name
                // property, e.g. for serialization providers.
                // https://github.com/Azure/azure-sdk-for-net/issues/50286
                if (type.RelativeFilePath.Contains("Models"))
                {
                    var fileName = Path.GetRelativePath(Path.Combine("src", "Generated", "Models"),
                        type.RelativeFilePath);
                    type.Update(relativeFilePath: Path.Combine("src", "Generated", fileName));
                }
            }
        }
    }
}