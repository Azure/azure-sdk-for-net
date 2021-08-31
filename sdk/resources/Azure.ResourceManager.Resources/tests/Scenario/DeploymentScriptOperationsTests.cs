// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentScriptOperationsTests : ResourcesTestBase
    {
        public DeploymentScriptOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DeploymentScriptData> GetDeploymentScriptDataAsync()
        {
            //The user assigned identities was created firstly in Portal due to the unexpected behavior of using generic resource to create the user assigned identities.
            string rgName4Identities = "rg-for-DeployScript";
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName4Identities, rgData);
            ResourceGroup rg4Identities = lro.Value;
            GenericResourceData userAssignedIdentitiesData = ConstructGenericUserAssignedIdentities();
            ResourceIdentifier userAssignedIdentitiesId = rg4Identities.Id.AppendProviderResource("Microsoft.ManagedIdentity", "userAssignedIdentities", "test-user-assigned-msi");
            var lro2 = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(userAssignedIdentitiesId, userAssignedIdentitiesData);
            GenericResource userAssignedIdentities = lro2.Value;
            var managedIdentity = new ManagedServiceIdentity()
            {
                Type = "UserAssigned",
                UserAssignedIdentities =
                {
                    {
                        userAssignedIdentitiesId,
                        new UserAssignedIdentity()
                    }
                }
            };
            string AzurePowerShellVersion = "2.7.0";
            TimeSpan RetentionInterval = new TimeSpan(1, 2, 0, 0, 0);
            string ScriptContent = "param([string] $helloWorld) Write-Output $helloWorld; $DeploymentScriptOutputs['output'] = $helloWorld";
            string ScriptArguments = "'Hello World'";
            return new AzurePowerShellScript(Location.WestUS2, RetentionInterval, AzurePowerShellVersion)
            {
                Identity = managedIdentity,
                ScriptContent = ScriptContent,
                Arguments = ScriptArguments
            };
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            DeploymentScriptData deploymentScriptData = await GetDeploymentScriptDataAsync();
            DeploymentScript deploymentScript = (await rg.GetDeploymentScripts().CreateOrUpdateAsync(deployScriptName, deploymentScriptData)).Value;
            await deploymentScript.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentScript.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private static GenericResourceData ConstructGenericUserAssignedIdentities()
        {
            var userAssignedIdentities = new GenericResourceData(Location.WestUS2);
            return userAssignedIdentities;
        }
    }
}
