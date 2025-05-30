// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal sealed class MockableArmClientProvider : MockableResourceProvider
    {
        public MockableArmClientProvider(CSharpType armCoreType, IReadOnlyList<ResourceClientProvider> resources) : base(armCoreType, resources)
        {
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_resources.Count);
            foreach (var resource in _resources)
            {
                methods.Add(BuildGetResourceIdMethodForResource(resource));
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
                Static(resource.Type).Invoke(ResourceClientProvider.ValidateResourceIdMethodName, idParameter).Terminate(),
                Return(New.Instance(resource.Type,
                    [
                        This.As<ArmResource>().Client(),
                        idParameter
                    ]))
            };

            return new MethodProvider(signature, body, this);
        }
    }
}
