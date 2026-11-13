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
internal class CollectionResultOwnershipTests
{
    private const string AttributeSource = """
        namespace Microsoft.TypeSpec.Generator.Customizations {
            internal class CodeGenTypeAttribute : System.Attribute {
                public CodeGenTypeAttribute(string name) { }
            }
        }
        """;

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void CodeGenTypeOriginalNameMustNotAttachToOrdinaryHelper(bool isAsync, bool preservedFirst)
    {
        string suffix = isAsync ? "Async" : "";
        string source = AttributeSource + $$"""
            namespace Samples {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("ChildrenGetCustomized{{suffix}}CollectionResultOfT")]
                internal partial class RenamedPaging{{suffix}}CollectionResultOfT {
                    internal string CustomMember => "only for GetCustomized";
                }
            }
            """;
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildrenGetCustomized", source);
        int firstIndex = preservedFirst ? 1 : 0;
        var first = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[firstIndex], itemType, isAsync);
        var second = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[1-firstIndex], itemType, isAsync);
        var ordinary = preservedFirst ? second : first;
        var preserved = preservedFirst ? first : second;
        TestContext.WriteLine($"ordinary={ordinary.Name}, custom={ordinary.CustomCodeView?.Name}, preserved={preserved.Name}, paths={ordinary.RelativeFilePath} / {preserved.RelativeFilePath}");
        var ordinaryCode = new TypeProviderWriter(ordinary).Write().Content;
        var preservedCode = new TypeProviderWriter(preserved).Write().Content;
        var compilation = Helpers.BuildCompilation([("Ordinary.cs", ordinaryCode), ("Preserved.cs", preservedCode), ("Customization.cs", source)]);
        var collisions = compilation.GetDiagnostics().Where(d => d.Id is "CS0102" or "CS0111").ToArray();
        Assert.Multiple(() => {
            Assert.That(ordinary.Name, Is.Not.EqualTo(preserved.Name));
            Assert.That(ordinary.RelativeFilePath, Is.Not.EqualTo(preserved.RelativeFilePath));
            Assert.That(ordinary.CustomCodeView, Is.Null);
            Assert.That(collisions, Is.Empty, "Rendered helper definitions must not have duplicate members");
        });
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void ArrayHelperOwnCustomizationOrReferenceMustKeepIdentity(bool isAsync, bool referenceOnly)
    {
        string suffix = isAsync ? "Async" : "";
        string name = $"FooResourceGetValues{suffix}CollectionResultOfT";
        string source = referenceOnly
            ? $$"""namespace Samples { internal class CustomPaging { internal object Create() => new {{name}}(null, null, null); } }"""
            : $$"""namespace Samples { internal partial class {{name}} { internal string CustomMember => "preserved"; } }""";
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var operation = InputFactory.Operation("GetValues", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))]);
        var method = InputFactory.BasicServiceMethod("GetValues", operation);
        var inputClient = InputFactory.Client("Children", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var helper = new ArrayResponseCollectionResultDefinition(client, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync, [], client, $"GetValues{suffix}", "FooResource");
        TestContext.WriteLine($"expected={name}, actual={helper.Name}, custom={helper.CustomCodeView?.Name}, path={helper.RelativeFilePath}");
        Assert.Multiple(() => {
            Assert.That(helper.Name, Is.EqualTo(name));
            if (!referenceOnly) Assert.That(helper.CustomCodeView, Is.Not.Null);
        });
    }

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void ReferenceOrCustomizeGeneratedRegularIdentityOnNextRun(bool isAsync, bool referenceOnly)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var firstHelper = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync);
        var expectedName = firstHelper.Name;
        string source = referenceOnly
            ? $$"""namespace Samples { internal class CustomPaging { internal object Create() => new {{expectedName}}(null, null, null); } }"""
            : $$"""namespace Samples { internal partial class {{expectedName}} { internal string CustomMember => "preserved"; } }""";
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);
        TestContext.WriteLine($"first run={expectedName}, next run after customization/reference={helper.Name}, custom={helper.CustomCodeView?.Name}");
        Assert.Multiple(() => {
            Assert.That(helper.Name, Is.EqualTo(expectedName));
            if (!referenceOnly) Assert.That(helper.CustomCodeView, Is.Not.Null);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public void CodeGenTypeCanRenamePreviouslyGeneratedCompactIdentity(bool isAsync)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var originalName = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync).Name;
        var alias = $"CustomizedGeneratedChildren{(isAsync ? "Async" : "")}CollectionResultOfT";
        var source = AttributeSource + $$"""
            namespace Samples {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("{{originalName}}")]
                internal partial class {{alias}} { internal string CustomMember => "preserved"; }
            }
            """;
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

        Assert.That(helper.Name, Is.EqualTo(alias));
        Assert.That(helper.RelativeFilePath, Is.EqualTo(Path.Combine("src", "Generated", "CollectionResults", $"{alias}.cs")));
        Assert.That(helper.CustomCodeView, Is.Not.Null);
        Assert.That(helper.CustomCodeView!.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void QualifiedReferenceToGeneratedIdentityKeepsItsNamespace(bool isAsync)
    {
        var (firstPlugin, firstClient, firstMethods, firstItemType) = CreatePagingScenario("ChildData", "");
        var expectedName = firstPlugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItemType, isAsync).Name;
        var source = $$"""
            namespace Samples { internal class NamespaceMarker { } }
            namespace OtherNamespace {
                internal class CustomPaging {
                    internal object Create() => new global::Samples.{{expectedName}}(null, null, null);
                }
            }
            """;
        var (plugin, client, methods, itemType) = CreatePagingScenario("ChildData", source);
        var helper = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(client, methods[0], itemType, isAsync);

        Assert.That(helper.Name, Is.EqualTo(expectedName));
        Assert.That(helper.Type.Namespace, Is.EqualTo("Samples"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void NumericArrayIdentityKeepsItsCodeGenTypeCustomization(bool isAsync)
    {
        var suffix = isAsync ? "Async" : "";
        var source = AttributeSource + $$"""
            namespace Samples {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("FooResourceGetValues{{suffix}}0CollectionResultOfT")]
                internal partial class CustomizedValues{{suffix}}CollectionResultOfT { }
            }
            """;
        var item = InputFactory.Model("ChildData", usage: InputModelTypeUsage.Output);
        var operations = new[] { "FirstValues", "SecondValues" }.Select(name => InputFactory.Operation(name,
            responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))])).ToArray();
        var methods = operations.Select(operation => InputFactory.BasicServiceMethod(operation.Name, operation)).ToArray();
        var inputClient = InputFactory.Client("Children", methods: methods);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item], customizationSources: [source]).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
        var first = new ArrayResponseCollectionResultDefinition(client, methods[0], itemType, isAsync, [], client, $"GetValues{suffix}", "FooResource");
        var second = new ArrayResponseCollectionResultDefinition(client, methods[1], itemType, isAsync, [], client, $"GetValues{suffix}", "FooResource");

        Assert.That(first.Name, Is.EqualTo($"FooResourceGetValues{suffix}CollectionResultOfT"));
        Assert.That(first.CustomCodeView, Is.Null);
        Assert.That(second.Name, Is.EqualTo($"CustomizedValues{suffix}CollectionResultOfT"));
        Assert.That(second.CustomCodeView, Is.Not.Null);
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
