using Microsoft.Rest.Azure;
using Xunit;

using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
using Microsoft.AzureStack.TestFramework;

namespace InfrastructureInsights.Tests
{

    public class InfrastructureInsightsTestBase : TestBase<InfrastructureInsightsAdminClient>
    {

        // Helpful funcs
        protected static Func<Resource, string> ResourceName = (resource) => resource.Name;
        protected static Func<Resource, string> ResourceId = (resource) => resource.Id;
        protected static Func<Resource, string> ResourceLocation = (resource) => resource.Location;
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
