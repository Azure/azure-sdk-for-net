// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class LiveDeploymentTests : ResourceOperationsTestsBase
    {
        public LiveDeploymentTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private const string DummyTemplateUri = "https://testtemplates.blob.core.windows.net/templates/dummytemplate.js";
        private const string GoodWebsiteTemplateUri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/201-web-app-github-deploy/azuredeploy.json";
        private const string BadTemplateUri = "https://testtemplates.blob.core.windows.net/templates/bad-website-1.js";
        private const string LocationWestEurope = "West Europe";
        private const string LocationSouthCentralUS = "South Central US";

        [Test]
        public async Task CreateDeploymentWithStringTemplateAndParameters()
        {
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "simple-storage-account.json"));
            var parameterString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "simple-storage-account-parameters.json"));

            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(parameterString);
            if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
            {
                parameter = jsonParameter;
            }

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    ParametersJson = parameter
                }
             );

            string groupName = Recording.GenerateAssetName("csmrg");
            string deploymentName = Recording.GenerateAssetName("csmd");
            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(LiveDeploymentTests.LocationWestEurope));
            var rawResult = await DeploymentsOperations.StartCreateOrUpdateAsync(groupName, deploymentName, parameters);
            await WaitForCompletionAsync(rawResult);

            var deployment = (await DeploymentsOperations.GetAsync(groupName, deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
        }

        [Test]
        public async Task CreateDeploymentAndValidateProperties()
        {
            string resourceName = Recording.GenerateAssetName("csmr");

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink(GoodWebsiteTemplateUri),
                    Parameters =
                    (@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}").Replace("'", "\"")
                }
            ){
                Tags = { { "tagKey1", "tagValue1" } }
            };
            string groupName = Recording.GenerateAssetName("csmrg");
            string deploymentName = Recording.GenerateAssetName("csmd");
            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(LiveDeploymentTests.LocationWestEurope));
            var rawResult = await DeploymentsOperations.StartCreateOrUpdateAsync(groupName, deploymentName, parameters);
            var deploymentCreateResult = (await WaitForCompletionAsync(rawResult)).Value;

            Assert.NotNull(deploymentCreateResult.Id);
            Assert.AreEqual(deploymentName, deploymentCreateResult.Name);

            if (Mode == RecordedTestMode.Record) Thread.Sleep(1*1000);

            var deploymentListResult = await DeploymentsOperations.ListByResourceGroupAsync(groupName, null).ToEnumerableAsync();
            var deploymentGetResult = (await DeploymentsOperations.GetAsync(groupName, deploymentName)).Value;

            Assert.IsNotEmpty(deploymentListResult);
            Assert.AreEqual(deploymentName, deploymentGetResult.Name);
            Assert.AreEqual(deploymentName, deploymentListResult.First().Name);
            Assert.AreEqual(GoodWebsiteTemplateUri, deploymentGetResult.Properties.TemplateLink.Uri);
            Assert.AreEqual(GoodWebsiteTemplateUri, deploymentListResult.First().Properties.TemplateLink.Uri);
            Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
            Assert.NotNull(deploymentListResult.First().Properties.ProvisioningState);
            Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
            Assert.NotNull(deploymentListResult.First().Properties.CorrelationId);
            Assert.NotNull(deploymentListResult.First().Tags);
            Assert.True(deploymentListResult.First().Tags.ContainsKey("tagKey1"));
        }

        [Test]
        public async Task ValidateGoodDeployment()
        {
            string groupName = Recording.GenerateAssetName("csmrg");
            string deploymentName = Recording.GenerateAssetName("csmd");
            string resourceName = Recording.GenerateAssetName("csres");

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink(GoodWebsiteTemplateUri),
                    Parameters = (@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}").Replace("'", "\"")
                }
            );

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(LiveDeploymentTests.LocationWestEurope));

            //Action
            var rawValidationResult = await DeploymentsOperations.StartValidateAsync(groupName, deploymentName, parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);
            Assert.AreEqual(1, validationResult.Properties.Providers.Count);
            Assert.AreEqual("Microsoft.Web", validationResult.Properties.Providers[0].Namespace);
        }

        [Test]
        public async Task ValidateBadDeployment()
        {
            string groupName = Recording.GenerateAssetName("csmrg");
            string deploymentName = Recording.GenerateAssetName("csmd");
            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink(BadTemplateUri),
                    Parameters = @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}".Replace("'", "\"")
                }
            );

            // TODO
            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(LiveDeploymentTests.LocationWestEurope));
            try
            {
                var rawResult = await DeploymentsOperations.StartValidateAsync(groupName, deploymentName, parameters);
                var result = (await WaitForCompletionAsync(rawResult)).Value;
                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("InvalidTemplate"));
            }
        }

        [Test]
        public async Task CreateLargeWebDeploymentTemplateWorks()
        {
            string resourceName = Recording.GenerateAssetName("csmr");
            string groupName = Recording.GenerateAssetName("csmrg");
            string deploymentName = Recording.GenerateAssetName("csmd");

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    TemplateLink = new TemplateLink(GoodWebsiteTemplateUri),
                    Parameters = ("{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}").Replace("'", "\"")
                }
            );

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup(LiveDeploymentTests.LocationSouthCentralUS));
            await DeploymentsOperations.StartCreateOrUpdateAsync(groupName, deploymentName, parameters);

            // Wait until deployment completes
            if (Mode == RecordedTestMode.Record) Thread.Sleep(30*1000);
            var operations = await DeploymentOperations.ListAsync(groupName, deploymentName, null).ToEnumerableAsync();

            Assert.True(operations.Any());
        }

        [Test]
        public async Task SubscriptionLevelDeployment()
        {
            string groupName = "SDK-test";
            string deploymentName = Recording.GenerateAssetName("csmd");
            string resourceName = Recording.GenerateAssetName("csmr");
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "subscription_level_template.json"));

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = "{'storageAccountName': {'value': 'armbuilddemo1803'}}".Replace("'", "\"")
                }
            ){
                Location = "WestUS",
                Tags = { { "tagKey1", "tagValue1" } }
            };

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup("WestUS"));

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtSubscriptionScopeAsync(deploymentName, parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var rawDeploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtSubscriptionScopeAsync(deploymentName, parameters);
            await WaitForCompletionAsync(rawDeploymentResult);

            var deployment = (await DeploymentsOperations.GetAtSubscriptionScopeAsync(deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));
        }

        [Test]
        public async Task ManagementGroupLevelDeployment()
        {
            string groupId = "tag-mg1";
            string deploymentName = Recording.GenerateAssetName("csharpsdktest");
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "management_group_level_template.json"));

            var parameters = new ScopedDeployment
            (
                "East US",
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = "{'storageAccountName': {'value': 'tagsa021921'}}".Replace("'", "\"")
                }
            ){
                Tags = { { "tagKey1", "tagValue1" } }
            };

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtManagementGroupScopeAsync(groupId, deploymentName, parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtManagementGroupScopeAsync(groupId, deploymentName, parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtManagementGroupScopeAsync(groupId, deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));
        }

        [Test]
        [Ignore("Need to resord with tenant access client")]
        public async Task TenantLevelDeployment()
        {
            string deploymentName = Recording.GenerateAssetName("csharpsdktest");
            var templateString  = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "tenant_level_template.json"));

            var parameters = new ScopedDeployment
            (
                "East US 2",
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = "{'managementGroupId': {'value': 'tiano-mgtest01'}}".Replace("'", "\"")
                }
            ){
                Tags = { { "tagKey1", "tagValue1" } }
            };

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtTenantScopeAsync(deploymentName, parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtTenantScopeAsync(deploymentName, parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtTenantScopeAsync(deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));

            var deploymentOperations = await DeploymentOperations.ListAtTenantScopeAsync(deploymentName).ToEnumerableAsync();
            Assert.AreEqual(4, deploymentOperations.Count());
        }

        [Test]
        [Ignore("Need to resord with tenant access client")]
        public async Task DeploymentWithScope_AtTenant()
        {
            string deploymentName = Recording.GenerateAssetName("csharpsdktest");
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "tenant_level_template.json"));

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = "{'managementGroupId': {'value': 'tiano-mgtest01'}}".Replace("'", "\"")
                }
            ){
                Location = "East US 2",
                Tags = { { "tagKey1", "tagValue1" } }
            };

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtScopeAsync(scope: "", deploymentName: deploymentName, parameters: parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtScopeAsync(scope: "", deploymentName: deploymentName, parameters: parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtScopeAsync(scope: "", deploymentName: deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));

            var deploymentOperations = await DeploymentOperations.ListAtScopeAsync(scope: "", deploymentName: deploymentName).ToEnumerableAsync();
            Assert.AreEqual(4, deploymentOperations.Count());
        }

        [Test]
        public async Task DeploymentWithScope_AtManagementGroup()
        {
            string groupId = "tag-mg1";
            string deploymentName = Recording.GenerateAssetName("csharpsdktest");
            string accountName = Recording.GenerateAssetName("tagsa");
            var templateString =
File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "management_group_level_template.json"));

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = ("{'storageAccountName': {'value': '"+ accountName+ "'}}").Replace("'", "\"")
                }
            ){
                Location = "East US",
                Tags = { { "tagKey1", "tagValue1" } }
            };

            var managementGroupScope = $"//providers/Microsoft.Management/managementGroups/{groupId}";

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtScopeAsync(scope: managementGroupScope, deploymentName: deploymentName, parameters: parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtScopeAsync(scope: managementGroupScope, deploymentName: deploymentName, parameters: parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtScopeAsync(scope: managementGroupScope, deploymentName: deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));

            var deploymentOperations = await DeploymentOperations.ListAtScopeAsync(scope: managementGroupScope, deploymentName: deploymentName).ToEnumerableAsync();
            Assert.AreEqual(4, deploymentOperations.Count());
        }

        [Test]
        public async Task DeploymentWithScope_AtSubscription()
        {
            string groupName = "SDK-test";
            string deploymentName = Recording.GenerateAssetName("csmd");
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "subscription_level_template.json"));

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = "{'storageAccountName': {'value': 'armbuilddemo1803'}}".Replace("'", "\"")
                }
            ){
                Location = "WestUS",
                Tags = { { "tagKey1", "tagValue1" } }
            };

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup("WestUS"));

            var subscriptionScope = $"//subscriptions/{TestEnvironment.SubscriptionId}";

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtScopeAsync(scope: subscriptionScope, deploymentName: deploymentName, parameters: parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtScopeAsync(scope: subscriptionScope, deploymentName: deploymentName, parameters: parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtScopeAsync(scope: subscriptionScope, deploymentName: deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));

            var deploymentOperations = await DeploymentOperations.ListAtScopeAsync(scope: subscriptionScope, deploymentName: deploymentName).ToEnumerableAsync();
            Assert.AreEqual(4, deploymentOperations.Count());
        }

        [Test]
        public async Task DeploymentWithScope_AtResourceGroup()
        {
            string groupName = "SDK-test-01";
            string deploymentName = Recording.GenerateAssetName("csmd");
            string accountName = Recording.GenerateAssetName("sdktestaccount");
            var templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ScenarioTests", "simple-storage-account.json"));

            var parameters = new Deployment
            (
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = templateString,
                    Parameters = ("{'storageAccountName': {'value': '"+ accountName + "'}}").Replace("'", "\"")
                }
            ){
                Tags = { { "tagKey1", "tagValue1" } }
            };

            await ResourceGroupsOperations.CreateOrUpdateAsync(groupName, new ResourceGroup("WestUS"));

            var resourceGroupScope = $"//subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{groupName}";

            //Validate
            var rawValidationResult = await DeploymentsOperations.StartValidateAtScopeAsync(scope: resourceGroupScope, deploymentName: deploymentName, parameters: parameters);
            var validationResult = (await WaitForCompletionAsync(rawValidationResult)).Value;

            //Assert
            Assert.Null(validationResult.Error);
            Assert.NotNull(validationResult.Properties);
            Assert.NotNull(validationResult.Properties.Providers);

            //Put deployment
            var deploymentResult = await DeploymentsOperations.StartCreateOrUpdateAtScopeAsync(scope: resourceGroupScope, deploymentName: deploymentName, parameters: parameters);
            await WaitForCompletionAsync(deploymentResult);

            var deployment = (await DeploymentsOperations.GetAtScopeAsync(scope: resourceGroupScope, deploymentName: deploymentName)).Value;
            Assert.AreEqual("Succeeded", deployment.Properties.ProvisioningState);
            Assert.NotNull(deployment.Tags);
            Assert.True(deployment.Tags.ContainsKey("tagKey1"));

            var deploymentOperations = await DeploymentOperations.ListAtScopeAsync(scope: resourceGroupScope, deploymentName: deploymentName).ToEnumerableAsync();
            Assert.AreEqual(2, deploymentOperations.Count());
        }
    }
}
