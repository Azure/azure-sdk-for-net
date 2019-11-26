// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class SlbMuxInstanceTests : FabricTestBase
    {

        private void AssertSlbMuxInstancesAreSame(SlbMuxInstance expected, SlbMuxInstance found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                if (expected.BgpPeers == null)
                {
                    Assert.Null(found.BgpPeers);
                }
                else
                {
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
                OverFabricLocations(client, (fabricLocationName) => {
                    var slbMuxInstances = client.SlbMuxInstances.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(slbMuxInstances, client.SlbMuxInstances.ListNext, ValidateSlbMuxInstance);
                    Common.WriteIPagesToFile(slbMuxInstances, client.SlbMuxInstances.ListNext, "ListSlbMuxInstances.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetSlbMuxInstance() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var slbMuxInstance = client.SlbMuxInstances.List(ResourceGroupName, fabricLocationName).GetFirst();
                var slbMuxInstanceName = ExtractName(slbMuxInstance.Name);
                var retrieved = client.SlbMuxInstances.Get(ResourceGroupName, fabricLocationName, slbMuxInstanceName);
                AssertSlbMuxInstancesAreSame(slbMuxInstance, retrieved);
            });
        }

        [Fact]
        public void TestGetAllSlbMuxInstances() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var slbMuxInstances = client.SlbMuxInstances.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(slbMuxInstances, client.SlbMuxInstances.ListNext, (slbMuxInstance) => {
                        var slbMuxInstanceName = ExtractName(slbMuxInstance.Name);
                        var retrieved = client.SlbMuxInstances.Get(ResourceGroupName, fabricLocationName, slbMuxInstanceName);
                        AssertSlbMuxInstancesAreSame(slbMuxInstance, retrieved);
                    });
                });
            });
        }
    }
}
