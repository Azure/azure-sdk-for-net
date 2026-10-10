// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;

internal class ApiVersionOverrideParameterOrderTests
{
    [Test]
    public void RestoredTypeContextFollowsTheCapturedInitialParameterOrder(
        [Values("filter", "page-size", "both")] string mode,
        [Values("kind", "resourceKind")] string kindName,
        [Values(false, true)] bool enumKind,
        [Values(false, true)] bool async)
    {
        var (client, models) = InputResourceData.ClientWithDynamicResourcePaging(mode, kindName, enumKind, reinjectScope: true);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models,
            inputEnums: () => client.Methods.SelectMany(m => m.Operation.Parameters).Select(p => p.Type).OfType<InputEnumType>().ToArray());
        var provider = plugin.Object.TypeFactory.CreateClient(client)!;
        var initial = provider.RestClient.Methods.Single(m => m.Signature.Name == "CreateGetAllRequest");
        var continuation = provider.RestClient.Methods.Single(m => m.Signature.Name == "CreateNextGetAllRequest");
        var continuationNames = continuation.Signature.Parameters.Skip(1).Select(p => p.Name).ToArray();
        var expectedNames = initial.Signature.Parameters.Where(p => continuationNames.Contains(p.Name)).Select(p => p.Name).ToArray();
        Assert.That(continuationNames, Is.EqualTo(expectedNames));
        Assert.That(continuationNames.Take(2), Is.EqualTo(new[] { "resourceGroupName", kindName }));
        Assert.That(continuation.Signature.Parameters.Single(p => p.WireInfo.SerializedName == "kind"),
            Is.SameAs(initial.Signature.Parameters.Single(p => p.WireInfo.SerializedName == "kind")));

        var list = (InputPagingServiceMethod)client.Methods.Single(m => m.Name == "GetAll");
        var collectionType = typeof(ManagementClientGenerator).BaseType!.Assembly.GetType("Azure.Generator.Providers.AzureCollectionResultDefinition")!;
        var collection = (TypeProvider)Activator.CreateInstance(collectionType, provider, list, plugin.Object.TypeFactory.CreateCSharpType(models[0]), async)!;
        var code = new TypeProviderWriter(collection).Write().Content;
        Assert.That(code, Does.Contain($"CreateNextGetAllRequest(nextLink, _resourceGroupName, _{kindName},"));
        var body = continuation.BodyStatements!.ToDisplayString();
        Assert.That(body, Does.Contain($"+ {kindName})) ?? \"opaque-page\""));
        Assert.That(body, Does.Not.Contain("+ resourceGroupName"));
        Assert.That(body, Does.Not.Contain("AppendPath("));
    }
}
