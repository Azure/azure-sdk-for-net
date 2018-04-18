// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace KeyVault.Tests
{
    using Microsoft.AzureStack.Management.KeyVault.Admin;
    using Xunit;

    public class OperationTest : KeyVaultTestBase
    {

        [Fact(Skip ="ARM Compliance bug against KeyVault (waiting on fix)")]
        public void TestListOperations() {
            RunTest((client) => {
                var operations = client.Operations.List();
                Assert.NotNull(operations);
            });
        }

    }
}
