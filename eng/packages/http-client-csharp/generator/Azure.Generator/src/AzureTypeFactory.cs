// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.ClientModel.Snippets;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

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
            return base.CreateCSharpTypeCore(inputType);
        }

        private CSharpType? CreateKnownPrimitiveType(InputPrimitiveType inputType)
        {
            InputPrimitiveType? primitiveType = inputType;
            while (primitiveType != null)
            {
                var knownType = KnownAzureTypes.GetPrimitiveType(primitiveType.CrossLanguageDefinitionId);
                if (knownType != null)
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return null;
        }

        /// <inheritdoc/>
        public override ValueExpression GetValueTypeDeserializationExpression(Type valueType, ScopedApi<JsonElement> element, SerializationFormat format)
        {
            var expression = GetValueTypeDeserializationExpressionCore(valueType, element, format);
            return expression ?? base.GetValueTypeDeserializationExpression(valueType, element, format);
        }

        private ValueExpression? GetValueTypeDeserializationExpressionCore(
            Type valueType,
            ScopedApi<JsonElement> element,
            SerializationFormat format)
        {
            return valueType switch
            {
                Type t when t == typeof(ResourceIdentifier) =>
                    New.Instance(valueType, element.GetString()),
                Type t when t == typeof(ETag)
                _ => null,
            };
        }

        /// <inheritdoc/>
        public override MethodBodyStatement SerializeValueType(CSharpType type, SerializationFormat serializationFormat, ValueExpression value, Type valueType, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter)
        {
            var statement = SerializeValueTypeCore(type, serializationFormat, value, valueType, utf8JsonWriter, mrwOptionsParameter);
            return statement ?? base.SerializeValueType(type, serializationFormat, value, valueType, utf8JsonWriter, mrwOptionsParameter);
        }

        private MethodBodyStatement? SerializeValueTypeCore(CSharpType type, SerializationFormat serializationFormat, ValueExpression value, Type valueType, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter)
        {
            return valueType switch
            {
                Type t when t == typeof(ResourceIdentifier) =>
                    utf8JsonWriter.WriteStringValue(value.Property(nameof(ResourceIdentifier.Name))),
                _ => null,
            };
        }
    }
}
