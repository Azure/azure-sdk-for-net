// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Utilities;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Utilities
{
    public class PageableExtensionsTests
    {
        [Test]
        public void ToBufferedListBuffersAllPages()
        {
            MockResponse firstResponse = new MockResponse(200);
            Page<int>[] pages =
            {
                Page<int>.FromValues(new[] { 1, 2 }, "next", firstResponse),
                Page<int>.FromValues(new[] { 3 }, null, new MockResponse(200)),
            };

            Response<IReadOnlyList<int>> response = Pageable<int>.FromPages(pages).ToBufferedList();

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, response.Value);
            Assert.AreSame(firstResponse, response.GetRawResponse());
        }

        [Test]
        public async Task ToBufferedListAsyncBuffersAllPages()
        {
            MockResponse firstResponse = new MockResponse(200);
            Page<int>[] pages =
            {
                Page<int>.FromValues(new[] { 1, 2 }, "next", firstResponse),
                Page<int>.FromValues(new[] { 3 }, null, new MockResponse(200)),
            };

            Response<IReadOnlyList<int>> response = await AsyncPageable<int>.FromPages(pages).ToBufferedListAsync();

            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, response.Value);
            Assert.AreSame(firstResponse, response.GetRawResponse());
        }
    }
}
