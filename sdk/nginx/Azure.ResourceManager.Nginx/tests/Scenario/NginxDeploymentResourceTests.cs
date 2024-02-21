// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Nginx.Models;
using Azure.ResourceManager.Nginx.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Scenario
{
    internal class NginxDeploymentResourceTests : NginxManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }

        public NginxDeploymentResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public NginxDeploymentResourceTests(bool isAsync) : base(isAsync)
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
            ResourceIdentifier nginxResourceIdentifier = NginxDeploymentResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName);
            NginxDeploymentResource.ValidateResourceId(nginxResourceIdentifier);

            Assert.IsTrue(nginxResourceIdentifier.ResourceType.Equals(NginxDeploymentResource.ResourceType));
            Assert.IsTrue(nginxResourceIdentifier.Equals($"{ResGroup.Id}/providers/{NginxDeploymentResource.ResourceType}/{nginxDeploymentName}"));
            Assert.Throws<ArgumentException>(() => NginxDeploymentResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            Assert.IsTrue(nginxDeployment.HasData);
            Assert.NotNull(nginxDeployment.Data);
            Assert.IsTrue(nginxDeployment.Data.Name.Equals(nginxDeploymentName));
            Assert.IsNotNull(nginxDeployment.Data.Identity);
            Assert.IsNotNull(nginxDeployment.Data.SkuName);
            Assert.IsNotNull(nginxDeployment.Data.Properties.ProvisioningState);
            Assert.IsNotNull(nginxDeployment.Data.Properties.NginxVersion);
            Assert.IsNotNull(nginxDeployment.Data.Properties.NetworkProfile.FrontEndIPConfiguration);
            Assert.IsNotNull(nginxDeployment.Data.Properties.NetworkProfile.NetworkInterfaceConfiguration);
            Assert.IsNotNull(nginxDeployment.Data.Properties.NetworkProfile.NetworkInterfaceSubnetId);
            Assert.IsNotNull(nginxDeployment.Data.Properties.IPAddress);
            Assert.IsNotNull(nginxDeployment.Data.Properties.EnableDiagnosticsSupport);
            Assert.IsNotNull(nginxDeployment.Data.Properties.ScalingCapacity);
            Assert.IsNotNull(nginxDeployment.Data.Properties.UserPreferredEmail);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxCertificates()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();
            Assert.NotNull(collection);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxCertificate()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            string certificateVirtualPath = "/etc/nginx/nginx.cert";
            string keyVirtualPath = "/etc/nginx/nginx.key";
            _ = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NginxCertificateResource nginxCertificate = await nginxDeployment.GetNginxCertificateAsync(nginxCertificateName);

            Assert.NotNull(nginxCertificate);
            Assert.IsTrue(nginxCertificateName.Equals(nginxCertificate.Data.Name));
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await nginxDeployment.GetNginxCertificateAsync(nginxCertificateName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await nginxDeployment.GetNginxCertificateAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxConfigurations()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxConfigurationCollection collection = nginxDeployment.GetNginxConfigurations();
            Assert.NotNull(collection);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxConfiguration()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxConfigurationName = "default";
            string virtualPath = "/etc/nginx/nginx.conf";
            _ = await CreateNginxConfiguration(Location, nginxDeployment, nginxConfigurationName, virtualPath);
            NginxConfigurationResource nginxConfiguration = await nginxDeployment.GetNginxConfigurationAsync(nginxConfigurationName);

            Assert.NotNull(nginxConfiguration);
            Assert.IsTrue(nginxConfigurationName.Equals(nginxConfiguration.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await nginxDeployment.GetNginxConfigurationAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentResource response = await nginxDeployment.GetAsync();

            ResourceDataHelper.AssertTrackedResourceData(nginxDeployment.Data, response.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            NginxDeploymentCollection collection = ResGroup.GetNginxDeployments();
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            await nginxDeployment.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await collection.ExistsAsync(nginxDeploymentName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentPatch deploymentPatch = new NginxDeploymentPatch();
            deploymentPatch.Tags.Add("Counter", "1");
            NginxDeploymentResource nginxDeployment2 = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.AreEqual(nginxDeployment2.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentResource nginxDeployment2 = await nginxDeployment.AddTagAsync("Counter", "1");

            Assert.AreEqual(nginxDeployment2.Data.Tags["Counter"], "1");
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.AddTagAsync(null, "1")).Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.AddTagAsync("Counter", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentResource nginxDeployment2 = await nginxDeployment.AddTagAsync("Counter", "1");

            Assert.AreEqual(nginxDeployment2.Data.Tags["Counter"], "1");
            await Delay(TimeSpan.FromMinutes(2).Milliseconds);
            NginxDeploymentResource nginxDeployment3 = await nginxDeployment.RemoveTagAsync("Counter");

            Assert.IsFalse(nginxDeployment3.Data.Tags.ContainsKey("Counter"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.RemoveTagAsync(null)).Value);
        }
    }
}
