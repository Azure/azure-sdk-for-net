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
        public void Verify_MultipleResourcesSharingDataModel_GeneratesSeparateOperationSources()
        {
            // This test verifies the fix for the issue where multiple resources sharing the same data model
            // only generated one OperationSource, causing compilation errors.

            // Create test data with two resources (Site and SitesBySubscription) sharing the same model (SiteData)
            const string sharedModelName = "SiteData";
            var sharedModel = InputFactory.Model(sharedModelName,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String, isReadOnly: false),
                ],
                decorators: []);

            var responseType = InputFactory.OperationResponse(statusCodes: [200], bodytype: sharedModel);
            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");

            // Common parameters
            var subsIdParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var rgParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var subscriptionIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            // First resource: Site (resource group scoped)
            var siteNameParameter = InputFactory.PathParameter("siteName", InputPrimitiveType.String, isRequired: true);
            var siteNameMethodParam = InputFactory.MethodParameter("siteName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            var createSiteOperation = InputFactory.Operation(
                name: "createSite",
                responses: [responseType],
                parameters: [subsIdParameter, rgParameter, siteNameParameter],
                path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SiteManager/sites/{siteName}");

            var lroMetadata1 = InputFactory.LongRunningServiceMetadata(1, InputFactory.OperationResponse([200], sharedModel), null);
            var createSiteMethod = InputFactory.LongRunningServiceMethod(
                "createSite",
                createSiteOperation,
                parameters: [siteNameMethodParam, subscriptionIdMethodParam, resourceGroupMethodParam],
                longRunningServiceMetadata: lroMetadata1);

            var getSiteOperation = InputFactory.Operation(
                name: "getSite",
                responses: [responseType],
                parameters: [siteNameMethodParam, subscriptionIdMethodParam, resourceGroupMethodParam]);

            var getSiteMethod = InputFactory.BasicServiceMethod(
                "getSite",
                getSiteOperation);

            var siteResourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SiteManager/sites/{siteName}";
            var siteDecorator = BuildArmProviderSchema(
                sharedModel,
                [
                    new ResourceMethod(ResourceOperationKind.Create, createSiteMethod, createSiteOperation.Path, ResourceScope.ResourceGroup, siteResourceIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Read, getSiteMethod, createSiteOperation.Path, ResourceScope.ResourceGroup, siteResourceIdPattern, null!)
                ],
                siteResourceIdPattern,
                "Microsoft.SiteManager/sites",
                null,
                ResourceScope.ResourceGroup,
                "Site");

            // Second resource: SitesBySubscription (subscription scoped, sharing same SiteData model)
            var siteNameParameter2 = InputFactory.PathParameter("siteName", InputPrimitiveType.String, isRequired: true);
            var siteNameMethodParam2 = InputFactory.MethodParameter("siteName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            var createSiteBySubOperation = InputFactory.Operation(
                name: "createSitesBySubscription",
                responses: [responseType],
                parameters: [subsIdParameter, siteNameParameter2],
                path: "/subscriptions/{subscriptionId}/providers/Microsoft.SiteManager/sites/{siteName}");

            var lroMetadata2 = InputFactory.LongRunningServiceMetadata(1, InputFactory.OperationResponse([200], sharedModel), null);
            var createSiteBySubMethod = InputFactory.LongRunningServiceMethod(
                "createSitesBySubscription",
                createSiteBySubOperation,
                parameters: [siteNameMethodParam2, subscriptionIdMethodParam],
                longRunningServiceMetadata: lroMetadata2);

            var getSiteBySubOperation = InputFactory.Operation(
                name: "getSitesBySubscription",
                responses: [responseType],
                parameters: [siteNameMethodParam2, subscriptionIdMethodParam]);

            var getSiteBySubMethod = InputFactory.BasicServiceMethod(
                "getSitesBySubscription",
                getSiteBySubOperation);

            var sitesBySubscriptionResourceIdPattern = "/subscriptions/{subscriptionId}/providers/Microsoft.SiteManager/sites/{siteName}";
            var sitesBySubscriptionDecorator = BuildArmProviderSchema(
                sharedModel,
                [
                    new ResourceMethod(ResourceOperationKind.Create, createSiteBySubMethod, createSiteBySubOperation.Path, ResourceScope.Subscription, sitesBySubscriptionResourceIdPattern, null!),
                    new ResourceMethod(ResourceOperationKind.Read, getSiteBySubMethod, createSiteBySubOperation.Path, ResourceScope.Subscription, sitesBySubscriptionResourceIdPattern, null!)
                ],
                sitesBySubscriptionResourceIdPattern,
                "Microsoft.SiteManager/sites",
                null,
                ResourceScope.Subscription,
                "SitesBySubscription");

            // Create a single client with all methods, but two ARM provider decorators for the two resources
            var client = InputFactory.Client(
                "SiteManagerClient",
                methods: [createSiteMethod, getSiteMethod, createSiteBySubMethod, getSiteBySubMethod],
                decorators: [siteDecorator, sitesBySubscriptionDecorator],
                crossLanguageDefinitionId: "Test.SiteManagerClient");

            // Load plugin with both resources via single client
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [sharedModel],
                clients: () => [client]);

            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.NotNull(outputLibrary);

            // Verify that TWO separate OperationSources are created, not just one
            var operationSources = outputLibrary!.OperationSourceDict;
            Assert.AreEqual(2, operationSources.Count,
                "Should generate 2 OperationSources for 2 resources sharing the same data model");

            // Verify the OperationSource names and types
            var operationSourcesList = operationSources.Values.ToList();
            var names = operationSourcesList.Select(os => os.Name).OrderBy(n => n).ToList();

            // Both resources should have their own OperationSource
            Assert.Contains("SiteResourceOperationSource", names, "Should have SiteResourceOperationSource");
            Assert.Contains("SitesBySubscriptionResourceOperationSource", names, "Should have SitesBySubscriptionResourceOperationSource");

            // Verify each OperationSource implements IOperationSource<CorrectResourceType>
            var siteOperationSource = operationSourcesList.First(os => os.Name == "SiteResourceOperationSource");
            var sitesBySubOperationSource = operationSourcesList.First(os => os.Name == "SitesBySubscriptionResourceOperationSource");

            // Check that the OperationSource implements IOperationSource<T> with the correct T
            var siteImplements = siteOperationSource.Implements;
            Assert.AreEqual(1, siteImplements.Count);
            Assert.IsTrue(siteImplements[0].Name.Contains("IOperationSource"));
            Assert.AreEqual("SiteResource", siteImplements[0].Arguments[0].Name);

            var sitesBySubImplements = sitesBySubOperationSource.Implements;
            Assert.AreEqual(1, sitesBySubImplements.Count);
            Assert.IsTrue(sitesBySubImplements[0].Name.Contains("IOperationSource"));
            Assert.AreEqual("SitesBySubscriptionResource", sitesBySubImplements[0].Arguments[0].Name);
        }

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
