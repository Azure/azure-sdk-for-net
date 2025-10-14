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

        private readonly RequestPathPattern _contextualPath;

        /// <summary>
        /// Creates a new instance of the <see cref="MockableResourceProvider"/> class.
        /// </summary>
        /// <param name="resourceScope">the scope of this mockable resource.</param>
        /// <param name="resources">the resources in this scope.</param>
        /// <param name="resourceMethods">the resource methods that belong to this scope.</param>
        /// <param name="nonResourceMethods">the non-resource methods that belong to this scope.</param>
        public MockableResourceProvider(ResourceScope resourceScope, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
            : this(ResourceHelpers.GetArmCoreTypeFromScope(resourceScope), RequestPathPattern.GetFromScope(resourceScope), resources, resourceMethods, nonResourceMethods)
        {
        }

        private protected MockableResourceProvider(CSharpType armCoreType, RequestPathPattern contextualPath, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
        {
            _resources = resources;
            _resourceMethods = resourceMethods;
            _nonResourceMethods = nonResourceMethods;
            ArmCoreType = armCoreType;
            _contextualPath = contextualPath;
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
                var methodsToProcess = new[] {
                    BuildServiceMethod(method.InputMethod, method.InputClient, true),
                    BuildServiceMethod(method.InputMethod, method.InputClient, false)
                };
                foreach (var m in methodsToProcess)
                {
                    methods.Add(m);
                    var updated = false;
                    foreach (var p in m.Signature.Parameters)
                    {
                        if (p.Location == ParameterLocation.Body)
                        {
                            p.Update(name: "content");
                            updated = true;
                        }
                    }
                    if (updated)
                    {
                        m.Update(signature: m.Signature);
                    }
                }
            }

            return [.. methods];
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
                yield return new MethodProvider(
                    resourceMethodSignature,
                    bodyStatement,
                    this);
            }
            else
            {
                // the first method is returning the collection
                var collection = resource.ResourceCollection!;
                var collectionMethodSignature = resource.FactoryMethodSignature;
                var pathParameters = collection.PathParameters;
                collectionMethodSignature.Update(parameters: [.. collectionMethodSignature.Parameters, .. pathParameters]);

                var bodyStatement = Return(This.As<ArmResource>().GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(collection.Type, [client, This.As<ArmResource>().Id(), .. pathParameters])));
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
                    yield return BuildGetMethod(this, getAsyncMethod, collectionMethodSignature, pathParameters, $"Get{resource.ResourceName}Async");
                }

                if (getMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getMethod, collectionMethodSignature, pathParameters, $"Get{resource.ResourceName}");
                }

                static MethodProvider BuildGetMethod(TypeProvider enclosingType, MethodProvider resourceGetMethod, MethodSignature collectionGetSignature, IReadOnlyList<ParameterProvider> pathParameters, string methodName)
                {
                    var signature = new MethodSignature(
                        methodName,
                        resourceGetMethod.Signature.Description,
                        resourceGetMethod.Signature.Modifiers,
                        resourceGetMethod.Signature.ReturnType,
                        resourceGetMethod.Signature.ReturnDescription,
                        [.. pathParameters, .. resourceGetMethod.Signature.Parameters],
                        Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);

                    return new MethodProvider(
                        signature,
                        // invoke on a MethodSignature would handle the async extra calls and keyword automatically
                        Return(This.Invoke(collectionGetSignature).Invoke(resourceGetMethod.Signature)),
                        enclosingType);
                }
            }
        }

        private MethodProvider BuildResourceServiceMethod(ResourceClientProvider resource, ResourceMethod resourceMethod, bool isAsync)
        {
            var methodName = ResourceHelpers.GetExtensionOperationMethodName(resourceMethod.Kind, resource.ResourceName, isAsync);
            return BuildServiceMethod(resourceMethod.InputMethod, resourceMethod.InputClient, isAsync, methodName);
        }

        private MethodProvider BuildServiceMethod(InputServiceMethod method, InputClient inputClient, bool isAsync, string? methodName = null)
        {
            var clientInfo = _clientInfos[inputClient];
            return method switch
            {
                InputPagingServiceMethod pagingMethod => new PageableOperationMethodProvider(this, _contextualPath, clientInfo, pagingMethod, isAsync, methodName),
                _ => new ResourceOperationMethodProvider(this, _contextualPath, clientInfo, method, isAsync, methodName)
            };
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
