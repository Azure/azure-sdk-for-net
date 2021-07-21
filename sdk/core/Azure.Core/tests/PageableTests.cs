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

            Assert.AreEqual(new byte[] { 1, 2, 3, 4 }, pageable.ToArray());
        }

        [Test]
        public async Task CanCreateAsyncPageableFromPages()
        {
            var pageable = AsyncPageable<byte>.FromPages(new[]
            {
                Page<byte>.FromValues(new byte[] {1, 2}, null, null),
                Page<byte>.FromValues(new byte[] {3, 4}, null, null)
            });

            Assert.AreEqual(new byte[] { 1, 2, 3, 4 }, await pageable.ToEnumerableAsync());
        }
    }
}