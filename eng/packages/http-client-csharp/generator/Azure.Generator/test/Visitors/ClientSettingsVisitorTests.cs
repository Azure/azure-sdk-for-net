// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Visitors
{
    public class ClientSettingsVisitorTests
    {
        [Test]
        public void ClientSettingsHasPartialModifier()
        {
            var endpointParam = InputFactory.EndpointParameter(
                "endpoint",
                InputPrimitiveType.String,
                isRequired: true,
                isEndpoint: true);
            var client = InputFactory.Client(
                "TestClient",
                parameters: [endpointParam]);

            MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client]);

            var clientProvider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);

            var settings = clientProvider!.ClientSettings;
            Assert.IsNotNull(settings);
            Assert.IsTrue(settings!.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public));
            Assert.IsTrue(settings.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Partial));
            Assert.IsTrue(settings.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Class));
        }

        [Test]
        public void ClientOptionsHasConfigurationSectionConstructorWithBaseCallToSectionNull()
        {
            var endpointParam = InputFactory.EndpointParameter(
                "endpoint",
                InputPrimitiveType.String,
                isRequired: true,
                isEndpoint: true);
            var client = InputFactory.Client(
                "TestClient",
                parameters: [endpointParam]);

            MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [client]);

            var clientProvider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);

            var options = clientProvider!.ClientOptions;
            Assert.IsNotNull(options);

            var configCtor = options!.Constructors.FirstOrDefault(
                c => c.Signature.Parameters.Any(
                    p => p.Type.Equals(typeof(IConfigurationSection))));
            Assert.IsNotNull(configCtor, "ClientOptions should have an IConfigurationSection constructor");

            var initializer = configCtor!.Signature.Initializer;
            Assert.IsNotNull(initializer, "IConfigurationSection constructor should have an initializer");
            Assert.IsTrue(initializer!.IsBase, "Initializer should be a base call");
            Assert.AreEqual(2, initializer.Arguments.Count,
                "Initializer should have 2 arguments: section and null");
        }

        [Test]
        public void SubClientDoesNotHaveClientSettings()
        {
            var endpointParam = InputFactory.EndpointParameter(
                "endpoint",
                InputPrimitiveType.String,
                isRequired: true,
                isEndpoint: true);
            var parentClient = InputFactory.Client(
                "ParentClient",
                parameters: [endpointParam]);
            var subClient = InputFactory.Client(
                "SubClient",
                parent: parentClient);

            MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("mock", null),
                clients: () => [parentClient, subClient]);

            var subClientProvider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ClientProvider>()
                .FirstOrDefault(c => c.Name == "SubClient");
            Assert.IsNotNull(subClientProvider);
            Assert.IsNull(subClientProvider!.ClientSettings,
                "Sub-clients should not have ClientSettings");
            Assert.IsNull(subClientProvider.ClientOptions,
                "Sub-clients should not have ClientOptions");
        }
    }
}
