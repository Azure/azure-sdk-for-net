using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HDInsight.Tests.UnitTests
{
    public class ClusterCreateDefaultVmTypeTests
    {
        [Fact]
        public void TestDefaultVmTypes()
        {
            AssertDefaultVmTypes("hadoop", "Standard_D3", "Standard_D3");
            AssertDefaultVmTypes("spark", "Standard_D12", "Standard_D12");
            AssertDefaultVmTypes("InteractiveHive", "Standard_D13_v2", "Standard_D13_v2");
            AssertDefaultVmTypes("hbase", "Large", "Standard_D3");
        }

        public void AssertDefaultVmTypes(string clusterType, string expectedheadNodeVmType, string expectedWorkerNodeVmType)
        {
            var createParams = new ClusterCreateParameters()
            {
                ClusterType = clusterType,
            };

            Assert.Equal(expectedheadNodeVmType, ClusterOperations.GetHeadNodeSize(createParams));
            Assert.Equal(expectedWorkerNodeVmType, ClusterOperations.GetWorkerNodeSize(createParams));
        }
    }
}
