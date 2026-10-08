// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;

internal class ApiVersionOverrideTests
{
    [Test]
    public void NonResourceRequestsPreserveDifferentWireDefaultsInOneClient()
    {
        var methods = new[]
        {
            CreateMethod("First", "opaque-first"),
            CreateMethod("Second", "opaque-second"),
            CreateMethod("Ordinary", "2023-01-01")
        };
        var client = InputFactory.Client("TestClient", methods: methods);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
        var provider = plugin.Object.TypeFactory.CreateClient(client)!;
        var requests = provider.RestClient.Methods.Where(m => m.Signature.Name.StartsWith("Create")).ToArray();

        Assert.That(requests, Has.Length.EqualTo(3));
        foreach (var (name, expected) in new[] { ("First", "opaque-first"), ("Second", "opaque-second"), ("Ordinary", "2023-01-01") })
        {
            var request = requests.Single(m => m.Signature.Name == $"Create{name}Request");
            Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain($"AppendQuery(\"api-version\", \"{expected}\", true)"));
        }
        Assert.That(client.ApiVersions, Is.EqualTo(new[] { "2023-01-01" }));
    }

    [Test]
    public void OptionalApiVersionStillEmitsItsWireDefault()
    {
        var parameter = InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isApiVersion: true,
            defaultValue: new InputConstant("opaque-optional", InputPrimitiveType.String),
            serializedName: "api-version", scope: InputParameterScope.Client);
        var method = InputFactory.BasicServiceMethod("Optional", InputFactory.Operation("Optional", parameters: [parameter]));
        var client = InputFactory.Client("TestClient", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
        var body = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods
            .Single(m => m.Signature.Name == "CreateOptionalRequest").BodyStatements!.ToDisplayString();
        Assert.That(body, Does.Contain("AppendQuery(\"api-version\", \"opaque-optional\", true)"));
        Assert.That(body, Does.Not.Contain("if (_apiVersion"));
    }

    [Test]
    public void OverrideEqualToServiceVersionRetainsTargetedRuntimeResolution()
    {
        var (client, models) = InputResourceData.ClientWithResource();
        foreach (var method in client.Methods)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters,
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant("2023-01-01", InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)]);
            typeof(InputOperation).GetProperty(nameof(InputOperation.Decorators))!.SetValue(method.Operation,
                new[] { new InputDecoratorInfo("Azure.ResourceManager.@hasApiVersionOverride", new Dictionary<string, BinaryData>()) });
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var request = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods.First(m => m.Signature.Name.StartsWith("Create"));
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("_getApiVersion"));
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("?? \"2023-01-01\""));
    }

    [Test]
    public void ConstantApiVersionInMixedClientRetainsItsWireValue()
    {
        var parameter = InputFactory.QueryParameter("apiVersion", InputFactory.Literal.String("constant-version"),
            isRequired: true, isApiVersion: true, serializedName: "api-version", scope: InputParameterScope.Constant);
        var constantMethod = InputFactory.BasicServiceMethod("Constant", InputFactory.Operation("Constant", parameters: [parameter]));
        var client = InputFactory.Client("TestClient", methods: [CreateMethod("Decorated", "opaque-first"), constantMethod]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
        var request = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods.Single(m => m.Signature.Name == "CreateConstantRequest");
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("AppendQuery(\"api-version\", \"constant-version\", true)"));
    }

    [Test]
    public void UndecoratedClientKeepsExistingVersionField()
    {
        var client = InputFactory.Client("TestClient", methods: [CreateMethod("Ordinary", "2023-01-01")]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
        var provider = plugin.Object.TypeFactory.CreateClient(client)!;
        var request = provider.RestClient.Methods.Single(m => m.Signature.Name == "CreateOrdinaryRequest");
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
    }

    [Test]
    public void ResourceAndCollectionResolveRuntimeOverridesByOperationResourceType()
    {
        var (client, models) = InputResourceData.ClientWithResource();
        AddWireDefaults(client);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var providers = plugin.Object.OutputLibrary.TypeProviders;
        foreach (var provider in providers.Where(p => p is ResourceClientProvider or ResourceCollectionClientProvider))
        {
            var code = new TypeProviderWriter(provider).Write().Content;
            Assert.That(code, Does.Contain("resourceType => this.TryGetApiVersion(resourceType, out string apiVersion) ? apiVersion : null"));
        }
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var request = restClient.RestClient.Methods.First(m => m.Signature.Name.StartsWith("Create") && m.Signature.Name.EndsWith("Request"));
        var body = request.BodyStatements!.ToDisplayString();
        Assert.That(body, Does.Contain("_getApiVersion"));
        Assert.That(body, Does.Contain("Microsoft.Tests/tests"));
        Assert.That(body, Does.Contain("?? \"opaque-first\""));
    }

    [Test]
    public void MockableResourceResolvesTargetedOverrideRatherThanOwningScopeVersion()
    {
        var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList();
        AddWireDefaults(client);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>().Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var code = new TypeProviderWriter(mockable).Write().Content;
        Assert.That(code, Does.Contain("resourceType => this.TryGetApiVersion(resourceType, out string apiVersion) ? apiVersion : null"));
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var request = restClient.RestClient.Methods.First(m => m.Signature.Name.StartsWith("Create") && m.Signature.Name.EndsWith("Request"));
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("_getApiVersion"));
        Assert.That(request.BodyStatements!.ToDisplayString(), Does.Contain("?? \"opaque-first\""));
    }

    [Test]
    public void SharedClientUsesEachOperationsAssociatedResourceType()
    {
        var (parent, child, models) = InputResourceData.ClientWithNestedChildResource();
        AddWireDefaults(parent, "parent-wire");
        AddWireDefaults(child, "child-wire");
        var client = InputFactory.Client("Combined", methods: [.. parent.Methods, .. child.Methods], decorators: parent.Decorators);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var requests = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods;
        var parentRequest = requests.Single(m => m.Signature.Name == "CreateCreateParentRequest").BodyStatements!.ToDisplayString();
        var childRequest = requests.Single(m => m.Signature.Name == "CreateCreateChildRequest").BodyStatements!.ToDisplayString();
        Assert.That(parentRequest, Does.Contain("Invoke(\"Microsoft.Tests/parents\") ?? \"parent-wire\""));
        Assert.That(childRequest, Does.Contain("Invoke(\"Microsoft.Tests/parents/nestedTypes/children\") ?? \"child-wire\""));
    }

    [Test]
    public void ExpandedResourceTypesResolveTheRuntimeKeyFromTheRequestParameter()
    {
        var (client, models) = InputResourceData.ClientWithDynamicResourceTypes();
        AddWireDefaults(client);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var body = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods
            .Single(m => m.Signature.Name == "CreateGetRequest").BodyStatements!.ToDisplayString();
        Assert.That(body, Does.Contain("Invoke(((\"Microsoft.Tests\" + \"/\") + kind)) ?? \"opaque-first\""));
        Assert.That(body, Does.Not.Contain("Invoke(\"Microsoft.Tests/first\")"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ContinuationRequestsUseTheSameOperationVersionPrecedence(bool resourceAssociated)
    {
        var (resourceClient, models) = InputResourceData.ClientWithExtensionScopedResourceList();
        AddWireDefaults(resourceClient);
        var client = resourceAssociated ? resourceClient : InputFactory.Client("NonResourcePaging", methods: resourceClient.Methods);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var continuations = plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods
            .Where(m => m.Signature.Name.StartsWith("CreateNext")).ToArray();
        Assert.That(continuations, Is.Not.Empty);
        foreach (var continuation in continuations)
        {
            var body = continuation.BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("UpdateQuery(\"api-version\""));
            Assert.That(body, Does.Contain("\"opaque-first\""));
            Assert.That(body.Contains("_getApiVersion"), Is.EqualTo(resourceAssociated));
            Assert.That(body, Does.Not.Contain("UpdateQuery(\"api-version\", _apiVersion)"));
        }
    }

    private static void AddWireDefaults(InputClient client, string version = "opaque-first")
    {
        foreach (var method in client.Methods)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters,
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant(version, InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)]);
        }
    }

    [Test]
    public void MockableResourceAssociatedClientResolvesRuntimeApiVersionOverride()
    {
        var (property, request) = RenderResourceAssociatedMockableClient();

        // Regression for #62600: the mockable supplies the runtime resolver, while each
        // request uses its operation's resource type rather than the owning core scope.
        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Contain("TryGetApiVersion("));
            Assert.That(request, Does.Contain("_getApiVersion"));
            Assert.That(request, Does.Contain("\"Microsoft.Tests/events\""));
            Assert.That(request, Does.Contain("?? \"2023-01-01\""));
        });
    }

    [Test]
    public void MockableResourceAssociatedClientPreservesDefaultApiVersion()
    {
        var (property, request) = RenderResourceAssociatedMockableClient();

        AssertRequestPreservesDefaultApiVersion(property, request);
    }

    [Test]
    public void MockableCrossProviderClientResolvesOperationResourceTypeRatherThanPackageProvider()
    {
        const string resourceType = "Microsoft.Compute/virtualMachineScaleSets/publicIPAddresses";
        var (property, request) = RenderResourceAssociatedMockableClient(resourceType, "Azure.ResourceManager.Network");

        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Contain("TryGetApiVersion("));
            Assert.That(property, Does.Contain("global::Azure.ResourceManager.Network.NetworkClient"));
            Assert.That(request, Does.Contain("_getApiVersion"));
            Assert.That(request, Does.Contain($"\"{resourceType}\""));
            Assert.That(request, Does.Not.Contain("\"Microsoft.Network/"));
            Assert.That(request, Does.Contain("?? \"2023-01-01\""));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void MockableUndecoratedRelationshipsClientResolvesOperationGroupOverride(bool resourceGroupScope)
    {
        var (property, request) = RenderUndecoratedScopedMockableClient(resourceGroupScope, hasProviderPath: true);

        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Contain("TryGetApiVersion("));
            Assert.That(request, Does.Contain("_getApiVersion"));
            Assert.That(request, Does.Contain("\"Microsoft.Relationships/contains\""));
            Assert.That(request, Does.Not.Contain("\"Microsoft.Resources/resourceGroups\""));
            Assert.That(request, Does.Not.Contain("\"Microsoft.Resources/subscriptions\""));
            Assert.That(request, Does.Contain("?? \"2023-01-01\""));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void MockableUndecoratedRelationshipsClientPreservesDefaultApiVersion(bool resourceGroupScope)
    {
        var (property, request) = RenderUndecoratedScopedMockableClient(resourceGroupScope, hasProviderPath: true);

        AssertRequestPreservesDefaultApiVersion(property, request);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void MockableTrulyNonResourceClientPreservesDefaultWithoutInventingResourceType(bool resourceGroupScope)
    {
        var (property, request) = RenderUndecoratedScopedMockableClient(resourceGroupScope, hasProviderPath: false);

        // Characterize the existing fallback, not a new override contract for #45049.
        // The core scope's type is not a resource-type key for this operation.
        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Contain("\"2023-01-01\""));
            Assert.That(property, Does.Not.Contain("TryGetApiVersion("));
            Assert.That(request, Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void MockableNonResourceInstanceActionDoesNotInventOperationGroupKey(bool resourceGroupScope)
    {
        var (property, request) = RenderUndecoratedScopedMockableClient(resourceGroupScope, hasProviderPath: true,
            pathSuffix: "/providers/Microsoft.Relationships/contains/default/restart");

        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Not.Contain("TryGetApiVersion("));
            Assert.That(request, Does.Not.Contain("_getApiVersion"));
            Assert.That(request, Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
        });
    }

    [Test]
    public void SharedMockableClientResolvesEachResourceTypesOverrideIndependently()
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(includeSecondResource: true);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        Assert.That(mockable.Properties.Count(p => p.Type.Equals(restClient.Type)), Is.EqualTo(1));
        Assert.That(plugin.Object.InputLibrary.ArmProviderSchema.Resources, Has.Count.EqualTo(2));

        // One constructor version cannot represent independent overrides for both keys.
        // Inspect each request rather than accepting a lookup for whichever resource is first.
        Assert.Multiple(() =>
        {
            foreach (var resourceName in new[] { "First", "Second" })
            {
                var request = GetInitialRequestBody(restClient.RestClient.Methods, resourceName);
                Assert.That(request, Does.Contain("_getApiVersion"), resourceName);
                Assert.That(request, Does.Contain($"\"Microsoft.Tests/{resourceName.ToLowerInvariant()}\""), resourceName);
                Assert.That(request, Does.Contain("?? \"2023-01-01\""), resourceName);
            }
        });
    }

    [Test]
    public void MixedMockableClientResolvesResourceOverrideAtTheRequestLevel()
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(includeNonResource: true);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        Assert.That(plugin.Object.InputLibrary.ArmProviderSchema.NonResourceMethods, Has.Count.EqualTo(1));
        var request = GetInitialRequestBody(restClient.RestClient.Methods, "First");

        Assert.Multiple(() =>
        {
            Assert.That(request, Does.Contain("_getApiVersion"));
            Assert.That(request, Does.Contain("\"Microsoft.Tests/first\""));
            Assert.That(request, Does.Contain("?? \"2023-01-01\""));
        });
    }

    [Test]
    public void MixedMockableClientDoesNotApplyResourceOverrideToNonResourceRequest()
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(includeNonResource: true);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var property = mockable.Properties.Single(p => p.Type.Equals(restClient.Type));
        var renderedProperty = new TypeProviderWriter(new TestTypeProvider(properties: [property])).Write().Content;
        var request = GetInitialRequestBody(restClient.RestClient.Methods, "CheckNameAvailability");

        Assert.Multiple(() =>
        {
            Assert.That(request, Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
            Assert.That(request, Does.Not.Contain("_getApiVersion"));
            Assert.That(renderedProperty, Does.Contain("\"2023-01-01\""));
            Assert.That(renderedProperty, Does.Not.Contain("\"Microsoft.Tests/first\""),
                "A resource-keyed constructor version would also leak into the non-resource request.");
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ResourceActionUsesResourceMetadataRatherThanActionPathForOverride(bool explicitlyDecorated)
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(includeAction: true);
        if (explicitlyDecorated)
        {
            var action = client.Methods.Single(m => m.Name.Contains("Restart"));
            typeof(InputOperation).GetProperty(nameof(InputOperation.Decorators))!.SetValue(action.Operation,
                new[] { new InputDecoratorInfo("Azure.ResourceManager.@hasApiVersionOverride", new Dictionary<string, BinaryData>()) });
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var request = GetInitialRequestBody(plugin.Object.TypeFactory.CreateClient(client)!.RestClient.Methods, "Restart");
        var resource = plugin.Object.OutputLibrary.TypeProviders.OfType<ResourceClientProvider>().Single();
        var renderedResource = new TypeProviderWriter(resource).Write().Content;

        Assert.Multiple(() =>
        {
            // Ordinary single-resource actions already inherit the resource constructor's
            // correctly keyed version; decorated actions resolve their own request version.
            Assert.That(renderedResource, Does.Contain("TryGetApiVersion("));
            Assert.That(renderedResource, Does.Contain("\"Microsoft.Tests/first\""));
            Assert.That(renderedResource, Does.Not.Contain("\"Microsoft.Tests/first/restart\""));
            if (explicitlyDecorated || request.Contains("_getApiVersion"))
            {
                Assert.That(request, Does.Contain("_getApiVersion"));
                Assert.That(request, Does.Contain("\"Microsoft.Tests/first\""));
                Assert.That(request, Does.Contain("?? \"2023-01-01\""));
            }
            else
            {
                Assert.That(request, Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
            }
            Assert.That(request, Does.Not.Contain("\"Microsoft.Tests/first/restart\""));
        });
    }

    private static void AssertRequestPreservesDefaultApiVersion(string property, string request)
    {
        Assert.Multiple(() =>
        {
            Assert.That(property, Does.Contain("\"2023-01-01\""));
            if (request.Contains("_getApiVersion"))
            {
                Assert.That(request, Does.Contain("?? \"2023-01-01\""));
            }
            else
            {
                // The unchanged generator supplies the default through the constructor.
                Assert.That(request, Does.Contain("AppendQuery(\"api-version\", _apiVersion, true)"));
            }
        });
    }

    private static string GetInitialRequestBody(IEnumerable<Microsoft.TypeSpec.Generator.Providers.MethodProvider> methods, string name)
        => methods.Single(m => m.Signature.Name.StartsWith("Create") && !m.Signature.Name.StartsWith("CreateNext")
            && m.Signature.Name.EndsWith("Request") && !m.Signature.Name.Contains("Read") && m.Signature.Name.Contains(name))
            .BodyStatements!.ToDisplayString();

    private static (string Property, string Request) RenderUndecoratedScopedMockableClient(bool resourceGroupScope, bool hasProviderPath, string? pathSuffix = null)
    {
        var scopePath = resourceGroupScope
            ? "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}"
            : "/subscriptions/{subscriptionId}";
        var parameterNames = resourceGroupScope ? new[] { "subscriptionId", "resourceGroupName" } : ["subscriptionId"];
        var operation = InputFactory.Operation("List",
            path: scopePath + (pathSuffix ?? (hasProviderPath ? "/providers/Microsoft.Relationships/contains" : "/checkNameAvailability")),
            parameters: [.. parameterNames.Select(name => InputFactory.PathParameter(name, InputPrimitiveType.String, isRequired: true)),
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant("2023-01-01", InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)],
            responses: [InputFactory.OperationResponse([200], InputPrimitiveType.String)]);
        var method = InputFactory.BasicServiceMethod("List", operation,
            parameters: parameterNames.Select(name => InputFactory.MethodParameter(name, InputPrimitiveType.String,
                location: InputRequestLocation.Path, isRequired: true)).ToArray(),
            crossLanguageDefinitionId: "Test.ScopedOperations.List");
        // Non-resource method metadata records the owning scope but supplies no ARM resource
        // schema and no API-version-override decorator, as with Relationships contains clients.
        var decorator = new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", new Dictionary<string, BinaryData>
        {
            ["resources"] = BinaryData.FromObjectAsJson(Array.Empty<object>()),
            ["nonResourceMethods"] = BinaryData.FromObjectAsJson(new[]
            {
                new
                {
                    methodId = method.CrossLanguageDefinitionId,
                    scope = new
                    {
                        kind = resourceGroupScope ? "ResourceGroup" : "Subscription",
                        scopeIdPattern = scopePath,
                        scopeResourceType = resourceGroupScope ? "Microsoft.Resources/resourceGroups" : "Microsoft.Resources/subscriptions"
                    }
                }
            })
        });
        var client = InputFactory.Client("ScopedOperations", methods: [method], decorators: [decorator]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client]);
        Assert.That(plugin.Object.InputLibrary.ArmProviderSchema.Resources, Is.Empty);
        var coreType = resourceGroupScope ? typeof(Azure.ResourceManager.Resources.ResourceGroupResource) : typeof(Azure.ResourceManager.Resources.SubscriptionResource);
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(coreType));
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var property = mockable.Properties.Single(p => p.Type.Equals(restClient.Type));
        var renderedProperty = new TypeProviderWriter(new TestTypeProvider(properties: [property])).Write().Content;
        var request = restClient.RestClient.Methods.Single(m => m.Signature.Name.StartsWith("Create") && m.Signature.Name.EndsWith("Request"))
            .BodyStatements!.ToDisplayString();
        return (renderedProperty, request);
    }

    private static (string Property, string Request) RenderResourceAssociatedMockableClient(string resourceType = "Microsoft.Tests/events", string clientNamespace = "Samples")
    {
        var (client, models) = InputResourceData.ClientWithExtensionScopedResourceList(resourceType: resourceType);
        foreach (var method in client.Methods)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters,
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant("2023-01-01", InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)]);
        }

        // No API-version-override decorator or differing wire default: the per-operation
        // resolver added for those cases must not mask the ordinary mockable-client bug.
        if (clientNamespace != "Samples")
        {
            client = InputFactory.Client("NetworkClient", clientNamespace: clientNamespace, methods: client.Methods, decorators: client.Decorators);
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var property = mockable.Properties.Single(p => p.Type.Equals(restClient.Type));
        var renderedProperty = new TypeProviderWriter(new TestTypeProvider(properties: [property])).Write().Content;
        var request = restClient.RestClient.Methods.Single(m => m.Signature.Name == "CreateGetBySingleResourceRequest")
            .BodyStatements!.ToDisplayString();
        return (renderedProperty, request);
    }

    private static InputServiceMethod CreateMethod(string name, string version)
    {
        var versionParameter = InputFactory.QueryParameter(
            "apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
            defaultValue: new InputConstant(version, InputPrimitiveType.String),
            serializedName: "api-version", scope: InputParameterScope.Client);
        return InputFactory.BasicServiceMethod(name, InputFactory.Operation(name, parameters: [versionParameter], path: $"/{name}"));
    }
}
