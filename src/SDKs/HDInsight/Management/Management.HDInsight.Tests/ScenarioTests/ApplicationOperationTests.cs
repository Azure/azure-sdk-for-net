// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;

namespace Management.HDInsight.Tests
{
    public class ApplicationOperationTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestHueOnRunningCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-applications-hue");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            var cluster = HDInsightClient.Clusters.Create(
                CommonData.ResourceGroupName,
                clusterName,
                createParams);
            ValidateCluster(clusterName, createParams, cluster);

            string applicationName = "MyApplication";
            var application = new Application
            {
                Properties = new ApplicationProperties
                {
                    InstallScriptActions = new[]
                    {
                        new RuntimeScriptAction
                        {
                            Name = "InstallHue",
                            Uri = "https://hdiconfigactions.blob.core.windows.net/linuxhueconfigactionv02/install-hue-uber-v02.sh",
                            Parameters = "-version latest -port 20000",
                            Roles = new [] { "edgenode" }
                        }
                    },
                    ApplicationType = "CustomApplication",
                    ComputeProfile = new ComputeProfile
                    {
                        Roles = new List<Role>
                        {
                            new Role
                            {
                                Name = "edgenode",
                                HardwareProfile = new HardwareProfile
                                {
                                    VmSize = "Large"
                                },
                                TargetInstanceCount = 1
                            }
                        }
                    }
                }
            };

            HDInsightClient.Applications.Create(CommonData.ResourceGroupName, clusterName, applicationName, application);
            var applications = HDInsightClient.Applications.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.NotEmpty(applications);
            Assert.Single(applications, app => app.Name.Equals(applicationName, StringComparison.OrdinalIgnoreCase));

            var startTime = DateTime.UtcNow;
            var timeout = TimeSpan.FromMinutes(10);
            while (DateTime.UtcNow - startTime < timeout)
            {
                cluster = HDInsightClient.Clusters.Get(CommonData.ResourceGroupName, clusterName);
                if (cluster.Properties.ClusterState == "Running")
                {
                    break;
                }

                TestUtilities.Wait(TimeSpan.FromSeconds(10));
            }

            HDInsightClient.Applications.Delete(CommonData.ResourceGroupName, clusterName, applicationName);
            applications = HDInsightClient.Applications.ListByCluster(CommonData.ResourceGroupName, clusterName);
            Assert.Empty(applications);
        }
    }
}
