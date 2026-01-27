// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Service.MultiService.Combined;


namespace TestProjects.Spector.Tests.Http.Service.MultiService
{
    public class MultiServiceTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ServiceAOperation() => Test(async (host) =>
        {
            var response = await new CombinedClient(host, new CombinedClientOptions()).GetFooClient().TestAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ServiceBOperation() => Test(async (host) =>
        {
            var response = await new CombinedClient(host, new CombinedClientOptions()).GetBarClient().TestAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}