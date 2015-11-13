﻿//
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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMSizesTests
    {
        [Fact]
        public void TestListVMSizes()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                string location = ComputeManagementTestUtilities.DefaultLocation.Replace(" ", "");

                var virtualMachineSizeListResponse = computeClient.VirtualMachineSizes.List(location);
                Helpers.ValidateVirtualMachineSizeListResponse(virtualMachineSizeListResponse);
            }
        }
    }
}