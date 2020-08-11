// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//


namespace Commerce.Tests
{

using Microsoft.AzureStack.Management.Commerce.Admin;
using Microsoft.AzureStack.Management.Commerce.Admin.Models;
using System;
using Xunit;

    public class SupportedOperationsTest : CommerceTestBase
    {

        private void ValidateDisplay(Display display) {
            Assert.NotNull(display);
            Assert.NotNull(display.Description);
            Assert.NotNull(display.Operation);
            Assert.NotNull(display.Provider);
            Assert.NotNull(display.Resource);
        }

        private void ValidateOperation(Operation op) {
            Assert.NotNull(op);
            Assert.NotNull(op.Name);
            ValidateDisplay(op.Display);
        }


        [Fact]
        public void TestListSupportedOperations() {
            RunTest((client) => {
                var operations = client.Operations.List();
                Assert.NotNull(operations);
                Common.MapOverIPage(operations, client.Operations.ListNext, ValidateOperation);
            });
        }

    }
}
