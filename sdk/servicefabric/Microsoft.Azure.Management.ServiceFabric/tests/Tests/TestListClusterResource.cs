// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceFabric.Tests.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.ServiceFabric;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;

    public class TestListClusterResource : ServiceFabricTestBase
    {
        [Fact]
        public void TestList()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var clusters = serviceFabricClient.Clusters.List();

                Assert.NotNull(clusters);
                Assert.NotNull(clusters);
                var subscriptions = clusters.Value.GroupBy(c => c.Id).Select(r => r.Key.Split('/')[2]).Distinct();
                Assert.Single(subscriptions);
            }
        }

        [Fact]
        public void TestListByResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var resouceClient = GetResourceManagementClient(context);
                var resourceGroups = resouceClient.ResourceGroups.List();
                foreach (var rg in resourceGroups)
                {
                    var resources = GetAllServiceFabricClusterResources(context, rg);
                    if (resources.Any())
                    {
                        var clusters = serviceFabricClient.Clusters.ListByResourceGroup(rg.Name);
                        Assert.NotNull(clusters);

                        var res1 = resources.Select(r => r.Name).OrderBy(r => r).ToList();
                        var res2 = clusters.Value.Select(
                          c => c.Name).OrderBy(r => r).ToList();

                        Assert.Equal(res1.Count, res2.Count);

                        for (int i = 0; i < res1.Count; i++)
                        {
                            Assert.True(res1[i] == res2[i]);
                        }

                        break;
                    }
                }
            }
        }
    }
}
