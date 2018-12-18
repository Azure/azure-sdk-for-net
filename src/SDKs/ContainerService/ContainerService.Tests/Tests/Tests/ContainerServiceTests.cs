// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using ContainerService.Tests;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.ContainerService.Tests
{
    public class ContainerServiceTests : TestBase
    {
        /// <summary>
        /// Test the creation a container service instance.
        /// </summary>
        [Fact]
        public void ContainerInstanceCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerServiceTestUtilities.GetResourceManagementClient(context, handler);
                var containerServiceClient = ContainerServiceTestUtilities.GetContainerServiceManagementClient(context, handler);

                var resourceGroup = ContainerServiceTestUtilities.CreateResourceGroup(resourceClient);
            }
        }
    }
}
