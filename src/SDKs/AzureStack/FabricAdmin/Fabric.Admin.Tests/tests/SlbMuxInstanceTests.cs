

using Xunit;

using Microsoft.AzureStack.TestFramework;
using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;

namespace Fabric.Tests {

    public class SlbMuxInstanceTests : FabricTestBase {

        private void AssertSlbMuxInstancesAreSame(SlbMuxInstance expected, SlbMuxInstance found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                if (expected.BgpPeers == null) {
                    Assert.Null(found.BgpPeers);
                } else {
                    Assert.Equal(expected.BgpPeers.Count, found.BgpPeers.Count);
                }
                Assert.Equal(expected.ConfigurationState, found.ConfigurationState);
                Assert.Equal(expected.VirtualServer, found.VirtualServer);
            }
        }

        private void ValidateSlbMuxInstance(SlbMuxInstance instance) {
            FabricCommon.ValidateResource(instance);

            Assert.NotNull(instance.BgpPeers);
            Assert.NotNull(instance.ConfigurationState);
            Assert.NotNull(instance.VirtualServer);
        }


        [Fact]
        public void TestListSlbMuxInstances() {
            RunTest((client) => {
                var slbMuxInstances = client.SlbMuxInstances.List(Location);
                Common.MapOverIPage(slbMuxInstances, client.SlbMuxInstances.ListNext, ValidateSlbMuxInstance);
                Common.WriteIPagesToFile(slbMuxInstances, client.SlbMuxInstances.ListNext, "ListSlbMuxInstances.txt", ResourceName);
            });
        }

        [Fact]
        public void TestGetSlbMuxInstance() {
            RunTest((client) => {
                var slbMuxInstance = client.SlbMuxInstances.List(Location).GetFirst();
                var retrieved = client.SlbMuxInstances.Get(Location, slbMuxInstance.Name);
                AssertSlbMuxInstancesAreSame(slbMuxInstance, retrieved);
            });
        }

        [Fact]
        public void TestGetAllSlbMuxInstances() {
            RunTest((client) => {
                var slbMuxInstances = client.SlbMuxInstances.List(Location);
                Common.MapOverIPage(slbMuxInstances, client.SlbMuxInstances.ListNext, (slbMuxInstance) => {
                    var retrieved = client.SlbMuxInstances.Get(Location, slbMuxInstance.Name);
                    AssertSlbMuxInstancesAreSame(slbMuxInstance, retrieved);
                });
            });
        }
        
    }
}
