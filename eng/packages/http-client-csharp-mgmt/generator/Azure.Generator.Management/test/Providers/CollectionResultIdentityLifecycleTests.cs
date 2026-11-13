// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers;
internal class CollectionResultIdentityLifecycleTests
{
    [TestCase(false, "reference")]
    [TestCase(true, "reference")]
    [TestCase(false, "partial")]
    [TestCase(true, "partial")]
    [TestCase(false, "mapping")]
    [TestCase(true, "mapping")]
    public void PreviouslyEmittedCompactIdentityMustKeepItsOperation(bool isAsync, string mode)
    {
        var (first, firstClient, firstMethods, firstItem) = Scenario("");
        var firstOrdinary = first.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[0], firstItem, isAsync);
        var firstOther = first.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(firstClient, firstMethods[1], firstItem, isAsync);
        var ordinaryName = firstOrdinary.Name;
        var otherName = firstOther.Name;
        var firstBody = new TypeProviderWriter(firstOrdinary).Write().Content;
        Assert.That(firstBody, Does.Contain("CreateGetOrdinaryRequest"));
        var source = mode switch
        {
            "reference" => $$"""namespace Samples { internal class CustomPaging { internal object Create() => new {{ordinaryName}}(null, null, null); } }""",
            "partial" => $$"""namespace Samples { internal partial class {{ordinaryName}} { internal string CustomMember => "ordinary only"; } }""",
            _ => $$"""
                namespace Microsoft.TypeSpec.Generator.Customizations {
                    internal class CodeGenTypeAttribute : System.Attribute { public CodeGenTypeAttribute(string name) { } }
                }
                namespace Samples {
                    [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("{{ordinaryName}}")]
                    internal partial class {{ordinaryName}} { internal string CustomMember => "ordinary only"; }
                }
                """
        };
        var (second, secondClient, secondMethods, secondItem) = Scenario(source);
        var secondOrdinary = second.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(secondClient, secondMethods[0], secondItem, isAsync);
        var secondOther = second.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(secondClient, secondMethods[1], secondItem, isAsync);
        var selectedByReference = new[] { secondOrdinary, secondOther }.Single(helper => helper.Name == ordinaryName);
        var selectedBody = new TypeProviderWriter(selectedByReference).Write().Content;
        TestContext.WriteLine($"first ordinary={ordinaryName}, first other={otherName}; next ordinary={secondOrdinary.Name}, next other={secondOther.Name}; selected body ordinary={selectedBody.Contains("CreateGetOrdinaryRequest")}");
        Assert.Multiple(() => {
            Assert.That(secondOrdinary.Name, Is.EqualTo(ordinaryName));
            Assert.That(secondOther.Name, Is.EqualTo(otherName));
            Assert.That(selectedBody, Does.Contain("CreateGetOrdinaryRequest"));
            Assert.That(selectedBody, Does.Not.Contain("CreateGetCustomizedRequest"));
            if (mode != "reference")
            {
                Assert.That(secondOrdinary.CustomCodeView?.Properties.Select(property => property.Name), Does.Contain("CustomMember"));
                Assert.That(secondOther.CustomCodeView, Is.Null);
            }
        });
    }

    private static (Azure.Generator.Management.ManagementClientGenerator Plugin, Microsoft.TypeSpec.Generator.ClientModel.Providers.ClientProvider Client, InputPagingServiceMethod[] Methods, Microsoft.TypeSpec.Generator.Primitives.CSharpType Item) Scenario(string source)
    {
        var item = InputFactory.Model("ChildrenGetCustomized", usage: InputModelTypeUsage.Output);
        var page = InputFactory.Model("Page", usage: InputModelTypeUsage.Output, properties: [InputFactory.Property("value", InputFactory.Array(item)), InputFactory.Property("nextLink", InputPrimitiveType.String)]);
        var methods = new[] { "ListOrdinary", "ListCustomized" }.Select((name, index) => {
            var operation = InputFactory.Operation(name, responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)], path: index == 0 ? "/ordinary" : "/customized");
            return InputFactory.PagingServiceMethod(name, operation, pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        }).ToArray();
        var inputClient = InputFactory.Client("Children", methods: methods);
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item, page], customizationSources: [source]).Object;
        return (plugin, plugin.TypeFactory.CreateClient(inputClient)!, methods, plugin.TypeFactory.CreateCSharpType(item)!);
    }
}
