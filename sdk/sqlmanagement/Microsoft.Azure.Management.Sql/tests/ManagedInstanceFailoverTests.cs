// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceFailoverTests
    {
        [Fact]
        public void FailoverPrimary()
        {
            using(SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var rg = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance managedInstance = context.CreateManagedInstance(rg);
                Assert.NotNull(managedInstance);
                var resourceGroupName = rg.Name;

                // Wait for first full backup to finish
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(6));
                }
                sqlClient.ManagedInstances.Failover(resourceGroupName, managedInstance.Name, ReplicaType.Primary);
            }
        }

        [Fact]
        public void FailoverReadableSecondaryInstance()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var rg = context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance managedInstance = context.CreateManagedInstance(rg);
                Assert.NotNull(managedInstance);
                var resourceGroupName = rg.Name;

                // Wait for first full backup to finish
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(6));
                }
                try
                {
                    sqlClient.ManagedInstances.Failover(resourceGroupName, managedInstance.Name, ReplicaType.ReadableSecondary);
                }
                catch (Exception ex)
                {
                    Assert.Contains("failover is not supported", ex.Message);
                }
            }
        }
    }
}