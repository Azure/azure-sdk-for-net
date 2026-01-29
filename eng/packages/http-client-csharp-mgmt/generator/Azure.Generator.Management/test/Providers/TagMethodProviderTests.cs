// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class TagMethodProviderTests
    {
        [TestCase]
        public void Verify_AddTag()
        {
            var addTagMethod = GetTagMethodByName("AddTag", false);

            // verify the method signature
            var signature = addTagMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsFalse(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(3, signature.Parameters.Count);
            Assert.AreEqual("key", signature.Parameters[0].Name);
            Assert.AreEqual("value", signature.Parameters[1].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[2].Name);
            Assert.AreEqual("AddTag", signature.Name);
            // verify the method body
            var bodyStatements = addTagMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_AddTagAsync()
        {
            var addTagAsyncMethod = GetTagMethodByName("AddTagAsync", true);

            // verify the method signature
            var signature = addTagAsyncMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(3, signature.Parameters.Count);
            Assert.AreEqual("key", signature.Parameters[0].Name);
            Assert.AreEqual("value", signature.Parameters[1].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[2].Name);
            Assert.AreEqual("AddTagAsync", signature.Name);
            // verify the method body
            var bodyStatements = addTagAsyncMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_RemoveTag()
        {
            var removeTagMethod = GetTagMethodByName("RemoveTag", false);

            // verify the method signature
            var signature = removeTagMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsFalse(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual("key", signature.Parameters[0].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[1].Name);
            Assert.AreEqual("RemoveTag", signature.Name);
            // verify the method body
            var bodyStatements = removeTagMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_RemoveTagAsync()
        {
            var removeTagAsyncMethod = GetTagMethodByName("RemoveTagAsync", true);

            // verify the method signature
            var signature = removeTagAsyncMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual("key", signature.Parameters[0].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[1].Name);
            Assert.AreEqual("RemoveTagAsync", signature.Name);
            // verify the method body
            var bodyStatements = removeTagAsyncMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_SetTags()
        {
            var setTagsMethod = GetTagMethodByName("SetTags", false);

            // verify the method signature
            var signature = setTagsMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsFalse(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual("tags", signature.Parameters[0].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[1].Name);
            Assert.AreEqual("SetTags", signature.Name);
            // verify the method body
            var bodyStatements = setTagsMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        [TestCase]
        public void Verify_SetTagsAsync()
        {
            var setTagsAsyncMethod = GetTagMethodByName("SetTagsAsync", true);

            // verify the method signature
            var signature = setTagsAsyncMethod.Signature;
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual));
            Assert.IsTrue(signature.Modifiers.HasFlag(MethodSignatureModifiers.Async));
            Assert.AreEqual(2, signature.Parameters.Count);
            Assert.AreEqual("tags", signature.Parameters[0].Name);
            Assert.AreEqual("cancellationToken", signature.Parameters[1].Name);
            Assert.AreEqual("SetTagsAsync", signature.Name);
            // verify the method body
            var bodyStatements = setTagsAsyncMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        private static MethodProvider GetTagMethodByName(string methodName, bool isAsync)
        {
            var (resource, restClient) = GetResourceClientProvider();
            var mockUpdateMethodProvider = CreateMockUpdateMethodProvider(resource);

            // validate the tag related methods are generated in the resource
            var method = resource.Methods.SingleOrDefault(m => m.Signature.Name == methodName);
            Assert.IsNotNull(method);
            return method!;
        }

        private static MethodProvider CreateMockUpdateMethodProvider(ResourceClientProvider resourceClientProvider)
        {
            // Create a mock Update method signature
            var updateSignature = new MethodSignature(
                "Update",
                $"Update a resource",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                new CSharpType(typeof(ArmOperation<>), resourceClientProvider.Type),
                $"The updated resource operation",
                [
                    new ParameterProvider("waitUntil", $"The wait until value", typeof(WaitUntil)),
                    new ParameterProvider("data", $"The resource data", resourceClientProvider.ResourceData.Type),
                    KnownParameters.CancellationTokenParameter
                ]);

            // Create a simple mock body that throws NotImplementedException
            var throwExpression = Throw(New.Instance(typeof(NotImplementedException)));
            var mockBody = new MethodBodyStatement[] { throwExpression };

            return new MethodProvider(updateSignature, mockBody, resourceClientProvider);
        }

        private static (ResourceClientProvider Resource, ClientProvider RestClientProvider) GetResourceClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceClientProvider = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().First();
            Assert.IsNotNull(resourceClientProvider);
            var clientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(client);
            Assert.IsNotNull(clientProvider);
            return (resourceClientProvider!, clientProvider!);
        }
    }
}
