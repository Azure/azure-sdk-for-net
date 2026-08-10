// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
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
                    new ResourceMethod(ResourceOperationKind.Create, createSiteMethod, new RequestPathPattern(createSiteOperation.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(siteResourceIdPattern), null), null!),
                    new ResourceMethod(ResourceOperationKind.Read, getSiteMethod, new RequestPathPattern(createSiteOperation.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(siteResourceIdPattern), null), null!)
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
                    new ResourceMethod(ResourceOperationKind.Create, createSiteBySubMethod, new RequestPathPattern(createSiteBySubOperation.Path), new ArmScopeInfo(ResourceScope.Subscription, new RequestPathPattern(sitesBySubscriptionResourceIdPattern), null), null!),
                    new ResourceMethod(ResourceOperationKind.Read, getSiteBySubMethod, new RequestPathPattern(createSiteBySubOperation.Path), new ArmScopeInfo(ResourceScope.Subscription, new RequestPathPattern(sitesBySubscriptionResourceIdPattern), null), null!)
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
            Assert.That(outputLibrary, Is.Not.Null);

            // Verify that separate OperationSources are created per resource. In addition, when multiple
            // resources share the same data type we also register a fallback OperationSource keyed by the
            // raw data type, so that ResourceOperationMethodProvider.BuildLroHandling can look it up when
            // TryGetResourceClientProvider declines to wrap (Count != 1 case).
            var operationSources = outputLibrary!.OperationSourceDict;
            Assert.That(operationSources.Count, Is.EqualTo(3),
                "Should generate 2 resource-keyed OperationSources plus 1 data-type-keyed fallback");

            // Verify the OperationSource names and types
            var operationSourcesList = operationSources.Values.ToList();
            var names = operationSourcesList.Select(os => os.Name).OrderBy(n => n).ToList();

            // Both resources should have their own OperationSource
            Assert.That(names, Does.Contain("SiteResourceOperationSource"), "Should have SiteResourceOperationSource");
            Assert.That(names, Does.Contain("SitesBySubscriptionResourceOperationSource"), "Should have SitesBySubscriptionResourceOperationSource");
            // And the fallback entry keyed by the shared data type should be registered as a non-resource OperationSource
            Assert.That(names, Does.Contain("SiteDataOperationSource"),
                "Should have a fallback OperationSource keyed by the shared data type for the non-wrap LRO path");

            // Verify each OperationSource implements IOperationSource<CorrectResourceType>
            var siteOperationSource = operationSourcesList.First(os => os.Name == "SiteResourceOperationSource");
            var sitesBySubOperationSource = operationSourcesList.First(os => os.Name == "SitesBySubscriptionResourceOperationSource");

            // Check that the OperationSource implements IOperationSource<T> with the correct T
            var siteImplements = siteOperationSource.Implements;
            Assert.That(siteImplements.Count, Is.EqualTo(1));
            Assert.That(siteImplements[0].Name.Contains("IOperationSource"), Is.True);
            Assert.That(siteImplements[0].Arguments[0].Name, Is.EqualTo("SiteResource"));

            var sitesBySubImplements = sitesBySubOperationSource.Implements;
            Assert.That(sitesBySubImplements.Count, Is.EqualTo(1));
            Assert.That(sitesBySubImplements[0].Name.Contains("IOperationSource"), Is.True);
            Assert.That(sitesBySubImplements[0].Arguments[0].Name, Is.EqualTo("SitesBySubscriptionResource"));
        }

        [TestCase]
        public void Verify_LongRunningPagingMethod_GeneratesOperationSource()
        {
            var resourceModel = InputFactory.Model("ManagedNetworkData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                ],
                decorators: []);
            var listResultModel = InputFactory.Model("OutboundRuleListResult",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("nextLink", InputPrimitiveType.String),
                    InputFactory.Property("value", InputFactory.Array(resourceModel)),
                ],
                decorators: []);

            var uuidType = new InputPrimitiveType(InputPrimitiveTypeKind.String, "uuid", "Azure.Core.uuid");
            var subscriptionIdParameter = InputFactory.PathParameter("subscriptionId", uuidType, isRequired: true);
            var resourceGroupParameter = InputFactory.PathParameter("resourceGroupName", InputPrimitiveType.String, isRequired: true);
            var resourceNameParameter = InputFactory.PathParameter("managedNetworkName", InputPrimitiveType.String, isRequired: true);
            var subscriptionIdMethodParam = InputFactory.MethodParameter("subscriptionId", uuidType, location: InputRequestLocation.Path);
            var resourceGroupMethodParam = InputFactory.MethodParameter("resourceGroupName", InputPrimitiveType.String, location: InputRequestLocation.Path);
            var resourceNameMethodParam = InputFactory.MethodParameter("managedNetworkName", InputPrimitiveType.String, location: InputRequestLocation.Path);

            var readOperation = InputFactory.Operation(
                name: "getManagedNetwork",
                responses: [InputFactory.OperationResponse([200], resourceModel)],
                parameters: [subscriptionIdParameter, resourceGroupParameter, resourceNameParameter],
                path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/managedNetworks/{managedNetworkName}");
            var readMethod = InputFactory.BasicServiceMethod(
                "getManagedNetwork",
                readOperation,
                parameters: [resourceNameMethodParam, subscriptionIdMethodParam, resourceGroupMethodParam],
                response: InputFactory.ServiceMethodResponse(resourceModel, null));

            var actionOperation = InputFactory.Operation(
                name: "batchOutboundRules",
                responses: [InputFactory.OperationResponse([200], listResultModel), InputFactory.OperationResponse([202])],
                parameters: [subscriptionIdParameter, resourceGroupParameter, resourceNameParameter],
                path: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/managedNetworks/{managedNetworkName}/batchOutboundRules",
                httpMethod: "POST");
            var actionMethod = new InputLongRunningPagingServiceMethod(
                "batchOutboundRules",
                "public",
                [],
                null,
                null,
                actionOperation,
                [resourceNameMethodParam, subscriptionIdMethodParam, resourceGroupMethodParam],
                InputFactory.ServiceMethodResponse(listResultModel, null),
                null,
                false,
                true,
                true,
                "Test.ManagedNetworks.batchOutboundRules",
                InputFactory.LongRunningServiceMetadata(1, InputFactory.OperationResponse([200], listResultModel), null),
                InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));

            var resourceIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Tests/managedNetworks/{managedNetworkName}";
            var armProviderDecorator = BuildArmProviderSchema(
                resourceModel,
                [
                    new ResourceMethod(ResourceOperationKind.Read, readMethod, new RequestPathPattern(readOperation.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(resourceIdPattern), null), null!),
                    new ResourceMethod(ResourceOperationKind.Action, actionMethod, new RequestPathPattern(actionOperation.Path), new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(resourceIdPattern), null), null!)
                ],
                resourceIdPattern,
                "Microsoft.Tests/managedNetworks",
                null,
                ResourceScope.ResourceGroup,
                "ManagedNetwork");
            var client = InputFactory.Client(
                "ManagedNetworksClient",
                methods: [readMethod, actionMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: "Test.ManagedNetworksClient");

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [resourceModel, listResultModel], clients: () => [client]);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;

            Assert.That(outputLibrary, Is.Not.Null);
            var operationSources = outputLibrary!.OperationSourceDict;
            Assert.That(operationSources.Keys.Any(type => type.Name == "OutboundRuleListResult"), Is.True);
            Assert.That(operationSources.Values.Any(source => source.Name == "OutboundRuleListResultOperationSource"), Is.True);

            var resourceProvider = outputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
            var lroPagingMethods = resourceProvider.Methods
                .Where(method => method.Signature.Name.Contains("BatchOutboundRules"))
                .ToList();
            Assert.That(lroPagingMethods, Has.Count.EqualTo(2));
            Assert.That(lroPagingMethods, Is.All.Matches<MethodProvider>(method =>
                method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)
                && !method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)));

            var readMethods = resourceProvider.Methods
                .Where(method => method.Signature.Name.Contains("Get"))
                .ToList();
            Assert.That(readMethods, Is.Not.Empty);
            Assert.That(readMethods, Is.All.Matches<MethodProvider>(method =>
                method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                && !method.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal)));
        }

        [TestCase]
        public void Verify_CreateResult()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResult");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.That(signature.Modifiers.Equals(MethodSignatureModifiers.None), Is.True);
            Assert.That(signature.Parameters.Count == 2, Is.True);
            Assert.That(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)), Is.True);
            Assert.That(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)), Is.True);
            Assert.That("ResponseTypeResource", Is.EqualTo(signature.ReturnType?.Name));

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_CreateResultAsync()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResultAsync");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.That(signature.Modifiers.Equals(MethodSignatureModifiers.Async), Is.True);
            Assert.That(signature.Parameters.Count == 2, Is.True);
            Assert.That(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)), Is.True);
            Assert.That(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)), Is.True);
            Assert.That(typeof(ValueTask<>), Is.EqualTo(signature.ReturnType?.FrameworkType));

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.That(bodyStatements, Is.Not.Null);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.That(bodyStatements, Is.EqualTo(exptected));
        }

        [TestCase]
        public void Verify_NonResourceFrameworkType_CreateResult_UsesModelReaderWriter()
        {
            // Regression test for #58709: for cross-assembly framework result types (e.g. OperationStatusResult,
            // defined in Azure.ResourceManager), the generated CreateResult must NOT call the inaccessible internal
            // Deserialize{Name} factory, and must instead use ModelReaderWriter.Read<T> with the SDK's generated
            // ModelReaderWriterContext.
            var (createResult, createResultAsync) = GetNonResourceFrameworkOperationSourceMethods();

            foreach (var (method, isAsync) in new[] { (createResult, false), (createResultAsync, true) })
            {
                var body = method.BodyStatements?.ToDisplayString();
                Assert.That(body, Is.Not.Null);

                // Must use ModelReaderWriter.Read with the generated context, not the internal factory.
                Assert.That(body, Does.Contain("global::System.ClientModel.Primitives.ModelReaderWriter.Read"),
                    $"{(isAsync ? "CreateResultAsync" : "CreateResult")} should use ModelReaderWriter.Read for framework result types.");
                Assert.That(body, Does.Contain("Context.Default"),
                    $"{(isAsync ? "CreateResultAsync" : "CreateResult")} should pass the generated ModelReaderWriterContext to ModelReaderWriter.Read.");
                Assert.That(body, Does.Contain("ModelSerializationExtensions.WireOptions"),
                    $"{(isAsync ? "CreateResultAsync" : "CreateResult")} should pass WireOptions to ModelReaderWriter.Read.");
                Assert.That(body, Does.Not.Contain("DeserializeOperationStatusResult"),
                    $"{(isAsync ? "CreateResultAsync" : "CreateResult")} must not call the inaccessible internal Deserialize factory.");
            }
        }

        [TestCase]
        public void Verify_GenericResultType_UsesGenericOperationSourceName()
        {
            _ = ManagementMockHelpers.LoadMockPlugin();

            var provider = new OperationSourceProvider(new CSharpType(typeof(IList<>), typeof(string)));

            Assert.That(provider.Name, Is.EqualTo("IListOfStringOperationSource"));
        }

        private static (MethodProvider CreateResult, MethodProvider CreateResultAsync) GetNonResourceFrameworkOperationSourceMethods()
        {
            // Bootstrap the mock plugin so TypeProvider machinery (ModelReaderWriterContextDefinition, etc.) is available.
            _ = ManagementMockHelpers.LoadMockPlugin();

            var provider = new OperationSourceProvider(typeof(OperationStatusResult));
            var createResult = provider.Methods.FirstOrDefault(m => m.Signature.Name == "CreateResult");
            var createResultAsync = provider.Methods.FirstOrDefault(m => m.Signature.Name == "CreateResultAsync");
            Assert.That(createResult, Is.Not.Null);
            Assert.That(createResultAsync, Is.Not.Null);
            return (createResult!, createResultAsync!);
        }

        private static MethodProvider GetOperationSourceProviderMethodByName(string methodName)
        {
            OperationSourceProvider resourceProvider = GetOperationSourceProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.That(method, Is.Not.Null);
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
                        new RequestPathPattern(createMethod.Operation.Path),
                        new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(resourceIdPattern), null),
                        null!),
                    new ResourceMethod(
                        ResourceOperationKind.Read,
                        getMethod,
                        new RequestPathPattern(getMethod.Operation.Path),
                        new ArmScopeInfo(ResourceScope.ResourceGroup, new RequestPathPattern(resourceIdPattern), null),
                        null!)
                ],
                resourceIdPattern,
                "Microsoft.Tests/tests",
                null,
                ResourceScope.ResourceGroup,
                "ResponseType");

            var client = InputFactory.Client(
                TestClientName,
                methods: [createMethod, getMethod],
                decorators: [armProviderDecorator],
                crossLanguageDefinitionId: $"Test.{TestClientName}");

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [responseModel], clients: () => [client]);
            var outputLibrary = plugin.Object.OutputLibrary as ManagementOutputLibrary;
            Assert.That(outputLibrary, Is.Not.Null);
            var operationSourceProvider = outputLibrary!.OperationSourceDict.Values.FirstOrDefault();
            Assert.That(operationSourceProvider, Is.Not.Null);
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
    }
}
