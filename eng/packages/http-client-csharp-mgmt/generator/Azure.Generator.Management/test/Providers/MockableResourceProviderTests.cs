// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class MockableResourceProviderTests
    {
        [TestCase]
        public void Verify_BackCompatOverloadIsDecorated()
        {
            // The current spec exposes a scoped list method with an optional "filter" query parameter; the previous
            // contract (loaded from TestData) did not, so the upstream generator synthesizes a hidden back-compat overload.
            var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client], lastContractCompilation: () => Helpers.GetCompilationFromDirectory());
            var provider = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>().Single(p => p.ArmCoreType.Equals(typeof(ArmClient)));
            Assert.That(provider.LastContractView, Is.Not.Null);

            ManagementMockHelpers.ProcessTypeForBackCompatibility(provider);

            var backCompatMethods = new TestTypeProvider(
                name: provider.Name,
                ns: provider.Type.Namespace,
                declarationModifiers: provider.DeclarationModifiers,
                methods: provider.Methods.Where(m => m.Signature.Name == "GetEvents" || m.Signature.Name == "GetEventsAsync"));
            var rendered = new TypeProviderWriter(backCompatMethods).Write().Content.Replace("\r\n", "\n");
            Assert.That(rendered, Is.EqualTo(Helpers.GetExpectedFromFile()));
        }
    }
}
