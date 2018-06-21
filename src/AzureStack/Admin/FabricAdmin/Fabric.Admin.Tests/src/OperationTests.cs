// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Fabric.Tests
{
    using Xunit;

    public class OperationTests : FabricTestBase
    {

        [Fact(Skip = "Need operation first, we run this in another test.")]
        public void TestGetComputeFabricOperations() {
            RunTest((client) => {
                // TODO
            });
        }

        [Fact(Skip = "Need operation first, we run this in another test.")]
        public void TestGetNetworkFabricOperations() {
            RunTest((client) => {
                // TODO
            });
        }
    }
}
