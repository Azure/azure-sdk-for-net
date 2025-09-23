// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Snippets;
using Azure.ResourceManager;
using Humanizer;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal sealed class MockableArmClientProvider : MockableResourceProvider
    {
        // TODO -- we also need to put operations here when we want to support scope resources/operations https://github.com/Azure/azure-sdk-for-net/issues/51821
        public MockableArmClientProvider(IReadOnlyList<ResourceClientProvider> resources)
            : base(typeof(ArmClient), RequestPathPattern.Tenant, resources, new Dictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>>(), [])
        {
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_resources.Count);
            foreach (var resource in _resources)
            {
                methods.Add(BuildGetResourceIdMethodForResource(resource));
                if (resource.IsExtensionResource)
                {
                    if (!resource.IsSingleton)
                    {
                        methods.AddRange(BuildMethodsForExtensionNoneSingletonResource(resource));
                    }
                    else
                    {
                        methods.AddRange(BuildMethodsForExtensionSingletonResource(resource));
                    }
                }
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

            var body = new MethodBodyStatement[]
            {
                Static(resource.Type).Invoke("ValidateResourceId", idParameter).Terminate(),
                Return(New.Instance(resource.Type,
                    [
                        This.As<ArmResource>().Client(),
                        idParameter
                    ]))
            };

            return new MethodProvider(signature, body, this);
        }

        private IList<MethodProvider> BuildMethodsForExtensionNoneSingletonResource(ResourceClientProvider resource)
        {
            var result = new List<MethodProvider>();
            var scopeParameter = new ParameterProvider("scope", $"The scope of the resource collection to get.", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                $"{resource.FactoryMethodSignature.Name}",
                $"Gets a collection of {resource.ResourceCollection!.Type:C} objects within the specified scope.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                resource.ResourceCollection!.Type,
                $"Returns a collection of {resource.Type:C} objects.",
                [scopeParameter]);
            var body = new MethodBodyStatement[]
            {
                Return(New.Instance(resource.ResourceCollection!.Type,
                    [
                        This.As<ArmResource>().Client(),
                        scopeParameter
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
            var signature = new MethodSignature(
                $"{resource.FactoryMethodSignature.Name}",
                $"Gets an object representing a {resource.Type:C} along with the instance operations that can be performed on it in the ArmClient",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                resource.Type,
                $"Returns a {resource.Type:C} object.",
                [scopeParameter]);

            var body = new MethodBodyStatement[]
            {
                Return(New.Instance(resource.Type,
                    [
                        This.As<ArmResource>().Client(),
                        BuildSingletonResourceIdentifier(scopeParameter.As<ResourceIdentifier>(), resource.ResourceTypeValue, resource.SingletonResourceName!)
                    ]))
            };

            var getByScopeMethod = new MethodProvider(signature, body, this);
            result.Add(getByScopeMethod);

            // Build methods for singleton extension resources
            return result;
        }
    }
}
