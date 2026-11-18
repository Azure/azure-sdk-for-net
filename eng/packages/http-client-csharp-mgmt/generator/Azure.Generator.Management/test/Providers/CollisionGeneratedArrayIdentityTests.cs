// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;
internal class CollisionGeneratedArrayIdentityTests
{
    [TestCase(false, false, "partial")]
    [TestCase(false, false, "mapping")]
    [TestCase(false, false, "reference")]
    [TestCase(false, true, "partial")]
    [TestCase(false, true, "mapping")]
    [TestCase(false, true, "reference")]
    [TestCase(true, false, "partial")]
    [TestCase(true, false, "mapping")]
    [TestCase(true, false, "reference")]
    [TestCase(true, true, "partial")]
    [TestCase(true, true, "mapping")]
    [TestCase(true, true, "reference")]
    public void CollisionGeneratedNumberedArrayMustKeepItsOwner(bool isAsync, bool arrayFirst, string customization)
    {
        var suffix = isAsync ? "Async" : "";
        var secondName = $"GetValues{suffix}";
        var name = $"FooResource{secondName}0CollectionResultOfT";
        var attribute = customization == "mapping" ? $"[Microsoft.TypeSpec.Generator.Customizations.CodeGenType(\"{name}\")]" : "";
        var source = $$"""
            namespace Microsoft.TypeSpec.Generator.Customizations {
                internal class CodeGenTypeAttribute : System.Attribute { public CodeGenTypeAttribute(string name) { } }
            }
            namespace Samples {
                {{attribute}} internal partial class {{name}} { internal string CustomMember => "second operation only"; }
            }
            """;
        if (customization == "reference")
        {
            source = $$"""namespace Samples { internal static class CustomPaging { internal static System.Type Legacy => typeof({{name}}); } }""";
        }
        var item = InputFactory.Model("FooResourceGetValues", usage: InputModelTypeUsage.Output);
        var arrayItem = InputFactory.Model("ArrayItemData", usage: InputModelTypeUsage.Output);
        var page = InputFactory.Model("Page", usage: InputModelTypeUsage.Output, properties: [InputFactory.Property("value", InputFactory.Array(item)), InputFactory.Property("nextLink", InputPrimitiveType.String)]);
        var regularOperation = InputFactory.Operation("ListOrdinary", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)]);
        var regularMethod = InputFactory.PagingServiceMethod("ListOrdinary", regularOperation, pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        var (resourceClient, resourceModels) = InputResourceData.ClientWithResource(resourceName: "Foo");
        var read = resourceClient.Methods[0];
        var arrayOperation = InputFactory.Operation("GetValues",
            responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(arrayItem))],
            parameters: read.Operation.Parameters, path: read.Operation.Path + "/values", httpMethod: "POST");
        var arrayMethod = InputFactory.BasicServiceMethod("GetValues", arrayOperation, parameters: read.Parameters);
        var secondItem = InputFactory.Model("SecondArrayItemData", usage: InputModelTypeUsage.Output);
        var depth = InputFactory.QueryParameter("depth", InputPrimitiveType.Int32, isRequired: true);
        var depthMethod = InputFactory.MethodParameter("depth", InputPrimitiveType.Int32, isRequired: true, location: InputRequestLocation.Query);
        var secondOperation = InputFactory.Operation("GetValues",
            responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(secondItem))],
            parameters: [.. read.Operation.Parameters, depth], path: read.Operation.Path + "/otherValues", httpMethod: "POST");
        var secondMethod = InputFactory.BasicServiceMethod("GetValues", secondOperation, parameters: [.. read.Parameters, depthMethod]);
        var decorator = resourceClient.Decorators.Single();
        var arguments = decorator.Arguments!.ToDictionary(pair => pair.Key, pair => pair.Value);
        var resources = System.Text.Json.Nodes.JsonNode.Parse(arguments["resources"].ToString())!.AsArray();
        var methods = resources[0]!["methods"]!.AsArray();
        while (methods.Count > 1)
        {
            methods.RemoveAt(1);
        }
        methods.Add(System.Text.Json.JsonSerializer.SerializeToNode(new
        {
            methodId = arrayMethod.CrossLanguageDefinitionId,
            kind = "Action",
            operationPath = arrayOperation.Path,
            scope = new { kind = "ResourceGroup", scopeIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}" }
        }));
        methods.Add(System.Text.Json.JsonSerializer.SerializeToNode(new
        {
            methodId = secondMethod.CrossLanguageDefinitionId,
            kind = "Action",
            operationPath = secondOperation.Path,
            scope = new { kind = "ResourceGroup", scopeIdPattern = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}" }
        }));
        arguments["resources"] = BinaryData.FromString(resources.ToJsonString());
        var inputClient = InputFactory.Client("Children", methods: [read, regularMethod, arrayMethod, secondMethod],
            decorators: [new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", arguments)]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient],
            inputModels: () => [item, arrayItem, secondItem, page, .. resourceModels], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
        var arrayItemType = plugin.TypeFactory.CreateCSharpType(arrayItem)!;
        var resource = plugin.OutputLibrary.ResourceProviders.Single();
        var planned = resource.ArrayCollectionResultPlans.SelectMany(plan => plan.GetOriginalNames()).ToArray();
        TestContext.WriteLine("planned identities=" + string.Join(", ", planned));
        Assert.That(planned.Count(value => value == $"FooResourceGetValues{suffix}CollectionResultOfT"), Is.EqualTo(2), "Both real plans must have the same helper base");
        var parameters = client.GetRequestMethodByOperation(arrayOperation).Signature.Parameters
            .Where(parameter => parameter.Name is not ("context" or "cancellationToken")).ToArray();
        var secondParameters = client.GetRequestMethodByOperation(secondOperation).Signature.Parameters
            .Where(parameter => parameter.Name is not ("context" or "cancellationToken")).ToArray();
        ArrayResponseCollectionResultDefinition? first = null;
        ArrayResponseCollectionResultDefinition? second = null;
        var secondType = plugin.TypeFactory.CreateCSharpType(secondItem)!;
        if (arrayFirst)
        {
            first = new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name);
            second = new ArrayResponseCollectionResultDefinition(client, secondMethod, secondType, isAsync, secondParameters, resource, secondName, resource.Name);
        }
        var regular = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, regularMethod, itemType, isAsync);
        first ??= new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name);
        second ??= new ArrayResponseCollectionResultDefinition(client, secondMethod, secondType, isAsync, secondParameters, resource, secondName, resource.Name);
        TestContext.WriteLine($"first={first.Name}, first custom={first.CustomCodeView?.Name}, second={second.Name}, second custom={second.CustomCodeView?.Name}, regular={regular.Name}");
        var selected = new Microsoft.TypeSpec.Generator.Providers.TypeProvider[] { regular, first, second }.Single(helper => helper.Name == name);
        var selectedBody = new Microsoft.TypeSpec.Generator.Primitives.TypeProviderWriter(selected).Write().Content;
        TestContext.WriteLine($"selected {name} uses intended overload={selectedBody.Contains("_depth")}");
        Assert.Multiple(() => {
            Assert.That(regular.Name, Is.Not.EqualTo(name));
            Assert.That(selectedBody, Does.Contain("CreateGetValuesRequest"));
            Assert.That(selectedBody, Does.Contain("_depth"), "The numbered helper belongs to the second overload");
            Assert.That(selectedBody, Does.Contain("SecondArrayItemData"));
            Assert.That(selectedBody, Does.Not.Contain("CreateGetOrdinaryRequest"));
            Assert.That(first.Name, Is.Not.EqualTo(name));
            Assert.That(first.CustomCodeView, Is.Null);
            Assert.That(second.Name, Is.EqualTo(name));
            if (customization != "reference")
            {
                Assert.That(second.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
            }
            Assert.That(first.RelativeFilePath, Is.Not.EqualTo(second.RelativeFilePath));
        });
    }
}
