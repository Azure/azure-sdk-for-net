// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Humanizer;
using Microsoft.TypeSpec.Generator.Expressions;
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

        protected override string BuildNamespace() => $"{base.BuildNamespace()}.Mocking";

        protected override string BuildName() => $"Mockable{ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName}{ArmCoreType.Name}";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Extensions", $"{Name}.cs");

        protected override CSharpType? GetBaseType() => typeof(ArmResource);

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
                var resourceMethodSignature = new MethodSignature(
                    $"Get{resource.SpecName}",
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
                var pluralOfResourceName = resource.SpecName.Pluralize();
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
                    yield return BuildGetMethod(this, getMethod, collectionMethodSignature, $"Get{collection.SpecName}");
                }

                if (getAsyncMethod is not null)
                {
                    // we should be sure that this would never be null, but this null check here is just ensuring that we never crash
                    yield return BuildGetMethod(this, getAsyncMethod, collectionMethodSignature, $"Get{collection.SpecName}Async");
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

        // TODO -- when we have the ability to get parent resources, we might move this to a more generic place and make it a helper method.
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
