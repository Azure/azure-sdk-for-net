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
            Assert.That(methodsOfClientA, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfClientA.Where(method => method.Name.EndsWith("Async")).Count(), Is.EqualTo(6));
                Assert.That(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedOneAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedThreeAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(ClientAClient).GetMethods().Where(m => m.Name == "RenamedFiveAsync").FirstOrDefault(), Is.Not.Null);
            });

            /*cheeck methods in ClientBClient. */
            var methodsOfClientB = typeof(ClientBClient).GetMethods();
            Assert.That(methodsOfClientB, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfClientB.Where(method => method.Name.EndsWith("Async")).Count(), Is.EqualTo(6));
                Assert.That(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedTwoAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedFourAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(ClientBClient).GetMethods().Where(m => m.Name == "RenamedSixAsync").FirstOrDefault(), Is.Not.Null);
            });
        }

        [SpectorTest]
        public Task RenamedOne() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedOneAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedTwo() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedTwoAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedThree() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedThreeAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedFour() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedFourAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedFive() => Test(async (host) =>
        {
            var response = await new ClientAClient(host, ClientType.MultiClient, null).RenamedFiveAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedSix() => Test(async (host) =>
        {
            var response = await new ClientBClient(host, ClientType.MultiClient, null).RenamedSixAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
