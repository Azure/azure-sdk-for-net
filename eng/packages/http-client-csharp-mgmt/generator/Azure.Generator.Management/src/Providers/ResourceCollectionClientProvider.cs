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
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal sealed class ResourceCollectionClientProvider : TypeProvider
    {
        private readonly ResourceMetadata _resourceMetadata;

        private readonly ResourceClientProvider _resource;
        private readonly InputServiceMethod? _getAll;
        private readonly InputServiceMethod? _create;
        private readonly InputServiceMethod? _get;

        // Support for multiple rest clients
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        // This is the resource type of the current resource. Not the resource type of my parent resource
        private ScopedApi<ResourceType> _resourceTypeExpression;

        internal ResourceCollectionClientProvider(ResourceClientProvider resource, InputModelType model, ResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            ContextualPath = GetContextualRequestPattern(resourceMetadata);
            _resource = resource;

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _resourceTypeExpression = Static(_resource.Type).As<ArmResource>().ResourceType();

            InitializeMethods(resourceMetadata, ref _get, ref _create, ref _getAll);
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

        private static void InitializeMethods(
            ResourceMetadata resourceMetadata,
            ref InputServiceMethod? getMethod,
            ref InputServiceMethod? createMethod,
            ref InputServiceMethod? getAllMethod)
        {
            foreach (var method in resourceMetadata.Methods)
            {
                if (getAllMethod is not null && createMethod is not null && getMethod is not null)
                {
                    break; // we already have all methods we need
                }

                switch (method.Kind)
                {
                    case ResourceOperationKind.Get:
                        AssignMethodKind(ref getMethod, resourceMetadata.ResourceIdPattern, method);
                        break;
                    case ResourceOperationKind.List:
                        AssignMethodKind(ref getAllMethod, resourceMetadata.ResourceIdPattern, method);
                        break;
                    case ResourceOperationKind.Create:
                        AssignMethodKind(ref createMethod, resourceMetadata.ResourceIdPattern, method);
                        break;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static void AssignMethodKind(ref InputServiceMethod? method, string resourceIdPattern, ResourceMethod resourceMethod)
            {
                if (method is not null)
                {
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "general-warning", // TODO -- in the near future, we should have a resource-specific diagnostic ID
                        $"Resource {resourceIdPattern} has multiple '{resourceMethod.Kind}' methods."
                        );
                }
                else
                {
                    method = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(resourceMethod.Id);
                }
            }
        }

        public ResourceClientProvider Resource => _resource;

        public RequestPathPattern ContextualPath { get; }

        internal string ResourceName => _resource.ResourceName;
        internal ResourceScope ResourceScope => _resource.ResourceScope;

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{ResourceName}Collection";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override CSharpType? BuildBaseType() => typeof(ArmCollection);

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? []
            : [new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var clientInfo in _clientInfos.Values)
            {
                fields.Add(clientInfo.DiagnosticsField);
                fields.Add(clientInfo.RestClientField);
            }
            return [.. fields];
        }

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

            var thisCollection = This.As<ArmCollection>();

            var bodyStatements = new List<MethodBodyStatement>();

            bodyStatements.Add(thisCollection.TryGetApiVersion(_resourceTypeExpression, $"{ResourceName}ApiVersion".ToVariableName(), out var apiVersion).Terminate());

            // Initialize all client diagnostics and rest client fields
            foreach (var (inputClient, clientInfo) in _clientInfos)
            {
                bodyStatements.Add(clientInfo.DiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeExpression.Namespace(), thisCollection.Diagnostics())).Terminate());
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type, clientInfo.DiagnosticsField, thisCollection.Pipeline(), thisCollection.Endpoint(), apiVersion)).Terminate());
            }

            bodyStatements.Add(Static(Type).As<ArmCollection>().ValidateResourceId(idParameter).Terminate());

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
                ResourceMethodSnippets.BuildValidateResourceIdMethod(this, Static(GetParentResourceType(_resourceMetadata, _resource)).As<ArmResource>().ResourceType()),
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
            var getAll = BuildGetAllMethod(_getAll, false);
            var getAllAsync = BuildGetAllMethod(_getAll, true);

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

            var restClientInfo = _resourceMetadata.GetRestClientForServiceMethod(_create, _clientInfos);
            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_create!.Operation, isAsync);
                var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync);
                result.Add(new ResourceOperationMethodProvider(this, ContextualPath, restClientInfo, _create, isAsync, methodName, forceLro: true));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(InputServiceMethod getAll, bool isAsync)
        {
            var restClientInfo = _resourceMetadata.GetRestClientForServiceMethod(getAll, _clientInfos);
            return getAll switch
            {
                InputPagingServiceMethod pagingGetAll => new PageableOperationMethodProvider(this, ContextualPath, restClientInfo, pagingGetAll, isAsync, ResourceOperationKind.List),
                _ => new ResourceOperationMethodProvider(this, ContextualPath, restClientInfo, getAll, isAsync, ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync))
            };
        }

        private List<MethodProvider> BuildGetMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            var restClientInfo = _resourceMetadata.GetRestClientForServiceMethod(_get, _clientInfos);
            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                result.Add(new ResourceOperationMethodProvider(this, ContextualPath, restClientInfo, _get, isAsync));
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

            var restClientInfo = _resourceMetadata.GetRestClientForServiceMethod(_get, _clientInfos);
            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                var existsMethodProvider = new ExistsOperationMethodProvider(this, restClientInfo, _get, isAsync);
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

            var restClientInfo = _resourceMetadata.GetRestClientForServiceMethod(_get, _clientInfos);
            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_get!.Operation, isAsync);
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, restClientInfo, _get, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }
    }
}
