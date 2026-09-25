// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
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
        public void DualAuthSettingsPreservesCustomizedConstructorOrdering()
        {
            var endpoint = InputFactory.EndpointParameter(
                "endpoint", InputPrimitiveType.String, isRequired: true, isEndpoint: true);
            var client = InputFactory.Client("TestClient", parameters: [endpoint]);
            MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("x-custom-key", null),
                oauth2Auth: () => new InputOAuth2Auth([new InputOAuth2Flow(["scope"], null, null, null)]),
                clients: () => [client],
                visitors: () => []);
            var provider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ClientProvider>().Single();
            var settingsCtor = provider.Constructors.Single(c =>
                c.Signature.Parameters.Count == 1 &&
                c.Signature.Parameters[0].Type.Equals(provider.ClientSettings!.Type));
            var internalCtor = provider.Constructors.Single(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal));

            // Model a customization that moves options before endpoint, and credentials to the front.
            var parameters = internalCtor.Signature.Parameters;
            internalCtor.Signature.Update(parameters: [parameters[0], parameters[2], parameters[1]]);
            var arguments = settingsCtor.Signature.Initializer!.Arguments;
            settingsCtor.Signature.Update(initializer: new ConstructorInitializer(false, [arguments[0], arguments[2], arguments[1]]));
            foreach (var ctor in provider.Constructors.Where(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                c.Signature.Parameters.Count == 3 &&
                c.Signature.Parameters.Any(p => p.Type.Equals(typeof(TokenCredential)) || p.Type.Equals(typeof(AzureKeyCredential)))))
            {
                var ctorParameters = ctor.Signature.Parameters;
                ctor.Signature.Update(parameters: [ctorParameters[1], ctorParameters[2], ctorParameters[0]]);
                var ctorArguments = ctor.Signature.Initializer!.Arguments;
                ctor.Signature.Update(initializer: new ConstructorInitializer(false, [ctorArguments[0], ctorArguments[2], ctorArguments[1]]));
            }

            new TestClientSettingsVisitor().VisitClient(client, provider);

            var result = settingsCtor.Signature.Initializer!.Arguments;
            Assert.IsInstanceOf<TernaryConditionalExpression>(result[0]);
            StringAssert.Contains("AzureKeyCredentialPolicy", result[0].ToDisplayString());
            StringAssert.Contains("BearerTokenAuthenticationPolicy", result[0].ToDisplayString());
            Assert.AreSame(arguments[2], result[1]);
            Assert.AreSame(arguments[1], result[2]);
            Assert.AreEqual(typeof(HttpPipelinePolicy), internalCtor.Signature.Parameters[0].Type.FrameworkType);
        }

        [Test]
        public void DualAuthSettingsConstructorSelectsPolicyAndPreservesParameters(
            [Values(null, "SharedAccessKey")] string? prefix,
            [Values(false, true)] bool hoistedParameters)
        {
            var endpoint = InputFactory.EndpointParameter(
                "endpoint", InputPrimitiveType.String, isRequired: true, isEndpoint: true);
            var instanceId = InputFactory.PathParameter(
                "instanceId", InputPrimitiveType.String, isRequired: true, scope: InputParameterScope.Client);
            var tenantId = InputFactory.PathParameter(
                "tenantId", InputPrimitiveType.String, isRequired: true, scope: InputParameterScope.Client);
            var client = InputFactory.Client(
                "TestClient", parameters: hoistedParameters ? [endpoint, instanceId, tenantId] : [endpoint]);

            MockHelpers.LoadMockGenerator(
                apiKeyAuth: () => new InputApiKeyAuth("x-custom-key", prefix),
                oauth2Auth: () => new InputOAuth2Auth(
                    [new InputOAuth2Flow(["https://first/.default", "https://second/.default"], null, null, null)]),
                clients: () => [client]);

            var provider = AzureClientGenerator.Instance.OutputLibrary.TypeProviders.OfType<ClientProvider>().Single();
            var settingsCtor = provider.Constructors.Single(c =>
                c.Signature.Parameters.Count == 1 &&
                c.Signature.Parameters[0].Type.Equals(provider.ClientSettings!.Type));
            var initializer = settingsCtor.Signature.Initializer!;
            var arguments = initializer.Arguments.Select(a => a.ToDisplayString()).ToArray();

            Assert.IsFalse(initializer.IsBase);
            Assert.AreEqual(hoistedParameters ? 5 : 3, arguments.Length);
            var prefixArgument = prefix == null ? "" : ", AuthorizationApiKeyPrefix";
            Assert.AreEqual(
                "string.Equals(settings?.Credential?.CredentialSource, \"apikeycredential\", global::System.StringComparison.OrdinalIgnoreCase)" +
                $" ? new global::Azure.Core.AzureKeyCredentialPolicy(new global::Azure.AzureKeyCredential(settings.Credential.Key), AuthorizationHeader{prefixArgument})" +
                " : new global::Azure.Core.Pipeline.BearerTokenAuthenticationPolicy(settings?.CredentialProvider as global::Azure.Core.TokenCredential, AuthorizationScopes)",
                arguments[0]);
            Assert.AreEqual("settings?.Endpoint", arguments[1]);
            if (hoistedParameters)
            {
                Assert.AreEqual("settings?.InstanceId", arguments[2]);
                Assert.AreEqual("settings?.TenantId", arguments[3]);
            }
            Assert.AreEqual("settings?.Options", arguments[^1]);

            Assert.AreEqual("\"x-custom-key\"", provider.Fields.Single(f => f.Name == "AuthorizationHeader").InitializationValue!.ToDisplayString());
            var scopes = provider.Fields.Single(f => f.Name == "AuthorizationScopes").InitializationValue!.ToDisplayString();
            StringAssert.Contains("\"https://first/.default\"", scopes);
            StringAssert.Contains("\"https://second/.default\"", scopes);
            if (prefix != null)
            {
                Assert.AreEqual($"\"{prefix}\"", provider.Fields.Single(f => f.Name == "AuthorizationApiKeyPrefix").InitializationValue!.ToDisplayString());
            }
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
        public void SettingsConstructorPlacesCredentialAfterHoistedClientParameter([Values(false, true)] bool apiKey)
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
                apiKeyAuth: apiKey ? () => new InputApiKeyAuth("mock", null) : null,
                oauth2Auth: apiKey ? null : () => new InputOAuth2Auth([new InputOAuth2Flow(["https://test.azure.com/.default"], null, null, null)]),
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
            var credentialType = apiKey ? typeof(AzureKeyCredential) : typeof(TokenCredential);
            var credentialCtor = clientProvider.Constructors.FirstOrDefault(c =>
                c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public) &&
                c.Signature.Parameters.Count == initializer!.Arguments.Count &&
                c.Signature.Parameters.Any(p => p.Type.Equals(credentialType)));
            Assert.IsNotNull(credentialCtor,
                "Client should have a public credential constructor matching the Settings chain arity");

            int credentialIndex = credentialCtor!.Signature.Parameters
                .ToList().FindIndex(p => p.Type.Equals(credentialType));
            Assert.Greater(credentialIndex, 1,
                "With a hoisted client parameter, the credential is not the second parameter");

            // The credential argument must be at the credential parameter's actual position.
            var credentialArgDisplay = initializer!.Arguments[credentialIndex].ToDisplayString();
            Assert.IsTrue(credentialArgDisplay.Contains(apiKey ? "CredentialSource" : "CredentialProvider"),
                $"Credential argument should be at index {credentialIndex}. Found: {credentialArgDisplay}");

            // The hoisted parameter's slot (index 1) must NOT receive the credential.
            var hoistedArgDisplay = initializer.Arguments[1].ToDisplayString();
            Assert.IsFalse(hoistedArgDisplay.Contains("Credential"),
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

        private class TestClientSettingsVisitor : ClientSettingsVisitor
        {
            public void VisitClient(InputClient client, ClientProvider provider) => Visit(client, provider);
        }
    }
}
