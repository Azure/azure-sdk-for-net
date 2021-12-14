// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.Management
{
    [Parallelizable]
    [PlaybackOnly("These are fake clients that won't run live")]
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
            var operation = (await sub.GetLroAsync()).Value;
            var result = operation.Method();

            Assert.AreEqual("TestResourceProxy", operation.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetLroAsync()).Value;
            var result = response.Method();

            Assert.AreEqual("TestResourceProxy", response.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetContainer()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();

            Assert.AreEqual("TestResourceCollectionProxy", testResources.GetType().Name);
            Assert.AreEqual("success", testResources.Method());
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetOperations()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResource = client.GetTestResource();

            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public async Task ValidateInstrumentPageable()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();
            await foreach (var item in testResources.GetAllAsync())
            {
                Assert.AreEqual("TestResourceProxy", item.GetType().Name);
                Assert.AreEqual("success", item.Method());
            }
        }

        [Test]
        public async Task ValidateInstrumentEnumerable()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();
            await foreach (var item in testResources)
            {
                Assert.AreEqual("TestResourceProxy", item.GetType().Name);
                Assert.AreEqual("success", item.Method());
            }
        }

        [Test]
        public async Task ValidateWaitForCompletion()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.GetLroAsync();
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public void ValidateExceptionResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            Assert.ThrowsAsync(typeof(ArgumentException), async () => await rgOp.GetResponseExceptionAsync());
        }

        [Test]
        public void ValidateExceptionOperation()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            Assert.ThrowsAsync(typeof(ArgumentException), async () => await rgOp.GetLroExceptionAsync());
        }

        [Test]
        public async Task ValidateExceptionOperationWaitForCompletion()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.GetLroAsync(true);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => await testResourceOp.WaitForCompletionAsync());
        }

        [Test]
        public async Task ValidateLroWrapper()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            TestResource testResource = await rgOp.LroWrapperAsync();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public async Task ValidateStartLroWrapper()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.StartLroWrapperAsync();
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public async Task ValidateSkipWait()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            Stopwatch timer = Stopwatch.StartNew();
            TestResource testResource = await rgOp.LroWrapperAsync();
            timer.Stop();
            //method waits for 10 seconds so timer should easily be less than half of that if we skip
            Assert.IsTrue(timer.ElapsedMilliseconds < 5000, $"WaitForCompletion took {timer.ElapsedMilliseconds}ms");
        }

        [Test]
        public async Task ValidateStartSkipWait()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.StartLroWrapperAsync();
            Stopwatch timer = Stopwatch.StartNew();
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            timer.Stop();
            //method waits for 10 seconds so timer should easily be less than half of that if we skip
            Assert.IsTrue(timer.ElapsedMilliseconds < 5000, $"WaitForCompletion took {timer.ElapsedMilliseconds}ms");
        }
    }
}
