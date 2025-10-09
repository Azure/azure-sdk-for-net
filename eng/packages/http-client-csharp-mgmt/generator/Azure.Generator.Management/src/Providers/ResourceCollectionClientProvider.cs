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
using Humanizer;
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
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using System.Linq;

namespace Azure.Generator.Management.Providers
{
    internal sealed class ResourceCollectionClientProvider : TypeProvider
    {
        private readonly ResourceMetadata _resourceMetadata;
        private readonly Dictionary<ParameterProvider, FieldProvider> _pathParameterMap;
        private readonly ResourceClientProvider _resource;
        private readonly ResourceMethod? _getAll;
        private readonly ResourceMethod? _create;
        private readonly ResourceMethod? _get;

        // Cached Get method providers
        private MethodProvider? _getAsyncMethodProvider;
        private MethodProvider? _getSyncMethodProvider;

        // Support for multiple rest clients
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        // This is the resource type of the current resource. Not the resource type of my parent resource
        private ScopedApi<ResourceType> _resourceTypeExpression;

        private readonly RequestPathPattern _contextualPath;

        internal ResourceCollectionClientProvider(ResourceClientProvider resource, InputModelType model, IReadOnlyList<ResourceMethod> resourceMethods, ResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _contextualPath = GetContextualRequestPattern(resourceMetadata);
            _resource = resource;

            _pathParameterMap = BuildPathParameterMap();

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _resourceTypeExpression = Static(_resource.Type).As<ArmResource>().ResourceType();

            InitializeMethods(resourceMethods, ref _get, ref _create, ref _getAll);
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

            if (resourceMetadata.ResourceScope == ResourceScope.Extension)
            {
                if (string.IsNullOrEmpty(resourceMetadata.ResourceIdPattern))
                {
                    throw new InvalidOperationException("Extension resource's IdPattern can't be empty or null.");
                }
                return RequestPathPattern.GetFromScope(resourceMetadata.ResourceScope, new RequestPathPattern(resourceMetadata.ResourceIdPattern));
            }

            return RequestPathPattern.GetFromScope(resourceMetadata.ResourceScope);
        }

        private static void InitializeMethods(
            IReadOnlyList<ResourceMethod> resourceMethods,
            ref ResourceMethod? getMethod,
            ref ResourceMethod? createMethod,
            ref ResourceMethod? getAllMethod)
        {
            foreach (var method in resourceMethods)
            {
                if (getAllMethod is not null && createMethod is not null && getMethod is not null)
                {
                    break; // we already have all methods we need
                }

                switch (method.Kind)
                {
                    case ResourceOperationKind.Get:
                        getMethod = method;
                        break;
                    case ResourceOperationKind.List:
                        getAllMethod = method;
                        break;
                    case ResourceOperationKind.Create:
                        createMethod = method;
                        break;
                }
            }
        }

        public ResourceClientProvider Resource => _resource;
        public IReadOnlyList<FieldProvider> PathParameterFields => _pathParameterMap.Values.ToList();
        public IReadOnlyList<ParameterProvider> PathParameters => _pathParameterMap.Keys.ToList();
        public RequestPathPattern ContextualPath => _contextualPath;

        // Cached Get method providers for reuse in other places
        public MethodProvider? GetAsyncMethodProvider
        {
            get
            {
                if (_get is not null && _getAsyncMethodProvider is null)
                {
                    _getAsyncMethodProvider = BuildGetMethod(isAsync: true);
                }
                return _getAsyncMethodProvider;
            }
        }
        public MethodProvider? GetSyncMethodProvider
        {
            get
            {
                if (_get is not null && _getSyncMethodProvider is null)
                {
                    _getSyncMethodProvider = BuildGetMethod(isAsync: false);
                }
                return _getSyncMethodProvider;
            }
        }

        internal string ResourceName => _resource.ResourceName;
        internal ResourceScope ResourceScope => _resource.ResourceScope;

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{ResourceName}Collection";

        // TODO: Add support for getting parent resource from a resource collection
        protected override FormattableString BuildDescription() => $"A class representing a collection of {_resource.Type:C} and their operations.\nEach {_resource.Type:C} in the collection will belong to the same instance of a parent resource (TODO: add parent resource information).\nTo get a {Type:C} instance call the Get{ResourceName.Pluralize()} method from an instance of the parent resource.";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override CSharpType? BuildBaseType() => typeof(ArmCollection);

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? []
            : [new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();

            foreach (var clientInfo in _clientInfos.Values)
            {
                if (clientInfo.DiagnosticProperty is not null)
                {
                    properties.Add(clientInfo.DiagnosticProperty);
                }
                if (clientInfo.RestClientProperty is not null)
                {
                    properties.Add(clientInfo.RestClientProperty);
                }
            }

            return [.. properties];
        }

        private Dictionary<ParameterProvider, FieldProvider> BuildPathParameterMap()
        {
            var map = new Dictionary<ParameterProvider, FieldProvider>();
            var diff = ContextualPath.TrimAncestorFrom(Resource.ContextualPath);
            var variableSegments = diff.Where(seg => !seg.IsConstant).ToList();
            if (variableSegments.Count > 0)
            {
                variableSegments.RemoveAt(variableSegments.Count - 1);
            }
            foreach (var seg in variableSegments)
            {
                var parameter = new ParameterProvider(
                    seg.VariableName,
                    $"The {seg.VariableName} for the resource.",
                    Resource.GetPathParameterType(seg.VariableName));
                var field = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, Resource.GetPathParameterType(seg.VariableName), $"_{seg.VariableName}", this, description: $"The {seg.VariableName}.");
                map.Add(parameter, field);
            }
            return map;
        }

