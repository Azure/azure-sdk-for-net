// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities;
using Microsoft.Rest.Azure;
using Xunit;

namespace SqlVirtualMachine.Tests
{
    public class AvailabilityGroupListenersScenarioTest
    {
        [Fact]
        public void TestCreateListDeleteAvailabilityGroupListeners()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                string groupName = "test-group";
                string agListenerName = "AGListener";
                IAvailabilityGroupListenersOperations sqlOperations = context.getSqlClient().AvailabilityGroupListeners;
                
                // Create AG listener
                AvailabilityGroupListener agListener = SqlVirtualMachineTestBase.CreateAGListener(context, agListenerName, groupName);

                // Recover
                AvailabilityGroupListener agListener2 = sqlOperations.Get(context.resourceGroup.Name, groupName, agListener.Name);
                SqlVirtualMachineTestBase.ValidateAGListener(agListener, agListener2);

                // List
                IPage<AvailabilityGroupListener> list = sqlOperations.ListByGroup(context.resourceGroup.Name, groupName);
                foreach (AvailabilityGroupListener ag in list)
                {
                    if (ag.Id.Equals(agListener.Id))
                    {
                        SqlVirtualMachineTestBase.ValidateAGListener(agListener, ag);
                    }
                }

                // Delete AG listener
                sqlOperations.Delete(context.resourceGroup.Name, groupName, agListenerName);
                list = sqlOperations.ListByGroup(context.resourceGroup.Name, groupName);
                Assert.False(list.GetEnumerator().MoveNext());   
            }
        }
    }
}
