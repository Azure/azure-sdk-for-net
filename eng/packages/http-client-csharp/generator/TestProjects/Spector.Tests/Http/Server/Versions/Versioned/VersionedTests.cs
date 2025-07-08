// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Server.Versions.Versioned;

namespace TestProjects.Spector.Tests.Http.Server.Versions.Versioned
{
    public class VersionedTests : SpectorTestBase
    {
        [SpectorTest]
        public Task WithoutApiVersion() => Test(async (host) =>
        {
            var response = await new VersionedClient(host, null).WithoutApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task WithQueryApiVersion() => Test(async (host) =>
        {
            var response = await new VersionedClient(host, null).WithQueryApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task WithPathApiVersion() => Test(async (host) =>
        {
            var response = await new VersionedClient(host, null).WithPathApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task WithQueryOldApiVersion() => Test(async (host) =>
        {
            var options = new VersionedClientOptions(VersionedClientOptions.ServiceVersion.V2021_01_01_Preview);
            var response = await new VersionedClient(host, options).WithQueryOldApiVersionAsync();
            Assert.AreEqual(200, response.Status);
        });
    }
}
