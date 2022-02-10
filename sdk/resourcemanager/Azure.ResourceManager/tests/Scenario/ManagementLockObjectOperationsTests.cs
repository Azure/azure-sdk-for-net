// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementLockObjectOperationsTests : ResourceManagerTestBase
    {
        public ManagementLockObjectOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject = await CreateManagementLockObject(subscription, mgmtLockObjectName);
            await mgmtLockObject.DeleteAsync(true);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await mgmtLockObject.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
