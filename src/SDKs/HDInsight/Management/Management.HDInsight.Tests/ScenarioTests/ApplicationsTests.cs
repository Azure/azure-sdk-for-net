// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Management.HDInsight.Tests
{
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using Microsoft.Rest.Azure;
    using Xunit;
    using System;
    using System.Collections.Generic;

    [Collection("ScenarioTests")]
    public class ApplicationsTests
    {
        [Fact]
        public void TestHueOnRunningCluster()
        {
            string clusterName = "hdisdk-applications-hue";
            string testName = "TestHueOnRunningCluster";
            string suiteName = GetType().FullName;

            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            createParams.Version = "3.6";
            createParams.EdgeNodeSize = "Large";
            
            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                string applicationName = "MyApplication";
                Application application = new Application
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
                                        VmSize = createParams.EdgeNodeSize
                                    },
                                    TargetInstanceCount = 1
                                }
                            }
                        }
                    }
                };

                client.Applications.Create(rgName, clusterName, applicationName, application);
                IPage<Application> listApplications = client.Applications.ListByCluster(rgName, clusterName);
                Assert.NotEmpty(listApplications);
                Assert.Single(listApplications, app => app.Name.Equals(applicationName, StringComparison.OrdinalIgnoreCase));

                client.Applications.Delete(rgName, clusterName, applicationName);
                listApplications = client.Applications.ListByCluster(rgName, clusterName);
                Assert.Empty(listApplications);
            });
        }
    }
}
