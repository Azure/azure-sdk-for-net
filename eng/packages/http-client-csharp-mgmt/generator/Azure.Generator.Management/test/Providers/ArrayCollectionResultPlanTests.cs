// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections;
using System.Reflection;

namespace Azure.Generator.Management.Tests.Providers;
internal class ArrayCollectionResultPlanTests
{
    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public void PlanningUsesFinalNamesWithoutAllocatingPagingHelpersOrChangingInputs(bool oldContract, bool renamedOwner)
    {
        var item = InputFactory.Model("Entry", usage: InputModelTypeUsage.Output);
        var arrayOperation = InputFactory.Operation("GetUrl", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: InputFactory.Array(item))]);
        arrayOperation.GetType().GetProperty("OriginalName")!.GetSetMethod(true)!.Invoke(arrayOperation, ["GetUrl"]);
        var arrayMethod = InputFactory.BasicServiceMethod("GetUrl", arrayOperation);
        var page = InputFactory.Model("Page", usage: InputModelTypeUsage.Output, properties: [InputFactory.Property("value", InputFactory.Array(item)), InputFactory.Property("nextLink", InputPrimitiveType.String)]);
        var pagingOperation = InputFactory.Operation("ListEntries", responses: [InputFactory.OperationResponse(statusCodes: [200], bodytype: page)]);
        var pagingMethod = InputFactory.PagingServiceMethod("ListEntries", pagingOperation, pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        var inputClient = InputFactory.Client("TestClient", methods: [pagingMethod, arrayMethod]);
        var ownerName = renamedOwner ? "RenamedOwner" : "Owner";
        var ownerNamespace = renamedOwner ? "Other" : "Samples";
        var custom = renamedOwner ? """
            namespace Microsoft.TypeSpec.Generator.Customizations {
                internal class CodeGenTypeAttribute : System.Attribute { public CodeGenTypeAttribute(string name) { } }
            }
            namespace Other {
                [Microsoft.TypeSpec.Generator.Customizations.CodeGenType("Owner")]
                internal partial class RenamedOwner { }
            }
            """ : "";
        var contract = $$"""
            namespace {{ownerNamespace}} {
                public partial class {{ownerName}} {
                    public void GetUrl() { }
                    public void GetUrlAsync() { }
                }
            }
            """;
        var plugin = ManagementMockHelpers.LoadMockPlugin(clients: () => [inputClient], inputModels: () => [item, page],
            customizationSources: [custom], lastContractCompilation: () => oldContract ? Helpers.BuildCompilation([("Contract.cs", contract)]) : null).Object;
        var client = plugin.TypeFactory.CreateClient(inputClient)!;
        var owner = new TestTypeProvider(name: "Owner", ns: "Samples");
        var methods = inputClient.Methods.ToArray();
        var methodName = arrayMethod.Name;
        var operationName = arrayOperation.Name;
        var plan = new ArrayResponseCollectionResultPlan(owner, inputClient, arrayMethod);
        var names = plan.GetOriginalNames().ToArray();
        var expectedMethod = oldContract ? "GetUrl" : "GetUri";
        var cache = (IDictionary)typeof(ManagementOutputLibrary).GetField("_regularCollectionResultNames", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(plugin.OutputLibrary)!;
        Assert.Multiple(() => {
            Assert.That(names, Is.EqualTo(new[] { $"{ownerName}{expectedMethod}CollectionResultOfT", $"{ownerName}{expectedMethod}AsyncCollectionResultOfT" }));
            Assert.That(cache.Count, Is.Zero, "Planning must not construct the sibling paging method");
            Assert.That(inputClient.Methods, Is.EqualTo(methods));
            Assert.That(arrayMethod.Name, Is.EqualTo(methodName));
            Assert.That(arrayOperation.Name, Is.EqualTo(operationName));
            Assert.That(plugin.InputLibrary.GetClientByMethod(arrayMethod), Is.SameAs(inputClient));
            Assert.That(plugin.InputLibrary.GetClientByMethod(pagingMethod), Is.SameAs(inputClient));
        });
        Assert.That(plugin.OutputLibrary.TypeProviders.OfType<ClientProvider>().Count(), Is.EqualTo(1), "The temporary naming client must not be emitted");
        var itemType = plugin.TypeFactory.CreateCSharpType(item)!;
        foreach (var isAsync in new[] { false, true })
        {
            var emittedName = client.GetConvenienceMethodByOperation(arrayOperation, isAsync, owner).Signature.Name;
            var helper = new ArrayResponseCollectionResultDefinition(client, arrayMethod, itemType, isAsync, [], owner, emittedName, owner.Name);
            Assert.That(names, Does.Contain(helper.Name));
            Assert.That(helper.Type.Namespace, Is.EqualTo(plugin.TypeFactory.PrimaryNamespace));
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public void GetAllVariantOrderDoesNotChangeCollisionIdentities(bool occupiedSlots)
    {
        Dictionary<(int Method, bool IsAsync), string> Allocate(bool syncFirst)
        {
            var library = ManagementMockHelpers.LoadMockPlugin().Object.OutputLibrary;
            if (occupiedSlots)
            {
                foreach (var name in new[] { "OwnerGetAll", "OwnerGetAll0", "OwnerGetAllAsync", "OwnerGetAllAsync0" })
                {
                    library.GetUniqueCollectionResultName(name);
                }
            }
            var names = new Dictionary<(int Method, bool IsAsync), string>();
            for (var method = 0; method < 3; method++)
            {
                foreach (var isAsync in syncFirst ? new[] { false, true } : new[] { true, false })
                {
                    names.Add((method, isAsync), library.GetUniqueCollectionResultName($"OwnerGetAll{(isAsync ? "Async" : "")}"));
                }
            }
            return names;
        }

        var syncFirst = Allocate(true);
        var asyncFirst = Allocate(false);
        Assert.That(asyncFirst, Is.EqualTo(syncFirst), "GetAll and GetAllAsync allocate from disjoint numeric-suffix families");
        Assert.That(asyncFirst[(0, false)], Is.EqualTo(occupiedSlots ? "OwnerGetAll1" : "OwnerGetAll"));
        Assert.That(asyncFirst[(0, true)], Is.EqualTo(occupiedSlots ? "OwnerGetAllAsync1" : "OwnerGetAllAsync"));
    }

    [Test]
    public void LongRunningArrayResponseIsNotAnArrayPlan()
    {
        var (client, models) = InputResourceData.ClientWithResourceLroArrayAction();
        ManagementMockHelpers.LoadMockPlugin(clients: () => [client], inputModels: () => models);
        Assert.That(client.Methods.Where(method => method.IsLongRunningOperation()).Select(ArrayResponseCollectionResultPlan.IsArrayResponse), Is.All.False);
    }
}
