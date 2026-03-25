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
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PUT");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
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
        /// Creates a client with a resource where PUT/PATCH body parameters are marked as optional in the spec.
        /// This tests that the generator still emits them as required.
        /// </summary>
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResourceOptionalBody()
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
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            // Body parameter is optional in the spec
            var dataOpParameter = InputFactory.BodyParameter("data", responseModel, isRequired: false);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PUT");
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            // Method parameter is also optional
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body, isRequired: false);
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
        /// Creates a client with a resource where the PATCH operation has no request body and no PUT operation exists.
        /// Tag methods should NOT be generated because the bodyless PATCH cannot carry tag changes
        /// and there is no PUT to fall back to.
        /// </summary>
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResourceBodylessPatch()
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
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            // PATCH operation with NO body parameter
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            // Update method has no body parameter
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}";
            var armProviderDecorator = BuildArmProviderSchema(responseModel, [
                new ResourceMethod(ResourceOperationKind.Read, getMethod, getMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Update, updateMethod, updateMethod.Operation.Path, ResourceScope.ResourceGroup, resourceIdPattern, null!)
            ], resourceIdPattern, "Microsoft.Tests/tests", null, ResourceScope.ResourceGroup, "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [getMethod, updateMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            return (client, [responseModel]);
        }

        /// <summary>
        /// Creates a client with a resource where the PATCH operation has no request body but a PUT operation exists.
        /// Tag methods should still be generated using the PUT operation as fallback.
        /// </summary>
        public static (InputClient InputClient, IReadOnlyList<InputModelType> InputModels) ClientWithResourceBodylessPatchAndPut()
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
            var subsIdOpParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var testNameOpParameter = InputFactory.PathParameter("testName", InputPrimitiveType.String, isRequired: true);
            var dataOpParameter = InputFactory.BodyParameter("data", responseModel, isRequired: true);
            var getOperation = InputFactory.Operation(name: "get", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}");
            // PUT operation WITH body parameter
            var createOperation = InputFactory.Operation(name: "createTest", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter, dataOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PUT");
            // PATCH operation with NO body parameter
            var updateOperation = InputFactory.Operation(name: "update", responses: [responseType], parameters: [subsIdOpParameter, rgOpParameter, testNameOpParameter], path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/tests/{testName}", httpMethod: "PATCH");
            var subscriptionIdParameter = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParameter = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var testNameParameter = InputFactory.MethodParameter("testName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var dataParameter = InputFactory.MethodParameter("data", responseModel, location: InputRequestLocation.Body, isRequired: true);
            var getMethod = InputFactory.BasicServiceMethod("get", getOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createTest", createOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter, dataParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            // Update method has no body parameter
            var updateMethod = InputFactory.BasicServiceMethod("update", updateOperation, parameters: [testNameParameter, subscriptionIdParameter, resourceGroupParameter], crossLanguageDefinitionId: Guid.NewGuid().ToString());

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
        /// Creates a parent resource with a nested child resource that has an extra path parameter.
        /// This tests that BuildGetChildResourceMethods correctly forwards path parameters
        /// to the child collection constructor and Get methods.
        /// Parent: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/parents/{parentName}
        /// Child:  .../parents/{parentName}/nestedTypes/{nestedTypeName}/children/{childName}
        /// The child has one extra path parameter (nestedTypeName) between parent and child.
        /// </summary>
        public static (InputClient ParentClient, InputClient ChildClient, IReadOnlyList<InputModelType> InputModels) ClientWithNestedChildResource()
        {
            const string ParentClientName = "ParentClient";
            const string ChildClientName = "ChildClient";

            // Parent resource model
            var parentModel = InputFactory.Model("ParentType",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String), isReadOnly: false),
                ],
                decorators: []);

            // Child resource model
            var childModel = InputFactory.Model("ChildType",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);

            var parentResponseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: parentModel);
            var childResponseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: childModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Parent operation parameters
            var subsIdOpParam = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgOpParam = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var parentNameOpParam = InputFactory.PathParameter("parentName", InputPrimitiveType.String, isRequired: true);
            var parentDataOpParam = InputFactory.BodyParameter("data", parentModel, isRequired: true);

            // Child operation parameters (includes nestedTypeName as extra path param)
            var nestedTypeNameOpParam = InputFactory.PathParameter("nestedTypeName", InputPrimitiveType.String, isRequired: true);
            var childNameOpParam = InputFactory.PathParameter("childName", InputPrimitiveType.String, isRequired: true);

            var parentIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/parents/{parentName}";
            var childIdPattern = parentIdPattern + "/nestedTypes/{nestedTypeName}/children/{childName}";

            // Parent operations
            var parentGetOp = InputFactory.Operation(name: "get", responses: [parentResponseType], parameters: [subsIdOpParam, rgOpParam, parentNameOpParam], path: parentIdPattern);
            var parentCreateOp = InputFactory.Operation(name: "createParent", responses: [parentResponseType], parameters: [subsIdOpParam, rgOpParam, parentNameOpParam, parentDataOpParam], path: parentIdPattern, httpMethod: "PUT");

            // Child operations
            var childGetOp = InputFactory.Operation(name: "get", responses: [childResponseType], parameters: [subsIdOpParam, rgOpParam, parentNameOpParam, nestedTypeNameOpParam, childNameOpParam], path: childIdPattern);
            var childDataOpParam = InputFactory.BodyParameter("data", childModel, isRequired: true);
            var childCreateOp = InputFactory.Operation(name: "createChild", responses: [childResponseType], parameters: [subsIdOpParam, rgOpParam, parentNameOpParam, nestedTypeNameOpParam, childNameOpParam, childDataOpParam], path: childIdPattern, httpMethod: "PUT");

            // List operation for the child (needed so the collection detects path parameters)
            var childListPath = parentIdPattern + "/nestedTypes/{nestedTypeName}/children";
            var childPageModel = InputFactory.Model("ChildListResult",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("value", InputFactory.Array(childModel)),
                    InputFactory.Property("nextLink", InputPrimitiveType.Url),
                ]);
            var childListOp = InputFactory.Operation(name: "listByParent", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: childPageModel)], parameters: [subsIdOpParam, rgOpParam, parentNameOpParam, nestedTypeNameOpParam], path: childListPath);

            // Parent method parameters
            var subscriptionIdParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var parentNameParam = InputFactory.MethodParameter("parentName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var parentDataParam = InputFactory.MethodParameter("data", parentModel, location: InputRequestLocation.Body, isRequired: true);

            // Child method parameters
            var nestedTypeNameParam = InputFactory.MethodParameter("nestedTypeName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var childNameParam = InputFactory.MethodParameter("childName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var childDataParam = InputFactory.MethodParameter("data", childModel, location: InputRequestLocation.Body, isRequired: true);

            // Parent service methods
            var parentGetMethod = InputFactory.BasicServiceMethod("get", parentGetOp, parameters: [parentNameParam, subscriptionIdParam, resourceGroupParam], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var parentCreateMethod = InputFactory.BasicServiceMethod("createParent", parentCreateOp, parameters: [parentNameParam, subscriptionIdParam, resourceGroupParam, parentDataParam], crossLanguageDefinitionId: Guid.NewGuid().ToString());

            // Child service methods
            var childGetMethod = InputFactory.BasicServiceMethod("get", childGetOp, parameters: [childNameParam, nestedTypeNameParam, parentNameParam, subscriptionIdParam, resourceGroupParam], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var childCreateMethod = InputFactory.BasicServiceMethod("createChild", childCreateOp, parameters: [childNameParam, nestedTypeNameParam, parentNameParam, subscriptionIdParam, resourceGroupParam, childDataParam], crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var childListPagingMetadata = InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body);
            var childListMethod = InputFactory.PagingServiceMethod("listByParent", childListOp, parameters: [nestedTypeNameParam, parentNameParam, subscriptionIdParam, resourceGroupParam], pagingMetadata: childListPagingMetadata);

            // Build multi-resource schema
            var armProviderDecorator = BuildArmProviderSchemaMultiResource([
                new ResourceSchemaInput(parentModel, [
                    new ResourceMethod(ResourceOperationKind.Read, parentGetMethod, parentGetOp.Path, ResourceScope.ResourceGroup, parentIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Create, parentCreateMethod, parentCreateOp.Path, ResourceScope.ResourceGroup, parentIdPattern, null!)
                ], parentIdPattern, "Microsoft.Tests/parents", null, ResourceScope.ResourceGroup, "ParentType", null),
                new ResourceSchemaInput(childModel, [
                    new ResourceMethod(ResourceOperationKind.Read, childGetMethod, childGetOp.Path, ResourceScope.ResourceGroup, childIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Create, childCreateMethod, childCreateOp.Path, ResourceScope.ResourceGroup, childIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.List, childListMethod, childListPath, ResourceScope.ResourceGroup, parentIdPattern, null!)
                ], childIdPattern, "Microsoft.Tests/parents/nestedTypes/children", null, ResourceScope.ResourceGroup, "ChildType", parentIdPattern)
            ]);

            var parentClient = InputFactory.Client(
                ParentClientName,
                methods: [parentGetMethod, parentCreateMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{ParentClientName}");

            var childClient = InputFactory.Client(
                ChildClientName,
                methods: [childGetMethod, childCreateMethod, childListMethod],
                decorators: [],
                crossLanguageDefinitionId: $"Test.{ChildClientName}");

            return (parentClient, childClient, [parentModel, childModel, childPageModel]);
        }

        private static InputDecoratorInfo BuildArmProviderSchema(InputModelType resourceModel, IReadOnlyList<ResourceMethod> methods, string resourceIdPattern, string resourceType, string? singletonResourceName, ResourceScope resourceScope, string? resourceName)
        {
            return BuildArmProviderSchemaMultiResource([
                new ResourceSchemaInput(resourceModel, methods, resourceIdPattern, resourceType, singletonResourceName, resourceScope, resourceName, null)
            ]);
        }

        private static InputDecoratorInfo BuildArmProviderSchemaMultiResource(IReadOnlyList<ResourceSchemaInput> resources)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            var resourceSchemas = resources.Select(r =>
            {
                var schema = new Dictionary<string, object?>
                {
                    ["resourceModelId"] = r.ResourceModel.CrossLanguageDefinitionId,
                    ["resourceIdPattern"] = r.ResourceIdPattern,
                    ["resourceType"] = r.ResourceType,
                    ["resourceScope"] = r.ResourceScope.ToString(),
                    ["methods"] = r.Methods.Select(SerializeResourceMethod).ToList(),
                    ["singletonResourceName"] = r.SingletonResourceName,
                    ["resourceName"] = r.ResourceName,
                };
                if (r.ParentResourceId is not null)
                {
                    schema["parentResourceId"] = r.ParentResourceId;
                }
                return schema;
            }).ToArray();

            var arguments = new Dictionary<string, BinaryData>
            {
                ["resources"] = BinaryData.FromObjectAsJson(resourceSchemas, options),
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
                if (m.ResourceScopeIdPattern != null)
                {
                    result["resourceScope"] = m.ResourceScopeIdPattern;
                }
                return result;
            }
        }

        private record ResourceSchemaInput(
            InputModelType ResourceModel,
            IReadOnlyList<ResourceMethod> Methods,
            string ResourceIdPattern,
            string ResourceType,
            string? SingletonResourceName,
            ResourceScope ResourceScope,
            string? ResourceName,
            string? ParentResourceId);
    }
}
