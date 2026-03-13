// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Common
{
    internal static class InputResourceData
    {
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResource()
        {
            const string TestClientName = "TestClient";
            const string ResourceModelName = "ResponseType";
            var responseModel = InputFactory.Model(ResourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: false),
                        ],
                        decorators: []);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");
            // the http operation parameters
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            var dataOpParameter = InputFactory.BodyParameter("data", responseModel, isRequired: true);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PUT");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
            // the method parameters
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body, isRequired: true);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            var armProviderDecorator = BuildArmProviderSchema(responseModel, [
                new ResourceMethod(ResourceOperationKind.Read, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, createMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, updateMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!)
            ], resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, createMethod, updateMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            return (client, [responseModel]);
        }

        /// <summary>
        /// Creates a client with a resource where PUT/PATCH body parameters are marked as optional in the spec.
        /// This tests that the generator still emits them as required.
        /// </summary>
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResourceOptionalBody()
        {
            const string TestClientName = "TestClient";
            const string ResourceModelName = "ResponseType";
            var responseModel = InputFactory.Model(ResourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: false),
                        ],
                        decorators: []);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            // Body parameter is optional in the spec
            var dataOpParameter = InputFactory.BodyParameter("data", responseModel, isRequired: false);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PUT");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            // Method parameter is also optional
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body, isRequired: false);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            var armProviderDecorator = BuildArmProviderSchema(responseModel, [
                new ResourceMethod(ResourceOperationKind.Read, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, createMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, updateMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!)
            ], resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, createMethod, updateMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            return (client, [responseModel]);
        }

        private static InputDecoratorInfo BuildArmProviderSchema(InputModelType resourceModel, IReadOnlyList<ResourceMethod> methods, string resourceIdPattern, string resourceType, string? singletonResourceName, ResourceScope resourceScope, string? resourceName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            var resourceSchema = new Dictionary<string, object?>
            {
                ["resourceModelId"] = resourceModel.CrossLanguageDefinitionId,
                ["resourceIdPattern"] = resourceIdPattern,
                ["resourceType"] = resourceType,
                ["resourceScope"] = resourceScope.ToString(),
                ["methods"] = methods.Select(SerializeResourceMethod).ToList(),
                ["singletonResourceName"] = singletonResourceName,
                ["resourceName"] = resourceName,
            };

            var arguments = new Dictionary<string, BinaryData>
            {
                ["resources"] = BinaryData.FromObjectAsJson(new[] { resourceSchema }, options),
                ["nonResourceMethods"] = BinaryData.FromObjectAsJson(Array.Empty<object>(), options)
            };

            return new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", arguments);

            static Dictionary<string, string> SerializeResourceMethod(ResourceMethod m)
            {
                var result = new Dictionary<string, string>
                {
                    ["methodId"] = m.InputMethod.CrossLanguageDefinitionId,
                    ["kind"] = m.Kind.ToString(),
                    ["operationPath"] = m.OperationPath,
                    ["operationScope"] = m.OperationScope.ToString()
                };
                if (m.ResourceScopeIdPattern != null)
                {
                    result["resourceScope"] = m.ResourceScopeIdPattern;
                }
                return result;
            }
        }
    }
}
