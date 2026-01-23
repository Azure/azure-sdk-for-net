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
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers.OperationMethodProviders
{
    /// <summary>
    /// Provider for building operation methods that return arrays, wrapping them into Pageable.
    /// This is used when an operation returns a list/array type but is not a standard paging operation.
    /// </summary>
    internal class ArrayResponseOperationMethodProvider
    {
        private readonly TypeProvider _enclosingType;
        private readonly OperationContext _operationContext;
        private readonly ClientProvider _restClient;
        private readonly InputServiceMethod _serviceMethod;
        private readonly MethodProvider _convenienceMethod;
        private readonly bool _isAsync;
        private readonly ValueExpression _restClientField;
        private readonly CSharpType _itemType;
        private readonly CSharpType _actualItemType;
        private readonly CSharpType _listType;
        private ResourceClientProvider? _itemResourceClient;
        private readonly string _methodName;
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;
        private readonly ArrayResponseCollectionResultDefinition? _collectionResult;
        private readonly ParameterContextRegistry _parameterMapping;

        public ArrayResponseOperationMethodProvider(
            TypeProvider enclosingType,
            OperationContext operationContext,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            bool isAsync,
            string? methodName = null,
            ResourceClientProvider? explicitResourceClient = null)
        {
            _enclosingType = enclosingType;
            _operationContext = operationContext;
            _restClient = restClientInfo.RestClientProvider;
            _serviceMethod = method;
            _convenienceMethod = _restClient.GetConvenienceMethodByOperation(_serviceMethod.Operation, isAsync);
            _parameterMapping = _operationContext.BuildParameterMapping(new RequestPathPattern(method.Operation.Path));
            _isAsync = isAsync;
            _restClientField = restClientInfo.RestClient;

            // Get the list type from the response
            _listType = _serviceMethod.GetResponseBodyType()!;

            // Extract the item type from the list
            _itemType = _listType.Arguments[0];

            // Check if the item type can be wrapped in a resource client
            InitializeTypeInfo(
                _itemType,
                ref _actualItemType!,
                ref _itemResourceClient,
                explicitResourceClient
            );

            _methodName = methodName ?? _convenienceMethod.Signature.Name;
            _signature = CreateSignature();
            var (bodyStatements, collectionResult) = BuildBodyStatements();
            _bodyStatements = bodyStatements;
            _collectionResult = collectionResult;
        }

        private static void InitializeTypeInfo(
            CSharpType itemType,
            ref CSharpType actualItemType,
            ref ResourceClientProvider? resourceClient,
            ResourceClientProvider? explicitResourceClient = null
            )
        {
            actualItemType = itemType;
            // If explicit resource client is provided, use it to avoid incorrect lookup when multiple resources share same model
            if (explicitResourceClient != null && explicitResourceClient.ResourceData.Type.Equals(itemType))
            {
                resourceClient = explicitResourceClient;
                actualItemType = resourceClient.Type;
            }
            else if (ManagementClientGenerator.Instance.OutputLibrary.TryGetResourceClientProvider(itemType, out resourceClient))
            {
                actualItemType = resourceClient.Type;
            }
        }

        public static implicit operator MethodProvider(ArrayResponseOperationMethodProvider singlePageListOperationMethodProvider)
        {
            var methodProvider = new ScmMethodProvider(
                singlePageListOperationMethodProvider._signature,
                singlePageListOperationMethodProvider._bodyStatements,
                singlePageListOperationMethodProvider._enclosingType,
                ScmMethodKind.Convenience,
                null,
                singlePageListOperationMethodProvider._collectionResult,
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

            // For pageable methods, we need to remove the 'async' modifier since the return type is AsyncPageable/Pageable
            // These types implement IEnumerable and are not awaitable themselves
            var modifiers = _convenienceMethod.Signature.Modifiers & ~MethodSignatureModifiers.Async;

            return new MethodSignature(
                _methodName,
                _convenienceMethod.Signature.Description,
                modifiers,
                returnType,
                returnDescription,
                OperationMethodParameterHelper.GetOperationMethodParameters(_serviceMethod, _convenienceMethod, _parameterMapping, _enclosingType),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected (MethodBodyStatement[] Statements, ArrayResponseCollectionResultDefinition CollectionResult) BuildBodyStatements()
        {
            var statements = new List<MethodBodyStatement>();

            // Create the collection result definition
            var scopeName = ResourceHelpers.GetDiagnosticScope(_enclosingType, _methodName, _isAsync);
            var collectionResult = CreateCollectionResultDefinition(scopeName);

            // Register the collection result with the output library
            ManagementClientGenerator.Instance.OutputLibrary.PageableMethodScopes.Add(collectionResult.Name, scopeName);

            statements.Add(ResourceMethodSnippets.CreateRequestContext(KnownParameters.CancellationTokenParameter, out var contextVariable));

            var requestMethod = _restClient.GetRequestMethodByOperation(_serviceMethod.Operation);

            var arguments = new List<ValueExpression>
            {
                _restClientField,
            };

            arguments.AddRange(_parameterMapping.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters));

            // Handle ResourceData type conversion if needed
            if (_itemResourceClient != null)
            {
                statements.Add(BuildResourceDataConversionStatement(collectionResult.Type, _itemResourceClient.Type, arguments));
            }
            else
            {
                statements.Add(Return(New.Instance(collectionResult.Type, arguments)));
            }

            return (statements.ToArray(), collectionResult);
        }

        private ArrayResponseCollectionResultDefinition CreateCollectionResultDefinition(string scopeName)
        {
            // Get the request method to extract path parameters
            var requestMethod = _restClient.GetRequestMethodByOperation(_serviceMethod.Operation);

            // Extract only the path parameters (not including CancellationToken or other optional parameters)
            // These are the parameters needed by the contextual path for the request
            var constructorParams = requestMethod.Signature.Parameters
                .Where(p => p.Name != "context" && p.Name != "cancellationToken")  // Exclude context-related params
                .ToArray();

            var collectionResult = new ArrayResponseCollectionResultDefinition(
                _restClient,
                _serviceMethod,
                _itemType,
                _listType,
                _isAsync,
                scopeName,
                constructorParams,
                _methodName,  // Pass the actual method name for proper class naming
                _enclosingType.Name);  // Pass the enclosing type name (e.g., "FooResource")

            return collectionResult;
        }

        private MethodBodyStatement BuildResourceDataConversionStatement(CSharpType sourcePageable, CSharpType typeOfResource, List<ValueExpression> arguments)
        {
            // Create PageableWrapper instance to convert from ResourceData to Resource
            var pageableWrapperType = _isAsync ? ManagementClientGenerator.Instance.OutputLibrary.AsyncPageableWrapper : ManagementClientGenerator.Instance.OutputLibrary.PageableWrapper;

            // Create the concrete wrapper type with proper generic parameters
            var concreteWrapperType = pageableWrapperType.Type.MakeGenericType([_itemType, typeOfResource]);

            // Create converter function: data => new ResourceType(Client, data)
            var converterFunc = CreateConverterFunction(_itemType, typeOfResource);

            var wrapperArguments = new List<ValueExpression>
            {
                New.Instance(sourcePageable, arguments),
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
