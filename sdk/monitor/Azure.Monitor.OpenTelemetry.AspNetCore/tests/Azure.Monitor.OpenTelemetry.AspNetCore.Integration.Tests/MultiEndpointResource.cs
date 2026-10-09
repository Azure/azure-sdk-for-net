// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text.Json;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    internal sealed class MultiEndpointResource
    {
        public string ConnectionString { get; set; } = null!;
        public string WorkspaceId { get; set; } = null!;
        public string ResourceId { get; set; } = null!;

        internal string InstrumentationKey
        {
            get
            {
                var settings = new DbConnectionStringBuilder { ConnectionString = ConnectionString };
                return (string)settings["InstrumentationKey"];
            }
        }

        internal Uri Endpoint
        {
            get
            {
                var settings = new DbConnectionStringBuilder { ConnectionString = ConnectionString };
                return new Uri((string)settings["IngestionEndpoint"]);
            }
        }

        internal static IReadOnlyList<MultiEndpointResource> Parse(string configuration)
        {
            var resources = JsonSerializer.Deserialize<MultiEndpointResource[]>(configuration, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            Assert.That(resources.Length, Is.GreaterThanOrEqualTo(3), "At least three destinations are required.");
            Assert.That(resources[0].Endpoint, Is.EqualTo(resources[1].Endpoint), "Destinations A/B must share an actual ingestion endpoint.");
            Assert.That(resources[0].Endpoint, Is.Not.EqualTo(resources[2].Endpoint), "Destination C must use another actual ingestion endpoint.");
            return resources;
        }
    }
}
#endif