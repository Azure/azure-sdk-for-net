// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ClientStructureClientOperationGroup;
using System.Linq;
using System.Threading.Tasks;
using ClientStructureClientOperationGroup::Client.Structure.AnotherClientOperationGroup;
using ClientStructureClientOperationGroup::Client.Structure.ClientOperationGroup;
using NUnit.Framework;
using ClientType = ClientStructureClientOperationGroup::Client.Structure.Service.ClientType;

namespace TestProjects.Spector.Tests.Http.Client.Structure.ClientOperationGroup
{
    public class ClientOperationGroupTests : SpectorTestBase
    {
        [Test]
        public void VerifyMethods()
        {
            /*check methods in FirstClient. */
            var methodsOfFirstClient = typeof(FirstClient).GetMethods();
            Assert.That(methodsOfFirstClient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfFirstClient.Where(method => method.Name.EndsWith("Async")).Count(), Is.EqualTo(2));
                Assert.That(typeof(FirstClient).GetMethods().Where(m => m.Name == "OneAsync").FirstOrDefault(), Is.Not.Null);
                //check existence of method to get the operation group client
                Assert.That(typeof(FirstClient).GetMethod("GetGroup3Client"), Is.Not.EqualTo(null));
                Assert.That(typeof(FirstClient).GetMethod("GetGroup4Client"), Is.Not.EqualTo(null));
            });
            /*check methods in operation group3 client. */
            var methodsOfGroup3 = typeof(Group3).GetMethods();
            Assert.That(methodsOfGroup3, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfGroup3.Where(method => method.Name.EndsWith("Async")).ToArray(), Has.Length.EqualTo(4));
                Assert.That(typeof(Group3).GetMethods().Where(m => m.Name == "TwoAsync").FirstOrDefault(), Is.Not.Null);
                Assert.That(typeof(Group3).GetMethods().Where(m => m.Name == "ThreeAsync").FirstOrDefault(), Is.Not.Null);
            });
            /*check methods in operation group4 client. */
            var methodsOfGroup4 = typeof(Group4).GetMethods();
            Assert.That(methodsOfGroup4, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfGroup4.Where(method => method.Name.EndsWith("Async")).ToArray(), Has.Length.EqualTo(2));
                Assert.That(typeof(Group4).GetMethods().Where(m => m.Name == "FourAsync").FirstOrDefault(), Is.Not.Null);
            });

            /*check methods in SecondClient. */
            var methodsOfSecondClient = typeof(SubNamespaceSecondClient).GetMethods();
            Assert.That(methodsOfSecondClient, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfSecondClient.Where(method => method.Name.EndsWith("Async")).Count(), Is.EqualTo(2));
                Assert.That(typeof(SubNamespaceSecondClient).GetMethods().Where(m => m.Name == "FiveAsync").FirstOrDefault(), Is.Not.Null);
                //check existence of method to get the operation group client
                Assert.That(typeof(SubNamespaceSecondClient).GetMethod("GetGroup5Client"), Is.Not.EqualTo(null));
            });
            /*check methods in operation group5 client. */
            var methodsOfGroup5 = typeof(Group5).GetMethods();
            Assert.That(methodsOfGroup5, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(methodsOfGroup5.Where(method => method.Name.EndsWith("Async")).ToArray(), Has.Length.EqualTo(2));
                Assert.That(typeof(Group5).GetMethods().Where(m => m.Name == "SixAsync").FirstOrDefault(), Is.Not.Null);
            });
        }

        [SpectorTest]
        public Task One() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).OneAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Two() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup3Client().TwoAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Three() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup3Client().ThreeAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Four() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup4Client().FourAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Five() => Test(async (host) =>
        {
            var response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup, null).FiveAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Six() => Test(async (host) =>
        {
            var response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup, null).GetGroup5Client().SixAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
