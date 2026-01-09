// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentScriptCollectionTests : ResourcesTestBase
    {
        public DeploymentScriptCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-C-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            Assert.That(deploymentScript.Data.Name, Is.EqualTo(deployScriptName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, null, deploymentScriptData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRg()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-L-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            _ = await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData);
            int count = 0;
            await foreach (var tempDeploymentScript in rg.GetArmDeploymentScripts().GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-L-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            _ = await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData);
            int count = 0;
            await foreach (var tempDeploymentScript in subscription.GetArmDeploymentScriptsAsync())
            {
                if (tempDeploymentScript.Data.Name == deployScriptName)
                {
                    count++;
                }
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-G-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var tempDeploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            AzurePowerShellScript deploymentScript = tempDeploymentScript.Data as AzurePowerShellScript;
            ArmDeploymentScriptResource tempGetDeploymentScript = await rg.GetArmDeploymentScripts().GetAsync(deployScriptName);
            AzurePowerShellScript getdeploymentScript = tempGetDeploymentScript.Data as AzurePowerShellScript;
            AssertValidDeploymentScript(deploymentScript, getdeploymentScript);
        }

        private static void AssertValidDeploymentScript(AzurePowerShellScript model, AzurePowerShellScript getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Id, Is.EqualTo(model.Id));
                Assert.That(getResult.Name, Is.EqualTo(model.Name));
                Assert.That(getResult.ResourceType, Is.EqualTo(model.ResourceType));
            });
            if (model.ContainerSettings != null || getResult.ContainerSettings != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.ContainerSettings, Is.Not.Null);
                    Assert.That(getResult.ContainerSettings, Is.Not.Null);
                });
                Assert.That(getResult.ContainerSettings.ContainerGroupName, Is.EqualTo(model.ContainerSettings.ContainerGroupName));
            }
            if (model.StorageAccountSettings != null || getResult.StorageAccountSettings != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.StorageAccountSettings, Is.Not.Null);
                    Assert.That(getResult.StorageAccountSettings, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.StorageAccountSettings.StorageAccountName, Is.EqualTo(model.StorageAccountSettings.StorageAccountName));
                    Assert.That(getResult.StorageAccountSettings.StorageAccountKey, Is.EqualTo(model.StorageAccountSettings.StorageAccountKey));
                });
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.CleanupPreference, Is.EqualTo(model.CleanupPreference));
                Assert.That(getResult.ProvisioningState, Is.EqualTo(model.ProvisioningState));
            });
            if (model.Status != null || getResult.Status != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Status, Is.Not.Null);
                    Assert.That(getResult.Status, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Status.ContainerInstanceId, Is.EqualTo(model.Status.ContainerInstanceId));
                    Assert.That(getResult.Status.StorageAccountId, Is.EqualTo(model.Status.StorageAccountId));
                    Assert.That(getResult.Status.StartOn, Is.EqualTo(model.Status.StartOn));
                    Assert.That(getResult.Status.EndOn, Is.EqualTo(model.Status.EndOn));
                    Assert.That(getResult.Status.ExpirationOn, Is.EqualTo(model.Status.ExpirationOn));
                });
                //Assert.AreEqual(model.Status.Error, getResult.Status.Error);
            }
            var modelOutputs = model.Outputs.ToObjectFromJson<Dictionary<string, object>>();
            var getOutputs = getResult.Outputs.ToObjectFromJson<Dictionary<string, object>>();
            Assert.That(getOutputs, Has.Count.EqualTo(modelOutputs.Count));
            foreach (var kv in modelOutputs)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(getOutputs.ContainsKey(kv.Key), Is.True);
                    Assert.That(getOutputs[kv.Key].ToString(), Is.EqualTo(kv.Value.ToString()));
                });
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.PrimaryScriptUri, Is.EqualTo(model.PrimaryScriptUri));
                Assert.That(getResult.SupportingScriptUris, Is.EqualTo(model.SupportingScriptUris));
                Assert.That(getResult.ScriptContent, Is.EqualTo(model.ScriptContent));
                Assert.That(getResult.Arguments, Is.EqualTo(model.Arguments));
            });
            if (model.EnvironmentVariables != null || getResult.EnvironmentVariables != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.EnvironmentVariables, Is.Not.Null);
                    Assert.That(getResult.EnvironmentVariables, Is.Not.Null);
                });
                Assert.That(getResult.EnvironmentVariables, Has.Count.EqualTo(model.EnvironmentVariables.Count));
                for (int i = 0; i < model.EnvironmentVariables.Count; ++i)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(getResult.EnvironmentVariables[i].Name, Is.EqualTo(model.EnvironmentVariables[i].Name));
                        Assert.That(getResult.EnvironmentVariables[i].Value, Is.EqualTo(model.EnvironmentVariables[i].Value));
                        Assert.That(getResult.EnvironmentVariables[i].SecureValue, Is.EqualTo(model.EnvironmentVariables[i].SecureValue));
                    });
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.ForceUpdateTag, Is.EqualTo(model.ForceUpdateTag));
                Assert.That(getResult.RetentionInterval, Is.EqualTo(model.RetentionInterval));
                Assert.That(getResult.Timeout, Is.EqualTo(model.Timeout));
                Assert.That(getResult.AzPowerShellVersion, Is.EqualTo(model.AzPowerShellVersion));
            });
        }
    }
}
