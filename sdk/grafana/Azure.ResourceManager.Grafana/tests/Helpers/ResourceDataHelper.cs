// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Grafana.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Grafana.Tests.Helpers
{
    public class ResourceDataHelper
    {
        public static ManagedGrafanaData GetGrafanaResourceData(AzureLocation location)
        {
            return new ManagedGrafanaData(location)
            {
                Sku = new ManagedGrafanaSku("Standard")
            };
        }

        public static void AssertGrafana(ManagedGrafanaData g1, ManagedGrafanaData g2)
        {
            AssertTrackedResource(g1, g2);
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }
    }
}
