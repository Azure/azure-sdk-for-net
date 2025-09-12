// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Server.Versions.NotVersioned;

namespace TestProjects.Spector.Tests.Http.Server.Versions.NotVersioned
{
    public class NotVersionedTests : SpectorTestBase
    {
        [SpectorTest]
        public Task WithoutApiVersion() => Test(async (host) =>
        {
            var response = await new NotVersionedClient(host, null).WithoutApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task WithQueryApiVersion() => Test(async (host) =>
        {
            var response = await new NotVersionedClient(host, null).WithQueryApiVersionAsync("v1.0");
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task WithPathApiVersion() => Test(async (host) =>
        {
            var response = await new NotVersionedClient(host, null).WithPathApiVersionAsync("v1.0");
            Assert.AreEqual(200, response.Status);
        });
    }
}
