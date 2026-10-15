// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    public class ApiVersionOverrideTests
    {
        private static readonly Guid SubscriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001");

        [TestCase(false, "get", false)]
        [TestCase(false, "list", false)]
        [TestCase(false, "nextAbsolute", false)]
        [TestCase(false, "nextRelative", false)]
        [TestCase(true, "get", false)]
        [TestCase(true, "list", false)]
        [TestCase(true, "nextAbsolute", false)]
        [TestCase(true, "nextRelative", false)]
        [TestCase(false, "get", true)]
        [TestCase(false, "list", true)]
        [TestCase(false, "nextAbsolute", true)]
        [TestCase(false, "nextRelative", true)]
        [TestCase(true, "get", true)]
        [TestCase(true, "list", true)]
        [TestCase(true, "nextAbsolute", true)]
        [TestCase(true, "nextRelative", true)]
        public void LegacyRequestsResolveResourceApiVersion(bool discoveredSolutions, string operation, bool hasOverride)
        {
            var options = new ArmClientOptions();
            var pipeline = HttpPipelineBuilder.Build(options);
            var diagnostics = new ClientDiagnostics(options);
            var endpoint = new Uri("https://management.azure.com");
            string resourceType = discoveredSolutions
                ? "Microsoft.Security/locations/discoveredSecuritySolutions"
                : "Microsoft.Security/locations/allowedConnections";
            string overrideVersion = hasOverride ? "2099-01-01" : null;
            int lookups = 0;
            string ResolveVersion(ResourceType type)
            {
                Assert.That(type.ToString(), Is.EqualTo(resourceType));
                lookups++;
                return overrideVersion;
            }

            // A stale next-link version must be replaced without losing the paging token.
            var nextPage = new Uri(operation == "nextRelative"
                ? "/subscriptions/next?api-version=stale&skiptoken=token"
                : "https://management.azure.com/subscriptions/next?api-version=stale&skiptoken=token",
                operation == "nextRelative" ? UriKind.Relative : UriKind.Absolute);
            HttpMessage message;
            if (discoveredSolutions)
            {
                var client = new DiscoveredSecuritySolutions(diagnostics, pipeline, null, endpoint, "2020-01-01", ResolveVersion);
                message = operation switch
                {
                    "get" => client.CreateGetRequest(SubscriptionId, "group", "eastus", "solution", null),
                    "list" => client.CreateGetByHomeRegionRequest(SubscriptionId, "eastus", null),
                    _ => client.CreateNextGetByHomeRegionRequest(nextPage, SubscriptionId, "eastus", null)
                };
            }
            else
            {
                var client = new AllowedConnections(diagnostics, pipeline, null, endpoint, "2020-01-01", ResolveVersion);
                message = operation switch
                {
                    "get" => client.CreateGetRequest(SubscriptionId, "group", "eastus", "connection", null),
                    "list" => client.CreateGetByHomeRegionRequest(SubscriptionId, "eastus", null),
                    _ => client.CreateNextGetByHomeRegionRequest(nextPage, SubscriptionId, "eastus", null)
                };
            }

            using (message)
            {
                var uri = message.Request.Uri.ToUri();
                Assert.That(uri.Query, Does.Contain("api-version=" + (overrideVersion ?? "2020-01-01")));
                Assert.That(uri.Query, Does.Not.Contain("stale"));
                if (operation.StartsWith("next", StringComparison.Ordinal))
                {
                    Assert.That(uri.Query, Does.Contain("skiptoken=token"));
                }
                Assert.That(lookups, Is.EqualTo(1));
            }
        }
    }
}
