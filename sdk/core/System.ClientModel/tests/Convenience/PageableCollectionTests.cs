// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class PageableCollectionTests //: SyncAsyncTestBase
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

    // Page enumeration stops on an empty page, so we add one to the count
    private static readonly int PageCount = MockPageContents.Length + 1;
    private static readonly int ItemCount = 9;

    //public PageableCollectionTests(bool isAsync) : base(isAsync)
    //{
    //}

    // TODO:
    // Enumerate values - sync and async
    // Get as pages
    // Modify page size
    // Get from middle page
    // Enumerate forward and backward
    // Get first and last pages per TypeSpec

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
        foreach (ClientPage<MockJsonModel> page in models.AsPages())
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
    public void CanStartPageEnumerationMidway()
    {
        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(MockPageContents);

        int pageCount = 0;
        int i = 6;
        foreach (ClientPage<MockJsonModel> page in models.AsPages(continuationToken: "5"))
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
        // Two pages - the last one with items 6-8 in it, and the final empty one.
        Assert.AreEqual(2, pageCount);
    }
}
