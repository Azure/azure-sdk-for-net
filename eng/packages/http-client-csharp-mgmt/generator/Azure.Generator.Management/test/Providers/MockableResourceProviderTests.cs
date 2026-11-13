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

        [Test]
        public void PreservesUrlOperationNameInMockableAndExtensionProjections()
        {
            var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList("GetUrl", hasClientNameOverride: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client],
                lastContractCompilation: () => Helpers.BuildCompilation([
                    ("MockableSamplesArmClient.cs", """
                        namespace Samples.Mocking
                        {
                            public partial class MockableSamplesArmClient : global::Azure.ResourceManager.ArmResource
                            {
                                public virtual global::Azure.Pageable<global::Samples.EventResource> GetUrl(global::Azure.Core.ResourceIdentifier scope, string filter = default, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
                                public virtual global::Azure.AsyncPageable<global::Samples.EventResource> GetUrlAsync(global::Azure.Core.ResourceIdentifier scope, string filter = default, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
                            }
                        }
                        """)]));

            var mockableProvider = plugin.Object.OutputLibrary.TypeProviders
                .OfType<MockableResourceProvider>()
                .Single(p => p.ArmCoreType.Equals(typeof(ArmClient)));
            Assert.That(mockableProvider.LastContractView, Is.Not.Null);
            Assert.That(mockableProvider.Methods.Any(m => m.Signature.Name == "GetUrl"), Is.True);
            Assert.That(mockableProvider.Methods.Any(m => m.Signature.Name == "GetUrlAsync"), Is.True);

            var extensionProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ExtensionProvider>().Single();
            Assert.That(extensionProvider.Methods.Any(m => m.Signature.Name == "GetUrl"), Is.True);
            Assert.That(extensionProvider.Methods.Any(m => m.Signature.Name == "GetUrlAsync"), Is.True);
        }

        [Test]
        public void NormalizesNewUrlOperationNameInMockableAndExtensionProjections()
        {
            var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList("GetUrl", hasClientNameOverride: true);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            var mockableProvider = plugin.Object.OutputLibrary.TypeProviders
                .OfType<MockableResourceProvider>()
                .Single(p => p.ArmCoreType.Equals(typeof(ArmClient)));
            Assert.That(mockableProvider.Methods.Any(m => m.Signature.Name == "GetUri"), Is.True);
            Assert.That(mockableProvider.Methods.Any(m => m.Signature.Name == "GetUriAsync"), Is.True);

            var extensionProvider = plugin.Object.OutputLibrary.TypeProviders.OfType<ExtensionProvider>().Single();
            Assert.That(extensionProvider.Methods.Any(m => m.Signature.Name == "GetUri"), Is.True);
            Assert.That(extensionProvider.Methods.Any(m => m.Signature.Name == "GetUriAsync"), Is.True);
        }
    }
}
