// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Xunit;
using System.Collections.Generic;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities;

namespace SqlVirtualMachine.Tests
{
    public class SqlVirtualMachinesScenarioTest
    {
        [Fact]
        public void TestCreateGetUpdateDeleteSqlVirtualMachine()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                // Create SQL VM
                ISqlVirtualMachinesOperations sqlOperations = context.getSqlClient().SqlVirtualMachines;
                Dictionary<string, SqlVirtualMachineModel> sqlVirtualMachines = new Dictionary<string, SqlVirtualMachineModel>();
                SqlVirtualMachineModel sqlVM = null;
                for (int i = 0; i < 3; i++)
                {
                    sqlVM = SqlVirtualMachineTestBase.CreateSqlVirtualMachine(context);
                    Assert.NotNull(sqlVM);
                    sqlVirtualMachines[sqlVM.Id] = sqlVM;
                }
                
                // Recover
                foreach (string id in sqlVirtualMachines.Keys)
                {
                    sqlVM = sqlOperations.Get(context.resourceGroup.Name, sqlVirtualMachines[id].Name);
                    Assert.NotNull(sqlVM);
                    SqlVirtualMachineTestBase.ValidateSqlVirtualMachine(sqlVM, sqlVirtualMachines[id]);
                }

                // Update
                string key = "test", value = "updateTag";
                sqlOperations.Update(context.resourceGroup.Name, sqlVM.Name, new SqlVirtualMachineUpdate
                {
                    Tags = new Dictionary<string, string>
                    {
                        { key, value }
                    }
                });
                SqlVirtualMachineModel sqlVM2 = sqlOperations.Get(context.resourceGroup.Name, sqlVM.Name);
                SqlVirtualMachineTestBase.ValidateSqlVirtualMachine(sqlVM, sqlVM2, sameTags: false);
                Assert.Equal(1, sqlVM2.Tags.Keys.Count);
                Assert.Equal(value, sqlVM2.Tags[key]);

                // Delete
                sqlOperations.Delete(context.resourceGroup.Name, sqlVM2.Name);
                sqlVirtualMachines.Remove(sqlVM2.Id);

                // List
                IPage<SqlVirtualMachineModel> recovered = sqlOperations.List();
                var iter = recovered.GetEnumerator();
                while (iter.MoveNext())
                {
                    sqlVM = iter.Current;
                    Assert.NotEqual(sqlVM.Id, sqlVM2.Id);
                    if (sqlVirtualMachines.ContainsKey(sqlVM.Id))
                    {
                        SqlVirtualMachineTestBase.ValidateSqlVirtualMachine(sqlVM, sqlVirtualMachines[sqlVM.Id]);
                        sqlVirtualMachines.Remove(sqlVM.Id);
                    }
                }
                Assert.Empty(sqlVirtualMachines.Keys);
                iter.Dispose();
            }
        }

        [Fact]
        public void TestListByGroupSqlVirtualMachine()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                // Create Sql VM
                ISqlVirtualMachinesOperations sqlOperations = context.getSqlClient().SqlVirtualMachines;
                SqlVirtualMachineModel sqlVM = SqlVirtualMachineTestBase.CreateSqlVirtualMachine(context);
                Assert.NotNull(sqlVM);

                // List by group
                IPage<SqlVirtualMachineModel> recovered = sqlOperations.ListByResourceGroup(context.resourceGroup.Name);
                var iter = recovered.GetEnumerator();
                Assert.NotNull(iter);
                iter.MoveNext();
                SqlVirtualMachineModel sqlVM2 = iter.Current;
                Assert.NotNull(sqlVM2);
                SqlVirtualMachineTestBase.ValidateSqlVirtualMachine(sqlVM, sqlVM2);
                Assert.False(iter.MoveNext());
                iter.Dispose();
            }
        }
    }
}
