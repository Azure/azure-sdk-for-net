// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ManagementGroups;
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
        private readonly ArmResourceMetadata _resourceMetadata;
        private readonly IReadOnlyList<ParameterProvider> _extraCtorParameters;
        private readonly IReadOnlyList<FieldProvider> _extraFields;
        private readonly ResourceClientProvider _resource;
        // All List-kind methods that should produce a GetAll overload. Ordered so the canonical (broadest-scope)
        // entry comes first; that entry drives the collection's secondary contextual path / extra ctor parameters.
        private readonly IReadOnlyList<ResourceMethod> _getAlls;
        // The canonical GetAll - the entry from _getAlls with the fewest extra variable path segments beyond the
        // collection's contextual path. May be null when the resource has no list operations.
        private readonly ResourceMethod? _getAll;
        private readonly ResourceMethod? _create;
        private readonly ResourceMethod? _get;

        // Cached Get method providers
        private MethodProvider? _getAsyncMethodProvider;
        private MethodProvider? _getSyncMethodProvider;
        private MethodProvider? _getAllSyncMethodProvider;

        // Support for multiple rest clients
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        // This is the resource type of the current resource. Not the resource type of my parent resource
        private ScopedApi<ResourceType> _resourceTypeExpression;

        private readonly OperationContext _operationContext;

        internal ResourceCollectionClientProvider(ResourceClientProvider resource, InputModelType model, IReadOnlyList<ResourceMethod> resourceMethods, ArmResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _resource = resource;

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _resourceTypeExpression = Static(_resource.Type).As<ArmResource>().ResourceType();

            _getAlls = InitializeMethods(resourceMethods, out _get, out _create, resourceMetadata);
            _getAll = _getAlls.Count > 0 ? _getAlls[0] : null;
            _operationContext = InitializeContext(this, resourceMetadata, _getAll);

            // this depends on _getAll being initialized
            (_extraCtorParameters, _extraFields) = BuildExtraConstructorParametersAndFields();
        }

        private static OperationContext InitializeContext(ResourceCollectionClientProvider enclosingType, ArmResourceMetadata resourceMetadata, ResourceMethod? getAll)
        {
            var contextualPath = GetContextualPath(resourceMetadata);
            if (getAll is not null)
            {
                var secondaryContextualPath = getAll.OperationPath;
                // validate the contextualPath should be an ancestor of the secondaryContextualPath, otherwise report diagnostic.
                if (!contextualPath.IsAncestorOf(secondaryContextualPath))
                {
                    // Report diagnostic
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        code: "malformed-resource-detected",
                        message: $"The contextual path '{contextualPath}' is not an ancestor of the secondary contextual path '{secondaryContextualPath}'.",
                        targetCrossLanguageDefinitionId: getAll.InputMethod.CrossLanguageDefinitionId
                    );
                }
                return OperationContext.Create(contextualPath, secondaryContextualPath, enclosingType.FindField);
            }
            else
            {
                return OperationContext.Create(contextualPath);
            }
        }

        private FieldProvider FindField(string variableName)
        {
            // in majority of cases (more than 99.9%) we will only have one or less extra ctor parameters
            // in the majority of rest of cases, we will only have two extra ctor parameters
            // we have never seen more than two extra ctor parameters in real world so far
            // it would be negative optimization to build a dictionary here instead of just searching the list linearly.
            // considering how this extraCtorParamaters are built, we could ensure here we always have a match.
            return _extraCtorParameters.First(p => p.WireInfo.SerializedName == variableName).Field!;
        }

        /// <summary>
        /// Get the contextual request path pattern for this collection client.
        /// The contextual request path pattern for a collection should always be the request path pattern of the parent resource.
        /// </summary>
        /// <param name="resourceMetadata"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private static RequestPathPattern GetContextualPath(ArmResourceMetadata resourceMetadata)
        {
            if (resourceMetadata.ParentResourceId is not null)
            {
                return resourceMetadata.ParentResourceId;
            }

            return resourceMetadata.Scope.ScopeIdPattern;
        }

        private (IReadOnlyList<ParameterProvider> ExtraParameters, IReadOnlyList<FieldProvider> ExtraFields) BuildExtraConstructorParametersAndFields()
        {
            var extraParameters = new List<ParameterProvider>();
            var extraFields = new List<FieldProvider>();
            var secondaryContextualParameters = _operationContext.SecondaryContextualPathParameters;
            foreach (var contextualParameter in secondaryContextualParameters)
            {
                var parameter = new ParameterProvider(
                    contextualParameter.VariableName,
                    $"The {contextualParameter.VariableName} for the resource.",
                    ResourceHelpers.GetRequestPathParameterType(contextualParameter.VariableName, _getAll!.InputMethod));
                var field = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, parameter.Type, $"_{contextualParameter.VariableName}", this, description: $"The {contextualParameter.VariableName}.");
                parameter.Field = field;
                extraParameters.Add(parameter);
                extraFields.Add(field);
            }
            return (extraParameters, extraFields);
        }

        private static IReadOnlyList<ResourceMethod> InitializeMethods(
            IReadOnlyList<ResourceMethod> resourceMethods,
            out ResourceMethod? getMethod,
            out ResourceMethod? createMethod,
            ArmResourceMetadata resourceMetadata)
        {
            getMethod = null;
            createMethod = null;
            var listMethods = new List<ResourceMethod>();

            foreach (var method in resourceMethods)
            {
                switch (method.Kind)
                {
                    case ResourceOperationKind.Read:
                        getMethod ??= method;
                        break;
                    case ResourceOperationKind.List:
                        // collect all list operations - tuple resources may have multiple list operations
                        // at different parent scopes, each producing a distinct GetAll overload.
                        listMethods.Add(method);
                        break;
                    case ResourceOperationKind.Create:
                        createMethod ??= method;
                        break;
                }
            }

            return SortGetAllMethodsByScopeBreadth(listMethods, resourceMetadata);
        }

        /// <summary>
        /// Orders list methods so the broadest-scope (canonical) entry is first. The canonical entry has the
        /// fewest extra variable path segments beyond the collection's contextual path; it drives the
        /// collection's secondary contextual path, extra ctor parameters, and the parameterless GetAll() overload.
        /// </summary>
        private static IReadOnlyList<ResourceMethod> SortGetAllMethodsByScopeBreadth(
            IReadOnlyList<ResourceMethod> listMethods,
            ArmResourceMetadata resourceMetadata)
        {
            if (listMethods.Count <= 1)
            {
                return listMethods;
            }

            var contextualPath = GetContextualPath(resourceMetadata);
            return [.. listMethods
                .OrderBy(m => CountExtraVariableSegments(contextualPath, m.OperationPath))
                .ThenBy(m => m.OperationPath.Count)];
        }

        private static int CountExtraVariableSegments(RequestPathPattern contextualPath, RequestPathPattern operationPath)
        {
            // If the operation path is not on the same branch as the contextual path, deprioritize it so
            // a same-branch list still wins canonical selection.
            if (!contextualPath.IsAncestorOf(operationPath))
            {
                return int.MaxValue;
            }

            var extra = contextualPath.TrimAncestorFrom(operationPath);
            int count = 0;
            foreach (var segment in extra)
            {
                if (!segment.IsConstant)
                {
                    count++;
                }
            }
            return count;
        }

        public ResourceClientProvider Resource => _resource;
        public IReadOnlyList<ParameterProvider> PathParameters => _extraCtorParameters;

        // Cached Get method providers for reuse in other places
        public MethodProvider? GetAsyncMethodProvider => _getAsyncMethodProvider ??= BuildGetMethod(isAsync: true);

        public MethodProvider? GetSyncMethodProvider => _getSyncMethodProvider ??= BuildGetMethod(isAsync: false);

        internal string ResourceName => _resource.ResourceName;
        internal ResourceScope ResourceScope => _resource.ResourceScope;
        internal ModelProvider ResourceData => _resource.ResourceData;

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{ResourceName}Collection";

        protected override FormattableString BuildDescription()
        {
            var parentResourceType = GetParentResourceType(_resourceMetadata, _resource) ?? typeof(ArmResource); // TODO: will update this with actual external resource type
            return $"A class representing a collection of {_resource.Type:C} and their operations.\nEach {_resource.Type:C} in the collection will belong to the same instance of {parentResourceType:C}.\nTo get a {Type:C} instance call the Get{ResourceName.Pluralize()} method from an instance of {parentResourceType:C}.";
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override CSharpType? BuildBaseType() => typeof(ArmCollection);

        protected override CSharpType[] BuildImplements() =>
            ShouldSkipIEnumerableImplementation()
            ? []
            : [new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        private bool ShouldSkipIEnumerableImplementation()
        {
            return _getAllSyncMethodProvider is null || _getAllSyncMethodProvider.Signature.Parameters.Any(p => p.DefaultValue is null);
        }

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

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var clientInfo in _clientInfos.Values)
            {
                fields.Add(clientInfo.DiagnosticsField);
                fields.Add(clientInfo.RestClientField);
            }
            return [.. fields, .. _extraFields];
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

            parameters.AddRange(_extraCtorParameters);

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
            foreach (var parameter in _extraCtorParameters)
            {
                bodyStatements.Add(parameter.Field!.Assign(parameter).Terminate());
            }

            // Initialize all client diagnostics and rest client fields
            foreach (var (inputClient, clientInfo) in _clientInfos)
            {
                bodyStatements.Add(clientInfo.DiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeExpression.Namespace(), thisCollection.Diagnostics())).Terminate());
                var effectiveApiVersion = apiVersion.NullCoalesce(Literal(inputClient.CurrentApiVersion));
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type, clientInfo.DiagnosticsField, thisCollection.Pipeline(), thisCollection.Endpoint(), effectiveApiVersion)).Terminate());
            }

            // skip resource Id validation for extension resource without parent resource type, since we don't have enough information to validate the resource Id. For example, for an extension resource with resource scope of extension and no parent resource type specified, the resource Id pattern could be something like /{scope}/providers/Microsoft.ABC/def/{defName}, in this case we don't know what the {scope} is, it could be subscription, resource group, or even a management group, so we can't validate the resource Id.
            if (_resourceMetadata.Scope.Kind != ResourceScope.Extension || _resourceMetadata.Scope.ScopeResourceType is not null)
            {
                bodyStatements.Add(Static(Type).As<ArmCollection>().ValidateResourceId(idParameter).Terminate());
            }

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private static CSharpType? GetParentResourceType(ArmResourceMetadata resourceMetadata, ResourceClientProvider resource)
        {
            // First check if the resource has a parent resource
            if (resourceMetadata.ParentResourceId is not null)
            {
                return resource.TypeOfParentResource;
            }

            // Fallback to scope-based resource type
            switch (resourceMetadata.Scope.Kind)
            {
                case ResourceScope.ResourceGroup:
                    return typeof(ResourceGroupResource);
                case ResourceScope.Subscription:
                    return typeof(SubscriptionResource);
                case ResourceScope.Tenant:
                    return typeof(TenantResource);
                case ResourceScope.ManagementGroup:
                    return typeof(ManagementGroupResource);
                case ResourceScope.Extension:
                    // Generic-scope extension resources (e.g., /{scope}/providers/...) have no
                    // specific parent type. Return null so callers fall back to ArmResource.
                    return null;
                default:
                    // TODO -- this is incorrect, but we put it here as a placeholder.
                    return resource.Type;
            }
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>();
            var parentResourceCsharpType = GetParentResourceType(_resourceMetadata, _resource);
            if (_resourceMetadata.Scope.Kind != ResourceScope.Extension)
            {
                methods.Add(ResourceMethodSnippets.BuildValidateResourceIdMethod(this,Static(parentResourceCsharpType!).As<ArmResource>().ResourceType()));
            }
            // For extension resource with known parent resource type, we can also generate a ValidateResourceId method
            else if (_resourceMetadata.Scope.ScopeResourceType is { } parentResourceType)
            {
                methods.Add(ResourceMethodSnippets.BuildValidateResourceIdMethod(this, Literal(parentResourceType)));
            }

            methods.AddRange(BuildCreateOrUpdateMethods());
            methods.AddRange(BuildGetMethods());
            methods.AddRange(BuildGetAllMethods());
            methods.AddRange(BuildExistsMethods());
            methods.AddRange(BuildGetIfExistsMethods());
            methods.AddRange(BuildEnumeratorMethods());

            return [.. methods];
        }

        private MethodProvider[] BuildGetAllMethods()
        {
            if (_getAlls.Count == 0)
            {
                return [];
            }

            var methods = new List<MethodProvider>(_getAlls.Count * 2);
            var seenSignatures = new HashSet<string>(StringComparer.Ordinal);
            foreach (var listMethod in _getAlls)
            {
                var sync = BuildGetAllMethod(listMethod, false);
                var async = BuildGetAllMethod(listMethod, true);

                // Cache the canonical sync provider (the broadest-scope GetAll) for enumerator decisions.
                if (ReferenceEquals(listMethod, _getAll))
                {
                    _getAllSyncMethodProvider = sync;
                }

                // De-dup by sync signature to avoid emitting two GetAll overloads with identical C# signatures.
                var key = string.Join(",", sync.Signature.Parameters.Select(p => p.Type.ToString()));
                if (!seenSignatures.Add(key))
                {
                    continue;
                }
                methods.Add(async);
                methods.Add(sync);
            }

            return [.. methods];
        }

        private MethodProvider[] BuildEnumeratorMethods()
        {
            if (ShouldSkipIEnumerableImplementation())
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
                var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync, true);
                result.Add(new ResourceOperationMethodProvider(this, _operationContext, restClientInfo, _create.InputMethod, isAsync, methodName: methodName, forceLro: true));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(ResourceMethod getAll, bool isAsync)
        {
            var restClientInfo = _clientInfos[getAll.InputClient];
            var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync, true);
            return getAll.InputMethod switch
            {
                InputPagingServiceMethod pagingGetAll => new PageableOperationMethodProvider(this, _operationContext, restClientInfo, pagingGetAll, isAsync, methodName, _resource),
                _ => BuildNonPagingGetAllMethod(getAll.InputMethod, restClientInfo, isAsync, methodName)
            };
        }

        private MethodProvider BuildNonPagingGetAllMethod(InputServiceMethod method, RestClientInfo clientInfo, bool isAsync, string? methodName)
        {
            // Check if the response body type is a list - if so, wrap it in a single-page pageable
            var responseBodyType = method.GetResponseBodyType();
            if (responseBodyType != null && responseBodyType.IsList)
            {
                return new ArrayResponseOperationMethodProvider(this, _operationContext, clientInfo, method, isAsync, methodName, _resource);
            }

            return new ResourceOperationMethodProvider(this, _operationContext, clientInfo, method, isAsync, methodName);
        }

        private MethodProvider? BuildGetMethod(bool isAsync)
        {
            if (_get is null)
            {
                return null;
            }

            var restClientInfo = _clientInfos[_get.InputClient];
            var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, isAsync, true);
            return new ResourceOperationMethodProvider(this, _operationContext, restClientInfo, _get.InputMethod, isAsync, methodName);
        }

        private List<MethodProvider> BuildGetMethods()
        {
            // Check if async method provider is null and build it if needed
            if (_getAsyncMethodProvider is null)
            {
                _getAsyncMethodProvider = BuildGetMethod(true);
            }

            // Check if sync method provider is null and build it if needed
            if (_getSyncMethodProvider is null)
            {
                _getSyncMethodProvider = BuildGetMethod(false);
            }

            if (_getAsyncMethodProvider is null || _getSyncMethodProvider is null)
            {
                return [];
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
                var existsMethodProvider = new ExistsOperationMethodProvider(this, _operationContext, restClientInfo, _get.InputMethod, isAsync);
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
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, _operationContext, restClientInfo, _get.InputMethod, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }
    }
}
