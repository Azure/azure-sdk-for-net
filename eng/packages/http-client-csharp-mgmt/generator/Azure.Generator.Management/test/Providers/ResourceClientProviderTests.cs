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
    }
}
