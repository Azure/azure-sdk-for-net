// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.InputTransformation;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Providers.Abstraction;
using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementTypeFactory : AzureTypeFactory
    {
        private string? _resourceProviderName;

        /// <summary>
        /// The name for this resource provider.
        /// For instance, if the namespace is "Azure.ResourceManager.Compute", the resource provider name will be "Compute".
        /// </summary>
        public string ResourceProviderName => _resourceProviderName ??= BuildResourceProviderName();

        private string BuildResourceProviderName()
        {
            const string armNamespacePrefix = "Azure.ResourceManager.";
            if (PrimaryNamespace.StartsWith(armNamespacePrefix))
            {
                return PrimaryNamespace[armNamespacePrefix.Length..].ToIdentifierName();
            }
            return PrimaryNamespace.ToIdentifierName();
        }

        /// <inheritdoc/>
        public override IClientPipelineApi ClientPipelineApi => ManagementHttpPipelineProvider.Instance;

        /// <inheritdoc/>
        protected override IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> AzureDependencyPackages =>
            [
                new("Azure.Core"),
                new("Azure.ResourceManager"),
                new("System.ClientModel"),
                new("System.Text.Json")
            ];

        /// <inheritdoc/>
        protected override ClientProvider? CreateClientCore(InputClient inputClient)
        {
            var transformedClient = InputClientTransformer.TransformInputClient(inputClient);
            return transformedClient is null ? null : base.CreateClientCore(transformedClient);
        }

        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            if (inputType is InputModelType model && KnownManagementTypes.TryGetSystemType(model.CrossLanguageDefinitionId, out var replacedType))
            {
                return replacedType;
            }

            if (inputType is InputPrimitiveType primitiveType && KnownManagementTypes.TryGetPrimitiveType(primitiveType.CrossLanguageDefinitionId, out replacedType))
            {
                return replacedType;
            }
            return base.CreateCSharpTypeCore(inputType);
        }

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            if (KnownManagementTypes.TryGetInheritableSystemType(model.CrossLanguageDefinitionId, out var replacedType))
            {
                return new InheritableSystemObjectModelProvider(replacedType.FrameworkType, model);
            }
            if (KnownManagementTypes.TryGetSystemType(model.CrossLanguageDefinitionId, out _))
            {
                return null;
            }
            return base.CreateModelCore(model);
        }

        /// <inheritdoc/>
        public override MethodBodyStatement SerializeJsonValue(Type valueType, ValueExpression value, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter, SerializationFormat serializationFormat)
        {
            if (KnownManagementTypes.IsKnownManagementType(valueType))
            {
                return value.CastTo(new CSharpType(typeof(IJsonModel<>), valueType)).Invoke(nameof(IJsonModel<object>.Write), [utf8JsonWriter, mrwOptionsParameter]).Terminate();
            }

            if (KnownManagementTypes.TryGetJsonSerializationExpression(valueType, out var serializationExpression))
            {
                return serializationExpression(value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
            }

            return base.SerializeJsonValue(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
        }

        /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override ValueExpression DeserializeJsonValue(
            Type valueType,
            ScopedApi<JsonElement> element,
            ScopedApi<BinaryData> data,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            if (KnownManagementTypes.IsKnownManagementType(valueType))
            {
                IReadOnlyList<ValueExpression> readBody =
                [
                    New.Instance(
                    typeof(BinaryData),
                    [
                        new MemberExpression(typeof(Encoding), nameof(Encoding.UTF8)).Invoke(nameof(UTF8Encoding.GetBytes),
                            [
                                element.GetRawText()
                            ])
                    ]),
                    ModelSerializationExtensionsSnippets.Wire
                ];

                return Static(typeof(ModelReaderWriter)).Invoke(
                    nameof(ModelReaderWriter.Read),
                    [.. readBody, ModelReaderWriterContextSnippets.Default],
                    typeArgs: [valueType]);
            }

            if (KnownManagementTypes.TryGetJsonDeserializationExpression(valueType, out var deserializationExpression))
            {
                return deserializationExpression(valueType, element, format);
            }

            return base.DeserializeJsonValue(valueType, element, data, mrwOptionsParameter, format);
        }

        /// <inheritdoc/>
        public override NewProjectScaffolding CreateNewProjectScaffolding()
        {
            return new NewManagementProjectScaffolding();
        }
    }
}
