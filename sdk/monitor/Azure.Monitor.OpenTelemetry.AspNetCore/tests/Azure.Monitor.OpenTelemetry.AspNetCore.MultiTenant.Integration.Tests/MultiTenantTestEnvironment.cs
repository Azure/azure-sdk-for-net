// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class MultiTenantTestEnvironment : AzureMonitorTestEnvironment
    {
        internal IReadOnlyList<TenantResource> LoadResources()
        {
            var configuration = GetOptionalVariable("MULTI_TENANT_RESOURCES");
            if (string.IsNullOrWhiteSpace(configuration))
            {
                Assert.That(GetOptionalVariable("MULTI_TENANT_REQUIRED"), Is.Not.EqualTo("true").IgnoreCase,
                    "Required CI resources are missing: MONITOR_MULTI_TENANT_RESOURCES must come from deployment outputs.");
                Assert.Ignore("Set MONITOR_MULTI_TENANT_RESOURCES to enable the dedicated multi-tenant live tests. See this project's README.md.");
            }
            return ParseResources(configuration!);
        }

        internal static IReadOnlyList<TenantResource> ParseResources(string json)
        {
            using var document = JsonDocument.Parse(json);
            var resources = document.RootElement.EnumerateArray().Select(element => new TenantResource(
                element.GetProperty("name").GetString()!,
                element.GetProperty("connectionString").GetString()!,
                element.GetProperty("workspaceId").GetString()!,
                element.GetProperty("resourceId").GetString()!)).ToArray();

            Assert.That(resources.Length, Is.GreaterThanOrEqualTo(4), "Configure a host resource and at least three routed resources.");
            Assert.That(resources.Select(resource => resource.Name).Distinct().Count(), Is.EqualTo(resources.Length));
            Assert.That(resources.Select(resource => resource.InstrumentationKey).Distinct(StringComparer.OrdinalIgnoreCase).Count(), Is.EqualTo(resources.Length));
            Assert.That(resources.Select(resource => resource.ResourceId).Distinct(StringComparer.OrdinalIgnoreCase).Count(), Is.EqualTo(resources.Length));
            var endpointGroups = resources.Skip(1).GroupBy(resource => resource.Endpoint).ToArray();
            Assert.That(endpointGroups.Length, Is.GreaterThanOrEqualTo(2), "Routed resources must cover at least two ingestion endpoints.");
            Assert.That(endpointGroups.Any(group => group.Count() >= 2), Is.True, "At least two routed resources must share an ingestion endpoint.");
            return resources;
        }
    }
}
#endif