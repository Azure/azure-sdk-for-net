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
            var location = "southcentralus";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var serviceFabricClient = GetServiceFabricClient(context);

                var environment = "Windows";
                var clusterVersions = serviceFabricClient.ClusterVersions.ListByEnvironment(location, environment);

                Assert.NotNull(clusterVersions);
                var versions = clusterVersions.Value
                    .Select(c => new Tuple<string, string>(c.Id.Split('/')[5], c.Id.Split('/')[7]))
                    .Distinct();
                Assert.Single(versions);
                Assert.Equal(location, versions.First().Item1, ignoreCase:true, ignoreWhiteSpaceDifferences:true);
                Assert.Equal(environment, versions.First().Item2, ignoreCase: true, ignoreWhiteSpaceDifferences: true);
            }
        }

    }
}
