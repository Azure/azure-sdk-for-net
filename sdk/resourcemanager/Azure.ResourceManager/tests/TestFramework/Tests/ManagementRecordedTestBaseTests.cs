// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests.Management
{
    [Parallelizable]
    [PlaybackOnly("These are fake clients that won't run live")]
    internal class ManagementRecordedTestBaseTests : ManagementRecordedTestBase<MockTestEnvironment>
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
            var operation = (await sub.GetLroAsync(WaitUntil.Completed)).Value;
            var result = operation.Method();

            Assert.AreEqual("TestResourceProxy", operation.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetLroAsync(WaitUntil.Completed)).Value;
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
            var testResourceOp = await rgOp.GetLroAsync(WaitUntil.Completed);
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
            Assert.ThrowsAsync(typeof(ArgumentException), async () => await rgOp.GetLroExceptionAsync(WaitUntil.Completed));
        }

        [Test]
        public async Task ValidateExceptionOperationWaitForCompletion()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.GetLroAsync(WaitUntil.Started, true);
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await testResourceOp.WaitForCompletionAsync());
        }

        [Test]
        public async Task ValidateStartLroWrapper()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.StartLroWrapperAsync(WaitUntil.Completed);
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.AreEqual("success", testResource.Method());
        }

        [Test]
        public async Task ValidateStartSkipWait()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.StartLroWrapperAsync(WaitUntil.Completed);
            Stopwatch timer = Stopwatch.StartNew();
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            timer.Stop();
            //method waits for 10 seconds so timer should easily be less than half of that if we skip
            Assert.IsTrue(timer.ElapsedMilliseconds < 5000, $"WaitForCompletion took {timer.ElapsedMilliseconds}ms");
        }

        [Test]
        public void ValidateForwardClientCallTrue()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            Assert.DoesNotThrowAsync(async () => testResource = await testResource.GetForwardsCallTrueAsync());
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
        }

        [Test]
        public void ValidateForwardClientCallFalse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => testResource = await testResource.GetForwardsCallFalseAsync());
            StringAssert.Contains("Expected some diagnostic scopes to be created other than the Azure.Core scopes", ex.Message);
        }

        [Test]
        public void ValidateForwardClientCallDefault()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => testResource = await testResource.GetForwardsCallDefaultAsync());
            StringAssert.Contains("Expected some diagnostic scopes to be created other than the Azure.Core scopes", ex.Message);
        }

        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Live)]
        public async Task ValidateWaitOverride(RecordedTestMode mode)
        {
            // keep the curent test mode and restore it back when finished, otherwise it will invoke unnecessary clean-up
            var currentMode = Mode;

            Mode = mode;
            try
            {
                ManagementTestClient testClient = InstrumentClient(new ManagementTestClient());
                TestResource testResource = testClient.GetTestResource();
                Stopwatch sw = Stopwatch.StartNew();
                testResource = (await testResource.GetLroAsync(WaitUntil.Completed)).Value;
                sw.Stop();
                Assert.AreEqual("TestResourceProxy", testResource.GetType().Name);
                if (mode == RecordedTestMode.Playback)
                {
                    Assert.Less(sw.ElapsedMilliseconds, 1000);
                }
                else
                {
                    Assert.That(sw.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(1000).Within(25));
                }
            }
            finally
            {
                Mode = currentMode;
            }
        }
    }
}
