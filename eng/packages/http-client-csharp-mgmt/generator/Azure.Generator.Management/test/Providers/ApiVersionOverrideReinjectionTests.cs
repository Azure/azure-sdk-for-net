// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;

internal class ApiVersionOverrideReinjectionTests
{
    [Test]
    public void ExpandedResourcePagingRetainsItsTypeContextAndCallSites(
        [Values("none", "filter", "page-size", "both")] string mode,
        [Values("kind", "resourceKind")] string kindName,
        [Values(false, true)] bool enumKind,
        [Values(false, true)] bool async)
    {
        var (client, models) = InputResourceData.ClientWithDynamicResourcePaging(mode, kindName, enumKind);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models,
            inputEnums: () => client.Methods.SelectMany(m => m.Operation.Parameters).Select(p => p.Type).OfType<InputEnumType>().ToArray());
        var provider = plugin.Object.TypeFactory.CreateClient(client)!;
        var methods = provider.RestClient.Methods;
        var initial = methods.Single(m => m.Signature.Name == "CreateGetAllRequest");
        var continuation = methods.Single(m => m.Signature.Name == "CreateNextGetAllRequest");
        var initialKind = initial.Signature.Parameters.Single(p => p.WireInfo.SerializedName == "kind");
        var continuationKind = continuation.Signature.Parameters.Single(p => p.WireInfo.SerializedName == "kind");
        Assert.That(continuationKind.InputParameter, Is.SameAs(initialKind.InputParameter));
        if (mode != "none")
        {
            Assert.That(continuationKind, Is.SameAs(initialKind), "Retain the actual initial parameter, including wire name and type.");
        }
        var body = continuation.BodyStatements!.ToDisplayString();
        var serializedKind = initialKind.Type.IsEnum ? $"{kindName}.ToSerialString()" : kindName;
        Assert.That(body, Does.Contain($"Invoke(((\"Microsoft.Tests\" + \"/\") + {serializedKind})) ?? \"opaque-page\""));
        Assert.That(continuationKind.Type, Is.EqualTo(initialKind.Type));
        Assert.That(body, Does.Not.Contain("Invoke(\"Microsoft.Tests/first\")"));
        Assert.That(body, Does.Not.Contain("AppendPath("), "Retained context must not replay the original route into the next-link URI.");
        Assert.That(continuation.Signature.Parameters.Count(p => p.WireInfo.SerializedName == "kind"), Is.EqualTo(1));
        Assert.That(continuation.Signature.Parameters.Select(p => p.Name), Does.Not.Contain("name"));

        var list = (InputPagingServiceMethod)client.Methods.Single(m => m.Name == "GetAll");
        var collectionType = typeof(ManagementClientGenerator).BaseType!.Assembly.GetType("Azure.Generator.Providers.AzureCollectionResultDefinition")!;
        var collection = (TypeProvider)Activator.CreateInstance(collectionType, provider, list, plugin.Object.TypeFactory.CreateCSharpType(models[0]), async)!;
        var code = new TypeProviderWriter(collection).Write().Content;
        Assert.That(code, Does.Contain($"CreateNextGetAllRequest(nextLink, _{kindName},"));
        if (mode is "filter" or "both")
        {
            Assert.That(body, Does.Contain("AppendQuery(\"$filter\""));
        }
        if (mode is "page-size" or "both")
        {
            Assert.That(body, Does.Contain("UpdateQuery(\"maxPageSize\""));
        }
    }
}
