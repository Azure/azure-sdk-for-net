// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ClientStructureTwoOperationGroup;
using System.ClientModel;
using System.Linq;
using System.Threading.Tasks;
using ClientStructureTwoOperationGroup::Client.Structure.TwoOperationGroup;
using ClientStructureTwoOperationGroup::Client.Structure.Service;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Structure.TwoOperationGroup
{
    public class TwoOperationGroupTests : SpectorTestBase
    {
        [Test]
        public void Client_Structure_Two_Operation_Group_methods()
        {
            /* check the methods in service client. */
            var methodsOfServiceClient = typeof(TwoOperationGroupClient).GetMethods();
            Assert.That(methodsOfServiceClient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfServiceClient.Where(method => method.Name.EndsWith("Async")).ToArray().Length, Is.EqualTo(0));
                //check existence of method to get the operation group client
                Assert.That(typeof(TwoOperationGroupClient).GetMethod("GetGroup1Client"), Is.Not.EqualTo(null));
                Assert.That(typeof(TwoOperationGroupClient).GetMethod("GetGroup2Client"), Is.Not.EqualTo(null));
            });

            /*check methods in operation group1 client. */
            var methodsOfGroup1 = typeof(Group1).GetMethods();
            Assert.That(methodsOfGroup1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfGroup1.Where(method => method.Name.EndsWith("Async")).ToArray(), Has.Length.EqualTo(6));
                Assert.That(typeof(Group1).GetMethods().Where(m => m.Name == "OneAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(Group1).GetMethods().Where(m => m.Name == "ThreeAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(Group1).GetMethods().Where(m => m.Name == "FourAsync").FirstOrDefault(), Is.Not.Null);
            });

            /*check methods in operation group2 client. */
            var methodsOfGroup2 = typeof(Group2).GetMethods();
            Assert.That(methodsOfGroup2, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfGroup2.Where(method => method.Name.EndsWith("Async")).ToArray(), Has.Length.EqualTo(6));
                Assert.That(typeof(Group2).GetMethods().Where(m => m.Name == "TwoAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(Group2).GetMethods().Where(m => m.Name == "FiveAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(Group2).GetMethods().Where(m => m.Name == "SixAsync").FirstOrDefault(), Is.Not.Null);
            });
        }

        [SpectorTest]
        public Task One() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup1Client().OneAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Three() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup1Client().ThreeAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Four() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup1Client().FourAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Two() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup2Client().TwoAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Five() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup2Client().FiveAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Six() => Test(async (host) =>
        {
            var result = await new TwoOperationGroupClient(host, ClientType.TwoOperationGroup).GetGroup2Client().SixAsync();
            Assert.That(result.Status, Is.EqualTo(204));
        });
    }
}
