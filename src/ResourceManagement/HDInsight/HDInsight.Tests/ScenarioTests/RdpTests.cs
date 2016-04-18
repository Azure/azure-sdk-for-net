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

using System;
using System.Linq;
using System.Net;
using HDInsight.Tests.Helpers;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsight.Tests
{
    public class RdpTests
    {
        [Fact]
        public void TestDisableEnableRdp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                //get clients
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);
                
                //create resourcegroup
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                
                //set variables
                const string dnsname = "hdisdk-rdp1";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();
                
                var rdpdisable = new RDPSettingsParameters
                {
                    OsProfile = new OsProfile
                    {
                        WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                        {
                            RdpSettings = null
                        }
                    }
                };
                var rdpenable = new RDPSettingsParameters
                {
                    OsProfile = new OsProfile
                    {
                        WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                        {
                            RdpSettings = new RdpSettings
                            {
                                ExpiryDate = new DateTime(2016, 10, 20),
                                Password = "Password1!",
                                UserName = "rdpuser"
                            }
                        }
                    }
                };

                //test
                var cluster = client.Clusters.Create(resourceGroup, dnsname, spec);
                //Assert.True(
                //    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                //        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));

                client.Clusters.ConfigureRdpSettings(resourceGroup, dnsname, rdpdisable);
                cluster = client.Clusters.Get(resourceGroup, dnsname);
                Assert.False(
                    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));

                client.Clusters.ConfigureRdpSettings(resourceGroup, dnsname, rdpenable);
                cluster = client.Clusters.Get(resourceGroup, dnsname);
                Assert.True(
                    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));
                
                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }

        [Fact]
        public void TestDisableEnableRdpCustomCode()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                //get clients
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                //create resourcegroup
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                //set variables
                const string dnsname = "hdisdk-rdpcluster0";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                //test
                var cluster = client.Clusters.Create(resourceGroup, dnsname, spec);
                Assert.True(
                    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));

                client.Clusters.DisableRdp(resourceGroup, dnsname);
                cluster = client.Clusters.Get(resourceGroup, dnsname);
                Assert.False(
                    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));

                client.Clusters.EnableRdp(resourceGroup, dnsname, "rdpuser", "Password1!", new DateTime(2016, 10, 12));
                cluster = client.Clusters.Get(resourceGroup, dnsname);
                Assert.True(
                    cluster.Cluster.Properties.ConnectivityEndpoints.Any(
                        c => c.Name.Equals("RDP", StringComparison.OrdinalIgnoreCase)));

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }
    }
}
