// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceClientProviderTests
    {
        private class MockBaseResourceClientProvider : ResourceClientProvider
        {
            public MockBaseResourceClientProvider(InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType, bool isSingleton)
                : base(inputClient, requestPath, specName, resourceData, resourceType, isSingleton)
            {
            }
            protected override FieldProvider[] BuildFields() => [];
            protected override PropertyProvider[] BuildProperties() => [];
            protected override ConstructorProvider[] BuildConstructors() => [];
        }

        [TestCase]
        public void Verify_ValidateIdMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton) => new MockValidateIdResourceClientProvider(inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton));

            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        private class MockValidateIdResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockValidateIdResourceClientProvider(InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType, bool isSingleton)
                : base(inputClient, requestPath, specName, resourceData, resourceType, isSingleton)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "ValidateResourceId")];
        }

        [TestCase]
        public void Verify_SyncOperationMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton) => new MockSyncOperationResourceClientProvider(inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockSyncOperationResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockSyncOperationResourceClientProvider(InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType, bool isSingleton)
                : base(inputClient, requestPath, specName, resourceData, resourceType, isSingleton)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "Get")];
        }

        [TestCase]
        public void Verify_AsyncOperationMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton) => new MockAsyncOperationResourceClientProvider(inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockAsyncOperationResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockAsyncOperationResourceClientProvider(InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType, bool isSingleton)
                : base(inputClient, requestPath, specName, resourceData, resourceType, isSingleton)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "GetAsync")];
        }

        [TestCase]
        public void Verify_Constructors()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton) => new MockConstructorsResourceClientProvider(inputClient, requestPath, schemaName, resourceData, resourceType, isSingleton));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockConstructorsResourceClientProvider : ResourceClientProvider
        {
            public MockConstructorsResourceClientProvider(InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resrouceType, bool isSingleton)
                : base(inputClient, requestPath, specName, resourceData, resrouceType, isSingleton)
            {
            }

            protected override MethodProvider[] BuildMethods() => [];
            protected override FieldProvider[] BuildFields() => [];
            protected override PropertyProvider[] BuildProperties() => [];
        }
    }
}
