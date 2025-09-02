// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        public override IClientResponseApi ClientResponseApi => AzureClientResponseProvider.Instance;

        /// <inheritdoc/>
        public override IHttpResponseApi HttpResponseApi => AzureResponseProvider.Instance;

        /// <inheritdoc/>
        public override IClientPipelineApi ClientPipelineApi => HttpPipelineProvider.Instance;

        /// <inheritdoc/>
        public override IHttpMessageApi HttpMessageApi => HttpMessageProvider.Instance;

        /// <inheritdoc/>
        public override IExpressionApi<HttpRequestApi> HttpRequestApi => HttpRequestProvider.Instance;

        /// <inheritdoc/>
        public override IStatusCodeClassifierApi StatusCodeClassifierApi => StatusCodeClassifierProvider.Instance;

        /// <inheritdoc/>
        public override IRequestContentApi RequestContentApi => RequestContentProvider.Instance;

        /// <inheritdoc/>
        public override IHttpRequestOptionsApi HttpRequestOptionsApi => HttpRequestOptionsProvider.Instance;

        /// <summary>
        /// Get dependency packages for Azure.
        /// </summary>
        protected internal virtual IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> AzureDependencyPackages =>
            [
                new("Azure.Core")
            ];

        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            if (inputType is InputPrimitiveType inputPrimitiveType)
            {
                var result = CreateKnownPrimitiveType(inputPrimitiveType);
                if (result != null)
                {
                    return result;
                }
            }
            else if (inputType is InputModelType inputModelType)
            {
                if (KnownAzureTypes.TryGetKnownType(inputModelType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }
            }
            else if (inputType is InputArrayType inputArrayType)
            {
                // Handle special collection types
                if (KnownAzureTypes.TryGetKnownType(inputArrayType.CrossLanguageDefinitionId, out var knownType))
                {
                    var elementType = CreateCSharpType(inputArrayType.ValueType);
                    return new CSharpType(knownType, elementType!);
                }
            }

            return base.CreateCSharpTypeCore(inputType);
        }

        /// <inheritdoc/>
        protected override Type? CreateFrameworkType(string fullyQualifiedTypeName)
        {
            return fullyQualifiedTypeName switch
            {
                "Azure.Core.ResourceIdentifier" => typeof(ResourceIdentifier),
                "Azure.Core.AzureLocation" => typeof(AzureLocation),
                "Azure.ResponseError" => typeof(ResponseError),
                "Azure.ETag" => typeof(ETag),
                _ => base.CreateFrameworkType(fullyQualifiedTypeName)
            };
        }

        private CSharpType? CreateKnownPrimitiveType(InputPrimitiveType inputType)
        {
            InputPrimitiveType? primitiveType = inputType;
            while (primitiveType != null)
            {
                if (KnownAzureTypes.TryGetKnownType(primitiveType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return null;
        }

        /// <inheritdoc/>
        public override ValueExpression DeserializeJsonValue(
            Type valueType,
            ScopedApi<JsonElement> element,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
        {
            var expression = DeserializeJsonValueCore(valueType, element, mrwOptionsParameter, format);
            return expression ?? base.DeserializeJsonValue(valueType, element, mrwOptionsParameter, format);
        }

        private ValueExpression? DeserializeJsonValueCore(
            Type valueType,
            ScopedApi<JsonElement> element,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
        {
            return KnownAzureTypes.TryGetJsonDeserializationExpression(valueType, out var deserializationExpression) ?
                deserializationExpression(valueType, element, mrwOptionsParameter, format) :
                null;
        }

        /// <inheritdoc/>
        public override MethodBodyStatement SerializeJsonValue(Type valueType, ValueExpression value, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter, SerializationFormat serializationFormat)
        {
            var statement = SerializeValueTypeCore(serializationFormat, value, valueType, utf8JsonWriter, mrwOptionsParameter);
            return statement ?? base.SerializeJsonValue(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
        }

        private MethodBodyStatement? SerializeValueTypeCore(SerializationFormat serializationFormat, ValueExpression value, CSharpType valueType, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter)
        {
            return KnownAzureTypes.TryGetJsonSerializationExpression(valueType, out var serializationExpression) ?
                serializationExpression(value, utf8JsonWriter, mrwOptionsParameter, serializationFormat) :
                null;
        }

        /// <inheritdoc/>
        public override NewProjectScaffolding CreateNewProjectScaffolding()
        {
            return new NewAzureProjectScaffolding();
        }
    }
}
