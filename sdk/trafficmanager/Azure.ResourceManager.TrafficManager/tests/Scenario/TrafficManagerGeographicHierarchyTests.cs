// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public sealed class TrafficManagerGeographicHierarchyTests : TrafficManagerManagementTestBase
    {
        public TrafficManagerGeographicHierarchyTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        [RecordedTest]
        public async Task GetTest()
        {
            TrafficManagerGeographicHierarchyResource trafficManagerGeographicHierarchyResource =
                Client.GetTrafficManagerGeographicHierarchyResource(
                    TrafficManagerGeographicHierarchyResource.CreateResourceIdentifier());

            trafficManagerGeographicHierarchyResource = await trafficManagerGeographicHierarchyResource.GetAsync();

            Assert.That(trafficManagerGeographicHierarchyResource, Is.Not.Null);
            Assert.That(trafficManagerGeographicHierarchyResource.HasData, Is.True);
            Assert.That(trafficManagerGeographicHierarchyResource.Data, Is.Not.Null);
            Assert.That(trafficManagerGeographicHierarchyResource.Data.GeographicHierarchy.Regions.Count > 0, Is.True);
        }
    }
}
