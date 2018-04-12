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

    public class BackupLocationTests : BackupTestBase
    {

        private void ValidateBackupLocation(BackupLocation location)
        {
            Assert.NotNull(location);

            // Resource properties
            Assert.NotNull(location.Id);
            Assert.NotNull(location.Type);
            Assert.NotNull(location.Name);
            Assert.NotNull(location.Location);

            // Backup location properties
            // TODO: Check with teams.
        }

        private void AssertSame(BackupLocation expected, BackupLocation given)
        {
            if (expected == null)
            {
                Assert.Null(given);
            }
            else
            {
                Assert.NotNull(given);

                // Resource properties
                Assert.Equal(expected.Id.ToLower(), given.Id.ToLower());
                Assert.Equal(expected.Type, given.Type);
                Assert.Equal(expected.Name, given.Name);
                Assert.Equal(expected.Location, given.Location);

                // Location properties
                Assert.Equal(expected.AvailableCapacity, given.AvailableCapacity);
                Assert.Equal(expected.BackupFrequencyInHours, given.BackupFrequencyInHours);
                Assert.Equal(expected.EncryptionKeyBase64, given.EncryptionKeyBase64);
                Assert.Equal(expected.IsBackupSchedulerEnabled, given.IsBackupSchedulerEnabled);
                Assert.Equal(expected.LastBackupTime, given.LastBackupTime);
                Assert.Equal(expected.NextBackupTime, given.NextBackupTime);
                Assert.Equal(expected.LastBackupTime, given.LastBackupTime);
                Assert.Equal(expected.Password, given.Password);
                Assert.Equal(expected.Path, given.Path);
                Assert.Equal(expected.UserName, given.UserName);

            }
        }

        [Fact]
        public void TestListBackupLocations()
        {
            RunTest((client) =>
            {
                var backupLocations = client.BackupLocations.List(ResourceGroupName);
                Common.MapOverIPage(backupLocations, client.BackupLocations.ListNext, ValidateBackupLocation);
            });
        }

        [Fact]
        public void TestGetBackupLocation()
        {
            RunTest((client) =>
            {
                var backupLocations = client.BackupLocations.List(ResourceGroupName);
                var backupLocation = backupLocations.GetFirst();
                var result = client.BackupLocations.Get(ResourceGroupName, backupLocation.Name);
                AssertSame(backupLocation, result);
            });
        }

        [Fact]
        public void TestGetAllBackupLocation()
        {
            RunTest((client) =>
            {
                var backupLocations = client.BackupLocations.List(ResourceGroupName);
                Common.MapOverIPage(backupLocations, client.BackupLocations.ListNext, (backupLocation) =>
                {
                    var result = client.BackupLocations.Get(ResourceGroupName, backupLocation.Name);
                    AssertSame(backupLocation, result);
                });
            });
        }

        [Fact]
        public void TestUpdateBackupLocation()
        {
            RunTest((client) =>
            {

                var backupLocation = client.BackupLocations.Get(ResourceGroupName, "local");

                backupLocation.Path = @"\\100.68.73.194\Share";
                backupLocation.UserName = @"Administrator";
                backupLocation.Password = "password";
                backupLocation.EncryptionKeyBase64 = "YVVOa0J3S2xTamhHZ1lyRU9wQ1pKQ0xWanhjaHlkaU5ZQnNDeHRPTGFQenJKdWZsRGtYT25oYmlaa1RMVWFKeQ==";

                var result = client.BackupLocations.Update(ResourceGroupName, "local", backupLocation);
                Assert.NotNull(result);

                result.Path = null;
                result.UserName = null;
                result.Password = null;
                result.EncryptionKeyBase64 = null;

                result = client.BackupLocations.Update(ResourceGroupName, "local", result);

                Assert.Null(result.Path);
                Assert.Null(result.UserName);
                Assert.Empty(result.Password);
                Assert.Empty(result.EncryptionKeyBase64);

            }, null, null, System.Net.HttpStatusCode.OK, false);
        }

        [Fact]
        public void TestCreateBackup()
        {
            RunTest((client) =>
            {
                var backup = client.BackupLocations.CreateBackup(ResourceGroupName, "local");
                Assert.NotNull(backup);
            });
        }


    }
}
