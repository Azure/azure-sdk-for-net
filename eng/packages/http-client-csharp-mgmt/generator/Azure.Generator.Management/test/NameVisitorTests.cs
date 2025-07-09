// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";
        private const string TestModelName = "TestModelUrl";
        private const string TestProtyName = "TestPropertyUrl";

        [Test]
        public void TestTransformUrlToUri()
        {
            var modelProperty = InputFactory.Property(TestProtyName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(TestModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);
            var visitor = new TestVisitor();
            var type = plugin.Object.TypeFactory.CreateModel(model);
            var transformedModel = visitor.InvokeVisit(model, type);
            Assert.That(transformedModel?.Name, Is.EqualTo(TestModelName.Replace("Url", "Uri")));
            Assert.That(transformedModel?.Properties[0].Name, Is.EqualTo(TestProtyName.Replace("Url", "Uri")));
        }

        private class TestVisitor : NameVisitor
        {
            public ModelProvider? InvokeVisit(InputModelType model, ModelProvider? type)
            {
                return base.PreVisitModel(model, type);
            }
        }
    }
}
