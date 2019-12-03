// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;
using Sku = Microsoft.Azure.Management.ContainerRegistry.Models.Sku;

namespace ContainerRegistry.Tests
{
    public class ContainerRegistryTests
    {
        [Fact]
        public void ContainerRegistryCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);

                // Check valid name
                var registryName = TestUtilities.GenerateName("acrregistry");
                var checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.True(checkNameRequest.NameAvailable);
                Assert.Null(checkNameRequest.Reason);
                Assert.Null(checkNameRequest.Message);

                // Check disallowed name
                registryName = "Microsoft";
                checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("Invalid", checkNameRequest.Reason);
                Assert.Equal("The specified resource name is disallowed", checkNameRequest.Message);

                // Check name of container registry that already exists
                registryName = ContainerRegistryTestUtilities.CreateManagedContainerRegistry(registryClient, resourceGroup.Name, resourceGroup.Location).Name;
                checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("AlreadyExists", checkNameRequest.Reason);
                Assert.Equal("The registry " + registryName + " is already in use.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void ClassicContainerRegistryTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                var storageAccount = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);

                // Create container registry
                var registry = ContainerRegistryTestUtilities.CreateClassicContainerRegistry(registryClient, resourceGroup, storageAccount);

                ContainerRegistryCoreScenario(registryClient, resourceGroup, registry, false);
            }
        }

        [Fact]
        public void ManagedContainerRegistryTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);

                // Create container registry
                var registry = ContainerRegistryTestUtilities.CreateManagedContainerRegistry(registryClient, resourceGroup.Name, resourceGroup.Location);

                ContainerRegistryCoreScenario(registryClient, resourceGroup, registry, true);
            }
        }

        private void ContainerRegistryCoreScenario(ContainerRegistryManagementClient registryClient, ResourceGroup resourceGroup, Registry registry, bool isManaged)
        {
            // Validate the created registry
            ContainerRegistryTestUtilities.ValidateResourceDefaultTags(registry);
            Assert.NotNull(registry.Sku);
            if (isManaged)
            {
                Assert.Equal(SkuName.Premium, registry.Sku.Name);
                Assert.Equal(SkuName.Premium, registry.Sku.Tier);
            }
            else
            {
                Assert.Equal(SkuName.Classic, registry.Sku.Name);
                Assert.Equal(SkuTier.Classic, registry.Sku.Tier);
            }
            Assert.NotNull(registry.LoginServer);
            Assert.NotNull(registry.CreationDate);
            Assert.Equal(ProvisioningState.Succeeded, registry.ProvisioningState);
            Assert.False(registry.AdminUserEnabled);
            if (isManaged)
            {
                Assert.Null(registry.StorageAccount);
            }
            else
            {
                Assert.NotNull(registry.StorageAccount);
            }

            // List container registries by resource group
            var registriesByResourceGroup = registryClient.Registries.ListByResourceGroup(resourceGroup.Name);
            registry = registriesByResourceGroup.First(
                r => StringComparer.OrdinalIgnoreCase.Equals(r.Name, registry.Name));
            Assert.Single(registriesByResourceGroup);
            ContainerRegistryTestUtilities.ValidateResourceDefaultTags(registry);

            // Get the container registry
            registry = registryClient.Registries.Get(resourceGroup.Name, registry.Name);
            ContainerRegistryTestUtilities.ValidateResourceDefaultTags(registry);

            // Try to list credentials, should fail when admin user is disabled
            try
            {
                registryClient.Registries.ListCredentials(resourceGroup.Name, registry.Name);
                Assert.True(false);
            }
            catch (CloudException ex)
            {
                Assert.NotNull(ex);
                Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
            }

            // Update the container registry
            registry = registryClient.Registries.Update(resourceGroup.Name, registry.Name, new RegistryUpdateParameters
            {
                Tags = ContainerRegistryTestUtilities.DefaultNewTags,
                AdminUserEnabled = true,
                Sku = new Sku
                {
                    Name = isManaged ? SkuName.Basic : SkuName.Classic
                }
            });

            // Validate the updated registry
            ContainerRegistryTestUtilities.ValidateResourceDefaultNewTags(registry);
            Assert.NotNull(registry.Sku);
            if (isManaged)
            {
                Assert.Equal(SkuName.Basic, registry.Sku.Name);
                Assert.Equal(SkuName.Basic, registry.Sku.Tier);
            }
            else
            {
                Assert.Equal(SkuName.Classic, registry.Sku.Name);
                Assert.Equal(SkuTier.Classic, registry.Sku.Tier);
            }
            Assert.NotNull(registry.LoginServer);
            Assert.NotNull(registry.CreationDate);
            Assert.Equal(ProvisioningState.Succeeded, registry.ProvisioningState);
            Assert.True(registry.AdminUserEnabled);
            if (isManaged)
            {
                Assert.Null(registry.StorageAccount);
            }
            else
            {
                Assert.NotNull(registry.StorageAccount);
            }

            // List credentials
            var credentials = registryClient.Registries.ListCredentials(resourceGroup.Name, registry.Name);

            // Validate username and password
            Assert.NotNull(credentials);
            Assert.NotNull(credentials.Username);
            Assert.Equal(2, credentials.Passwords.Count);
            var password1 = credentials.Passwords[0].Value;
            var password2 = credentials.Passwords[1].Value;
            Assert.NotNull(password1);
            Assert.NotNull(password2);

            // Regenerate credential
            credentials = registryClient.Registries.RegenerateCredential(resourceGroup.Name, registry.Name, PasswordName.Password);

            // Validate if generated password is different
            var newPassword1 = credentials.Passwords[0].Value;
            var newPassword2 = credentials.Passwords[1].Value;
            Assert.NotEqual(password1, newPassword1);
            Assert.Equal(password2, newPassword2);

            credentials = registryClient.Registries.RegenerateCredential(resourceGroup.Name, registry.Name, PasswordName.Password2);

            // Validate if generated password is different
            Assert.Equal(newPassword1, credentials.Passwords[0].Value);
            Assert.NotEqual(newPassword2, credentials.Passwords[1].Value);

            // Delete the container registry
            registryClient.Registries.Delete(resourceGroup.Name, registry.Name);

            // Delete the container registry again
            registryClient.Registries.Delete(resourceGroup.Name, registry.Name);
        }

        [Fact]
        public void ContainerRegistryWebhookTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);

                // Create container registry and webhook
                var registry = ContainerRegistryTestUtilities.CreateManagedContainerRegistry(registryClient, resourceGroup.Name, resourceGroup.Location);
                var webhook = ContainerRegistryTestUtilities.CreatedContainerRegistryWebhook(registryClient, resourceGroup.Name, registry.Name, resourceGroup.Location);

                // Validate the created webhook
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(webhook);
                Assert.Equal(WebhookStatus.Enabled, webhook.Status);
                Assert.True(string.IsNullOrEmpty(webhook.Scope));
                Assert.Equal(1, webhook.Actions.Count);
                Assert.True(webhook.Actions.Contains(WebhookAction.Push));
                Assert.Equal(ProvisioningState.Succeeded, webhook.ProvisioningState);

                // List webhooks by container registry
                var webhooks = registryClient.Webhooks.List(resourceGroup.Name, registry.Name);
                webhook = webhooks.First(
                    w => StringComparer.OrdinalIgnoreCase.Equals(w.Name, webhook.Name));
                Assert.Single(webhooks);
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(webhook);

                // Get the webhook
                webhook = registryClient.Webhooks.Get(resourceGroup.Name, registry.Name, webhook.Name);
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(webhook);

                // Update the webhook
                webhook = registryClient.Webhooks.Update(resourceGroup.Name, registry.Name, webhook.Name, new WebhookUpdateParameters
                {
                    Tags = ContainerRegistryTestUtilities.DefaultNewTags,
                    Status = WebhookStatus.Disabled,
                    Scope = ContainerRegistryTestUtilities.DefaultWebhookScope,
                    Actions = new List<string>
                    {
                         WebhookAction.Push, WebhookAction.Delete
                    },
                    CustomHeaders = new Dictionary<string, string>
                    {
                        {"key","value" }
                    }
                });

                // Validate the updated webhook
                ContainerRegistryTestUtilities.ValidateResourceDefaultNewTags(webhook);
                Assert.Equal(WebhookStatus.Disabled, webhook.Status);
                Assert.Equal(ContainerRegistryTestUtilities.DefaultWebhookScope, webhook.Scope);
                Assert.Equal(2, webhook.Actions.Count);
                Assert.True(webhook.Actions.Contains(WebhookAction.Push));
                Assert.True(webhook.Actions.Contains(WebhookAction.Delete));
                Assert.Equal(ProvisioningState.Succeeded, webhook.ProvisioningState);

                // Get the webhook call back config
                var webhookConfig = registryClient.Webhooks.GetCallbackConfig(resourceGroup.Name, registry.Name, webhook.Name);
                Assert.NotNull(webhookConfig);
                Assert.Equal(ContainerRegistryTestUtilities.DefaultWebhookServiceUri, webhookConfig.ServiceUri);
                Assert.Equal(1, webhookConfig.CustomHeaders.Count);
                Assert.Equal("value", webhookConfig.CustomHeaders["key"]);

                // Ping the webhook
                var eventInfo = registryClient.Webhooks.Ping(resourceGroup.Name, registry.Name, webhook.Name);
                Assert.NotNull(eventInfo);
                Assert.NotNull(eventInfo.Id);

                var events = registryClient.Webhooks.ListEvents(resourceGroup.Name, registry.Name, webhook.Name);
                Assert.NotNull(events);

                // Delete the webhook
                registryClient.Webhooks.Delete(resourceGroup.Name, registry.Name, webhook.Name);

                // Delete the webhook again
                registryClient.Webhooks.Delete(resourceGroup.Name, registry.Name, webhook.Name);

                // Delete the container registry
                registryClient.Registries.Delete(resourceGroup.Name, registry.Name);
            }
        }

        [Fact]
        public void ContainerRegistryReplicationTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                var nonDefaultLocation = ContainerRegistryTestUtilities.GetNonDefaultRegistryLocation(resourceClient, resourceGroup.Location);

                // Create container registry and replication
                var registry = ContainerRegistryTestUtilities.CreateManagedContainerRegistry(registryClient, resourceGroup.Name, nonDefaultLocation);
                var replication = ContainerRegistryTestUtilities.CreatedContainerRegistryReplication(registryClient, resourceGroup.Name, registry.Name, resourceGroup.Location);

                // Validate the created replication
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(replication);
                Assert.Equal(ProvisioningState.Succeeded, replication.ProvisioningState);
                Assert.NotNull(replication.Status);
                Assert.NotNull(replication.Status.DisplayStatus);

                // List replications by container registry
                var replications = registryClient.Replications.List(resourceGroup.Name, registry.Name);
                replication = replications.First(
                    r => StringComparer.OrdinalIgnoreCase.Equals(r.Name, replication.Name));
                Assert.Equal(2, replications.Count()); // 2 because a replication in home region is auto created
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(replication);

                // Get the replication
                replication = registryClient.Replications.Get(resourceGroup.Name, registry.Name, replication.Name);
                ContainerRegistryTestUtilities.ValidateResourceDefaultTags(replication);

                // Update the replication
                replication = registryClient.Replications.Update(resourceGroup.Name, registry.Name, replication.Name, ContainerRegistryTestUtilities.DefaultNewTags);

                // Validate the updated replication
                ContainerRegistryTestUtilities.ValidateResourceDefaultNewTags(replication);
                Assert.Equal(ProvisioningState.Succeeded, replication.ProvisioningState);
                Assert.NotNull(replication.Status);
                Assert.NotNull(replication.Status.DisplayStatus);

                // Delete the replication
                registryClient.Replications.Delete(resourceGroup.Name, registry.Name, replication.Name);

                // Delete the replication again
                registryClient.Replications.Delete(resourceGroup.Name, registry.Name, replication.Name);

                // Delete the container registry
                registryClient.Registries.Delete(resourceGroup.Name, registry.Name);
            }
        }

        [Fact]
        public void ContainerRegistryTaskTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group
                var resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                var nonDefaultLocation = ContainerRegistryTestUtilities.GetNonDefaultRegistryLocation(resourceClient, resourceGroup.Location);

                // Create container registry
                var registry = ContainerRegistryTestUtilities.CreateManagedContainerRegistry(registryClient, resourceGroup.Name, nonDefaultLocation);

                // Crete task
                var task = registryClient.Tasks.Create(
                    resourceGroup.Name,
                    registry.Name,
                    TestUtilities.GenerateName("acrtask"),
                    new Task(
                        location: registry.Location,
                        platform: new PlatformProperties { Architecture = Architecture.Amd64, Os = OS.Linux },
                        step: new DockerBuildStep(
                            dockerFilePath: "Dockerfile",
                            baseImageDependencies: null,
                            contextPath: "https://github.com/azure/acr-builder.git",
                            imageNames: new List<string> { "image:{{.Run.ID}}", "image:latest" },
                            isPushEnabled: true,
                            noCache: true,
                            arguments: null),
                        agentConfiguration: new AgentProperties(cpu: 2),
                        status: "Enabled",
                        timeout: 600,
                        trigger: new TriggerProperties(
                            sourceTriggers: null, 
                            baseImageTrigger: new BaseImageTrigger(BaseImageTriggerType.Runtime, "defaultBaseimageTriggerName", TriggerStatus.Enabled))
                        ));

                Assert.NotNull(task);

                // List task
                var taskList = registryClient.Tasks.List(resourceGroup.Name, registry.Name);
                Assert.Single(taskList);

                // Update task
                task = registryClient.Tasks.Update(resourceGroup.Name, registry.Name, task.Name, new TaskUpdateParameters(
                        timeout: 900
                    ));

                Assert.Equal(900, task.Timeout);

                // Schedule a run from task
                var run1 = registryClient.Registries.ScheduleRun(resourceGroup.Name, registry.Name,
                    new TaskRunRequest(
                        task.Name,
                        values: new List<SetValue> { new SetValue("key1", "value1"), new SetValue("key2", "value2", isSecret: true) }));

                Assert.Equal("ca1", run1.RunId);

                // Cancel the run
                registryClient.Runs.Cancel(resourceGroup.Name, registry.Name, run1.RunId);

                // Schedule a docker build run
                var run2 = registryClient.Registries.ScheduleRun(resourceGroup.Name, registry.Name,
                    new DockerBuildRequest(
                        dockerFilePath: "Dockerfile",
                        platform: new PlatformProperties { Architecture = Architecture.Amd64, Os = OS.Linux },
                        isArchiveEnabled: false,
                        imageNames: new List<string> { "testimage1:tag1", "testimage2:tag2" },
                        isPushEnabled: false,
                        noCache: true,
                        arguments: new List<Argument> { new Argument("param1", "value1", isSecret: true) },
                        timeout: 600, 
                        agentConfiguration: new AgentProperties(cpu: 2),
                        sourceLocation: "https://github.com/azure/acr-builder.git"));

                Assert.Equal("ca2", run2.RunId);

                // Schedule a file based task run
                var run3 = registryClient.Registries.ScheduleRun(resourceGroup.Name, registry.Name,
                    new FileTaskRunRequest(
                        taskFilePath: "acb.yaml",
                        platform: new PlatformProperties { Architecture = Architecture.Amd64, Os = OS.Linux },
                        isArchiveEnabled: false,
                        valuesFilePath: null,
                        values: new List<SetValue> { new SetValue("key1", "value1"), new SetValue("key2", "value2", isSecret: true) },
                        timeout: 600,
                        agentConfiguration: new AgentProperties(cpu: 2),
                        sourceLocation: "https://github.com/azure/acr-builder.git"));

                Assert.Equal("ca3", run3.RunId);

                // Schedule an encoded task run
                string taskString =
@"
steps:
  -build: . -t acb:linux-{{.Run.ID}}";
                string valuesString =
@"
key1: value1
key2: value2
";
                var run4 = registryClient.Registries.ScheduleRun(resourceGroup.Name, registry.Name,
                    new EncodedTaskRunRequest(
                        encodedTaskContent: Convert.ToBase64String(Encoding.UTF8.GetBytes(taskString)),
                        platform: new PlatformProperties { Architecture = Architecture.Amd64, Os = OS.Linux },
                        isArchiveEnabled: false,
                        encodedValuesContent: Convert.ToBase64String(Encoding.UTF8.GetBytes(valuesString)),
                        values: null,
                        timeout: 600,
                        agentConfiguration: new AgentProperties(cpu: 2),
                        sourceLocation: "https://github.com/azure/acr-builder.git"));

                Assert.Equal("ca4", run4.RunId);

                // List runs
                var runList = registryClient.Runs.List(resourceGroup.Name, registry.Name);
                Assert.Equal(4, runList.Count());

                // Delete the task
                registryClient.Tasks.Delete(resourceGroup.Name, registry.Name, task.Name);

                // Delete the container registry
                registryClient.Registries.Delete(resourceGroup.Name, registry.Name);
            }
        }
    }
}
