// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;

namespace Management.HDInsight.Tests
{
    public class VirtualMachineOperationTests: HDInsightManagementTestBase
    {
        [Fact]
        public void TestListAndRestartHosts()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-nodereboot");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var hosts = HDInsightClient.VirtualMachines.ListHosts(CommonData.ResourceGroupName, clusterName);
            Assert.NotEmpty(hosts);

            var restartHosts = hosts.Where(host => host.Name.StartsWith("wn")).Take(1).Select(host => host.Name).ToList();

            HDInsightClient.VirtualMachines.RestartHosts(CommonData.ResourceGroupName, cluster.Name, restartHosts);
        }

        [Fact]
        public void TestListHosts()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-nodereboot");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Location = "South Central US";
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var hosts = HDInsightClient.VirtualMachines.ListHosts(CommonData.ResourceGroupName, clusterName);
            Assert.NotEmpty(hosts);
            Assert.NotEmpty(hosts[0].Fqdn);
        }
    }
}
