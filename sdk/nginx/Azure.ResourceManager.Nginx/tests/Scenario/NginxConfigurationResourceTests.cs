// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxConfigurationResourceTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxConfigurationResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxConfigurationResourceTests(bool isAsync) : base(isAsync)
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
        public void CreateResourceIdentifier()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            ResourceIdentifier nginxConfigurationResourceIdentifier = NginxConfigurationResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, "default");
            NginxConfigurationResource.ValidateResourceId(nginxConfigurationResourceIdentifier);

            Assert.IsTrue(nginxConfigurationResourceIdentifier.ResourceType.Equals(NginxConfigurationResource.ResourceType));
            Assert.Throws<ArgumentException>(() => NginxConfigurationResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);

            Assert.IsTrue(nginxConfiguration.HasData);
            Assert.NotNull(nginxConfiguration.Data);
            Assert.IsTrue(nginxConfiguration.Data.Name.Equals(nginxConfigurationName));
            Assert.IsNotNull(nginxConfiguration.Data.Properties.ProvisioningState);
            Assert.True(nginxConfiguration.Data.Properties.RootFile.Equals(virtualPath));
            Assert.True(nginxConfiguration.Data.Properties.Files.Count != 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);
            NginxConfigurationResource response = await nginxConfiguration.GetAsync();

            ResourceDataHelper.AssertResourceData(nginxConfiguration.Data, response.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);
            Assert.IsTrue(await collection.ExistsAsync(nginxConfigurationName));

            await nginxConfiguration.DeleteAsync(WaitUntil.Completed);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(nginxConfigurationName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);

            NginxConfigurationFile rootConfigFile = new NginxConfigurationFile();
            rootConfigFile.Content = NginxConfigurationContent;
            rootConfigFile.VirtualPath = "/etc/nginx/app.conf";

            NginxConfigurationProperties configurationProperties = new NginxConfigurationProperties();
            configurationProperties.RootFile = rootConfigFile.VirtualPath;
            configurationProperties.Files.Add(rootConfigFile);

            NginxConfigurationData nginxConfigurationData = new NginxConfigurationData();
            nginxConfigurationData.Location = Location;
            nginxConfigurationData.Properties = configurationProperties;
            NginxConfigurationResource nginxConfiguration2 = (await nginxConfiguration.UpdateAsync(WaitUntil.Completed, nginxConfigurationData)).Value;

            Assert.AreNotEqual(nginxConfiguration.Data.Properties.RootFile, nginxConfiguration2.Data.Properties.RootFile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxConfiguration.UpdateAsync(WaitUntil.Completed, null)).Value);
        }
    }
}
