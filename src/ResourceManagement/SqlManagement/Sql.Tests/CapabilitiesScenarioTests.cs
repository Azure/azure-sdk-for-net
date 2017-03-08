// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Sql.Tests
{
    public class CapabilitiesScenarioTests
    {
        [Fact]
        public void TestGetCapabilities()
        {
            string login = "dummylogin";
            string password = "Un53cuRE!";
            string version12 = "12.0";
            string databaseName = "testdb";
            string testPrefix = "sqlcrudtest-";
            Dictionary<string, string> tags = new Dictionary<string, string>();
            string suiteName = this.GetType().FullName;

            using (MockContext context = MockContext.Start(suiteName, "TestGetCapabilities"))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var resourceClient = SqlManagementTestUtilities.GetResourceManagementClient(context, handler);
                var sqlClient = SqlManagementTestUtilities.GetSqlManagementClient(context, handler);

                LocationCapabilities response = sqlClient.Capabilities.Get(SqlManagementTestUtilities.DefaultLocation);

                Assert.True(response.SupportedServerVersions.Count > 0);
                
                foreach (ServerVersionCapability supportedServerVersion in response.SupportedServerVersions)
                {
                    Assert.True(supportedServerVersion.SupportedEditions.Count > 0);
                    foreach (EditionCapability edition in supportedServerVersion.SupportedEditions)
                    {
                        Assert.True(edition.SupportedServiceLevelObjectives.Count > 0);
                        foreach (ServiceObjectiveCapability serviceObjective in edition.SupportedServiceLevelObjectives)
                        {
                            Assert.True(serviceObjective.SupportedMaxSizes.Count > 0);
                            Assert.NotEqual(null, serviceObjective.Unit);
                            Assert.NotEqual(null, serviceObjective.Value);
                        }
                    }
                }
            }
        }
    }
}
