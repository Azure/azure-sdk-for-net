// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal sealed class ResourceCollectionClientProvider : ContextualClientProvider
    {
        private readonly ResourceMetadata _resourceMetadata;
        private readonly ResourceClientProvider _resource;
        private readonly InputServiceMethod? _getAll;
        private readonly InputServiceMethod? _create;
        private readonly InputServiceMethod? _get;

        private readonly ClientProvider _restClientProvider;
        private readonly FieldProvider _clientDiagnosticsField;
        private readonly FieldProvider _restClientField;

        // This is the resource type of the current resource. Not the resource type of my parent resource
        private ScopedApi<ResourceType> _resourceTypeExpression;

        internal ResourceCollectionClientProvider(ResourceClientProvider resource, InputModelType model, InputClient inputClient, ResourceMetadata resourceMetadata) : base(GetContextualRequestPattern(resourceMetadata))
        {
            _resourceMetadata = resourceMetadata;
            _resource = resource;

            _restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), ResourceHelpers.GetClientDiagnosticFieldName(ResourceName), this);
            _restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _restClientProvider.Type, ResourceHelpers.GetRestClientFieldName(_restClientProvider.Name), this);

            _resourceTypeExpression = Static(_resource.Type).As<ArmResource>().ResourceType();

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

        /// <summary>
        /// Get the contextual request path pattern for this collection client.
        /// The contextual request path pattern for a collection should always be the request path pattern of the parent resource.
        /// </summary>
        /// <param name="resourceMetadata"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private static RequestPathPattern GetContextualRequestPattern(ResourceMetadata resourceMetadata)
        {
            if (resourceMetadata.ParentResourceId is not null)
            {
                return new RequestPathPattern(resourceMetadata.ParentResourceId);
            }
            return resourceMetadata.ResourceScope switch
            {
                ResourceScope.ManagementGroup => RequestPathPattern.ManagementGroup,
                ResourceScope.ResourceGroup => RequestPathPattern.ResourceGroup,
                ResourceScope.Subscription => RequestPathPattern.Subscription,
                ResourceScope.Tenant => RequestPathPattern.Tenant,
                _ => throw new NotSupportedException($"Unsupported resource scope: {resourceMetadata.ResourceScope}"),
            };
        }

        public ResourceClientProvider Resource => _resource;

        internal string ResourceName => _resource.ResourceName;
        internal ResourceScope ResourceScope => _resource.ResourceScope;

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{ResourceName}Collection";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override CSharpType? GetBaseType() => typeof(ArmCollection);

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? []
            : [new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields() => [_clientDiagnosticsField, _restClientField];

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelpers.BuildMockingConstructor(this), BuildResourceIdentifierConstructor()];

        private ConstructorProvider BuildResourceIdentifierConstructor()
        {
            var idParameter = new ParameterProvider("id", $"The identifier of the resource that is the target of operations.", typeof(ResourceIdentifier));
            var parameters = new List<ParameterProvider>
            {
                new("client", $"The client parameters to use in these operations.", typeof(ArmClient)),
                idParameter
            };

            var initializer = new ConstructorInitializer(true, parameters);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                parameters,
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeExpression.Namespace(), This.As<ArmResource>().Diagnostics())).Terminate(),
                ResourceHelpers.BuildTryGetApiVersionInvocation(ResourceName, _resourceTypeExpression, out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_restClientProvider.Type, _clientDiagnosticsField, This.As<ArmResource>().Pipeline(), This.As<ArmResource>().Endpoint(), apiVersion)).Terminate(),
                Static(Type).Invoke("ValidateResourceId", idParameter).Terminate()
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        // TODO -- this expression currently is incorrect. Maybe we need to leave an API in OutputLibrary for us to query the parent resource, because when construct the collection, we do not know it yet.
        private static CSharpType GetParentResourceType(ResourceMetadata resourceMetadata, ResourceClientProvider resource)
        {
            // TODO -- implement this to be more accurate when we implement the parent of resources.
            switch (resourceMetadata.ResourceScope)
            {
                case ResourceScope.ResourceGroup:
                    return typeof(ResourceGroupResource);
                case ResourceScope.Subscription:
                    return typeof(SubscriptionResource);
                case ResourceScope.Tenant:
                    return typeof(TenantResource);
                default:
                    // TODO -- this is incorrect, but we put it here as a placeholder.
                    return resource.Type;
            }
        }

        protected override MethodProvider[] BuildMethods()
            => [
                BuildValidateResourceIdMethod(Static(GetParentResourceType(_resourceMetadata, _resource)).As<ArmResource>().ResourceType()),
                .. BuildCreateOrUpdateMethods(),
                .. BuildGetMethods(),
                .. BuildGetAllMethods(),
                .. BuildExistsMethods(),
                .. BuildGetIfExistsMethods(),
                .. BuildEnumeratorMethods()
                ];

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
                result.Add(new ResourceOperationMethodProvider(this, _resource, _restClientProvider, _create, convenienceMethod, _clientDiagnosticsField, _restClientField, isAsync));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(bool isAsync)
        {
            var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(_getAll!.Operation, isAsync);
            return new GetAllOperationMethodProvider(this, _restClientProvider, _getAll, convenienceMethod, _clientDiagnosticsField, _restClientField, isAsync);
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
                result.Add(new ResourceOperationMethodProvider(this, _resource, _restClientProvider, _get, convenienceMethod, _clientDiagnosticsField, _restClientField, isAsync));
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
                var existsMethodProvider = new ExistsOperationMethodProvider(this, _restClientProvider, _get, convenienceMethod, _clientDiagnosticsField, _restClientField, isAsync);
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
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, _resource, _restClientProvider, _get, convenienceMethod, _clientDiagnosticsField, _restClientField, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }
    }
}
