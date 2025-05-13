// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static));
            Assert.IsTrue(signature.Parameters.Count == 1);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(ResourceIdentifier)));
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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Parameters.Count == 1);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Response<>));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual | MethodSignatureModifiers.Async));
            Assert.IsTrue(signature.Parameters.Count == 1);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(Task<>));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Internal));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.AreEqual(signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType, typeof(ArmClient));

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
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Internal));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.AreEqual(signature.Parameters.Single(p => p.Name == "client").Type.FrameworkType, typeof(ArmClient));

            // verify the method body
            var bodyStatements = constructor.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }
    }
}
