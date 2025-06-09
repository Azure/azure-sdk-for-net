// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Providers.TagMethodProviders;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

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
            Assert.AreEqual("AddTag", signature.Name);            // verify the method body
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
            Assert.AreEqual("AddTagAsync", signature.Name);            // verify the method body
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
            Assert.AreEqual("RemoveTag", signature.Name);            // verify the method body
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
            Assert.AreEqual("RemoveTagAsync", signature.Name);            // verify the method body
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
            Assert.AreEqual("SetTags", signature.Name);            // verify the method body
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
            Assert.AreEqual("SetTagsAsync", signature.Name);            // verify the method body
            var bodyStatements = setTagsAsyncMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var expected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(expected, bodyStatements);
        }

        private static MethodProvider GetTagMethodByName(string methodName, bool isAsync)
        {
            var resourceClientProvider = GetResourceClientProvider();

            // Get the appropriate tag method provider based on method name and async flag
            BaseTagMethodProvider tagMethodProvider = methodName switch
            {
                "AddTag" or "AddTagAsync" => new AddTagMethodProvider(resourceClientProvider, isAsync),
                "RemoveTag" or "RemoveTagAsync" => new RemoveTagMethodProvider(resourceClientProvider, isAsync),
                "SetTags" or "SetTagsAsync" => new SetTagsMethodProvider(resourceClientProvider, isAsync),
                _ => throw new ArgumentException($"Unknown tag method: {methodName}")
            };

            // Use implicit conversion to MethodProvider
            MethodProvider method = tagMethodProvider;
            Assert.NotNull(method);
            Assert.AreEqual(methodName, method.Signature.Name);
            return method;
        }

        private static ResourceClientProvider GetResourceClientProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var resourceClientProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceClientProvider);
            return resourceClientProvider!;
        }
    }
}
