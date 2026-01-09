// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Service.MultiService.Combined;
using static Service.MultiService.Combined.CombinedClientOptions;

namespace TestProjects.Spector.Tests.Http.Service.MultiService
{
    public class MultiServiceTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ServiceAOperation() => Test(async (host) =>
        {
            var response = await new CombinedClient(host).GetFooClient().TestAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [SpectorTest]
        public Task ServiceBOperation() => Test(async (host) =>
        {
            var response = await new CombinedClient(host).GetBarClient().TestAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task ServiceAOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = ServiceAVersion.Av1;
            var clientOptions = new CombinedClientOptions(serviceAVersion: serviceVersion);
            var client = new CombinedClient(host, clientOptions).GetFooClient();

            Assert.IsNotNull(client);
        });

        [Test]
        public Task ServiceBOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = ServiceBVersion.Bv1;
            var clientOptions = new CombinedClientOptions(serviceBVersion: serviceVersion);
            var client = new CombinedClient(host, clientOptions).GetBarClient();

            Assert.IsNotNull(client);
        });
    }
}
