// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests.Scenario
{
    public class ContainerServiceManagedClusterCollectionTests : ContainerServiceManagementTestBase
    {
        public ContainerServiceManagedClusterCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        { }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var clusterName = Recording.GenerateAssetName("manCluster-");

            var clusterData = new ContainerServiceManagedClusterData(DefaultLocation);
            clusterData.ServicePrincipalProfile = new ManagedClusterServicePrincipalProfile(Guid.Parse(TestEnvironment.ClientId));
            clusterData.ServicePrincipalProfile.Secret = TestEnvironment.ClientSecret;
            clusterData.DnsPrefix = Recording.GenerateAssetName("dns-");

            var agentPoolProfile = new ManagedClusterAgentPoolProfile("mypool");
            agentPoolProfile.VmSize = "standard_a2";
            agentPoolProfile.Count = 2;
            agentPoolProfile.Mode = AgentPoolMode.System;
            clusterData.AgentPoolProfiles.Add(agentPoolProfile);

            var createOp = await ResourceGroup.GetContainerServiceManagedClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            Assert.AreEqual(clusterName, createOp.Value.Id.Name);
        }
    }
}
