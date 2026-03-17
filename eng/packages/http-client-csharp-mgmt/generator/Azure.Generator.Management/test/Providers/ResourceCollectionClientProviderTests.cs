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
            Assert.NotNull(method);
            return method!;
        }

        private static ResourceCollectionClientProvider GetResourceCollectionClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.NotNull(resourceProvider);
            return resourceProvider!;
        }

        [TestCase]
        public void Verify_GetOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Get");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(Response<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_GetAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(Task<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_ExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("Exists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(Response<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_ExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("ExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(Task<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_GetIfExistsOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExists");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(NullableResponse<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_GetIfExistsAsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceCollectionClientProviderMethodByName("GetIfExistsAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(string), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[1].Type.FrameworkType);
            Assert.AreEqual(typeof(Task<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_CreateOrUpdateOperationMethod()
        {
            ResourceCollectionClientProvider resourceProvider = GetResourceCollectionClientProvider();

            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdate");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, signature.Modifiers);
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.AreEqual(4, signature.Parameters.Count);
            Assert.AreEqual(typeof(WaitUntil), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(string), signature.Parameters[1].Type.FrameworkType);
            Assert.IsTrue(signature.Parameters[2].Type.Name.EndsWith("Data"));
            // Body parameter for PUT operations must be required (no default value)
            Assert.IsNull(signature.Parameters[2].DefaultValue, "Body parameter should be required for PUT operations");
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[3].Type.FrameworkType);
            Assert.AreEqual(typeof(ArmOperation<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_CreateOrUpdateAsyncOperationMethod()
        {
            MethodProvider createOrUpdateMethod = GetResourceCollectionClientProviderMethodByName("CreateOrUpdateAsync");

            // verify the method signature
            var signature = createOrUpdateMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async, signature.Modifiers);
            // the createOrUpdate method is a fake LRO, therefore it has 4 parameters
            Assert.AreEqual(4, signature.Parameters.Count);
            Assert.AreEqual(typeof(WaitUntil), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(string), signature.Parameters[1].Type.FrameworkType);
            Assert.IsTrue(signature.Parameters[2].Type.Name.EndsWith("Data"));
            // Body parameter for PUT operations must be required (no default value)
            Assert.IsNull(signature.Parameters[2].DefaultValue, "Body parameter should be required for PUT operations");
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[3].Type.FrameworkType);
            Assert.AreEqual(typeof(Task<>), signature.ReturnType?.FrameworkType);
            Assert.AreEqual(typeof(ArmOperation<>), signature.ReturnType?.Arguments[0].FrameworkType);

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_PutBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceCollectionClientProvider) as ResourceCollectionClientProvider;
            Assert.NotNull(resourceProvider);

            var createOrUpdate = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "CreateOrUpdate");
            Assert.NotNull(createOrUpdate);
            var signature = createOrUpdate!.Signature;

            // Body parameter (Data) should be required even though it's optional in the spec
            var dataParam = signature.Parameters.FirstOrDefault(p => p.Type.Name.EndsWith("Data"));
            Assert.NotNull(dataParam, "Body parameter should exist");
            Assert.IsNull(dataParam!.DefaultValue, "PUT body parameter should be required (no default value) even when optional in spec");
        }

        [TestCase]
        public void Verify_PatchBodyParameterIsRequiredEvenWhenOptionalInSpec()
        {
            var (client, models) = InputResourceData.ClientWithResourceOptionalBody();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);

            var update = resourceProvider!.Methods.FirstOrDefault(m => m.Signature.Name == "Update");
            Assert.NotNull(update);
            var signature = update!.Signature;

            // Body parameter should be required even though it's optional in the spec
            var bodyParam = signature.Parameters.FirstOrDefault(p => p.Location == ParameterLocation.Body);
            Assert.NotNull(bodyParam, "Body parameter should exist");
            Assert.IsNull(bodyParam!.DefaultValue, "PATCH body parameter should be required (no default value) even when optional in spec");
        }
    }
}