        // BuildPathParameters is now handled by BuildPathParametersAndFields

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var clientInfo in _clientInfos.Values)
            {
                fields.Add(clientInfo.DiagnosticsField);
                fields.Add(clientInfo.RestClientField);
            }
            return [ .. fields, .. _pathParameterMap.Values];
        }

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelpers.BuildMockingConstructor(this), BuildResourceIdentifierConstructor()];

        private ConstructorProvider BuildResourceIdentifierConstructor()
        {
            var idParameter = new ParameterProvider("id", $"The identifier of the resource that is the target of operations.", typeof(ResourceIdentifier));
            var baseParameters = new List<ParameterProvider>
            {
                new("client", $"The client parameters to use in these operations.", typeof(ArmClient)),
                idParameter
            };

            var initializer = new ConstructorInitializer(true, baseParameters);
            var parameters = new List<ParameterProvider>(baseParameters);

            parameters.AddRange(_pathParameterMap.Keys);

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

            // Assign all path parameter fields by assigning from the path parameters
            foreach (var kvp in _pathParameterMap)
            {
                bodyStatements.Add(kvp.Value.Assign(kvp.Key).Terminate());
            }

            // Initialize all client diagnostics and rest client fields
            foreach (var (inputClient, clientInfo) in _clientInfos)
            {
                bodyStatements.Add(clientInfo.DiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeExpression.Namespace(), thisCollection.Diagnostics())).Terminate());
                var effectiveApiVersion = apiVersion.NullCoalesce(Literal(ManagementClientGenerator.Instance.InputLibrary.DefaultApiVersion));
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type, clientInfo.DiagnosticsField, thisCollection.Pipeline(), thisCollection.Endpoint(), effectiveApiVersion)).Terminate());
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
                Return(This.Invoke("GetAllAsync", [KnownAzureParameters.CancellationTokenWithoutDefault.PositionalReference(KnownAzureParameters.CancellationTokenWithoutDefault)]).Invoke("GetAsyncEnumerator", [KnownAzureParameters.CancellationTokenWithoutDefault])),
                this);
            return [getEnumeratorOfTMethod, getEnumeratorMethod, getEnumeratorAsyncMethod];
        }

        private List<MethodProvider> BuildCreateOrUpdateMethods()
        {
            if (_create is null)
            {
                return [];
            }

            var result = new List<MethodProvider>();
            var restClientInfo = _clientInfos[_create.InputClient];
            foreach (var isAsync in new List<bool> { true, false })
            {
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_create.InputMethod.Operation, isAsync);
                var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync);
                result.Add(new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, _create.InputMethod, isAsync, methodName: methodName, forceLro: true));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(ResourceMethod getAll, bool isAsync)
        {
            var restClientInfo = _clientInfos[getAll.InputClient];
            var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync);
            return getAll.InputMethod switch
            {
                InputPagingServiceMethod pagingGetAll => new PageableOperationMethodProvider(this, _contextualPath, restClientInfo, pagingGetAll, isAsync, methodName),
                _ => new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, getAll.InputMethod, isAsync, methodName)
            };
        }

        private MethodProvider? BuildGetMethod(bool isAsync)
        {
            if (_get is null)
            {
                return null;
            }

            var restClientInfo = _clientInfos[_get.InputClient];
            return new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, _get.InputMethod, isAsync);
        }

        private List<MethodProvider> BuildGetMethods()
        {
            if (_get is null)
            {
                return [];
            }

            // Check if async method provider is null and build it if needed
            if (_getAsyncMethodProvider is null)
            {
                _getAsyncMethodProvider = BuildGetMethod(isAsync: true);
            }

            // Check if sync method provider is null and build it if needed
            if (_getSyncMethodProvider is null)
            {
                _getSyncMethodProvider = BuildGetMethod(isAsync: false);
            }

            return [_getAsyncMethodProvider, _getSyncMethodProvider];
        }

        private List<MethodProvider> BuildExistsMethods()
        {
            if (_get is null)
            {
                return [];
            }

            var result = new List<MethodProvider>();
            var restClientInfo = _clientInfos[_get.InputClient];
            foreach (var isAsync in new List<bool> { true, false })
            {
                var existsMethodProvider = new ExistsOperationMethodProvider(this, _contextualPath, restClientInfo, _get.InputMethod, isAsync);
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

            var restClientInfo = _clientInfos[_get.InputClient];
            foreach (var isAsync in new List<bool> { true, false })
            {
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, _contextualPath, restClientInfo, _get.InputMethod, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }

        public bool TryGetPrivateFieldParameter(ParameterProvider parameter, out FieldProvider? matchingField)
        {
            matchingField = _pathParameterMap
                .FirstOrDefault(kvp => kvp.Key.WireInfo.SerializedName.Equals(parameter.WireInfo.SerializedName, StringComparison.OrdinalIgnoreCase))
                .Value;
            return matchingField != null;
        }
    }
}
