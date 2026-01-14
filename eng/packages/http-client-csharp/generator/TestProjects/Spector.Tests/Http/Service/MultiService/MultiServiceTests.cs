// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Service.MultiService.ServiceA;
using Service.MultiService.ServiceB;


namespace TestProjects.Spector.Tests.Http.Service.MultiService
{
    public class MultiServiceTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ServiceAOperation() => Test(async (host) =>
        {
            var response = await new FooClient(host).TestAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [SpectorTest]
        public Task ServiceBOperation() => Test(async (host) =>
        {
            var response = await new BarClient(host).TestAsync();
            Assert.AreEqual(204, response.GetRawResponse().Status);
        });

        [Test]
        public Task ServiceAOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = FooClientOptions.ServiceVersion.Av1;
            var clientOptions = new FooClientOptions(serviceVersion);
            var client = new FooClient(host, clientOptions);

            Assert.IsNotNull(client);
        });

        [Test]
        public Task ServiceBOperation_SetDiffServiceVersion() => Test(async (host) =>
        {
            var serviceVersion = BarClientOptions.ServiceVersion.Bv1;
            var clientOptions = new BarClientOptions(serviceVersion);
            var client = new BarClient(host, clientOptions);

            Assert.IsNotNull(client);
        });
    }
}
