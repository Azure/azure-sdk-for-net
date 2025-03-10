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
            public MockBaseResourceClientProvider(InputClient inputClient)
                : base(inputClient)
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
                createResourceCore: (inputClient) => new MockValidateIdResourceClientProvider(inputClient));

            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        private class MockValidateIdResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockValidateIdResourceClientProvider(InputClient inputClient)
                : base(inputClient)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "ValidateResourceId")];
        }

        [TestCase]
        public void Verify_SyncOperationMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient) => new MockSyncOperationResourceClientProvider(inputClient));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockSyncOperationResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockSyncOperationResourceClientProvider(InputClient inputClient) : base(inputClient)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "Get")];
        }

        [TestCase]
        public void Verify_AsyncOperationMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient) => new MockAsyncOperationResourceClientProvider(inputClient));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockAsyncOperationResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockAsyncOperationResourceClientProvider(InputClient inputClient) : base(inputClient)
            {
            }

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == "GetAsync")];
        }

        [TestCase]
        public void Verify_Constructors()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (inputClient) => new MockConstructorsResourceClientProvider(inputClient));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockConstructorsResourceClientProvider : ResourceClientProvider
        {
            public MockConstructorsResourceClientProvider(InputClient inputClient) : base(inputClient)
            {
            }

            protected override MethodProvider[] BuildMethods() => [];
            protected override FieldProvider[] BuildFields() => [];
            protected override PropertyProvider[] BuildProperties() => [];
        }
    }
}
