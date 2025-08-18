// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Extensions;
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
    internal class PageableOperationMethodProvider
    {
        private readonly TypeProvider _enclosingType;
        private readonly RequestPathPattern _contextualPath;
        private readonly RestClientInfo _restClientInfo;
        private readonly InputPagingServiceMethod _method;
        private readonly MethodProvider _convenienceMethod;
        private readonly bool _isAsync;
        private readonly CSharpType _itemType;
        private readonly CSharpType _actualItemType;
        private ResourceClientProvider? _itemResourceClient;
        private readonly string _methodName;
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;

        public PageableOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputPagingServiceMethod method,
            bool isAsync,
            string? methodName = null)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _restClientInfo = restClientInfo;
            _method = method;
            _convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_method.Operation, isAsync);
            _isAsync = isAsync;
            _itemType = _convenienceMethod.Signature.ReturnType!.Arguments[0]; // a paging method's return type should be `Pageable<T>` or `AsyncPageable<T>`, so we can safely access the first argument as the item type.
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

        public static implicit operator MethodProvider(PageableOperationMethodProvider pageableOperationMethodProvider)
        {
            return new MethodProvider(
                pageableOperationMethodProvider._signature,
                pageableOperationMethodProvider._bodyStatements,
                pageableOperationMethodProvider._enclosingType);
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
                OperationMethodParameterHelper.GetOperationMethodParameters(_method, _contextualPath),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected MethodBodyStatement[] BuildBodyStatements()
        {
            var statements = new List<MethodBodyStatement>();

            var collectionResult = ((ScmMethodProvider)_convenienceMethod).CollectionDefinition!;
            var diagnosticScope = ResourceHelpers.GetDiagnosticScope(_enclosingType, _methodName, _isAsync);
            ManagementClientGenerator.Instance.OutputLibrary.PageableMethodScopes.Add(collectionResult, diagnosticScope);

            var collectionResultOfT = collectionResult.Type;
            statements.Add(ResourceMethodSnippets.CreateRequestContext(KnownParameters.CancellationTokenParameter, out var contextVariable));

            var requestMethod = _restClientInfo.RestClientProvider.GetRequestMethodByOperation(_method.Operation);

            var arguments = new List<ValueExpression>
            {
                _restClientInfo.RestClient,
            };
            arguments.AddRange(_contextualPath.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters));

            // Handle ResourceData type conversion if needed
            if (_itemResourceClient != null)
            {
                statements.Add(BuildResourceDataConversionStatement(collectionResultOfT, _itemResourceClient.Type, arguments));
            }
            else
            {
                statements.Add(Return(New.Instance(collectionResultOfT, arguments)));
            }

            return statements.ToArray();
        }

        private MethodBodyStatement BuildResourceDataConversionStatement(CSharpType sourcePageable, CSharpType typeOfResource, List<ValueExpression> arguments)
        {
            // Create PageableWrapper instance to convert from ResourceData to Resource
            var pageableWrapperType = _isAsync ? ManagementClientGenerator.Instance.OutputLibrary.AsyncPageableWrapper : ManagementClientGenerator.Instance.OutputLibrary.PageableWrapper;

            // Create the concrete wrapper type with proper generic parameters
            // Since pageableWrapperType.Type represents the constructed generic type, we need to use it directly
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
            // This should create a proper Func<fromType, toType> delegate
            var parameterDeclaration = new CodeWriterDeclaration("data");
            var resourceConstructor = New.Instance(toType, This.Property("Client"), new VariableExpression(fromType, parameterDeclaration));

            return new FuncExpression([parameterDeclaration], resourceConstructor);
        }
    }
}
