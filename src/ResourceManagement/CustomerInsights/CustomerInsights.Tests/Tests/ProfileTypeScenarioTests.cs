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

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;

    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    public class ProfileTypeScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static ProfileTypeScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CreateAndReadProfileType()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName = TestUtilities.GenerateName("TestProfileType");
                var profileResourceFormat = Helpers.GetTestProfile(profileName);

                //Create profile and verify
                var profileResult = aciClient.Profiles.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    profileName,
                    profileResourceFormat);

                Assert.Equal(profileName, profileResult.TypeName);
                Assert.Equal(profileResult.Name, HubName + "/" + profileName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    profileResult.Type,
                    "Microsoft.CustomerInsights/hubs/profiles",
                    StringComparer.OrdinalIgnoreCase);

                //Get profile and verify
                var profileGetResult = aciClient.Profiles.Get(ResourceGroupName, HubName, profileName, "en-us");
                Assert.Equal(profileName, profileGetResult.TypeName);
                Assert.Equal(profileGetResult.Name, HubName + "/" + profileName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    profileGetResult.Type,
                    "Microsoft.CustomerInsights/hubs/profiles",
                    StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void ListProfileTypesInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName1 = TestUtilities.GenerateName("TestProfileType1");
                var profileName2 = TestUtilities.GenerateName("TestProfileType2");

                var profileResourceFormat1 = Helpers.GetTestProfile(profileName1);
                var profileResourceFormat2 = Helpers.GetTestProfile(profileName2);

                //Create profile and verify
                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName1, profileResourceFormat1);
                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName2, profileResourceFormat2);

                var profileList = aciClient.Profiles.ListByHub(ResourceGroupName, HubName);

                Assert.True(profileList.ToList().Count >= 2);
                Assert.True(
                    profileList.ToList().Any(profileReturned => profileName1 == profileReturned.TypeName)
                    && profileList.ToList().Any(profileReturned => profileName2 == profileReturned.TypeName));
            }
        }
    }
}