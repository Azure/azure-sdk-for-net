// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PageResponseEnumeratorTests
    {
        [Test]
        public void EnumerateSyncPages()
        {
            var enumerable = PageResponseEnumerator.CreateEnumerable(s =>
                s == null ?
                    Page<int>.FromValues(new[]{1, 2, 3}, "next", new MockResponse(200)):
                    Page<int>.FromValues(new[]{4, 5, 6}, null, new MockResponse(200)));

            Assert.AreEqual(new[]{1,2,3,4,5,6}, enumerable.ToArray());

            int pageCount = 0;
            foreach (var page in enumerable.AsPages())
            {
                Assert.AreEqual(3, page.Values.Count);
                pageCount++;
            }
            Assert.AreEqual(2, pageCount);
        }

        [Test]
        public async Task EnumerateAsyncPages()
        {
            var enumerable = PageResponseEnumerator.CreateAsyncEnumerable(async s =>
            {
                await Task.CompletedTask;
                return s == null ? Page<int>.FromValues(new[] {1, 2, 3}, "next", new MockResponse(200)) : Page<int>.FromValues(new[] {4, 5, 6}, null, new MockResponse(200));
            });

            Assert.AreEqual(new[]{1,2,3,4,5,6}, await enumerable.ToEnumerableAsync());

            int pageCount = 0;
            await foreach (var page in enumerable.AsPages())
            {
                Assert.AreEqual(3, page.Values.Count);
                pageCount++;
            }
            Assert.AreEqual(2, pageCount);
        }
    }
}