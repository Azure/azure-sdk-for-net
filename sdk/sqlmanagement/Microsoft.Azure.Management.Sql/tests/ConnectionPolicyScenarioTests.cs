// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class ConnectionPolicyScenarioTests
    {
        [Fact]
        public void TestServerConnectionPolicy()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);

                // Get initial connection policy
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                ServerConnectionPolicy policy = sqlClient.ServerConnectionPolicies.Get(resourceGroup.Name, server.Name);
                Assert.Equal(ServerConnectionType.Default, policy.ConnectionType);

                // Update connection policy
                policy = sqlClient.ServerConnectionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, new ServerConnectionPolicy(ServerConnectionType.Proxy));
                Assert.Equal(ServerConnectionType.Proxy, policy.ConnectionType);

                // Get again
                policy = sqlClient.ServerConnectionPolicies.Get(resourceGroup.Name, server.Name);
                Assert.Equal(ServerConnectionType.Proxy, policy.ConnectionType);
            }
        }
    }
}
