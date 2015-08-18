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

using System.Linq;
using System.Net;
using HDInsight.Tests.Helpers;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsight.Tests
{
    public class GetConfigurationTests
    {
        [Fact]
        public void TestGetConfigCoreSiteCluster()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);
                const string dnsname = "hdisdk-configtest";

                var spec = GetClusterSpecHelpers.GetPaasClusterSpec();

                client.Clusters.Create(resourceGroup, dnsname, spec);

                var configs = client.Clusters.GetClusterConfigurations(resourceGroup, dnsname, "core-site");

                Assert.Equal(2, configs.Configuration.Count);

                client.Clusters.Delete(resourceGroup, dnsname);
            }
        }
    }
}
