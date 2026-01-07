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
            Assert.That(securityConnectorOperation.HasCompleted, Is.EqualTo(true));
            Assert.That(securityConnectorOperation.Value.Data.EnvironmentName.Value, Is.EqualTo(data.EnvironmentName));

            // setup devops
            var devopsConfigurationResource = securityConnectorOperation.Value.GetDevOpsConfiguration();

            Assert.That(devopsConfigurationResource.HasData, Is.False);

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
            Assert.That(ex.ErrorCode, Is.EqualTo("TokenExchangeFailed"));

            var deleteLro = await devopsConfigurationResource.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteLro);
            Assert.That(deleteLro.HasCompleted, Is.True);
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
            Assert.That(operation.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Disabled));
        }

        [RecordedTest]
        public async Task AzureDevOps_Get()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Disabled));

            var onboardedOrg = await devopsConfigurationResource.Value.GetDevOpsOrgs().GetAsync("dfdsdktests");

            Assert.That(onboardedOrg.Value.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedOrg.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(onboardedOrg.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedProject = await onboardedOrg.Value.GetDevOpsProjects().GetAsync("ContosoSDKDfd");
            Assert.That(onboardedProject.Value.HasData, Is.True);
            Assert.That(onboardedProject.Value.Data.Name, Is.EqualTo("ContosoSDKDfd"));
            Assert.That(onboardedProject.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(onboardedProject.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedRepo = await onboardedProject.Value.GetDevOpsRepositories().GetAsync("TestApp0");
            Assert.That(onboardedRepo.Value.HasData, Is.True);
            Assert.That(onboardedRepo.Value.Data.Name, Is.EqualTo("TestApp0"));
            Assert.That(onboardedRepo.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(onboardedRepo.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
            Assert.That(onboardedRepo.Value.Data.Properties.ActionableRemediation.State, Is.EqualTo(ActionableRemediationState.None));
        }

        [RecordedTest]
        public async Task AzureDevOps_GetAll()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Disabled));

            var onboardedOrgs = await devopsConfigurationResource.Value.GetDevOpsOrgs().GetAllAsync().ToEnumerableAsync();
            var onboardedOrg = onboardedOrgs.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.That(onboardedOrg.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedOrg.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedProjects = await onboardedOrg.GetDevOpsProjects().GetAllAsync().ToEnumerableAsync();
            var onboardedProject = onboardedProjects.Where(project => project.Data.Name.Equals("ContosoSDKDfd")).FirstOrDefault();
            Assert.That(onboardedProject.HasData, Is.True);
            Assert.That(onboardedProject.Data.Name, Is.EqualTo("ContosoSDKDfd"));
            Assert.That(onboardedProject.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(onboardedProject.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedRepos = await onboardedProject.GetDevOpsRepositories().GetAllAsync().ToEnumerableAsync();
            var onboardedRepo = onboardedRepos.Where(project => project.Data.Name.Equals("TestApp0")).FirstOrDefault();

            Assert.That(onboardedRepo.HasData, Is.True);
            Assert.That(onboardedRepo.Data.Name, Is.EqualTo("TestApp0"));
            Assert.That(onboardedRepo.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
            Assert.That(onboardedRepo.Data.Properties.ActionableRemediation.State, Is.EqualTo(ActionableRemediationState.None));
        }

        [RecordedTest]
        public async Task AzureDevOps_GetAvailableAzureDevOpsOrgsAsync()
        {
            string connectorName = AzureDevOpsStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));

            var azureDevOpsOrgs = await devopsConfigurationResource.Value.GetAvailableDevOpsOrgsAsync().ToEnumerableAsync();

            Assert.That(azureDevOpsOrgs.Count > 0, Is.True);
            Assert.That(azureDevOpsOrgs.FirstOrDefault().HasData, Is.True);
            Assert.That(azureDevOpsOrgs.FirstOrDefault().Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
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
            Assert.That(operation.Value.Data.Properties.ActionableRemediation.InheritFromParentState, Is.EqualTo(InheritFromParentState.Enabled));
        }

        [RecordedTest]
        public async Task GitHub_Get()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Enabled));

            var onboardedOwner = await devopsConfigurationResource.Value.GetSecurityConnectorGitHubOwners().GetAsync("dfdsdktests");

            Assert.That(onboardedOwner.Value.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedOwner.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedRepo = await onboardedOwner.Value.GetSecurityConnectorGitHubRepositories().GetAsync("TestApp0");
            Assert.That(onboardedRepo.Value.HasData, Is.True);
            Assert.That(onboardedRepo.Value.Data.Name, Is.EqualTo("TestApp0"));
            Assert.That(onboardedRepo.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitHub_GetAll()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Enabled));

            var onboardedOwners = await devopsConfigurationResource.Value.GetSecurityConnectorGitHubOwners().GetAllAsync().ToEnumerableAsync();
            var onboardedOwner = onboardedOwners.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.That(onboardedOwner.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedOwner.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedRepos = await onboardedOwner.GetSecurityConnectorGitHubRepositories().GetAllAsync().ToEnumerableAsync();
            var onboardedRepo = onboardedRepos.Where(project => project.Data.Name.Equals("TestApp0")).FirstOrDefault();

            Assert.That(onboardedRepo.HasData, Is.True);
            Assert.That(onboardedRepo.Data.Name, Is.EqualTo("TestApp0"));
            Assert.That(onboardedRepo.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitHub_GetAvailableGitHubOwners()
        {
            string connectorName = GitHubStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));

            var gitHubOwners = await devopsConfigurationResource.Value.GetAvailableGitHubOwnersAsync().ToEnumerableAsync();

            Assert.That(gitHubOwners.Count > 0, Is.True);
            Assert.That(gitHubOwners.FirstOrDefault().HasData, Is.True);
            Assert.That(gitHubOwners.FirstOrDefault().Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitLab_Get()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Disabled));

            var onboardedGroup = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetAsync("dfdsdktests");

            Assert.That(onboardedGroup.Value.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedGroup.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedProject = await onboardedGroup.Value.GetSecurityConnectorGitLabProjects().GetAsync("testapp0");
            Assert.That(onboardedProject.Value.HasData, Is.True);
            Assert.That(onboardedProject.Value.Data.Name, Is.EqualTo("testapp0"));
            Assert.That(onboardedProject.Value.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitLab_GetAll()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));
            Assert.That(devopsConfigurationResource.Value.Data.Properties.AutoDiscovery, Is.EqualTo(DevOpsAutoDiscovery.Disabled));

            var onboardedGroups = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetAllAsync().ToEnumerableAsync();
            var onboardedGroup = onboardedGroups.Where(org => org.Data.Name.Equals("dfdsdktests")).FirstOrDefault();

            Assert.That(onboardedGroup.Data.Name, Is.EqualTo("dfdsdktests"));
            Assert.That(onboardedGroup.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));

            var onboardedProjects = await onboardedGroup.GetSecurityConnectorGitLabProjects().GetAllAsync().ToEnumerableAsync();
            var onboardedProject = onboardedProjects.Where(project => project.Data.Name.Equals("testapp0")).FirstOrDefault();

            Assert.That(onboardedProject.HasData, Is.True);
            Assert.That(onboardedProject.Data.Name, Is.EqualTo("testapp0"));
            Assert.That(onboardedProject.Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitLab_GetAvailableGitLabGroupsAsync()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));

            var gitLabGroups = await devopsConfigurationResource.Value.GetAvailableGitLabGroupsAsync().ToEnumerableAsync();

            Assert.That(gitLabGroups.Count > 0, Is.True);
            Assert.That(gitLabGroups.FirstOrDefault().HasData, Is.True);
            Assert.That(gitLabGroups.FirstOrDefault().Data.Properties.OnboardingState, Is.EqualTo(ResourceOnboardingState.Onboarded));
        }

        [RecordedTest]
        public async Task GitLab_GetGitLabSubgroupsAsync()
        {
            string connectorName = GitLabStaticConnectorName;

            var securityConnectorResponse = await _defaultResourceGroup.GetSecurityConnectors().GetAsync(connectorName);

            Assert.IsNotNull(securityConnectorResponse);

            // setup devops
            var devopsConfigurationResource = await securityConnectorResponse.Value.GetDevOpsConfiguration().GetAsync();

            Assert.That(devopsConfigurationResource.Value.HasData, Is.True);
            Assert.That(devopsConfigurationResource.Value.Data.Properties.ProvisioningState, Is.EqualTo(DevOpsProvisioningState.Succeeded));

            var onboardedSubGroups = await devopsConfigurationResource.Value.GetSecurityConnectorGitLabGroups().GetGitLabSubgroupsAsync("dfdsdktests").ToEnumerableAsync();

            Assert.That(onboardedSubGroups.Count, Is.EqualTo(2));

            var testSubgroup = onboardedSubGroups.Where(s => s.Data?.Properties?.FullyQualifiedName?.Contains("testsubgroupNested") == true).FirstOrDefault();
            Assert.IsNotNull(testSubgroup);
            Assert.That(testSubgroup.Data.Properties.FullyQualifiedName, Is.EqualTo("dfdsdktests$testsubgroup1$testsubgroupNested"));
        }
    }
}
