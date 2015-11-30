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

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "hdi";
            var rgname = TestUtilities.GenerateName(testPrefix);
            return CreateResourceGroup(resourcesClient, rgname);
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string rgname)
        {
            var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                rgname,
                new ResourceGroup
                {
                    Location = DefaultLocation
                });

            return rgname;
        }
    }
}
