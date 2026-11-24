// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class MockableResourceProviderTests
    {
        [Test]
        public void DirectSingletonAccessorPreservesItsParameterlessShapeAndFixedName()
        {
            var (client, models) = InputResourceData.ClientWithResource(singletonResourceName: "default");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(provider => provider.ArmCoreType.Equals(typeof(ResourceGroupResource)));
            var method = mockable.Methods.Single(method => method.Signature.Name == "GetResponseType");
            Assert.That(method.Signature.Parameters, Is.Empty);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("AppendProviderResource(\"Microsoft.Tests\", \"tests\", \"default\")").And.Not.Contain("throw"));
        }

        [Test]
        public void SingletonAccessorEscapesBracesInLiteralResourceName()
        {
            var (client, models) = InputResourceData.ClientWithResource(singletonResourceName: "{applicationDefinitionName}?disambiguation_dummy");
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(provider => provider.ArmCoreType.Equals(typeof(ResourceGroupResource)));
            var method = mockable.Methods.Single(method => method.Signature.Name == "GetResponseType");
            Assert.That(method.Signature.Parameters, Is.Empty);
            Assert.That(method.BodyStatements!.ToDisplayString(), Does.Contain("\"{applicationDefinitionName}?disambiguation_dummy\"").And.Not.Contain("$\""));
        }

        [Test]
        public void RegionalSingletonAccessorRequiresLocationAndRetainsExplicitlyFailingLegacyOverload()
        {
            var (client, models) = InputResourceData.ClientWithRegionalSingleton();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(provider => provider.ArmCoreType.Equals(typeof(SubscriptionResource)));
            var accessors = mockable.Methods.Where(method => method.Signature.Name == "GetHorizonDBCapability").ToArray();
            var regional = accessors.Single(method => method.Signature.Parameters.Count == 1);
            var legacy = accessors.Single(method => method.Signature.Parameters.Count == 0);
            Assert.Multiple(() =>
            {
                Assert.That(regional.Signature.Parameters[0].Type, Is.EqualTo(new CSharpType(typeof(AzureLocation))));
                Assert.That(regional.Signature.Parameters[0].Name, Is.EqualTo("location"));
                Assert.That(regional.BodyStatements!.ToDisplayString(),
                    Does.Contain("/providers/Microsoft.HorizonDb/locations/{location}/capabilities/default"));
                Assert.That(legacy.BodyStatements!.ToDisplayString(), Does.Contain("InvalidOperationException").And.Contain("requires a location"));
                Assert.That(legacy.BodyStatements!.ToDisplayString(), Does.Not.Contain("new HorizonDBCapabilityResource"));
            });
            var extensions = plugin.Object.OutputLibrary.TypeProviders.OfType<ExtensionProvider>().Single();
            Assert.That(extensions.Methods.Count(method => method.Signature.Name == "GetHorizonDBCapability"), Is.EqualTo(2));
        }

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
