// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ClientStructureMultiClient;
using System.Linq;
using System.Threading.Tasks;
using ClientStructureMultiClient::Client.Structure.MultiClient;
using NUnit.Framework;
using ClientType = ClientStructureMultiClient::Client.Structure.Service.ClientType;

namespace TestProjects.Spector.Tests.Http.Client.Structure.MultiClient
{
    public class MultiClientTests : SpectorTestBase
    {
        [Test]
        public void VerifyMethods()
        {
            /*cheeck methods in ClientAClient. */
            var methodsOfClientA = typeof(ClientAClient).GetMethods();
            Assert.IsNotNull(methodsOfClientA);
            Assert.AreEqual(6, methodsOfClientA.Where(method => method.Name.EndsWith("Async")).Count());
            Assert.IsNotNull(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedOneAsync").FirstOrDefault());
            Assert.IsNotNull(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedThreeAsync").FirstOrDefault());
            Assert.IsNotNull(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedFiveAsync").FirstOrDefault());

            /*cheeck methods in ClientBClient. */
            var methodsOfClientB = typeof(ClientBClient).GetMethods();
            Assert.IsNotNull(methodsOfClientB);
            Assert.AreEqual(6, methodsOfClientB.Where(method => method.Name.EndsWith("Async")).Count());
            Assert.IsNotNull(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedTwoAsync").FirstOrDefault());
            Assert.IsNotNull(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedFourAsync").FirstOrDefault());
            Assert.IsNotNull(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedSixAsync").FirstOrDefault());
        }

        [SpectorTest]
        public Task RenamedOne() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedOneAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RenamedTwo() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedTwoAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RenamedThree() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedThreeAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RenamedFour() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedFourAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RenamedFive() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedFiveAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RenamedSix() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedSixAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
