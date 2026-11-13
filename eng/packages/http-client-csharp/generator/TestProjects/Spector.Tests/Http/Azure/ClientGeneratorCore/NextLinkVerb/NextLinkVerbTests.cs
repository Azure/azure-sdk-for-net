// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.NextLinkVerb;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.NextLinkVerb
{
    public class NextLinkVerbTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_NextLinkVerb_ListItems() => Test(async (host) =>
        {
            var items = new NextLinkVerbClient(host, null).GetItemsAsync();
            int count = 0;
            await foreach (var item in items)
            {
                count++;
                Assert.IsNotNull(item.Id);
            }
            Assert.AreEqual(2, count);
        });
    }
}
