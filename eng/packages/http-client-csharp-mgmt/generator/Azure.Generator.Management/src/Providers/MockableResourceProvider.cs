﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Humanizer;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class MockableResourceProvider : TypeProvider
    {
        private protected readonly IReadOnlyList<ResourceClientProvider> _resources;
        private protected readonly IReadOnlyList<NonResourceMethod> _methods;
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        private readonly RequestPathPattern _contextualPath;

        public MockableResourceProvider(ResourceScope resourceScope, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyList<NonResourceMethod> nonResourceMethods)
            : this(ResourceHelpers.GetArmCoreTypeFromScope(resourceScope), RequestPathPattern.GetFromScope(resourceScope), resources, nonResourceMethods)
        {
        }

        private protected MockableResourceProvider(CSharpType armCoreType, RequestPathPattern contextualPath, IReadOnlyList<ResourceClientProvider> resources, IReadOnlyList<NonResourceMethod> methods)
        {
            _resources = resources;
            _methods = methods;
            ArmCoreType = armCoreType;
            _contextualPath = contextualPath;
            _clientInfos = BuildRestClientInfos(methods, this);
        }

        private static Dictionary<InputClient, RestClientInfo> BuildRestClientInfos(IReadOnlyList<NonResourceMethod> methods, TypeProvider enclosingType)
        {
            var clientInfos = new Dictionary<InputClient, RestClientInfo>();
            foreach (var method in methods)
            {
                var inputClient = method.InputClient;
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
            var methods = new List<MethodProvider>(_resources.Count * 3);
            foreach (var resource in _resources)
            {
                methods.AddRange(BuildMethodsForResource(resource));
            }

            foreach (var method in _methods)
            {
                // add the method provider one by one.
                methods.Add(BuildNonResourceMethod(method, false));
                methods.Add(BuildNonResourceMethod(method, true));
            }

            return [.. methods];
        }

        private IEnumerable<MethodProvider> BuildMethodsForResource(ResourceClientProvider resource)
        {
            if (resource.IsSingleton)
            {
                var resourceMethodSignature = new MethodSignature(
                    $"Get{resource.ResourceName}",
                    $"Gets an object representing a {resource.Type:C} along with the instance operations that can be performed on it in the {ArmCoreType:C}.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    resource.Type,
                    $"Returns a {resource.Type:C} object.",
                    []
                    );
                var bodyStatement = Return(
                    New.Instance(
                        resource.Type,
                        This.As<ArmResource>().Client(),
                        BuildSingletonResourceIdentifier(resource.ResourceTypeValue, resource.SingletonResourceName!)));
                yield return new MethodProvider(
                    resourceMethodSignature,
                    bodyStatement,
                    this);
            }
            else
            {
                var collection = resource.ResourceCollection!;
                // the first method is returning the collection
                var pluralOfResourceName = resource.ResourceName.Pluralize();
                var collectionMethodSignature = new MethodSignature(
                    $"Get{pluralOfResourceName}",
                    $"Gets a collection of {pluralOfResourceName} in the {ArmCoreType:C}",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    collection.Type,
                    $"An object representing collection of {pluralOfResourceName} and their operations over a {resource.Name}.",
                    []
                    );

                var bodyStatement = Return(This.As<ArmResource>().GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(collection.Type, client, This.As<ArmResource>().Id())));
                yield return new MethodProvider(
                    collectionMethodSignature,
                    bodyStatement,
                    this);
                // the second and third methods are the sync and async version of the Get method on the collection
                // find the method
                var getMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "Get");
                var getAsyncMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "GetAsync");
                if (getMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getMethod, collectionMethodSignature, $"Get{resource.ResourceName}");
                }

                if (getAsyncMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getAsyncMethod, collectionMethodSignature, $"Get{resource.ResourceName}Async");
                }

                static MethodProvider BuildGetMethod(TypeProvider enclosingType, MethodProvider resourceGetMethod, MethodSignature collectionGetSignature, string methodName)
                {
                    var signature = new MethodSignature(
                        methodName,
                        resourceGetMethod.Signature.Description,
                        resourceGetMethod.Signature.Modifiers,
                        resourceGetMethod.Signature.ReturnType,
                        resourceGetMethod.Signature.ReturnDescription,
                        resourceGetMethod.Signature.Parameters,
                        Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);

                    return new MethodProvider(
                        signature,
                        // invoke on a MethodSignature would handle the async extra calls and keyword automatically
                        Return(This.Invoke(collectionGetSignature).Invoke(resourceGetMethod.Signature)),
                        enclosingType);
                }
            }
        }

        private MethodProvider BuildNonResourceMethod(NonResourceMethod method, bool isAsync)
        {
            var clientInfo = _clientInfos[method.InputClient];
            return method.InputMethod switch
            {
                InputPagingServiceMethod pagingMethod => new PageableOperationMethodProvider(this, _contextualPath, clientInfo, pagingMethod, isAsync),
                _ => new ResourceOperationMethodProvider(this, _contextualPath, clientInfo, method.InputMethod, isAsync)
            };
        }

        private static ValueExpression BuildSingletonResourceIdentifier(string resourceType, string resourceName)
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
            return This.As<ArmResource>().Id().AppendProviderResource(Literal(segments[0]), Literal(segments[1]), Literal(resourceName));
        }
    }
}
