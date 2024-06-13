// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class PageableCollectionTests
{
    private static readonly string[] MockPageContents = { """
            [
                { "intValue" : 0, "stringValue" : "0" },
                { "intValue" : 1, "stringValue" : "1" },
                { "intValue" : 2, "stringValue" : "2" }
            ]
            ""","""
            [
                { "intValue" : 3, "stringValue" : "3" },
                { "intValue" : 4, "stringValue" : "4" },
                { "intValue" : 5, "stringValue" : "5" }
            ]
            ""","""
            [
                { "intValue" : 6, "stringValue" : "6" },
                { "intValue" : 7, "stringValue" : "7" },
                { "intValue" : 8, "stringValue" : "8" }
            ]
            """,
        };

    private static readonly int PageCount = MockPageContents.Length;
    private static readonly int ItemCount = 9;

    [Test]
    public void CanEnumerateValues()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

        int i = 0;
        foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(ItemCount, i);
    }

    [Test]
    public void CanEnumeratePages()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

        int pageCount = 0;
        int itemCount = 0;
        foreach (ResultPage<MockJsonModel> page in models.AsPages())
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(itemCount, model.IntValue);
                Assert.AreEqual(itemCount.ToString(), model.StringValue);

                itemCount++;
            }

            pageCount++;
        }

        Assert.AreEqual(ItemCount, itemCount);
        Assert.AreEqual(PageCount, pageCount);
    }

    [Test]
    public void CanStartPageEnumerationMidwayThrough()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

        int pageCount = 0;
        int i = 6;

        // Request just the last page by starting at the last seen value
        // on the prior page -- i.e. item 5.
        foreach (ResultPage<MockJsonModel> page in models.AsPages(continuationToken: "5"))
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(i, model.IntValue);
                Assert.AreEqual(i.ToString(), model.StringValue);

                i++;
            }

            pageCount++;
        }

        Assert.AreEqual(ItemCount, i);
        Assert.AreEqual(1, pageCount);
    }

    [Test]
    public void CanSetPageSizeHint()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);
        var pages = models.AsPages(pageSizeHint: 10);
        foreach (var _ in pages)
        {
            // page size hint is ignored in this mock
        }

        Assert.AreEqual(10, client.RequestedPageSize);
    }

    [Test]
    public void CanGetRawResponses()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

        int pageCount = 0;
        int itemCount = 0;
        foreach (ResultPage<MockJsonModel> page in models.AsPages())
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(itemCount, model.IntValue);
                Assert.AreEqual(itemCount.ToString(), model.StringValue);

                itemCount++;
            }

            PipelineResponse collectionResponse = models.GetRawResponse();
            PipelineResponse pageResponse = page.GetRawResponse();

            Assert.AreEqual(pageResponse, collectionResponse);
            Assert.AreEqual(MockPageContents[pageCount], pageResponse.Content.ToString());
            Assert.AreEqual(MockPageContents[pageCount], collectionResponse.Content.ToString());

            pageCount++;
        }

        Assert.AreEqual(ItemCount, itemCount);
        Assert.AreEqual(PageCount, pageCount);
    }

    [Test]
    public async Task CanEnumerateValuesAsync()
    {
        MockPageableClient client = new();
        AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

        int i = 0;
        await foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(ItemCount, i);
    }

    [Test]
    public async Task CanEnumeratePagesAsync()
    {
        MockPageableClient client = new();
        AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

        int pageCount = 0;
        int itemCount = 0;
        await foreach (ResultPage<MockJsonModel> page in models.AsPages())
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(itemCount, model.IntValue);
                Assert.AreEqual(itemCount.ToString(), model.StringValue);

                itemCount++;
            }

            pageCount++;
        }

        Assert.AreEqual(ItemCount, itemCount);
        Assert.AreEqual(PageCount, pageCount);
    }

    [Test]
    public async Task CanStartPageEnumerationMidwayThroughAsync()
    {
        MockPageableClient client = new();
        AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

        int pageCount = 0;
        int i = 6;

        // Request just the last page by starting at the last seen value
        // on the prior page -- i.e. item 5.
        await foreach (ResultPage<MockJsonModel> page in models.AsPages(continuationToken: "5"))
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(i, model.IntValue);
                Assert.AreEqual(i.ToString(), model.StringValue);

                i++;
            }

            pageCount++;
        }

        Assert.AreEqual(ItemCount, i);
        Assert.AreEqual(1, pageCount);
    }

    [Test]
    public async Task CanSetPageSizeHintAsync()
    {
        MockPageableClient client = new();
        AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);
        var pages = models.AsPages(pageSizeHint: 10);
        await foreach (var _ in pages)
        {
            // page size hint is ignored in this mock
        }

        Assert.AreEqual(10, client.RequestedPageSize);
    }

    [Test]
    public async Task CanGetRawResponsesAsync()
    {
        MockPageableClient client = new();
        AsyncPageableCollection<MockJsonModel> models = client.GetModelsAsync(MockPageContents);

        int pageCount = 0;
        int itemCount = 0;
        await foreach (ResultPage<MockJsonModel> page in models.AsPages())
        {
            foreach (MockJsonModel model in page)
            {
                Assert.AreEqual(itemCount, model.IntValue);
                Assert.AreEqual(itemCount.ToString(), model.StringValue);

                itemCount++;
            }

            PipelineResponse collectionResponse = models.GetRawResponse();
            PipelineResponse pageResponse = page.GetRawResponse();

            Assert.AreEqual(pageResponse, collectionResponse);
            Assert.AreEqual(MockPageContents[pageCount], pageResponse.Content.ToString());
            Assert.AreEqual(MockPageContents[pageCount], collectionResponse.Content.ToString());

            pageCount++;
        }

        Assert.AreEqual(ItemCount, itemCount);
        Assert.AreEqual(PageCount, pageCount);
    }
}
