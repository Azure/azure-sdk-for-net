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

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using System.Linq;
using Xunit;

namespace HDInsight.Tests
{
    public class GetCapabilitiesTests
    {
        [Fact]
        public void TestGetCapabilities()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);

                var capabilities = client.Clusters.GetCapabilities("East US");

                Assert.NotNull(capabilities);
                Assert.NotNull(capabilities.Features);
                Assert.True(capabilities.Features.Count > 0);
                Assert.NotNull(capabilities.QuotaCapability);
                Assert.NotNull(capabilities.QuotaCapability.RegionalQuotas);
                Assert.NotNull(capabilities.Regions);
                Assert.Equal(capabilities.Regions.Count, 2);
                Assert.NotNull(capabilities.Versions);
                Assert.Equal(capabilities.Versions.Count, 2);
                Assert.NotNull(capabilities.VmSizeCompatibilityFilters);
                Assert.True(capabilities.VmSizeCompatibilityFilters.Count > 0);
                Assert.NotNull(capabilities.VmSizes);
                Assert.Equal(capabilities.VmSizes.Count, 2);
            }
        }
    }
}
