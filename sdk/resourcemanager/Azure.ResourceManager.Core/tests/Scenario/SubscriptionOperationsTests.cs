// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class SubscriptionOperationsTests : ResourceManagerTestBase
    {
        public SubscriptionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSubscriptionOperation()
        {
            var sub = await Client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            Assert.AreEqual(sub.Id.SubscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase(null)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgNullException(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestCase("te%st")]        
        [TestCase("te$st")]
        [TestCase("te#st")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgException(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                ResourceGroup rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (RequestFailedException e) when (e.Status == 400)
            {
            }
        }

        [TestCase("")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsEmptyString(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                ResourceGroup rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestCase(91)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsOutOfRangeArgException(int length)
        {
            var resourceGroupName = GetLongString(length);
            var subOps = Client.DefaultSubscription;
            try
            {
                var rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (RequestFailedException e) when (e.Status == 400)
            {
            }
        }

        [TestCase("test ")]
        [TestCase("te.st")]
        [TestCase("te")]
        [TestCase("t")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsValid(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
            }
        }

        [TestCase(89)]
        [TestCase(90)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsLong(int length)
        {
            var resourceGroupName = GetLongString(length);
            var subOps = Client.DefaultSubscription;
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected 404 from service");
            }
            catch(RequestFailedException e) when (e.Status == 404)
            {
            }
        }

        private string GetLongString(int length)
        {
            StringBuilder builder = new StringBuilder();
            for(int i=0; i<length; i++)
            {
                builder.Append('a');
            }
            return builder.ToString();
        }
    }
}
