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

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using System;

namespace HDInsight.Tests.Helpers
{
    public static class HDInsightManagementTestUtilities
    {
        public static string DefaultLocation = "West US";

        public static HDInsightManagementClient GetHDInsightManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
             var client =
                 TestBase.GetServiceClient<HDInsightManagementClient>(new CSMTestEnvironmentFactory())
                     .WithHandler(handler);
            return client;
        }

        public static ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string location = "")
        {
            const string testPrefix = "hdi";
            var rgname = TestUtilities.GenerateName(testPrefix);
            return CreateResourceGroup(resourcesClient, rgname, location);
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string rgname, string location = "")
        {
            if (string.IsNullOrEmpty(location))
            {
                location = DefaultLocation;
            }

            var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                rgname,
                new ResourceGroup
                {
                    Location = location
                });

            return rgname;
        }

        public static void WaitForClusterToMoveToRunning(string resourceGroup, string dnsName, HDInsightManagementClient hdInsightClient)
        {
            System.TimeSpan timeout = System.TimeSpan.FromMinutes(10);

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            bool createError = false;
            do
            {
                var cluster = hdInsightClient.Clusters.Get(resourceGroup, dnsName);

                if (cluster.Cluster.Properties.ClusterState == "Error")
                {
                    createError = true;
                    break;
                }
                if (cluster.Cluster.Properties.ClusterState == "Running") { return; }
                System.Threading.Thread.Sleep(2000);
            }
            while (stopwatch.Elapsed < timeout);

            Xunit.Assert.True(!createError);
        }

        public static bool IsRecordMode()
        {
            string testMode = System.Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            bool recordMode = !string.IsNullOrEmpty(testMode) && testMode.Equals("Record", StringComparison.OrdinalIgnoreCase);
            return recordMode;
        }
    }
}
