// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using Xunit;

namespace SqlVirtualMachine.Tests
{
    public class SqlVirtualMachineGroupScenarioTest
    {
        [Fact]
        public void TestCreateGetDeleteSqlVirtualMachineGroup()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                // Create SQL VM group
                ISqlVirtualMachineGroupsOperations sqlOperations = context.getSqlClient().SqlVirtualMachineGroups;
                StorageAccount storageAccount = VirtualMachineTestBase.CreateStorageAccount(context);
                SqlVirtualMachineGroup group = SqlVirtualMachineTestBase.CreateSqlVirtualMachineGroup(context, storageAccount, "test-group");
                
                // Recover
                SqlVirtualMachineGroup group2 = sqlOperations.Get(context.resourceGroup.Name, group.Name);
                SqlVirtualMachineTestBase.ValidateSqlVirtualMachineGroups(group, group2);

                // Delete
                sqlOperations.Delete(context.resourceGroup.Name, group.Name);

                // Recover
                IPage<SqlVirtualMachineGroup> list = sqlOperations.ListByResourceGroup(context.resourceGroup.Name);
                IEnumerator<SqlVirtualMachineGroup> iter = list.GetEnumerator();
                Assert.False(iter.MoveNext());
            }   
        }

        [Fact]
        public void TestListSqlVirtualMachineGroup()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                // Create SQL VM group
                ISqlVirtualMachineGroupsOperations sqlOperations = context.getSqlClient().SqlVirtualMachineGroups;
                StorageAccount storageAccount = VirtualMachineTestBase.CreateStorageAccount(context);
                SqlVirtualMachineGroup group = SqlVirtualMachineTestBase.CreateSqlVirtualMachineGroup(context, storageAccount, "test-group");

                // List
                IPage<SqlVirtualMachineGroup> list = sqlOperations.List();
                IEnumerator<SqlVirtualMachineGroup> iter = list.GetEnumerator();
                int count = 0;
                while(iter.MoveNext())
                {
                    SqlVirtualMachineGroup group2 = iter.Current;
                    if(group.Id.Equals(group2.Id))
                    {
                        SqlVirtualMachineTestBase.ValidateSqlVirtualMachineGroups(group, group2);
                        count++;
                    }
                }
                iter.Dispose();
                Assert.Equal(1, count);
            }
        }

        [Fact]
        public void TestCreateUpdateGetSqlVirtualMachineGroup()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                // Create SQL VM group
                ISqlVirtualMachineGroupsOperations sqlOperations = context.getSqlClient().SqlVirtualMachineGroups;
                StorageAccount storageAccount = VirtualMachineTestBase.CreateStorageAccount(context);
                SqlVirtualMachineGroup group = SqlVirtualMachineTestBase.CreateSqlVirtualMachineGroup(context, storageAccount, "test-group");

                // Update
                string key = "test", value = "updateTag";
                sqlOperations.Update(context.resourceGroup.Name, group.Name, new SqlVirtualMachineGroupUpdate()
                {
                    Tags = new Dictionary<string, string>
                    {
                        { key, value }
                    }
                });

                // Get
                SqlVirtualMachineGroup group2 = sqlOperations.Get(context.resourceGroup.Name, group.Name);
                SqlVirtualMachineTestBase.ValidateSqlVirtualMachineGroups(group, group2, false);
                Assert.Equal(1, group2.Tags.Keys.Count);
                Assert.Equal(value, group2.Tags[key]);
            }
        }
    }
}
