// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.Azure;
using Xunit;

namespace SqlVirtualMachine.Tests
{
    public class OperationsScenarioTests
    {
        [Fact]
        public void TestListOperations()
        {
            using (SqlVirtualMachineTestContext context = new SqlVirtualMachineTestContext(this))
            {
                context.getSqlClient().Operations.ListWithHttpMessagesAsync();
            }
        }
    }
}
