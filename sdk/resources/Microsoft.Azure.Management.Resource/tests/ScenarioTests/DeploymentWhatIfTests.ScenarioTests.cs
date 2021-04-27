// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ResourceGroups.Tests
{
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Test;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class LiveDeploymentWhatIfTests : TestBase
    {
        private static readonly ResourceGroup ResourceGroup = new ResourceGroup("westus");

        private static readonly string BlankTemplate = LoadTemplateContent("blank_template.json");

        private static readonly string ResourceGroupTemplate = LoadTemplateContent("simple-storage-account.json");

        private static readonly string ResourceGroupTemplateParameters = LoadTemplateContent("simple-storage-account-parameters.json");

        private static readonly string SubscriptionTemplate = LoadTemplateContent("subscription_level_template.json");

        private static readonly string ManagementGroupTemplate = LoadTemplateContent("management_group_level_template.json");

        private static readonly string ManagementGroupTemplateParameters = LoadTemplateContent("management_group_level_template.parameters.json");

        private static readonly string TenantTemplate = LoadTemplateContent("tenant_level_template.json");

        [Fact]
        public void WhatIf_BlankTemplate_ReturnsNoChange()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
                    }
                };

                string resourceGroupName = NewResourceGroupName();
                string deploymentName = NewDeploymentName();

                client.ResourceGroups.CreateOrUpdate(resourceGroupName, ResourceGroup);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIf(resourceGroupName, deploymentName, deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Empty(result.Changes);
            }
        }

        [Fact]
        public void WhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ResourceGroupTemplate,
                        Parameters = ResourceGroupTemplateParameters,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                string resourceGroupName = NewResourceGroupName();
                string deploymentName = NewDeploymentName();

                client.ResourceGroups.CreateOrUpdate(resourceGroupName, ResourceGroup);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIf(resourceGroupName, deploymentName, deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.Equal(ChangeType.Create, change.ChangeType);
                    Assert.Null(change.Before);
                    Assert.Null(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        [Fact]
        public void WhatIf_CreateResources_ReturnsCreateChanges()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ResourceGroupTemplate,
                        Parameters = ResourceGroupTemplateParameters,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                string resourceGroupName = NewResourceGroupName();
                string deploymentName = NewDeploymentName();

                client.ResourceGroups.CreateOrUpdate(resourceGroupName, ResourceGroup);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIf(resourceGroupName, deploymentName, deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change => Assert.Equal(ChangeType.Create, change.ChangeType));
            }
        }

        [Fact]
        public void WhatIf_ModifyResources_ReturnsModifyChanges()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);

                var deployment = new Deployment
                {
                    Properties = new DeploymentProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ResourceGroupTemplate,
                        Parameters = ResourceGroupTemplateParameters,
                    }
                };

                // Modify account type: Standard_LRS => Standard_GRS.
                JObject newTemplate = JObject.Parse(ResourceGroupTemplate);
                newTemplate["resources"][0]["properties"]["accountType"] = "Standard_GRS";

                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = newTemplate,
                        Parameters = ResourceGroupTemplateParameters,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
                    }
                };

                string resourceGroupName = NewResourceGroupName();

                client.ResourceGroups.CreateOrUpdate(resourceGroupName, ResourceGroup);
                client.Deployments.CreateOrUpdate(resourceGroupName, NewDeploymentName(), deployment);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIf(resourceGroupName, NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);

                WhatIfChange storageAccountChange = result.Changes.FirstOrDefault(change =>
                    change.ResourceId.EndsWith("Microsoft.Storage/storageAccounts/ramokaSATestAnother"));

                Assert.NotNull(storageAccountChange);
                Assert.Equal(ChangeType.Modify, storageAccountChange.ChangeType);

                Assert.NotNull(storageAccountChange.Delta);
                Assert.NotEmpty(storageAccountChange.Delta);

                WhatIfPropertyChange accountTypeChange = storageAccountChange.Delta
                    .FirstOrDefault(propertyChange => propertyChange.Path.Equals("properties.accountType"));

                Assert.NotNull(accountTypeChange);
                Assert.Equal("Standard_LRS", accountTypeChange.Before);
                Assert.Equal("Standard_GRS", accountTypeChange.After);
            }
        }

        [Fact]
        public void WhatIf_DeleteResources_ReturnsDeleteChanges()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);

                var deployment = new Deployment
                {
                    Properties = new DeploymentProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ResourceGroupTemplate,
                        Parameters = ResourceGroupTemplateParameters,
                    }
                };

                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Complete,
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                string resourceGroupName = NewResourceGroupName();

                client.ResourceGroups.CreateOrUpdate(resourceGroupName, ResourceGroup);
                client.Deployments.CreateOrUpdate(resourceGroupName, NewDeploymentName(), deployment);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIf(resourceGroupName, NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change => Assert.Equal(ChangeType.Delete, change.ChangeType));
            }
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_BlankTemplate_ReturnsNoChange()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtSubscriptionScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Empty(result.Changes);
            }
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = SubscriptionTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtSubscriptionScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                    Assert.Null(change.Before);
                    Assert.Null(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_CreateResources_ReturnsCreateChanges()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Location = "westus2",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = SubscriptionTemplate,
                        Parameters = JObject.Parse("{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}"),
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Use resource group name from the template.
                client.ResourceGroups.CreateOrUpdate("SDK-test", ResourceGroup);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtSubscriptionScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    if (change.ResourceId.EndsWith("SDK-test"))
                    {
                        Assert.Equal(ChangeType.Ignore, change.ChangeType);
                    }
                    else
                    {
                        Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                    }
                });
            }
        }

        [Fact]
        public void WhatIfAtSubscriptionScope_ModifyResources_ReturnsModifyChanges()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);

                var deployment = new Deployment
                {
                    Location = "westus2",
                    Properties = new DeploymentProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = SubscriptionTemplate,
                        Parameters = JObject.Parse("{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}"),
                    }
                };

                // Change "northeurope" to "westeurope".
                JObject newTemplate = JObject.Parse(SubscriptionTemplate);
                newTemplate["resources"][0]["properties"]["policyRule"]["if"]["equals"] = "westeurope";

                var deploymentWhatIf = new DeploymentWhatIf
                {
                    Location = "westus2",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = newTemplate,
                        Parameters = JObject.Parse("{ 'storageAccountName': {'value': 'whatifnetsdktest1'}}"),
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
                    }
                };

                client.ResourceGroups.CreateOrUpdate("SDK-test", ResourceGroup);
                client.Deployments.CreateOrUpdateAtSubscriptionScope(NewDeploymentName(), deployment);

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtSubscriptionScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);

                WhatIfChange policyChange = result.Changes.FirstOrDefault(change =>
                    change.ResourceId.EndsWith("Microsoft.Authorization/policyDefinitions/policy2"));

                Assert.NotNull(policyChange);
                Assert.True(policyChange.ChangeType == ChangeType.Deploy ||
                            policyChange.ChangeType == ChangeType.Modify);
                Assert.NotNull(policyChange.Delta);
                Assert.NotEmpty(policyChange.Delta);

                WhatIfPropertyChange policyRuleChange = policyChange.Delta
                    .FirstOrDefault(propertyChange => propertyChange.Path.Equals("properties.policyRule.if.equals"));

                Assert.NotNull(policyRuleChange);
                Assert.Equal(PropertyChangeType.Modify, policyRuleChange.PropertyChangeType);
                Assert.Equal("northeurope", policyRuleChange.Before);
                Assert.Equal("westeurope", policyRuleChange.After);
            }
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_BlankTemplate_ReturnsNoChange()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtManagementGroupScope("tag-mg-sdk", NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Empty(result.Changes);
            }
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ManagementGroupTemplate,
                        Parameters = ManagementGroupTemplateParameters,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtManagementGroupScope("tag-mg-sdk", NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                    Assert.Null(change.Before);
                    Assert.Null(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        [Fact]
        public void WhatIfAtManagementGroupScope_FullResourcePayloadMode_ReturnsChangesWithPayloads()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = ManagementGroupTemplate,
                        Parameters = ManagementGroupTemplateParameters,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtManagementGroupScope("tag-mg-sdk", NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                    Assert.Null(change.Before);
                    Assert.NotNull(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        [Fact]
        public void WhatIfAtTenantScope_BlankTemplate_ReturnsNoChange()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = BlankTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtTenantScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.Empty(result.Changes);
            }
        }

        [Fact]
        public void WhatIfAtTenantScope_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = TenantTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.ResourceIdOnly)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtTenantScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.True(change.ChangeType == ChangeType.Deploy || change.ChangeType == ChangeType.Create);
                    Assert.Null(change.Before);
                    Assert.Null(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        [Fact]
        public void WhatIfAtTenantScope_FullResourcePayloadMode_ReturnsChangesWithPayloads()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Arrange.
                ResourceManagementClient client = this.GetResourceManagementClient(context);
                var deploymentWhatIf = new ScopedDeploymentWhatIf
                {
                    Location = "westus",
                    Properties = new DeploymentWhatIfProperties
                    {
                        Mode = DeploymentMode.Incremental,
                        Template = TenantTemplate,
                        WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
                    }
                };

                // Act.
                WhatIfOperationResult result = client.Deployments
                    .WhatIfAtTenantScope(NewDeploymentName(), deploymentWhatIf);

                // Assert.
                Assert.Equal("Succeeded", result.Status);
                Assert.NotNull(result.Changes);
                Assert.NotEmpty(result.Changes);
                result.Changes.ForEach(change =>
                {
                    Assert.NotNull(change.ResourceId);
                    Assert.NotEmpty(change.ResourceId);
                    Assert.True(change.ChangeType == ChangeType.Create);
                    Assert.Null(change.Before);
                    Assert.NotNull(change.After);
                    Assert.Null(change.Delta);
                });
            }
        }

        private static string LoadTemplateContent(string filePath)
            => File.ReadAllText(Path.Combine("ScenarioTests", filePath));

        private static string NewResourceGroupName() => TestUtilities.GenerateName("csmrg");

        private static string NewDeploymentName() => TestUtilities.GenerateName("csmd");
    }
}
