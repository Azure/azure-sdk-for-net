// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
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
            Assert.AreEqual(MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, signature.Modifiers);
            Assert.AreEqual(1, signature.Parameters.Count);
            Assert.AreEqual(typeof(ResourceIdentifier), signature.Parameters[0].Type.FrameworkType);
            Assert.Null(signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        private static MethodProvider GetResourceClientProviderMethodByName(string methodName)
        {
            ResourceClientProvider resourceProvider = GetResourceClientProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.NotNull(method);
            return method!;
        }

        private static ResourceClientProvider GetResourceClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            return resourceProvider!;
        }

        private static ConstructorProvider GetResourceClientProviderConstructorByName(string constructorParameterName)
        {
            ResourceClientProvider resourceProvider = GetResourceClientProvider();
            var constructor = resourceProvider.Constructors.FirstOrDefault(c => c.Signature.Parameters.Any(p => p.Name == constructorParameterName));
            Assert.NotNull(constructor);
            return constructor!;
        }

        [TestCase]
        public void Verify_SyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceClientProviderMethodByName("Get");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, signature.Modifiers);
            Assert.AreEqual(1, signature.Parameters.Count);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(Response<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_AsyncOperationMethod()
        {
            MethodProvider getMethod = GetResourceClientProviderMethodByName("GetAsync");

            // verify the method signature
            var signature = getMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async, signature.Modifiers);
            Assert.AreEqual(1, signature.Parameters.Count);
            Assert.AreEqual(typeof(CancellationToken), signature.Parameters[0].Type.FrameworkType);
            Assert.AreEqual(typeof(Task<>), signature.ReturnType?.FrameworkType);

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_ConstructorWithData()
        {
            var constructor = GetResourceClientProviderConstructorByName("data");

            // verify the constructor signature
            var signature = constructor.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Internal, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(ArmClient), signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType);

            // verify the method body
            var bodyStatements = constructor.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_ConstructorWithId()
        {
            var constructor = GetResourceClientProviderConstructorByName("id");

            // verify the constructor signature
            var signature = constructor.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Internal, signature.Modifiers);
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual(typeof(ArmClient), signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType);

            // verify the method body
            var bodyStatements = constructor.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_CreateResourceIdentifierMethod()
        {
            MethodProvider createResourceIdentifierMethod = GetResourceClientProviderMethodByName("CreateResourceIdentifier");

            var signature = createResourceIdentifierMethod.Signature;
            Assert.AreEqual(MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, signature.Modifiers);
            Assert.AreEqual(typeof(ResourceIdentifier), signature.ReturnType?.FrameworkType);

            Assert.AreEqual(3, signature.Parameters.Count);

            var subscriptionIdParam = signature.Parameters.FirstOrDefault(p => p.Name == "subscriptionId");
            Assert.NotNull(subscriptionIdParam);
            Assert.AreEqual(typeof(string), subscriptionIdParam!.Type.FrameworkType);

            var resourceGroupParam = signature.Parameters.FirstOrDefault(p => p.Name == "resourceGroupName");
            Assert.NotNull(resourceGroupParam);
            Assert.AreEqual(typeof(string), resourceGroupParam!.Type.FrameworkType);

            var testNameParam = signature.Parameters.FirstOrDefault(p => p.Name == "testName");
            Assert.NotNull(testNameParam);
            Assert.AreEqual(typeof(string), testNameParam!.Type.FrameworkType);

            var bodyStatements = createResourceIdentifierMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }
    }
}
