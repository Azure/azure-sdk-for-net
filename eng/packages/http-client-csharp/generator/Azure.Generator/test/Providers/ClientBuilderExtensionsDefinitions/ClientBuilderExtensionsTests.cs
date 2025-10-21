// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Tests.Providers.ClientBuilderExtensionsDefinitions
{
    public class ClientBuilderExtensionsTests
    {
        [Test]
        public void AddsClientExtensionForApiKeyAuth()
        {
            var client  = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client]);

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(builderExtensions);
            var writer = new TypeProviderWriter(builderExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void AddsClientExtensionForOAuth()
        {
            var client  = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                oauth2Auth: ()=> new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client]);

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(builderExtensions);
            var writer = new TypeProviderWriter(builderExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void AddsClientExtensionForEachAuthMethod()
        {
            var client  = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                oauth2Auth: ()=> new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client]);

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(builderExtensions);
            var writer = new TypeProviderWriter(builderExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void AddsClientExtensionForEachAuthMethodMultipleClients()
        {
            var client1  = InputFactory.Client("TestClient", "Samples", "");
            var client2  = InputFactory.Client("TestClient2", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                oauth2Auth: ()=> new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client1, client2]);

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(builderExtensions);
            var writer = new TypeProviderWriter(builderExtensions!);
            var file = writer.Write();
            Assert.AreEqual(Helpers.GetExpectedFromFile(), file.Content);
        }

        [Test]
        public void DoesNotAddExtensionMethodsClassIfOnlyInternalClients()
        {
            var client = InputFactory.Client("TestClient", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                oauth2Auth: ()=> new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client],
                createClientCore: inputClient =>
                {
                    var provider =  new ClientProvider(inputClient);
                    provider.Update(modifiers: TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class);
                    return provider;
                });

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNull(builderExtensions);
        }

        [Test]
        public void DoesNotAddExtensionMethodsForInternalClients()
        {
            var client1 = InputFactory.Client("TestClient1", "Samples", "");
            var client2 = InputFactory.Client("TestClient2", "Samples", "");
            var plugin = MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                oauth2Auth: ()=> new InputOAuth2Auth([new InputOAuth2Flow(["mock"], null, null, null)]),
                clients: () => [client1, client2],
                createClientCore: inputClient =>
                {
                    var provider =  new ClientProvider(inputClient);
                    if (inputClient.Name == "TestClient1")
                    {
                        provider.Update(modifiers: TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class);
                    }
                    return provider;
                });

            var builderExtensions = plugin.Object.OutputLibrary.TypeProviders
                .OfType<ClientBuilderExtensionsDefinition>().SingleOrDefault();

            Assert.IsNotNull(builderExtensions);
            Assert.AreEqual(3, builderExtensions!.Methods.Count);
            foreach (var method in builderExtensions.Methods)
            {
                Assert.IsTrue(method.Signature.Name.EndsWith("TestClient2", StringComparison.Ordinal));
            }
        }
    }
}