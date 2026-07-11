// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
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

        // Regression test for https://github.com/Azure/azure-sdk-for-net/pull/58979 (LroVisitor path).
        // LroVisitor.BuildConvertCallComponents resolves the ClientDiagnostics property via
        // GetClientDiagnosticProperty. Libraries such as Azure.AI.Agents.Persistent declare the
        // "ClientDiagnostics" property in hand-written custom code, whose CSharpType is not equal to the
        // framework ClientDiagnostics type. Matching by type threw "Sequence contains no matching element"
        // during regeneration, so the property must be matched by name instead.
        [Test]
        public async Task GetClientDiagnosticProperty_FindsCustomTypedProperty()
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
            Assert.IsTrue(property.Type.Equals(typeof(object)));
            Assert.IsNotNull(clientProvider.CustomCodeView);
        }

        // Regression test for https://github.com/Azure/azure-sdk-for-net/pull/58979 (LroVisitor path).
        // Custom code can rename the ClientDiagnostics property via [CodeGenMember("ClientDiagnostics")],
        // in which case the property's Name differs but its OriginalName is still "ClientDiagnostics".
        // GetClientDiagnosticProperty must locate the property by its OriginalName so the renamed property
        // is still found by the LroVisitor.
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
