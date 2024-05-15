// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class PageableCollectionTests //: SyncAsyncTestBase
{
    //public PageableCollectionTests(bool isAsync) : base(isAsync)
    //{
    //}

    [Test]
    public void CanEnumerateValues()
    {
        string[] mockPageContents = { """
            [
                { "intValue" : 0, "stringValue" : "0" },
                { "intValue" : 1, "stringValue" : "1" }
            ]
            """, """
            [
                { "intValue" : 2, "stringValue" : "2" },
                { "intValue" : 3, "stringValue" : "3" }
            ]
            """,
        };

        MockPageableClient client = new();
        PageableCollection<MockJsonModel> models = client.GetModels(mockPageContents);

        int i = 0;
        foreach (MockJsonModel model in models)
        {
            Assert.AreEqual(i, model.IntValue);
            Assert.AreEqual(i.ToString(), model.StringValue);

            i++;
        }

        Assert.AreEqual(4, i);
    }

    // Enumerate values - sync and async
    // Get as pages
    // Modify page size
    // Get from middle page
    // Enumerate forward and backward
    // Get first and last pages per TypeSpec
}
