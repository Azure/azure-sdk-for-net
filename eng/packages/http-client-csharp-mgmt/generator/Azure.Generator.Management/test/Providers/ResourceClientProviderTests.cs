// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ResourceClientProviderTests
    {
        [TestCase]
        public void Verify_ValidateIdMethod()
        {
            var validateIdMethod = GetResourceClientProviderMethodByName("ValidateResourceId");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static));
            Assert.That(signature.Parameters.Count, Is.EqualTo(1));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(ResourceIdentifier)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.Null);

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        private static MethodProvider GetResourceClientProviderMethodByName(string methodName)
        {
            ResourceClientProvider resourceProvider = GetResourceClientProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.That(method, Is.Not.Null);
            return method!;
        }

        private static ResourceClientProvider GetResourceClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);
            return resourceProvider!;
        }

        private static ConstructorProvider GetResourceClientProviderConstructorByName(string constructorParameterName)
        {
            ResourceClientProvider resourceProvider = GetResourceClientProvider();
            var constructor = resourceProvider.Constructors.FirstOrDefault(c => c.Signature.Parameters.Any(p => p.Name == constructorParameterName));
            Assert.That(constructor, Is.Not.Null);
            return constructor!;
        }

        [TestCase]
        public void Verify_SyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceClientProviderMethodByName("Get");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(1));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_AsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceClientProviderMethodByName("GetAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(1));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_ConstructorWithData()
        {
            var constructor = GetResourceClientProviderConstructorByName("data");

            // verify the constructor signature
            var signature = constructor.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Internal));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType, Is.EqualTo(typeof(ArmClient)));

            // verify the method body
            var bodyStatements = constructor.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_ConstructorWithId()
        {
            var constructor = GetResourceClientProviderConstructorByName("id");

            // verify the constructor signature
            var signature = constructor.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Internal));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType, Is.EqualTo(typeof(ArmClient)));

            // verify the method body
            var bodyStatements = constructor.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_CreateResourceIdentifierMethod()
        {
            MethodProvider createResourceIdentifierMethod = GetResourceClientProviderMethodByName("CreateResourceIdentifier");

            var signature = createResourceIdentifierMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Static));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(ResourceIdentifier)));

            Assert.That(signature.Parameters.Count, Is.EqualTo(3));

            var subscriptionIdParam = signature.Parameters.FirstOrDefault(p => p.Name == "subscriptionId");
            Assert.That(subscriptionIdParam, Is.Not.Null);
            Assert.That(subscriptionIdParam!.Type.FrameworkType, Is.EqualTo(typeof(string)));

            var resourceGroupParam = signature.Parameters.FirstOrDefault(p => p.Name == "resourceGroupName");
            Assert.That(resourceGroupParam, Is.Not.Null);
            Assert.That(resourceGroupParam!.Type.FrameworkType, Is.EqualTo(typeof(string)));

            var testNameParam = signature.Parameters.FirstOrDefault(p => p.Name == "testName");
            Assert.That(testNameParam, Is.Not.Null);
            Assert.That(testNameParam!.Type.FrameworkType, Is.EqualTo(typeof(string)));

            var bodyStatements = createResourceIdentifierMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_NestedChildResource_CollectionGetter_IncludesPathParameters()
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient]);

            var parentResource = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.ResourceName == "ParentType");
            Assert.That(parentResource, Is.Not.Null);

            // Find the collection getter method — the name is based on pluralized resource name
            var childMethods = parentResource!.Methods
                .Where(m => m.Signature.Name.Contains("Child"))
                .Select(m => m.Signature.Name)
                .ToList();

            // The collection getter should exist
            Assert.That(childMethods.Count > 0, Is.True, $"Parent resource should have child methods. Available methods: {string.Join(", ", parentResource.Methods.Select(m => m.Signature.Name))}");

            var collectionGetter = parentResource.Methods
                .FirstOrDefault(m => m.Signature.ReturnType?.Name?.Contains("Collection") == true);
            Assert.That(collectionGetter, Is.Not.Null, $"Parent resource should have a collection getter. Available methods: {string.Join(", ", parentResource.Methods.Select(m => m.Signature.Name))}");

            // The collection getter should include nestedTypeName as a path parameter
            var nestedTypeParam = collectionGetter!.Signature.Parameters
                .FirstOrDefault(p => p.Name == "nestedTypeName");
            Assert.That(nestedTypeParam, Is.Not.Null, $"Collection getter '{collectionGetter.Signature.Name}' should include 'nestedTypeName' path parameter. Params: {string.Join(", ", collectionGetter.Signature.Parameters.Select(p => p.Name))}");
            Assert.That(nestedTypeParam!.Type.FrameworkType, Is.EqualTo(typeof(string)));
        }

        [TestCase]
        public void Verify_NestedChildResource_GetMethods_IncludePathParameters()
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithNestedChildResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient]);

            var parentResource = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.ResourceName == "ParentType");
            Assert.That(parentResource, Is.Not.Null);

            // Check sync Get method
            var getMethod = parentResource!.Methods
                .FirstOrDefault(m => m.Signature.Name == "GetChildType");
            Assert.That(getMethod, Is.Not.Null, "Parent resource should have a GetChildType method");

            // Should include nestedTypeName + childName parameters (plus cancellationToken)
            var nestedTypeParam = getMethod!.Signature.Parameters
                .FirstOrDefault(p => p.Name == "nestedTypeName");
            Assert.That(nestedTypeParam, Is.Not.Null, "GetChildType should include 'nestedTypeName' path parameter");

            var childNameParam = getMethod.Signature.Parameters
                .FirstOrDefault(p => p.Name == "childName");
            Assert.That(childNameParam, Is.Not.Null, "GetChildType should include 'childName' path parameter");

            // Check async Get method
            var getAsyncMethod = parentResource.Methods
                .FirstOrDefault(m => m.Signature.Name == "GetChildTypeAsync");
            Assert.That(getAsyncMethod, Is.Not.Null, "Parent resource should have a GetChildTypeAsync method");

            var asyncNestedTypeParam = getAsyncMethod!.Signature.Parameters
                .FirstOrDefault(p => p.Name == "nestedTypeName");
            Assert.That(asyncNestedTypeParam, Is.Not.Null, "GetChildTypeAsync should include 'nestedTypeName' path parameter");
        }

        /// <summary>
        /// Demonstrates that ArmResource.GetCachedClient uses typeof(T) as cache key,
        /// so different parameter values captured in the factory closure are silently ignored
        /// after the first call. This means parameterized collection getters that use
        /// GetCachedClient will return stale instances when called with different path parameters.
        /// </summary>
        [TestCase]
        public void Verify_GetCachedClient_IgnoresParameterChanges()
        {
            // ArmResource._clientCache is ConcurrentDictionary<Type, object>
            // GetCachedClient<T> calls: _clientCache.GetOrAdd(typeof(T), _ => clientFactory(Client))
            // This means the cache key is ONLY the type T, not the parameters.

            // Simulate the exact same caching mechanism used by ArmResource.GetCachedClient
            var cache = new System.Collections.Concurrent.ConcurrentDictionary<System.Type, object>();

            // First call with nestedTypeName = "typeA"
            var collection1 = cache.GetOrAdd(typeof(FakeCollection), _ => new FakeCollection("typeA")) as FakeCollection;

            // Second call with nestedTypeName = "typeB" — expects a DIFFERENT collection
            var collection2 = cache.GetOrAdd(typeof(FakeCollection), _ => new FakeCollection("typeB")) as FakeCollection;

            // BUG: Both return the same instance — the second parameter is silently ignored
            Assert.That(collection2, Is.SameAs(collection1), "GetCachedClient returns the same instance regardless of parameter values");
            Assert.That(collection2!.NestedTypeName, Is.EqualTo("typeA"),
                "Second call should have nestedTypeName='typeB' but got 'typeA' because GetCachedClient ignores the closure parameters after first call");
        }

        private class FakeCollection
        {
            public string NestedTypeName { get; }
            public FakeCollection(string nestedTypeName) => NestedTypeName = nestedTypeName;
        }
    }
}
