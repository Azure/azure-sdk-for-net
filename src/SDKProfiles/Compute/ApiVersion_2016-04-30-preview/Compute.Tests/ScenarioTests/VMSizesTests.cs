// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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