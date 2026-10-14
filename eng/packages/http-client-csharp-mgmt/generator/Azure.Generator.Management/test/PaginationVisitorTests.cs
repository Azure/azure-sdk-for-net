// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests;

public class PaginationVisitorTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void PagingDeserializesResponseWithFromResponse(bool isAsync)
    {
        var item = InputFactory.Model("Item");
        var page = InputFactory.Model("ItemListResult", properties:
        [
            InputFactory.Property("value", InputFactory.Array(item), isRequired: true),
            InputFactory.Property("nextLink", InputPrimitiveType.Url)
        ]);
        var operation = InputFactory.Operation("ListItems",
            responses: [InputFactory.OperationResponse(bodytype: page)]);
        var method = InputFactory.PagingServiceMethod("ListItems", operation,
            pagingMetadata: InputFactory.NextLinkPagingMetadata("value", "nextLink", InputResponseLocation.Body));
        var client = InputFactory.Client("Items", methods: [method]);
        var plugin = ManagementMockHelpers.LoadMockPlugin(
            inputModels: () => [item, page], clients: () => [client]).Object;
        var clientProvider = plugin.TypeFactory.CreateClient(client)!;
        var collection = plugin.TypeFactory.ClientResponseApi.CreateClientCollectionResultDefinition(
            clientProvider, method, plugin.TypeFactory.CreateCSharpType(item)!, isAsync);

        var visitTypeCore = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
        visitTypeCore.Invoke(new PaginationVisitor(), [collection]);
        var code = new TypeProviderWriter(collection).Write().Content;

        if (isAsync)
        {
            Assert.That(collection.Methods.Any(m => m.Signature.Name == "AsPagesAsync"), Is.True,
                "Exercise the private async iterator introduced by the new dependency.");
        }
        Assert.That(code, Does.Contain("ItemListResult.FromResponse(response)"));
        Assert.That(code, Does.Not.Match(@"\bItemListResult\)response\b"),
            "Azure.Response cannot be cast to the list-result model.");
    }
}
