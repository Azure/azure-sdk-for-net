// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Providers.ClientHostExtensionsDefinitions
{
    public class ClientHostExtensionsTests
    {
        [Test]
        public void AddsHostExtensionsForApiKeyAuth()
        {
            var client = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client]);

            var hostExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientHostExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(hostExtensions);
            var writer = new TypeProviderWriter(hostExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void AddsHostExtensionsForOAuth()
        {
            var client = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                oauth2Auth: () => new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client]);

            var hostExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientHostExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(hostExtensions);
            var writer = new TypeProviderWriter(hostExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void AddsHostExtensionsForEachPublicClient()
        {
            var client1 = InputFactory.Client("TestClient1", "Samples", "");
            var client2 = InputFactory.Client("TestClient2", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client1, client2]);

            var hostExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientHostExtensionsDefinition>().ToList();

            Assert.AreEqual(2, hostExtensions.Count);
            Assert.IsTrue(hostExtensions.Any(h => h.Name == "TestClient1HostExtensions"));
            Assert.IsTrue(hostExtensions.Any(h => h.Name == "TestClient2HostExtensions"));
        }

        [Test]
        public void DoesNotAddHostExtensionsForInternalClients()
        {
            var client = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client],
                createClientCore: inputClient =>
                {
                    var provider = new ClientProvider(inputClient);
                    provider.Update(modifiers: TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class);
                    return provider;
                });

            var hostExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientHostExtensionsDefinition>().SingleOrDefault();

            Assert.IsNull(hostExtensions);
        }

        [Test]
        public void DoesNotAddHostExtensionsForClientsWithoutClientSettings()
        {
            // Sub-clients (clients with a parent) are not Individually initializable, which means
            // ClientProvider.ClientSettings is null. The host-extensions provider should be skipped
            // for such public clients to avoid emitting a class that references a non-existent
            // {ClientName}Settings type.
            var parent = InputFactory.Client("ParentClient", "Samples", "");
            var subClient = InputFactory.Client("SubClient", "Samples", "", parent: parent);
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [parent, subClient]);

            var subClientProvider = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientProvider>().Single(c => c.Name == "SubClient");
            Assert.IsTrue(subClientProvider.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            Assert.IsNull(subClientProvider.ClientSettings);

            var hostExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientHostExtensionsDefinition>().ToList();

            Assert.AreEqual(1, hostExtensions.Count);
            Assert.AreEqual("ParentClientHostExtensions", hostExtensions[0].Name);
        }
    }
}
