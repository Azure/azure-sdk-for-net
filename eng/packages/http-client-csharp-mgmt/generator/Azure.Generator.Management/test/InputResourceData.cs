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
            var decorators = new List<InputDecoratorInfo>() { };
            var responseModel = InputFactory.Model(ResourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: false),
                        ],
                        decorators: decorators);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");
            // the http operation parameters
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            var dataOpParameter = InputFactory.BodyParameter("data", responseModel, isRequired: true);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            // the method parameters
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, createMethod, updateMethod],
                crossLanguageDefinitionId: $"Test.{TestClientName}");
            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            decorators.Add(BuildResourceMetadata(responseModel, client, resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, [
                new ResourceMethod(ResourceOperationKind.Get, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, client),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, createMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, client),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, updateMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, client)
            ], "ResponseType"));
            return (client, [responseModel]);
        }

        private static InputDecoratorInfo BuildResourceMetadata(InputModelType resourceModel, InputClient resourceClient, string resourceIdPattern, string resourceType, string? singletonResourceName, ResourceScope resourceScope, IReadOnlyList<ResourceMethod> methods, string? resourceName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
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
