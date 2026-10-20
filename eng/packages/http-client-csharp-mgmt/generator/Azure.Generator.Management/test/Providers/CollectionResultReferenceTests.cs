// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;
internal class CollectionResultReferenceTests
{
    private const string AttributeSource = """
        namespace Microsoft.TypeSpec.Generator.Customizations {
            internal class CodeGenTypeAttribute : System.Attribute {
                public CodeGenTypeAttribute(string name) { }
            }
            internal class PagingTypeAttribute : CodeGenTypeAttribute {
                public PagingTypeAttribute(string name) : base(name) { }
            }
        }
        """;

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public void ReferencedCodeGenTypeMappingKeepsNamespace(bool isAsync, bool keepName)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var originalName = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync).Name;
        var alias = keepName ? originalName : $"CustomizedGeneratedChildren{(isAsync ? "Async" : "")}CollectionResultOfT";
        var source = AttributeSource + $$"""
            namespace OtherNamespace {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("{{originalName}}")]
                internal partial class {{alias}} { internal string CustomMember => "preserved"; internal {{alias}} Self => this; }
            }
            """;
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

        TestContext.WriteLine($"expected alias={alias}, actual={helper.Name}, namespace={helper.Type.Namespace}, custom={helper.CustomCodeView?.Name}");
        Assert.Multiple(() => {
            Assert.That(helper.Type.Namespace, Is.EqualTo("OtherNamespace"));
            Assert.That(helper.Name, Is.EqualTo(alias));
            Assert.That(helper.RelativeFilePath, Is.EqualTo(Path.Combine("src", "Generated", "CollectionResults", $"{alias}.cs")));
            Assert.That(helper.CustomCodeView, Is.Not.Null);
            Assert.That(helper.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void MovedArraySelfReferenceMustKeepCustomization(bool isAsync)
    {
        var suffix = isAsync ? "Async" : "";
        var name = $"FooResourceGetValues{suffix}CollectionResultOfT";
        var source = AttributeSource + $$"""
            namespace OtherNamespace {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("{{name}}")]
                internal partial class {{name}} {
                    internal {{name}} Self => this;
                    internal string CustomMember => "preserved";
                }
            }
            """;
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var operation = InputFactory.Operation("GetValues", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))]);
        var method = InputFactory.BasicServiceMethod("GetValues", operation);
        var inputClient = InputFactory.Client("Children", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var helper = new ArrayResponseCollectionResultDefinition(client, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync, [], client, $"GetValues{suffix}", "FooResource");
        TestContext.WriteLine($"expected={name}, actual={helper.Name}, namespace={helper.Type.Namespace}, custom={helper.CustomCodeView?.Name}");
        Assert.Multiple(() => {
            Assert.That(helper.Name, Is.EqualTo(name));
            Assert.That(helper.Type.Namespace, Is.EqualTo("OtherNamespace"));
            Assert.That(helper.CustomCodeView, Is.Not.Null);
            Assert.That(helper.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
        });
    }

    [TestCase(false, "global")]
    [TestCase(true, "global")]
    [TestCase(false, "relative")]
    [TestCase(true, "relative")]
    [TestCase(false, "alias")]
    [TestCase(true, "alias")]
    [TestCase(false, "escapedAlias")]
    [TestCase(true, "escapedAlias")]
    public void QualifiedArrayReferenceMustKeepIdentity(bool isAsync, string qualification)
    {
        string suffix = isAsync ? "Async" : "";
        string name = $"FooResourceGetValues{suffix}CollectionResultOfT";
        var qualifier = qualification switch { "global" => "global::Samples", "relative" => "Samples", "escapedAlias" => "@Generated", _ => "Generated" };
        var import = qualification is "alias" or "escapedAlias" ? "using Generated = global::Samples;" : "";
        string source = $$"""
            namespace OtherNamespace {
                {{import}}
                internal class CustomPaging { internal object Create() => new {{qualifier}}.{{name}}(null, null, null); }
            }
            """;
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var operation = InputFactory.Operation("GetValues", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))]);
        var method = InputFactory.BasicServiceMethod("GetValues", operation);
        var inputClient = InputFactory.Client("Children", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var helper = new ArrayResponseCollectionResultDefinition(client, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync, [], client, $"GetValues{suffix}", "FooResource");
        TestContext.WriteLine($"expected={name}, actual={helper.Name}, custom={helper.CustomCodeView?.Name}, path={helper.RelativeFilePath}");
        Assert.That(helper.Name, Is.EqualTo(name));
    }

    [TestCase(false, "global")]
    [TestCase(true, "global")]
    [TestCase(false, "relative")]
    [TestCase(true, "relative")]
    [TestCase(false, "alias")]
    [TestCase(true, "alias")]
    [TestCase(false, "escapedAlias")]
    [TestCase(true, "escapedAlias")]
    public void QualifiedRegularReferenceMustKeepIdentity(bool isAsync, string qualification)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var firstHelper = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync);
        var expectedName = firstHelper.Name;
        var qualifier = qualification switch { "global" => "global::Samples", "relative" => "Samples", "escapedAlias" => "@Generated", _ => "Generated" };
        var import = qualification is "alias" or "escapedAlias" ? "using Generated = global::Samples;" : "";
        string source = $$"""
            namespace OtherNamespace {
                {{import}}
                internal class CustomPaging { internal object Create() => new {{qualifier}}.{{expectedName}}(null, null, null); }
            }
            """;
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
        TestContext.WriteLine($"first run={expectedName}, next run after customization/reference={helper.Name}, custom={helper.CustomCodeView?.Name}");
        Assert.That(helper.Name, Is.EqualTo(expectedName));
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public void ParentNamespaceArrayReferenceMustKeepIdentity(bool isAsync, bool fileScoped)
    {
        string suffix = isAsync ? "Async" : "";
        string name = $"FooResourceGetValues{suffix}CollectionResultOfT";
        string source = $$"""
            namespace Samples.Customizations {
                internal class CustomPaging { internal object Create() => new {{name}}(null, null, null); }
            }
            """;
        if (fileScoped) source = $$"""namespace Samples.Customizations; internal class CustomPaging { internal object Create() => new {{name}}(null, null, null); }""";
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var operation = InputFactory.Operation("GetValues", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))]);
        var method = InputFactory.BasicServiceMethod("GetValues", operation);
        var inputClient = InputFactory.Client("Children", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var helper = new ArrayResponseCollectionResultDefinition(client, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync, [], client, $"GetValues{suffix}", "FooResource");
        TestContext.WriteLine($"expected={name}, actual={helper.Name}, custom={helper.CustomCodeView?.Name}, path={helper.RelativeFilePath}");
        Assert.That(helper.Name, Is.EqualTo(name));
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public void ParentNamespaceRegularReferenceMustKeepIdentity(bool isAsync, bool fileScoped)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var firstHelper = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync);
        var expectedName = firstHelper.Name;
        string source = $$"""
            namespace Samples.Customizations {
                internal class CustomPaging { internal object Create() => new {{expectedName}}(null, null, null); }
            }
            """;
        if (fileScoped) source = $$"""namespace Samples.Customizations; internal class CustomPaging { internal object Create() => new {{expectedName}}(null, null, null); }""";
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
        TestContext.WriteLine($"first run={expectedName}, next run after customization/reference={helper.Name}, custom={helper.CustomCodeView?.Name}");
        Assert.That(helper.Name, Is.EqualTo(expectedName));
    }

    private static (ManagementClientGenerator Plugin, ClientProvider Client, InputPagingServiceMethod[] Methods, CSharpType ItemType) CreatePagingScenario(string itemName, string source)
    {
        var item = InputFactory.Model(itemName, usage: InputModelTypeUsage.Output);
        var page = InputFactory.Model("ChildList", usage: InputModelTypeUsage.Output, properties: [InputFactory.Property("value", InputFactory.Array(item)), InputFactory.Property("nextLink", InputPrimitiveType.String)]);
        var methods = new[] { "ListOrdinary", "ListCustomized" }.Select(name => {
            var op = InputFactory.Operation(name, responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)]);
            return InputFactory.PagingServiceMethod(name, op, pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        }).ToArray();
        var inputClient = InputFactory.Client("Children", methods: methods);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item, page], customizationSources: [source]).Object;
        return (plugin, plugin.TypeFactory.CreateClient(inputClient)!, methods, plugin.TypeFactory.CreateCSharpType(item)!);
    }
}
