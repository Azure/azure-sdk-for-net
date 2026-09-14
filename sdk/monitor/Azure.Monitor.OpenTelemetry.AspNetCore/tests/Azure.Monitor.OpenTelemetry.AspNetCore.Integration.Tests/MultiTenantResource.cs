// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal sealed class MultiTenantResource
    {
        private MultiTenantResource(JsonElement resource)
        {
            ConnectionString = resource.GetProperty("connectionString").GetString()!;
            WorkspaceId = resource.GetProperty("workspaceId").GetString()!;
            ResourceId = resource.GetProperty("resourceId").GetString()!;
            Region = resource.GetProperty("region").GetString()!;
            var settings = new DbConnectionStringBuilder { ConnectionString = ConnectionString };
            Assert.That(settings.ContainsKey("InstrumentationKey") && settings.ContainsKey("IngestionEndpoint"), Is.True,
                "Each tenant requires a full connection string with an explicit ingestion endpoint.");
            InstrumentationKey = (string)settings["InstrumentationKey"];
            Endpoint = new Uri((string)settings["IngestionEndpoint"], UriKind.Absolute);
            Assert.That(Guid.TryParse(InstrumentationKey, out _), Is.True, "Invalid tenant instrumentation key.");
            Assert.That(Guid.TryParse(WorkspaceId, out _), Is.True, "A workspace GUID is required.");
            Assert.That(ResourceId, Does.StartWith("/subscriptions/").IgnoreCase);
            Assert.That(Region, Is.Not.Null.And.Not.Empty);
            Assert.That(Endpoint.Scheme, Is.EqualTo(Uri.UriSchemeHttps));
            Assert.That(Endpoint.UserInfo.Length + Endpoint.Query.Length + Endpoint.Fragment.Length, Is.Zero,
                "Ingestion endpoints must not contain credentials, queries, or fragments.");
        }

        internal string ConnectionString { get; }
        internal string WorkspaceId { get; }
        internal string ResourceId { get; }
        internal string Region { get; }
        internal string InstrumentationKey { get; }
        internal Uri Endpoint { get; }

        internal static IReadOnlyList<MultiTenantResource> Parse(string configuration)
        {
            MultiTenantResource[] resources;
            try
            {
                using var document = JsonDocument.Parse(configuration);
                resources = document.RootElement.EnumerateArray().Select(resource => new MultiTenantResource(resource)).ToArray();
            }
            catch (Exception exception) when (exception is JsonException or ArgumentException or FormatException or KeyNotFoundException or InvalidOperationException)
            {
                throw new InvalidOperationException("MONITOR_MULTI_TENANT_RESOURCES must be a JSON array of connectionString, workspaceId, resourceId, and region objects. Configuration values are omitted for security.");
            }

            Assert.That(resources.Length, Is.GreaterThanOrEqualTo(3), "At least three tenant destinations are required.");
            Assert.That(resources.Select(resource => resource.ResourceId).Distinct(StringComparer.OrdinalIgnoreCase).Count(), Is.EqualTo(resources.Length),
                "Tenant resource identities must be distinct.");
            Assert.That(resources.Select(resource => resource.InstrumentationKey).Distinct(StringComparer.OrdinalIgnoreCase).Count(), Is.EqualTo(resources.Length),
                "Tenant instrumentation keys must be distinct.");
            Assert.That(resources[0].Region, Is.EqualTo(resources[1].Region).IgnoreCase, "Tenants A/B must share a region.");
            Assert.That(resources[0].Region, Is.Not.EqualTo(resources[2].Region).IgnoreCase, "Tenant C must be in another region.");
            Assert.That(resources[0].Endpoint, Is.EqualTo(resources[1].Endpoint), "Tenants A/B must share an actual ingestion endpoint.");
            Assert.That(resources[0].Endpoint, Is.Not.EqualTo(resources[2].Endpoint), "Tenant C must use another actual ingestion endpoint.");
            return resources;
        }
    }
}
#endif