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

    private static InputServiceMethod CreateMethod(string name, string version)
    {
        var versionParameter = InputFactory.QueryParameter(
            "apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
            defaultValue: new InputConstant(version, InputPrimitiveType.String),
            serializedName: "api-version", scope: InputParameterScope.Client);
        return InputFactory.BasicServiceMethod(name, InputFactory.Operation(name, parameters: [versionParameter], path: $"/{name}"));
    }
}
