// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Backup.Tests
{
    using Microsoft.AzureStack.Management.Backup.Admin;
    using Microsoft.AzureStack.Management.Backup.Admin.Models;
    using System;
    using Xunit;

    public class BackupTests : BackupTestBase
    {

        private void ValidateBackups(Backup backup) {
            Assert.NotNull(backup);
        }

        private void AssertSame(Backup expected, Backup found) {
            if(expected == null)
            {
                Assert.Null(found);
            } else
            {
                Assert.NotNull(found);

                // Resource Group
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.Type, found.Type);
                Assert.Equal(expected.Location, found.Location);
            }
        }

        [Fact]
        public void TestListBackups() {
            RunTest((client) => {
                var backupLocations = client.BackupLocations.List(ResourceGroupName);
                backupLocations.ForEach((backupLocation) => {
                    var name = ExtractName(backupLocation.Name);
                    var backups = client.Backups.List(ResourceGroupName, name);
                    backups.ForEach(ValidateBackups);
                });
            });
        }

        [Fact]
        public void TestGetBackup() {
            RunTest((client) => {
                var backupLocations = client.BackupLocations.List(ResourceGroupName);
                backupLocations.ForEach((backupLocation) => {
                    var blName = ExtractName(backupLocation.Name);
                    var backups = client.Backups.List(ResourceGroupName, blName);
                    foreach(var backup in backups)
                    {
                        var bName = ExtractName(backup.Name);
                        client.Backups.Get(ResourceGroupName, blName, bName);
                        return;
                    }
                });
            });
        }

        [Fact]
        public void TestRestoreBackup()
        {
            RunTest((client) =>
            {
                var backupLocation = "local";
                var backup = client.BackupLocations.CreateBackup(ResourceGroupName, backupLocation);
                Assert.NotNull(backup);
                client.Backups.Restore(backupLocation, ResourceGroupName, backup.BackupId);
            });
        }
    }
}
