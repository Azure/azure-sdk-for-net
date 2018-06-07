// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Update.Admin;
using Models = Microsoft.AzureStack.Management.Update.Admin.Models;
using System.Linq;
using Xunit;

namespace Update.Tests
{
    public class Updates : UpdateTestBase
    {

        void ValidateUpdate(Models.Update update) {
            Assert.True(ValidResource(update));
            Assert.NotNull(update.DateAvailable);
            Assert.NotNull(update.Description);
            Assert.NotNull(update.InstalledDate);
            Assert.NotNull(update.KbLink);
            Assert.NotNull(update.MinVersionRequired);
            Assert.NotNull(update.PackagePath);
            Assert.NotNull(update.PackageSizeInMb);
            Assert.NotNull(update.PackageType);
            Assert.NotNull(update.Publisher);
            Assert.NotNull(update.State);
            Assert.NotNull(update.UpdateName);
            Assert.NotNull(update.UpdateOemFile);
            Assert.NotNull(update.Version);
        }

        void AssertAreSame(Models.Update expected, Models.Update found) {
            Assert.True(ResourceAreSame(expected, found));

            if (expected != null)
            {
                Assert.Equal(expected.DateAvailable, found.DateAvailable);
                Assert.Equal(expected.Description, found.Description);
                Assert.Equal(expected.InstalledDate, found.InstalledDate);
                Assert.Equal(expected.KbLink, found.KbLink);
                Assert.Equal(expected.MinVersionRequired, found.MinVersionRequired);
                Assert.Equal(expected.PackagePath, found.PackagePath);
                Assert.Equal(expected.PackageSizeInMb, found.PackageSizeInMb);
                Assert.Equal(expected.PackageType, found.PackageType);
                Assert.Equal(expected.Publisher, found.Publisher);
                Assert.Equal(expected.State, found.State);
                Assert.Equal(expected.KbLink, found.KbLink);
                Assert.Equal(expected.UpdateName, found.UpdateName);
                Assert.Equal(expected.UpdateOemFile, found.UpdateOemFile);
                Assert.Equal(expected.Version, found.Version);
            }
        }

        [Fact]
        public void TestListUpdates() {
            RunTest((client) => {
                var updateLocations = client.UpdateLocations.List("System.Redmond");
                updateLocations.ForEach((updateLocation) => {
                    var updates = client.Updates.List("System.Redmond", updateLocation.Name);
                    updates.ForEach(ValidateUpdate);
                    Common.WriteIEnumerableToFile(updates, "TestListUpdates.txt");
                });
            });
        }

        [Fact]
        public void TestGetUpdate() {
            RunTest((client) => {
                var updateLocation = client.UpdateLocations.List("System.Redmond").FirstOrDefault();
                Assert.NotNull(updateLocation);
                var update = client.Updates.List("System.Redmond", updateLocation.Name).FirstOrDefault();
                if (update != null)
                {
                    var returned = client.Updates.Get("System.Redmond", updateLocation.Name, update.Name);
                    AssertAreSame(update, returned);
                }
            });
        }

        [Fact]
        public void TestGetAllUpdates() {
            RunTest((client) => {
                var updateLocations = client.UpdateLocations.List("System.Redmond");
                updateLocations.ForEach((updateLocation) => {
                    var updates = client.Updates.List("System.Redmond", updateLocation.Name);
                    updates.ForEach((update) => {
                        var returned = client.Updates.Get("System.Redmond", updateLocation.Name, update.Name);
                        AssertAreSame(update, returned);
                    });
                });
            });
        }
    }
}
