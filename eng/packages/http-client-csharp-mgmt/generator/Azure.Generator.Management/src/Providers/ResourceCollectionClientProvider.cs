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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.TypeSpec.Generator.Expressions;
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
        private (IReadOnlyList<ParameterProvider> Parameters, IReadOnlyList<FieldProvider> Fields)? _extraConstructor;
        private IReadOnlyList<ParameterProvider> _extraCtorParameters => (_extraConstructor ??= BuildExtraConstructorParametersAndFields()).Parameters;
        private IReadOnlyList<FieldProvider> _extraFields => (_extraConstructor ??= BuildExtraConstructorParametersAndFields()).Fields;
        private readonly ResourceClientProvider _resource;
        private readonly IReadOnlyList<ResourceMethod> _getAlls;
        private readonly IReadOnlyList<ResourceMethod> _actions;
        private readonly ResourceMethod? _create;
        private readonly ResourceMethod? _get;
        private readonly ResourceMethod? _checkExistence;
        private readonly IReadOnlyList<ResourceMethod> _resourceMethods;

        // Cached Get method providers
        private MethodProvider? _getAsyncMethodProvider;
        private MethodProvider? _getSyncMethodProvider;
        private MethodProvider? _getAllSyncMethodProvider;

        // Support for multiple rest clients
        private Dictionary<InputClient, RestClientInfo>? _clientInfosCache;
        private Dictionary<InputClient, RestClientInfo> _clientInfos => _clientInfosCache ??= BuildClientInfos();

        // This is the resource type of the current resource. Not the resource type of my parent resource
        private ScopedApi<ResourceType> _resourceTypeExpression;

        private readonly OperationContext _operationContext;

        internal ResourceCollectionClientProvider(ResourceClientProvider resource, InputModelType model, IReadOnlyList<ResourceMethod> resourceMethods, ArmResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _resource = resource;
            _resourceMethods = resourceMethods;

            _resourceTypeExpression = Static(_resource.Type).As<ArmResource>().ResourceType();

            var contextualPath = GetContextualPath(resourceMetadata);
            (_get, _checkExistence, _create, _getAlls, _actions) = InitializeMethods(resourceMethods, contextualPath);
            _operationContext = InitializeContext(this, contextualPath, _getAlls.Count > 0 ? _getAlls[0] : null);
        }

        private Dictionary<InputClient, RestClientInfo> BuildClientInfos()
        {
            return _resourceMetadata.CreateClientInfosMap(this,
                _resourceMethods.Where(method => method.Kind != ResourceOperationKind.CheckExistence || ReferenceEquals(method, _checkExistence)));
        }

        private static OperationContext InitializeContext(ResourceCollectionClientProvider enclosingType, RequestPathPattern contextualPath, ResourceMethod? canonicalGetAll)
        {
            if (canonicalGetAll is null)
            {
                return OperationContext.Create(contextualPath);
            }

            var secondaryContextualPath = canonicalGetAll.OperationPath;
            // validate the contextualPath should be an ancestor of the secondaryContextualPath, otherwise report diagnostic.
            if (!contextualPath.IsAncestorOf(secondaryContextualPath))
            {
                // Report diagnostic
                ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                    code: "malformed-resource-detected",
                    message: $"The contextual path '{contextualPath}' is not an ancestor of the secondary contextual path '{secondaryContextualPath}'.",
                    targetCrossLanguageDefinitionId: canonicalGetAll.InputMethod.CrossLanguageDefinitionId
                );
            }
            return OperationContext.Create(contextualPath, secondaryContextualPath, enclosingType.FindField);
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
            var parameterTypes = secondaryContextualParameters
                .Select(parameter => ResourceHelpers.GetRequestPathParameterType(parameter.VariableName, _getAlls[0].InputMethod)).ToArray();
            for (var index = 0; index < secondaryContextualParameters.Count; index++)
            {
                var contextualParameter = secondaryContextualParameters[index];
                var inputParameter = SynthesizedParameterNameHelper.GetPathParameter(contextualParameter.VariableName, _getAlls[0].InputMethod);
                var parameterName = inputParameter?.IsExactName == true
                    ? inputParameter.Name
                    : GetExistingAccessorParameterName(parameterTypes, index)
                        ?? SynthesizedParameterNameHelper.GetPathParameterName(contextualParameter.VariableName, _getAlls[0].InputMethod);
                var parameter = SynthesizedParameterNameHelper.PreserveName(new ParameterProvider(
                    parameterName,
                    $"The {parameterName} for the resource.",
                    parameterTypes[index],
                    location: ParameterLocation.Path,
                    wireInfo: new WireInformation(SerializationFormat.Default, contextualParameter.VariableName),
                    inputParameter: inputParameter));
                var field = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, parameter.Type, $"_{parameterName}", this, description: $"The {parameterName}.");
                parameter.Field = field;
                extraParameters.Add(parameter);
                extraFields.Add(field);
            }
            return (extraParameters, extraFields);
        }

        private string? GetExistingAccessorParameterName(IReadOnlyList<CSharpType> parameterTypes, int index)
        {
            var library = ManagementClientGenerator.Instance.OutputLibrary;
            var methodName = ResourceName.GetCollectionMethodName();
            if (_resourceMetadata.ParentResourceId is { } parentId)
            {
                var parent = library.GetResourceById(parentId);
                methodName = _resource.GetPublishedCollectionAccessor(parent, parameterTypes)?.Signature.Name ?? methodName;
                return SynthesizedParameterNameHelper.GetExistingParameterName(parent, methodName, parameterTypes, index);
            }

            var mockable = _resourceMetadata.Scope.Kind == ResourceScope.Extension
                ? library.MockableResourceProviders.OfType<MockableArmClientProvider>().Single()
                : library.GetMockableResourceByScope(_resourceMetadata.Scope.Kind);
            var offset = _resourceMetadata.Scope.Kind == ResourceScope.Extension ? 1 : 0;
            CSharpType[] prefixTypes = offset > 0 ? [typeof(ResourceIdentifier)] : [];
            methodName = _resource.GetPublishedCollectionAccessor(mockable, [.. prefixTypes, .. parameterTypes])?.Signature.Name ?? methodName;
            return SynthesizedParameterNameHelper.GetExistingParameterName(mockable, methodName, parameterTypes, index, offset, prefixTypes)
                ?? SynthesizedParameterNameHelper.GetExistingParameterName(library.ExtensionProvider, methodName, parameterTypes, index, offset + 1, [mockable.ArmCoreType, .. prefixTypes]);
        }

        private static (ResourceMethod? Get, ResourceMethod? CheckExistence, ResourceMethod? Create, IReadOnlyList<ResourceMethod> GetAlls, IReadOnlyList<ResourceMethod> Actions) InitializeMethods(
            IReadOnlyList<ResourceMethod> resourceMethods,
            RequestPathPattern contextualPath)
        {
            ResourceMethod? getMethod = null;
            ResourceMethod? checkExistenceMethod = null;
            ResourceMethod? createMethod = null;
            var listMethods = new List<ResourceMethod>();
            var actionMethods = new List<ResourceMethod>();

            foreach (var method in resourceMethods)
            {
                switch (method.Kind)
                {
                    case ResourceOperationKind.Read:
                        getMethod ??= method;
                        break;
                    case ResourceOperationKind.CheckExistence:
                        checkExistenceMethod ??= method;
                        break;
                    case ResourceOperationKind.List:
                        listMethods.Add(method);
                        break;
                    case ResourceOperationKind.Create:
                        createMethod ??= method;
                        break;
                    case ResourceOperationKind.CollectionAction:
                        actionMethods.Add(method);
                        break;
                }
            }

            return (getMethod, checkExistenceMethod, createMethod, SortGetAllMethodsByScopeBreadth(listMethods, contextualPath), actionMethods);
        }

        private static IReadOnlyList<ResourceMethod> SortGetAllMethodsByScopeBreadth(
            IReadOnlyList<ResourceMethod> listMethods,
            RequestPathPattern contextualPath)
        {
            if (listMethods.Count <= 1)
            {
                return listMethods;
            }

            return [.. listMethods
                .OrderBy(m => CountExtraVariableSegments(contextualPath, m.OperationPath))
                .ThenBy(m => m.OperationPath.Count)];
        }

        private static int CountExtraVariableSegments(RequestPathPattern contextualPath, RequestPathPattern operationPath)
        {
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

        private ParameterContextRegistry BuildParameterMapping(RequestPathPattern operationPath)
        {
            // A resource collection is already bound to one concrete child resource type,
            // but some ARM operations are modeled with a variable resource-type segment so
            // the same REST operation can serve multiple concrete resource kinds.
            //
            // For example:
            //   Resource type: Microsoft.Network/dnsZones/A
            //   Operation path: .../dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}
            //
            // In that shape, {recordType} is not a caller choice for DnsARecordCollection:
            // the collection itself means "A records", so generated collection methods
            // should pass "A" to the REST client internally and should not expose
            // recordType as a public method parameter.
            //
            // OperationContext intentionally handles only values that come from the
            // enclosing resource id, such as subscriptionId, resourceGroupName, zoneName,
            // or parent resource names. It should not know that this collection's concrete
            // resource type fixes an operation resource-type variable. Therefore the
            // collection adds these overrides after the normal OperationContext mapping.
            return _operationContext
                .BuildParameterMapping(operationPath)
                .WithContextualParameterOverrides(GetResourceTypeSegmentParameterMappings(operationPath));
        }

        private IReadOnlyList<ParameterContextMapping> GetResourceTypeSegmentParameterMappings(RequestPathPattern operationPath)
        {
            var resourceTypeSegments = _resource.ResourceType;
            var operationTypeSegments = operationPath.ResourceType;
            var mappings = new List<ParameterContextMapping>();

            // Compare only resource type segments:
            // - scope and parent path parameters remain OperationContext's responsibility;
            // - resource name parameters remain public method parameters;
            // - only operation variables in resource-type segment positions can be replaced
            //   by constants from the concrete collection resource type.
            //
            // If a resource-type segment differs in any other way, stop applying overrides
            // so unrelated operation paths do not accidentally inherit constants from this
            // collection.
            for (int i = 0; i < operationTypeSegments.Count && i < resourceTypeSegments.Count; i++)
            {
                var operationSegment = operationTypeSegments[i];
                var resourceSegment = resourceTypeSegments[i];
                if (operationSegment.IsConstant && resourceSegment.IsConstant)
                {
                    if (!operationSegment.Equals(resourceSegment))
                    {
                        break;
                    }
                    continue;
                }

                if (!operationSegment.IsConstant && !resourceSegment.IsConstant)
                {
                    continue;
                }

                if (!operationSegment.IsConstant && resourceSegment.IsConstant)
                {
                    var fixedValue = resourceSegment.Value;
                    mappings.Add(new ParameterContextMapping(
                        operationSegment.VariableName,
                        new ContextualParameter(fixedValue, operationSegment.VariableName, _ => Literal(fixedValue))));
                    continue;
                }

                break;
            }

            return mappings;
        }

        // Cached Get method providers for reuse in other places
        public MethodProvider? GetAsyncMethodProvider => _getAsyncMethodProvider ??= BuildGetMethod(isAsync: true);

        public MethodProvider? GetSyncMethodProvider => _getSyncMethodProvider ??= BuildGetMethod(isAsync: false);

        internal string ResourceName => _resource.ResourceName;
        internal ResourceScope ResourceScope => _resource.ResourceScope;
        internal TypeProvider ResourceData => _resource.ResourceData;

        protected override TypeProvider[] BuildSerializationProviders() => [];

        protected override string BuildName() => $"{ResourceName}Collection";

        protected override FormattableString BuildDescription()
        {
            var parentResourceType = GetParentResourceType(_resourceMetadata, _resource) ?? typeof(ArmResource); // TODO: will update this with actual external resource type
            return $"A class representing a collection of {_resource.Type:C} and their operations.\nEach {_resource.Type:C} in the collection will belong to the same instance of {parentResourceType:C}.\nTo get a {Type:C} instance call the {_resource.FactoryMethodSignature.Name} method from an instance of {parentResourceType:C}.";
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override IReadOnlyList<CSharpType> BuildBodyDependencyTypes()
            => ManagementMethodProvider.GetBodyDependencyTypes(Methods);

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

            ScopedApi<string>? apiVersion = null;
            if (_clientInfos.Keys.Any(client => client.NeedsApiVersionField && client.ConstructorApiVersion is null))
            {
                bodyStatements.Add(thisCollection.TryGetApiVersion(_resourceTypeExpression, $"{ResourceName}ApiVersion".ToVariableName(), out var resolvedApiVersion).Terminate());
                apiVersion = resolvedApiVersion;
            }

            // Assign all path parameter fields by assigning from the path parameters
            foreach (var parameter in _extraCtorParameters)
            {
                bodyStatements.Add(parameter.Field!.Assign(parameter).Terminate());
            }

            // Initialize all client diagnostics and rest client fields
            foreach (var (inputClient, clientInfo) in _clientInfos)
            {
                bodyStatements.Add(clientInfo.DiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeExpression.Namespace(), thisCollection.Diagnostics())).Terminate());
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type,
                [
                    clientInfo.DiagnosticsField, thisCollection.Pipeline(), thisCollection.Diagnostics().Property(nameof(DiagnosticsOptions.ApplicationId)), thisCollection.Endpoint(),
                    .. inputClient.NeedsApiVersionField ? new[] { inputClient.ConstructorApiVersion is { } constructorVersion
                        ? InputClientExtensions.BuildConstructorApiVersion(constructorVersion, isCollection: true,
                            variableName: $"{clientInfo.RestClientProvider.Name}ApiVersionOverride".ToVariableName())
                        : apiVersion!.NullCoalesce(Literal(inputClient.CurrentApiVersion)) } : [],
                    .. inputClient.NeedsApiVersionResolver ? new[] { InputClientExtensions.BuildApiVersionResolver(isCollection: true) } : []
                ])).Terminate());
            }

            if (TryGetResourceIdValidationType(out _))
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

        private bool TryGetResourceIdValidationType(out ValueExpression resourceType)
        {
            var parentResourceCsharpType = GetParentResourceType(_resourceMetadata, _resource);
            if (_resourceMetadata.ParentResourceId is not null || _resourceMetadata.Scope.Kind != ResourceScope.Extension)
            {
                resourceType = Static(parentResourceCsharpType!).As<ArmResource>().ResourceType();
                return true;
            }

            // For extension resources with a known parent scope type, validate against that scope.
            // Generic-scope extension resources do not have enough information to validate.
            if (_resourceMetadata.Scope.ScopeResourceType is { } parentResourceType)
            {
                resourceType = Literal(parentResourceType);
                return true;
            }

            resourceType = null!;
            return false;
        }

        protected override IReadOnlyList<MethodProvider> BuildMethodsForBackCompatibility(IEnumerable<MethodProvider> originalMethods)
        {
            if (LastContractView?.Methods == null || LastContractView.Methods.Count == 0)
            {
                return [.. originalMethods];
            }

            var originalMethodList = originalMethods.ToList();
            if (_get is not null && _checkExistence is not null)
            {
                var restClientInfo = _clientInfos[_get.InputClient];
                var parameterMappings = BuildParameterMapping(new RequestPathPattern(_get.InputMethod.Operation.Path));
                foreach (var isAsync in new[] { false, true })
                {
                    MethodProvider candidate = new ExistsOperationMethodProvider(this, parameterMappings, restClientInfo, _get.InputMethod, _get.Kind, isAsync);
                    var checkClient = _clientInfos[_checkExistence.InputClient];
                    var checkMappings = BuildParameterMapping(new RequestPathPattern(_checkExistence.InputMethod.Operation.Path));
                    MethodProvider checkMethod = new ExistsOperationMethodProvider(this, checkMappings, checkClient, _checkExistence.InputMethod, _checkExistence.Kind, isAsync);
                    var primary = originalMethodList.Concat(CustomCodeView?.Methods ?? [])
                        .FirstOrDefault(method => MethodSignature.MethodSignatureComparer.Equals(method.Signature, checkMethod.Signature));
                    foreach (var previous in LastContractView.Methods.Where(method =>
                        method.Signature.Name == candidate.Signature.Name &&
                        method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                        !BackCompatHelper.IsMethodRemovalAcceptedInBaseline(this, method.Signature)))
                    {
                        var custom = CustomCodeView?.Methods.FirstOrDefault(method => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previous.Signature));
                        var existing = custom ?? originalMethodList.FirstOrDefault(method => MethodSignature.MethodSignatureComparer.Equals(method.Signature, previous.Signature));
                        if (existing is not null)
                        {
                            if (ReferenceEquals(existing, primary) && originalMethodList.Contains(existing))
                            {
                                var publishedParameters = GetPublishedCheckParameters(existing.Signature, previous.Signature);
                                if (publishedParameters is null)
                                {
                                    ReportExistsCompatibilityError(previous.Signature.Name, "requires a parameter that was previously optional or cannot preserve its published parameter names");
                                }
                                else
                                {
                                    MethodProvider replacement = new ExistsOperationMethodProvider(this, checkMappings, checkClient, _checkExistence.InputMethod, _checkExistence.Kind, isAsync, publishedParameters);
                                    replacement.Signature.Update(modifiers: (replacement.Signature.Modifiers & ~MethodSignatureModifiers.Internal & ~MethodSignatureModifiers.Private & ~MethodSignatureModifiers.Protected)
                                        | MethodSignatureModifiers.Public | (previous.Signature.Modifiers & MethodSignatureModifiers.Virtual));
                                    originalMethodList[originalMethodList.IndexOf(existing)] = replacement;
                                    primary = replacement;
                                }
                            }
                            else if (primary is not null && !MethodSignature.MethodSignatureComparer.Equals(primary.Signature, existing.Signature))
                            {
                                ReportAmbiguousExistsOverload(primary, existing);
                            }
                            continue;
                        }

                        var parameters = GetPublishedReadParameters(candidate.Signature, previous.Signature);
                        if (parameters is null)
                        {
                            ReportExistsCompatibilityError(previous.Signature.Name, "cannot be reconstructed from the current read operation");
                            continue;
                        }

                        MethodProvider legacy = new ExistsOperationMethodProvider(this, parameterMappings, restClientInfo, _get.InputMethod, _get.Kind, isAsync, parameters);
                        legacy.Signature.Update(modifiers: (legacy.Signature.Modifiers & ~MethodSignatureModifiers.Internal & ~MethodSignatureModifiers.Private & ~MethodSignatureModifiers.Protected)
                            | MethodSignatureModifiers.Public | (previous.Signature.Modifiers & MethodSignatureModifiers.Virtual));
                        originalMethodList.Add(legacy);
                        if (primary is not null)
                        {
                            ReportAmbiguousExistsOverload(primary, legacy);
                        }
                    }
                }
            }
            var backCompatMethods = base.BuildMethodsForBackCompatibility(originalMethodList);

            return BackCompatHelper.DecorateBackwardCompatibilityMethods(backCompatMethods, originalMethodList);
        }

        private static IReadOnlyList<ParameterProvider>? GetPublishedReadParameters(MethodSignature current, MethodSignature previous)
        {
            if (current.ReturnType is not { } returnType || previous.ReturnType is not { } previousReturnType ||
                !returnType.AreNamesEqual(previousReturnType))
            {
                return null;
            }

            var parameters = new List<ParameterProvider>();
            foreach (var oldParameter in previous.Parameters)
            {
                var parameter = current.Parameters.SingleOrDefault(p => p.Name == oldParameter.Name && p.Type.AreNamesEqual(oldParameter.Type));
                if (parameter is null || (parameter.DefaultValue is null && oldParameter.DefaultValue is not null) ||
                    parameter.IsRef != oldParameter.IsRef || parameter.IsOut != oldParameter.IsOut || parameter.IsIn != oldParameter.IsIn)
                {
                    return null;
                }
                var becameOptional = parameter.DefaultValue is not null && oldParameter.DefaultValue is null;
                var validation = becameOptional && !oldParameter.Type.IsValueType && !oldParameter.Type.IsNullable
                    ? oldParameter.Type.AreNamesEqual(typeof(string)) ? ParameterValidationType.AssertNotNullOrEmpty : ParameterValidationType.AssertNotNull
                    : parameter.Validation;
                parameters.Add(CopyParameter(parameter, oldParameter.DefaultValue, type: oldParameter.Type, validation: validation));
            }

            if (current.Parameters.Any(p => !previous.Parameters.Any(old => p.Name == old.Name && p.Type.AreNamesEqual(old.Type)) &&
                (p.DefaultValue is null || (!ReferenceEquals(p.DefaultValue, Default) && !ReferenceEquals(p.DefaultValue, Null)))))
            {
                return null;
            }
            return parameters;
        }

        private static IReadOnlyList<ParameterProvider>? GetPublishedCheckParameters(MethodSignature current, MethodSignature previous)
        {
            var parameters = new List<ParameterProvider>();
            for (var i = 0; i < current.Parameters.Count; i++)
            {
                var parameter = current.Parameters[i];
                var oldParameter = previous.Parameters[i];
                if ((oldParameter.DefaultValue is not null && parameter.DefaultValue is null) ||
                    (parameter.Type.Equals(typeof(System.Threading.CancellationToken)) && parameter.Name != oldParameter.Name))
                {
                    return null;
                }
                parameters.Add(CopyParameter(parameter, oldParameter.DefaultValue ?? parameter.DefaultValue, oldParameter.Name));
            }
            return parameters;
        }

        private static ParameterProvider CopyParameter(ParameterProvider parameter, ValueExpression? defaultValue, string? name = null, CSharpType? type = null, ParameterValidationType? validation = null)
            => new(name ?? parameter.Name, parameter.Description, type ?? parameter.Type, defaultValue,
                isRef: parameter.IsRef, isOut: parameter.IsOut, isIn: parameter.IsIn, isParams: parameter.IsParams,
                attributes: parameter.Attributes, property: parameter.Property, field: parameter.Field,
                initializationValue: parameter.InitializationValue, location: parameter.Location, wireInfo: parameter.WireInfo,
                validation: validation ?? parameter.Validation, inputParameter: parameter.InputParameter);

        private void ReportExistsCompatibilityError(string methodName, string reason)
        {
            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-error",
                $"The published '{methodName}' overload on '{Name}' {reason}. A custom compatibility implementation is required.",
                severity: Microsoft.TypeSpec.Generator.EmitterRpc.EmitterDiagnosticSeverity.Error);
        }

        private void ReportAmbiguousExistsOverload(MethodProvider primary, MethodProvider previous)
        {
            if (!primary.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) ||
                !previous.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
            {
                return;
            }

            var resolution = CheckDefaultLiteralResolution(primary.Signature, previous.Signature);
            if (resolution != ExistsOverloadResolution.Published)
            {
                var reason = resolution switch
                {
                    ExistsOverloadResolution.Ambiguous => "has ambiguous optional parameters with the check-existence method",
                    ExistsOverloadResolution.CheckExistence => "would rebind previously valid calls to the check-existence method",
                    _ => "cannot be checked for default-literal overload ambiguity"
                };
                ReportExistsCompatibilityError(primary.Signature.Name, reason);
            }
        }

        private enum ExistsOverloadResolution { Published, CheckExistence, Ambiguous, Unknown }

        private static ExistsOverloadResolution CheckDefaultLiteralResolution(MethodSignature current, MethodSignature previous)
        {
            if (ManagementClientGenerator.Instance.SourceInputModel?.LastContract is not CSharpCompilation compilation)
            {
                return ExistsOverloadResolution.Unknown;
            }

            ITypeSymbol? ResolveType(CSharpType type)
            {
                if (type.IsArray)
                {
                    var element = ResolveType(type.ElementType);
                    return element is null ? null : compilation.CreateArrayTypeSymbol(element,
                        type.IsFrameworkType ? type.FrameworkType.GetArrayRank() : 1);
                }
                var metadataName = type.IsFrameworkType ? type.FrameworkType.FullName :
                    type.FullyQualifiedName + (type.Arguments.Count == 0 ? string.Empty : $"`{type.Arguments.Count}");
                var symbol = metadataName is null ? null : compilation.GetTypeByMetadataName(metadataName);
                if (symbol is null)
                {
                    return null;
                }
                if (type.Arguments.Count > 0)
                {
                    var arguments = type.Arguments.Select(ResolveType).ToArray();
                    if (arguments.Any(argument => argument is null))
                    {
                        return null;
                    }
                    symbol = symbol.Construct(arguments.Select(argument => argument!).ToArray());
                }
                if (symbol.IsValueType && type.IsNullable)
                {
                    symbol = compilation.GetSpecialType(SpecialType.System_Nullable_T).Construct(symbol);
                }
                return symbol;
            }

            string? FormatParameters(MethodSignature signature)
            {
                var parameters = new List<string>();
                for (var i = 0; i < signature.Parameters.Count; i++)
                {
                    var parameter = signature.Parameters[i];
                    if (parameter.IsRef || parameter.IsIn || parameter.IsOut || parameter.IsParams || ResolveType(parameter.Type) is not { } symbol)
                    {
                        return null;
                    }
                    var type = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    parameters.Add($"{type} {EscapeName(parameter.Name)}{(parameter.DefaultValue is null ? string.Empty : " = default")}");
                }
                return string.Join(", ", parameters);
            }

            const int maximumCallShapes = 256;
            var calls = new HashSet<string>(StringComparer.Ordinal);
            var requiredCount = Math.Max(current.Parameters.Count(parameter => parameter.DefaultValue is null), previous.Parameters.Count(parameter => parameter.DefaultValue is null));
            var maximumCount = Math.Min(current.Parameters.Count, previous.Parameters.Count);
            for (var count = requiredCount; count <= maximumCount; count++)
            {
                calls.Add(string.Join(", ", Enumerable.Repeat("default", count)));
            }
            for (var positionalCount = 0; positionalCount <= maximumCount; positionalCount++)
            {
                var currentRemaining = current.Parameters.Skip(positionalCount).ToDictionary(parameter => parameter.Name, StringComparer.Ordinal);
                var previousRemaining = previous.Parameters.Skip(positionalCount).ToDictionary(parameter => parameter.Name, StringComparer.Ordinal);
                if (currentRemaining.Values.Any(parameter => parameter.DefaultValue is null && !previousRemaining.ContainsKey(parameter.Name)) ||
                    previousRemaining.Values.Any(parameter => parameter.DefaultValue is null && !currentRemaining.ContainsKey(parameter.Name)))
                {
                    continue;
                }
                var common = previousRemaining.Values.Where(parameter => currentRemaining.ContainsKey(parameter.Name)).ToArray();
                var optional = common.Where(parameter => parameter.DefaultValue is not null && currentRemaining[parameter.Name].DefaultValue is not null).ToArray();
                if (optional.Length >= 9)
                {
                    return ExistsOverloadResolution.Unknown;
                }
                for (var mask = 0; mask < (1 << optional.Length); mask++)
                {
                    var named = common.Where(parameter => parameter.DefaultValue is null || currentRemaining[parameter.Name].DefaultValue is null ||
                        (mask & (1 << Array.IndexOf(optional, parameter))) != 0).ToArray();
                    if (named.Length == 0)
                    {
                        continue;
                    }
                    var arguments = Enumerable.Repeat("default", positionalCount)
                        .Concat(named.Select(parameter => $"{EscapeName(parameter.Name)}: default"));
                    calls.Add(string.Join(", ", arguments));
                    if (calls.Count > maximumCallShapes)
                    {
                        return ExistsOverloadResolution.Unknown;
                    }
                }
            }
            if (calls.Count == 0)
            {
                return ExistsOverloadResolution.Published;
            }
            var currentParameters = FormatParameters(current);
            var previousParameters = FormatParameters(previous);
            if (currentParameters is null || previousParameters is null)
            {
                return ExistsOverloadResolution.Unknown;
            }
            var invocations = string.Join(" ", calls.Select(arguments => $"Check({arguments});"));
            var source = $"namespace __ExistsCompatibilityProbe {{ internal class Probe {{ void Check({currentParameters}) {{ }} void Check({previousParameters}) {{ }} void Call() {{ {invocations} }} }} }}";
            var tree = CSharpSyntaxTree.ParseText(source);
            var model = compilation.AddSyntaxTrees(tree).GetSemanticModel(tree);
            var diagnostics = model.GetDiagnostics();
            if (diagnostics.Any(diagnostic => diagnostic.Id == "CS0121"))
            {
                return ExistsOverloadResolution.Ambiguous;
            }
            if (diagnostics.Any(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error))
            {
                return ExistsOverloadResolution.Unknown;
            }
            var root = tree.GetRoot();
            var currentMethod = model.GetDeclaredSymbol(root.DescendantNodes().OfType<MethodDeclarationSyntax>().First());
            foreach (var invocation in root.DescendantNodes().OfType<InvocationExpressionSyntax>())
            {
                var selected = model.GetSymbolInfo(invocation).Symbol;
                if (SymbolEqualityComparer.Default.Equals(currentMethod, selected))
                {
                    return ExistsOverloadResolution.CheckExistence;
                }
                if (selected is null)
                {
                    return ExistsOverloadResolution.Unknown;
                }
            }
            return ExistsOverloadResolution.Published;

            static string EscapeName(string name) => name.StartsWith('@') ? name : $"@{name}";
        }

        internal IEnumerable<ArrayResponseCollectionResultPlan> ArrayCollectionResultPlans =>
            _getAlls.Where(method => ArrayResponseCollectionResultPlan.IsArrayResponse(method.InputMethod))
                .Select(method => new ArrayResponseCollectionResultPlan(this, method.InputClient, method.InputMethod, "GetAll", "GetAllAsync"))
                .Concat(_actions.Where(method => ArrayResponseCollectionResultPlan.IsArrayResponse(method.InputMethod))
                    .Select(method => new ArrayResponseCollectionResultPlan(this, method.InputClient, method.InputMethod)));

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>();
            if (TryGetResourceIdValidationType(out var resourceType))
            {
                methods.Add(ResourceMethodSnippets.BuildValidateResourceIdMethod(this, resourceType));
            }

            methods.AddRange(BuildCreateOrUpdateMethods());
            methods.AddRange(BuildGetMethods());
            methods.AddRange(BuildGetAllMethods());
            methods.AddRange(BuildActionMethods());
            methods.AddRange(BuildExistsMethods());
            methods.AddRange(BuildGetIfExistsMethods());
            methods.AddRange(BuildEnumeratorMethods());

            return [.. methods];
        }

        private MethodProvider[] BuildActionMethods()
        {
            if (_actions.Count == 0)
            {
                return [];
            }

            var methods = new List<MethodProvider>(_actions.Count * 2);
            foreach (var action in _actions)
            {
                methods.Add(BuildActionMethod(action, true));
                methods.Add(BuildActionMethod(action, false));
            }

            return [.. methods];
        }

        private MethodProvider BuildActionMethod(ResourceMethod action, bool isAsync)
        {
            var restClientInfo = _clientInfos[action.InputClient];
            var parameterMappings = BuildParameterMapping(new RequestPathPattern(action.InputMethod.Operation.Path));
            return action.InputMethod switch
            {
                InputPagingServiceMethod pagingAction => new PageableOperationMethodProvider(this, parameterMappings, restClientInfo, pagingAction, isAsync, methodName: null, explicitResourceClient: _resource),
                _ => BuildNonPagingResourceMethod(action.InputMethod, parameterMappings, restClientInfo, ResourceOperationKind.CollectionAction, isAsync, methodName: null, explicitResourceClient: _resource)
            };
        }

        private MethodProvider[] BuildGetAllMethods()
        {
            if (_getAlls.Count == 0)
            {
                return [];
            }

            var methods = new List<MethodProvider>(_getAlls.Count * 2);
            for (int i = 0; i < _getAlls.Count; i++)
            {
                var listMethod = _getAlls[i];
                var sync = BuildGetAllMethod(listMethod, false);
                var async = BuildGetAllMethod(listMethod, true);

                if (i == 0)
                {
                    _getAllSyncMethodProvider = sync;
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
                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(_create.InputMethod.Operation, isAsync, this);
                var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Create, isAsync, true);
                result.Add(new ResourceOperationMethodProvider(this, BuildParameterMapping(new RequestPathPattern(_create.InputMethod.Operation.Path)), restClientInfo, _create.InputMethod, ResourceOperationKind.Create, isAsync, methodName: methodName, forceLro: true));
            }

            return result;
        }

        private MethodProvider BuildGetAllMethod(ResourceMethod getAll, bool isAsync)
        {
            var restClientInfo = _clientInfos[getAll.InputClient];
            var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.List, isAsync, true);
            var parameterMappings = BuildParameterMapping(new RequestPathPattern(getAll.InputMethod.Operation.Path));
            return getAll.InputMethod switch
            {
                InputPagingServiceMethod pagingGetAll => new PageableOperationMethodProvider(this, parameterMappings, restClientInfo, pagingGetAll, isAsync, methodName, _resource),
                _ => BuildNonPagingResourceMethod(getAll.InputMethod, parameterMappings, restClientInfo, ResourceOperationKind.List, isAsync, methodName, explicitResourceClient: _resource)
            };
        }

        private MethodProvider BuildNonPagingResourceMethod(InputServiceMethod method, ParameterContextRegistry parameterMappings, RestClientInfo clientInfo, ResourceOperationKind operationKind, bool isAsync, string? methodName, ResourceClientProvider? explicitResourceClient)
        {
            // Check if the response body type is a list - if so, wrap it in a single-page pageable.
            // Long-running operations are excluded: an LRO returning an array is surfaced as
            // ArmOperation<IReadOnlyList<T>> instead of a pageable.
            var responseBodyType = method.GetResponseBodyType();
            if (responseBodyType != null && responseBodyType.IsList && !method.IsLongRunningOperation())
            {
                return new ArrayResponseOperationMethodProvider(this, parameterMappings, clientInfo, method, isAsync, methodName, explicitResourceClient);
            }

            return new ResourceOperationMethodProvider(this, parameterMappings, clientInfo, method, operationKind, isAsync, methodName, explicitResourceClient: explicitResourceClient);
        }

        private MethodProvider? BuildGetMethod(bool isAsync)
        {
            if (_get is null)
            {
                return null;
            }

            var restClientInfo = _clientInfos[_get.InputClient];
            var methodName = ResourceHelpers.GetOperationMethodName(ResourceOperationKind.Read, isAsync, true);
            return new ResourceOperationMethodProvider(this, BuildParameterMapping(new RequestPathPattern(_get.InputMethod.Operation.Path)), restClientInfo, _get.InputMethod, ResourceOperationKind.Read, isAsync, methodName);
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
            var method = _checkExistence ?? _get;
            if (method is null)
            {
                return [];
            }

            var result = new List<MethodProvider>();
            var restClientInfo = _clientInfos[method.InputClient];
            var parameterMappings = BuildParameterMapping(new RequestPathPattern(method.InputMethod.Operation.Path));
            foreach (var isAsync in new List<bool> { true, false })
            {
                var existsMethodProvider = new ExistsOperationMethodProvider(this, parameterMappings, restClientInfo, method.InputMethod, method.Kind, isAsync);
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
            var parameterMappings = BuildParameterMapping(new RequestPathPattern(_get.InputMethod.Operation.Path));
            foreach (var isAsync in new List<bool> { true, false })
            {
                var getIfExistsMethodProvider = new GetIfExistsOperationMethodProvider(this, parameterMappings, restClientInfo, _get.InputMethod, isAsync);
                result.Add(getIfExistsMethodProvider);
            }

            return result;
        }
    }
}
