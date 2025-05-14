// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(string)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Response<>));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(string)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Task<>));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(string)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Response<>));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(string)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Task<>));

            // verify the method body
            var bodyStatements = getMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }
    }
}
