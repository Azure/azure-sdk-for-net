// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.Diagnostics
{
    public class PageableTests
    {
        [Test]
        public void CanCreatePageableFromPages()
        {
            var pageable = Pageable<byte>.FromPages(new[]
            {
                Page<byte>.FromValues(new byte[] {1, 2}, null, null),
                Page<byte>.FromValues(new byte[] {3, 4}, null, null)
            });

            Assert.That(pageable.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3, 4 }));
        }

        [Test]
        public async Task CanCreateAsyncPageableFromPages()
        {
            var pageable = AsyncPageable<byte>.FromPages(new[]
            {
                Page<byte>.FromValues(new byte[] {1, 2}, null, null),
                Page<byte>.FromValues(new byte[] {3, 4}, null, null)
            });

            Assert.That(await pageable.ToEnumerableAsync(), Is.EqualTo(new byte[] { 1, 2, 3, 4 }));
        }

        [Test]
        public void CanCreatePageableFromPage_MultiplePage()
        {
            var pageable = Pageable<byte>.FromPages(new[]
            {
                Page<byte>.FromValues(new byte[] {1, 2}, "X", null),
                Page<byte>.FromValues(new byte[] {3, 4}, null, null)
            });

            var pages = pageable.AsPages(continuationToken: null);
            var page = pages.First();

            Assert.That(page.Values, Is.EqualTo(new byte[] { 1, 2 }));
            Assert.That(page.ContinuationToken, Is.EqualTo("X"));

            pages = pageable.AsPages(continuationToken: "X");
            page = pages.First();

            Assert.That(page.Values, Is.EqualTo(new byte[] { 3, 4 }));
            Assert.That(page.ContinuationToken, Is.Null);
        }

        [Test]
        public async Task CanCreateAsyncPageableFromPage_MultiplePage()
        {
            var pageable = AsyncPageable<byte>.FromPages(new[]
            {
                Page<byte>.FromValues(new byte[] {1, 2}, "X", null),
                Page<byte>.FromValues(new byte[] {3, 4}, null, null)
            });

            var pages = pageable.AsPages(continuationToken: null);
            var page = await pages.FirstAsync();

            Assert.That(page.Values, Is.EqualTo(new byte[] { 1, 2 }));
            Assert.That(page.ContinuationToken, Is.EqualTo("X"));

            pages = pageable.AsPages(continuationToken: "X");
            page = await pages.FirstAsync();

            Assert.That(page.Values, Is.EqualTo(new byte[] { 3, 4 }));
            Assert.That(page.ContinuationToken, Is.Null);
        }
    }
}
