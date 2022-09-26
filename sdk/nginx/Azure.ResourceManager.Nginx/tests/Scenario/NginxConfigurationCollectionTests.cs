// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
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

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(ResGroup, Location, nginxDeployment, nginxConfigurationName, virtualPath);

            Assert.IsTrue(nginxConfigurationName.Equals(nginxConfiguration.Data.Name));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration1 = await CreateNginxConfiguration(ResGroup, Location, nginxDeployment, nginxConfigurationName, virtualPath);
            NginxConfigurationResource nginxConfiguration2 = await collection.GetAsync(nginxConfigurationName);

            ResourceDataHelper.AssertTrackedResource(nginxConfiguration1.Data, nginxConfiguration2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(ResGroup, Location, nginxDeployment, nginxConfigurationName, virtualPath);

            Assert.IsTrue(await collection.ExistsAsync(nginxConfigurationName));
            Assert.IsFalse(await collection.ExistsAsync(Recording.GenerateAssetName("testConfiguration-")));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            string nginxConfigurationName = "default";
            string virtualPath1 = "/etc/nginx/nginx.conf";
            string virtualPath2 = "/etc/nginx/app.conf";
            _ = await CreateNginxConfiguration(ResGroup, Location, nginxDeployment, nginxConfigurationName, virtualPath1);
            _ = await CreateNginxConfiguration(ResGroup, Location, nginxDeployment, nginxConfigurationName, virtualPath2);

            int count = 0;
            await foreach (NginxConfigurationResource nginxConfiguration in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 1);
        }
    }
}
