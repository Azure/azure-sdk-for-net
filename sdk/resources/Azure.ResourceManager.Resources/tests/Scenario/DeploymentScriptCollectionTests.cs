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
            Assert.AreEqual(deployScriptName, deploymentScript.Data.Name);
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
            Assert.AreEqual(count, 1);
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
            Assert.AreEqual(count, 1);
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
            Assert.AreEqual(model.Id, getResult.Id);
            Assert.AreEqual(model.Name, getResult.Name);
            Assert.AreEqual(model.ResourceType, getResult.ResourceType);
            if (model.ContainerSettings != null || getResult.ContainerSettings != null)
            {
                Assert.NotNull(model.ContainerSettings);
                Assert.NotNull(getResult.ContainerSettings);
                Assert.AreEqual(model.ContainerSettings.ContainerGroupName, getResult.ContainerSettings.ContainerGroupName);
            }
            if (model.StorageAccountSettings != null || getResult.StorageAccountSettings != null)
            {
                Assert.NotNull(model.StorageAccountSettings);
                Assert.NotNull(getResult.StorageAccountSettings);
                Assert.AreEqual(model.StorageAccountSettings.StorageAccountName, getResult.StorageAccountSettings.StorageAccountName);
                Assert.AreEqual(model.StorageAccountSettings.StorageAccountKey, getResult.StorageAccountSettings.StorageAccountKey);
            }
            Assert.AreEqual(model.CleanupPreference, getResult.CleanupPreference);
            Assert.AreEqual(model.ProvisioningState, getResult.ProvisioningState);
            if (model.Status != null || getResult.Status != null)
            {
                Assert.NotNull(model.Status);
                Assert.NotNull(getResult.Status);
                Assert.AreEqual(model.Status.ContainerInstanceId, getResult.Status.ContainerInstanceId);
                Assert.AreEqual(model.Status.StorageAccountId, getResult.Status.StorageAccountId);
                Assert.AreEqual(model.Status.StartOn, getResult.Status.StartOn);
                Assert.AreEqual(model.Status.EndOn, getResult.Status.EndOn);
                Assert.AreEqual(model.Status.ExpirationOn, getResult.Status.ExpirationOn);
                //Assert.AreEqual(model.Status.Error, getResult.Status.Error);
            }
            var modelOutputs = model.Outputs.ToObjectFromJson<Dictionary<string, object>>();
            var getOutputs = getResult.Outputs.ToObjectFromJson<Dictionary<string, object>>();
            Assert.AreEqual(modelOutputs.Count, getOutputs.Count);
            foreach (var kv in modelOutputs)
            {
                Assert.IsTrue(getOutputs.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value.ToString(), getOutputs[kv.Key].ToString());
            }
            Assert.AreEqual(model.PrimaryScriptUri, getResult.PrimaryScriptUri);
            Assert.AreEqual(model.SupportingScriptUris, getResult.SupportingScriptUris);
            Assert.AreEqual(model.ScriptContent, getResult.ScriptContent);
            Assert.AreEqual(model.Arguments, getResult.Arguments);
            if (model.EnvironmentVariables != null || getResult.EnvironmentVariables != null)
            {
                Assert.NotNull(model.EnvironmentVariables);
                Assert.NotNull(getResult.EnvironmentVariables);
                Assert.AreEqual(model.EnvironmentVariables.Count, getResult.EnvironmentVariables.Count);
                for (int i = 0; i < model.EnvironmentVariables.Count; ++i)
                {
                    Assert.AreEqual(model.EnvironmentVariables[i].Name, getResult.EnvironmentVariables[i].Name);
                    Assert.AreEqual(model.EnvironmentVariables[i].Value, getResult.EnvironmentVariables[i].Value);
                    Assert.AreEqual(model.EnvironmentVariables[i].SecureValue, getResult.EnvironmentVariables[i].SecureValue);
                }
            }
            Assert.AreEqual(model.ForceUpdateTag, getResult.ForceUpdateTag);
            Assert.AreEqual(model.RetentionInterval, getResult.RetentionInterval);
            Assert.AreEqual(model.Timeout, getResult.Timeout);
            Assert.AreEqual(model.AzPowerShellVersion, getResult.AzPowerShellVersion);
        }
    }
}
