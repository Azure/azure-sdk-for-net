// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseRestoreScenarioTests
    {
        [Fact]
        public void TestDatabasePointInTimeRestore()
        {
            // Warning: This test takes around 35 minutes to run in record mode.

            string testPrefix = "sqlrestoretest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestDatabasePointInTimeRestore", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create database with only required parameters
                string db2Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, db2Name, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // If earliest restore time is in the future, we need to wait until then.
                // Add some padding in case of clock skew between Azure and this machine.
                // Beware this wait is at least 10 minutes long. Note that this is specifically
                // written so that it will actually be 0 wait when in playback mode.
                WaitUntil(db1.EarliestRestoreDate.Value.AddMinutes(1));

                // Create a new database that is the first database restored to an earlier point in time
                db2Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db2Input = new Database()
                {
                    Location = server.Location,
                    CreateMode = CreateMode.PointInTimeRestore,
                    RestorePointInTime = db1.EarliestRestoreDate.Value,
                    SourceDatabaseId = db1.Id
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, db2Name, db2Input);
                Assert.NotNull(db2);
                SqlManagementTestUtilities.ValidateDatabase(db2Input, db2, db2Name);

                // Delete the original database
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db1.Name);

                // Wait until the final backup is created and the restorable dropped database exists.
                // This could be up to 10 minutes after the database is deleted, and the database must already
                // have a backup (which was accomplished by the previous wait period). Let's wait up to 15
                // just to give it a little more room.
                IEnumerable<RestorableDroppedDatabase> droppedDatabases;
                DateTime startTime = DateTime.UtcNow;
                TimeSpan timeout = TimeSpan.FromMinutes(15);
                do
                {
                    droppedDatabases = sqlClient.RestorableDroppedDatabases.ListByServer(resourceGroup.Name, server.Name);

                    if (droppedDatabases.Any())
                    {
                        // Dropped database now exists. Exit polling loop.
                        break;
                    }

                    // Sleep if we are running live to avoid hammering the server.
                    // No need to sleep if we are playing back the recording.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                } while (DateTime.UtcNow < startTime + timeout);

                // Assert that we found a restorable db before timeout ended.
                Assert.True(droppedDatabases.Any(), "No dropped databases were found after waiting for " + timeout);

                // The original database should now exist as a restorable dropped database
                var droppedDatabase = droppedDatabases.Single();
                Assert.StartsWith(db1.Name, droppedDatabase.Name);

                // Restore the deleted database using restorable dropped database id
                var db3Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db3Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.Restore,
                    SourceDatabaseId = droppedDatabase.Id,
                    RestorePointInTime = droppedDatabase.EarliestRestoreDate // optional param for Restore
                };
                var db3Response = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db3Name, db3Input);

                // Concurrently (to make test faster) also restore the deleted database using its original id
                // and deletion date
                var db4Name = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db4Input = new Database
                {
                    Location = server.Location,
                    CreateMode = CreateMode.Restore,
                    SourceDatabaseId = db1.Id,
                    SourceDatabaseDeletionDate = droppedDatabase.DeletionDate,
                    RestorePointInTime = droppedDatabase.EarliestRestoreDate // optional param for Restore
                };
                var db4Response = sqlClient.Databases.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, db4Name, db4Input);

                // Wait for completion
                sqlClient.GetPutOrPatchOperationResultAsync(db3Response.Result, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();
                sqlClient.GetPutOrPatchOperationResultAsync(db4Response.Result, new Dictionary<string, List<string>>(), CancellationToken.None).Wait();
            });
        }

        private static void WaitUntil(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Invalid DateTimeKind. Expected DateTimeKind.Utc, actual " + dateTime.Kind);
            }

            TimeSpan waitDelay = dateTime.Subtract(DateTime.UtcNow);
            if (waitDelay > TimeSpan.Zero)
            {
                Thread.Sleep(waitDelay);
            }
        }

        [Fact]
        public void TestLongTermRetentionCrud()
        {
        }
    }
}
