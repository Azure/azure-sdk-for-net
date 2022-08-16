// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerRegistry.Tests
{
    public class ContainerRegistryTests : ContainerRegistryManagementTestBase
    {
        public ContainerRegistryTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameAvailability()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);

            // Check valid name
            string registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryNameAvailabilityContent content = new ContainerRegistryNameAvailabilityContent(registryName);
            ContainerRegistryNameAvailableResult result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.True(result.IsNameAvailable);
            Assert.Null(result.Reason);
            Assert.Null(result.Message);

            // Check disallowed name
            registryName = "Microsoft";
            content = new ContainerRegistryNameAvailabilityContent(registryName);
            result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.False(result.IsNameAvailable);
            Assert.AreEqual("Invalid", result.Reason);
            Assert.AreEqual("The specified resource name is disallowed.", result.Message);

            // Check name of container registry that already exists
            registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            content = new ContainerRegistryNameAvailabilityContent(registryName);
            result = await Subscription.CheckContainerRegistryNameAvailabilityAsync(content);
            Assert.False(result.IsNameAvailable);
            Assert.AreEqual("AlreadyExists", result.Reason);
            Assert.AreEqual("The registry " + registryName + " is already in use.", result.Message);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryCoreScenario()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);
            var registryCollection = rg.GetContainerRegistries();
            // Validate the created registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var registryData = registry.Data;
            ValidateResourceDefaultTags(registryData);
            Assert.NotNull(registryData.Sku);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryData.Sku.Name);
            Assert.AreEqual(ContainerRegistrySkuTier.Premium, registryData.Sku.Tier);

            Assert.NotNull(registryData.LoginServer);
            Assert.NotNull(registryData.CreatedOn);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, registryData.ProvisioningState);
            Assert.False(registryData.IsAdminUserEnabled);

            // List container registries by resource group
            var registryPages = registryCollection.GetAllAsync();
            ContainerRegistryResource registryFromList = await registryPages.FirstOrDefaultAsync(r => r.Data.Name.Equals(registryName, StringComparison.Ordinal));
            ValidateResourceDefaultTags(registryFromList.Data);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryFromList.Data.Sku.Name);

            // Get the container registry
            ContainerRegistryResource registryFromGet = await registryCollection.GetAsync(registryName);
            ValidateResourceDefaultTags(registryFromGet.Data);
            Assert.AreEqual(ContainerRegistrySkuName.Premium, registryFromGet.Data.Sku.Name);

            // Try to list credentials, should fail when admin user is disabled
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await registryFromGet.GetCredentialsAsync());
            Assert.AreEqual(400, ex.Status);

            // Update the container registry
            var registryPatch = new ContainerRegistryPatch()
            {
                Tags =
                {
                    { "key2","value2"},
                    { "key3","value3"},
                    { "key4","value4"}
                },
                IsAdminUserEnabled = true,
                Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Basic)
            };
            ContainerRegistryResource registryFromUpdate = (await registryFromGet.UpdateAsync(WaitUntil.Completed, registryPatch)).Value;
            // Validate the updated registry
            ValidateResourceDefaultNewTags(registryFromUpdate.Data);
            registryData = registryFromUpdate.Data;
            Assert.NotNull(registryData.Sku);
            Assert.AreEqual(ContainerRegistrySkuName.Basic, registryData.Sku.Name);
            Assert.AreEqual(ContainerRegistrySkuTier.Basic, registryData.Sku.Tier);

            Assert.NotNull(registryData.LoginServer);
            Assert.NotNull(registryData.CreatedOn);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, registryData.ProvisioningState);
            Assert.True(registryData.IsAdminUserEnabled);

            // List credentials
            ContainerRegistryListCredentialsResult credentials = await registryFromUpdate.GetCredentialsAsync();
            // Validate username and password
            Assert.NotNull(credentials);
            Assert.NotNull(credentials.Username);
            Assert.AreEqual(2, credentials.Passwords.Count);
            var password1 = credentials.Passwords[0].Value;
            var password2 = credentials.Passwords[1].Value;
            Assert.NotNull(password1);
            Assert.NotNull(password2);

            // Regenerate credential
            ContainerRegistryCredentialRegenerateContent credentialContent = new ContainerRegistryCredentialRegenerateContent(ContainerRegistryPasswordName.Password);
            credentials = await registryFromUpdate.RegenerateCredentialAsync(credentialContent);
            // Validate if generated password is different
            var newPassword1 = credentials.Passwords[0].Value;
            var newPassword2 = credentials.Passwords[1].Value;
            Assert.AreNotEqual(password1, newPassword1);
            Assert.AreEqual(password2, newPassword2);

            credentialContent = new ContainerRegistryCredentialRegenerateContent(ContainerRegistryPasswordName.Password2);
            credentials = await registryFromUpdate.RegenerateCredentialAsync(credentialContent);
            // Validate if generated password is different
            Assert.AreEqual(newPassword1, credentials.Passwords[0].Value);
            Assert.AreNotEqual(newPassword2, credentials.Passwords[1].Value);

            // Delete the container registry
            await registryFromUpdate.DeleteAsync(WaitUntil.Completed);

            // Delete the container registry again
            await registryFromUpdate.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryWebhook()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry and webhook
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var webhookName = Recording.GenerateAssetName("acrwebhook");
            ContainerRegistryWebhookResource webhook = await CreateContainerWebhookAsync(registry, webhookName);
            // Validate the created webhook
            var webhookData = webhook.Data;
            ValidateResourceDefaultTags(webhookData);
            Assert.AreEqual(ContainerRegistryWebhookStatus.Enabled, webhookData.Status);
            Assert.True(string.IsNullOrEmpty(webhookData.Scope));
            Assert.AreEqual(1, webhookData.Actions.Count);
            Assert.True(webhookData.Actions.Contains(ContainerRegistryWebhookAction.Push));
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, webhookData.ProvisioningState);

            // List webhooks by container registry
            var webhooks = registry.GetContainerRegistryWebhooks();
            var webhookPages = webhooks.GetAllAsync();
            ContainerRegistryWebhookResource webhookFromList = await webhookPages.FirstOrDefaultAsync(h => h.Data.Name.Equals(webhookName, StringComparison.Ordinal));
            ValidateResourceDefaultTags(webhookFromList.Data);

            // Get the webhook
            ContainerRegistryWebhookResource webhookFromGet = await webhooks.GetAsync(webhookName);
            ValidateResourceDefaultTags(webhookFromGet.Data);

            // Update the webhook
            var webhookPatch = new ContainerRegistryWebhookPatch()
            {
                Tags =
                {
                    { "key2","value2"},
                    { "key3","value3"},
                    { "key4","value4"}
                },
                Status = ContainerRegistryWebhookStatus.Disabled,
                Scope = DefaultWebhookScope,
                Actions =
                {
                    ContainerRegistryWebhookAction.Push,
                    ContainerRegistryWebhookAction.Delete
                },
                CustomHeaders =
                {
                    { "key", "value" }
                }
            };
            var webhookFromUpdate = (await webhookFromGet.UpdateAsync(WaitUntil.Completed, webhookPatch)).Value;

            // Validate the updated webhook
            var webhookDataFromUpdate = webhookFromUpdate.Data;
            ValidateResourceDefaultNewTags(webhookDataFromUpdate);
            Assert.AreEqual(ContainerRegistryWebhookStatus.Disabled, webhookDataFromUpdate.Status);
            Assert.AreEqual(DefaultWebhookScope, webhookDataFromUpdate.Scope);
            Assert.AreEqual(2, webhookDataFromUpdate.Actions.Count);
            Assert.True(webhookDataFromUpdate.Actions.Contains(ContainerRegistryWebhookAction.Push));
            Assert.True(webhookDataFromUpdate.Actions.Contains(ContainerRegistryWebhookAction.Delete));
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, webhookDataFromUpdate.ProvisioningState);

            // Get the webhook call back config
            ContainerRegistryWebhookCallbackConfig webhookConfig = await webhookFromUpdate.GetCallbackConfigAsync();
            Assert.NotNull(webhookConfig);
            Assert.AreEqual(DefaultWebhookServiceUri, webhookConfig.ServiceUri);
            Assert.AreEqual(1, webhookConfig.CustomHeaders.Count);
            Assert.AreEqual("value", webhookConfig.CustomHeaders["key"]);

            // Ping the webhook
            ContainerRegistryWebhookEventInfo eventInfo = await webhookFromUpdate.PingAsync();
            Assert.NotNull(eventInfo);
            Assert.NotNull(eventInfo.Id);

            //List webhook events
            var eventPages = webhookFromUpdate.GetEventsAsync();
            ContainerRegistryWebhookEvent eventFromList = await eventPages.FirstOrDefaultAsync(_ => true);
            Assert.NotNull(eventFromList);

            //Delete the webhook
            await webhookFromUpdate.DeleteAsync(WaitUntil.Completed);

            //Delete the webhook again
            await webhookFromUpdate.DeleteAsync(WaitUntil.Completed);

            //Delete the container registry
            await registry.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryReplication()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", AzureLocation.WestUS);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry and replication
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var replicationCollection = registry.GetContainerRegistryReplications();
            var replicationName = AzureLocation.EastUS.ToString();
            var lro = await replicationCollection.CreateOrUpdateAsync(WaitUntil.Completed, replicationName, new ContainerRegistryReplicationData(AzureLocation.EastUS)
            {
                Tags =
                {
                    { "key1", "value1"},
                    { "key2", "value2"}
                }
            });
            ContainerRegistryReplicationResource replication = lro.Value;
            // Validate the created replication
            var replicationData = replication.Data;
            ValidateResourceDefaultTags(replicationData);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, replicationData.ProvisioningState);
            Assert.NotNull(replicationData.Status);
            Assert.NotNull(replicationData.Status.DisplayStatus);
            // List replications by container registry
            var replicationPages = replicationCollection.GetAllAsync();
            var replicationCount = 0;
            await foreach (var replicationFromList in replicationPages)
            {
                if (replicationFromList.Data.Name.Equals(replicationName, StringComparison.Ordinal))
                {
                    ValidateResourceDefaultTags(replicationFromList.Data);
                    Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, replicationFromList.Data.ProvisioningState);
                    Assert.NotNull(replicationFromList.Data.Status);
                    Assert.NotNull(replicationFromList.Data.Status.DisplayStatus);
                }
                replicationCount++;
            }
            Assert.AreEqual(2, replicationCount);
            // Get the replication
            ContainerRegistryReplicationResource replicationFromGet = await replicationCollection.GetAsync(replicationName);
            ValidateResourceDefaultTags(replicationFromGet.Data);
            // Update the replication
            var replicationPatch = new ContainerRegistryReplicationPatch()
            {
                Tags =
                {
                    { "key2","value2"},
                    { "key3","value3"},
                    { "key4","value4"}
                }
            };
            var replicationFromUpdate = (await replicationFromGet.UpdateAsync(WaitUntil.Completed, replicationPatch)).Value;
            // Validate the updated replication
            var replicationDataFromUpdate = replicationFromUpdate.Data;
            ValidateResourceDefaultNewTags(replicationDataFromUpdate);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, replicationDataFromUpdate.ProvisioningState);
            Assert.NotNull(replicationDataFromUpdate.Status);
            Assert.NotNull(replicationDataFromUpdate.Status.DisplayStatus);
            // Delete the replication
            await replicationFromUpdate.DeleteAsync(WaitUntil.Completed);
            // Delete the replication again
            await replicationFromUpdate.DeleteAsync(WaitUntil.Completed);
            // Delete the container registry
            await registry.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryTask()
        {
            var location = AzureLocation.WestUS;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", location);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry and task
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            var taskCollection = registry.GetContainerRegistryTasks();
            var taskName = Recording.GenerateAssetName("acrtask");
            var data = new ContainerRegistryTaskData(location)
            {
                Platform = new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 },
                Step = new ContainerRegistryDockerBuildStep("Dockerfile")
                {
                    ContextPath = "https://github.com/azure/acr-builder.git",
                    ImageNames = { "image:{{.Run.ID}}", "image:latest" },
                    IsPushEnabled = true,
                    NoCache = true
                },
                AgentConfiguration = new ContainerRegistryAgentProperties() { Cpu = 2 },
                Status = ContainerRegistryTaskStatus.Enabled,
                TimeoutInSeconds = 600,
                Trigger = new ContainerRegistryTriggerProperties()
                {
                    BaseImageTrigger = new ContainerRegistryBaseImageTrigger(ContainerRegistryBaseImageTriggerType.Runtime, "defaultBaseimageTriggerName")
                    {
                        Status = ContainerRegistryTriggerStatus.Enabled
                    }
                }
            };
            var lro = await taskCollection.CreateOrUpdateAsync(WaitUntil.Completed, taskName, data);
            ContainerRegistryTaskResource task = lro.Value;
            Assert.NotNull(task);
            Assert.AreEqual(taskName, task.Data.Name);
            Assert.AreEqual(ContainerRegistryProvisioningState.Succeeded, task.Data.ProvisioningState);
            Assert.AreEqual(ContainerRegistryTaskStatus.Enabled, task.Data.Status);
            // List tasks
            var taskCount = 0;
            await foreach (var taskInList in taskCollection)
            {
                taskCount++;
                Assert.AreEqual(taskName, taskInList.Data.Name);
            }
            Assert.AreEqual(1, taskCount);
            // Update the task
            lro = await task.UpdateAsync(WaitUntil.Completed, new ContainerRegistryTaskPatch()
            {
                TimeoutInSeconds = 900
            });
            ContainerRegistryTaskResource taskFromUpdate = lro.Value;
            Assert.AreEqual(900, taskFromUpdate.Data.TimeoutInSeconds);
            // Schedule a run from task
            var runLro = await registry.ScheduleRunAsync(WaitUntil.Completed, new ContainerRegistryTaskRunContent(taskFromUpdate.Data.Id)
            {
                OverrideTaskStepProperties = new ContainerRegistryOverrideTaskStepProperties()
                {
                    Values =
                    {
                        new ContainerRegistryTaskOverridableValue("key1", "value1"),
                        new ContainerRegistryTaskOverridableValue("key2", "value2"){ IsSecret = true }
                    }
                }
            });
            ContainerRegistryRunResource run1 = runLro.Value;
            Assert.AreEqual("cf1", run1.Data.RunId);
            // Cancel the run
            await run1.CancelAsync(WaitUntil.Completed);
            // Schedule a docker build run
            runLro = await registry.ScheduleRunAsync(WaitUntil.Completed, new ContainerRegistryDockerBuildContent("DockerFile", new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 })
            {
                IsArchiveEnabled = false,
                ImageNames = { "testimage1:tag1", "testimage2:tag2" },
                IsPushEnabled = false,
                NoCache = true,
                Arguments = { new ContainerRegistryRunArgument("param1", "value1") { IsSecret = true } },
                TimeoutInSeconds = 600,
                AgentConfiguration = new ContainerRegistryAgentProperties() { Cpu = 2 },
                SourceLocation = "https://github.com/azure/acr-builder.git"
            });
            ContainerRegistryRunResource run2 = runLro.Value;
            Assert.AreEqual("cf2", run2.Data.RunId);
            // Schedule a file based task run
            runLro = await registry.ScheduleRunAsync(WaitUntil.Completed, new ContainerRegistryFileTaskRunContent("abc.yaml", new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 })
            {
                IsArchiveEnabled = false,
                Values =
                {
                    new ContainerRegistryTaskOverridableValue("key1", "value1"),
                    new ContainerRegistryTaskOverridableValue("key2", "value2"){ IsSecret = true }
                },
                TimeoutInSeconds = 600,
                AgentConfiguration = new ContainerRegistryAgentProperties() { Cpu = 2 },
                SourceLocation = "https://github.com/azure/acr-builder.git"
            });
            ContainerRegistryRunResource run3 = runLro.Value;
            Assert.AreEqual("cf3", run3.Data.RunId);
            // Schedule an encoded task run
            string taskString =
