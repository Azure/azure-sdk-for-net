// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Update.Admin;
using Microsoft.AzureStack.Management.Update.Admin.Models;
using System.Linq;
using Xunit;

namespace Update.Tests
{
    public class UpdateLocations : UpdateTestBase
    {

        void ValidateUpdateLocation(UpdateLocation location) {
            Assert.True(ValidResource(location));
            Assert.NotNull(location.CurrentOemVersion);
            Assert.NotNull(location.CurrentVersion);
            Assert.NotNull(location.State);
        }

        void AssertAreSame(UpdateLocation expected, UpdateLocation found) {
            Assert.True(ResourceAreSame(expected, found));

            if (expected != null)
            {
                Assert.Equal(expected.CurrentOemVersion, found.CurrentOemVersion);
                Assert.Equal(expected.CurrentVersion, found.CurrentVersion);
                Assert.Equal(expected.LastUpdated, found.LastUpdated);
                Assert.Equal(expected.State, found.State);
            }
        }

        [Fact]
        public void TestListUpdateLocations() {
            RunTest((client) => {
                var list = client.UpdateLocations.List("System.Redmond");
                Common.WriteIEnumerableToFile(list, "TestListUpdateLocations");
                list.ForEach(ValidateUpdateLocation);
            });
        }

        [Fact]
        public void TestGetUpdateLocation() {
            RunTest((client) => {
                var updateLocation = client.UpdateLocations.List("System.Redmond").FirstOrDefault();
                var returned = client.UpdateLocations.Get("System.Redmond", updateLocation.Name);
                AssertAreSame(updateLocation, returned);
            });
        }

        [Fact]
        public void TestGetAllUpdateLocations() {
            RunTest((client) => {
                var list = client.UpdateLocations.List("System.Redmond");
                list.ForEach((updateLocation) => {
                    var returned = client.UpdateLocations.Get("System.Redmond", updateLocation.Name);
                    AssertAreSame(updateLocation, returned);
                }
                );
            });
        }
    }
}
