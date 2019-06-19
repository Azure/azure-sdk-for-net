// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;
    using Xunit;

    public class ScaleUnitTests : FabricTestBase
    {
        private void AssertScaleUnitsAreSame(ScaleUnit expected, ScaleUnit found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.LogicalFaultDomain, found.LogicalFaultDomain);
                Assert.Equal(expected.Model, found.Model);

                if (expected.Nodes == null)
                {
                    Assert.Null(found.Nodes);
                }
                else
                {
                    Assert.Equal(expected.Nodes.Count, found.Nodes.Count);
                }

                Assert.Equal(expected.ScaleUnitType, found.ScaleUnitType);
                Assert.Equal(expected.State, found.State);

                if (expected.TotalCapacity == null)
                {
                    Assert.Null(found.TotalCapacity);
                }
                else
                {
                    Assert.Equal(expected.TotalCapacity.Cores, found.TotalCapacity.Cores);
                    Assert.Equal(expected.TotalCapacity.MemoryGB, found.TotalCapacity.MemoryGB);
                }

            }
        }

        private void ValidateScaleUnit(ScaleUnit scaleUnit) {
            FabricCommon.ValidateResource(scaleUnit);

            Assert.NotNull(scaleUnit.LogicalFaultDomain);
            Assert.NotNull(scaleUnit.ScaleUnitType);
            Assert.NotNull(scaleUnit.State);
            Assert.NotNull(scaleUnit.TotalCapacity);
        }


        [Fact]
        public void TestListScaleUnits() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var scaleUnits = client.ScaleUnits.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(scaleUnits, client.ScaleUnits.ListNext, ValidateScaleUnit);
                    Common.WriteIPagesToFile(scaleUnits, client.ScaleUnits.ListNext, "ListScaleUnits.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetScaleUnit() {
            RunTest((client) => {
                var fabricLocationName = GetLocation(client);
                var scaleUnit = client.ScaleUnits.List(ResourceGroupName, fabricLocationName).GetFirst();

                var scaleUnitName = ExtractName(scaleUnit.Name);
                var retrieved = client.ScaleUnits.Get(ResourceGroupName, fabricLocationName, scaleUnitName);
                AssertScaleUnitsAreSame(scaleUnit, retrieved);
            });
        }

        [Fact]
        public void TestGetAllScaleUnits() {
            RunTest((client) => {
                OverFabricLocations(client, (fabricLocationName) => {
                    var scaleUnits = client.ScaleUnits.List(ResourceGroupName, fabricLocationName);
                    Common.MapOverIPage(scaleUnits, client.ScaleUnits.ListNext, (scaleUnit) => {
                        var scaleUnitName = ExtractName(scaleUnit.Name);
                        var retrieved = client.ScaleUnits.Get(ResourceGroupName, fabricLocationName, scaleUnitName);
                        AssertScaleUnitsAreSame(scaleUnit, retrieved);
                    });
                });
            });
        }
    }
}
