// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.Management
{
    [Parallelizable]
    internal class ManagementRecordedTestBaseTests : ManagementRecordedTestBase<TestEnvironmentTests.MockTestEnvironment>
    {
        public ManagementRecordedTestBaseTests(bool isAsync)
            : base(isAsync)
        {
            TestDiagnostics = true;
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentTopLevelClient()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var result = client.Method();

            Assert.AreEqual("ManagementTestClientProxy", client.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentDefaultSubscription()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var result = sub.Method();

            Assert.AreEqual("TestResourceProxy", sub.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmOperation()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var operation = (await sub.GetArmOperationAsync()).Value;
            var result = operation.Method();

            Assert.AreEqual("TestResourceProxy", operation.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetArmOperationAsync()).Value;
            var result = response.Method();

            Assert.AreEqual("TestResourceProxy", response.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentPhArmOperation()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var operation = (await sub.GetPhArmOperationAsync()).Value;
            var result = operation.Method();

            Assert.AreEqual("TestResourceProxy", operation.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentPhArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetPhArmOperationAsync()).Value;
            var result = response.Method();

            Assert.AreEqual("TestResourceProxy", response.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetContainer()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceContainer();

            Assert.AreEqual("TestResourceContainerProxy", testResources.GetType().Name);
            Assert.AreEqual("success", testResources.Method());
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetOperations()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResource = client.GetTestResourceOperations();

            Assert.AreEqual("TestResourceOperationsProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public async Task ValidateInstrumentPhPageable()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceContainer();
            await foreach (var item in testResources.ListAsync())
            {
                Assert.AreEqual("TestResourceProxy", item.GetType().Name);
                Assert.AreEqual("success", item.Method());
            }
        }

        [Test]
        public async Task ValidateWaitForCompletion()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResourceOperations rgOp = client.GetTestResourceOperations();
            var testResourceOp = await rgOp.GetArmOperationAsync();
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }
    }
}
