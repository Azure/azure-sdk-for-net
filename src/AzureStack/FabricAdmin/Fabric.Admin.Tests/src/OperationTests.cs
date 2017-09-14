// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Fabric.Admin;
using Xunit;

namespace Fabric.Tests {
    public class OperationTests : FabricTestBase {
        
        [Fact(Skip ="Need operation first, we run this in another test.")]
        public void TestGetComputeFabricOperations() {
            RunTest((client) => {
                client.ComputeFabricOperations.Get("storageFabricOperation", "Microsoft.Storage", Location);
            });
        }

        [Fact(Skip = "Need operation first, we run this in another test.")]
        public void TestGetNetworkFabricOperations() {
            RunTest((client) => {
                client.NetworkFabricOperations.Get("storageFabricOperation", "Microsoft.Storage", Location);
            });
        }
    }
}
