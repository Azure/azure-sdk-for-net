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

namespace Management.HDInsight.Tests
{
    using Xunit;
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using System.Net;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    [Collection("ScenarioTests")]
    public class CapabilitiesTests
    {
        [Fact]
        public void TestGetCapabilities()
        {
            string suiteName = GetType().FullName;
            string testName = "TestGetCapabilities";

            using (MockContext context = MockContext.Start(suiteName, testName))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);

                CapabilitiesResult capabilities = client.Location.GetCapabilities(HDInsightManagementTestUtilities.DefaultLocation);
                Assert.NotNull(capabilities);
                Assert.NotNull(capabilities.Features);
                Assert.NotNull(capabilities.Quota);
                Assert.NotNull(capabilities.Regions);
                Assert.NotNull(capabilities.Versions);
                Assert.NotNull(capabilities.VmSizeFilters);
                Assert.NotNull(capabilities.VmSizes);
            }
        }
    }
}
