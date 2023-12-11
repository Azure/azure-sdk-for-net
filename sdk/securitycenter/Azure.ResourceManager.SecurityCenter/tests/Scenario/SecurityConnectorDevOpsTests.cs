﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SecurityConnectorDevOpsTests : SecurityCenterManagementTestBase
    {
        private const string DevOpsConnectorsResourceGroup = "dfdtest-sdk";

        private ResourceGroupResource _defaultResourceGroup;

        public SecurityConnectorDevOpsTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback) // Change to RecordedTestMode.Record to regenerate tests
        {
            JsonPathSanitizers.Add("$..code");
            SanitizedHeaders.Add("Set-Cookie");
        }

        [SetUp]
        public async Task TestSetup()
        {
            _defaultResourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync(DevOpsConnectorsResourceGroup);
        }

        //[OneTimeTearDown]
        //public async Task OneTimeTearDown()
        //{
        //    await CleanupSecurityConnectorsByPrefix(TempConnectorPrefix);
        //}

        //[RecordedTest]
        //public async Task AzureDevOps_CreateOrUpdate()
        //{
        //    // create new security connector
        //    string hierarchyId = Recording.GenerateAssetName("89d583e7-2986-4813-8a9e-9551e45a");
        //    string connectorName = Recording.GenerateAssetName(TempConnectorPrefix + "ado-");

        //    var data = new SecurityConnectorData(TestEnvironment.Location)
        //    {
        //        EnvironmentName = SecurityCenterCloudName.AzureDevOps,
        //        HierarchyIdentifier = hierarchyId,
        //        EnvironmentData = new AzureDevOpsScopeEnvironment()
        //    };

        //    data.EnvironmentName = SecurityCenterCloudName.AzureDevOps;
        //    data.EnvironmentData = new AzureDevOpsScopeEnvironment();
        //    data.Offerings.Add(new CspmMonitorAzureDevOpsOffering());

        //    var securityConnectorOperation = await _resourceGroup.GetSecurityConnectors().CreateOrUpdateAsync(WaitUntil.Completed, connectorName, data);

        //    Assert.IsNotNull(securityConnectorOperation);
        //    Assert.AreEqual(true, securityConnectorOperation.HasCompleted);
        //    Assert.AreEqual(data.EnvironmentName, securityConnectorOperation.Value.Data.EnvironmentName.Value);

        //    // setup devops
        //    var devopsConfigurationResource = securityConnectorOperation.Value.GetDevOpsConfiguration();

        //    Assert.IsFalse(devopsConfigurationResource.HasData);

        //    var devOpsConfigurationData = new DevOpsConfigurationData()
        //    {
        //        Properties = new DevOpsConfigurationProperties()
        //        {
        //            AutoDiscovery = AutoDiscovery.Disabled,
        //            Authorization = new Authorization("Sanitized")
        //        }
        //    };

        //    devOpsConfigurationData.Properties.TopLevelInventoryList.Add("dfdsdktest");

        //    var lro = await devopsConfigurationResource.CreateOrUpdateAsync(WaitUntil.Completed, devOpsConfigurationData);
        //    Assert.IsNotNull(lro);
        //}

        [RecordedTest]
        public async Task AzureDevOps_Get()
        {
            string connectorName = "dfdsdktests-azdo-01";

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var onboardedOrg = await devopsConfigurationResource.Value.GetAzureDevOpsOrgs().GetAsync("dfdsdktests");

            Assert.AreEqual("dfdsdktests", onboardedOrg.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedOrg.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedOrg.Value.Data.Properties.OnboardingState);

            var onboardedProject = await onboardedOrg.Value.GetAzureDevOpsProjects().GetAsync("ContosoSDKDfd");
            Assert.IsTrue(onboardedProject.Value.HasData);
            Assert.AreEqual("ContosoSDKDfd", onboardedProject.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedProject.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedProject.Value.Data.Properties.OnboardingState);

            var onboardedRepo = await onboardedProject.Value.GetAzureDevOpsRepositories().GetAsync("TestApp0");
            Assert.IsTrue(onboardedRepo.Value.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedRepo.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedRepo.Value.Data.Properties.OnboardingState);
            Assert.AreEqual(ActionableRemediationState.None, onboardedRepo.Value.Data.Properties.ActionableRemediation.State);
        }

        [RecordedTest]
        public async Task AzureDevOps_GetAll()
        {
            string connectorName = "dfdsdktests-azdo-01";

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var onboardedOrgs = await devopsConfigurationResource.Value.GetAzureDevOpsOrgs().GetAllAsync().ToEnumerableAsync();
            var onboardedOrg = onboardedOrgs.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.AreEqual("dfdsdktests", onboardedOrg.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedOrg.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedOrg.Data.Properties.OnboardingState);

            var onboardedProjects = await onboardedOrg.GetAzureDevOpsProjects().GetAllAsync().ToEnumerableAsync();
            var onboardedProject = onboardedProjects.Where(project => project.Data.Name.Equals("ContosoSDKDfd")).FirstOrDefault();
            Assert.IsTrue(onboardedProject.HasData);
            Assert.AreEqual("ContosoSDKDfd", onboardedProject.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedProject.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedProject.Data.Properties.OnboardingState);

            var onboardedRepos = await onboardedProject.GetAzureDevOpsRepositories().GetAllAsync().ToEnumerableAsync();
            var onboardedRepo = onboardedRepos.Where(project => project.Data.Name.Equals("TestApp0")).FirstOrDefault();

            Assert.IsTrue(onboardedRepo.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedRepo.Data.Properties.ProvisioningState);
            Assert.AreEqual(OnboardingState.Onboarded, onboardedRepo.Data.Properties.OnboardingState);
            Assert.AreEqual(ActionableRemediationState.None, onboardedRepo.Data.Properties.ActionableRemediation.State);
        }

        //[RecordedTest]
        //public async Task GitHub_CreateOrUpdate()
        //{
        //    // create new security connector
        //    string hierarchyId = Recording.GenerateAssetName("89d583e7-2986-4813-8a9e-9551e45a");
        //    string connectorName = Recording.GenerateAssetName(TempConnectorPrefix + "gh-");

        //    var data = new SecurityConnectorData(TestEnvironment.Location)
        //    {
        //        EnvironmentName = SecurityCenterCloudName.Github,
        //        HierarchyIdentifier = hierarchyId,
        //        EnvironmentData = new GithubScopeEnvironment()
        //    };

        //    data.EnvironmentName = SecurityCenterCloudName.Github;
        //    data.EnvironmentData = new GithubScopeEnvironment();
        //    data.Offerings.Add(new CspmMonitorGithubOffering());

        //    var securityConnectorOperation = await _resourceGroup.GetSecurityConnectors().CreateOrUpdateAsync(WaitUntil.Completed, connectorName, data);

        //    Assert.IsNotNull(securityConnectorOperation);
        //    Assert.AreEqual(true, securityConnectorOperation.HasCompleted);
        //    Assert.AreEqual(data.EnvironmentName, securityConnectorOperation.Value.Data.EnvironmentName.Value);

        //    // setup devops
        //    var devopsConfigurationResource = securityConnectorOperation.Value.GetDevOpsConfiguration();

        //    Assert.IsFalse(devopsConfigurationResource.HasData);

        //    var devOpsConfigurationData = new DevOpsConfigurationData()
        //    {
        //        Properties = new DevOpsConfigurationProperties()
        //        {
        //            AutoDiscovery = AutoDiscovery.Enabled,
        //            Authorization = new Authorization("Sanitized")
        //        }
        //    };

        //    var lro = await devopsConfigurationResource.CreateOrUpdateAsync(WaitUntil.Completed, devOpsConfigurationData);
        //    Assert.IsNotNull(lro);
        //}

        //[RecordedTest]
        //public async Task GitLab_CreateOrUpdate()
        //{
        //    // create new security connector
        //    string hierarchyId = Recording.GenerateAssetName("89d583e7-2986-4813-8a9e-9551e45a");
        //    string connectorName = Recording.GenerateAssetName(TempConnectorPrefix + "gl-");

        //    var data = new SecurityConnectorData(TestEnvironment.Location)
        //    {
        //        EnvironmentName = SecurityCenterCloudName.GitLab,
        //        HierarchyIdentifier = hierarchyId,
        //        EnvironmentData = new GitlabScopeEnvironment()
        //    };

        //    data.EnvironmentName = SecurityCenterCloudName.GitLab;
        //    data.EnvironmentData = new GitlabScopeEnvironment();
        //    data.Offerings.Add(new CspmMonitorGitLabOffering());

        //    var securityConnectorOperation = await _resourceGroup.GetSecurityConnectors().CreateOrUpdateAsync(WaitUntil.Completed, connectorName, data);

        //    Assert.IsNotNull(securityConnectorOperation);
        //    Assert.AreEqual(true, securityConnectorOperation.HasCompleted);
        //    Assert.AreEqual(data.EnvironmentName, securityConnectorOperation.Value.Data.EnvironmentName.Value);

        //    // setup devops
        //    var devopsConfigurationResource = securityConnectorOperation.Value.GetDevOpsConfiguration();

        //    Assert.IsFalse(devopsConfigurationResource.HasData);

        //    var devOpsConfigurationData = new DevOpsConfigurationData()
        //    {
        //        Properties = new DevOpsConfigurationProperties()
        //        {
        //            AutoDiscovery = AutoDiscovery.Disabled,
        //            Authorization = new Authorization("Sanitized")
        //        }
        //    };

        //    var lro = await devopsConfigurationResource.CreateOrUpdateAsync(WaitUntil.Completed, devOpsConfigurationData);
        //    Assert.IsNotNull(lro);
        //}

        //private async Task CleanupSecurityConnectorsByPrefix(string prefix)
        //{
        //    var connectors = await _defaultResourceGroup.GetSecurityConnectors().GetAllAsync().ToEnumerableAsync();
        //    var deleteConnectorTasks = connectors.Select(async securityConnector =>
        //    {
        //        try
        //        {
        //            if (securityConnector.HasData && securityConnector.Data.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        //            {
        //                await securityConnector.DeleteAsync(WaitUntil.Completed);
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    });
        //    await Task.WhenAll(deleteConnectorTasks);
        //}
    }
}