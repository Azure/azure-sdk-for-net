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

            Assert.That(nginxResourceIdentifier.ResourceType.Equals(NginxDeploymentResource.ResourceType), Is.True);
            Assert.That(nginxResourceIdentifier.Equals($"{ResGroup.Id}/providers/{NginxDeploymentResource.ResourceType}/{nginxDeploymentName}"), Is.True);
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            ResourceIdentifier nginxResourceIdentifier = NginxDeploymentResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName);
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            Assert.That(nginxDeployment.HasData, Is.True);
            Assert.That(nginxDeployment.Data, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Name.Equals(nginxDeploymentName), Is.True);
            Assert.That(nginxDeployment.Data.Id.Equals(nginxResourceIdentifier), Is.True);
            Assert.That(nginxDeployment.Data.ResourceType.Equals(NginxDeploymentResource.ResourceType), Is.True);
            Assert.That(nginxDeployment.Data.Location.Equals(Location), Is.True);
            Assert.That(nginxDeployment.Data.SystemData, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Tags, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Identity, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Sku, Is.Not.Null);
            Assert.That(nginxDeployment.Data.SkuName, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.ProvisioningState, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NginxVersion, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NetworkProfile.FrontEndIPConfiguration.PublicIPAddresses, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NetworkProfile.FrontEndIPConfiguration.PrivateIPAddresses, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NetworkProfile.NetworkInterfaceConfiguration.SubnetId, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NetworkProfile.NetworkInterfaceSubnetId, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.IPAddress, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.EnableDiagnosticsSupport, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.Logging, Is.Null);
            Assert.That(nginxDeployment.Data.Properties.LoggingStorageAccount, Is.Null);
            Assert.That(nginxDeployment.Data.Properties.ScalingProperties.Capacity, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.AutoUpgradeProfile.UpgradeChannel, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.UserProfile.PreferredEmail, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.UserPreferredEmail, Is.Not.Null);
            Assert.That(nginxDeployment.Data.Properties.NginxAppProtect, Is.Null);
            Assert.That(nginxDeployment.Data.Properties.DataplaneApiEndpoint, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxDeploymentApiKeys()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentApiKeyCollection collection = nginxDeployment.GetNginxDeploymentApiKeys();
            Assert.That(collection, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxDeploymentApiKey()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxDeploymentApiKeyName = Recording.GenerateAssetName("testApiKey-");
            _ = await CreateNginxDeploymentApiKey(nginxDeployment, nginxDeploymentApiKeyName);
            NginxDeploymentApiKeyResource nginxDeploymentApiKey = await nginxDeployment.GetNginxDeploymentApiKeyAsync(nginxDeploymentApiKeyName);

            Assert.That(nginxDeploymentApiKey, Is.Not.Null);
            Assert.That(nginxDeploymentApiKeyName.Equals(nginxDeploymentApiKey.Data.Name, StringComparison.InvariantCultureIgnoreCase), Is.True);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await nginxDeployment.GetNginxDeploymentApiKeyAsync(nginxDeploymentApiKeyName + "1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await nginxDeployment.GetNginxDeploymentApiKeyAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxCertificates()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxCertificateCollection collection = nginxDeployment.GetNginxCertificates();
            Assert.That(collection, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxCertificate()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            string nginxCertificateName = Recording.GenerateAssetName("testCertificate-");
            const string certificateVirtualPath = "/etc/nginx/nginx.cert";
            const string keyVirtualPath = "/etc/nginx/nginx.key";
            _ = await CreateNginxCertificate(Location, nginxDeployment, nginxCertificateName, certificateVirtualPath, keyVirtualPath);
            NginxCertificateResource nginxCertificate = await nginxDeployment.GetNginxCertificateAsync(nginxCertificateName);

            Assert.That(nginxCertificate, Is.Not.Null);
            Assert.That(nginxCertificateName.Equals(nginxCertificate.Data.Name, StringComparison.InvariantCultureIgnoreCase), Is.True);
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
            Assert.That(collection, Is.Not.Null);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetNginxConfiguration()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            _ = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath);
            NginxConfigurationResource nginxConfiguration = await nginxDeployment.GetNginxConfigurationAsync(nginxConfigurationName);

            Assert.That(nginxConfiguration, Is.Not.Null);
            Assert.That(nginxConfigurationName.Equals(nginxConfiguration.Data.Name, StringComparison.InvariantCultureIgnoreCase), Is.True);
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

            Assert.That((bool)await collection.ExistsAsync(nginxDeploymentName), Is.False);
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

            Assert.That(nginxDeployment2.Data.Tags["Counter"], Is.EqualTo("1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateScaling()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentPatch deploymentPatch = new NginxDeploymentPatch();
            List<NginxScaleProfile> nginxScaleProfiles = new List<NginxScaleProfile>();
            NginxScaleProfileCapacity nginxScaleProfileCapacity = new NginxScaleProfileCapacity(20, 30);
            NginxScaleProfile nginxScaleProfile = new NginxScaleProfile("default", nginxScaleProfileCapacity);
            nginxScaleProfiles.Add(nginxScaleProfile);
            NginxDeploymentAutoScaleSettings autoScaleSettings = new NginxDeploymentAutoScaleSettings(nginxScaleProfiles);
            NginxDeploymentScalingProperties testScalingProp = new NginxDeploymentScalingProperties(null, autoScaleSettings, null);
            deploymentPatch.Properties = new NginxDeploymentUpdateProperties
            {
                NginxAppProtect = null,
                ScalingProperties = testScalingProp
            };

            NginxDeploymentResource nginxDeployment2 = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.That(nginxDeployment2.Data.Properties.ScalingProperties.Profiles.Count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateAutoupgrade()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentPatch deploymentPatch = new NginxDeploymentPatch
            {
                Properties = new NginxDeploymentUpdateProperties()
                {
                    NginxAppProtect = null,
                    AutoUpgradeProfile = new AutoUpgradeProfile
                    {
                        UpgradeChannel = "stable"
                    }
                }
            };

            NginxDeploymentResource nginxDeployment2 = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.That(nginxDeployment2.Data.Properties.AutoUpgradeProfile.UpgradeChannel, Is.EqualTo("stable"));
        }

        [TestCase]
        [RecordedTest]
        public async Task AddTag()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);
            NginxDeploymentResource nginxDeployment2 = await nginxDeployment.AddTagAsync("Counter", "1");

            Assert.That(nginxDeployment2.Data.Tags["Counter"], Is.EqualTo("1"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.AddTagAsync(null, "1")).Value);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxDeployment.AddTagAsync("Counter", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task RemoveTag()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentPatch deploymentPatch = new NginxDeploymentPatch();
            deploymentPatch.Tags.Add("Counter", "1");
            NginxDeploymentResource nginxDeployment2 = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.That(nginxDeployment2.Data.Tags["Counter"], Is.EqualTo("1"));
            await Delay(TimeSpan.FromMinutes(3).Milliseconds);
            NginxDeploymentResource nginxDeployment3 = await nginxDeployment.RemoveTagAsync("Counter");

            Assert.That(nginxDeployment3.Data.Tags.ContainsKey("Counter"), Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateWebApplicationFirewall()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            NginxDeploymentPatch deploymentPatch = new NginxDeploymentPatch
            {
                Properties = new NginxDeploymentUpdateProperties()
            };
            deploymentPatch.Properties.WebApplicationFirewallActivationState = WebApplicationFirewallActivationState.Enabled;
            NginxDeploymentResource updatedNginxDeployment = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallActivationState, Is.Not.Null);
            Assert.That(WebApplicationFirewallActivationState.Enabled, Is.EqualTo(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallActivationState));
            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallSettings.ActivationState, Is.Not.Null);
            Assert.That(WebApplicationFirewallActivationState.Enabled, Is.EqualTo(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallSettings.ActivationState));
            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallStatus.AttackSignaturesPackage, Is.Not.Null);
            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallStatus.BotSignaturesPackage, Is.Not.Null);
            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallStatus.ThreatCampaignsPackage, Is.Not.Null);
            Assert.That(updatedNginxDeployment.Data.Properties.NginxAppProtect.WebApplicationFirewallStatus.ComponentVersions, Is.Not.Null);

            deploymentPatch.Properties.WebApplicationFirewallActivationState = WebApplicationFirewallActivationState.Disabled;
            NginxDeploymentResource nginxDeployment2 = (await nginxDeployment.UpdateAsync(WaitUntil.Completed, deploymentPatch)).Value;

            Assert.That(WebApplicationFirewallActivationState.Disabled, Is.EqualTo(nginxDeployment2.Data.Properties.NginxAppProtect.WebApplicationFirewallActivationState));
        }
    }
}
