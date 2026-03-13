// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Linq;

namespace Azure.Generator.Tests.Visitors
{
    public class ClientSettingsVisitorTests
    {
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
            Assert.IsInstanceOf<KeywordExpression>(initializer.Arguments[1],
                "Second argument should be a null keyword expression");
        }

        [Test]
        public void ClientOptionsHasConfigureLoggingPartialMethod()
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

            var method = options!.Methods.FirstOrDefault(
                m => m.Signature.Name == "ConfigureLogging");
            Assert.IsNotNull(method, "ClientOptions should have a ConfigureLogging method");
            Assert.IsTrue(method!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Partial),
                "ConfigureLogging should be a partial method");
            Assert.IsNull(method.Signature.ReturnType,
                "ConfigureLogging should return void");
            Assert.IsEmpty(method.Signature.Parameters,
                "ConfigureLogging should have no parameters");
            Assert.IsNull(method.BodyStatements,
                "ConfigureLogging partial declaration should have no body");
            Assert.IsNull(method.BodyExpression,
                "ConfigureLogging partial declaration should have no body expression");
        }

        [Test]
        public void AllConstructorsCallConfigureLogging()
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

            foreach (var ctor in options!.Constructors)
            {
                var display = ctor.BodyStatements!.ToDisplayString();
                Assert.IsTrue(display.Contains("ConfigureLogging"),
                    $"Constructor should call ConfigureLogging. Body: {display}");
            }
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

        [Test]
        public void InternalAuthenticationPolicyConstructorIsRemoved()
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

            // The internal AuthenticationPolicy constructor should be completely removed.
            // Azure clients use credential types directly instead of the base library's
            // AuthenticationPolicy abstraction. The "with options" constructors have the
            // body inlined.
            var internalCtors = clientProvider!.Constructors.Where(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)).ToList();
            Assert.IsEmpty(internalCtors,
                "No internal constructors should exist — the AuthenticationPolicy constructor should be removed");
        }

        [Test]
        public void SettingsConstructorChainsToTokenCredentialConstructor()
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
                oauth2Auth: () => new InputOAuth2Auth([new InputOAuth2Flow(["https://test.azure.com/.default"], null, null, null)]),
                clients: () => [client]);

            var clientProvider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);
            Assert.IsNotNull(clientProvider!.ClientSettings,
                "Client should have ClientSettings");

            var settingsCtor = clientProvider.Constructors.FirstOrDefault(c =>
                c.Signature.Parameters.Count == 1 &&
                c.Signature.Parameters[0].Type.Equals(clientProvider.ClientSettings!.Type));
            Assert.IsNotNull(settingsCtor,
                "Client should have a Settings constructor");

            var initializer = settingsCtor!.Signature.Initializer;
            Assert.IsNotNull(initializer, "Settings constructor should have an initializer");
            Assert.IsFalse(initializer!.IsBase, "Settings constructor should use this(), not base()");

            // The initializer should contain a TokenProvider as TokenCredential argument
            var display = string.Join(", ", initializer.Arguments.Select(a => a.ToDisplayString()));
            Assert.IsTrue(display.Contains("CredentialProvider"),
                $"Settings constructor initializer should reference CredentialProvider. Args: {display}");
            Assert.IsTrue(display.Contains("TokenCredential"),
                $"Settings constructor initializer should cast to TokenCredential. Args: {display}");
        }
    }
}
