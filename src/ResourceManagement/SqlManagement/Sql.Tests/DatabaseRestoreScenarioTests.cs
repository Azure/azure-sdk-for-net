using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
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
            // Warning: This test takes around 20 minutes to run in record mode.

            string testPrefix = "sqlrestoretest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestDatabasePointInTimeRestore", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create database only required parameters
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // If earliest restore time is in the future, we need to wait until then. Add some padding in case of clock skew
                // between Azure and this machine. Beware this wait is at least 10 minutes long.
                //
                DateTime waitUntil = db1.EarliestRestoreDate.Value.AddMinutes(1);
                TimeSpan waitDelay = waitUntil.Subtract(DateTime.UtcNow);
                if (waitDelay > TimeSpan.Zero)
                {
                    Thread.Sleep(waitDelay);
                }

                // Create a new database that is the first database restored to an earlier point in time
                // 
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db2Input = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    CreateMode = "PointInTimeRestore",
                    RestorePointInTime = db1.EarliestRestoreDate.Value,
                    SourceDatabaseId = db1.Id
                };
                var db2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, db2Input);
                Assert.NotNull(db2);
                SqlManagementTestUtilities.ValidateDatabase(db2Input, db2, dbName);

                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db1.Name);
                sqlClient.Databases.Delete(resourceGroup.Name, server.Name, db2.Name);
            });
        }
    }
}
