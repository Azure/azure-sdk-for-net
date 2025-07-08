// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class SafeFlattenVisitorTests
    {
        private const string TestClientName = "TestClient";
        private const string TestModelName = "TestModel";
        private const string TestProtyName = "TestProperty";
        private const string InnerModelPropertyName = "InnerModelProperty";
        private const string InnerModelName = "InnerModel";

        [Test]
        public void TestSinglePropertyModelSafeFlatten()
        {
            var modelProperty = InputFactory.Property(TestProtyName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var innnerModel = InputFactory.Model(InnerModelName, properties: [InputFactory.Property("InnerProperty", InputPrimitiveType.String)]);
            var innerModelProperty = InputFactory.Property(InnerModelPropertyName, innnerModel, isRequired: true);
            var model = InputFactory.Model(TestModelName, properties: [modelProperty, innerModelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);
            var outputModel = plugin.Object.TypeFactory.CreateModel(model);
            Assert.NotNull(outputModel);

            var outputInnerModelProperty = outputModel!.Properties.FirstOrDefault(p => p.Name == InnerModelPropertyName);
            Assert.NotNull(outputInnerModelProperty);
            Assert.That(outputInnerModelProperty!.Modifiers.HasFlag(MethodSignatureModifiers.Internal));

            var flattenedProperty = outputModel.Properties.FirstOrDefault(p => p.Name == $"{InnerModelName}InnerProperty");
            Assert.NotNull(flattenedProperty);
            Assert.That(flattenedProperty!.Modifiers.HasFlag(MethodSignatureModifiers.Public));
            var flattenPropertyBody = flattenedProperty.Body as MethodPropertyBody;
            Assert.NotNull(flattenPropertyBody);
            Assert.AreEqual("return (this.InnerModelProperty is null) ? default : InnerModelProperty.InnerProperty;\n", flattenPropertyBody!.Getter?.ToDisplayString());
            Assert.AreEqual("if ((this.InnerModelProperty is null))\n{\n    InnerModelProperty = new global::Samples.Models.InnerModel();\n}\nthis.InnerModelProperty.InnerProperty = value;\n", flattenPropertyBody!.Setter?.ToDisplayString());
        }
    }
}
