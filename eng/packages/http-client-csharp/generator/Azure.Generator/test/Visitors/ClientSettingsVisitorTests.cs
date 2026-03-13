// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
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
        public void ClientOptionsHasLoggedHeaderDefaultsPartialMethod()
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
                m => m.Signature.Name == "ConfigureLoggedHeaderDefaults");
            Assert.IsNotNull(method, "ClientOptions should have a ConfigureLoggedHeaderDefaults method");
            Assert.IsTrue(method!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Partial),
                "ConfigureLoggedHeaderDefaults should be a partial method");
            Assert.IsNull(method.Signature.ReturnType,
                "ConfigureLoggedHeaderDefaults should return void");
            Assert.IsEmpty(method.Signature.Parameters,
                "ConfigureLoggedHeaderDefaults should have no parameters");
            Assert.IsNull(method.BodyStatements,
                "ConfigureLoggedHeaderDefaults partial declaration should have no body");
            Assert.IsNull(method.BodyExpression,
                "ConfigureLoggedHeaderDefaults partial declaration should have no body expression");
        }

        [Test]
        public void ClientOptionsHasLoggedQueryParameterDefaultsPartialMethod()
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
                m => m.Signature.Name == "ConfigureLoggedQueryParameterDefaults");
            Assert.IsNotNull(method, "ClientOptions should have a ConfigureLoggedQueryParameterDefaults method");
            Assert.IsTrue(method!.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Partial),
                "ConfigureLoggedQueryParameterDefaults should be a partial method");
            Assert.IsNull(method.Signature.ReturnType,
                "ConfigureLoggedQueryParameterDefaults should return void");
            Assert.IsEmpty(method.Signature.Parameters,
                "ConfigureLoggedQueryParameterDefaults should have no parameters");
            Assert.IsNull(method.BodyStatements,
                "ConfigureLoggedQueryParameterDefaults partial declaration should have no body");
            Assert.IsNull(method.BodyExpression,
                "ConfigureLoggedQueryParameterDefaults partial declaration should have no body expression");
        }

        [Test]
        public void AllConstructorsCallLoggingConfigurationMethods()
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
                Assert.IsTrue(display.Contains("ConfigureLoggedHeaderDefaults"),
                    $"Constructor should call ConfigureLoggedHeaderDefaults. Body: {display}");
                Assert.IsTrue(display.Contains("ConfigureLoggedQueryParameterDefaults"),
                    $"Constructor should call ConfigureLoggedQueryParameterDefaults. Body: {display}");
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
    }
}
