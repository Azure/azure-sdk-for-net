// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    internal class NameVisitorTests
    {
        private const string TestClientName = "TestClient";

        [Test]
        public void TestTransformUrlToUri()
        {
            const string testModelName = "TestModelUrl";
            const string testPropertyName = "TestPropertyUrl";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Name, Is.EqualTo(testModelName.Replace("Url", "Uri")));
            Assert.That(type?.Properties[0].Name, Is.EqualTo(testPropertyName.Replace("Url", "Uri")));
        }

        [TestCase("StartTime", "dateTime", "StartOn")]
        [TestCase("StartTimestamp", "dateTime", "StartOn")]
        [TestCase("EndTimeStamp", "dateTime", "EndOn")]
        [TestCase("Date", "plainDate", "On")]
        [TestCase("LastTimestamp", "nullableDateTime", "LastOn")]
        [TestCase("StartTimestamp", "string", "StartTimestamp")]
        [TestCase("FromTimestamp", "dateTime", "FromTimestamp")]
        [TestCase("ToTimeStamp", "dateTime", "ToTimeStamp")]
        [TestCase("RestorePointInTime", "dateTime", "RestorePointInTime")]
        public void TestTransformTimePropertyName(string testPropertyName, string inputTypeName, string expectedName)
        {
            const string testModelName = "TestModel";
            var modelProperty = InputFactory.Property(testPropertyName, GetInputType(inputTypeName), serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Properties[0].Name, Is.EqualTo(expectedName));
        }

        [TestCase("startTimestamp", "dateTime", "startOn")]
        [TestCase("endTimeStamp", "nullableDateTime", "endOn")]
        [TestCase("date", "plainDate", "on")]
        [TestCase("startTimestamp", "string", "startTimestamp")]
        [TestCase("fromTimestamp", "dateTime", "fromTimestamp")]
        [TestCase("toTimeStamp", "dateTime", "toTimeStamp")]
        [TestCase("restorePointInTime", "dateTime", "restorePointInTime")]
        public void TestTransformTimeMethodParameterName(string parameterName, string inputTypeName, string expectedName)
        {
            var parameter = InputFactory.MethodParameter(
                parameterName,
                GetInputType(inputTypeName),
                serializedName: parameterName,
                location: InputRequestLocation.Query);
            var operation = InputFactory.Operation(
                name: "get",
                parameters: [parameter],
                path: "/providers/a/test",
                decorators: []);
            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [parameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);
            var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);

            var provider = plugin.Object.TypeFactory.CreateClient(client);
            var generatedParameterNames = provider!.Methods
                .SelectMany(method => method.Signature.Parameters)
                .Where(methodParameter => methodParameter.WireInfo.SerializedName == parameterName)
                .Select(methodParameter => methodParameter.Name);

            Assert.That(generatedParameterNames, Is.Not.Empty);
            Assert.That(generatedParameterNames, Is.All.EqualTo(expectedName));
        }

        [Test]
        public void TestPrependResourceProviderNameForModel()
        {
            var skuModelName = "Sku";
            var modelProperty = InputFactory.Property("TestName", InputPrimitiveType.String, serializedName: "testName", isRequired: true);
            var model = InputFactory.Model(skuModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            var resourceProviderName = ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName;
            var updatedSkuModelName = $"{resourceProviderName}{skuModelName}";
            Assert.That(updatedSkuModelName, Is.EqualTo(type?.Name));
            Assert.That($"{resourceProviderName}{skuModelName}", Is.EqualTo(type!.Constructors[0].Signature.Name));
            var serializationProvider = type?.SerializationProviders.SingleOrDefault();
            Assert.That(serializationProvider, Is.Not.Null);
            Assert.That(updatedSkuModelName, Is.EqualTo(serializationProvider!.Name));
            var deserializationMethod = serializationProvider.Methods.SingleOrDefault(m => m.Signature.Name.StartsWith("Deserialize"));
            Assert.That(deserializationMethod!.Signature.Name, Is.EqualTo("DeserializeSamplesSku"));
        }

        [Test]
        public void TestPrependResourceProviderNameForEnum()
        {
            var enumName = "PrivateEndpointServiceConnectionStatus";
            var stringEnum = InputFactory.StringEnum(enumName, [("a", "a"), ("b", "b")]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: stringEnum);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputEnums: () => [stringEnum], clients: () => [client]);

            // PreVisitEnum is called during the enum creation
            var type = plugin.Object.TypeFactory.CreateEnum(stringEnum);
            var resourceProviderName = ManagementClientGenerator.Instance.TypeFactory.ResourceProviderName;
            var updatedSkuModelName = $"{resourceProviderName}{enumName}";
            Assert.That(updatedSkuModelName, Is.EqualTo(type?.Name));
        }

        [Test]
        public void TestTransformEtagToETag()
        {
            const string testModelName = "TestModel";
            const string testPropertyName = "Etag";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.String, serializedName: "etag", isRequired: true);
            var model = InputFactory.Model(testModelName, properties: [modelProperty]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: model);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: []);

            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [model], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(model);
            Assert.That(type?.Properties[0].Name, Is.EqualTo("ETag"));
        }

        [Test]
        public void TestPatchModelRenameRespectsResourceDerivedClientNameOverride()
        {
            var (client, models, patchModel) = InputResourceData.ClientWithResourcePatchBodyEquivalentModelInstance();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var type = plugin.Object.TypeFactory.CreateModel(patchModel);

            Assert.That(type?.Name, Is.EqualTo("OperationSpecificUpdateShape"));
        }

        private static InputType GetInputType(string inputTypeName) => inputTypeName switch
        {
            "dateTime" => new InputDateTimeType(
                DateTimeKnownEncoding.Rfc3339,
                "utcDateTime",
                "TypeSpec.utcDateTime",
                InputPrimitiveType.String),
            "nullableDateTime" => new InputNullableType(GetInputType("dateTime")),
            "plainDate" => InputPrimitiveType.PlainDate,
            "string" => InputPrimitiveType.String,
            _ => throw new ArgumentOutOfRangeException(nameof(inputTypeName))
        };
    }
}