@"
steps:
  - build: . -t acb:linux-{{.Run.ID}}".Replace("\r\n", "\n");
            string valuesString =
@"
key1: value1
key2: value2
".Replace("\r\n", "\n");
            runLro = await registry.ScheduleRunAsync(WaitUntil.Completed, new ContainerRegistryEncodedTaskRunContent(Convert.ToBase64String(Encoding.UTF8.GetBytes(taskString)), new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 })
            {
                IsArchiveEnabled = false,
                EncodedValuesContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(valuesString)),
                TimeoutInSeconds = 600,
                AgentConfiguration = new ContainerRegistryAgentProperties() { Cpu = 2 },
                SourceLocation = "https://github.com/azure/acr-builder.git"
            });
            ContainerRegistryRunResource run4 = runLro.Value;
            Assert.AreEqual("cf4", run4.Data.RunId);
            // List runs
            var runCount = 0;
            await foreach (var run in registry.GetContainerRegistryRuns())
            {
                runCount++;
            }
            Assert.AreEqual(4, runCount);
            // Delete the task
            await taskFromUpdate.DeleteAsync(WaitUntil.Completed);
            // Delete the registry
            await registry.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryAgentPool()
        {
            AzureLocation location = AzureLocation.EastUS;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", location);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            // Crete a new agentpool
            var agentPoolCollection = registry.GetContainerRegistryAgentPools();
            var agentPoolName = Recording.GenerateAssetName("acrap");
            var lro = await agentPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, agentPoolName, new ContainerRegistryAgentPoolData(location)
            {
                Count = 1,
                Tier = "S2",
                OS = ContainerRegistryOS.Linux
            });
            ContainerRegistryAgentPoolResource agentPool = lro.Value;
            Assert.AreEqual(agentPoolName, agentPool.Data.Name);
            Assert.AreEqual(1, agentPool.Data.Count);
            Assert.AreEqual("S2", agentPool.Data.Tier);
            Assert.AreEqual(ContainerRegistryOS.Linux, agentPool.Data.OS);
            // List agentpools
            await foreach (var agentPoolFromList in agentPoolCollection)
            {
                Assert.AreEqual(agentPoolName, agentPoolFromList.Data.Name);
            }
            // Update the agentpool
            lro = await agentPool.UpdateAsync(WaitUntil.Completed, new ContainerRegistryAgentPoolPatch()
            {
                Count = 2
            });
            ContainerRegistryAgentPoolResource agentPoolFromUpdate = lro.Value;
            Assert.AreEqual(2, agentPoolFromUpdate.Data.Count);
            // Schedule a task run on the agentpool
            string taskString =
