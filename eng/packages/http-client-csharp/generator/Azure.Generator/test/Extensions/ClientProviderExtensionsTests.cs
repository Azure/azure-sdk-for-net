// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Generator.Extensions;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Tests.Extensions
{
    public class ClientProviderExtensionsTests
    {
        private const string ClientDiagnosticsPropertyName = "ClientDiagnostics";

        [SetUp]
        public void Setup()
        {
            MockHelpers.LoadMockGenerator();
        }

        // The generated client exposes a framework-typed ClientDiagnostics property, which must be
        // located by GetClientDiagnosticProperty (baseline for the regression tests below).
        [Test]
        public void GetClientDiagnosticProperty_FindsGeneratedProperty()
        {
            var inputClient = CreateInputClient();
            MockHelpers.LoadMockGenerator(clients: () => [inputClient]);
            var clientProvider = CreateClientProvider(inputClient);

            var property = clientProvider.GetClientDiagnosticProperty();

            Assert.IsNotNull(property);
            Assert.AreEqual(ClientDiagnosticsPropertyName, property.Name);
        }

        // Libraries such as Azure.AI.Agents.Persistent declare ClientDiagnostics in custom code.
        // The custom-code symbol must be normalized to the framework ClientDiagnostics type so
        // GetClientDiagnosticProperty can locate it by type.
        [Test]
        public async Task GetClientDiagnosticProperty_FindsCustomCodeProperty()
        {
            var inputClient = CreateInputClient();
            await MockHelpers.LoadMockGeneratorAsync(
                clients: () => [inputClient],
                compilation: () => Helpers.GetCompilationFromDirectoryAsync());
            var clientProvider = CreateClientProvider(inputClient);

            PropertyProvider? property = null;
            Assert.DoesNotThrow(() => property = clientProvider.GetClientDiagnosticProperty());
            Assert.IsNotNull(property);
            Assert.AreEqual(ClientDiagnosticsPropertyName, property!.Name);
            Assert.AreEqual(nameof(ClientDiagnostics), property.Type.Name);
            Assert.AreEqual(typeof(ClientDiagnostics).Namespace, property.Type.Namespace);
            Assert.IsTrue(property.Type.IsFrameworkType);
            Assert.IsTrue(property.Type.Equals(typeof(ClientDiagnostics)));
            Assert.IsNotNull(clientProvider.CustomCodeView);
        }

        // Custom code can rename the ClientDiagnostics property via [CodeGenMember("ClientDiagnostics")],
        // but type-based lookup must still locate the renamed property for the LroVisitor.
        [Test]
        public async Task GetClientDiagnosticProperty_FindsRenamedProperty()
        {
            var inputClient = CreateInputClient();
            await MockHelpers.LoadMockGeneratorAsync(
                clients: () => [inputClient],
                compilation: () => Helpers.GetCompilationFromDirectoryAsync());
            var clientProvider = CreateClientProvider(inputClient);

            PropertyProvider? property = null;
            Assert.DoesNotThrow(() => property = clientProvider.GetClientDiagnosticProperty());
            Assert.IsNotNull(property);
            Assert.AreEqual("RenamedDiagnostics", property!.Name);
            Assert.AreEqual(ClientDiagnosticsPropertyName, property.OriginalName);
        }

        private static InputClient CreateInputClient()
        {
            List<InputMethodParameter> parameters =
            [
                InputFactory.MethodParameter("p1", InputPrimitiveType.String)
            ];
            var basicOperation = InputFactory.Operation("foo", parameters: parameters);
            var basicServiceMethod = InputFactory.BasicServiceMethod("foo", basicOperation, parameters: parameters);
            return InputFactory.Client("TestClient", methods: [basicServiceMethod]);
        }

        private static ClientProvider CreateClientProvider(InputClient inputClient)
        {
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(inputClient);
            Assert.IsNotNull(clientProvider);
            return clientProvider!;
        }
    }
}
