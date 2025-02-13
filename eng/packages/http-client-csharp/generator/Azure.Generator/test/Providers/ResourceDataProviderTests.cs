// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Providers;
using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Linq;

namespace Azure.Generator.Tests.Providers
{
    internal class ResourceDataProviderTests
    {
        private const string TestClientName = "TestClient";

        [TestCase]
        public void ValidateResourceDataProviderIsGenerated()
        {
            var resourceModelName = "responseType";
            var responseModel = InputFactory.Model(resourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String),
                            InputFactory.Property("type", InputPrimitiveType.String),
                            InputFactory.Property("name", InputFactory.Primitive.String()),
                        ]);
            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var operation = InputFactory.Operation(name: "GetOperation", responses: [responseType], path: "/providers/a");
            var client = InputFactory.Client(TestClientName, operations: [operation]);
            var plugin = MockHelpers.LoadMockPlugin(inputModels: () => [responseModel], clients: () => [client]);

            var resourceDataProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p.Name == "ResponseTypeData") as ModelProvider;
            Assert.NotNull(resourceDataProvider);
            Assert.IsTrue(resourceDataProvider is ResourceDataProvider);

            var serializationProvider = resourceDataProvider?.SerializationProviders.FirstOrDefault();
            Assert.NotNull(serializationProvider);
            Assert.IsTrue(serializationProvider is ResourceDataSerializationProvider);
        }
    }
}
