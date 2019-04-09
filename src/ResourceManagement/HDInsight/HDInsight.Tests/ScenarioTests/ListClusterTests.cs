﻿//
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

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Test;
using System.Linq;
using Xunit;
using Microsoft.Azure.Management.ResourceManager;

namespace HDInsight.Tests
{
    public class ListClusterTests
    {
        public ListClusterTests()
        {
            HyakTestUtilities.SetHttpMockServerMatcher();
        }

        [Fact(Skip = "Test case will list all clusters under a subscription.")]
        public void TestListClustersInSubscription()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup1 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                var resourceGroup2 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname1 = "hdisdk-paas1";
                const string dnsname2 = "hdisdk-paas2";
                const string dnsname3 = "hdisdk-paas3";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                //Parallel.Invoke(
                //    () => client.Clusters.Create(resourceGroup1, dnsname1, spec),
                //    () => client.Clusters.Create(resourceGroup1, dnsname2, spec),
                //    () => client.Clusters.Create(resourceGroup2, dnsname3, spec));

                var listresponse = client.Clusters.List();
                Assert.Equal(3, listresponse.Clusters.Count);
                Assert.Contains(listresponse.Clusters, c => c.Name.Equals(dnsname1));
                Assert.Contains(listresponse.Clusters, c => c.Name.Equals(dnsname2));
                Assert.Contains(listresponse.Clusters, c => c.Name.Equals(dnsname3));

                Parallel.Invoke(
                    () => client.Clusters.Delete(resourceGroup1, dnsname1),
                    () => client.Clusters.Delete(resourceGroup1, dnsname2),
                    () => client.Clusters.Delete(resourceGroup2, dnsname3));
            }
        }

        [Fact(Skip = "This test case will be skipped.")]
        public void TestListClustersByResourceGroup()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup1 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                var resourceGroup2 = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                const string dnsname1 = "hdisdk-paas01";
                const string dnsname2 = "hdisdk-paas02";
                const string dnsname3 = "hdisdk-paas03";

                var paasSpec = GetClusterSpecHelpers.GetPaasClusterSpec();

                Parallel.Invoke(
                    () => client.Clusters.Create(resourceGroup1, dnsname1, paasSpec),
                    () => client.Clusters.Create(resourceGroup1, dnsname2, paasSpec),
                    () => client.Clusters.Create(resourceGroup2, dnsname3, paasSpec)
                    );

                var listresponse1 = client.Clusters.ListByResourceGroup(resourceGroup1);
                //Assert.Equal(listresponse1.Clusters.Count, 2);
                //Assert.True(listresponse1.Clusters.Any(c => c.Name.Equals(dnsname1)));
                //Assert.True(listresponse1.Clusters.Any(c => c.Name.Equals(dnsname2)));

                var listresponse2 = client.Clusters.ListByResourceGroup(resourceGroup2);
                //Assert.Equal(listresponse2.Clusters.Count, 1);
                //Assert.True(listresponse2.Clusters.Any(c => c.Name.Equals(dnsname3)));

                client.Clusters.Delete(resourceGroup1, dnsname1);
                client.Clusters.Delete(resourceGroup1, dnsname2);
                client.Clusters.Delete(resourceGroup2, dnsname3);
            }
        }

        [Fact]
        public void TestListEmptyResourceGroup()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                var listResult = client.Clusters.ListByResourceGroup(resourceGroup);
                Assert.NotNull(listResult);
                Assert.Equal(0, listResult.Clusters.Count);

                resourceManagementClient.ResourceGroups.Delete(resourceGroup);
            }
        }

        [Fact]
        public void TestGetNonexistentCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);
                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                try
                {
                    client.Clusters.Get(resourceGroup, "nonexistentcluster");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        public void TestListNonexistentResourceGroup()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);

                try
                {
                    client.Clusters.ListByResourceGroup("nonexistentrg");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
        }
    }
}
