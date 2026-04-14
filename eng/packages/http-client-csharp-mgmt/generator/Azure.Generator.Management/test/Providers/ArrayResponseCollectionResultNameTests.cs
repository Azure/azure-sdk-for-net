// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Generator.Management.Tests.Providers
{
    /// <summary>
    /// Tests that ArrayResponseCollectionResultDefinition generates unique class names
    /// even when multiple operations share the same @@clientName (method overloads).
    /// Regression test for: https://github.com/Azure/azure-sdk-for-net/issues/58138
    /// </summary>
    internal class ArrayResponseCollectionResultNameTests
    {
        /// <summary>
        /// Verifies that two markAsPageable operations with different operation names but the
        /// same C# method name produce distinct CollectionResultOfT class names.
        /// </summary>
        [TestCase]
        public void CollectionResultNames_AreUnique_WhenOperationsShareClientName()
        {
            var plugin = SetupTwoActionsWithSameMethodName();

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var collectionResults = outputLibrary!.TypeProviders
                .OfType<ArrayResponseCollectionResultDefinition>()
                .ToList();

            // There should be 4 collection results: 2 operations x (sync + async)
            Assert.GreaterOrEqual(collectionResults.Count, 4,
                $"Expected at least 4 ArrayResponseCollectionResultDefinition instances (2 operations x sync/async), got {collectionResults.Count}");

            // All names must be unique — no two collection results should share the same name
            var names = collectionResults.Select(cr => cr.Name).ToList();
            var uniqueNames = names.Distinct().ToList();

            Assert.AreEqual(names.Count, uniqueNames.Count,
                $"Collection result names must be unique but found duplicates. Names: [{string.Join(", ", names)}]");
        }

        /// <summary>
        /// Verifies that the operation name (not the C# method name) is used in the class name,
        /// so each CollectionResultOfT corresponds to its specific operation.
        /// </summary>
        [TestCase]
        public void CollectionResultName_ContainsOperationName()
        {
            var plugin = SetupTwoActionsWithSameMethodName();

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var collectionResults = outputLibrary!.TypeProviders
                .OfType<ArrayResponseCollectionResultDefinition>()
                .ToList();

            // Verify that sync collection results have distinct names derived from operation names
            var syncResults = collectionResults.Where(cr => !cr.Name.Contains("Async")).ToList();
            Assert.GreaterOrEqual(syncResults.Count, 2,
                $"Expected at least 2 sync collection results, got {syncResults.Count}");

            // One should contain "GetVersions" (from CLDI "...getVersions") and the other "ListVersions" (from CLDI "...listVersions")
            Assert.IsTrue(
                syncResults.Any(cr => cr.Name.Contains("GetVersions")),
                $"Expected a sync collection result name containing 'GetVersions'. Names: [{string.Join(", ", syncResults.Select(cr => cr.Name))}]");
            Assert.IsTrue(
                syncResults.Any(cr => cr.Name.Contains("ListVersions")),
                $"Expected a sync collection result name containing 'ListVersions'. Names: [{string.Join(", ", syncResults.Select(cr => cr.Name))}]");
        }

        /// <summary>
        /// Verifies that the generated file paths are unique for each collection result.
        /// This prevents file overwrites that cause CS1729 build errors.
        /// </summary>
        [TestCase]
        public void CollectionResultFilePaths_AreUnique()
        {
            var plugin = SetupTwoActionsWithSameMethodName();

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            var collectionResults = outputLibrary!.TypeProviders
                .OfType<ArrayResponseCollectionResultDefinition>()
                .ToList();

            var filePaths = collectionResults.Select(cr => cr.RelativeFilePath).ToList();
            var uniqueFilePaths = filePaths.Distinct().ToList();

            Assert.AreEqual(filePaths.Count, uniqueFilePaths.Count,
                $"Collection result file paths must be unique but found duplicates. Paths: [{string.Join(", ", filePaths)}]");
        }

        #region Setup

        /// <summary>
        /// Sets up a scenario with two action operations on the same resource that both return
        /// an array/list type. Both operations have different CrossLanguageDefinitionIds but would
        /// produce the same C# method name via @@clientName in a real TypeSpec scenario.
        /// </summary>
        private static Moq.Mock<ManagementClientGenerator> SetupTwoActionsWithSameMethodName()
        {
            // Resource model
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

            // Result model for the list operations
            var versionModel = InputFactory.Model("VersionResult",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("value", InputPrimitiveType.String, isReadOnly: false),
                ],
                decorators: []);

            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            var subsIdParam = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgParam = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var serverNameParam = InputFactory.PathParameter("serverName", InputPrimitiveType.String, isRequired: true);
            var versionParam = InputFactory.PathParameter("version", InputPrimitiveType.String, isRequired: true);

            var subsIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var rgMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var serverNameMethodParam = InputFactory.MethodParameter("serverName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var versionMethodParam = InputFactory.MethodParameter("version", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // Server resource: Read
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

            // Action 1: "getVersions" — returns an array (with extra "version" path param)
            var getVersionsPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/getVersions/{version}";
            var getVersionsResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(versionModel));

            var getVersionsOp = InputFactory.Operation(
                name: "getVersions",
                responses: [getVersionsResponse],
                parameters: [subsIdParam, rgParam, serverNameParam, versionParam],
                path: getVersionsPath,
                httpMethod: "POST");

            var getVersionsMethod = InputFactory.BasicServiceMethod(
                "getVersions",
                getVersionsOp,
                parameters: [versionMethodParam, serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: "Microsoft.Test.Servers.getVersions");

            // Action 2: "listVersions" — returns an array (without extra "version" param)
            var listVersionsPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}/listVersions";
            var listVersionsResponse = InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(versionModel));

            var listVersionsOp = InputFactory.Operation(
                name: "listVersions",
                responses: [listVersionsResponse],
                parameters: [subsIdParam, rgParam, serverNameParam],
                path: listVersionsPath,
                httpMethod: "POST");

            var listVersionsMethod = InputFactory.BasicServiceMethod(
                "listVersions",
                listVersionsOp,
                parameters: [serverNameMethodParam, subsIdMethodParam, rgMethodParam],
                crossLanguageDefinitionId: "Microsoft.Test.Servers.listVersions");

            // Build ARM provider schema
            var serverResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/servers/{serverName}";

            var serverDecorator = BuildArmProviderSchema(
                serverModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, getServerMethod, getServerOp.Path, ResourceScope.ResourceGroup, serverResourceIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Action, getVersionsMethod, getVersionsPath, ResourceScope.ResourceGroup, serverResourceIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Action, listVersionsMethod, listVersionsPath, ResourceScope.ResourceGroup, serverResourceIdPattern, null!),
                ],
                serverResourceIdPattern,
                "Microsoft.Test/servers",
                null,
                ResourceScope.ResourceGroup,
                "Server");

            var methods = new List<InputServiceMethod> { getServerMethod, getVersionsMethod, listVersionsMethod };
            var client = InputFactory.Client(
                "TestClient",
                methods: methods,
                decorators: [serverDecorator],
                crossLanguageDefinitionId: "Test.TestClient");

            return ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [serverModel, versionModel],
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

        #endregion
    }
}
