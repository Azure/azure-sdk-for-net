// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Providers
{
    /// <summary>
    /// Tests the resource wrapping rule: when a data type is used by exactly one resource,
    /// wrap the return type to that resource type. When the data type is shared by multiple
    /// resources, return the raw data type to avoid arbitrarily picking one resource.
    /// This rule applies universally to all operation types.
    /// </summary>
    internal class ResourceWrappingTests
    {
        // ===== Paging Action: Single resource -> wraps =====

        [TestCase]
        public void PagingAction_SingleResource_Wraps_Sync()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: true, sharedDataType: false, out var plugin);
            var returnType = FindSyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(Pageable<>), returnType!.FrameworkType,
                $"Sync return type should be Pageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationResource", returnType.Arguments[0].Name,
                "Single-resource data type should be resource-wrapped");
        }

        [TestCase]
        public void PagingAction_SingleResource_Wraps_Async()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: true, sharedDataType: false, out var plugin);
            var returnType = FindAsyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(AsyncPageable<>), returnType!.FrameworkType,
                $"Async return type should be AsyncPageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationResource", returnType.Arguments[0].Name,
                "Single-resource data type should be resource-wrapped");
        }

        // ===== Paging Action: Shared data type -> does NOT wrap =====

        [TestCase]
        public void PagingAction_SharedDataType_DoesNotWrap_Sync()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: true, sharedDataType: true, out var plugin);
            var returnType = FindSyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(Pageable<>), returnType!.FrameworkType,
                $"Sync return type should be Pageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationData", returnType.Arguments[0].Name,
                "Shared data type should NOT be resource-wrapped");
        }

        [TestCase]
        public void PagingAction_SharedDataType_DoesNotWrap_Async()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: true, sharedDataType: true, out var plugin);
            var returnType = FindAsyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(AsyncPageable<>), returnType!.FrameworkType,
                $"Async return type should be AsyncPageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationData", returnType.Arguments[0].Name,
                "Shared data type should NOT be resource-wrapped");
        }

        // ===== Paging List: Single resource -> wraps =====

        [TestCase]
        public void PagingList_SingleResource_Wraps_Sync()
        {
            SetupScenario(ResourceOperationKind.List, isPaging: true, sharedDataType: false, out var plugin);
            var returnType = FindSyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(Pageable<>), returnType!.FrameworkType,
                $"Sync return type should be Pageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationResource", returnType.Arguments[0].Name,
                "Single-resource data type should be resource-wrapped for List operations");
        }

        // ===== Paging List: Shared data type -> does NOT wrap =====

        [TestCase]
        public void PagingList_SharedDataType_DoesNotWrap_Sync()
        {
            SetupScenario(ResourceOperationKind.List, isPaging: true, sharedDataType: true, out var plugin);
            var returnType = FindSyncMethodReturnType(plugin, "ServerResource", "GetConfigurations", "listConfigurations");

            Assert.AreEqual(typeof(Pageable<>), returnType!.FrameworkType,
                $"Sync return type should be Pageable<>, but was {returnType}");
            Assert.AreEqual("ConfigurationData", returnType.Arguments[0].Name,
                "Shared data type should NOT be resource-wrapped for List operations");
        }

        // ===== Non-paging Action (returns single item): Single resource -> wraps =====

        [TestCase]
        public void NonPagingAction_SingleResource_Wraps_Sync()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: false, sharedDataType: false, out var plugin);
            var method = FindSyncMethod(plugin, "ServerResource", "GetConfigurations", "listConfigurations");
            Assert.NotNull(method, "Sync non-paging action method should exist on ServerResource");

            var returnType = method!.Signature.ReturnType;
            Assert.NotNull(returnType);

            // Non-paging action returns a single item, not pageable
            Assert.AreNotEqual(typeof(Pageable<>), returnType!.FrameworkType, "Non-paging action should not return Pageable<>");
            // The return type should reference ConfigurationResource (wrapped)
            AssertReturnTypeContains(returnType, "ConfigurationResource",
                "Single-resource data type should be resource-wrapped for non-paging actions");
        }

        // ===== Non-paging Action: Shared data type -> does NOT wrap =====

        [TestCase]
        public void NonPagingAction_SharedDataType_DoesNotWrap_Sync()
        {
            SetupScenario(ResourceOperationKind.Action, isPaging: false, sharedDataType: true, out var plugin);
            var method = FindSyncMethod(plugin, "ServerResource", "GetConfigurations", "listConfigurations");
            Assert.NotNull(method, "Sync non-paging action method should exist on ServerResource");

            var returnType = method!.Signature.ReturnType;
            Assert.NotNull(returnType);

            // The return type should reference ConfigurationData (raw), not a resource type
            AssertReturnTypeDoesNotContain(returnType!, "ConfigurationResource",
                "Shared data type should NOT be resource-wrapped for non-paging actions");
            AssertReturnTypeDoesNotContain(returnType!, "AltConfigurationResource",
                "Shared data type should NOT wrap to alternate resource type");
        }

        #region Helper Methods

        private static CSharpType FindSyncMethodReturnType(
            Moq.Mock<ManagementClientGenerator> plugin,
            string resourceName,
            params string[] methodNamePrefixes)
        {
            var method = FindSyncMethod(plugin, resourceName, methodNamePrefixes);
            Assert.NotNull(method, $"Sync method should exist on {resourceName}");
            var returnType = method!.Signature.ReturnType;
            Assert.NotNull(returnType);
            return returnType!;
        }

        private static CSharpType FindAsyncMethodReturnType(
            Moq.Mock<ManagementClientGenerator> plugin,
            string resourceName,
            params string[] methodNamePrefixes)
        {
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var resourceProvider = outputLibrary!.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.Name == resourceName);
            Assert.NotNull(resourceProvider, $"{resourceName} provider should exist");

            var asyncMethod = resourceProvider!.Methods
                .FirstOrDefault(m => m.Signature.Name.EndsWith("Async", StringComparison.OrdinalIgnoreCase)
                    && methodNamePrefixes.Any(prefix =>
                        m.Signature.Name.Contains(prefix, StringComparison.OrdinalIgnoreCase)));
            Assert.NotNull(asyncMethod, $"Async method should exist on {resourceName}");

            var returnType = asyncMethod!.Signature.ReturnType;
            Assert.NotNull(returnType);
            return returnType!;
        }

        private static MethodProvider? FindSyncMethod(
            Moq.Mock<ManagementClientGenerator> plugin,
            string resourceName,
            params string[] methodNamePrefixes)
        {
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var resourceProvider = outputLibrary!.TypeProviders
                .OfType<ResourceClientProvider>()
                .FirstOrDefault(p => p.Name == resourceName);
            Assert.NotNull(resourceProvider, $"{resourceName} provider should exist");

            return resourceProvider!.Methods
                .FirstOrDefault(m => !m.Signature.Name.EndsWith("Async", StringComparison.OrdinalIgnoreCase)
                    && methodNamePrefixes.Any(prefix =>
                        m.Signature.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)));
        }

        /// <summary>
        /// Asserts that the return type (possibly generic like Response{T}) contains a type argument
        /// with the given name.
        /// </summary>
        private static void AssertReturnTypeContains(CSharpType returnType, string expectedTypeName, string message)
        {
            if (returnType.Name == expectedTypeName)
                return;
            if (returnType.Arguments.Any(arg => arg.Name == expectedTypeName))
                return;
            Assert.Fail($"{message}. Return type was {returnType} with arguments [{string.Join(", ", returnType.Arguments.Select(a => a.Name))}]");
        }

        /// <summary>
        /// Asserts that the return type does NOT contain a type argument with the given name.
        /// </summary>
        private static void AssertReturnTypeDoesNotContain(CSharpType returnType, string unexpectedTypeName, string message)
        {
            Assert.AreNotEqual(unexpectedTypeName, returnType.Name, message);
            Assert.IsFalse(returnType.Arguments.Any(arg => arg.Name == unexpectedTypeName),
                $"{message}. Return type was {returnType} with arguments [{string.Join(", ", returnType.Arguments.Select(a => a.Name))}]");
        }

        #endregion

        #region Scenario Setup

        /// <summary>
        /// Sets up a test scenario with configurable operation kind, paging, and shared data type.
        /// </summary>
        /// <param name="operationKind">The ResourceOperationKind for the "listConfigurations" method on Server.</param>
        /// <param name="isPaging">If true, creates a paging method; if false, creates a basic (non-paging) method.</param>
        /// <param name="sharedDataType">If true, adds a second resource (AltConfiguration) that shares ConfigurationData.</param>
        /// <param name="plugin">Output mock plugin.</param>
        private static void SetupScenario(
            ResourceOperationKind operationKind,
            bool isPaging,
            bool sharedDataType,
            out Moq.Mock<ManagementClientGenerator> plugin)
        {
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

            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            var subsIdParam = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgParam = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var serverNameParam = InputFactory.PathParameter("serverName", InputPrimitiveType.String, isRequired: true);
            var configNameParam = InputFactory.PathParameter("configurationName", InputPrimitiveType.String, isRequired: true);

            var subsIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var rgMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var serverNameMethodParam = InputFactory.MethodParameter("serverName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var configNameMethodParam = InputFactory.MethodParameter("configurationName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // ===== Server resource: Read =====
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

            // ===== Configuration resource: Read =====
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

            // ===== The operation under test: listConfigurations on Server =====
            var listConfigsPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/configurations";

            InputServiceMethod listConfigsMethod;
            var inputModels = new List<InputModelType> { serverModel, configModel };

            if (isPaging)
            {
                var pageModel = InputFactory.Model("ConfigurationListResult",
                    usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                    properties:
                    [
                        InputFactory.Property("value", InputFactory.Array(configModel)),
                        InputFactory.Property("nextLink", InputPrimitiveType.Url),
                    ]);
                inputModels.Add(pageModel);

                var listConfigsResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: pageModel);

                var listConfigsOp = InputFactory.Operation(
                    name: "listConfigurations",
                    responses: [listConfigsResponse],
                    parameters: [subsIdParam, rgParam, serverNameParam],
                    path: listConfigsPath,
                    httpMethod: "POST");

                var pagingMetadata = InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body);

                listConfigsMethod = InputFactory.PagingServiceMethod(
                    "listConfigurations",
                    listConfigsOp,
                    parameters: [serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                    pagingMetadata: pagingMetadata);
            }
            else
            {
                var listConfigsResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: configModel);

                var listConfigsOp = InputFactory.Operation(
                    name: "listConfigurations",
                    responses: [listConfigsResponse],
                    parameters: [subsIdParam, rgParam, serverNameParam],
                    path: listConfigsPath,
                    httpMethod: "POST");

                listConfigsMethod = InputFactory.BasicServiceMethod(
                    "listConfigurations",
                    listConfigsOp,
                    parameters: [serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                    crossLanguageDefinitionId: "Microsoft.Test.Servers.listConfigurations");
            }

            // ===== Build ARM provider schemas =====
            var serverResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}";
            var configResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/configurations/{configurationName}";

            var serverDecorator = BuildArmProviderSchema(
                serverModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, getServerMethod, new RequestPathPattern(getServerOp.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(serverResourceIdPattern), null), null!),
                    new ResourceMethod(operationKind, listConfigsMethod, new RequestPathPattern(listConfigsPath), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(serverResourceIdPattern), null), null!),
                ],
                serverResourceIdPattern,
                "Microsoft.Test/servers",
                null,
                ResourceScope.ResourceGroup,
                "Server");

            var configDecorator = BuildArmProviderSchema(
                configModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, getConfigMethod, new RequestPathPattern(getConfigOp.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(configResourceIdPattern), null), null!),
                ],
                configResourceIdPattern,
                "Microsoft.Test/servers/configurations",
                null,
                ResourceScope.ResourceGroup,
                "Configuration");

            var methods = new List<InputServiceMethod> { getServerMethod, getConfigMethod, listConfigsMethod };
            var decorators = new List<InputDecoratorInfo> { serverDecorator, configDecorator };

            // Optionally add a second resource sharing ConfigurationData
            if (sharedDataType)
            {
                var altConfigNameParam = InputFactory.PathParameter("altConfigName", InputPrimitiveType.String, isRequired: true);
                var altConfigNameMethodParam = InputFactory.MethodParameter("altConfigName", InputPrimitiveType.String, location: InputRequestLocation.Path);

                var altConfigPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/altConfigurations/{altConfigName}";
                var altConfigResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: configModel);

                var getAltConfigOp = InputFactory.Operation(
                    name: "getAltConfiguration",
                    responses: [altConfigResponse],
                    parameters: [subsIdParam, rgParam, serverNameParam, altConfigNameParam],
                    path: altConfigPath);

                var getAltConfigMethod = InputFactory.BasicServiceMethod(
                    "getAltConfiguration",
                    getAltConfigOp,
                    parameters: [altConfigNameMethodParam, serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                    crossLanguageDefinitionId: "Microsoft.Test.AltConfigurations.get");

                var altConfigResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/altConfigurations/{altConfigName}";

                var altConfigDecorator = BuildArmProviderSchema(
                    configModel,
                    [
                        new ResourceMethod(ResourceOperationKind.Read, getAltConfigMethod, new RequestPathPattern(getAltConfigOp.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(altConfigResourceIdPattern), null), null!),
                    ],
                    altConfigResourceIdPattern,
                    "Microsoft.Test/servers/altConfigurations",
                    null,
                    ResourceScope.ResourceGroup,
                    "AltConfiguration");

                methods.Add(getAltConfigMethod);
                decorators.Add(altConfigDecorator);
            }

            var client = InputFactory.Client(
                "TestClient",
                methods: methods,
                decorators: decorators,
                crossLanguageDefinitionId: "Test.TestClient");

            plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => inputModels,
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
                ["scope"] = new Dictionary<string, string?>
                {
                    ["kind"] = resourceScope.ToString(),
                    ["scopeIdPattern"] = resourceScope switch
                    {
                        ResourceScope.ResourceGroup => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
                        ResourceScope.Subscription => "/subscriptions/{subscriptionId}",
                        ResourceScope.Tenant => "",
                        ResourceScope.ManagementGroup => "/providers/Microsoft.Management/managementGroups/{managementGroupId}",
                        _ => ""
                    }
                },
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

            static Dictionary<string, object> SerializeResourceMethod(ResourceMethod m)
            {
                var result = new Dictionary<string, object>
                {
                    ["methodId"] = m.InputMethod.CrossLanguageDefinitionId,
                    ["kind"] = m.Kind.ToString(),
                    ["operationPath"] = (string)m.OperationPath,
                    ["scope"] = new Dictionary<string, string?>
                    {
                        ["kind"] = m.Scope.Kind.ToString(),
                        ["scopeIdPattern"] = (string)m.Scope.ScopeIdPattern,
                        ["scopeResourceType"] = m.Scope.ScopeResourceType
                    }
                };
                return result;
            }
        }

        #endregion
    }
}
