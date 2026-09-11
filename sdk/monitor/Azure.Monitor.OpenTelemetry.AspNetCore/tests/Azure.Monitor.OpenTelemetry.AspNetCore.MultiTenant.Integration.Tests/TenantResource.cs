// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Data.Common;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal sealed class TenantResource
    {
        internal TenantResource(string name, string connectionString, string workspaceId, string resourceId)
        {
            Assert.That(name, Is.Not.Null.And.Not.Empty);
            Assert.That(Guid.TryParse(workspaceId, out _), Is.True, "workspaceId must be the workspace GUID.");
            Assert.That(resourceId, Does.StartWith("/subscriptions/").IgnoreCase);
            var settings = new DbConnectionStringBuilder { ConnectionString = connectionString };
            Assert.That(settings.ContainsKey("InstrumentationKey"), Is.True);
            Assert.That(settings.ContainsKey("IngestionEndpoint"), Is.True, "Use the full resource connection string with an explicit ingestion endpoint.");
            Name = name;
            ConnectionString = connectionString;
            WorkspaceId = workspaceId;
            ResourceId = resourceId;
            InstrumentationKey = (string)settings["InstrumentationKey"];
            Endpoint = new Uri((string)settings["IngestionEndpoint"]);
            Assert.That(Guid.TryParse(InstrumentationKey, out _), Is.True);
            Assert.That(Endpoint.Scheme, Is.EqualTo(Uri.UriSchemeHttps));
        }

        internal string Name { get; }
        internal string ConnectionString { get; }
        internal string WorkspaceId { get; }
        internal string ResourceId { get; }
        internal string InstrumentationKey { get; }
        internal Uri Endpoint { get; }
    }
}
#endif