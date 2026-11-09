// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Utilities
{
    internal class ClientProviderExtensionsTests
    {
        [Test]
        public void UsesFinalProviderContractToPreserveUrlOperationName()
        {
            var operation = InputFactory.Operation("GetUrl");
            operation.GetType().GetProperty("OriginalName")!.GetSetMethod(true)!.Invoke(operation, ["GetUrl"]);
            var serviceMethod = InputFactory.BasicServiceMethod("GetUrl", operation);
            var client = InputFactory.Client("TestClient", methods: [serviceMethod]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                clients: () => [client],
                lastContractCompilation: () => Helpers.BuildCompilation([
                    ("MockableTestResource.cs", """
                        namespace Samples
                        {
                            public partial class MockableTestResource
                            {
                                public void GetUrl() { }
                                public void GetUrlAsync() { }
                            }
                        }
                        """)]));
            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().Single();
            var finalProvider = new TestTypeProvider(name: "MockableTestResource", ns: "Samples");

            Assert.That(finalProvider.LastContractView, Is.Not.Null);
            Assert.That(operation.Name, Is.EqualTo("GetUri"));
            Assert.That(operation.OriginalName, Is.EqualTo("GetUrl"));
            Assert.That(clientProvider.GetConvenienceMethodByOperation(operation, false, finalProvider).Signature.Name, Is.EqualTo("GetUrl"));
            Assert.That(clientProvider.GetConvenienceMethodByOperation(operation, true, finalProvider).Signature.Name, Is.EqualTo("GetUrlAsync"));
        }

        [Test]
        public void NormalizesUrlOperationNameForNewContract()
        {
            var operation = InputFactory.Operation("GetUrl");
            operation.GetType().GetProperty("OriginalName")!.GetSetMethod(true)!.Invoke(operation, ["GetUrl"]);
            var serviceMethod = InputFactory.BasicServiceMethod("GetUrl", operation);
            var client = InputFactory.Client("TestClient", methods: [serviceMethod]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
            var clientProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ClientProvider>().Single();
            var finalProvider = new TestTypeProvider(name: "MockableTestResource", ns: "Samples");

            Assert.That(clientProvider.GetConvenienceMethodByOperation(operation, false, finalProvider).Signature.Name, Is.EqualTo("GetUri"));
            Assert.That(clientProvider.GetConvenienceMethodByOperation(operation, true, finalProvider).Signature.Name, Is.EqualTo("GetUriAsync"));
        }
    }
}
