// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Tests.Common;
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
                            InputFactory.Property("name", InputFactory.Primitive.String(), isReadOnly: true),
                        ],
                        decorators: decorators);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var subscriptionIdParameter = InputFactory.Parameter("subscriptionId", InputPrimitiveType.String, location: InputRequestLocation.Path, kind: InputParameterKind.Client);
            var resourceGroupParameter = InputFactory.Parameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path, kind: InputParameterKind.Client);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/a/test/{testName}");
            var crossLanguageDefinitionId = Guid.NewGuid().ToString();
            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: crossLanguageDefinitionId)],
                crossLanguageDefinitionId: $"Test.{TestClientName}");
            decorators.Add(BuildResourceMetadata(responseModel, client, "a/test", false, ResourceScope.ResourceGroup, [new ResourceMethod(crossLanguageDefinitionId, ResourceOperationKind.Get)]));
            return (client, [responseModel]);
        }

        private static InputDecoratorInfo BuildResourceMetadata(InputModelType resourceModel, InputClient resourceClient, string resourceType, bool isSingleton, ResourceScope resourceScope, IReadOnlyList<ResourceMethod> methods)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            var arguments = new Dictionary<string, BinaryData>
            {
                ["resourceType"] = FromLiteralString(resourceType),
                ["isSingleton"] = BinaryData.FromObjectAsJson(isSingleton, options),
                ["resourceScope"] = FromLiteralString(resourceScope.ToString()),
                ["methods"] = BinaryData.FromObjectAsJson(methods, options),
            };

            return new InputDecoratorInfo("Azure.ClientGenerator.Core.@resourceSchema", arguments);

            static BinaryData FromLiteralString(string literal)
                => BinaryData.FromString($"\"{literal}\"");
        }
    }
}
