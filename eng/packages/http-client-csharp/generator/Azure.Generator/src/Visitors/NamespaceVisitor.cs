// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Extensions;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that updates the namespace and file paths for model and enum types.
    /// </summary>
    internal class NamespaceVisitor : ScmLibraryVisitor
    {
        private const string ModelsNamespacePiece = "Models";
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
            if (type is EnumProvider)
            {
                return type;
            }

            if (type is SerializationFormatDefinition)
            {
                return type;
            }

            if (type is ModelProvider || type is ModelFactoryProvider
                || type is MrwSerializationTypeDefinition || type is FixedEnumSerializationProvider || type is ExtensibleEnumSerializationProvider)
            {
                UpdateModelsNamespace(type);
            }

            return type;
        }

        private static void UpdateModelsNamespace(TypeProvider type)
        {
            if (CodeModelGenerator.Instance.Configuration.UseModelNamespace())
            {
                // If the type is customized, then we don't want to override the namespace.
                if (type.CustomCodeView == null)
                {
                    var ns = type.Type.Namespace;
                    if (ns.Split('.')[^1] != ModelsNamespacePiece)
                    {
                        ns = $"{ns}.{ModelsNamespacePiece}";
                    }
                    type.Update(
                        @namespace: CodeModelGenerator.Instance.TypeFactory.GetCleanNameSpace(ns));
                }
            }
        }
    }
}