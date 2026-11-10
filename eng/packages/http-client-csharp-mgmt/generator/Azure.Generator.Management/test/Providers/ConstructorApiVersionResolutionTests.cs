// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;

internal class ConstructorApiVersionResolutionTests
{
    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public void FixedKeyCommonDefaultUsesStringConstructor(bool isSubClient, bool differentServiceVersion)
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations();
        string wireDefault = differentServiceVersion ? "opaque&channel=legacy%2F+#hash" : "2023-01-01";
        foreach (var method in client.Methods)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters.Where(p => !p.IsApiVersion),
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant(wireDefault, InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)]);
        }
        if (isSubClient)
        {
            client = InputFactory.Client(client.Name, methods: client.Methods, decorators: client.Decorators,
                parent: InputFactory.Client("ParentClient", decorators: client.Decorators));
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client.Parent ?? client], inputModels: () => models);
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var request = restClient.RestClient.Methods.Single(m => m.Signature.Name == "CreateReadFirstRequest")
            .BodyStatements!.ToDisplayString();
        var code = new TypeProviderWriter(restClient).Write().Content;
        var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
            .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
        var caller = new TypeProviderWriter(mockable).Write().Content;

        Assert.Multiple(() =>
        {
            Assert.That(code, Does.Not.Contain("_getApiVersion"));
            Assert.That(restClient.Constructors.SelectMany(c => c.Signature.Parameters).Select(p => p.Name),
                Does.Contain("apiVersion").And.Not.Contain("getApiVersion"));
            Assert.That(request, Does.Contain("_apiVersion"));
            Assert.That(caller, Does.Contain("TryGetApiVersion(\"Microsoft.Tests/first\""));
            Assert.That(caller, Does.Contain("\"" + wireDefault + "\""));
            Assert.That(caller, Does.Not.Contain("resourceType =>"));
        });
    }

    [TestCase("mixed")]
    [TestCase("multiple-keys")]
    [TestCase("different-defaults")]
    [TestCase("method-scope")]
    public void ComplexClientKeepsItsResolver(string scenario)
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(
            includeSecondResource: scenario == "multiple-keys", includeNonResource: scenario == "mixed");
        if (scenario is "different-defaults" or "method-scope")
        {
            var operation = client.Methods[0].Operation;
            operation.Update(parameters: [.. operation.Parameters.Where(p => !p.IsApiVersion),
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isApiVersion: true,
                    defaultValue: new InputConstant(scenario == "method-scope" ? "2023-01-01" : "opaque-first", InputPrimitiveType.String),
                    serializedName: "api-version", scope: scenario == "method-scope" ? InputParameterScope.Method : InputParameterScope.Client)]);
        }
        if (scenario == "different-defaults")
        {
            // Isolate the default comparison: no unrelated eligibility check may reject this case.
            var versions = client.Methods.Select(m => m.Operation.Parameters.Single(p => p.IsApiVersion)).ToArray();
            Assert.That(versions.All(p => p.Scope == InputParameterScope.Client), Is.True);
            Assert.That(versions.Select(p => p.DefaultValue!.Value).Distinct().Count(), Is.EqualTo(2));
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var code = new TypeProviderWriter(restClient).Write().Content;

        Assert.That(code, Does.Contain("_getApiVersion"));
        Assert.That(restClient.Constructors.SelectMany(c => c.Signature.Parameters).Select(p => p.Name),
            Does.Contain("getApiVersion"));
    }

    [TestCase(false, true, true)]
    [TestCase(false, true, false)]
    [TestCase(false, false, true)]
    [TestCase(false, false, false)]
    [TestCase(true, true, true)]
    [TestCase(true, true, false)]
    [TestCase(true, false, true)]
    [TestCase(true, false, false)]
    public void ConstructorPlanIsStableAcrossDiscoveryOrder(bool isSubClient, bool eligible, bool callerFirst)
    {
        var (client, models) = InputResourceData.ClientWithSharedMockableOperations(includeNonResource: !eligible);
        if (isSubClient)
        {
            client = InputFactory.Client(client.Name, methods: client.Methods, decorators: client.Decorators,
                parent: InputFactory.Client("ParentClient", decorators: client.Decorators));
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client.Parent ?? client], inputModels: () => models);
        string RenderCaller()
        {
            var mockable = plugin.Object.OutputLibrary.TypeProviders.OfType<MockableResourceProvider>()
                .Single(p => p.ArmCoreType.Equals(typeof(Azure.ResourceManager.ArmClient)));
            return new TypeProviderWriter(mockable).Write().Content;
        }

        string? caller = callerFirst ? RenderCaller() : null;
        var restClient = plugin.Object.TypeFactory.CreateClient(client)!;
        var firstPlan = client.ConstructorApiVersion;
        _ = restClient.Fields;
        _ = restClient.Constructors;
        var requests = restClient.RestClient.Methods.Where(m => m.Signature.Name.StartsWith("Create"))
            .Select(m => m.BodyStatements!.ToDisplayString()).ToArray();
        caller ??= RenderCaller();
        var rendered = new TypeProviderWriter(restClient).Write().Content;
        var plans = plugin.Object.InputLibrary.ConstructorApiVersions;

        Assert.Multiple(() =>
        {
            Assert.That(firstPlan.HasValue, Is.EqualTo(eligible));
            Assert.That(client.ConstructorApiVersion, Is.EqualTo(firstPlan));
            Assert.That(plans.ContainsKey(client), Is.True, "Negative plans must be cached as well.");
            Assert.That(plans[client], Is.EqualTo(firstPlan));
            Assert.That(rendered.Contains("_getApiVersion"), Is.EqualTo(!eligible));
            Assert.That(caller.Contains("resourceType =>"), Is.EqualTo(!eligible));
            Assert.That(requests.Any(r => r.Contains("_getApiVersion")), Is.EqualTo(!eligible));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void OrdinaryResourceCallersUseTheWireDefault(bool isCollection)
    {
        var (client, models) = InputResourceData.ClientWithResource();
        foreach (var method in client.Methods)
        {
            method.Operation.Update(parameters: [.. method.Operation.Parameters.Where(p => !p.IsApiVersion),
                InputFactory.QueryParameter("apiVersion", InputPrimitiveType.String, isRequired: true, isApiVersion: true,
                    defaultValue: new InputConstant("opaque-common", InputPrimitiveType.String),
                    serializedName: "api-version", scope: InputParameterScope.Client)]);
        }
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        var caller = plugin.Object.OutputLibrary.TypeProviders.Single(p => isCollection
            ? p is ResourceCollectionClientProvider
            : p is ResourceClientProvider);
        var code = new TypeProviderWriter(caller).Write().Content;

        Assert.Multiple(() =>
        {
            Assert.That(code, Does.Contain("TryGetApiVersion(\"Microsoft.Tests/tests\""));
            Assert.That(code, Does.Contain("\"opaque-common\""));
            Assert.That(code, Does.Not.Contain("resourceType =>"));
        });
    }
}
