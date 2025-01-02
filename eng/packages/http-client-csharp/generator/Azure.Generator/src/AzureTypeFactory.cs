// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        private Dictionary<InputModelType, ResourceDataProvider?> _resourceDataProvdierCache = new();

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
                if (KnownAzureTypes.TryGetPrimitiveType(primitiveType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return null;
        }

        /// <inheritdoc/>
        public override ValueExpression DeserializeJsonValue(Type valueType, ScopedApi<JsonElement> element, SerializationFormat format)
        {
            var expression = DeserializeJsonValueCore(valueType, element, format);
            return expression ?? base.DeserializeJsonValue(valueType, element, format);
        }

        private ValueExpression? DeserializeJsonValueCore(
            Type valueType,
            ScopedApi<JsonElement> element,
            SerializationFormat format)
        {
            return KnownAzureTypes.TryGetJsonDeserializationExpression(valueType, out var deserializationExpression) ?
                deserializationExpression(new CSharpType(valueType), element, format) :
                null;
        }

        /// <inheritdoc/>
        public override MethodBodyStatement SerializeJsonValue(Type valueType, ValueExpression value, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter, SerializationFormat serializationFormat)
        {
            var statement = SerializeValueTypeCore(serializationFormat, value, valueType, utf8JsonWriter, mrwOptionsParameter);
            return statement ?? base.SerializeJsonValue(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
        }

        private MethodBodyStatement? SerializeValueTypeCore(SerializationFormat serializationFormat, ValueExpression value, Type valueType, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter)
        {
            return KnownAzureTypes.TryGetJsonSerializationExpression(valueType, out var serializationExpression) ?
                serializationExpression(value, utf8JsonWriter, mrwOptionsParameter, serializationFormat) :
                null;
        }

        /// <inheritdoc/>
        protected override ClientProvider CreateClientCore(InputClient inputClient)
            => AzureClientPlugin.Instance.IsAzureArm.Value ? base.CreateClientCore(TransformInputClient(inputClient)) : base.CreateClientCore(inputClient);

        private InputClient TransformInputClient(InputClient client)
        {
            var operationsToKeep = new List<InputOperation>();
            foreach (var operation in client.Operations)
            {
                // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
                if (operation.CrossLanguageDefinitionId != "Azure.ResourceManager.Operations.list")
                {
                    // TODO: have a helper method in InputOperation to update the parameters
                    var transformedOperation = new InputOperation(operation.Name, operation.ResourceName, operation.Summary, operation.Doc, operation.Deprecated, operation.Accessibility, TransformInputOperationParameters(operation), operation.Responses, operation.HttpMethod, operation.RequestBodyMediaType, operation.Uri, operation.Path, operation.ExternalDocsUrl, operation.RequestMediaTypes, operation.BufferResponse, operation.LongRunning, operation.Paging, operation.GenerateProtocolMethod, operation.GenerateConvenienceMethod, operation.CrossLanguageDefinitionId);
                    operationsToKeep.Add(transformedOperation);
                }
            }
            return new InputClient(client.Name, client.Summary, client.Doc, operationsToKeep, client.Parameters, client.Parent);
        }

        private IReadOnlyList<InputParameter> TransformInputOperationParameters(InputOperation operation)
        {
            var parameters = new List<InputParameter>();
            foreach (var parameter in operation.Parameters)
            {
                if (parameter.NameInRequest.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                {
                    parameters.Add(new InputParameter(parameter.Name, parameter.NameInRequest, parameter.Summary, parameter.Doc, InputPrimitiveType.String, parameter.Location, parameter.DefaultValue, InputOperationParameterKind.Method, parameter.IsRequired, parameter.IsApiVersion, parameter.IsResourceParameter, parameter.IsContentType, parameter.IsEndpoint, parameter.SkipUrlEncoding, parameter.Explode, parameter.ArraySerializationDelimiter, parameter.HeaderCollectionPrefix));
                }
                else
                {
                    parameters.Add(parameter);
                }
            }
            return parameters;
        }

        internal ResourceDataProvider CreateResourceData(InputModelType model)
        {
            if (_resourceDataProvdierCache.TryGetValue(model, out var resourceData))
            {
                return resourceData!;
            }

            return new ResourceDataProvider(model);
        }
    }
}
