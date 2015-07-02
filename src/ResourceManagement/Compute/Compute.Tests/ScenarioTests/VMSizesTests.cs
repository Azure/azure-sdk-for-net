//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMSizesTests
    {
        [Fact]
        public void TestListVMSizes()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                var computeClient = ComputeManagementTestUtilities.GetComputeManagementClient();
                string location = ComputeManagementTestUtilities.DefaultLocation.Replace(" ", "");

                VirtualMachineSizeListResponse virtualMachineSizeListResponse = computeClient.VirtualMachineSizes.List(location);
                Assert.True(virtualMachineSizeListResponse.StatusCode == HttpStatusCode.OK);
                Helpers.ValidateVirtualMachineSizeListResponse(virtualMachineSizeListResponse);
            }
        }
    }
}