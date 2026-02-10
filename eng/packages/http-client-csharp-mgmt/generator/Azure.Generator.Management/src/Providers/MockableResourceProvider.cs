// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class MockableResourceProvider : TypeProvider
    {
        private protected readonly IReadOnlyList<ResourceClientProvider> _resources;
        private protected readonly IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> _resourceMethods;
        private protected readonly IReadOnlyList<NonResourceMethod> _nonResourceMethods;
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        private readonly OperationContext _operationContext;

        /// <summary>
        /// Creates a new instance of the <see cref="MockableResourceProvider"/> class.
        /// </summary>
        /// <param name="resourceScope">the scope of this mockable resource.</param>
        /// <param name="resources">the resources in this scope.</param>
        /// <param name="resourceMethods">the resource methods that belong to this scope.</param>
        /// <param name="nonResourceMethods">the non-resource methods that belong to this scope.</param>
        private MockableResourceProvider(ResourceScope resourceScope, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
            : this(ResourceHelpers.GetArmCoreTypeFromScope(resourceScope), OperationContext.Create(RequestPathPattern.GetFromScope(resourceScope)), resources, resourceMethods, nonResourceMethods)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="MockableResourceProvider"/> if there are resources or methods to generate.
        /// </summary>
        /// <param name="resourceScope">The scope of this mockable resource.</param>
        /// <param name="resources">The resources in this scope.</param>
        /// <param name="resourceMethods">The resource methods that belong to this scope.</param>
        /// <param name="nonResourceMethods">The non-resource methods that belong to this scope.</param>
        /// <returns>A new instance of <see cref="MockableResourceProvider"/> if there are resources or methods, otherwise null.</returns>
        public static MockableResourceProvider? TryCreate(ResourceScope resourceScope, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
        {
            if (resources.Count == 0 && resourceMethods.Count == 0 && nonResourceMethods.Count == 0)
            {
                return null;
            }
            return new MockableResourceProvider(resourceScope, resources, resourceMethods, nonResourceMethods);
        }

        private protected MockableResourceProvider(CSharpType armCoreType, OperationContext operationContext, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
        {
            _resources = resources;
            _resourceMethods = resourceMethods;
            _nonResourceMethods = nonResourceMethods;
            ArmCoreType = armCoreType;
            _operationContext = operationContext;
            _clientInfos = BuildRestClientInfos(resourceMethods.Values.SelectMany(m => m).Select(m => m.InputClient).Concat(nonResourceMethods.Select(m => m.InputClient)), this);
        }

        private static Dictionary<InputClient, RestClientInfo> BuildRestClientInfos(
            IEnumerable<InputClient> inputClients,
            TypeProvider enclosingType)
        {
            var clientInfos = new Dictionary<InputClient, RestClientInfo>();
            foreach (var inputClient in inputClients)
            {
                if (clientInfos.ContainsKey(inputClient))
                {
                    continue;
                }

                var thisResource = This.As<ArmResource>();
                var restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

                var clientDiagnosticsField = new FieldProvider(
                    FieldModifiers.Private,
                    typeof(ClientDiagnostics),
                    ResourceHelpers.GetClientDiagnosticsFieldName(restClientProvider.Name),
                    enclosingType);
                var clientDiagnosticsProperty = new PropertyProvider(
                    null,
                    MethodSignatureModifiers.Private,
                    typeof(ClientDiagnostics),
                    ResourceHelpers.GetClientDiagnosticsPropertyName(restClientProvider.Name),
                    new ExpressionPropertyBody(
                        clientDiagnosticsField.Assign(
                            New.Instance(typeof(ClientDiagnostics), Literal(enclosingType.Type.Namespace), ProviderConstantsProvider.DefaultProviderNamespace, thisResource.Diagnostics()),
                            nullCoalesce: true)),
                    enclosingType);

                var restClientField = new FieldProvider(
                    FieldModifiers.Private,
                    restClientProvider.Type,
                    ResourceHelpers.GetRestClientFieldName(restClientProvider.Name),
                    enclosingType);
                var restClientProperty = new PropertyProvider(
                    null,
                    MethodSignatureModifiers.Private,
                    restClientProvider.Type,
                    ResourceHelpers.GetRestClientPropertyName(restClientProvider.Name),
                    new ExpressionPropertyBody(
                        restClientField.Assign(
                            New.Instance(restClientProvider.Type, clientDiagnosticsProperty, thisResource.Pipeline(), thisResource.Endpoint(), Literal(ManagementClientGenerator.Instance.InputLibrary.DefaultApiVersion)),
                            nullCoalesce: true)),
                    enclosingType);

                clientInfos.Add(inputClient, new RestClientInfo(restClientProvider, restClientField, restClientProperty, clientDiagnosticsField, clientDiagnosticsProperty));
            }
            return clientInfos;
        }

        internal CSharpType ArmCoreType { get; }

        protected override string BuildNamespace() => $"{base.BuildNamespace()}.Mocking";

        protected override string BuildName() => $"Mockable{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{ArmCoreType.Name}";

        protected override FormattableString BuildDescription() => $"A class to add extension methods to {ArmCoreType:C}.";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

        protected override CSharpType? BuildBaseType() => typeof(ArmResource);

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

            return new ConstructorProvider(signature, MethodBodyStatement.Empty, this);
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>(_clientInfos.Count * 2);
            foreach (var clientInfo in _clientInfos.Values)
            {
                // add the client diagnostics field
                fields.Add(clientInfo.DiagnosticsField);
                // add the rest client field
                fields.Add(clientInfo.RestClientField);
            }

            return [.. fields];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>(_clientInfos.Count * 2);
            foreach (var clientInfo in _clientInfos.Values)
            {
                if (clientInfo.DiagnosticProperty is not null)
                {
                    // add the client diagnostics property
                    properties.Add(clientInfo.DiagnosticProperty);
                }
                if (clientInfo.RestClientProperty is not null)
                {
                    // add the rest client property
                    properties.Add(clientInfo.RestClientProperty);
                }
            }

            return [.. properties];
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_resources.Count * 3 + _resourceMethods.Count * 2 + _nonResourceMethods.Count * 2);
            foreach (var resource in _resources)
            {
                methods.AddRange(BuildMethodsForResource(resource));
            }

            foreach (var (resource, resourceMethods) in _resourceMethods)
            {
                foreach (var resourceMethod in resourceMethods)
                {
                    methods.Add(BuildResourceServiceMethod(resource, resourceMethod, true));
                    methods.Add(BuildResourceServiceMethod(resource, resourceMethod, false));
                }
            }

            foreach (var method in _nonResourceMethods)
            {
                // Process both async and sync method variants
                // Pass the input client name to generate unique method names when multiple non-resource methods
                // target different parent resource types (e.g., GetAll on VM vs HCRP vs VMSS assignments)
                var methodName = GetNonResourceMethodName(method, true);
                methods.Add(BuildServiceMethod(method.InputMethod, method.InputClient, true, methodName));
                methodName = GetNonResourceMethodName(method, false);
                methods.Add(BuildServiceMethod(method.InputMethod, method.InputClient, false, methodName));
            }

            return [.. methods];
        }

        /// <summary>
        /// Gets a unique method name for a non-resource method by incorporating the parent resource type
        /// from the operation path. This avoids duplicate method signatures when multiple extension
        /// resources target different parent types (e.g., VM vs HCRP vs VMSS).
        /// </summary>
        /// <param name="method">The non-resource method.</param>
        /// <param name="isAsync">Whether this is an async method.</param>
        /// <returns>The unique method name with discriminator, or null if no disambiguation is needed.</returns>
        private string? GetNonResourceMethodName(NonResourceMethod method, bool isAsync)
        {
            var clientName = method.InputClient.Name;
            var operationPath = new RequestPathPattern(method.InputMethod.Operation.Path);

            // Extract a discriminator from the path
            var discriminator = ExtractResourceTypeDiscriminator(clientName, operationPath);

            // If we found a discriminator, always use it (safer approach)
            if (!string.IsNullOrEmpty(discriminator))
            {
                // Get the rest client info for this method
                var clientInfo = _clientInfos[method.InputClient];

                // Get the base method name from the convenience method
                var convenienceMethod = clientInfo.RestClientProvider
                    .GetConvenienceMethodByOperation(method.InputMethod.Operation, isAsync);
                var baseMethodName = convenienceMethod.Signature.Name;

                // Build the disambiguated method name
                // e.g., "GetAll" + "Vm" -> "GetAllVm" / "GetAllVmAsync"
                var suffix = isAsync ? "Async" : string.Empty;
                var baseName = baseMethodName.EndsWith("Async") ? baseMethodName[..^5] : baseMethodName;

                return $"{baseName}{discriminator}{suffix}";
            }

            return null;
        }

        /// <summary>
        /// Extracts a resource type discriminator from the operation path.
        /// </summary>
        private static string ExtractResourceTypeDiscriminator(string clientName, RequestPathPattern operationPath)
        {
            // Try to extract the parent resource type from the operation path
            // The path pattern for extension resources typically looks like:
            // /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/...
            // /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/...

            // Count the number of providers segments - extension resources have at least 2
            int providerCount = 0;
            for (int i = 0; i < operationPath.Count; i++)
            {
                if (operationPath[i].IsProvidersSegment)
                    providerCount++;
            }

            // Only apply disambiguation for extension resources (paths with multiple provider segments)
            if (providerCount < 2)
                return string.Empty;

            // Find the first (parent) provider segment to identify the target resource type
            for (int i = 0; i < operationPath.Count - 1; i++)
            {
                if (operationPath[i].IsProvidersSegment && i + 2 < operationPath.Count)
                {
                    var providerNamespace = operationPath[i + 1];
                    var resourceTypeSegment = operationPath[i + 2];

                    // Skip if this is not a constant segment (e.g., {scope})
                    if (!providerNamespace.IsConstant || !resourceTypeSegment.IsConstant)
                        continue;

                    var namespaceValue = providerNamespace.Value;
                    var resourceType = resourceTypeSegment.Value;

                    // Check if the next segment is a variable (indicating this is a parent resource)
                    if (i + 3 < operationPath.Count && !operationPath[i + 3].IsConstant)
                    {
                        // Build the full parent resource type and use the shared helper
                        var parentResourceType = $"{namespaceValue}/{resourceType}";
                        return ResourceHelpers.GetParentTypeDiscriminator(parentResourceType);
                    }
                }
            }

            return string.Empty;
        }

        private IEnumerable<MethodProvider> BuildMethodsForResource(ResourceClientProvider resource)
        {
            if (resource.IsSingleton)
            {
                var resourceMethodSignature = resource.FactoryMethodSignature;
                var bodyStatement = Return(
                    New.Instance(
                        resource.Type,
                        This.As<ArmResource>().Client(),
                        BuildSingletonResourceIdentifier(This.As<ArmResource>().Id(), resource.ResourceTypeValue, resource.SingletonResourceName!)));
                var method = new MethodProvider(
                    resourceMethodSignature,
                    bodyStatement,
                    this);

                // Copy the enhanced XML documentation from the singleton resource's Get method if available
                var getMethod = resource.Methods.FirstOrDefault(m => m.Signature.Name == "Get");
                if (getMethod?.XmlDocs?.Summary != null)
                {
                    method.XmlDocs?.Update(summary: getMethod.XmlDocs.Summary);
                }

                yield return method;
            }
            else
            {
                // the first method is returning the collection
                var collection = resource.ResourceCollection!;
                var collectionMethodSignature = resource.FactoryMethodSignature;

                var bodyStatement = Return(This.As<ArmResource>().GetCachedClient(new CodeWriterDeclaration("client"),
                    client => New.Instance(collection.Type,
                        [client, This.As<ArmResource>().Id(), .. collectionMethodSignature.Parameters]))); // the first two parameters have values, others we just pass through them.
                yield return new MethodProvider(
                    collectionMethodSignature,
                    bodyStatement,
                    this);
                // the second and third methods are the sync and async version of the Get method on the collection
                // find the method
                var getMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "Get");
                var getAsyncMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "GetAsync");
                if (getAsyncMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getAsyncMethod, collectionMethodSignature, $"Get{resource.ResourceName}Async");
                }

                if (getMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getMethod, collectionMethodSignature, $"Get{resource.ResourceName}");
                }

                static MethodProvider BuildGetMethod(TypeProvider enclosingType, MethodProvider resourceGetMethod, MethodSignature collectionGetSignature, string methodName)
                {
                    var signature = new MethodSignature(
                        methodName,
                        resourceGetMethod.Signature.Description,
                        resourceGetMethod.Signature.Modifiers,
                        resourceGetMethod.Signature.ReturnType,
                        resourceGetMethod.Signature.ReturnDescription,
                        [.. collectionGetSignature.Parameters, .. resourceGetMethod.Signature.Parameters],
                        Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);

                    var method = new MethodProvider(
                        signature,
                        // invoke on a MethodSignature would handle the async extra calls and keyword automatically
                        Return(This.Invoke(collectionGetSignature).Invoke(resourceGetMethod.Signature)),
                        enclosingType);

                    // Copy the enhanced XML documentation from the collection's Get method
                    if (resourceGetMethod.XmlDocs?.Summary != null)
                    {
                        method.XmlDocs?.Update(summary: resourceGetMethod.XmlDocs.Summary);
                    }

                    return method;
                }
            }
        }

        private MethodProvider BuildResourceServiceMethod(ResourceClientProvider resource, ResourceMethod resourceMethod, bool isAsync)
        {
            // Use parent resource type for disambiguation when available (for specific extension resources)
            var methodName = resourceMethod.ParentResourceType != null
                ? ResourceHelpers.GetExtensionOperationMethodNameWithParentType(resourceMethod.Kind, resource.ResourceName, resourceMethod.ParentResourceType, isAsync)
                : ResourceHelpers.GetExtensionOperationMethodName(resourceMethod.Kind, resource.ResourceName, isAsync);

            // Only fall back to the raw SDK method name when no standard name was generated.
            // This handles non-CRUD operations (e.g., GetReports, GetReport) that don't map to
            // standard CRUD method naming patterns.
            if (methodName == null)
            {
                var baseName = resourceMethod.InputMethod.Name;
                methodName = isAsync ? $"{baseName}Async" : baseName;
            }

            return BuildServiceMethod(resourceMethod.InputMethod, resourceMethod.InputClient, isAsync, methodName);
        }

        protected MethodProvider BuildServiceMethod(InputServiceMethod method, InputClient inputClient, bool isAsync, string? methodName = null)
        {
            var clientInfo = _clientInfos[inputClient];
            return method switch
            {
                InputPagingServiceMethod pagingMethod => new PageableOperationMethodProvider(this, _operationContext, clientInfo, pagingMethod, isAsync, methodName),
                _ => BuildNonPagingServiceMethod(method, clientInfo, isAsync, methodName)
            };
        }

        private MethodProvider BuildNonPagingServiceMethod(InputServiceMethod method, RestClientInfo clientInfo, bool isAsync, string? methodName)
        {
            // Check if the response body type is a list - if so, wrap it in a single-page pageable
            var responseBodyType = method.GetResponseBodyType();
            if (responseBodyType != null && responseBodyType.IsList)
            {
                return new ArrayResponseOperationMethodProvider(this, _operationContext, clientInfo, method, isAsync, methodName);
            }

            return new ResourceOperationMethodProvider(this, _operationContext, clientInfo, method, isAsync, methodName);
        }

        public static ValueExpression BuildSingletonResourceIdentifier(ScopedApi<ResourceIdentifier> resourceId, string resourceType, string resourceName)
        {
            var segments = resourceType.Split('/');
            if (segments.Length < 2)
            {
                ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "general-error",
                    $"ResourceType {resourceType} is malformed.");
                return Null.CastTo(typeof(ResourceIdentifier));
            }
            if (segments.Length > 3)
            {
                // TODO -- for single resource which is not a direct child of this extension, we did not really implement it yet.
                // Leave this here for future refinement.
                ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "general-warning",
                    $"Tuple singleton resource type is not implemented yet.");
                return Null.CastTo(typeof(ResourceIdentifier));
            }
            return resourceId.AppendProviderResource(Literal(segments[0]), Literal(segments[1]), Literal(resourceName));
        }
    }
}
