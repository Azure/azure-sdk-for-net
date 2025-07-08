// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceCollectionClientProvider : ResourceClientProvider
    {
        private ResourceClientProvider _resource;
        private InputServiceMethod? _getAll;
        private InputServiceMethod? _create;
        private InputServiceMethod? _get;

        internal ResourceCollectionClientProvider(InputModelType model, ResourceMetadata resourceMetadata, ResourceClientProvider resource) : base(model, resourceMetadata)
        {
            _resource = resource;

            foreach (var method in resourceMetadata.Methods)
            {
                if (_getAll is not null && _create is not null && _get is not null)
                {
                    break; // we already have all methods we need
                }

                if (method.Kind == ResourceOperationKind.Get)
                {
                    _get = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(method.Id);
                }
                if (method.Kind == ResourceOperationKind.List)
                {
                    _getAll = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(method.Id);
                }
                if (method.Kind == ResourceOperationKind.Create)
                {
                    _create = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(method.Id);
                }
            }
        }

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{SpecName}Collection";

        protected override CSharpType? GetBaseType() => typeof(ArmCollection);

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? []
            : [new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields() => [_clientDiagnosticsField, _clientField];

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelpers.BuildMockingConstructor(this), BuildResourceIdentifierConstructor()];

        // TODO -- we need to change this type to its parent resource type.
        private ScopedApi<ResourceType>? _resourceTypeExpression;
        protected override ScopedApi<ResourceType> ResourceTypeExpression => _resourceTypeExpression ??= BuildCollectionResourceTypeExpression();

        private ScopedApi<ResourceType> BuildCollectionResourceTypeExpression()
        {
            // we need to know the parent of the current resource, and use the `ResourceType` property of the parent resource.
            return Static(GetParentResourceType()).Property("ResourceType").As<ResourceType>();
        }

        private CSharpType GetParentResourceType()
        {
            // TODO -- implement this to be more accurate when we implement the parent of resources.
            switch (ResourceScope)
            {
                case ResourceScope.ResourceGroup:
                    return typeof(ResourceGroupResource);
                case ResourceScope.Subscription:
                    return typeof(SubscriptionResource);
                case ResourceScope.Tenant:
                    return typeof(TenantResource);
                default:
                    throw new NotSupportedException($"Unsupported resource scope: {ResourceScope}");
            }
        }

        protected internal override CSharpType ResourceClientCSharpType => _resource.Type;

        protected override MethodProvider[] BuildMethods() => [BuildValidateResourceIdMethod(), .. BuildCreateOrUpdateMethods(), .. BuildGetMethods(), .. BuildGetAllMethods(), .. BuildExistsMethods(), .. BuildGetIfExistsMethods(), .. BuildEnumeratorMethods()];

        private MethodProvider[] BuildGetAllMethods()
        {
            if (_getAll is null)
            {
                return [];
            }

            // implement paging method GetAll
            var getAll = BuildGetAllMethod(false);
            var getAllAsync = BuildGetAllMethod(true);

            return [getAllAsync, getAll];
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
            return [getEnumeratorOfTMethod, getEnumeratorMethod, getEnumeratorAsyncMethod];
        }

        private List<MethodProvider> BuildCreateOrUpdateMethods()
        {
            var result = new List<MethodProvider>();
            if (_create is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_create!.Operation, isAsync);
                result.Add(new ResourceOperationMethodProvider(this, _create, convenienceMethod, isAsync));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(bool isAsync)
        {
            var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_getAll!.Operation, isAsync);
            return new GetAllOperationMethodProvider(this, _getAll, convenienceMethod, isAsync);
        }

        private List<MethodProvider> BuildGetMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                result.Add(new ResourceOperationMethodProvider(this, _get, convenienceMethod, isAsync));
            }

            return result;
        }

        private List<MethodProvider> BuildExistsMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                var existsMethodProvider = new ExistsOperationMethodProvider(this, _get, convenienceMethod, isAsync);
                result.Add(existsMethodProvider);
            }

            return result;
        }

        private List<MethodProvider> BuildGetIfExistsMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, _get, convenienceMethod, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }

        /// <summary>
        /// Gets the collection of parameter names that should be excluded from method parameters.
        /// For collection clients, this excludes all contextual parameters except the last one (typically the resource name).
        /// </summary>
        internal override IReadOnlyList<string> ImplicitParameterNames
        {
            get
            {
                if (ContextualParameters is null)
                    return [];

                // resourceGroupName and subscriptionId are always included in the parameters for collection clients.
                if (ContextualParameters.Count > 2)
                {
                    return ContextualParameters.Take(ContextualParameters.Count - 1).ToList();
                }

                return ContextualParameters;
            }
    }
    }
}
