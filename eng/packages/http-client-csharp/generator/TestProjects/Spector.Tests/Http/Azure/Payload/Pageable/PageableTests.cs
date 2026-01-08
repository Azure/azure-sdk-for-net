// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.Payload.Pageable;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Payload.Pageable
{
    public class PageableTests : SpectorTestBase
    {
        [SpectorTest]
        [Ignore("https://github.com/microsoft/typespec/issues/9201")]
        public Task ListWithMaxPageSize() => Test(async (host) =>
        {
            var users = new PageableClient(host, null).GetAllAsync(maxpagesize: 3);
            string[] expectedUserName = ["user5", "user6", "user7", "user8"];
            int count = 0;
            await foreach (var user in users)
            {
                Assert.AreEqual(expectedUserName[count++], user.Name);
            }
            Assert.AreEqual(4, count);
        });
    }
}