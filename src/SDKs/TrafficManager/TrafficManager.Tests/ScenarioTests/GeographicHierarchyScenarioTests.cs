// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System.Collections.Generic;
    using System.Linq;
    using global::TrafficManager.Tests.Helpers;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class GeographicHierarchyScenarioTests : TestBase
    {
        [Fact]
        public void GetDefaultGeographicHierarchy()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                TrafficManagerManagementClient trafficManagerClient = this.GetTrafficManagerManagementClient(context);

                TrafficManagerGeographicHierarchy getHierarchyResponse = trafficManagerClient.GeographicHierarchies.GetDefault();
                Assert.NotNull(getHierarchyResponse);
                Assert.Equal("/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default", getHierarchyResponse.Id);
                Assert.Equal("Microsoft.Network/trafficManagerGeographicHierarchies", getHierarchyResponse.Type);
                Assert.Equal("default", getHierarchyResponse.Name);

                Assert.NotNull(getHierarchyResponse.GeographicHierarchy);
                Region root = getHierarchyResponse.GeographicHierarchy;

                Assert.Equal("WORLD", root.Code);
                Assert.Equal("World", root.Name);
                Assert.NotEmpty(root.Regions);

                foreach (var grouping in root.Regions)
                {
                    Assert.NotNull(grouping.Code);
                    Assert.NotEmpty(grouping.Code);
                    Assert.NotNull(grouping.Name);
                    Assert.NotEmpty(grouping.Name);
                    Assert.NotEmpty(grouping.Regions);
                }
            }
        }
    }
}
