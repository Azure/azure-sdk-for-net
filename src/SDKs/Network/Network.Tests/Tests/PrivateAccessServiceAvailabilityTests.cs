// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Networks.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class PrivateAccessServiceAvailabilityTests
    {
        [Fact]
        public void CheckPrivateAccessServiceAvailabilityTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1, true);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                // Check Private Access Services availability API
                var responseAvailable = networkManagementClient.AvailablePrivateAccessServices.List(location);
                Assert.NotNull(responseAvailable);
            }
        }
    }
}