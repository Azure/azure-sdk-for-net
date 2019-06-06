// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
using Microsoft.Rest.Azure;
using System;
using System.Text;
using System.Collections.Generic;
using Xunit;


namespace InfrastructureInsights.Tests
{

    public class InfrastructureInsightsTestBase : AzureStackTestBase<InfrastructureInsightsAdminClient>
    {

        // Helpful funcs
        protected static Func<Resource, string> ResourceName = (resource) => resource.Name;
        protected static Func<Resource, string> ResourceId = (resource) => resource.Id;
        protected static Func<TrackedResource, string> ResourceLocation = (resource) => resource.Location;
        protected static Func<Resource, string> ResourceType = (resource) => resource.Type;

        protected override void ValidateClient(InfrastructureInsightsAdminClient client) {
            Assert.NotNull(client);

            Assert.NotNull(client.Alerts);
            Assert.NotNull(client.RegionHealths);
            // Assert.NotNull(client.ResourceHealthRegistrations);
            Assert.NotNull(client.ResourceHealths);
            // Assert.NotNull(client.ServiceHealthRegistrations);
            Assert.NotNull(client.ServiceHealths);

            Assert.False(String.IsNullOrEmpty(client.SubscriptionId));
        }

        public InfrastructureInsightsTestBase() {
        }

    }
}
