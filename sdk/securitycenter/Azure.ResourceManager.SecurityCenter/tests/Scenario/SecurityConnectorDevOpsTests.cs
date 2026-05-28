﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SecurityConnectorDevOpsTests : SecurityCenterManagementTestBase
    {
        private const string DevOpsConnectorsResourceGroup = "dfdtest-sdk";
        private const string TempDevOpsConnectorsResourceGroup = "dfdtest-sdk-tmp";
        private const string AzureDevOpsStaticConnectorName = "dfdsdktests-azdo-01";
        private const string GitHubStaticConnectorName = "dfdsdktests-gh-01";
        private const string GitLabStaticConnectorName = "dfdsdktests-gl-01";

        private ResourceGroupResource _defaultResourceGroup;

        public SecurityConnectorDevOpsTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback) // Change to RecordedTestMode.Record to regenerate tests
        {
            JsonPathSanitizers.Add("$..authorization.code");
            SanitizedHeaders.Add("Set-Cookie");
        }

        [SetUp]
        public async Task TestSetup()
        {
            _defaultResourceGroup = await DefaultSubscription.GetResourceGroups().GetAsync(DevOpsConnectorsResourceGroup);        }

        [RecordedTest]
        public async Task GenericDevOpsConfiguration_CreateOrUpdateAndDeleteFailed()
        {
            var tempResourceGroupName = Recording.GenerateAssetName(TempDevOpsConnectorsResourceGroup);
            string hierarchyId = Recording.GenerateAssetName("0223e997-c821-4df6-a6df-843c6465"); //workaround to generate semi-random guid to reduce collisions between sync and async tests
            string connectorName = Recording.GenerateAssetName("dfdsdktest-tmp");

            ResourceGroupData input = new ResourceGroupData(TestEnvironment.Location);
            var armOperationResourceGroupResource = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, tempResourceGroupName, input);
            var resourceGroup = armOperationResourceGroupResource.Value;

            var data = new SecurityConnectorData(TestEnvironment.Location)
            {
                EnvironmentName = SecurityCenterCloudName.AzureDevOps,
                HierarchyIdentifier = hierarchyId,
                EnvironmentData = new AzureDevOpsScopeEnvironment()
            };

            data.EnvironmentName = SecurityCenterCloudName.AzureDevOps;
            data.EnvironmentData = new AzureDevOpsScopeEnvironment();
            data.Offerings.Add(new CspmMonitorAzureDevOpsOffering());

            var securityConnectorOperation = await resourceGroup.GetSecurityConnectors().CreateOrUpdateAsync(WaitUntil.Completed, connectorName, data);

            Assert.IsNotNull(securityConnectorOperation);
            Assert.AreEqual(true, securityConnectorOperation.HasCompleted);
            Assert.AreEqual(data.EnvironmentName, securityConnectorOperation.Value.Data.EnvironmentName.Value);

            // setup devops
            var devopsConfigurationResource = securityConnectorOperation.Value.GetDevOpsConfiguration();

            Assert.IsFalse(devopsConfigurationResource.HasData);

            var devOpsConfigurationData = new DevOpsConfigurationData()
            {
                Properties = new DevOpsConfigurationProperties()
                {
                    AutoDiscovery = DevOpsAutoDiscovery.Disabled,
                    Authorization = new DevOpsAuthorization("NotRealValue", null)
                }
            };

            devOpsConfigurationData.Properties.TopLevelInventoryList.Add("dfdsdktests");

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => {
                try
                {
                    await devopsConfigurationResource.CreateOrUpdateAsync(WaitUntil.Completed, devOpsConfigurationData);
                }
                catch (InvalidOperationException ioex)
                {
                    // Recorded tests incorrectly throws InvalidOperationException instead of RequestFailedException.
                    if (ioex.Message.Contains("TokenExchangeFailed"))
                    {
                        throw new RequestFailedException(200, "AzureDevOps OAuth token exchange failed", "TokenExchangeFailed", null);
                    }
                    throw;
                }
             });
            Assert.IsNotNull(ex);
            Assert.AreEqual("TokenExchangeFailed", ex.ErrorCode);

            var deleteLro = await devopsConfigurationResource.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteLro);
            Assert.IsTrue(deleteLro.HasCompleted);
        }

        [RecordedTest]
        public async Task GenericDevOpsConfiguration_Patch()
        {
            // there is no difference which connectorName is used all SCMs use same implementation
            ResourceIdentifier repositoryResourceId = DevOpsConfigurationResource.CreateResourceIdentifier(
                subscriptionId: TestEnvironment.SubscriptionId,
                resourceGroupName: DevOpsConnectorsResourceGroup,
                securityConnectorName: AzureDevOpsStaticConnectorName);

            DevOpsConfigurationResource devops = await Client.GetDevOpsConfigurationResource(repositoryResourceId).GetAsync();

            var operation = await devops.UpdateAsync(WaitUntil.Completed, new DevOpsConfigurationData());
            Assert.IsNotNull(operation);
            Assert.AreEqual(DevOpsAutoDiscovery.Disabled, operation.Value.Data.Properties.AutoDiscovery);
        }

        [RecordedTest]
        public async Task AzureDevOps_Get()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Disabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedOrg = await devopsConfigurationResource.Value.GetDevOpsOrgs().GetAsync("dfdsdktests");

            Assert.AreEqual("dfdsdktests", onboardedOrg.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedOrg.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedOrg.Value.Data.Properties.OnboardingState);

            var onboardedProject = await onboardedOrg.Value.GetDevOpsProjects().GetAsync("ContosoSDKDfd");
            Assert.IsTrue(onboardedProject.Value.HasData);
            Assert.AreEqual("ContosoSDKDfd", onboardedProject.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedProject.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedProject.Value.Data.Properties.OnboardingState);

            var onboardedRepo = await onboardedProject.Value.GetDevOpsRepositories().GetAsync("TestApp0");
            Assert.IsTrue(onboardedRepo.Value.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Value.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedRepo.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedRepo.Value.Data.Properties.OnboardingState);
            Assert.AreEqual(ActionableRemediationState.None, onboardedRepo.Value.Data.Properties.ActionableRemediation.State);
        }

        [RecordedTest]
        public async Task AzureDevOps_GetAll()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Disabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedOrgs = await devopsConfigurationResource.Value.GetDevOpsOrgs().GetAllAsync().ToEnumerableAsync();
            var onboardedOrg = onboardedOrgs.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.AreEqual("dfdsdktests", onboardedOrg.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedOrg.Data.Properties.OnboardingState);

            var onboardedProjects = await onboardedOrg.GetDevOpsProjects().GetAllAsync().ToEnumerableAsync();
            var onboardedProject = onboardedProjects.Where(project => project.Data.Name.Equals("ContosoSDKDfd")).FirstOrDefault();
            Assert.IsTrue(onboardedProject.HasData);
            Assert.AreEqual("ContosoSDKDfd", onboardedProject.Data.Name);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, onboardedProject.Data.Properties.ProvisioningState);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedProject.Data.Properties.OnboardingState);

            var onboardedRepos = await onboardedProject.GetDevOpsRepositories().GetAllAsync().ToEnumerableAsync();
            var onboardedRepo = onboardedRepos.Where(project => project.Data.Name.Equals("TestApp0")).FirstOrDefault();

            Assert.IsTrue(onboardedRepo.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedRepo.Data.Properties.OnboardingState);
            Assert.AreEqual(ActionableRemediationState.None, onboardedRepo.Data.Properties.ActionableRemediation.State);
        }

        [RecordedTest]
        public async Task AzureDevOps_GetAvailableAzureDevOpsOrgsAsync()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var azureDevOpsOrgs = await devopsConfigurationResource.Value.GetAvailableDevOpsOrgsAsync().ToEnumerableAsync();

            Assert.IsTrue(azureDevOpsOrgs.Count > 0);
            Assert.IsTrue(azureDevOpsOrgs.FirstOrDefault().HasData);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, azureDevOpsOrgs.FirstOrDefault().Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task AzureDevOps_PatchRepository()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            ResourceIdentifier repositoryResourceId = DevOpsRepositoryResource.CreateResourceIdentifier(
                subscriptionId: TestEnvironment.SubscriptionId,
                resourceGroupName: DevOpsConnectorsResourceGroup,
                securityConnectorName: connectorName,
                orgName: "dfdsdktests",
                projectName: "ContosoSDKDfd",
                repoName: "TestApp0");
            DevOpsRepositoryResource repository = await Client.GetDevOpsRepositoryResource(repositoryResourceId).GetAsync();

            var operation = await repository.UpdateAsync(WaitUntil.Completed, new DevOpsRepositoryData()
            {
                Properties = new DevOpsRepositoryProperties()
                {
                    ActionableRemediation = new ActionableRemediation()
                    {
                        InheritFromParentState = InheritFromParentState.Enabled
                    }
                }
            });
            Assert.IsNotNull(operation);
            Assert.AreEqual(InheritFromParentState.Enabled, operation.Value.Data.Properties.ActionableRemediation.InheritFromParentState);
        }

        [RecordedTest]
        public async Task GitHub_Get()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Enabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedOwner = await devopsConfigurationResource.Value.GetSecurityConnectorGitHubOwners().GetAsync("dfdsdktests");

            Assert.AreEqual("dfdsdktests", onboardedOwner.Value.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedOwner.Value.Data.Properties.OnboardingState);

            var onboardedRepo = await onboardedOwner.Value.GetSecurityConnectorGitHubRepositories().GetAsync("TestApp0");
            Assert.IsTrue(onboardedRepo.Value.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Value.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedRepo.Value.Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitHub_GetAll()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Enabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedOwners = await devopsConfigurationResource.Value.GetSecurityConnectorGitHubOwners().GetAllAsync().ToEnumerableAsync();
            var onboardedOwner = onboardedOwners.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.AreEqual("dfdsdktests", onboardedOwner.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedOwner.Data.Properties.OnboardingState);

            var onboardedRepos = await onboardedOwner.GetSecurityConnectorGitHubRepositories().GetAllAsync().ToEnumerableAsync();
            var onboardedRepo = onboardedRepos.Where(project => project.Data.Name.Equals("TestApp0")).FirstOrDefault();

            Assert.IsTrue(onboardedRepo.HasData);
            Assert.AreEqual("TestApp0", onboardedRepo.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedRepo.Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitHub_GetAvailableGitHubOwners()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var gitHubOwners = await devopsConfigurationResource.Value.GetAvailableGitHubOwnersAsync().ToEnumerableAsync();

            Assert.IsTrue(gitHubOwners.Count > 0);
            Assert.IsTrue(gitHubOwners.FirstOrDefault().HasData);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, gitHubOwners.FirstOrDefault().Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitLab_Get()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Disabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedGroup = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetAsync("dfdsdktests");

            Assert.AreEqual("dfdsdktests", onboardedGroup.Value.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedGroup.Value.Data.Properties.OnboardingState);

            var onboardedProject = await onboardedGroup.Value.GetSecurityConnectorGitLabProjects().GetAsync("testapp0");
            Assert.IsTrue(onboardedProject.Value.HasData);
            Assert.AreEqual("testapp0", onboardedProject.Value.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedProject.Value.Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitLab_GetAll()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);
            Assert.AreEqual(DevOpsAutoDiscovery.Disabled, devopsConfigurationResource.Value.Data.Properties.AutoDiscovery);

            var onboardedGroups = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetAllAsync().ToEnumerableAsync();
            var onboardedGroup = onboardedGroups.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.AreEqual("dfdsdktests", onboardedGroup.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedGroup.Data.Properties.OnboardingState);

            var onboardedProjects = await onboardedGroup.GetSecurityConnectorGitLabProjects().GetAllAsync().ToEnumerableAsync();
            var onboardedProject = onboardedProjects.Where(project => project.Data.Name.Equals("testapp0")).FirstOrDefault();

            Assert.IsTrue(onboardedProject.HasData);
            Assert.AreEqual("testapp0", onboardedProject.Data.Name);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, onboardedProject.Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitLab_GetAvailableGitLabGroupsAsync()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var gitLabGroups = await devopsConfigurationResource.Value.GetAvailableGitLabGroupsAsync().ToEnumerableAsync();

            Assert.IsTrue(gitLabGroups.Count > 0);
            Assert.IsTrue(gitLabGroups.FirstOrDefault().HasData);
            Assert.AreEqual(ResourceOnboardingState.Onboarded, gitLabGroups.FirstOrDefault().Data.Properties.OnboardingState);
        }

        [RecordedTest]
        public async Task GitLab_GetGitLabSubgroupsAsync()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.IsTrue(devopsConfigurationResource.Value.HasData);
            Assert.AreEqual(DevOpsProvisioningState.Succeeded, devopsConfigurationResource.Value.Data.Properties.ProvisioningState);

            var onboardedSubGroups = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetGitLabSubgroupsAsync("dfdsdktests").ToEnumerableAsync();

            Assert.IsTrue(onboardedSubGroups.Count == 2);

            var testSubgroup = onboardedSubGroups.Where(s => s.Data?.Properties?.FullyQualifiedName?.Contains("testsubgroupNested") == true).FirstOrDefault();
            Assert.IsNotNull(testSubgroup);
            Assert.AreEqual("dfdsdktests$testsubgroup1$testsubgroupNested", testSubgroup.Data.Properties.FullyQualifiedName);
        }
    }
}
