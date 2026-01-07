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

            Assert.That(nginxConfigurationResourceIdentifier.ResourceType, Is.EqualTo(NginxConfigurationResource.ResourceType));
        }

        [TestCase]
        [RecordedTest]
        public async Task Data()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            const string protectedVirtualPath = "/etc/nginx/protected.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath, protectedVirtualPath);
            ResourceIdentifier nginxConfigurationResourceIdentifier = NginxConfigurationResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, nginxConfigurationName);

            Assert.That(nginxConfiguration.HasData, Is.True);
            Assert.That(nginxConfiguration.Data, Is.Not.Null);
            Assert.That(nginxConfiguration.Data.Name, Is.EqualTo(nginxConfigurationName));
            Assert.That(nginxConfiguration.Data.Id, Is.EqualTo(nginxConfigurationResourceIdentifier));
            Assert.That(nginxConfiguration.Data.ResourceType, Is.EqualTo(NginxConfigurationResource.ResourceType));
            Assert.That(nginxConfiguration.Data.SystemData, Is.Null);
            Assert.That(nginxConfiguration.Data.Properties.ProvisioningState, Is.Not.Null);
            Assert.That(nginxConfiguration.Data.Properties.RootFile, Is.EqualTo(virtualPath));
            Assert.That(nginxConfiguration.Data.Properties.Files.Count != 0, Is.True);
            Assert.That(nginxConfiguration.Data.Properties.Files[0].VirtualPath, Is.EqualTo(virtualPath));
            Assert.That(nginxConfiguration.Data.Properties.Files[0].Content, Is.EqualTo(NginxConfigurationContent));
            Assert.That(nginxConfiguration.Data.Properties.ProtectedFiles.Count != 0, Is.True);
            Assert.That(nginxConfiguration.Data.Properties.ProtectedFiles[0].VirtualPath, Is.EqualTo(protectedVirtualPath));
            Assert.That(nginxConfiguration.Data.Properties.ProtectedFiles[0].ContentHash, Is.Not.Null);
            Assert.That(nginxConfiguration.Data.Properties.Package.Data, Is.Null);
            Assert.That(nginxConfiguration.Data.Properties.Package.ProtectedFiles.Count, Is.EqualTo(0));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath);
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

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath);
            Assert.That((bool)await collection.ExistsAsync(nginxConfigurationName), Is.True);

            await nginxConfiguration.DeleteAsync(WaitUntil.Completed);
            Assert.ThrowsAsync<RequestFailedException>(async () => _ = await collection.GetAsync(nginxConfigurationName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath);

            NginxConfigurationFile rootConfigFile = new NginxConfigurationFile
            {
                Content = NginxConfigurationContent,
                VirtualPath = "/etc/nginx/app.conf"
            };

            NginxConfigurationCreateOrUpdateProperties configurationProperties = new NginxConfigurationCreateOrUpdateProperties
            {
                RootFile = rootConfigFile.VirtualPath
            };
            configurationProperties.Files.Add(rootConfigFile);

            NginxConfigurationCreateOrUpdateContent nginxConfigurationCreateOrUpdateContent = new NginxConfigurationCreateOrUpdateContent
            {
                Properties = configurationProperties
            };
            NginxConfigurationResource nginxConfiguration2 = (await nginxConfiguration.UpdateAsync(WaitUntil.Completed, nginxConfigurationCreateOrUpdateContent)).Value;

            Assert.That(nginxConfiguration2.Data.Properties.RootFile, Is.Not.EqualTo(nginxConfiguration.Data.Properties.RootFile));
        }

        [TestCase]
        [RecordedTest]
        public async Task Analysis()
        {
            string nginxDeploymentName = Recording.GenerateAssetName("testDeployment-");
            NginxDeploymentResource nginxDeployment = await CreateNginxDeployment(ResGroup, Location, nginxDeploymentName);

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            const string protectedFileVirtualPath = "/etc/nginx/protected.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath);

            NginxConfigurationFile rootConfigFile = new NginxConfigurationFile
            {
                Content = NginxConfigurationContent,
                VirtualPath = virtualPath
            };

            NginxConfigurationContentProtectedFile protectedFile = new NginxConfigurationContentProtectedFile
            {
                Content = NginxConfigurationContent,
                VirtualPath = protectedFileVirtualPath
            };

            NginxAnalysisConfig nginxAnalysisConfig = new NginxAnalysisConfig
            {
                RootFile = rootConfigFile.VirtualPath,
            };
            nginxAnalysisConfig.Files.Add(rootConfigFile);
            nginxAnalysisConfig.ProtectedFiles.Add(protectedFile);

            NginxAnalysisContent nginxAnalysisContent = new NginxAnalysisContent(nginxAnalysisConfig);
            NginxAnalysisResult analysisResult = await nginxConfiguration.AnalysisAsync(nginxAnalysisContent);

            Assert.That(analysisResult, Is.Not.Null);
            Assert.That(analysisResult.Status, Is.Not.Null);
            Assert.That(analysisResult.Data.Errors, Is.Not.Null);
            Assert.That(analysisResult.Data.Diagnostics, Is.Not.Null);
        }
    }
}
