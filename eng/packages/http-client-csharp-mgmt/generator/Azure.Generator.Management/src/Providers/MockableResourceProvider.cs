// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Humanizer;
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

        // TODO -- in the future we need to update this to include the operations this mockable resource should include.
        public MockableResourceProvider(CSharpType armCoreType, IReadOnlyList<ResourceClientProvider> resources)
        {
            ArmCoreType = armCoreType;
            _resources = resources;
        }
        internal CSharpType ArmCoreType { get; }

        protected override string BuildName() => $"Mockable{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{ArmCoreType.Name}";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

        protected override CSharpType? GetBaseType() => typeof(ArmResource);

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildResourceIdentifierConstructor()];

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

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>(_resources.Count * 3);
            foreach (var resource in _resources)
            {
                methods.AddRange(BuildMethodsForResource(resource));
            }
            return [.. methods];
        }

        private IEnumerable<MethodProvider> BuildMethodsForResource(ResourceClientProvider resource)
        {
            if (resource.IsSingleton)
            {
                // TODO -- not implemented yet.
                yield break;
            }
            else
            {
                var collection = resource.ResourceCollection!;
                // the first method is returning the collection
                var pluralOfResourceName = resource.SpecName.Pluralize();
                var collectionMethodSignature = new MethodSignature(
                    $"Get{pluralOfResourceName}",
                    $"Gets a collection of {pluralOfResourceName} in the {ArmCoreType:C}",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    collection.Type,
                    $"An object representing collection of {pluralOfResourceName} and their operations over a {resource.Name}.",
                    []
                    );

                var bodyStatement = new MethodBodyStatement[]
                {
                    Return(This.As<ArmResource>().GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(collection.Type, client, This.As<ArmResource>().Id())))
                };
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
                    var getResourceMethodSignature = new MethodSignature(
                        $"Get{collection.SpecName}",
                        getMethod.Signature.Description,
                        getMethod.Signature.Modifiers,
                        getMethod.Signature.ReturnType,
                        getMethod.Signature.ReturnDescription,
                        getMethod.Signature.Parameters);
                    // TODO -- we need to add the ForwardsClientCallsAttribute attribute when the hook to add more shared source is available
                    // Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);

                    yield return new MethodProvider(
                        getResourceMethodSignature,
                        new MethodBodyStatement[]
                        {
                            Return(This.Invoke(collectionMethodSignature).Invoke(getMethod.Signature))
                        },
                        this);
                }

                if (getAsyncMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    var getResourceAsyncMethodSignature = new MethodSignature(
                        $"Get{collection.SpecName}Async",
                        getAsyncMethod.Signature.Description,
                        getAsyncMethod.Signature.Modifiers,
                        getAsyncMethod.Signature.ReturnType,
                        getAsyncMethod.Signature.ReturnDescription,
                        getAsyncMethod.Signature.Parameters);
                    // TODO -- we need to add the ForwardsClientCallsAttribute attribute when the hook to add more shared source is available
                    // Attributes: [new AttributeStatement(typeof(ForwardsClientCallsAttribute))]);
                    yield return new MethodProvider(
                        getResourceAsyncMethodSignature,
                        new MethodBodyStatement[]
                        {
                            Return(This.Invoke(collectionMethodSignature).Invoke(getAsyncMethod.Signature))
                        },
                        this);
                }
            }
        }
    }
}
