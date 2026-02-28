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
            var responseModel = InputFactory.Model(ResourceModelName,
                        usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                        properties:
                        [
                            InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                            InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: false),
                        ],
                        decorators: []);
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
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body, isRequired: true);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            var armProviderDecorator = BuildArmProviderSchema(responseModel, [
                new ResourceMethod(ResourceOperationKind.Read, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, createMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, updateMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!)
            ], resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, createMethod, updateMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            return (client, [responseModel]);
        }

        /// <summary>
        /// Builds a client with a single scope URL (Extension-scope) non-resource list operation.
        /// The operation path starts with a variable segment: /{resourceId}/providers/Microsoft.Tests/backupInstances.
        /// This verifies that such operations are placed in MockableArmClientProvider (not a per-scope mockable resource).
        /// </summary>
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithScopeUrlOperation()
        {
            const string TestClientName = "TestClient";
            const string ResponseModelName = "BackupInstance";
            // Use a fixed, deterministic ID so tests are repeatable and easier to debug.
            const string ScopeUrlMethodId = "Test.TestClient.listBackupInstances";

            var responseModel = InputFactory.Model(ResponseModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);

            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: responseModel);

            // Scope URL path: starts with variable segment /{resourceId}/...
            const string scopeUrlPath = "/{resourceId}/providers/Microsoft.Tests/backupInstances";
            var resourceIdOpParameter = InputFactory.PathParameter("resourceId", InputPrimitiveType.String, isRequired: true);
            var listOperation = InputFactory.Operation(
                name: "listBackupInstances",
                responses: [responseType],
                parameters: [resourceIdOpParameter],
                path: scopeUrlPath);

            var resourceIdMethodParameter = InputFactory.MethodParameter("resourceId", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var listMethod = InputFactory.BasicServiceMethod(
                "listBackupInstances",
                listOperation,
                parameters: [resourceIdMethodParameter],
                crossLanguageDefinitionId: ScopeUrlMethodId);

            // Build decorator: no resources, one non-resource method with Extension scope
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            var nonResourceMethodEntry = new Dictionary<string, string>
            {
                ["methodId"] = ScopeUrlMethodId,
                ["operationPath"] = scopeUrlPath,
                ["operationScope"] = ResourceScope.Extension.ToString()
            };

            var arguments = new Dictionary<string, BinaryData>
            {
                ["resources"] = BinaryData.FromObjectAsJson(Array.Empty<object>(), options),
                ["nonResourceMethods"] = BinaryData.FromObjectAsJson(new[] { nonResourceMethodEntry }, options)
            };

            var armProviderDecorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", arguments);

            var client = InputFactory.Client(
                TestClientName,
                methods: [listMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            return (client, [responseModel]);
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
