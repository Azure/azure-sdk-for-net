// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
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
                    "Microsoft.CustomerInsights/hubs/profiles",
                    profileResult.Type, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(ProvisioningStates.Succeeded, profileResult.ProvisioningState);

                //Get profile and verify
                var profileGetResult = aciClient.Profiles.Get(ResourceGroupName, HubName, profileName, "en-us");
                Assert.Equal(profileName, profileGetResult.TypeName);
                Assert.Equal(profileGetResult.Name, HubName + "/" + profileName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/profiles",
                    profileGetResult.Type, StringComparer.OrdinalIgnoreCase);
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


        [Fact]
        public void GetEnrichingKpis()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName1 = TestUtilities.GenerateName("TestProfileType1");
                var profileResourceFormat1 = Helpers.GetTestProfile(profileName1);
                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName1, profileResourceFormat1);

                var interactionName1 = TestUtilities.GenerateName("TestInteractionType1");
                var interactionResourceFormat1 = Helpers.GetTestInteraction(interactionName1, profileName1);
                interactionResourceFormat1.ParticipantProfiles = 
                    new List<Participant>()
                        {
                            new Participant()
                                {
                                    ParticipantName = profileName1,
                                    ProfileTypeName = profileName1,
                                    ParticipantPropertyReferences = 
                                        new List<ParticipantPropertyReference>()
                                            {
                                                new ParticipantPropertyReference()
                                                    {
                                                        InteractionPropertyName = interactionName1,
                                                        ProfilePropertyName = profileName1
                                                    }
                                            }
                                }
                        };

                var interaction1 = aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName1,
                    interactionResourceFormat1);

                var kpiName = TestUtilities.GenerateName("TestKpi1");
                var kpiResourceFormat = new KpiResourceFormat
                                            {
                                                EntityType = EntityTypes.Interaction,
                                                EntityTypeName = interactionName1,
                                                DisplayName =
                                                    new Dictionary<string, string> { { "en-us", "Kpi DisplayName" } },
                                                Description =
                                                    new Dictionary<string, string> { { "en-us", "Kpi Description" } },
                                                CalculationWindow = CalculationWindowTypes.Day,
                                                Function = KpiFunctions.Count,
                                                Expression = "*",
                                                GroupBy = new[] { interactionName1 },
                                                Unit = "unit",
                                                ThresHolds =
                                                    new KpiThresholds
                                                        {
                                                            LowerLimit = 5.0m,
                                                            UpperLimit = 50.0m,
                                                            IncreasingKpi = true
                                                        }
                                            };

                var kpi = aciClient.Kpi.CreateOrUpdate(ResourceGroupName, HubName, kpiName, kpiResourceFormat);
                var enrichingKpis = aciClient.Profiles.GetEnrichingKpis(ResourceGroupName, HubName, profileName1);

                Assert.Equal(1, enrichingKpis.Count);
                Assert.Equal(kpi.KpiName, enrichingKpis[0].KpiName);
                Assert.Equal(kpi.EntityType, enrichingKpis[0].EntityType);
                Assert.Equal(kpi.EntityTypeName, enrichingKpis[0].EntityTypeName);
            }
        }
    }
}