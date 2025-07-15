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
            Assert.IsNotNull(methodsOfFirstClient);
            Assert.AreEqual(2, methodsOfFirstClient.Where(method => method.Name.EndsWith("Async")).Count());
            Assert.IsNotNull(typeof(FirstClient).GetMethods().Where(m => m.Name == "OneAsync").FirstOrDefault());
            //check existence of method to get the operation group client
            Assert.AreNotEqual(null, typeof(FirstClient).GetMethod("GetGroup3Client"));
            Assert.AreNotEqual(null, typeof(FirstClient).GetMethod("GetGroup4Client"));
            /*check methods in operation group3 client. */
            var methodsOfGroup3 = typeof(Group3).GetMethods();
            Assert.IsNotNull(methodsOfGroup3);
            Assert.AreEqual(4, methodsOfGroup3.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.IsNotNull(typeof(Group3).GetMethods().Where(m => m.Name == "TwoAsync").FirstOrDefault());
            Assert.IsNotNull(typeof(Group3).GetMethods().Where(m => m.Name == "ThreeAsync").FirstOrDefault());
            /*check methods in operation group4 client. */
            var methodsOfGroup4 = typeof(Group4).GetMethods();
            Assert.IsNotNull(methodsOfGroup4);
            Assert.AreEqual(2, methodsOfGroup4.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.IsNotNull(typeof(Group4).GetMethods().Where(m => m.Name == "FourAsync").FirstOrDefault());

            /*check methods in SecondClient. */
            var methodsOfSecondClient = typeof(SubNamespaceSecondClient).GetMethods();
            Assert.IsNotNull(methodsOfSecondClient);
            Assert.AreEqual(2, methodsOfSecondClient.Where(method => method.Name.EndsWith("Async")).Count());
            Assert.IsNotNull(typeof(SubNamespaceSecondClient).GetMethods().Where(m => m.Name == "FiveAsync").FirstOrDefault());
            //check existence of method to get the operation group client
            Assert.AreNotEqual(null, typeof(SubNamespaceSecondClient).GetMethod("GetGroup5Client"));
            /*check methods in operation group5 client. */
            var methodsOfGroup5 = typeof(Group5).GetMethods();
            Assert.IsNotNull(methodsOfGroup5);
            Assert.AreEqual(2, methodsOfGroup5.Where(method => method.Name.EndsWith("Async")).ToArray().Length);
            Assert.IsNotNull(typeof(Group5).GetMethods().Where(m => m.Name == "SixAsync").FirstOrDefault());
        }

        [SpectorTest]
        public Task One() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).OneAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Two() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup3Client().TwoAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Three() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup3Client().ThreeAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Four() => Test(async (host) =>
        {
            var response = await new FirstClient(host, ClientType.ClientOperationGroup, null).GetGroup4Client().FourAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Five() => Test(async (host) =>
        {
            var response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup, null).FiveAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Six() => Test(async (host) =>
        {
            var response = await new SubNamespaceSecondClient(host, ClientType.ClientOperationGroup, null).GetGroup5Client().SixAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
