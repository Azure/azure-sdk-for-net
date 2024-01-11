// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxDeploymentCollectionTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxDeploymentCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxDeploymentCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await CreateResourceGroup(Subscription, ResourceGroupPrefix, Location);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            Assert.IsTrue(nginxDeploymentName.Equals(nginxDeployment.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await ResGroup.GetNginxDeployments().CreateOrUpdateAsync(WaitUntil.Completed, nginxDeploymentName, null)).Value);

            NginxDeploymentData nginxDeploymentData = new NginxDeploymentData(Location);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await ResGroup.GetNginxDeployments().CreateOrUpdateAsync(WaitUntil.Completed, null, nginxDeploymentData)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            NginxDeploymentCollection collection = ResGroup.GetNginxDeployments();
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment1 = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentResource nginxDeployment2 = await collection.GetAsync(nginxDeploymentName);

            ResourceDataHelper.AssertTrackedResourceData(nginxDeployment1.Data, nginxDeployment2.Data);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(nginxDeploymentName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            NginxDeploymentCollection collection = ResGroup.GetNginxDeployments();
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            Assert.IsTrue(await collection.ExistsAsync(nginxDeploymentName));
            Assert.IsFalse(await collection.ExistsAsync(nginxDeploymentName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetIfExists()
        {
            NginxDeploymentCollection collection = ResGroup.GetNginxDeployments();
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment1 = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NullableResponse<NginxDeploymentResource> nginxDeploymentResponse = await collection.GetIfExistsAsync(nginxDeploymentName);

            Assert.True(nginxDeploymentResponse.HasValue);
            NginxDeploymentResource nginxDeployment2 = nginxDeploymentResponse.Value;
            ResourceDataHelper.AssertTrackedResourceData(nginxDeployment1.Data, nginxDeployment2.Data);

            NullableResponse<NginxDeploymentResource> nginxDeploymentResource2 = await collection.GetIfExistsAsync(nginxDeploymentName + "1");
            Assert.False(nginxDeploymentResource2.HasValue);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            NginxDeploymentCollection collection = ResGroup.GetNginxDeployments();

            int count = 0;
            await foreach (NginxDeploymentResource nginxDeployment in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 0);

            string nginxDeploymentName1 = Recording.GenerateAssetName("testDeployment-");
            string nginxDeploymentName2 = Recording.GenerateAssetName("testDeployment-");
            _ = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName1);
            _ = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName2);

            await foreach (NginxDeploymentResource nginxDeployment in collection.GetAllAsync())
            {
                count++;
            }

            Assert.GreaterOrEqual(count, 2);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            string nginxDeploymentName1 = Recording.GenerateAssetName("testDeployment-");
            string nginxDeploymentName2 = Recording.GenerateAssetName("testDeployment-");
            _ = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName1);
            _ = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName2);

            NginxDeploymentResource nginxDeployment1 = null, nginxDeployment2 = null;
            await foreach (NginxDeploymentResource nginxDeployment in Subscription.GetNginxDeploymentsAsync())
            {
                if (nginxDeployment.Data.Name == nginxDeploymentName1)
                    nginxDeployment1 = nginxDeployment;
                if (nginxDeployment.Data.Name == nginxDeploymentName2)
                    nginxDeployment2 = nginxDeployment;
            }

            Assert.NotNull(nginxDeployment1);
            Assert.NotNull(nginxDeployment2);
        }
    }
}
