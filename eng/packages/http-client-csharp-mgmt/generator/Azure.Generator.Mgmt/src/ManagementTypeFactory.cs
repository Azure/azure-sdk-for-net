// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.InputTransformation;
using Azure.Generator.Management.Providers.Abstraction;
using Azure.Generator.Mgmt.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System;
using System.Collections.Generic;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using Azure.Generator.Management.Providers;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementTypeFactory : AzureTypeFactory
    {
        /// <inheritdoc/>
        public override IClientPipelineApi ClientPipelineApi => MgmtHttpPipelineProvider.Instance;

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

        // TODO: right now, we are missing the connection between CsharpType and TypeProvider, that's why we need both CreateCSharpTypeCore and CreateModelCore
        // Once we have the mapping between CsharpType and TypeProvider, we should only keep CreateModelCore
        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            if (inputType is InputModelType model && KnownManagementTypes.TryGetManagementType(model.CrossLanguageDefinitionId, out var replacedType))
            {
                return replacedType;
            }
            return base.CreateCSharpTypeCore(inputType);
        }

        /// <inheritdoc/>
        protected override ModelProvider? CreateModelCore(InputModelType model)
        {
            if (KnownManagementTypes.TryGetManagementType(model.CrossLanguageDefinitionId, out var replacedType))
            {
                return new InheritableSystemObjectModelProvider(replacedType.FrameworkType, model);
            }
            return base.CreateModelCore(model);
        }

        /// <inheritdoc/>
        public override MethodBodyStatement SerializeJsonValue(Type valueType, ValueExpression value, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter, SerializationFormat serializationFormat)
        {
            if (KnownManagementTypes.IsKnownManagementType(valueType))
            {
                return Static(typeof(JsonSerializer)).Invoke(nameof(JsonSerializer.Serialize), [value]).Terminate();
            }
            return base.SerializeJsonValue(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
        }

        /// <inheritdoc/>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public override ValueExpression DeserializeJsonValue(Type valueType, ScopedApi<JsonElement> element, SerializationFormat format)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            if (KnownManagementTypes.IsKnownManagementType(valueType))
            {
                return Static(typeof(JsonSerializer)).Invoke(nameof(JsonSerializer.Deserialize), [element], [valueType], false);
            }
            return base.DeserializeJsonValue(valueType, element, format);
        }
    }
}
