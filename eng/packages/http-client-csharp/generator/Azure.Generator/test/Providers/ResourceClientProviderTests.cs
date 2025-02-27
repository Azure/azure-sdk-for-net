// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Models;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceClientProviderTests
    {
        private class MockBaseResourceClientProvider : ResourceClientProvider
        {
            public MockBaseResourceClientProvider(OperationSet operationSet, InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType)
                : base(operationSet, inputClient, requestPath, specName, resourceData, resourceType)
            {
            }

            protected virtual string MethodName => "";

            protected override MethodProvider[] BuildMethods() => [.. base.BuildMethods().Where(m => m.Signature.Name == MethodName)];
            protected override FieldProvider[] BuildFields() => [];
            protected override PropertyProvider[] BuildProperties() => [];
            protected override ConstructorProvider[] BuildConstructors() => [];
        }

        [TestCase]
        public void Verify_ValidateIdMethod()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (operationSet, inputClient, requestPath, schemaName, resourceData, resourceType) => new MockValidateIdResourceClientProvider(operationSet, inputClient, requestPath, schemaName, resourceData, resourceType));

            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }

        private class MockValidateIdResourceClientProvider : MockBaseResourceClientProvider
        {
            public MockValidateIdResourceClientProvider(OperationSet operationSet, InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resourceType)
                : base(operationSet, inputClient, requestPath, specName, resourceData, resourceType)
            {
            }

            protected override string MethodName => "ValidateId";
        }

        [TestCase]
        public void Verify_Constructors()
        {
            var (client, models) = InputData.ClientWithResource();
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client],
                createResourceCore: (operationSet, inputClient, requestPath, schemaName, resourceData, resourceType) => new MockConstructorsResourceClientProvider(operationSet, inputClient, requestPath, schemaName, resourceData, resourceType));
            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is ResourceClientProvider) as ResourceClientProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, result);
        }

        private class MockConstructorsResourceClientProvider : ResourceClientProvider
        {
            public MockConstructorsResourceClientProvider(IReadOnlyCollection<InputOperation> operationSet, InputClient inputClient, string requestPath, string specName, ModelProvider resourceData, string resrouceType) : base(operationSet, inputClient, requestPath, specName, resourceData, resrouceType)
            {
            }

            protected override MethodProvider[] BuildMethods() => [];
            protected override FieldProvider[] BuildFields() => [];
            protected override PropertyProvider[] BuildProperties() => [];
        }
    }
}
