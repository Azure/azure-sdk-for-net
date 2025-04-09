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

            const string nginxConfigurationName = "default";
            const string virtualPath = "/etc/nginx/nginx.conf";
            const string protectedVirtualPath = "/etc/nginx/protected.conf";
            NginxConfigurationResource nginxConfiguration = await CreateNginxConfiguration(nginxDeployment, nginxConfigurationName, virtualPath, protectedVirtualPath);
            ResourceIdentifier nginxConfigurationResourceIdentifier = NginxConfigurationResource.CreateResourceIdentifier(Subscription.Data.SubscriptionId, ResGroup.Data.Name, nginxDeploymentName, nginxConfigurationName);

            Assert.IsTrue(nginxConfiguration.HasData);
            Assert.NotNull(nginxConfiguration.Data);
            Assert.IsTrue(nginxConfiguration.Data.Name.Equals(nginxConfigurationName));
            Assert.IsTrue(nginxConfiguration.Data.Id.Equals(nginxConfigurationResourceIdentifier));
            Assert.IsTrue(nginxConfiguration.Data.ResourceType.Equals(NginxConfigurationResource.ResourceType));
            Assert.IsNull(nginxConfiguration.Data.SystemData);
            Assert.IsNotNull(nginxConfiguration.Data.Properties.ProvisioningState);
            Assert.True(nginxConfiguration.Data.Properties.RootFile.Equals(virtualPath));
            Assert.True(nginxConfiguration.Data.Properties.Files.Count != 0);
            Assert.True(nginxConfiguration.Data.Properties.Files[0].VirtualPath.Equals(virtualPath));
            Assert.True(nginxConfiguration.Data.Properties.Files[0].Content.Equals(NginxConfigurationContent));
            Assert.True(nginxConfiguration.Data.Properties.ProtectedFiles.Count != 0);
            Assert.True(nginxConfiguration.Data.Properties.ProtectedFiles[0].VirtualPath.Equals(protectedVirtualPath));
            Assert.IsNotNull(nginxConfiguration.Data.Properties.ProtectedFiles[0].ContentHash);
            Assert.IsNull(nginxConfiguration.Data.Properties.Package.Data);
            Assert.True(nginxConfiguration.Data.Properties.Package.ProtectedFiles.Count == 0);
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

            Assert.AreNotEqual(nginxConfiguration.Data.Properties.RootFile, nginxConfiguration2.Data.Properties.RootFile);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await nginxConfiguration.UpdateAsync(WaitUntil.Completed, null)).Value);
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

            NginxConfigurationProtectedFileContent protectedFile = new NginxConfigurationProtectedFileContent
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

            Assert.IsNotNull(analysisResult);
            Assert.IsNotNull(analysisResult.Status);
            Assert.IsNotNull(analysisResult.Data.Errors);
            Assert.IsNotNull(analysisResult.Data.Diagnostics);
        }
    }
}
