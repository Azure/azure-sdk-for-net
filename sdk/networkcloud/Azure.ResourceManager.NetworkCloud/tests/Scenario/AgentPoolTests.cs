// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class AgentPoolTests : NetworkCloudManagementTestBase
    {
        public AgentPoolTests  (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public AgentPoolTests (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        public async Task AgentPool()
        {
            string agentPoolName = Recording.GenerateAssetName("systemPool");
            ResourceIdentifier agentPoolId = AgentPoolResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.KubernetesClusterRG, TestEnvironment.KubernetesClusterName, agentPoolName);
            AgentPoolResource agentPool = Client.GetAgentPoolResource(agentPoolId);

            KubernetesClusterResource kubernetesCluster = Client.GetKubernetesClusterResource(TestEnvironment.KubernetesClusterId);
            kubernetesCluster = await kubernetesCluster.GetAsync();
            AgentPoolCollection collection = kubernetesCluster.GetAgentPools();

            // Create
            AgentPoolData data = new AgentPoolData
            (TestEnvironment.Location, 1, AgentPoolMode.System, TestEnvironment.VMImage)
            {
                ExtendedLocation = kubernetesCluster.Data.ExtendedLocation,
                AdministratorConfiguration = new AdministratorConfiguration()
                {
                    AdminUsername = "azure",
                    SshPublicKeys =
                    {
                    new SshPublicKey("ssh-rsa AAtsE3njSONzDYRIZv/WLjVuMfrUSByHp+jfaaOLHTIIB4fJvo6dQUZxE20w2iDHV3tEkmnTo84eba97VMueQD6OzJPEyWZMRpz8UYWOd0IXeRqiFu1lawNblZhwNT/ojNZfpB3af/YDzwQCZgTcTRyNNhL4o/blKUmug0daSsSXISTRnIDpcf5qytjs1Xo+yYyJMvzLL59mhAyb3p/cD+Y3/s3WhAx+l0XOKpzXnblrv9d3q4c2tWmm/SyFqthaqd0= fake-public-key")
                    },
                },
                AgentOptions = new AgentOptions(12)
                {
                    HugepagesSize = HugepagesSize.TwoM,
                },
                UpgradeMaxSurge = "1",
                Tags =
                {
                    [ "key1" ] = "value1",
                    [ "key2" ] = "value2",
                },
                AttachedNetworkConfiguration = new AttachedNetworkConfiguration()
                {
                    L3Networks =
                    {
                        new L3NetworkAttachmentConfiguration(TestEnvironment.L3NAttachmentId)
                        {
                            IpamEnabled = L3NetworkConfigurationIpamEnabled.False,
                            PluginType = KubernetesPluginType.Sriov,
                        }
                    }
                }
            };

            // Create
            ArmOperation<AgentPoolResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, agentPoolName, data);
            Assert.AreEqual(agentPoolName, createResult.Value.Data.Name);

            // Get
            var getResult = await agentPool.GetAsync();
            Assert.AreEqual(agentPoolName, getResult.Value.Data.Name);

            // List
            var listByKubernetesCluster = new List<AgentPoolResource>();
            await foreach (AgentPoolResource item in collection.GetAllAsync())
            {
                listByKubernetesCluster.Add(item);
            }
            Assert.IsNotEmpty(listByKubernetesCluster);

            // Update
            AgentPoolPatch patch = new AgentPoolPatch()
            {
                Tags =
                {
                    ["key1"] = "newvalue1",
                    ["key2"] = "newvalue2",
                }
            };
            ArmOperation<AgentPoolResource> updateResult = await agentPool.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await agentPool.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
