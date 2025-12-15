// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Provides method generation for single-page list operations that are not technically pageable
    /// but should be generated as pageable for consistency (e.g., ListSinglePage operations).
    /// This provider wraps the response from a list operation into a single-page Pageable/AsyncPageable.
    /// </summary>
    internal class SinglePageListOperationMethodProvider
    {
        private readonly TypeProvider _enclosingType;
        private readonly RequestPathPattern _contextualPath;
        private readonly RestClientInfo _restClientInfo;
        private readonly InputServiceMethod _method;
        private readonly MethodProvider _convenienceMethod;
        private readonly bool _isAsync;
        private readonly CSharpType _itemType;
        private readonly CSharpType _actualItemType;
        private ResourceClientProvider? _itemResourceClient;
        private readonly string _methodName;
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;

        public SinglePageListOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            bool isAsync,
            string? methodName = null)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _restClientInfo = restClientInfo;
            _method = method;
            _convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_method.Operation, isAsync);
            _isAsync = isAsync;

            // Extract the item type from the response body
            var responseBodyType = _method.GetResponseBodyType();
            if (responseBodyType is null)
            {
                throw new InvalidOperationException($"List operation {_method.Name} must have a response body type");
            }

            _itemType = ExtractItemType(responseBodyType);
            InitializeTypeInfo(
                _itemType,
                ref _actualItemType!,
                ref _itemResourceClient
            );
            _methodName = methodName ?? _convenienceMethod.Signature.Name;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
        }

        private static CSharpType ExtractItemType(CSharpType responseBodyType)
        {
            // The response body type should be a collection type like IReadOnlyList<T>, IEnumerable<T>, T[], etc.
            // We need to extract the item type T

            if (responseBodyType.IsFrameworkType && responseBodyType.FrameworkType.IsGenericType)
            {
                var genericTypeDef = responseBodyType.FrameworkType.GetGenericTypeDefinition();
                if (genericTypeDef == typeof(IReadOnlyList<>) ||
                    genericTypeDef == typeof(IEnumerable<>) ||
                    genericTypeDef == typeof(List<>) ||
                    genericTypeDef == typeof(ICollection<>))
                {
                    return responseBodyType.Arguments[0];
                }
            }

            // Handle array types T[]
            if (responseBodyType.IsFrameworkType && responseBodyType.FrameworkType.IsArray)
            {
                return new CSharpType(responseBodyType.FrameworkType.GetElementType()!);
            }

            // If it's not a recognized collection type, the response body itself might be the item type
            // This could happen if the spec defines a custom collection model
            throw new InvalidOperationException($"Unable to extract item type from collection type: {responseBodyType}. Expected a collection type like IReadOnlyList<T>.");
        }

        private static void InitializeTypeInfo(
            CSharpType itemType,
            ref CSharpType actualItemType,
            ref ResourceClientProvider? resourceClient
            )
        {
            actualItemType = itemType;
            if (ManagementClientGenerator.Instance.OutputLibrary.TryGetResourceClientProvider(itemType, out resourceClient))
            {
                actualItemType = resourceClient.Type;
            }
        }

        public static implicit operator MethodProvider(SinglePageListOperationMethodProvider provider)
        {
            var methodProvider = new MethodProvider(
                provider._signature,
                provider._bodyStatements,
                provider._enclosingType);

            // Add enhanced XML documentation with structured tags
            ResourceHelpers.BuildEnhancedXmlDocs(
                provider._method,
                provider._convenienceMethod.Signature.Description,
                provider._enclosingType,
                methodProvider.XmlDocs);

            return methodProvider;
        }

        protected MethodSignature CreateSignature()
        {
            var returnType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), _actualItemType)
                : new CSharpType(typeof(Pageable<>), _actualItemType);

            // Generate return description for pageable methods
            FormattableString returnDescription = $"A collection of {_actualItemType:C} that may take multiple service requests to iterate over.";

            return new MethodSignature(
                _methodName,
                _convenienceMethod.Signature.Description,
                _convenienceMethod.Signature.Modifiers,
                returnType,
                returnDescription,
                OperationMethodParameterHelper.GetOperationMethodParameters(_method, _contextualPath, _enclosingType),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected MethodBodyStatement[] BuildBodyStatements()
        {
            var statements = new List<MethodBodyStatement>();

            statements.Add(ResourceMethodSnippets.CreateRequestContext(KnownParameters.CancellationTokenParameter, out var contextVariable));

            var requestMethod = _restClientInfo.RestClientProvider.GetRequestMethodByOperation(_method.Operation);

            var arguments = new List<ValueExpression>();
            arguments.AddRange(_contextualPath.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters, _enclosingType));

            // Call the convenience method to get the response
            var convenienceMethodCall = _restClientInfo.RestClient.Invoke(_convenienceMethod.Signature.Name, arguments);

            // Call the convenience method to get the response
            ValueExpression responseExpression;
            if (_isAsync)
            {
                // For async: var response = await ...Async(...)
                responseExpression = new KeywordExpression("await", convenienceMethodCall);
            }
            else
            {
                // For sync: var response = ...(...)
                responseExpression = convenienceMethodCall;
            }

            // Extract the value from the response: response.Value
            var valuesExpression = responseExpression.Property("Value");

            // Create a single page: Page<T>.FromValues(values, null, response)
            var pageType = new CSharpType(typeof(Page<>), _itemType);
            var singlePage = Static(pageType).Invoke("FromValues", [valuesExpression, Null, responseExpression]);

            // Convert to Pageable/AsyncPageable using FromPages
            var pageableType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), _actualItemType)
                : new CSharpType(typeof(Pageable<>), _actualItemType);

            // Handle ResourceData type conversion if needed
            if (_itemResourceClient != null)
            {
                // We need to convert from ResourceData to Resource type
                // Create a converter function and use PageableWrapper
                statements.Add(BuildResourceDataConversionStatement(singlePage, _itemType, _itemResourceClient.Type));
            }
            else
            {
                // No conversion needed, just wrap in FromPages
                // Use collection expression to create array: [singlePage]
                var arrayOfPages = New.Array(pageType, isInline: false, [singlePage]);
                var fromPagesCall = Static(pageableType).Invoke("FromPages", [arrayOfPages]);
                statements.Add(Return(fromPagesCall));
            }

            return statements.ToArray();
        }

        private MethodBodyStatement BuildResourceDataConversionStatement(ValueExpression singlePage, CSharpType sourceItemType, CSharpType targetItemType)
        {
            // For resource data conversion, we need to:
            // 1. Create a Pageable<ResourceData> from the single page
            // 2. Wrap it with PageableWrapper to convert to Resource type

            var sourcePageableType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), sourceItemType)
                : new CSharpType(typeof(Pageable<>), sourceItemType);

            // Create an array expression: [singlePage]
            var pageType = new CSharpType(typeof(Page<>), sourceItemType);
            var arrayOfPages = New.Array(pageType, isInline: false, [singlePage]);
            var sourcePageable = Static(sourcePageableType).Invoke("FromPages", [arrayOfPages]);

            // Create PageableWrapper instance to convert from ResourceData to Resource
            var pageableWrapperType = _isAsync
                ? ManagementClientGenerator.Instance.OutputLibrary.AsyncPageableWrapper
                : ManagementClientGenerator.Instance.OutputLibrary.PageableWrapper;

            var concreteWrapperType = pageableWrapperType.Type.MakeGenericType([sourceItemType, targetItemType]);

            // Create converter function: data => new ResourceType(Client, data)
            var converterFunc = CreateConverterFunction(sourceItemType, targetItemType);

            var wrapperArguments = new List<ValueExpression>
            {
                sourcePageable,
                converterFunc
            };

            return Return(New.Instance(concreteWrapperType, wrapperArguments));
        }

        private ValueExpression CreateConverterFunction(CSharpType fromType, CSharpType toType)
        {
            // Create a lambda expression: data => new ResourceType(Client, data)
            var parameterDeclaration = new CodeWriterDeclaration("data");
            var resourceConstructor = New.Instance(toType, This.Property("Client"), new VariableExpression(fromType, parameterDeclaration));

            return new FuncExpression([parameterDeclaration], resourceConstructor);
        }
    }
}
