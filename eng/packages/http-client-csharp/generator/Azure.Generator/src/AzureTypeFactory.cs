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
        protected internal virtual IReadOnlyList<CSharpProjectWriter.CSProjDependencyPackage> AzureDependencyPackages
        {
            get
            {
                var packages = new List<CSharpProjectWriter.CSProjDependencyPackage>
                {
                    new("Azure.Core")
                };
                if (AzureClientGenerator.Instance.HasDataFactoryElement)
                {
                    packages.Add(new("Azure.Core.Expressions.DataFactory"));
                }

                // Add external packages from @alternateType decorator
                var addedPackages = new HashSet<string>();
                foreach (var externalType in AzureClientGenerator.Instance.ExternalTypes)
                {
                    if (!string.IsNullOrEmpty(externalType.Package) && addedPackages.Add(externalType.Package))
                    {
                        // Don't specify version for external packages to use centralized package management
                        packages.Add(new(externalType.Package));
                    }
                }

                return packages;
            }
        }

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

                // Handle external types (e.g., @alternateType decorator)
                if (inputModelType.External != null)
                {
                    return CreateExternalType(inputModelType.External);
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
            if (inputUnionType.External?.Identity != AzureClientGenerator.DataFactoryElementIdentity)
            {
                return null;
            }

            // The first variant is used as the type argument T in DataFactoryElement<T>
            if (inputUnionType.VariantTypes.Count != 2)
            {
                AzureClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "DFE001",
                    $"DataFactoryElement union '{inputUnionType.Name}' must have 2 variant types. Skipping DataFactoryElement<T> specialized handling.");
                return null;
            }

            // Create the inner type T from the other variant
            var innerType = CreateCSharpType(inputUnionType.VariantTypes[0]);
            if (innerType == null)
            {
                return null;
            }

            // Return DataFactoryElement<T>
            return new CSharpType(typeof(DataFactoryElement<>), innerType);
        }

        private static CSharpType CreateExternalType(InputExternalTypeMetadata external)
        {
            // Parse the fully qualified type name into namespace and type name
            // Note: This assumes simple types (namespace.TypeName) and does not handle:
            // - Nested types (OuterClass+InnerClass)
            // - Generic types (Type<T>)
            // - Types with special characters
            // For alternate types, these are typically simple class references like NetTopologySuite.IO.GeoJSON.Feature
            var lastDotIndex = external.Identity.LastIndexOf('.');
            var ns = lastDotIndex > 0 ? external.Identity.Substring(0, lastDotIndex) : string.Empty;
            var typeName = lastDotIndex > 0 ? external.Identity.Substring(lastDotIndex + 1) : external.Identity;

            // Use reflection to call the internal CSharpType constructor
            // This is necessary because external types are not available at generation time
            // and CSharpType doesn't provide a public factory method for creating unbound type references.
            // 
            // IMPORTANT: This approach is tightly coupled to the internal implementation of CSharpType.
            // If the constructor signature changes in Microsoft.TypeSpec.Generator, this code will break.
            // Consider requesting a public factory method in the base generator for creating external type references.
            //
            // internal CSharpType(string name, string ns, bool isValueType, bool isNullable,
            //     CSharpType? declaringType, IReadOnlyList<CSharpType> args, bool isPublic, bool isStruct,
            //     CSharpType? baseType = null, Type? underlyingEnumType = null)
            var constructor = typeof(CSharpType).GetConstructor(
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null,
                new[] {
                    typeof(string), typeof(string), typeof(bool), typeof(bool),
                    typeof(CSharpType), typeof(IReadOnlyList<CSharpType>), typeof(bool), typeof(bool),
                    typeof(CSharpType), typeof(Type)
                },
                null);

            if (constructor == null)
            {
                throw new InvalidOperationException($"Could not find internal CSharpType constructor for external type: {external.Identity}");
            }

            // Create the CSharpType with the parsed namespace and type name
            // External types are assumed to be public, reference types (not value types or structs)
            var csharpType = (CSharpType)constructor.Invoke(new object?[] {
                typeName,              // name
                ns,                    // namespace
                false,                 // isValueType
                false,                 // isNullable
                null,                  // declaringType
                Array.Empty<CSharpType>(), // args
                true,                  // isPublic
                false,                 // isStruct
                null,                  // baseType
                null                   // underlyingEnumType
            });

            return csharpType;
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
            CSharpType valueType,
            ScopedApi<JsonElement> element,
            ScopedApi<BinaryData> data,
            ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter,
            SerializationFormat format)
        {
            var expression = DeserializeJsonValueCore(valueType, element, data, mrwOptionsParameter, format);
            return expression ?? base.DeserializeJsonValue(valueType, element, data, mrwOptionsParameter, format);
        }

        private ValueExpression? DeserializeJsonValueCore(
            CSharpType valueType,
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
        public override MethodBodyStatement SerializeJsonValue(CSharpType valueType, ValueExpression value, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter, SerializationFormat serializationFormat)
        {
            var statement = SerializeValueTypeCore(serializationFormat, value, valueType, utf8JsonWriter, mrwOptionsParameter);
            return statement ?? base.SerializeJsonValue(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat);
        }

        private MethodBodyStatement? SerializeValueTypeCore(SerializationFormat serializationFormat, ValueExpression value, CSharpType valueType, ScopedApi<Utf8JsonWriter> utf8JsonWriter, ScopedApi<ModelReaderWriterOptions> mrwOptionsParameter)
        {
            return KnownAzureTypes.TryGetJsonSerializationExpression(valueType, out var serializationExpression) ?
                serializationExpression(valueType, value, utf8JsonWriter, mrwOptionsParameter, serializationFormat) :
                null;
        }

        /// <inheritdoc/>
        public override NewProjectScaffolding CreateNewProjectScaffolding()
        {
            return new NewAzureProjectScaffolding();
        }
    }
}
