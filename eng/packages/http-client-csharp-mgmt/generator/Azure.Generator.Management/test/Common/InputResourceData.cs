// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Tests.Common;
using Microsoft.TypeSpec.Generator.Input;

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
                            InputFactory.Property("name", InputFactory.Primitive.String(), isReadOnly: true),
                        ],
                        decorators: [new InputDecoratorInfo(KnownDecorators.ArmResourceInternal, null)]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: [new InputDecoratorInfo(KnownDecorators.ArmResourceRead, null)]);
            var decorators = new List<InputDecoratorInfo>()
            {
                new InputDecoratorInfo(KnownDecorators.ArmProviderNamespace, new Dictionary<string, BinaryData>())
            };
            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter])],
                crossLanguageDefinitionId: $"Test.{TestClientName}",
                decorators: decorators);
            decorators.Add(BuildResourceMetadata(responseModel, client, "a/test", false, ResourceScope.ResourceGroup));
            return (client, [responseModel]);
        }

        private static InputDecoratorInfo BuildResourceMetadata(InputModelType resourceModel, InputClient resourceClient, string resourceType, bool isSingleton, ResourceScope resourceScope)
        {
            var arguments = new Dictionary<string, BinaryData>
            {
                [KnownDecorators.ResourceModel] = FromLiteralString(resourceModel.CrossLanguageDefinitionId),
                [KnownDecorators.ResourceClient] = FromLiteralString(resourceClient.CrossLanguageDefinitionId),
                [KnownDecorators.ResourceType] = FromLiteralString(resourceType),
                [KnownDecorators.IsSingleton] = BinaryData.FromObjectAsJson<bool>(isSingleton),
                [KnownDecorators.ResourceScope] = FromLiteralString(resourceScope.ToString()),
            };

            return new InputDecoratorInfo(KnownDecorators.ResourceMetadata, arguments);

            static BinaryData FromLiteralString(string literal)
                => BinaryData.FromString($"\"{literal}\"");
        }
    }
}
