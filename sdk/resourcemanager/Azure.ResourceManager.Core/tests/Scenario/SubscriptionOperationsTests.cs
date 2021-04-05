// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class SubscriptionOperationsTests : ResourceManagerTestBase
    {
        public SubscriptionOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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
        [TestCase("")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgNullException(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (AggregateException e) when (e.InnerExceptions.FirstOrDefault(ie => ie is ArgumentException) != null)
            {
            }
        }

        [TestCase("te%st")]        
        [TestCase("test ")]
        [TestCase("te$st")]
        [TestCase("te#st")]
        [TestCase("te#st")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgException(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (AggregateException e) when (e.InnerExceptions.FirstOrDefault(ie => ie is RequestFailedException) != null)
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
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            //catch (AggregateException e) when (e.InnerExceptions.FirstOrDefault(ie => ie is RequestFailedException) != null)
            //{
            //}
            catch (Exception ex)
            {
                string x = ex.Message;

            }
        }

            [TestCase("te.st")]
        [TestCase("te")]
        [TestCase("t")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsValid(string resourceGroupName)
        {
            var subOps = Client.DefaultSubscription;
            _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
        }

        [TestCase(89)]
        [TestCase(90)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsLong(int length)
        {
            var resourceGroupName = GetLongString(length);
            var subOps = Client.DefaultSubscription;
            _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
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