@"
version: v1.1.0
steps:
  - cmd: docker images".Replace("\r\n", "\n");
            var runLro = await registry.ScheduleRunAsync(WaitUntil.Completed, new ContainerRegistryEncodedTaskRunContent(Convert.ToBase64String(Encoding.UTF8.GetBytes(taskString)), new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 })
            {
                AgentPoolName = agentPoolName,
                IsArchiveEnabled = false,
                TimeoutInSeconds = 600
            });
            ContainerRegistryRunResource run = runLro.Value;
            // List runs
            var runCount = 0;
            await foreach (var runFromList in registry.GetContainerRegistryRuns())
            {
                runCount++;
                Assert.AreEqual(agentPoolName, runFromList.Data.AgentPoolName);
            }
            Assert.AreEqual(1, runCount);
            // Delete the registry
            await registry.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Need permission of existing resource to run the tests")]
        public async Task ContainerRegistryTaskRun()
        {
            var location = AzureLocation.WestUS;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", location);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName, AzureLocation.EastUS);
            var taskRunCollection = registry.GetContainerRegistryTaskRuns();
            // Create task run
            var taskRunName = Recording.GenerateAssetName("acrtaskrun");
            string taskString =
@"
version: v1.1.0
steps:
  - cmd: docker images".Replace("\r\n", "\n");
            var lro = await taskRunCollection.CreateOrUpdateAsync(WaitUntil.Completed, taskRunName, new ContainerRegistryTaskRunData()
            {
                Location = registry.Data.Location,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                {
                    UserAssignedIdentities =
                    {
                        { new ResourceIdentifier("/subscriptions/84c559c6-30a0-417c-ba06-8a2253b388c3/resourceGroups/sdk-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/acrsdktestidentity"), new UserAssignedIdentity()}
                    }
                },
                RunRequest = new ContainerRegistryEncodedTaskRunContent(Convert.ToBase64String(Encoding.UTF8.GetBytes(taskString)), new ContainerRegistryPlatformProperties(ContainerRegistryOS.Linux) { Architecture = ContainerRegistryOSArchitecture.Amd64 })
                {
                    Credentials = new ContainerRegistryCredentials()
                    {
                        SourceRegistry = new SourceRegistryCredentials()
                        {
                            LoginMode = SourceRegistryLoginMode.Default
                        },
                        CustomRegistries =
                        {
                            {
                                "acrsdktestregistry.azurecr.io", new CustomRegistryCredentials()
                                {
                                    Identity = "84962bda-7c5e-403e-8515-5100e4ede735" // client id of acrsdktestidentity
                                }
                            }
                        }
                    },
                    TimeoutInSeconds = 600
                }
            });
            ContainerRegistryTaskRunResource taskRun = lro.Value;
            Assert.AreEqual(taskRunName, taskRun.Data.Name);
            // Assert.AreEqual("ca1", taskRun.Data.RunResult.RunId);
            // List taskruns
            await foreach (var taskRunFromList in taskRunCollection)
            {
                Assert.AreEqual(taskRunName, taskRunFromList.Data.Name);
            }
            // Delete the taskrun
            await taskRun.DeleteAsync(WaitUntil.Completed);
            // Delete the registry
            await registry.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistryPrivateLinkResources()
        {
            var location = AzureLocation.WestUS;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", location);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            // Validate list private link resources operation for premium registry
            var privateLinkCollection = registry.GetContainerRegistryPrivateLinkResources();
            var privateLinkCount = 0;
            var privateLinkName = string.Empty;
            await foreach (var privateLinkFromList in privateLinkCollection)
            {
                privateLinkName = privateLinkFromList.Data.Name;
                privateLinkCount++;
            }
            Assert.Greater(privateLinkCount, 0);
            // Validate get private link resource operation
            ContainerRegistryPrivateLinkResource privateLink = await privateLinkCollection.GetAsync(privateLinkName);
            Assert.AreEqual(privateLinkName, privateLink.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task ContainerRegistrySystemData()
        {
            var location = AzureLocation.WestUS;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testRg", location);
            var registryCollection = rg.GetContainerRegistries();
            // Create container registry
            var registryName = Recording.GenerateAssetName("acrregistry");
            ContainerRegistryResource registry = await CreateContainerRegistryAsync(rg, registryName);
            // Validate registry system data properties
            var cachedSystemData = registry.Data.SystemData;
            ValidateSystemData(cachedSystemData);
            // Apply Sku update
            var lro = await registry.UpdateAsync(WaitUntil.Completed, new ContainerRegistryPatch()
            {
                Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Standard)
            });
            ContainerRegistryResource registryFromUpdate = lro.Value;
            // Validate updated registry system data properties
            ValidateSystemData(registryFromUpdate.Data.SystemData);
            // Validate system data create properties
            Assert.AreEqual(cachedSystemData.CreatedOn, registryFromUpdate.Data.SystemData.CreatedOn);
            Assert.AreEqual(cachedSystemData.CreatedBy, registryFromUpdate.Data.SystemData.CreatedBy);
            Assert.AreEqual(cachedSystemData.CreatedByType, registryFromUpdate.Data.SystemData.CreatedByType);
            // Validate system data update properties
            Assert.AreNotEqual(cachedSystemData.LastModifiedOn, registryFromUpdate.Data.SystemData.LastModifiedOn);
            Assert.AreEqual(cachedSystemData.LastModifiedBy, registryFromUpdate.Data.SystemData.LastModifiedBy);
            Assert.AreEqual(cachedSystemData.LastModifiedByType, registryFromUpdate.Data.SystemData.LastModifiedByType);
        }

        private static void ValidateSystemData(SystemData systemData)
        {
            Assert.NotNull(systemData);
            Assert.NotNull(systemData.CreatedOn);
            Assert.NotNull(systemData.CreatedBy);
            Assert.NotNull(systemData.CreatedByType);
            Assert.NotNull(systemData.LastModifiedOn);
            Assert.NotNull(systemData.LastModifiedBy);
            Assert.NotNull(systemData.LastModifiedByType);
        }

        private static void ValidateResourceDefaultTags(TrackedResourceData resourceData)
        {
            ValidateResourceData(resourceData);
            Assert.NotNull(resourceData.Tags);
            Assert.AreEqual(2, resourceData.Tags.Count);
            Assert.AreEqual("value1", resourceData.Tags["key1"]);
            Assert.AreEqual("value2", resourceData.Tags["key2"]);
        }

        private static void ValidateResourceDefaultNewTags(TrackedResourceData resourceData)
        {
            ValidateResourceData(resourceData);
            Assert.NotNull(resourceData.Tags);
            Assert.AreEqual(3, resourceData.Tags.Count);
            Assert.AreEqual("value2", resourceData.Tags["key2"]);
            Assert.AreEqual("value3", resourceData.Tags["key3"]);
            Assert.AreEqual("value4", resourceData.Tags["key4"]);
        }

        private static void ValidateResourceData(TrackedResourceData resourceData)
        {
            Assert.NotNull(resourceData);
            Assert.NotNull(resourceData.Id);
            Assert.NotNull(resourceData.Name);
            Assert.NotNull(resourceData.ResourceType);
            Assert.NotNull(resourceData.Location);
        }
    }
}
