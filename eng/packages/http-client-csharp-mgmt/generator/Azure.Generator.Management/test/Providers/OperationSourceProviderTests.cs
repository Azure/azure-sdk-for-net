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
            var responseModel = InputFactory.Model(ResourceModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);

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
            var getMethod = InputFactory.BasicServiceMethod(
                "getTest",
                InputFactory.Operation(
                    name: "getTest",
                    responses: [responseType],
                    parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter]));

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            var armProviderDecorator = BuildArmProviderSchema(
                responseModel,
                [
                    new ResourceMethod(
                        ResourceOperationKind.Create,
                        createMethod,
                        createMethod.Operation.Path,
                        ResourceScope.ResourceGroup,
                        resourceIdPattern,
                        null!),
                    new ResourceMethod(
                        ResourceOperationKind.Read,
                        getMethod,
                        getMethod.Operation.Path,
                        ResourceScope.ResourceGroup,
                        resourceIdPattern,
                        null!)
                ],
                resourceIdPattern,
                "Microsoft.Tests/tests",
                null,
                ResourceScope.ResourceGroup,
                "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [createMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [responseModel], clients: () => [client]);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);
            var operationSourceProvider = outputLibrary!.OperationSourceDict.Values.FirstOrDefault();
            Assert.NotNull(operationSourceProvider);
            return operationSourceProvider!;
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
                if (m.ResourceScope != null)
                {
                    result["resourceScope"] = m.ResourceScope;
                }
                return result;
            }
        }
    }
}
