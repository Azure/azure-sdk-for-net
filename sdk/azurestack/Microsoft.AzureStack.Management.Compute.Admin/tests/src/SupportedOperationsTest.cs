// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Compute.Tests
{
    using Microsoft.AzureStack.Management.Compute.Admin;
    using Microsoft.AzureStack.Management.Compute.Admin.Models;
    using System;
    using System.Linq;
    using Xunit;

    public class SupportedOperationsTests : ComputeTestBase
    {

        private void ValidateDisplay(Display display)
        {
            Assert.NotNull(display);
            Assert.NotNull(display.Provider);
            Assert.NotNull(display.Description);
            Assert.NotNull(display.Operation);
            Assert.NotNull(display.Resource);
        }

        private void ValidateOperation(Operation operation)
        {
            Assert.NotNull(operation);
            Assert.NotNull(operation.Name);
            ValidateDisplay(operation.Display);
        }

        [Fact(Skip = "Incorrect permissions,cannot access endpoint.")]
        public void TestListSupportedOperations()
        {
            RunTest((client) =>
            {
                var operations = client.Operations.List();
                Common.MapOverIPage(operations, client.Operations.ListNext, ValidateOperation);
            });
        }
    }
}
