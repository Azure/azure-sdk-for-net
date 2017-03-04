//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.TrafficManager.Models;
using Microsoft.Azure.Management.TrafficManager.Testing.Helpers;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Management.TrafficManager.Testing.ScenarioTests
{
    using System;

    public class GeographicHierarchyScenarioTests
    {
        public GeographicHierarchyScenarioTests()
        {
            // No cleanup required 
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ;
            }
        }

        [Fact]
        public void GetDefaultGeographicHierarchy()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                TrafficManagerManagementClient trafficManagerClient = TrafficManagerHelper.GetTrafficManagerClient();

                GeographicHierarchyGetResponse hierarchyResponse = trafficManagerClient.GeographicHierarchy.GetDefault();
                Assert.NotNull(hierarchyResponse);
                Assert.NotNull(hierarchyResponse.GeographicHierarchy);
                Assert.NotNull(hierarchyResponse.GeographicHierarchy.Properties);
                Assert.NotNull(hierarchyResponse.GeographicHierarchy.Properties.Root);
                HierarchyRoot root = hierarchyResponse.GeographicHierarchy.Properties.Root;

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
