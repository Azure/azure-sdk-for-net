// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void TestTransformTimePropertyName()
        {
            const string testModelName = "TestModel";
            const string testPropertyName = "StartTime";
            var modelProperty = InputFactory.Property(testPropertyName, InputPrimitiveType.PlainDate, serializedName: "testName", isRequired: true);
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
            Assert.That(type?.Properties[0].Name, Is.EqualTo(testPropertyName.Replace("Time", "On")));
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
            Assert.AreEqual(type?.Name, updatedSkuModelName);
            Assert.AreEqual(type!.Constructors[0].Signature.Name, $"{resourceProviderName}{skuModelName}");
            var serializationProvider = type?.SerializationProviders.SingleOrDefault();
            Assert.NotNull(serializationProvider);
            Assert.AreEqual(serializationProvider!.Name, updatedSkuModelName);
            var deserializationMethod = serializationProvider.Methods.SingleOrDefault(m => m.Signature.Name.StartsWith("Deserialize"));
            Assert.AreEqual("DeserializeSamplesSku", deserializationMethod!.Signature.Name);
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
            Assert.AreEqual(type?.Name, updatedSkuModelName);
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
        public void TestResourceModelEndingWithDataShouldNotAppendData()
        {
            const string resourceModelName = "SampleData";
            var decorators = new List<InputDecoratorInfo>();
            var modelProperty = InputFactory.Property("sampleValue", InputPrimitiveType.String, serializedName: "sampleValue", isRequired: true);
            var resourceModel = InputFactory.Model(resourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties: [modelProperty],
                        decorators: decorators);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: resourceModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: System.Guid.NewGuid().ToString());

            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: []);

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            decorators.Add(BuildResourceMetadata(resourceModel, client, resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, [
                new ResourceMethod(ResourceOperationKind.Get, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, client)
            ], resourceModelName));

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [resourceModel], clients: () => [client]);

            // PreVisitModel is called during the model creation
            var type = plugin.Object.TypeFactory.CreateModel(resourceModel);
            // Since the model name already ends with "Data", it should NOT append "Data" again
            Assert.That(type?.Name, Is.EqualTo("SampleData"));
        }

        private static InputDecoratorInfo BuildResourceMetadata(InputModelType resourceModel, InputClient resourceClient, string resourceIdPattern, string resourceType, string? singletonResourceName, ResourceScope resourceScope, IReadOnlyList<ResourceMethod> methods, string? resourceName)
        {
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase) }
            };

            var arguments = new Dictionary<string, BinaryData>
            {
                ["resourceIdPattern"] = FromLiteralString(resourceIdPattern),
                ["resourceType"] = FromLiteralString(resourceType),
                ["resourceScope"] = FromLiteralString(resourceScope.ToString()),
                ["methods"] = BinaryData.FromObjectAsJson(methods.Select(SerializeResourceMethod), options),
                ["singletonResourceName"] = BinaryData.FromObjectAsJson(singletonResourceName, options),
                ["resourceName"] = BinaryData.FromObjectAsJson(resourceName, options),
            };

            return new InputDecoratorInfo("Azure.ClientGenerator.Core.@resourceSchema", arguments);

            static BinaryData FromLiteralString(string literal)
                => BinaryData.FromString($"\"{literal}\"");

            static Dictionary<string, string> SerializeResourceMethod(ResourceMethod m)
            {
                var result = new Dictionary<string, string>
                {
                    ["methodId"] = m.InputMethod.CrossLanguageDefinitionId,
                    ["kind"] = m.Kind.ToString(),
                    ["operationPath"] = m.OperationPath,
                    ["operationScope"] = m.OperationScope.ToString()
                };
                if (m.ResourceScope != null)
                {
                    result["resourceScope"] = m.ResourceScope;
                }
                return result;
            }
        }
    }
}
