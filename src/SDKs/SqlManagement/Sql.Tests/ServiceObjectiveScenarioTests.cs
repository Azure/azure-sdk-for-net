// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Sql;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Sql.Tests
{
    public class ServiceObjectiveScenarioTests
    {
        [Fact]
        public void TestGetListServiceObjectives()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var serviceObjectives = sqlClient.ServiceObjectives.ListByServer(resourceGroup.Name, server.Name);

                foreach(ServiceObjective objective in serviceObjectives)
                {
                    Assert.NotNull(objective.ServiceObjectiveName);
                    Assert.NotNull(objective.IsDefault);
                    Assert.NotNull(objective.IsSystem);
                    Assert.NotNull(objective.Enabled);

                    // Assert Get finds the service objective from List
                    Assert.NotNull(sqlClient.ServiceObjectives.Get(resourceGroup.Name, server.Name, objective.Name));
                }
            }
        }
    }
}
