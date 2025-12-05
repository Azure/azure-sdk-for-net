// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Azure.Generator.Utilities;
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
using System.Linq;
using System.Text.Json;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        private const string DataFactoryElementIdentity = "Azure.Core.Expressions.DataFactoryElement";

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
        protected override string BuildServiceName()
        {
            return TypeNameUtilities.GetResourceProviderName();
        }

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
            else if (inputType is InputUnionType inputUnionType)
            {
                var dataFactoryElementType = TryCreateDataFactoryElementTypeFromUnion(inputUnionType);
                if (dataFactoryElementType != null)
                {
                    return dataFactoryElementType;
                }
            }

            return base.CreateCSharpTypeCore(inputType);
        }

        private CSharpType? TryCreateDataFactoryElementTypeFromUnion(InputUnionType inputUnionType)
        {
            // Find the DataFactoryElement external type in the union variants
            InputExternalType? dataFactoryExternalType = null;
            InputType? otherVariantType = null;
            int otherVariantCount = 0;

            foreach (var variant in inputUnionType.VariantTypes)
            {
                if (variant is InputExternalType externalType && externalType.Identity == DataFactoryElementIdentity)
                {
                    dataFactoryExternalType = externalType;
                }
                else
                {
                    otherVariantType = variant;
                    otherVariantCount++;
                }
            }

            // If no DataFactoryElement external type found, return null
            if (dataFactoryExternalType == null)
            {
                return null;
            }

            // If there is more than one other variant, log a warning and don't apply specialized logic
            if (otherVariantCount != 1 || otherVariantType == null)
            {
                AzureClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "DFE001",
                    $"DataFactoryElement union '{inputUnionType.Name}' has {otherVariantCount} variant types instead of exactly 1. Skipping DataFactoryElement<T> specialized handling.");
                return null;
            }

            // Create the inner type T from the other variant
            var innerType = CreateCSharpType(otherVariantType);
            if (innerType == null)
            {
                return null;
            }

            // Return DataFactoryElement<T>
            return new CSharpType(typeof(DataFactoryElement<>), innerType);
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
            ScopedApi<BinaryData> data,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
        {
            var expression = DeserializeJsonValueCore(valueType, element, data, mrwOptionsParameter, format);
            return expression ?? base.DeserializeJsonValue(valueType, element, data, mrwOptionsParameter, format);
        }

        private ValueExpression? DeserializeJsonValueCore(
            Type valueType,
            ScopedApi<JsonElement> element,
            ScopedApi<BinaryData> data,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
        {
            return KnownAzureTypes.TryGetJsonDeserializationExpression(valueType, out var deserializationExpression) ?
                deserializationExpression(valueType, element, data, mrwOptionsParameter, format) :
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
