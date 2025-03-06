// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;

namespace Azure.Generator.Tests.Common
{
    internal static class InputData
    {
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResource()
        {
            const string TestClientName = "TestClient";
            const string resourceModelName = "ResponseType";
            var responseModel = InputFactory.Model(resourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String),
                            InputFactory.Property("type", InputPrimitiveType.String),
                            InputFactory.Property("name", InputFactory.Primitive.String()),
                        ]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var testNameParameter = InputFactory.Parameter("testName", InputPrimitiveType.String, location: RequestLocation.Path);
            var operation = InputFactory.Operation(name: "Get", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}", decorators: [new InputDecoratorInfo("Azure.ResourceManager.@armResourceRead", null)]);
            var client = InputFactory.Client(TestClientName, operations: [operation], decorators: [new InputDecoratorInfo("Azure.ResourceManager.@armProviderNamespace", null)]);
            return (client, [responseModel]);
        }
    }
}
