// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class MultiTenantConfigurationTests
    {
        [Test]
        public void AcceptsDistinctResourcesSharingAWorkspace()
        {
            var resources = MultiTenantTestEnvironment.ParseResources(CreateConfiguration("valid"));
            Assert.That(resources.Count, Is.EqualTo(4));
            Assert.That(resources.Select(resource => resource.WorkspaceId).Distinct().Count(), Is.EqualTo(1));
        }

        [TestCase("duplicate-key")]
        [TestCase("one-endpoint")]
        [TestCase("no-shared-endpoint")]
        [TestCase("missing-endpoint")]
        public void RejectsIncompleteRoutingCoverage(string scenario)
        {
            Assert.Throws<AssertionException>(() => MultiTenantTestEnvironment.ParseResources(CreateConfiguration(scenario)));
        }

        private static string CreateConfiguration(string scenario)
        {
            var sharedKey = Guid.NewGuid();
            var workspaceId = Guid.NewGuid().ToString();
            var endpoints = scenario switch
            {
                "one-endpoint" => new[] { "host", "west", "west", "west" },
                "no-shared-endpoint" => new[] { "host", "west", "east", "north" },
                _ => new[] { "host", "west", "west", "east" }
            };
            return JsonSerializer.Serialize(endpoints.Select((endpoint, index) => new
            {
                name = $"resource-{index}",
                connectionString = $"InstrumentationKey={(scenario == "duplicate-key" ? sharedKey : Guid.NewGuid())};" +
                    (scenario == "missing-endpoint" ? string.Empty : $"IngestionEndpoint=https://{endpoint}.example/"),
                workspaceId,
                resourceId = $"/subscriptions/{Guid.NewGuid()}/resourceGroups/test/providers/Microsoft.Insights/components/resource-{index}"
            }));
        }
    }
}
#endif