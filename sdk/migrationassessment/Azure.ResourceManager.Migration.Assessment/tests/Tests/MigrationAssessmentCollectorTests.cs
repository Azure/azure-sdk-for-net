// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Migration.Assessment.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Migration.Assessment.Tests
{
    public class MigrationAssessmentCollectorTests : MigrationAssessmentManagementTestBase
    {
        private static AzureLocation targetRegion;
        private static string targetSubscriptionId;
        private static Guid tenantId;
        private static ResourceGroupResource rg;
        private static MigrationAssessmentProjectResource assessmentProjectResource;
        private static CollectorAgentPropertiesBase agentProperties;

        public MigrationAssessmentCollectorTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            targetRegion = AzureLocation.BrazilSouth;
            targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            tenantId = Guid.Parse("50d65f49-5a31-4b70-b34a-a73bb29b77c5");
            rg = await DefaultSubscription.GetResourceGroups().GetAsync("sakanwar");

            string assessmentProjName = Recording.GenerateAssetName("assessmentProj-");

            var assessmentProjectData = new MigrationAssessmentProjectData(targetRegion);
            var assessmentProjectCollection = rg.GetMigrationAssessmentProjects();

            // Create Assessment Project
            var response =
                await assessmentProjectCollection.CreateOrUpdateAsync(WaitUntil.Completed, assessmentProjName, assessmentProjectData);
            await response.WaitForCompletionAsync();
            assessmentProjectResource = response.Value;
            Assert.That(response.HasCompleted, Is.True);
            Assert.That(assessmentProjectResource, Is.Not.Null);

            agentProperties = new CollectorAgentPropertiesBase()
            {
                Id = Recording.GenerateAssetName("agentId-"),
                Version = "2.0.1993.19",
                LastHeartbeatOn = DateTimeOffset.Parse("2022-07-07T14:25:35.708325Z"),
                SpnDetails = new CollectorAgentSpnPropertiesBase()
                {
                    Authority = $"https://login.windows.net/{tenantId}",
                    ApplicationId = "5db4fda9-7d3d-410e-ba13-a84ec7d2f01f",
                    Audience = Recording.GenerateAssetName("audience-"),
                    ObjectId = "2354347c-7ed1-44c3-8f39-b3a972e3ce0e",
                    TenantId = tenantId,
                },
            };
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestHyperVCollectorOperations()
        {
            string rgName = rg.Id.Name;
            var hyperVCollectorCollection = assessmentProjectResource.GetMigrationAssessmentHyperVCollectors();

            // Create Hyper-V Collector
            var hyperVCollectorData = new MigrationAssessmentHyperVCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                AgentProperties = agentProperties,
                DiscoverySiteId =
                    string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.OffAzure/HyperVSites/{Recording.GenerateAssetName("site-")}"),
            };
            string hyperVCollectorName = Recording.GenerateAssetName("hyperVCollector-");
            var hyperVCollectorResponse =
                await hyperVCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, hyperVCollectorName, hyperVCollectorData);
            var hyperVCollectorResource = hyperVCollectorResponse.Value;
            Assert.That(hyperVCollectorResponse.HasCompleted, Is.True);
            Assert.That(hyperVCollectorResource, Is.Not.Null);

            // Get Hyper-V Collector
            hyperVCollectorResource = await hyperVCollectorCollection.GetAsync(hyperVCollectorName);
            Assert.That(hyperVCollectorResource, Is.Not.Null);
            Assert.That(hyperVCollectorName, Is.EqualTo(hyperVCollectorResource.Data.Name));

            // Get All Hyper-V Collectors
            var allHyperVCollectors = hyperVCollectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allHyperVCollectors, Is.Not.Null);
            Assert.That(allHyperVCollectors.Result.Count, Is.GreaterThanOrEqualTo(1));

            // Delete Hyper-V Collector
            await hyperVCollectorResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestVMwareCollectorOperations()
        {
            string rgName = rg.Id.Name;
            var vmwareCollectorCollection = assessmentProjectResource.GetMigrationAssessmentVMwareCollectors();

            // Create VMware Collector
            var vmwareCollectorData = new MigrationAssessmentVMwareCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                AgentProperties = agentProperties,
                DiscoverySiteId =
                    string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.OffAzure/VMwareSites/{Recording.GenerateAssetName("site-")}"),
            };
            string vmwareCollectorName = Recording.GenerateAssetName("vmwareCollector-");
            var vmwareCollectorResponse =
                await vmwareCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmwareCollectorName, vmwareCollectorData);
            var vmwareCollectorResource = vmwareCollectorResponse.Value;
            Assert.That(vmwareCollectorResponse.HasCompleted, Is.True);
            Assert.That(vmwareCollectorResource, Is.Not.Null);

            // Get VMware Collector
            vmwareCollectorResource = await vmwareCollectorCollection.GetAsync(vmwareCollectorName);
            Assert.That(vmwareCollectorResource, Is.Not.Null);
            Assert.That(vmwareCollectorName, Is.EqualTo(vmwareCollectorResource.Data.Name));

            // Get All VMware Collectors
            var allVMwareCollectors = vmwareCollectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allVMwareCollectors, Is.Not.Null);
            Assert.That(allVMwareCollectors.Result.Count, Is.GreaterThanOrEqualTo(1));

            // Delete VMware Collector
            await vmwareCollectorResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestServerCollectorOperations()
        {
            string rgName = rg.Id.Name;
            var serverCollectorCollection = assessmentProjectResource.GetMigrationAssessmentServerCollectors();

            // Create Server Collector
            var serverCollectorData = new MigrationAssessmentServerCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                AgentProperties = agentProperties,
                DiscoverySiteId =
                    string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.OffAzure/ServerSites/{Recording.GenerateAssetName("site-")}"),
            };
            string serverCollectorName = Recording.GenerateAssetName("serverCollector-");
            var serverCollectorResponse =
                await serverCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, serverCollectorName, serverCollectorData);
            var serverCollectorResource = serverCollectorResponse.Value;
            Assert.That(serverCollectorResponse.HasCompleted, Is.True);
            Assert.That(serverCollectorResource, Is.Not.Null);

            // Get Server Collector
            serverCollectorResource = await serverCollectorCollection.GetAsync(serverCollectorName);
            Assert.That(serverCollectorResource, Is.Not.Null);
            Assert.That(serverCollectorName, Is.EqualTo(serverCollectorResource.Data.Name));

            // Get All Server Collectors
            var allServerCollectors = serverCollectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allServerCollectors, Is.Not.Null);
            Assert.That(allServerCollectors.Result.Count, Is.GreaterThanOrEqualTo(1));

            // Delete Server Collector
            await serverCollectorResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestImportCollectorOperations()
        {
            string rgName = rg.Id.Name;

            var importCollectorCollection = assessmentProjectResource.GetMigrationAssessmentImportCollectors();

            // Create Import Collector
            var importCollectorData = new MigrationAssessmentImportCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                DiscoverySiteId =
                    string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.OffAzure/ImportSites/{Recording.GenerateAssetName("site-")}"),
            };
            string importCollectorName = Recording.GenerateAssetName("importCollector-");
            var importCollectorResponse =
                await importCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, importCollectorName, importCollectorData);
            var importCollectorResource = importCollectorResponse.Value;
            Assert.That(importCollectorResponse.HasCompleted, Is.True);
            Assert.That(importCollectorResource, Is.Not.Null);

            // Get Import Collector
            importCollectorResource = await importCollectorCollection.GetAsync(importCollectorName);
            Assert.That(importCollectorResource, Is.Not.Null);
            Assert.That(importCollectorName, Is.EqualTo(importCollectorResource.Data.Name));

            // Get All Import Collectors
            var allImportCollectors = importCollectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allImportCollectors, Is.Not.Null);
            Assert.That(allImportCollectors.Result.Count, Is.GreaterThanOrEqualTo(1));

            // Delete Import Collector
            await importCollectorResource.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        [Ignore("Defer for beta release; should address before stable release.")]
        public async Task TestSqlCollectorOperations()
        {
            string rgName = rg.Id.Name;
            var vmwareCollectorCollection = assessmentProjectResource.GetMigrationAssessmentVMwareCollectors();

            // Create VMware Collector
            var vmwareCollectorData = new MigrationAssessmentVMwareCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                AgentProperties = agentProperties,
                DiscoverySiteId =
                    string.Format($"/subscriptions/{targetSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.OffAzure/VMwareSites/{Recording.GenerateAssetName("site-")}"),
            };
            string vmwareCollectorName = Recording.GenerateAssetName("vmwareCollector-");
            var vmwareCollectorResponse =
                await vmwareCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmwareCollectorName, vmwareCollectorData);
            var vmwareCollectorResource = vmwareCollectorResponse.Value;
            Assert.That(vmwareCollectorResponse.HasCompleted, Is.True);
            Assert.That(vmwareCollectorResource, Is.Not.Null);

            var sqlAgentProperties = new CollectorAgentPropertiesBase()
            {
                Id = Recording.GenerateAssetName("agentId-"),
                Version = "2.0.1993.19",
                LastHeartbeatOn = DateTimeOffset.Parse("2022-07-07T14:25:35.708325Z"),
                SpnDetails = new CollectorAgentSpnPropertiesBase()
                {
                    Authority = $"https://login.windows.net/{tenantId}",
                    ApplicationId = "5db4fda9-7d3d-410e-ba13-a84ec7d2f01f",
                    Audience = Recording.GenerateAssetName("audience-"),
                    ObjectId = "2354347c-7ed1-44c3-8f39-b3a972e3ce0e",
                    TenantId = tenantId,
                },
            };

            var sqlCollectorCollection = assessmentProjectResource.GetMigrationAssessmentSqlCollectors();

            // Create SQL Collector
            var sqlCollectorData = new MigrationAssessmentSqlCollectorData()
            {
                ProvisioningState = MigrationAssessmentProvisioningState.Succeeded,
                AgentProperties = sqlAgentProperties,
                DiscoverySiteId =
                    string.Format($"{vmwareCollectorResource.Id}/SqlSites/{Recording.GenerateAssetName("site-")}"),
            };
            string sqlCollectorName = Recording.GenerateAssetName("sqlCollector-");
            var sqlCollectorResponse =
                await sqlCollectorCollection.CreateOrUpdateAsync(WaitUntil.Completed, sqlCollectorName, sqlCollectorData);
            var sqlCollectorResource = sqlCollectorResponse.Value;
            Assert.That(sqlCollectorResponse.HasCompleted, Is.True);
            Assert.That(sqlCollectorResource, Is.Not.Null);

            // Get SQL Collector
            sqlCollectorResource = await sqlCollectorCollection.GetAsync(sqlCollectorName);
            Assert.That(sqlCollectorResource, Is.Not.Null);
            Assert.That(sqlCollectorName, Is.EqualTo(sqlCollectorResource.Data.Name));

            // Get All SQL Collectors
            var allSqlCollectors = sqlCollectorCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(allSqlCollectors, Is.Not.Null);
            Assert.That(allSqlCollectors.Result.Count, Is.GreaterThanOrEqualTo(1));

            // Delete SQL Collector
            await sqlCollectorResource.DeleteAsync(WaitUntil.Completed);
            await vmwareCollectorResource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
