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
        private string? _customNamespace;
        private bool _customNamespaceInitialized;

        private string? GetCustomNamespace()
        {
            if (!_customNamespaceInitialized)
            {
                _customNamespace = CodeModelGenerator.Instance.Configuration.GetNamespace();
                _customNamespaceInitialized = true;
            }
            return _customNamespace;
        }

        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                UpdateTypeNamespace(type);
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
                UpdateTypeNamespace(type);
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

            // Update namespace for all types
            UpdateTypeNamespace(type);

            // Apply Models sub-namespace if configured
            if (type is ModelProvider || type is ModelFactoryProvider
                || type is MrwSerializationTypeDefinition || type is FixedEnumSerializationProvider || type is ExtensibleEnumSerializationProvider)
            {
                UpdateModelsNamespace(type);
            }

            return type;
        }

        private void UpdateTypeNamespace(TypeProvider type)
        {
            var customNamespace = GetCustomNamespace();
            // If a custom namespace is configured, update the type's namespace (unless it's customized)
            if (!string.IsNullOrWhiteSpace(customNamespace))
            {
                // Only update if the type doesn't have custom code
                // Note: We don't check the current namespace because types may be created with
                // different namespaces by the base generator that we need to override
                if (type.CustomCodeView == null)
                {
                    type.Update(@namespace: customNamespace);
                }
            }
        }

        private void UpdateModelsNamespace(TypeProvider type)
        {
            if (CodeModelGenerator.Instance.Configuration.UseModelNamespace())
            {
                // If the type is customized, then we don't want to override the namespace.
                if (type.CustomCodeView == null)
                {
                    var customNamespace = GetCustomNamespace();
                    var baseNamespace = !string.IsNullOrWhiteSpace(customNamespace)
                        ? customNamespace
                        : CodeModelGenerator.Instance.TypeFactory.PrimaryNamespace;

                    type.Update(
                        @namespace: CodeModelGenerator.Instance.TypeFactory.GetCleanNameSpace(
                            $"{baseNamespace}.Models"));
                }
            }
        }
    }
}