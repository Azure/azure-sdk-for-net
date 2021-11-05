// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;
using System.Threading;
using System.Linq;

namespace Microsoft.Azure.Management.Quantum.Tests
{
    public class OperationsTests : QuantumManagementTestBase
    {
        [Fact]
        public void TestListOperations()
        {
            TestInitialize();

            var firstPage = QuantumClient.Operations.List();
            var operations = QuantumManagementTestUtilities.ListResources(firstPage, QuantumClient.Operations.ListNext);
            Assert.True(operations.Count >= 1);
            var workspaceRead = operations.FirstOrDefault((operation) => "Microsoft.Quantum/Workspaces/Read".Equals(operation.Name));
            Assert.NotNull(workspaceRead);
        }
    }
}