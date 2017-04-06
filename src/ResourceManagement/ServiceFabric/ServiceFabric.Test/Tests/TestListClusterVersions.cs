using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServiceFabric.Tests.Tests
{
    public class TestListClusterVersions : ServiceFabricTestBase
    {
        [Fact]
        public void TestList()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var serviceFabricClient = GetServiceFabricClient(context);
                var clusterVersions = serviceFabricClient.ClusterVersions.List("southcentralus","Windows");

                Assert.NotNull(clusterVersions);
                Assert.NotNull(clusterVersions);
                var versions = clusterVersions.GroupBy(c => c.Id).Select(r => r.Key.Split('/')[2]).Distinct();
                Assert.Equal(versions.Count(), 1);

                clusterVersions = serviceFabricClient.ClusterVersions.List("southcentralus", "default");

                Assert.NotNull(clusterVersions);
                Assert.NotNull(clusterVersions);
                versions = clusterVersions.GroupBy(c => c.Id).Select(r => r.Key.Split('/')[2]).Distinct();
                Assert.Equal(versions.Count(), 1);
            }
        }

    }
}
