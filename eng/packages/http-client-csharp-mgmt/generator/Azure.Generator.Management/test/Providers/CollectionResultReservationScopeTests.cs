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
internal class CollectionResultReservationScopeTests
{
    [TestCase(false, false, false)]
    [TestCase(false, false, true)]
    [TestCase(false, true, false)]
    [TestCase(false, true, true)]
    [TestCase(true, false, false)]
    [TestCase(true, false, true)]
    [TestCase(true, true, false)]
    [TestCase(true, true, true)]
    public void RegularMustNotClaimPreservedArrayIdentity(bool isAsync, bool arrayFirst, bool referenceOnly)
    {
        var suffix = isAsync ? "Async" : "";
        var name = $"FooResourceGetValues{suffix}CollectionResultOfT";
        var source = referenceOnly
            ? $$"""namespace Samples { internal class CustomPaging { internal object Create() => new {{name}}(null, null, null, null, null, null); } }"""
            : $$"""namespace Samples { internal partial class {{name}} { internal string CustomMember => "array operation"; } }""";
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
        arguments["resources"] = BinaryData.FromString(resources.ToJsonString());
        var inputClient = InputFactory.Client("Children", methods: [read, regularMethod, arrayMethod],
            decorators: [new InputDecoratorInfo("Azure.ClientGenerator.Core.@armProviderSchema", arguments)]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient],
            inputModels: () => [item, arrayItem, page, .. resourceModels], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
        var arrayItemType = plugin.TypeFactory.CreateCSharpType(arrayItem)!;
        var resource = plugin.OutputLibrary.ResourceProviders.Single();
        var parameters = client.GetRequestMethodByOperation(arrayOperation).Signature.Parameters
            .Where(parameter => parameter.Name is not ("context" or "cancellationToken")).ToArray();
        var array = arrayFirst ? new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name) : null;
        var regular = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, regularMethod, itemType, isAsync);
        array ??= new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name);
        TestContext.WriteLine($"array={array.Name}, regular={regular.Name}, array custom={array.CustomCodeView?.Name}, regular custom={regular.CustomCodeView?.Name}");
        Assert.Multiple(() => {
            Assert.That(array.Name, Is.EqualTo(name));
            Assert.That(array.Constructors.Single().Signature.Parameters.Count, Is.EqualTo(6));
            Assert.That(regular.Name, Is.Not.EqualTo(name));
            Assert.That(regular.RelativeFilePath, Is.Not.EqualTo(array.RelativeFilePath));
            Assert.That(regular.CustomCodeView, Is.Null);
            if (!referenceOnly) Assert.That(array.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
        });
    }

    [TestCase(false, false, false)]
    [TestCase(false, false, true)]
    [TestCase(false, true, false)]
    [TestCase(false, true, true)]
    [TestCase(true, false, false)]
    [TestCase(true, false, true)]
    [TestCase(true, true, false)]
    [TestCase(true, true, true)]
    public void UnrelatedNamespaceHomonymMustNotRenameHelper(bool isAsync, bool array, bool referenceOnly)
    {
        var name = array ? $"FooResourceGetValues{(isAsync ? "Async" : "")}CollectionResultOfT" : GetRegularName(isAsync, "Samples");
        var intended = referenceOnly
            ? $$"""internal class CustomPaging { internal object Create() => new {{name}}(null, null, null); }"""
            : $$"""internal partial class {{name}} { internal string CustomMember => "intended helper"; }""";
        var source = $$"""
            namespace Other { internal class {{name}} { } }
            namespace Samples { {{intended}} }
            """;
        var helper = CreateHelper(isAsync, array, "Samples", source);
        TestContext.WriteLine($"expected={name}, actual={helper.Name}, custom={helper.CustomCodeView?.Name}");
        Assert.Multiple(() => {
            Assert.That(helper.Name, Is.EqualTo(name));
            if (!referenceOnly) Assert.That(helper.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
        });
    }

    [TestCase(false, false, false, false)]
    [TestCase(false, false, false, true)]
    [TestCase(false, false, true, false)]
    [TestCase(false, false, true, true)]
    [TestCase(false, true, false, false)]
    [TestCase(false, true, false, true)]
    [TestCase(false, true, true, false)]
    [TestCase(false, true, true, true)]
    [TestCase(true, false, false, false)]
    [TestCase(true, false, false, true)]
    [TestCase(true, false, true, false)]
    [TestCase(true, false, true, true)]
    [TestCase(true, true, false, false)]
    [TestCase(true, true, false, true)]
    [TestCase(true, true, true, false)]
    [TestCase(true, true, true, true)]
    public void AliasQualifiedReferenceMustKeepIdentity(bool isAsync, bool array, bool nested, bool escaped)
    {
        var primaryNamespace = nested ? "Samples.Nested" : "Samples";
        var name = array ? $"FooResourceGetValues{(isAsync ? "Async" : "")}CollectionResultOfT" : GetRegularName(isAsync, primaryNamespace);
        var alias = escaped ? "@Generated" : "Generated";
        var qualification = nested ? $"{alias}::Nested" : alias + "::";
        var reference = nested ? $"{qualification}.{name}" : qualification + name;
        var source = $$"""
            namespace OtherNamespace {
                using Generated = global::Samples;
                internal class CustomPaging { internal object Create() => new {{reference}}(null, null, null); }
            }
            """;
        var helper = CreateHelper(isAsync, array, primaryNamespace, source);
        TestContext.WriteLine($"reference={reference}, expected={name}, actual={helper.Name}, namespace={helper.Type.Namespace}");
        Assert.That(helper.Name, Is.EqualTo(name));
    }

    [TestCase(false, false, "block")]
    [TestCase(false, false, "fileScoped")]
    [TestCase(false, false, "enclosing")]
    [TestCase(false, true, "block")]
    [TestCase(false, true, "fileScoped")]
    [TestCase(false, true, "enclosing")]
    [TestCase(true, false, "block")]
    [TestCase(true, false, "fileScoped")]
    [TestCase(true, false, "enclosing")]
    [TestCase(true, true, "block")]
    [TestCase(true, true, "fileScoped")]
    [TestCase(true, true, "enclosing")]
    public void NamespaceRelativeImportMustKeepIdentity(bool isAsync, bool array, string declarationStyle)
    {
        var name = array ? $"FooResourceGetValues{(isAsync ? "Async" : "")}CollectionResultOfT" : GetRegularName(isAsync, "Root.Samples");
        var declaration = $$"""internal class CustomPaging { internal object Create() => new {{name}}(null, null, null); }""";
        var source = declarationStyle switch
        {
            "block" => $$"""namespace Root { using Samples; {{declaration}} }""",
            "fileScoped" => $$"""namespace Root; using Samples; {{declaration}}""",
            _ => $$"""namespace Root { using Samples; namespace Child { {{declaration}} } }"""
        };
        var helper = CreateHelper(isAsync, array, "Root.Samples", source);
        TestContext.WriteLine($"style={declarationStyle}, expected={name}, actual={helper.Name}, namespace={helper.Type.Namespace}");
        Assert.That(helper.Name, Is.EqualTo(name));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ReferenceToUnrelatedUpstreamHomonymMustNotDisableShortening(bool isAsync)
    {
        var expected = GetRegularName(isAsync, "Samples");
        var unrelatedName = $"ChildrenGetOrdinary{(isAsync ? "Async" : "")}CollectionResultOfT";
        var source = $$"""
            namespace Other {
                internal class {{unrelatedName}} {
                    internal {{unrelatedName}}(object a, object b, object c) { }
                }
                internal class CustomPaging {
                    internal object Create() => new {{unrelatedName}}(null, null, null);
                }
            }
            """;
        var helper = CreateHelper(isAsync, false, "Samples", source);
        Assert.That(helper.Name, Is.EqualTo(expected));
    }

    [TestCase(false, false, false)]
    [TestCase(false, false, true)]
    [TestCase(false, true, false)]
    [TestCase(false, true, true)]
    [TestCase(true, false, false)]
    [TestCase(true, false, true)]
    [TestCase(true, true, false)]
    [TestCase(true, true, true)]
    public void NumberedArrayMustNotClaimAnotherOriginalIdentity(bool isAsync, bool arrayFirst, bool mappedPartial)
    {
        var suffix = isAsync ? "Async" : "";
        var secondName = $"GetValues{suffix}0";
        var name = $"FooResource{secondName}CollectionResultOfT";
        var attribute = mappedPartial ? $"[Microsoft.TypeSpec.Generator.Customizations.CodeGenType(\"{name}\")]" : "";
        var source = $$"""
            namespace Microsoft.TypeSpec.Generator.Customizations {
                internal class CodeGenTypeAttribute : System.Attribute { public CodeGenTypeAttribute(string name) { } }
            }
            namespace Samples {
                {{attribute}} internal partial class {{name}} { internal string CustomMember => "second operation only"; }
            }
            """;
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
        var secondOperation = InputFactory.Operation(secondName,
            responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(secondItem))],
            parameters: read.Operation.Parameters, path: read.Operation.Path + "/values0", httpMethod: "POST");
        var secondMethod = InputFactory.BasicServiceMethod(secondName, secondOperation, parameters: read.Parameters);
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
        var parameters = client.GetRequestMethodByOperation(arrayOperation).Signature.Parameters
            .Where(parameter => parameter.Name is not ("context" or "cancellationToken")).ToArray();
        ArrayResponseCollectionResultDefinition? first = null;
        ArrayResponseCollectionResultDefinition? second = null;
        var secondType = plugin.TypeFactory.CreateCSharpType(secondItem)!;
        if (arrayFirst)
        {
            first = new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name);
            second = new ArrayResponseCollectionResultDefinition(client, secondMethod, secondType, false, parameters, resource, secondName, resource.Name);
        }
        var regular = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, regularMethod, itemType, isAsync);
        first ??= new ArrayResponseCollectionResultDefinition(client, arrayMethod, arrayItemType, isAsync, parameters, resource, $"GetValues{suffix}", resource.Name);
        second ??= new ArrayResponseCollectionResultDefinition(client, secondMethod, secondType, false, parameters, resource, secondName, resource.Name);
        TestContext.WriteLine($"first={first.Name}, first custom={first.CustomCodeView?.Name}, second={second.Name}, second custom={second.CustomCodeView?.Name}, regular={regular.Name}");
        Assert.Multiple(() => {
            Assert.That(first.Name, Is.Not.EqualTo(name));
            Assert.That(first.CustomCodeView, Is.Null);
            Assert.That(second.Name, Is.EqualTo(name));
            Assert.That(second.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
            Assert.That(first.RelativeFilePath, Is.Not.EqualTo(second.RelativeFilePath));
        });
    }

    [TestCase(false, "plain")]
    [TestCase(true, "plain")]
    [TestCase(false, "global")]
    [TestCase(true, "global")]
    [TestCase(false, "aliasDot")]
    [TestCase(true, "aliasDot")]
    [TestCase(false, "aliasColon")]
    [TestCase(true, "aliasColon")]
    [TestCase(false, "nestedAlias")]
    [TestCase(true, "nestedAlias")]
    public void NameofUpstreamHelperMustKeepIdentity(bool isAsync, string syntax)
    {
        var ns = syntax == "nestedAlias" ? "Samples.Nested" : "Samples";
        var name = $"ChildrenGetOrdinary{(isAsync ? "Async" : "")}CollectionResultOfT";
        var expression = syntax switch
        {
            "plain" => $"Samples.{name}",
            "global" => $"global::Samples.{name}",
            "aliasDot" => $"Generated.{name}",
            "aliasColon" => $"Generated::{name}",
            _ => $"Generated::Nested.{name}"
        };
        var source = $$"""
            namespace OtherNamespace {
                using Generated = global::Samples;
                internal class CustomPaging { internal string HelperName => nameof({{expression}}); }
            }
            """;
        var helper = CreateHelper(isAsync, false, ns, source);
        TestContext.WriteLine($"nameof={expression}, actual={helper.Name}, namespace={helper.Type.Namespace}");
        Assert.That(helper.Name, Is.EqualTo(name));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void NameofUnrelatedResolvedHomonymMustNotPreserveUpstreamName(bool isAsync)
    {
        var name = $"ChildrenGetOrdinary{(isAsync ? "Async" : "")}CollectionResultOfT";
        var expected = GetRegularName(isAsync, "Samples");
        var source = $$"""
            namespace Other { internal class {{name}} { } }
            namespace Samples { internal class CustomPaging { internal string HelperName => nameof(global::Other.{{name}}); } }
            """;
        Assert.That(CreateHelper(isAsync, false, "Samples", source).Name, Is.EqualTo(expected));
    }

    private static string GetRegularName(bool isAsync, string primaryNamespace) => CreateHelper(isAsync, false, primaryNamespace, "").Name;

    private static TypeProvider CreateHelper(bool isAsync, bool array, string primaryNamespace, string source)
    {
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var page = InputFactory.Model("Page", usage: InputModelTypeUsage.Output, properties: [InputFactory.Property("value", InputFactory.Array(item)), InputFactory.Property("nextLink", InputPrimitiveType.String)]);
        var operation = InputFactory.Operation(array ? "GetValues" : "ListOrdinary", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: array ? InputFactory.Array(item) : page)]);
        InputServiceMethod method = array
            ? InputFactory.BasicServiceMethod("GetValues", operation)
            : InputFactory.PagingServiceMethod("ListOrdinary", operation, pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        var inputClient = InputFactory.Client("Children", clientNamespace: primaryNamespace, methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item, page], customizationSources: [source], primaryNamespace: primaryNamespace).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
        return array
            ? new ArrayResponseCollectionResultDefinition(client, method, itemType, isAsync, [], client, $"GetValues{(isAsync ? "Async" : "")}", "FooResource")
            : plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, (InputPagingServiceMethod)method, itemType, isAsync);
    }
}
