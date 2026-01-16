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
            Assert.That(signature.Parameters[3].Type.FrameworkType, Is.EqualTo(typeof(CancellationToken)));
            Assert.That(signature.ReturnType?.FrameworkType, Is.EqualTo(typeof(Task<>)));
            Assert.That(signature.ReturnType?.Arguments[0].FrameworkType, Is.EqualTo(typeof(ArmOperation<>)));

            // verify the method body
            var bodyStatements = createOrUpdateMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var expected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(expected));
        }
    }
}
