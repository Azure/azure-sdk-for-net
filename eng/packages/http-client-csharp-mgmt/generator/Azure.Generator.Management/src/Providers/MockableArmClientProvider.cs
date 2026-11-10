// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
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
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal sealed class MockableArmClientProvider : MockableResourceProvider
    {
        private MockableArmClientProvider(IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
            : base(typeof(ArmClient), OperationContext.Create(RequestPathPattern.Tenant), resources, resourceMethods, nonResourceMethods)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="MockableArmClientProvider"/> if there are resources or extension methods to generate methods for.
        /// </summary>
        /// <param name="resources">The resources to generate methods for.</param>
        /// <param name="resourceMethods">The resource methods to generate methods for.</param>
        /// <param name="nonResourceMethods">The non-resource methods to generate methods for.</param>
        /// <returns>A new instance of <see cref="MockableArmClientProvider"/> if there are resources or extension methods, otherwise null.</returns>
        public static MockableArmClientProvider? TryCreate(IReadOnlyList<ResourceClientProvider> resources, IReadOnlyDictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> resourceMethods, IReadOnlyList<NonResourceMethod> nonResourceMethods)
        {
            if (resources.Count == 0 && resourceMethods.Count == 0 && nonResourceMethods.Count == 0)
            {
                return null;
            }
            return new MockableArmClientProvider(resources, resourceMethods, nonResourceMethods);
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_resources.Count + _resourceMethods.Sum(kvp => kvp.Value.Count) * 2 + _nonResourceMethods.Count * 2);

            // Build methods for extension resources
            foreach (var resource in _resources)
            {
                methods.Add(BuildGetResourceIdMethodForResource(resource));
                if (resource.IsExtensionResource)
                {
                    if (resource.IsSingleton)
                    {
                        methods.AddRange(BuildMethodsForExtensionSingletonResource(resource));
                    }
                    else
                    {
                        methods.AddRange(BuildMethodsForExtensionNonSingletonResource(resource));
                    }
                }
            }

            // Build methods for extension-scoped resource operations.
            foreach (var (resource, resourceMethods) in _resourceMethods)
            {
                foreach (var resourceMethod in resourceMethods)
                {
                    var scopeParameter = new ParameterProvider(
                        "scope",
                        $"The scope that the resource will apply against.",
                        typeof(ResourceIdentifier),
                        wireInfo: new WireInformation(SerializationFormat.Default, string.Empty),
                        validation: ParameterValidationType.AssertNotNull);
                    var scopeContext = OperationContext.Create(resourceMethod.Scope.ScopeIdPattern);

                    methods.Add(BuildResourceServiceMethod(resource, resourceMethod, true, scopeContext, scopeParameter));
                    methods.Add(BuildResourceServiceMethod(resource, resourceMethod, false, scopeContext, scopeParameter));
                }
            }

            // Build methods for non-resource extension operations
            foreach (var method in _nonResourceMethods)
            {
                // For extension-scoped non-resource methods, create a synthetic scope parameter (ResourceIdentifier).
                // Pass an explicit WireInformation with an empty SerializedName so this synthetic parameter does not
                // collide with a real wire parameter named "scope" (e.g. an @query("scope")) when
                // ParameterContextRegistry.PopulateArguments matches arguments by WireInfo.SerializedName.
                // Note: the ParameterProvider constructor defaults WireInfo to one whose SerializedName equals the
                // parameter Name when wireInfo is null, so we must pass a non-null sentinel here. See issue #58484.
                var scopeParameter = new ParameterProvider(
                    "scope",
                    $"The scope that the resource will apply against.",
                    typeof(ResourceIdentifier),
                    wireInfo: new WireInformation(SerializationFormat.Default, string.Empty),
                    validation: ParameterValidationType.AssertNotNull);
                var scopeContext = OperationContext.Create(method.Scope.ScopeIdPattern);

                // Process both async and sync method variants, passing the scope parameter
                // so that PopulateArguments uses it instead of Id
                methods.Add(BuildServiceMethodWithContext(method.InputMethod, method.InputClient, scopeContext, true, scopeParameter: scopeParameter));
                methods.Add(BuildServiceMethodWithContext(method.InputMethod, method.InputClient, scopeContext, false, scopeParameter: scopeParameter));
            }

            return [.. methods];
        }

        private MethodProvider BuildGetResourceIdMethodForResource(ResourceClientProvider resource)
        {
            var idParameter = new ParameterProvider("id", $"The resource ID of the resource to get.", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                $"Get{resource.Name}",
                $"Gets an object representing a {resource.Type:C} along with the instance operations that can be performed on it but with no data.",
                //"\nYou can use <see cref=\"{resource.Name}.CreateResourceIdentifier\" /> to create a {resource.Type:C} {typeof(ResourceIdentifier):C} from its components.",
                // TODO -- we cannot include this method reference in cref because we do not have that method generated yet.
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                resource.Type,
                $"Returns a {resource.Type:C} object.",
                [idParameter]);

            var body = new List<MethodBodyStatement>();
            var pattern = resource.ResourceIdPattern;

            // A scope placeholder can span several segments, and malformed query-suffixed
            // routes can be misclassified as singletons. Do not treat either as a fixed path.
            var hasFixedPath = resource.SingletonResourceName is not null &&
                !resource.IsExtensionResource &&
                resource.ResourceType.All(segment => segment.IsConstant) &&
                pattern.SerializedPath.StartsWith('/') &&
                pattern.All(segment => !segment.IsConstant || segment.Value.IndexOfAny(['{', '}', '?', '#']) < 0);

            if (hasFixedPath)
            {
                body.Add(new IfStatement(idParameter.Equal(Null))
                {
                    Throw(New.Instance(typeof(ArgumentNullException), Nameof(idParameter)))
                });

                body.Add(Declare("segments", typeof(string[]), idParameter.Invoke("ToString").Invoke("Split", Literal('/')), out var segments));
                var invalid = idParameter.As<ResourceIdentifier>().ResourceType().NotEqual(Static(resource.Type).Property("ResourceType"))
                    .Or(segments.Property("Length").NotEqual(Literal(pattern.Count + 1)))
                    .Or(new IndexerExpression(segments, Literal(0)).NotEqual(Literal(string.Empty)));

                for (var index = 0; index < pattern.Count; index++)
                {
                    var segment = pattern[index];
                    var value = new IndexerExpression(segments, Literal(index + 1));
                    invalid = invalid.Or(segment.IsConstant
                        ? Not(StringSnippets.Equals(value.As<string>(), Literal(segment.Value).As<string>(), StringComparison.OrdinalIgnoreCase))
                        : value.Equal(Literal(string.Empty)));

                    // AzureLocation converts display names such as "East US" to "eastus".
                    // Reject IDs that would therefore target a different path than their Id.
                    if (!segment.IsConstant && resource.IsAzureLocationPathParameter(segment.VariableName))
                    {
                        var normalizedLocation = New.Instance(typeof(AzureLocation), value).Invoke(nameof(ToString));
                        invalid = invalid.Or(Not(StringSnippets.Equals(value.As<string>(), normalizedLocation.As<string>(), StringComparison.OrdinalIgnoreCase)));
                    }
                }

                body.Add(new IfStatement(invalid)
                {
                    Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid singleton resource ID {0} expected path {1}"), idParameter, Literal(pattern.SerializedPath)), wrapInNameOf: true))
                });
            }

            body.Add(Static(resource.Type).Invoke("ValidateResourceId", idParameter).Terminate());

            // Keep the existing name check for singleton extension resources and ambiguous
            // paths; an extension scope is not necessarily a single path segment.
            if (!hasFixedPath && resource.SingletonResourceName is { } singletonName && singletonName.IndexOfAny(['{', '}', '?', '#']) < 0)
            {
                var nameMatches = StringSnippets.Equals(
                    idParameter.Property(nameof(ResourceIdentifier.Name)).As<string>(),
                    Literal(singletonName).As<string>(),
                    StringComparison.OrdinalIgnoreCase);
                body.Add(new IfStatement(
                    idParameter.NotEqual(Null)
                        .And(idParameter.As<ResourceIdentifier>().ResourceType().Equal(Static(resource.Type).Property("ResourceType")))
                        .And(Not(nameMatches)))
                {
                    Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid singleton resource name {0} expected {1}"), idParameter.Property(nameof(ResourceIdentifier.Name)), Literal(singletonName)), wrapInNameOf: true))
                });
            }

            body.Add(Return(New.Instance(resource.Type,
                [
                    This.As<ArmResource>().Client(),
                    idParameter
                ])));

            return new MethodProvider(signature, body, this);
        }

        private IList<MethodProvider> BuildMethodsForExtensionNonSingletonResource(ResourceClientProvider resource)
        {
            var result = new List<MethodProvider>();
            var scopeParameter = new ParameterProvider("scope", $"The scope of the resource collection to get.", typeof(ResourceIdentifier));
            var extraParameters = resource.FactoryMethodSignature.Parameters;
            var signature = new MethodSignature(
                $"{resource.FactoryMethodSignature.Name}",
                $"Gets a collection of {resource.ResourceCollection!.Type:C} objects within the specified scope.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                resource.ResourceCollection!.Type,
                $"Returns a collection of {resource.Type:C} objects.",
                [scopeParameter, .. extraParameters]);
            var body = new MethodBodyStatement[]
            {
                Return(New.Instance(resource.ResourceCollection!.Type,
                    [
                        This.As<ArmResource>().Client(),
                        scopeParameter,
                        .. extraParameters
                    ]))
            };
            result.Add(new MethodProvider(signature, body, this));

            var collection = resource.ResourceCollection!;
            var getMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "Get");
            var getAsyncMethod = collection.Methods.FirstOrDefault(m => m.Signature.Name == "GetAsync");
            if (getMethod is not null)
            {
                result.Add(BuildGetMethod(this, getMethod, signature, $"Get{resource.ResourceName}"));
            }
            if (getAsyncMethod is not null)
            {
                result.Add(BuildGetMethod(this, getAsyncMethod, signature, $"Get{resource.ResourceName}Async"));
            }

            return result;

            static MethodProvider BuildGetMethod(TypeProvider enclosingType, MethodProvider resourceGetMethod, MethodSignature collectionGetSignature, string methodName)
            {
                var parameters = new List<ParameterProvider>(resourceGetMethod.Signature.Parameters);
                var insertIndex = 0;
                foreach (var p in collectionGetSignature.Parameters)
                {
                    if (!parameters.Any(existing => existing.Name == p.Name))
                    {
                        parameters.Insert(insertIndex, p);
                        insertIndex++;
                    }
                }

                var signature = new MethodSignature(
                    methodName,
                    resourceGetMethod.Signature.Description,
                    resourceGetMethod.Signature.Modifiers,
                    resourceGetMethod.Signature.ReturnType,
                    resourceGetMethod.Signature.ReturnDescription,
                    parameters,
                    Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);

                return new MethodProvider(
                    signature,
                    Return(This.Invoke(collectionGetSignature).Invoke(resourceGetMethod.Signature)),
                    enclosingType);
            }
        }

        private IList<MethodProvider> BuildMethodsForExtensionSingletonResource(ResourceClientProvider resource)
        {
            var result = new List<MethodProvider>();

            var scopeParameter = new ParameterProvider("scope", $"The scope that the resource will apply against.", typeof(ResourceIdentifier));
            var extraParameters = resource.FactoryMethodSignature.Parameters;
            var signature = new MethodSignature(
                $"{resource.FactoryMethodSignature.Name}",
                $"Gets an object representing a {resource.Type:C} along with the instance operations that can be performed on it in the ArmClient",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                resource.Type,
                $"Returns a {resource.Type:C} object.",
                [scopeParameter, .. extraParameters]);

            var body = new MethodBodyStatement[]
            {
                Return(New.Instance(resource.Type,
                    [
                        This.As<ArmResource>().Client(),
                        MockableResourceProvider.BuildSingletonResourceIdentifier(scopeParameter.As<ResourceIdentifier>(), resource.ResourceTypeValue, resource.SingletonResourceName!)
                    ]))
            };

            var getByScopeMethod = new MethodProvider(signature, body, this);
            result.Add(getByScopeMethod);

            return result;
        }
    }
}
