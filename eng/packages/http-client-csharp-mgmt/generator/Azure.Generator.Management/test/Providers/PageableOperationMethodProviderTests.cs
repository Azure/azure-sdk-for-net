// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class PageableOperationMethodProviderTests
    {
        /// <summary>
        /// Verifies that a paging action operation on a resource does NOT resource-wrap the return type.
        /// The return type should be Pageable{ConfigurationData}, not Pageable{ConfigurationResource}.
        /// </summary>
        [TestCase]
        public void PagingAction_DoesNotResourceWrap_ReturnType()
        {
            SetupPagingActionScenario(out var plugin);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            // Find the parent resource (Server) - it should have the paging action method
            var serverResourceProvider = outputLibrary!.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.Name == "ServerResource");
            Assert.NotNull(serverResourceProvider, "ServerResource provider should exist");

            // Find the sync paging action method, explicitly excluding Async variants
            var listConfigMethod = serverResourceProvider!.Methods
                .FirstOrDefault(m => !m.Signature.Name.EndsWith("Async", StringComparison.OrdinalIgnoreCase)
                    && (m.Signature.Name.StartsWith("GetConfigurations", StringComparison.OrdinalIgnoreCase)
                        || m.Signature.Name.StartsWith("listConfigurations", StringComparison.OrdinalIgnoreCase)));
            Assert.NotNull(listConfigMethod, "Sync paging action method should exist on ServerResource");

            var returnType = listConfigMethod!.Signature.ReturnType;
            Assert.NotNull(returnType);

            // The return type should be Pageable<T> or AsyncPageable<T>
            Assert.IsTrue(
                returnType!.FrameworkType == typeof(Pageable<>) || returnType.FrameworkType == typeof(AsyncPageable<>),
                $"Return type should be Pageable<> or AsyncPageable<>, but was {returnType}");

            // The generic argument should be the data model type, NOT the resource type
            var itemType = returnType.Arguments[0];
            Assert.AreNotEqual("ConfigurationResource", itemType.Name,
                "Paging action should NOT resource-wrap the return type to ConfigurationResource");
            Assert.AreEqual("ConfigurationData", itemType.Name,
                "Paging action should return the raw data type ConfigurationData");
        }

        /// <summary>
        /// Verifies the same for the async variant.
        /// </summary>
        [TestCase]
        public void PagingAction_DoesNotResourceWrap_AsyncReturnType()
        {
            SetupPagingActionScenario(out var plugin);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var serverResourceProvider = outputLibrary!.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.Name == "ServerResource");
            Assert.NotNull(serverResourceProvider);

            // Find async variant
            var asyncMethod = serverResourceProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name.EndsWith("Async", StringComparison.OrdinalIgnoreCase)
                    && (m.Signature.Name.Contains("GetConfigurations", StringComparison.OrdinalIgnoreCase)
                        || m.Signature.Name.Contains("listConfigurations", StringComparison.OrdinalIgnoreCase)));
            Assert.NotNull(asyncMethod, "Async paging action method should exist on ServerResource");

            var returnType = asyncMethod!.Signature.ReturnType;
            Assert.NotNull(returnType);

            Assert.AreEqual(typeof(AsyncPageable<>), returnType!.FrameworkType,
                "Async return type should be AsyncPageable<>");

            var itemType = returnType.Arguments[0];
            Assert.AreNotEqual("ConfigurationResource", itemType.Name,
                "Async paging action should NOT resource-wrap the return type");
            Assert.AreEqual("ConfigurationData", itemType.Name,
                "Async paging action should return the raw data type ConfigurationData");
        }

        /// <summary>
        /// Sets up a scenario with two resources:
        /// - ServerResource (parent) with a Read operation and a paging Action that returns ConfigurationData
        /// - ConfigurationResource (child) with a Read operation
        /// This models the real-world case from the issue: listByServer is an action on ClusterServer
        /// that returns ServerConfiguration items.
        /// </summary>
        private static void SetupPagingActionScenario(
            out Moq.Mock<ManagementClientGenerator> plugin)
        {
            // Create the child resource model (Configuration) - this is what the paging action returns
            var configModel = InputFactory.Model("ConfigurationData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("value", InputPrimitiveType.String, isReadOnly: false),
                ],
                decorators: []);

            // Create the parent resource model (Server)
            var serverModel = InputFactory.Model("ServerData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String, isReadOnly: false),
                ],
                decorators: []);

            // Create the page wrapper model for the paging response
            var pageModel = InputFactory.Model("ConfigurationListResult",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("value", InputFactory.Array(configModel)),
                    InputFactory.Property("nextLink", InputPrimitiveType.Url),
                ]);

            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Common path parameters
            var subsIdParam = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgParam = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var serverNameParam = InputFactory.PathParameter("serverName", InputPrimitiveType.String, isRequired: true);
            var configNameParam = InputFactory.PathParameter("configurationName", InputPrimitiveType.String, isRequired: true);

            // Method parameters
            var subsIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var rgMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var serverNameMethodParam = InputFactory.MethodParameter("serverName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var configNameMethodParam = InputFactory.MethodParameter("configurationName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // ===== Server resource operations =====
            var serverPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}";
            var serverResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: serverModel);

            var getServerOp = InputFactory.Operation(
                name: "getServer",
                responses: [serverResponse],
                parameters: [subsIdParam, rgParam, serverNameParam],
                path: serverPath);

            var getServerMethod = InputFactory.BasicServiceMethod(
                "getServer",
                getServerOp,
                parameters: [serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: "Microsoft.Test.Servers.get");

            // ===== Configuration resource operations =====
            var configPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/configurations/{configurationName}";
            var configResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: configModel);

            var getConfigOp = InputFactory.Operation(
                name: "getConfiguration",
                responses: [configResponse],
                parameters: [subsIdParam, rgParam, serverNameParam, configNameParam],
                path: configPath);

            var getConfigMethod = InputFactory.BasicServiceMethod(
                "getConfiguration",
                getConfigOp,
                parameters: [configNameMethodParam, serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: "Microsoft.Test.Configurations.get");

            // ===== Paging action on Server that returns Configuration items =====
            var listConfigsPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/configurations";
            var listConfigsResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: pageModel);

            var listConfigsOp = InputFactory.Operation(
                name: "listConfigurations",
                responses: [listConfigsResponse],
                parameters: [subsIdParam, rgParam, serverNameParam],
                path: listConfigsPath,
                httpMethod: "POST");

            var pagingMetadata = InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body);

            var listConfigsMethod = InputFactory.PagingServiceMethod(
                "listConfigurations",
                listConfigsOp,
                parameters: [serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                pagingMetadata: pagingMetadata);

            // ===== Build ARM provider schema =====
            var serverResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}";
            var configResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/configurations/{configurationName}";

            var serverDecorator = BuildArmProviderSchema(
                serverModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, getServerMethod, getServerOp.Path, ResourceScope.ResourceGroup, serverResourceIdPattern, null!),
                    // This is the key: listConfigurations is an Action on Server, not a List
                    new ResourceMethod(ResourceOperationKind.Action, listConfigsMethod, listConfigsOp.Path, ResourceScope.ResourceGroup, serverResourceIdPattern, null!),
                ],
                serverResourceIdPattern,
                "Microsoft.Test/servers",
                null,
                ResourceScope.ResourceGroup,
                "Server");

            var configDecorator = BuildArmProviderSchema(
                configModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, getConfigMethod, getConfigOp.Path, ResourceScope.ResourceGroup, configResourceIdPattern, null!),
                ],
                configResourceIdPattern,
                "Microsoft.Test/servers/configurations",
                null,
                ResourceScope.ResourceGroup,
                "Configuration");

            var client = InputFactory.Client(
                "TestClient",
                methods: [getServerMethod, getConfigMethod, listConfigsMethod],
                decorators: [serverDecorator, configDecorator],
                crossLanguageDefinitionId: "Test.TestClient");

            plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [serverModel, configModel, pageModel],
                clients: () => [client]);
        }

        private static InputDecoratorInfo BuildArmProviderSchema(
            InputModelType resourceModel,
            IReadOnlyList<ResourceMethod> methods,
            string resourceIdPattern,
            string resourceType,
            string? singletonResourceName,
            ResourceScope resourceScope,
            string? resourceName)
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
                if (m.ResourceScopeIdPattern != null)
                {
                    result["resourceScope"] = m.ResourceScopeIdPattern;
                }
                return result;
            }
        }
    }
}
