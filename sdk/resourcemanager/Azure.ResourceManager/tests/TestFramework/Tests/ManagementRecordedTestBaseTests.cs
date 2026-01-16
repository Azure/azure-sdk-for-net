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

            Assert.That(client.GetType().Name, Is.EqualTo("ManagementTestClientProxy"));
            Assert.That(result, Is.EqualTo("success"));
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentDefaultSubscription()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var result = sub.Method();

            Assert.That(sub.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(result, Is.EqualTo("success"));
        }

        [Test]
        public async Task ValidateInstrumentArmOperation()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var operation = (await sub.GetLroAsync(WaitUntil.Completed)).Value;
            var result = operation.Method();

            Assert.That(operation.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(result, Is.EqualTo("success"));
        }

        [Test]
        public async Task ValidateInstrumentArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetLroAsync(WaitUntil.Completed)).Value;
            var result = response.Method();

            Assert.That(response.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(result, Is.EqualTo("success"));
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetContainer()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();

            Assert.That(testResources.GetType().Name, Is.EqualTo("TestResourceCollectionProxy"));
            Assert.That(testResources.Method(), Is.EqualTo("success"));
        }

        [Test]
        [SyncOnly]
        public void ValidateInstrumentGetOperations()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResource = client.GetTestResource();

            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(testResource.Method(), Is.EqualTo("success"));
        }

        [Test]
        public async Task ValidateInstrumentPageable()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();
            await foreach (var item in testResources.GetAllAsync())
            {
                Assert.That(item.GetType().Name, Is.EqualTo("TestResourceProxy"));
                Assert.That(item.Method(), Is.EqualTo("success"));
            }
        }

        [Test]
        public async Task ValidateInstrumentEnumerable()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var testResources = client.GetTestResourceCollection();
            await foreach (var item in testResources)
            {
                Assert.That(item.GetType().Name, Is.EqualTo("TestResourceProxy"));
                Assert.That(item.Method(), Is.EqualTo("success"));
            }
        }

        [Test]
        public async Task ValidateWaitForCompletion()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource rgOp = client.GetTestResource();
            var testResourceOp = await rgOp.GetLroAsync(WaitUntil.Completed);
            TestResource testResource = await testResourceOp.WaitForCompletionAsync();
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(testResource.Method(), Is.EqualTo("success"));
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
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.That(testResource.Method(), Is.EqualTo("success"));
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
            Assert.That(timer.ElapsedMilliseconds < 5000, Is.True, $"WaitForCompletion took {timer.ElapsedMilliseconds}ms");
        }

        [Test]
        public void ValidateForwardClientCallTrue()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            Assert.DoesNotThrowAsync(async () => testResource = await testResource.GetForwardsCallTrueAsync());
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
        }

        [Test]
        public void ValidateForwardClientCallFalse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => testResource = await testResource.GetForwardsCallFalseAsync());
            Assert.That(ex.Message, Does.Contain("Expected some diagnostic scopes to be created other than the Azure.Core scopes"));
        }

        [Test]
        public void ValidateForwardClientCallDefault()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            TestResource testResource = client.GetTestResource();
            Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => testResource = await testResource.GetForwardsCallDefaultAsync());
            Assert.That(ex.Message, Does.Contain("Expected some diagnostic scopes to be created other than the Azure.Core scopes"));
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
                Assert.That(testResource.GetType().Name, Is.EqualTo("TestResourceProxy"));
                if (mode == RecordedTestMode.Playback)
                {
                    Assert.That(sw.ElapsedMilliseconds, Is.LessThan(1000));
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
