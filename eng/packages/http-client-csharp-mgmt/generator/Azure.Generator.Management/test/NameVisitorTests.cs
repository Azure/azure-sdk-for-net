// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";

        [Test]
        public void TestTransformUrlToUri()
        {
            var model = InputFactory.Model("TestModelUrl");
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
            Assert.That(transformedModel?.Name, Is.EqualTo("TestModelUri"));
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
