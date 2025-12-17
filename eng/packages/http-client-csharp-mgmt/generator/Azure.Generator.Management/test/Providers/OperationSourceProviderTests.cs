// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class OperationSourceProviderTests
    {
        [TestCase]
        public void Verify_CreateResult()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResult");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.None));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.Name, "ResponseTypeResource");

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_CreateResultAsync()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResultAsync");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Async));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(ValueTask<>));

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        private static MethodProvider GetOperationSourceProviderMethodByName(string methodName)
        {
            OperationSourceProvider resourceProvider = GetOperationSourceProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.NotNull(method);
            return method!;
        }

        private static OperationSourceProvider GetOperationSourceProvider()
        {
            // Create test data with a long-running operation
            const string TestClientName = "TestClient";
            const string ResourceModelName = "ResponseType";
            var decorators = new List<InputDecoratorInfo>();
            var responseModel = InputFactory.Model(ResourceModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: decorators);

            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Create operation parameters
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);

            var createOperation = InputFactory.Operation(
                name: "createTest",
                responses: [responseType],
                parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter],
                path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");

            // Create method parameters
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // Create a long-running operation method
            var lroMetadata = InputFactory.LongRunningServiceMetadata(1, InputFactory.OperationResponse([200], responseModel), null);
            var createMethod = InputFactory.LongRunningServiceMethod(
                "createTest",
                createOperation,
                parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter],
                longRunningServiceMetadata: lroMetadata);

            var client = InputFactory.Client(
                TestClientName,
                methods: [createMethod],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            decorators.Add(BuildResourceMetadata(
                responseModel,
                client,
                resourceIdPattern,
                "Microsoft.Tests/tests",
                null,
                ResourceScope.ResourceGroup,
                [
                    new ResourceMethod(
                        ResourceOperationKind.Create,
                        createMethod,
                        createMethod.Operation.Path,
                        ResourceScope.ResourceGroup,
                        resourceIdPattern,
                        client)
                ],
                "ResponseType"));

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [responseModel], clients: () => [client]);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);
            var operationSourceProvider = outputLibrary!.OperationSourceDict.Values.FirstOrDefault();
            Assert.NotNull(operationSourceProvider);
            return operationSourceProvider!;
        }

        private static InputDecoratorInfo BuildResourceMetadata(
            InputModelType resourceModel,
            InputClient resourceClient,
            string resourceIdPattern,
            string resourceType,
            string? singletonResourceName,
            ResourceScope resourceScope,
            IReadOnlyList<ResourceMethod> methods,
            string? resourceName)
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

        [TestCase]
        public void Verify_NonLro_NonResource_Operation_Creates_OperationSource()
        {
            // Create test data with a non-LRO operation
            const string TestClientName = "TestClient";
            const string ResponseModelName = "NonLroResponseType";

            var responseModel = InputFactory.Model(ResponseModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("result", InputPrimitiveType.String, isReadOnly: true)
                ]);

            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Create operation parameters
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var locationOpParameter = InputFactory.PathParameter("location", InputPrimitiveType.String, isRequired: true);

            var nonLroOperation = InputFactory.Operation(
                name: "performAction",
                responses: [responseType],
                parameters: [subsIdOpParameter, locationOpParameter],
                path: "/subscriptions/{subscriptionId}/providers/Microsoft.Tests/locations/{location}/performAction");

            // Create method parameters
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var locationParameter = InputFactory.MethodParameter("location", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // Create a non-LRO (basic) method
            var nonLroMethod = InputFactory.BasicServiceMethod(
                "performAction",
                nonLroOperation,
                parameters: [subscriptionIdParameter, locationParameter],
                crossLanguageDefinitionId: "Test.performAction");

            var client = InputFactory.Client(
                TestClientName,
                methods: [nonLroMethod],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            // Build decorator for non-resource method
            var nonResourceMethodArgs = new Dictionary<string, BinaryData>
            {
                ["nonResourceMethods"] = BinaryData.FromString($$"""
                    [{
                        "methodId": "{{nonLroMethod.CrossLanguageDefinitionId}}",
                        "operationPath": "{{nonLroOperation.Path}}",
                        "operationScope": "Subscription"
                    }]
                    """)
            };
            var nonResourceMethodDecorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@nonResourceMethodSchema", nonResourceMethodArgs);

            // Add decorator to the client
            var clientWithDecorator = InputFactory.Client(
                TestClientName,
                methods: [nonLroMethod],
                decorators: [nonResourceMethodDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [responseModel],
                clients: () => [clientWithDecorator]);

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            // Verify that an OperationSource was created for the non-LRO non-resource operation
            var operationSourceDict = outputLibrary!.OperationSourceDict;
            Assert.IsNotNull(operationSourceDict);
            Assert.IsTrue(operationSourceDict.Count > 0, "Expected at least one OperationSource to be created");

            // Find the operation source for our response model
            var responseModelType = plugin.Object.TypeFactory.CreateCSharpType(responseModel);
            Assert.IsNotNull(responseModelType);
            Assert.IsTrue(operationSourceDict.ContainsKey(responseModelType!),
                $"Expected OperationSource for {ResponseModelName} to be created");

            var operationSource = operationSourceDict[responseModelType!];
            Assert.IsNotNull(operationSource);
            Assert.AreEqual($"{ResponseModelName}OperationSource", operationSource.Name);
        }
    }
}
