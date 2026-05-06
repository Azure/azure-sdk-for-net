// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ResourceCollectionClientProviderTests
    {
        private static MethodProvider GetResourceCollectionClientProviderMethodByName(string methodName)
        {
            ResourceCollectionClientProvider resourceProvider = GetResourceCollectionClientProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.That(method, Is.Not.Null);
            return method!;
        }

        private static ResourceCollectionClientProvider GetResourceCollectionClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);
            return resourceProvider!;
        }

        [TestCase]
        public void Verify_GetOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Get");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_ExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Exists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_ExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("ExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetIfExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(NullableResponse<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_GetIfExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.That(signature.Parameters.Count, Is.EqualTo(2));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_CreateOrUpdateOperationMethod()
        {
            ResourceCollectionClientProvider resourceProvider = GetResourceCollectionClientProvider();

            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdate");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.That(signature.Parameters.Count, Is.EqualTo(4));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(WaitUntil)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[2].Type.Name.EndsWith("Data"), Is.True);
            // Body parameter for PUT operations must be required (no default value)
            Assert.That(signature.Parameters[2].DefaultValue, Is.Null, "Body parameter should be required for PUT operations");
            Assert.That(signature.Parameters[3].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(ArmOperation<>)));

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var expected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(expected));
        }

        [TestCase]
        public void Verify_CreateOrUpdateAsyncOperationMethod()
        {
            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdateAsync");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.That(signature.Modifiers, Is.EqualTo(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.That(signature.Parameters.Count, Is.EqualTo(4));
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(WaitUntil)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[2].Type.Name.EndsWith("Data"), Is.True);
            // Body parameter for PUT operations must be required (no default value)
            Assert.That(signature.Parameters[2].DefaultValue, Is.Null, "Body parameter should be required for PUT operations");
            Assert.That(signature.Parameters[3].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(ArmOperation<>)));

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var expected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(expected));
        }

        [TestCase]
        public void Verify_PutBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var createOrUpdate = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "CreateOrUpdate");
            Assert.That(createOrUpdate, Is.Not.Null);
            var signature = createOrUpdate!.Signature;

            // Body parameter (Data) should be required even though it's optional in the spec
            var dataParam = signature.Parameters.FirstOrDefault(p => p.Type.Name.EndsWith("Data"));
            Assert.That(dataParam, Is.Not.Null, "Body parameter should exist");
            Assert.That(dataParam!.DefaultValue, Is.Null, "PUT body parameter should be required (no default value) even when optional in spec");
        }

        [TestCase]
        public void Verify_PatchBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var update = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "Update");
            Assert.That(update, Is.Not.Null);
            var signature = update!.Signature;

            // Body parameter should be required even though it's optional in the spec
            var bodyParam = signature.Parameters.FirstOrDefault(p => p.Location == ParameterLocation.Body);
            Assert.That(bodyParam, Is.Not.Null, "Body parameter should exist");
            Assert.That(bodyParam!.DefaultValue, Is.Null, "PATCH body parameter should be required (no default value) even when optional in spec");
        }

        [TestCase]
        public void Verify_ExistsReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var existsMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "Exists");
            Assert.That(existsMethod, Is.Not.Null);
            var signature = existsMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Response<>)),
                "Exists should return Response<bool> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "Exists should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "Exists should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_ExistsAsyncReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var existsAsyncMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "ExistsAsync");
            Assert.That(existsAsyncMethod, Is.Not.Null);
            var signature = existsAsyncMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)),
                "ExistsAsync should return Task<Response<bool>> even when Get is an LRO");
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(Response<>)),
                "ExistsAsync inner type should be Response<bool> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "ExistsAsync should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "ExistsAsync should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_GetIfExistsReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var getIfExistsMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "GetIfExists");
            Assert.That(getIfExistsMethod, Is.Not.Null);
            var signature = getIfExistsMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(NullableResponse<>)),
                "GetIfExists should return NullableResponse<> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "GetIfExists should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "GetIfExists should not have a WaitUntil parameter even when Get is an LRO");
        }

        [TestCase]
        public void Verify_GetIfExistsAsyncReturnType_WhenGetIsLro()
        {
            var (client, models) = InputResourceData.ClientWithResourceLroGet();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.That(resourceProvider, Is.Not.Null);

            var getIfExistsAsyncMethod = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "GetIfExistsAsync");
            Assert.That(getIfExistsAsyncMethod, Is.Not.Null);
            var signature = getIfExistsAsyncMethod!.Signature;
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)),
                "GetIfExistsAsync should return Task<NullableResponse<>> even when Get is an LRO");
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(NullableResponse<>)),
                "GetIfExistsAsync inner type should be NullableResponse<> even when Get is an LRO");
            // Verify no WaitUntil parameter and correct parameter shape
            Assert.That(signature.Parameters.Count, Is.EqualTo(2), "GetIfExistsAsync should have 2 parameters (testName, cancellationToken)");
            Assert.That(signature.Parameters[0].Type.FrameworkType, Is.EqualTo(typeof(string)));
            Assert.That(signature.Parameters[1].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.Parameters.Any(p => p.Type.Equals(typeof(WaitUntil))), Is.False,
                "GetIfExistsAsync should not have a WaitUntil parameter even when Get is an LRO");
        }

        // Regression test for the "tuple resource" scenario where a single resource exposes
        // multiple ResourceOperationKind.List service methods on the same collection. The
        // schema builder produces three List entries, two of which share a structurally
        // identical C# parameter signature. The provider must:
        //   - emit one (sync, async) GetAll pair per *unique* CSharpType parameter signature
        //     (so we expect two pairs, not three),
        //   - keep the parameterless overload as canonical (the broadest scope, sorted first),
        //   - implement IEnumerable<TResource>/IAsyncEnumerable<TResource> because a
        //     parameterless GetAll exists.
        // This guards against regressions where a non-structural de-dup key (e.g. Type.ToString())
        // could either incorrectly merge two distinct overloads or fail to merge two identical
        // overloads (causing CS0111 in generated code).
        [TestCase]
        public void Verify_MultipleListOperations_DedupedByStructuralSignature()
        {
            var (parentClient, childClient, models) = InputResourceData.ClientWithChildResourceMultipleLists();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [parentClient, childClient]);

            var childCollection = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ResourceCollectionClientProvider>()
                .FirstOrDefault(p => p.ResourceName == "ChildType");
            Assert.That(childCollection, Is.Not.Null, "ChildType collection provider should be generated");

            var syncGetAlls = childCollection!.Methods.Where(m => m.Signature.Name == "GetAll").ToList();
            var asyncGetAlls = childCollection.Methods.Where(m => m.Signature.Name == "GetAllAsync").ToList();

            Assert.That(syncGetAlls.Count, Is.EqualTo(2),
                $"Expected 2 sync GetAll overloads after de-dup, got {syncGetAlls.Count}: " +
                string.Join(" | ", syncGetAlls.Select(m => $"({string.Join(",", m.Signature.Parameters.Select(p => p.Type.Name))})")));
            Assert.That(asyncGetAlls.Count, Is.EqualTo(2),
                $"Expected 2 async GetAllAsync overloads after de-dup, got {asyncGetAlls.Count}");

            // The two surviving signatures must be structurally distinct.
            var syncSignatures = syncGetAlls
                .Select(m => m.Signature.Parameters.Select(p => p.Type).ToArray())
                .ToList();
            Assert.That(syncSignatures[0].SequenceEqual(syncSignatures[1]), Is.False,
                "The two emitted GetAll overloads should have structurally distinct parameter signatures.");

            // One overload is parameterless (CancellationToken only); the other has the $filter query parameter.
            var parameterless = syncGetAlls.FirstOrDefault(m =>
                m.Signature.Parameters.Count == 1 &&
                m.Signature.Parameters[0].Type.FrameworkType == typeof(CancellationToken));
            Assert.That(parameterless, Is.Not.Null,
                "A parameterless GetAll(CancellationToken) overload should exist.");

            var withFilter = syncGetAlls.FirstOrDefault(m =>
                m.Signature.Parameters.Any(p => p.Name == "filter" && p.Type.FrameworkType == typeof(string)));
            Assert.That(withFilter, Is.Not.Null,
                "A GetAll overload that accepts the 'filter' query parameter should exist.");

            // Because a parameterless GetAll exists, the collection must implement IEnumerable<T>/IAsyncEnumerable<T>.
            var getEnumeratorMethods = childCollection.Methods
                .Where(m => m.Signature.Name == "GetEnumerator" || m.Signature.Name == "GetAsyncEnumerator")
                .ToList();
            Assert.That(getEnumeratorMethods.Count, Is.GreaterThanOrEqualTo(2),
                "Collection should expose GetEnumerator and GetAsyncEnumerator when a parameterless GetAll exists.");
        }
    }
}
