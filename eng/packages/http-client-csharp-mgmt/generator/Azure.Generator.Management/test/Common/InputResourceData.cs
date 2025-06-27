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
            var operation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}");
            var crossLanguageDefinitionId = Guid.NewGuid().ToString();
            var client = InputFactory.Client(
                TestClientName,
                methods: [InputFactory.BasicServiceMethod("Get", operation, parameters: [testNameParameter], crossLanguageDefinitionId: crossLanguageDefinitionId)],
                crossLanguageDefinitionId: $"Test.{TestClientName}");
            decorators.Add(BuildResourceMetadata(responseModel, client, "a/test", false, ResourceScope.ResourceGroup, [new ResourceMethod(crossLanguageDefinitionId, OperationKind.Get)]));
            return (client, [responseModel]);
        }

        private static InputDecoratorInfo BuildResourceMetadata(InputModelType resourceModel, InputClient resourceClient, string resourceType, bool isSingleton, ResourceScope resourceScope, IReadOnlyList<ResourceMethod> methods)
        {
            var arguments = new Dictionary<string, BinaryData>
            {
                [KnownDecorators.ResourceType] = FromLiteralString(resourceType),
                [KnownDecorators.IsSingleton] = BinaryData.FromObjectAsJson(isSingleton),
                [KnownDecorators.ResourceScope] = FromLiteralString(resourceScope.ToString()),
                [KnownDecorators.Methods] = BinaryData.FromObjectAsJson(methods),
            };

            return new InputDecoratorInfo(KnownDecorators.ResourceMetadata, arguments);

            static BinaryData FromLiteralString(string literal)
                => BinaryData.FromString($"\"{literal}\"");
        }
    }
}
