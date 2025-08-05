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
        private readonly InputServiceMethod _method;
        private readonly MethodProvider _convenienceMethod;
        private readonly bool _isAsync;
        private readonly CSharpType _itemType;
        private readonly ResourceOperationKind _methodKind;
        private readonly MethodSignature _signature;
        private readonly MethodBodyStatement[] _bodyStatements;

        public PageableOperationMethodProvider(
            TypeProvider enclosingType,
            RequestPathPattern contextualPath,
            RestClientInfo restClientInfo,
            InputServiceMethod method,
            MethodProvider convenienceMethod,
            bool isAsync,
            CSharpType itemType,
            ResourceOperationKind methodKind)
        {
            _enclosingType = enclosingType;
            _contextualPath = contextualPath;
            _restClientInfo = restClientInfo;
            _method = method;
            _convenienceMethod = convenienceMethod;
            _isAsync = isAsync;
            _itemType = itemType;
            _methodKind = methodKind;
            _signature = CreateSignature();
            _bodyStatements = BuildBodyStatements();
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
            var actualItemType = IsResourceDataType(_itemType) ? GetResourceClientProvider().Type : _itemType;

            var returnType = _isAsync
                ? new CSharpType(typeof(AsyncPageable<>), actualItemType)
                : new CSharpType(typeof(Pageable<>), actualItemType);
            var methodName = _methodKind == ResourceOperationKind.List
                ? (_isAsync ? "GetAllAsync" : "GetAll")
                : (_isAsync ? $"{_convenienceMethod.Signature.Name}Async" : _convenienceMethod.Signature.Name);

            return new MethodSignature(
                methodName,
                _convenienceMethod.Signature.Description,
                _convenienceMethod.Signature.Modifiers,
                returnType,
                _convenienceMethod.Signature.ReturnDescription,
                OperationMethodParameterHelper.GetOperationMethodParameters(_method, _contextualPath, false),
                _convenienceMethod.Signature.Attributes,
                _convenienceMethod.Signature.GenericArguments,
                _convenienceMethod.Signature.GenericParameterConstraints,
                _convenienceMethod.Signature.ExplicitInterface,
                _convenienceMethod.Signature.NonDocumentComment);
        }

        protected MethodBodyStatement[] BuildBodyStatements()
        {
            var statements = new List<MethodBodyStatement>();

            var collectionResultOfT = ((ScmMethodProvider)_convenienceMethod).CollectionDefinition!.Type;
            statements.Add(ResourceMethodSnippets.CreateRequestContext(KnownParameters.CancellationTokenParameter, out var contextVariable));

            var requestMethod = _restClientInfo.RestClientProvider.GetRequestMethodByOperation(_method.Operation);

            var arguments = new List<ValueExpression>
            {
                _restClientInfo.RestClientField,
            };
            arguments.AddRange(_contextualPath.PopulateArguments(This.As<ArmResource>().Id(), requestMethod.Signature.Parameters, contextVariable, _signature.Parameters));

            // Handle ResourceData type conversion if needed
            if (IsResourceDataType(_itemType))
            {
                statements.Add(BuildResourceDataConversionStatement(collectionResultOfT, arguments));
            }
            else
            {
                statements.Add(Return(New.Instance(collectionResultOfT, arguments)));
            }

            return statements.ToArray();
        }

        private MethodBodyStatement BuildResourceDataConversionStatement(CSharpType sourcePageable, List<ValueExpression> arguments)
        {
            // Get the resource client provider to access the resource type
            var resourceClientProvider = GetResourceClientProvider();
            var resourceType = resourceClientProvider.Type;

            // Create PageableWrapper instance to convert from ResourceData to Resource
            var pageableWrapperType = _isAsync ? ManagementClientGenerator.Instance.OutputLibrary.AsyncPageableWrapper : ManagementClientGenerator.Instance.OutputLibrary.PageableWrapper;

            // Create the concrete wrapper type with proper generic parameters
            // Since pageableWrapperType.Type represents the constructed generic type, we need to use it directly
            var concreteWrapperType = pageableWrapperType.Type.MakeGenericType([_itemType, resourceType]);

            // Create converter function: data => new ResourceType(Client, data)
            var converterFunc = CreateConverterFunction(_itemType, resourceType);

            var wrapperArguments = new List<ValueExpression>
            {
                New.Instance(sourcePageable, arguments),
                converterFunc
            };

            return Return(New.Instance(concreteWrapperType, wrapperArguments));
        }

        private bool IsResourceDataType(CSharpType itemType)
        {
            try
            {
                var resourceClientProvider = GetResourceClientProvider();
                return itemType.Equals(resourceClientProvider.ResourceData.Type);
            }
            catch (InvalidOperationException)
            {
                // If we can't get a ResourceClientProvider, then this is not a ResourceData type
                return false;
            }
        }

        private ResourceClientProvider GetResourceClientProvider()
        {
            return _enclosingType switch
            {
                ResourceClientProvider rcp => rcp,
                ResourceCollectionClientProvider rccp => rccp.Resource, // Return the Resource property
                _ => throw new InvalidOperationException($"Expected ResourceClientProvider or ResourceCollectionClientProvider, but got: {_enclosingType.GetType()}")
            };
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
