// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
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
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Provider for building single-page list operation methods that wrap IList responses into Pageable.
    /// This is used when an operation returns a list/array type but is not a paging operation.
    /// </summary>
    internal class SinglePageListOperationMethodProvider
    {
        private readonly TypeProvider _enclosingType;
        private readonly RequestPathPattern _contextualPath;
        private readonly ClientProvider _restClient;
        private readonly InputServiceMethod _serviceMethod;
        private readonly MethodProvider _convenienceMethod;
        private readonly bool _isAsync;
        private readonly ValueExpression _clientDiagnosticsField;
        private readonly ValueExpression _restClientField;
        private readonly CSharpType _itemType;
        private readonly CSharpType _actualItemType;
        private readonly CSharpType _listType;
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
            _restClient = restClientInfo.RestClientProvider;
            _serviceMethod = method;
            _convenienceMethod = _restClient.GetConvenienceMethodByOperation(_serviceMethod.Operation, isAsync);
            _isAsync = isAsync;
            _clientDiagnosticsField = restClientInfo.Diagnostics;
            _restClientField = restClientInfo.RestClient;

            // Get the list type from the response
            _listType = _serviceMethod.GetResponseBodyType()!;
            
            // Extract the item type from the list
            _itemType = _listType.Arguments[0];
            
            // Check if the item type can be wrapped in a resource client
            InitializeTypeInfo(
                _itemType,
                ref _actualItemType!,
                ref _itemResourceClient
            );
            
            _methodName = methodName ?? _convenienceMethod.Signature.Name;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
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

        public static implicit operator MethodProvider(SinglePageListOperationMethodProvider singlePageListOperationMethodProvider)
        {
            var methodProvider = new ScmMethodProvider(
                singlePageListOperationMethodProvider._signature,
                singlePageListOperationMethodProvider._bodyStatements,
                singlePageListOperationMethodProvider._enclosingType,
                ScmMethodKind.Convenience,
                null,
                null,
                singlePageListOperationMethodProvider._serviceMethod);

            // Add enhanced XML documentation with structured tags
            ResourceHelpers.BuildEnhancedXmlDocs(
                singlePageListOperationMethodProvider._serviceMethod,
                singlePageListOperationMethodProvider._convenienceMethod.Signature.Description,
                singlePageListOperationMethodProvider._enclosingType,
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
                OperationMethodParameterHelper.GetOperationMethodParameters(_serviceMethod, _contextualPath, _enclosingType),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected MethodBodyStatement[] BuildBodyStatements()
        {
            var scopeName = _signature.Name.EndsWith("Async") ? _signature.Name.Substring(0, _signature.Name.Length - "Async".Length) : _signature.Name;
            var scopeStatements = ResourceMethodSnippets.CreateDiagnosticScopeStatements(_enclosingType, _clientDiagnosticsField, scopeName, out var scopeVariable);
            
            return [
                .. scopeStatements,
                new TryCatchFinallyStatement(
                    BuildTryExpression(),
                    ResourceMethodSnippets.CreateDiagnosticCatchBlock(scopeVariable)
                )
            ];
        }

        private TryExpression BuildTryExpression()
        {
            var cancellationTokenParameter = KnownParameters.CancellationTokenParameter;
            var requestMethod = _restClient.GetRequestMethodByOperation(_serviceMethod.Operation);
            var tryStatements = new List<MethodBodyStatement>
            {
                ResourceMethodSnippets.CreateRequestContext(cancellationTokenParameter, out var contextVariable)
            };

            // Populate arguments for the REST client method call
            var arguments = _contextualPath.PopulateArguments(
                This.As<ArmResource>().Id(), 
                requestMethod.Signature.Parameters, 
                contextVariable, 
                _signature.Parameters, 
                _enclosingType);

            tryStatements.Add(ResourceMethodSnippets.CreateHttpMessage(
                _restClientField, 
                requestMethod.Signature.Name, 
                arguments, 
                out var messageVariable));

            // Process the pipeline and get the response
            tryStatements.AddRange(ResourceMethodSnippets.CreateGenericResponsePipelineProcessing(
                messageVariable,
                contextVariable,
                _listType,
                _isAsync,
                out var responseVariable));

            // Add null check for the response value
            var nullCheckStatement = new IfStatement(
                responseVariable.Value().Equal(Null))
            {
                ((KeywordExpression)ThrowExpression(
                    New.Instance(
                        typeof(RequestFailedException),
                        responseVariable.GetRawResponse()))).Terminate()
            };
            tryStatements.Add(nullCheckStatement);

            // Convert the list to a single-page Pageable
            if (_itemResourceClient != null)
            {
                // Need to convert item types from ResourceData to Resource
                tryStatements.Add(BuildResourceDataConversionStatement(responseVariable));
            }
            else
            {
                // Direct conversion without type transformation
                tryStatements.Add(BuildDirectConversionStatement(responseVariable));
            }

            return new TryExpression(tryStatements);
        }

        private MethodBodyStatement BuildDirectConversionStatement(ScopedApi<Response> responseVariable)
        {
            // Create a single page from the list: Page<T>.FromValues(response.Value, null, response.GetRawResponse())
            var pageExpression = Static(new CSharpType(typeof(Page<>), _itemType)).Invoke(
                nameof(Page<object>.FromValues),
                [responseVariable.Value(), Null, responseVariable.GetRawResponse()]);

            // Wrap in a Pageable: Pageable<T>.FromPages(new[] { page })
            var pageableType = _isAsync 
                ? new CSharpType(typeof(AsyncPageable<>), _itemType)
                : new CSharpType(typeof(Pageable<>), _itemType);

            var pageableExpression = Static(pageableType).Invoke(
                "FromPages",
                [New.Array(_itemType.MakeGenericType(typeof(Page<>)), isInline: true, pageExpression)]);

            return Return(pageableExpression);
        }

        private MethodBodyStatement BuildResourceDataConversionStatement(ScopedApi<Response> responseVariable)
        {
            // Create a page with the original data type
            var pageExpression = Static(new CSharpType(typeof(Page<>), _itemType)).Invoke(
                nameof(Page<object>.FromValues),
                [responseVariable.Value(), Null, responseVariable.GetRawResponse()]);

            // Create the pageable from the page
            var sourcePageableType = _isAsync 
                ? new CSharpType(typeof(AsyncPageable<>), _itemType)
                : new CSharpType(typeof(Pageable<>), _itemType);

            var sourcePageableExpression = Static(sourcePageableType).Invoke(
                "FromPages",
                [New.Array(_itemType.MakeGenericType(typeof(Page<>)), isInline: true, pageExpression)]);

            // Wrap with PageableWrapper to convert from ResourceData to Resource
            var pageableWrapperType = _isAsync 
                ? ManagementClientGenerator.Instance.OutputLibrary.AsyncPageableWrapper 
                : ManagementClientGenerator.Instance.OutputLibrary.PageableWrapper;

            var concreteWrapperType = pageableWrapperType.Type.MakeGenericType([_itemType, _actualItemType]);

            // Create converter function: data => new ResourceType(Client, data)
            var converterFunc = CreateConverterFunction(_itemType, _actualItemType);

            var wrapperExpression = New.Instance(concreteWrapperType, [sourcePageableExpression, converterFunc]);

            return Return(wrapperExpression);
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
