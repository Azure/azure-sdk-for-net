// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceProviderTests
    {
        private const string TestClientName = "TestClient";

        [TestCase]
        public void Verify_ResourceProviderGeneration()
        {
            var resourceModelName = "ResponseType";
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
            var operation = InputFactory.Operation(name: "GetOperation", responses: [responseType], parameters: [testNameParameter], path: "/providers/a/test/{testName}");
            var client = InputFactory.Client(TestClientName, operations: [operation], decorators: [new InputDecoratorInfo("Azure.ResourceManager.@armProviderNamespace", null)]);
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => [responseModel], clients: () => [client]);

            var resourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p.Name == "ResponseTypeResource") as ResourceProvider;
            Assert.NotNull(resourceProvider);
            var codeFile = new TypeProviderWriter(resourceProvider!).Write();
            var result = codeFile.Content;

            var exptected = Helpers.GetExpectedFromFile();

            Assert.AreEqual(exptected, result);
        }
    }
}
