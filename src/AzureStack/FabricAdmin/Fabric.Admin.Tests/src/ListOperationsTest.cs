// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin;
    using System.Linq;
    using Xunit;

    public class ListOperationsTest : FabricTestBase
    {
        [Fact]
        public void TestListOperations() {
            RunTest((client) => {
                var operations = client.Fabric.ListOperations();
                Assert.NotNull(operations);
                var numOperations = operations.Count();
                while (operations.NextPageLink != null)
                {
                    operations = client.Fabric.ListOperationsNext(operations.NextPageLink);
                    numOperations += operations.Count();
                }
                Assert.Null(operations.NextPageLink);
                Assert.Equal(12, numOperations);
            });
        }
    }
}
