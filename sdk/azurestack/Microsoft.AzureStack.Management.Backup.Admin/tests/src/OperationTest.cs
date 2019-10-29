// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Backup.Tests
{
    using Microsoft.AzureStack.Management.Backup.Admin;
    using Microsoft.AzureStack.Management.Backup.Admin.Models;
    using Xunit;

    public class OperationTest : BackupTestBase
    {

        private void ValidateOperation(Operation op) {
            Assert.NotNull(op);

            Assert.NotNull(op.Display);
            Assert.NotNull(op.Name);

            Assert.NotNull(op.Display.Description);
            Assert.NotNull(op.Display.Operation);
            Assert.NotNull(op.Display.Provider);
            Assert.NotNull(op.Display.Resource);
        }
        
        [Fact]
        public void TestListBackupOperations() {
            RunTest((client) => {
                var operations = client.Operations.List();
                Assert.NotNull(operations);
                Common.MapOverIPage(operations, client.Operations.ListNext, ValidateOperation);
            });
        }
    }
}
