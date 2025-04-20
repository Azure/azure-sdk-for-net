// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceCollectionClientProvider : ResourceClientProvider
    {
        private ResourceClientProvider _resource;
        private InputServiceMethod? _getAll;
        private InputOperation? _create;
        private InputOperation? _get;

        public ResourceCollectionClientProvider(InputClient inputClient, ResourceClientProvider resource) : base(inputClient)
        {
            _resource = resource;

            foreach (var method in inputClient.Methods)
            {
                var operation = method.Operation;
                if (operation.HttpMethod == HttpMethod.Get.ToString())
                {
                    if (operation.Name == "list")
                    {
                        _getAll = method;
                    }
                    else if (operation.Name == "get")
                    {
                        _get = operation;
                    }
                }
                if (operation.HttpMethod == HttpMethod.Put.ToString() && operation.Name == "createOrUpdate")
                {
                    _create = operation;
                }
            }
        }

        protected override string BuildName() => $"{SpecName}Collection";

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? [typeof(ArmCollection)]
            : [typeof(ArmCollection), new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields() => [_clientDiagonosticsField, _restClientField];

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildInitializationConstructor()];

        protected override ValueExpression ExpectedResourceTypeForValidation => Static(typeof(ResourceGroupResource)).Property("ResourceType");

        protected override ValueExpression ResourceTypeExpression => Static(_resource.Type).Property("ResourceType");

        // TODO: build GetIfExists, GetIfExistsAsync, Exists, ExistsAsync, Get, GetAsync, CreateOrUpdate, CreateOrUpdateAsync methods
        protected override MethodProvider[] BuildMethods() => [BuildValidateResourceIdMethod(), .. BuildGetAllMethods()];

        private MethodProvider[] BuildGetAllMethods()
        {
            // implement paging method GetAll
            var getAll = BuildGetAllMethod(false);
            var getAllAsync = BuildGetAllMethod(true);

            return [getAll, getAllAsync, .. BuildEnumeratorMethods()];
        }

        private MethodProvider[] BuildEnumeratorMethods()
        {
            if (_getAll is null)
            {
                return [];
            }

            const string getEnumeratormethodName = "GetEnumerator";
            var body = Return(This.Invoke("GetAll").Invoke("GetEnumerator"));
            var getEnumeratorMethod = new MethodProvider(
                new MethodSignature(getEnumeratormethodName, null, MethodSignatureModifiers.None, typeof(IEnumerator), null, [], ExplicitInterface: typeof(IEnumerable)),
                body,
                this);
            var getEnumeratorOfTMethod = new MethodProvider(
                new MethodSignature(getEnumeratormethodName, null, MethodSignatureModifiers.None, new CSharpType(typeof(IEnumerator<>), _resource.Type), null, [], ExplicitInterface: new CSharpType(typeof(IEnumerable<>), _resource.Type)),
                body,
                this);
            var getEnumeratorAsyncMethod = new MethodProvider(
                new MethodSignature("GetAsyncEnumerator", null, MethodSignatureModifiers.None, new CSharpType(typeof(IAsyncEnumerator<>), _resource.Type), null, [KnownAzureParameters.CancellationTokenWithoutDefault], ExplicitInterface: new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)),
                Return(This.Invoke("GetAllAsync", [KnownAzureParameters.CancellationTokenWithoutDefault]).Invoke("GetAsyncEnumerator", [KnownAzureParameters.CancellationTokenWithoutDefault])),
                this);
            return [getEnumeratorMethod, getEnumeratorOfTMethod, getEnumeratorAsyncMethod];
        }

        private MethodProvider BuildGetAllMethod(bool isAsync)
        {
            var convenienceMethod = GetCorrespondingConvenienceMethod(_getAll!.Operation, isAsync);
            var isLongRunning = _getAll is InputLongRunningPagingServiceMethod;
            var signature = new MethodSignature(
                isAsync ? "GetAllAsync" : "GetAll",
                convenienceMethod.Signature.Description,
                convenienceMethod.Signature.Modifiers,
                isAsync ? new CSharpType(typeof(AsyncPageable<>), _resource.Type) : new CSharpType(typeof(Pageable<>), _resource.Type),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, isLongRunning),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);

            // TODO: implement paging method properly
            return new MethodProvider(signature, ThrowExpression(New.Instance(typeof(NotImplementedException))), this);
        }
    }
}
