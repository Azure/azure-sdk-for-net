// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Microsoft.AzureStack.Management.Fabric.Admin.Models;
using Xunit;

namespace Fabric.Tests {
    
    public class FabricLocationTests : FabricTestBase {

        private void AssertFabricLocationEqual(FabricLocation expected, FabricLocation found) {
            if (expected == null) {
                Assert.Null(found);
            } else {
                Assert.True(FabricCommon.ResourceAreSame(expected, found));

                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);
                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.Type, found.Type);
            }
        }

        private void ValidateFabricLocation(FabricLocation location) {
            FabricCommon.ValidateResource(location);
        }

        [Fact]
        public void TestListFabricLocations() {
            RunTest((client) => {
                var locations = client.FabricLocations.List(Location);
                Common.MapOverIPage(locations, client.FabricLocations.ListNext, ValidateFabricLocation);
                Common.WriteIPagesToFile(locations, client.FabricLocations.ListNext, "ListFabricLocations.txt", (location) => location.Name);
            });
        }

        [Fact]
        public void TestGetFabricLocation() {
            RunTest((client) => {
                var location = client.FabricLocations.List(Location).GetFirst();
                if (location != null) {
                    var retrieved = client.FabricLocations.Get(Location, location.Name);
                    AssertFabricLocationEqual(location, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllFabricLocations() {
            RunTest((client) => {
                var locations = client.FabricLocations.List(Location);
                Common.MapOverIPage(locations, client.FabricLocations.ListNext, (location) => {
                    var retrieved = client.FabricLocations.Get(Location, location.Name);
                    AssertFabricLocationEqual(location, retrieved);
                });
            });
        }

    }
}
