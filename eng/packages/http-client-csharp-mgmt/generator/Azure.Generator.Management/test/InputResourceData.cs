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
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var subscriptionIdParameter = InputFactory.Parameter("subscriptionId", new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid"), location: InputRequestLocation.Path, kind: InputParameterKind.Client);
            var resourceGroupParameter = InputFactory.Parameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path, kind: InputParameterKind.Client);
            var dataParameter = InputFactory.Parameter("data", responseModel, location: InputRequestLocation.Body);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, createMethod, updateMethod],
                crossLanguageDefinitionId: $"Test.{TestClientName}");
            decorators.Add(BuildResourceMetadata(responseModel, client, "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, [
                new ResourceMethod(ResourceOperationKind.Get, getMethod, client),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, client),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, client)
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
                ["methods"] = BinaryData.FromObjectAsJson(methods.Select(m => new Dictionary<string, string>
                {
                    ["id"] = m.InputMethod.CrossLanguageDefinitionId,
                    ["kind"] = m.Kind.ToString()
                }
                ), options),
                ["singletonResourceName"] = BinaryData.FromObjectAsJson(singletonResourceName, options),
                ["resourceName"] = BinaryData.FromObjectAsJson(resourceName, options),
            };

            return new InputDecoratorInfo("Azure.ClientGenerator.Core.@resourceSchema", arguments);

            static BinaryData FromLiteralString(string literal)
                => BinaryData.FromString($"\"{literal}\"");
        }
    }
}
