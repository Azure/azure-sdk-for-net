// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class MultiScopeExtensionResourceTests
    {
        /// <summary>
        /// Verifies that an extension resource with Extension scope (as emitted for multi-scope
        /// resources like ConfigurationAssignment) is correctly modeled as an extension resource
        /// with methods on MockableArmClient.
        /// </summary>
        [TestCase]
        public void Verify_ExtensionScopeResource_IsModeledAsExtensionResource()
        {
            var (client, models) = BuildExtensionResourceClient(ResourceScope.Extension);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.IsNotNull(outputLibrary);

            // Verify a ResourceClientProvider is created and marked as extension
            var resources = outputLibrary!.TypeProviders.OfType<ResourceClientProvider>().ToList();
            Assert.AreEqual(1, resources.Count, "Should generate exactly one resource");
            var resource = resources[0];
            Assert.IsTrue(resource.IsExtensionResource, "Resource should be an extension resource");
            Assert.AreEqual(ResourceScope.Extension, resource.ResourceScope);
            Assert.AreEqual("ConfigurationAssignmentResource", resource.Name);

            // Extension scope resources should produce a MockableArmClientProvider
            var mockableArmClient = outputLibrary.TypeProviders
                .OfType<MockableArmClientProvider>().FirstOrDefault();
            Assert.IsNotNull(mockableArmClient, "Extension resource should produce a MockableArmClientProvider");

            // The MockableArmClient should have methods for the extension resource
            Assert.IsTrue(mockableArmClient!.Methods.Count > 0,
                "MockableArmClientProvider should have methods for the extension resource");

            // There should be NO MockableResourceProvider for ResourceGroup or Subscription scope
            // because all operations are Extension-scoped
            var mockableByScope = outputLibrary.TypeProviders
                .OfType<MockableResourceProvider>()
                .Where(m => m is not MockableArmClientProvider)
                .ToList();
            foreach (var mockable in mockableByScope)
            {
                // Mockable resources for RG/Sub/etc should have no methods since this resource is Extension-only
                Assert.AreEqual(0, mockable.Methods.Count,
                    $"MockableResourceProvider '{mockable.Name}' should have no methods for an Extension-only resource");
            }
        }

        private static (InputClient Client, IReadOnlyList<InputModelType> Models) BuildExtensionResourceClient(ResourceScope scope)
        {
            const string resourceModelName = "ConfigurationAssignment";
            var resourceModel = InputFactory.Model(resourceModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);

            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: resourceModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Path parameters for the multi-scope extension pattern
            var subsIdParam = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgParam = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var providerNameParam = InputFactory.PathParameter("providerName", InputPrimitiveType.String, isRequired: true);
            var resourceTypeParam = InputFactory.PathParameter("resourceType", InputPrimitiveType.String, isRequired: true);
            var resourceNameParam = InputFactory.PathParameter("resourceName", InputPrimitiveType.String, isRequired: true);
            var configNameParam = InputFactory.PathParameter("configurationAssignmentName", InputPrimitiveType.String, isRequired: true);
            var dataParam = InputFactory.BodyParameter("data", resourceModel, isRequired: true);

            // The multi-provider path pattern: parent resource has a variable provider name
            var extensionPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}";
            var resourceIdPattern = extensionPath;

            var getOperation = InputFactory.Operation(
                name: "get",
                responses: [responseType],
                parameters: [subsIdParam, rgParam, providerNameParam, resourceTypeParam, resourceNameParam, configNameParam],
                path: extensionPath);

            var createOperation = InputFactory.Operation(
                name: "createOrUpdate",
                responses: [responseType],
                parameters: [subsIdParam, rgParam, providerNameParam, resourceTypeParam, resourceNameParam, configNameParam, dataParam],
                path: extensionPath);

            var deleteOperation = InputFactory.Operation(
                name: "delete",
                responses: [InputFactory.OperationResponse(statusCodes: [200])],
                parameters: [subsIdParam, rgParam, providerNameParam, resourceTypeParam, resourceNameParam, configNameParam],
                path: extensionPath);

            // Method parameters
            var subsIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var rgMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var providerNameMethodParam = InputFactory.MethodParameter("providerName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var resourceTypeMethodParam = InputFactory.MethodParameter("resourceType", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var resourceNameMethodParam = InputFactory.MethodParameter("resourceName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var configNameMethodParam = InputFactory.MethodParameter("configurationAssignmentName", InputPrimitiveType.String, location: InputRequestLocation.Path, isRequired: true);
            var dataMethodParam = InputFactory.MethodParameter("data", resourceModel, location: InputRequestLocation.Body, isRequired: true);

            var getMethod = InputFactory.BasicServiceMethod("get", getOperation,
                parameters: [configNameMethodParam, providerNameMethodParam, resourceTypeMethodParam, resourceNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var createMethod = InputFactory.BasicServiceMethod("createOrUpdate", createOperation,
                parameters: [configNameMethodParam, providerNameMethodParam, resourceTypeMethodParam, resourceNameMethodParam, subsIdMethodParam, rgMethodParam, dataMethodParam],
                crossLanguageDefinitionId: Guid.NewGuid().ToString());
            var deleteMethod = InputFactory.BasicServiceMethod("delete", deleteOperation,
                parameters: [configNameMethodParam, providerNameMethodParam, resourceTypeMethodParam, resourceNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: Guid.NewGuid().ToString());

            var armProviderDecorator = BuildArmProviderSchema(resourceModel, [
                new ResourceMethod(ResourceOperationKind.Read, getMethod, getMethod.Operation.Path, scope, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Create, createMethod, createMethod.Operation.Path, scope, resourceIdPattern, null!),
                new ResourceMethod(ResourceOperationKind.Delete, deleteMethod, deleteMethod.Operation.Path, scope, resourceIdPattern, null!),
            ], resourceIdPattern, "Microsoft.Maintenance/configurationAssignments", null, scope, "ConfigurationAssignment");

            var client = InputFactory.Client(
                "MaintenanceClient",
                methods: [getMethod, createMethod, deleteMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: "Test.MaintenanceClient");

            return (client, [resourceModel]);
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
