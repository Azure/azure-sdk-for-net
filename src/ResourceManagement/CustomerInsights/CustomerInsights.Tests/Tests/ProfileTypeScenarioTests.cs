// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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