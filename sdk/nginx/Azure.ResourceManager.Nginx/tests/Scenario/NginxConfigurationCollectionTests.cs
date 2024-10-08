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
    internal class NginxConfigurationCollectionTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxConfigurationCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxConfigurationCollectionTests(bool isAsync) : base(isAsync)
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

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);

            Assert.IsTrue(nginxConfigurationName.Equals(nginxConfiguration.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, nginxConfigurationName, null)).Value);

            NginxConfigurationData nginxConfigurationData = new NginxConfigurationData
            {
                Location = Location
            };
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.GetNginxConfigurations().CreateOrUpdateAsync(WaitUntil.Completed, null, nginxConfigurationData)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            const string nginxConfigurationName = "default";
            Assert.IsFalse(await collection.ExistsAsync(nginxConfigurationName));
            const string virtualPath = "/etc/nginx/nginx.conf";
            _ = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);

            Assert.IsTrue(await collection.ExistsAsync(nginxConfigurationName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetIfExists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            const string nginxConfigurationName = "default";
            NullableResponse<NginxConfigurationResource> nginxConfigurationResponse = await collection.GetIfExistsAsync(nginxConfigurationName);
            Assert.False(nginxConfigurationResponse.HasValue);

            const string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration1 = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);
            NullableResponse<NginxConfigurationResource> nginxConfigurationResponse2 = await collection.GetIfExistsAsync(nginxConfigurationName);
            Assert.True(nginxConfigurationResponse2.HasValue);
            NginxConfigurationResource nginxConfiguration2 = nginxConfigurationResponse2.Value;

            ResourceDataHelper.AssertResourceData(nginxConfiguration1.Data, nginxConfiguration2.Data);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.GetIfExistsAsync(null));
        }
    }
}
