// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class CheckNameAvailabilityTests
    {
        [Fact]
        public void TestCheckServerNameAvailable()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTest(suiteName, "TestCheckServerNameAvailable", (resClient, sqlClient) =>
            {
                string serverName = SqlManagementTestUtilities.GenerateName(testPrefix);

                CheckNameAvailabilityResponse response = sqlClient.Servers.CheckNameAvailability(new CheckNameAvailabilityRequest
                {
                    Name = serverName
                });

                Assert.True(response.Available);
                Assert.Equal(serverName, response.Name);
                Assert.Equal(null, response.Message);
                Assert.Equal(null, response.Reason);
            });
        }

        [Fact]
        public void TestCheckServerNameInvalid()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTest(suiteName, "TestCheckServerNameInvalid", (resClient, sqlClient) =>
            {
                string serverName = SqlManagementTestUtilities.GenerateName(testPrefix).ToUpperInvariant(); // upper case is invalid

                CheckNameAvailabilityResponse response = sqlClient.Servers.CheckNameAvailability(new CheckNameAvailabilityRequest
                {
                    Name = serverName,
                });

                Assert.False(response.Available);
                Assert.Equal(serverName, response.Name);
                Assert.NotNull(response.Message);
                Assert.Equal(CheckNameAvailabilityReason.Invalid, response.Reason);
            });
        }

        [Fact]
        public void TestCheckServerNameAlreadyExists()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCheckServerNameAlreadyExists", testPrefix, (resClient, sqlClient, rg, server) =>
            {
                // Check name of a server that we know exists (because we just created it)
                CheckNameAvailabilityResponse response = sqlClient.Servers.CheckNameAvailability(new CheckNameAvailabilityRequest
                {
                    Name = server.Name
                });

                Assert.False(response.Available);
                Assert.Equal(server.Name, response.Name);
                Assert.NotNull(response.Message);
                Assert.Equal(CheckNameAvailabilityReason.AlreadyExists, response.Reason);
            });
        }
    }
}
