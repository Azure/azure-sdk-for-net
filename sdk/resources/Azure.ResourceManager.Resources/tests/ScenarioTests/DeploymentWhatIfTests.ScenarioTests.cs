// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests.ScenarioTests
{
    public class LiveDeploymentWhatIfTests : ResourceOperationsTestsBase
    {
        private static readonly ResourceGroup ResourceGroup = new ResourceGroup("westus");

        private static readonly string BlankTemplate = TemplateLoader.LoadTemplateContents("blank_template");

        private static readonly string ResourceGroupTemplate = TemplateLoader.LoadTemplateContents("simple-storage-account");

        private static readonly string ResourceGroupTemplateGRS = TemplateLoader.LoadTemplateContents("simple-storage-account-GRS");

        private static readonly string ResourceGroupTemplateParameters = TemplateLoader.LoadTemplateContents("simple-storage-account-parameters");

        private static readonly string SubscriptionTemplate = TemplateLoader.LoadTemplateContents("subscription_level_template");

        private static readonly string SubscriptionTemplateWestEurope = TemplateLoader.LoadTemplateContents("subscription_level_template_westeurope");

        public LiveDeploymentWhatIfTests(bool isAsync)
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

        [Test]
        public async Task WhatIf_BlankTemplate_ReturnsNoChange()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                    {
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings()
                        {
                            ResultFormat = WhatIfResultFormat.FullResourcePayloads
                        }
                    }
                );

            string resourceGroupName = NewResourceGroupName();
            string deploymentName = NewDeploymentName();

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, ResourceGroup)).Value;

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAsync(resourceGroupName, deploymentName, deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsEmpty(result.Changes);
        }

        [Test]
        public async Task WhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            // Arrange.
            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(ResourceGroupTemplateParameters);
            if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
            {
                parameter = jsonParameter;
            }

            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = ResourceGroupTemplate,
                    ParametersJson = parameter,
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.ResourceIdOnly
                    }
                }
                );

            string resourceGroupName = NewResourceGroupName();
            string deploymentName = NewDeploymentName();

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, ResourceGroup)).Value;

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAsync(resourceGroupName, deploymentName, deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);

            foreach (var change in result.Changes)
            {
                Assert.NotNull(change.ResourceId);
                Assert.IsNotEmpty(change.ResourceId);
                Assert.AreEqual(ChangeType.Create, change.ChangeType);
                Assert.Null(change.Before);
                Assert.Null(change.After);
                Assert.IsEmpty(change.Delta);
            }
        }
        [Test]
        public async Task WhatIf_CreateResources_ReturnsCreateChanges()
        {
            // Arrange.
            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(ResourceGroupTemplateParameters);
            if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
            {
                parameter = jsonParameter;
            }

            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                    {
                        Template = ResourceGroupTemplate,
                        ParametersJson = parameter,
                        WhatIfSettings = new DeploymentWhatIfSettings()
                        {
                            ResultFormat = WhatIfResultFormat.ResourceIdOnly
                        }
                    }
                );

            string resourceGroupName = NewResourceGroupName();
            string deploymentName = NewDeploymentName();

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, ResourceGroup)).Value;

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAsync(resourceGroupName, deploymentName, deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);
            foreach (var change in result.Changes)
            {
                Assert.AreEqual(ChangeType.Create, change.ChangeType);
            }
        }

        [Test]
        public async Task WhatIf_ModifyResources_ReturnsModifyChanges()
        {
            // Arrange.
            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(ResourceGroupTemplateParameters);
            if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
            {
                parameter = jsonParameter;
            }

            var deployment = new Deployment(new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = ResourceGroupTemplate,
                ParametersJson = parameter
            });

            // Modify account type: Standard_LRS => Standard_GRS.
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = ResourceGroupTemplateGRS,
                    ParametersJson = parameter,
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.FullResourcePayloads
                    }
                }
                );

            string resourceGroupName = NewResourceGroupName();

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, ResourceGroup)).Value;
            var deploy = await DeploymentsOperations.StartCreateOrUpdateAsync(resourceGroupName, NewDeploymentName(), deployment);
            await WaitForCompletionAsync(deploy);

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAsync(resourceGroupName, NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);

            WhatIfChange storageAccountChange = result.Changes.FirstOrDefault(change =>
                change.ResourceId.EndsWith("Microsoft.Storage/storageAccounts/ramokaSATestAnother1"));

            Assert.NotNull(storageAccountChange);
            Assert.AreEqual(ChangeType.Modify, storageAccountChange.ChangeType);

            Assert.NotNull(storageAccountChange.Delta);
            Assert.IsNotEmpty(storageAccountChange.Delta);

            WhatIfPropertyChange accountTypeChange = storageAccountChange.Delta
                .FirstOrDefault(propertyChange => propertyChange.Path.Equals("properties.accountType"));

            Assert.NotNull(accountTypeChange);
            Assert.AreEqual("Standard_LRS", accountTypeChange.Before);
            Assert.AreEqual("Standard_GRS", accountTypeChange.After);
        }

        [Test]
        public async Task WhatIf_DeleteResources_ReturnsDeleteChanges()
        {
            // Arrange.
            JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(ResourceGroupTemplateParameters);
            if (!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
            {
                parameter = jsonParameter;
            }

            var deployment = new Deployment(new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = ResourceGroupTemplate,
                ParametersJson = parameter
            });
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Complete)
                {
                    Template = BlankTemplate,
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.ResourceIdOnly
                    }
                }
                );

            string resourceGroupName = NewResourceGroupName();

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, ResourceGroup)).Value;
            var deploy = await DeploymentsOperations.StartCreateOrUpdateAsync(resourceGroupName, NewDeploymentName(), deployment);
            await WaitForCompletionAsync(deploy);

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAsync(resourceGroupName, NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);
            foreach (var change in result.Changes)
            {
                Assert.AreEqual(ChangeType.Delete, change.ChangeType);
            }
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_BlankTemplate_ReturnsNoChange()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = BlankTemplate,
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.ResourceIdOnly
                    }
                }
                )
            { Location = "westus" };
            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAtSubscriptionScopeAsync(NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsEmpty(result.Changes);
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = SubscriptionTemplate,
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.ResourceIdOnly
                    }
                }
                )
            { Location = "westus" };

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAtSubscriptionScopeAsync(NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);
            foreach (var change in result.Changes)
            {
                Assert.NotNull(change.ResourceId);
                Assert.IsNotEmpty(change.ResourceId);
                Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                Assert.Null(change.Before);
                Assert.Null(change.After);
                Assert.IsEmpty(change.Delta);
            }
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_CreateResources_ReturnsCreateChanges()
        {
            // Arrange.
            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = SubscriptionTemplate,
                    Parameters = "{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}".Replace("'", "\""),
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.ResourceIdOnly
                    }
                }
                )
            { Location = "westus2" };

            // Use resource group name from the template.
            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync("SDK-test", ResourceGroup)).Value;

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAtSubscriptionScopeAsync(NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);
            foreach (var change in result.Changes)
            {
                if (change.ResourceId.EndsWith("SDK-test"))
                {
                    Assert.AreEqual(ChangeType.Ignore, change.ChangeType);
                }
                else
                {
                    Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                }
            }
        }

        [Test]
        public async Task WhatIfAtSubscriptionScope_ModifyResources_ReturnsModifyChanges()
        {
            // Arrange.
            var deployment = new Deployment(
                new DeploymentProperties(DeploymentMode.Incremental)
                {
                    Template = SubscriptionTemplate,
                    Parameters = "{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}".Replace("'", "\"")
                }) {
                Location = "westus2"
            };

            var deploymentWhatIf = new DeploymentWhatIf(
                new DeploymentWhatIfProperties(DeploymentMode.Incremental)
                {
                    Template = SubscriptionTemplateWestEurope,
                    Parameters = "{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}".Replace("'", "\""),
                    WhatIfSettings = new DeploymentWhatIfSettings()
                    {
                        ResultFormat = WhatIfResultFormat.FullResourcePayloads
                    }
                }
                )
            { Location = "westus2" };

            var resourcegroup = (await ResourceGroupsOperations.CreateOrUpdateAsync("SDK-test", ResourceGroup)).Value;
            var deploy = await DeploymentsOperations.StartCreateOrUpdateAtSubscriptionScopeAsync(NewDeploymentName(), deployment);
            await WaitForCompletionAsync(deploy);

            // Act.
            var rawResult = await DeploymentsOperations.StartWhatIfAtSubscriptionScopeAsync(NewDeploymentName(), deploymentWhatIf);
            var result = (await WaitForCompletionAsync(rawResult)).Value;

            // Assert.
            Assert.AreEqual("Succeeded", result.Status);
            Assert.NotNull(result.Changes);
            Assert.IsNotEmpty(result.Changes);

            WhatIfChange policyChange = result.Changes.FirstOrDefault(change =>
                change.ResourceId.EndsWith("Microsoft.Authorization/policyDefinitions/policy2"));

            Assert.NotNull(policyChange);
            Assert.True(policyChange.ChangeType == ChangeType.Deploy ||
                        policyChange.ChangeType == ChangeType.Modify);
            Assert.NotNull(policyChange.Delta);
            Assert.IsNotEmpty(policyChange.Delta);

            WhatIfPropertyChange policyRuleChange = policyChange.Delta
                .FirstOrDefault(propertyChange => propertyChange.Path.Equals("properties.policyRule.if.equals"));

            Assert.NotNull(policyRuleChange);
            Assert.AreEqual(PropertyChangeType.Modify, policyRuleChange.PropertyChangeType);
            Assert.AreEqual("northeurope", policyRuleChange.Before);
            Assert.AreEqual("westeurope", policyRuleChange.After);
        }

        private string NewResourceGroupName() => Recording.GenerateAssetName("csmd");

        private string NewDeploymentName() => Recording.GenerateAssetName("csmd");
    }
}
