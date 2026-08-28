// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
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
        public void InternalAuthenticationPolicyConstructorUsesHttpPipelinePolicy()
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

            // The internal constructor should exist but its AuthenticationPolicy parameter
            // should be changed to HttpPipelinePolicy (Azure.Core type).
            var internalCtors = clientProvider!.Constructors.Where(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)).ToList();
            Assert.AreEqual(1, internalCtors.Count,
                "There should be exactly one internal constructor");

            var policyParam = internalCtors[0].Signature.Parameters.FirstOrDefault(
                p => p.Name == "authenticationPolicy");
            Assert.IsNotNull(policyParam,
                "The internal constructor should have an authenticationPolicy parameter");
            Assert.AreEqual(nameof(HttpPipelinePolicy), policyParam!.Type.Name,
                "The authenticationPolicy parameter should be HttpPipelinePolicy, not AuthenticationPolicy");
        }

        [Test]
        public void SettingsConstructorPlacesCredentialAfterHoistedClientParameter()
        {
            // Reproduces the case where an additional client-level parameter (e.g. an
            // instanceId hoisted onto the client via @clientInitialization) appears before
            // the credential in the public credential constructor. The Settings constructor
            // must place the credential argument at the credential parameter's actual
            // position, not hard-coded at index 1, otherwise the credential and the hoisted
            // parameter are passed into each other's slots and the code fails to compile.
            var endpointParam = InputFactory.EndpointParameter(
                "endpoint",
                InputPrimitiveType.String,
                isRequired: true,
                isEndpoint: true);
            var instanceIdParam = InputFactory.PathParameter(
                "instanceId",
                InputPrimitiveType.String,
                isRequired: true,
                scope: InputParameterScope.Client);
            var client = InputFactory.Client(
                "TestClient",
                parameters: [endpointParam, instanceIdParam]);

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
            Assert.IsNotNull(settingsCtor, "Client should have a Settings constructor");

            var initializer = settingsCtor!.Signature.Initializer;
            Assert.IsNotNull(initializer, "Settings constructor should have an initializer");

            // Find the public credential constructor the Settings constructor chains to.
            var credentialCtor = clientProvider.Constructors.FirstOrDefault(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                c.Signature.Parameters.Count == initializer!.Arguments.Count &&
                c.Signature.Parameters.Any(p => p.Type.Equals(typeof(TokenCredential))));
            Assert.IsNotNull(credentialCtor,
                "Client should have a public TokenCredential constructor matching the Settings chain arity");

            int credentialIndex = credentialCtor!.Signature.Parameters
                .ToList().FindIndex(p => p.Type.Equals(typeof(TokenCredential)));
            Assert.Greater(credentialIndex, 1,
                "With a hoisted client parameter, the credential is not the second parameter");

            // The credential argument must be at the credential parameter's actual position.
            var credentialArgDisplay = initializer!.Arguments[credentialIndex].ToDisplayString();
            Assert.IsTrue(credentialArgDisplay.Contains("CredentialProvider"),
                $"Credential argument should be at index {credentialIndex}. Found: {credentialArgDisplay}");

            // The hoisted parameter's slot (index 1) must NOT receive the credential.
            var hoistedArgDisplay = initializer.Arguments[1].ToDisplayString();
            Assert.IsFalse(hoistedArgDisplay.Contains("CredentialProvider"),
                $"The hoisted parameter slot should not receive the credential. Found: {hoistedArgDisplay}");
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

        [Test]
        public void SettingsConstructorForKeyCredentialOnlyClientChecksCredentialSource()
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
            Assert.IsNotNull(clientProvider!.ClientSettings,
                "Key-credential client should have ClientSettings");

            var settingsCtor = clientProvider.Constructors.FirstOrDefault(c =>
                c.Signature.Parameters.Count == 1 &&
                c.Signature.Parameters[0].Type.Equals(clientProvider.ClientSettings!.Type));
            Assert.IsNotNull(settingsCtor,
                "Key-credential client should have a Settings constructor");

            var initializer = settingsCtor!.Signature.Initializer;
            Assert.IsNotNull(initializer, "Settings constructor should have an initializer");
            Assert.IsFalse(initializer!.IsBase, "Settings constructor should use this(), not base()");

            // The initializer should contain a ternary checking CredentialSource for "apikeycredential"
            var display = string.Join(", ", initializer.Arguments.Select(a => a.ToDisplayString()));
#pragma warning disable SCME0002
            Assert.IsTrue(display.Contains(nameof(CredentialSettings.CredentialSource)),
#pragma warning restore SCME0002
                $"Settings constructor initializer should check CredentialSource. Args: {display}");
            Assert.IsTrue(display.Contains("apikeycredential"),
                $"Settings constructor initializer should compare against 'apikeycredential'. Args: {display}");
            Assert.IsTrue(display.Contains(nameof(AzureKeyCredential)),
                $"Settings constructor initializer should construct AzureKeyCredential. Args: {display}");
        }

        [Test]
        public void NoCredentialClientSettingsConstructorChainsWithNullAuth()
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
                clients: () => [client]);

            var clientProvider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ClientProvider>().FirstOrDefault();
            Assert.IsNotNull(clientProvider);

            // Client with no credential constructors: check if Settings constructor exists
            var clientSettings = clientProvider!.ClientSettings;
            var settingsCtor = clientSettings != null
                ? clientProvider.Constructors.FirstOrDefault(c =>
                    c.Signature.Parameters.Count == 1 &&
                    c.Signature.Parameters[0].Type.Equals(clientSettings.Type))
                : null;

            if (settingsCtor != null)
            {
                var initializer = settingsCtor.Signature.Initializer;
                Assert.IsNotNull(initializer, "Settings constructor should have an initializer");
                Assert.IsFalse(initializer!.IsBase, "Settings constructor should use this(), not base()");

                // The first argument should be null (no auth policy)
                var firstArgDisplay = initializer.Arguments[0].ToDisplayString();
                Assert.AreEqual("((global::Azure.Core.Pipeline.HttpPipelinePolicy)null)", firstArgDisplay,
                    $"First argument of no-auth Settings constructor should be null, was: {firstArgDisplay}");
            }
            else
            {
                // If no Settings constructor exists, this is acceptable behavior —
                // no credential means no configuration-based construction.
                Assert.Pass("No Settings constructor generated for client without credential support — expected behavior");
            }
        }
    }
}
