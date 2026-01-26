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

        [Test]
        public Task ServiceAOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = CombinedClientOptions.ServiceAVersion.Vav1;
            var clientOptions = new CombinedClientOptions(serviceVersion);
            var client = new CombinedClient(host, clientOptions).GetFooClient();

            Assert.IsNotNull(client);
        });

        [Test]
        public Task ServiceBOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = CombinedClientOptions.ServiceBVersion.Vbv1;
            var clientOptions = new CombinedClientOptions(serviceBVersion: serviceVersion);
            var client = new CombinedClient(host, clientOptions).GetBarClient();

            Assert.IsNotNull(client);
        });
    }
}
