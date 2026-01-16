// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ClientStructureRenamedOperation;
using System.Linq;
using System.Threading.Tasks;
using ClientStructureRenamedOperation::Client.Structure.RenamedOperation;
using ClientStructureRenamedOperation::Client.Structure.Service;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Structure.RenamedOperation
{
    public class RenamedOperationTests : SpectorTestBase
    {
        [Test]
        public void VerifyMethods()
        {
            /*check methods in RenamedOperationClient. */
            var methodsRenamedOperation = typeof(RenamedOperationClient).GetMethods();
            Assert.That(methodsRenamedOperation, Is.Not.Null);
            Assert.That(methodsRenamedOperation.Where(method => method.Name.EndsWith("Async")).Count(), Is.EqualTo(6));
            Assert.That(typeof(RenamedOperationClient).GetMethods().Where(m => m.Name == "RenamedOneAsync").FirstOrDefault(), Is.Not.Null);
            Assert.That(typeof(RenamedOperationClient).GetMethods().Where(m => m.Name == "RenamedThreeAsync").FirstOrDefault(), Is.Not.Null);
            Assert.That(typeof(RenamedOperationClient).GetMethods().Where(m => m.Name == "RenamedFiveAsync").FirstOrDefault(), Is.Not.Null);
            Assert.That(typeof(RenamedOperationClient).GetMethods().Where(m => m.Name == "GetGroupClient").FirstOrDefault(), Is.Not.Null);
        }

        [SpectorTest]
        public Task RenamedOne() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).RenamedOneAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedThree() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).RenamedThreeAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedFive() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).RenamedFiveAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        // Check OperationGroup
        [SpectorTest]
        public Task RenamedTwo() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).GetGroupClient().RenamedTwoAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedFour() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).GetGroupClient().RenamedFourAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RenamedSix() => Test(async (host) =>
        {
            var response = await new RenamedOperationClient(host, ClientType.RenamedOperation, null).GetGroupClient().RenamedSixAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
