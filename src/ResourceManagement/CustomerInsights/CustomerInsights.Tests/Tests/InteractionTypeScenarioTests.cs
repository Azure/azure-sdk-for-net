// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class InteractionTypeScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static InteractionTypeScenarioTests()
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
        public void CreateAndReadInteractionType()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();
                var interactionName = TestUtilities.GenerateName("TestInteractionType");
                var interactionResourceFormat = Helpers.GetTestInteraction(interactionName, "profile1");

                //Create interaction and verify
                var interactionResult = aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName,
                    interactionResourceFormat);

                Assert.Equal(interactionName, interactionResult.TypeName);
                Assert.Equal(interactionResult.Name, HubName + "/" + interactionName);
                Assert.Equal(interactionResult.Type, "Microsoft.CustomerInsights/hubs/interactions");

                //Get interaction and verify
                var interactionGetResult = aciClient.Interactions.Get(
                    ResourceGroupName,
                    HubName,
                    interactionName,
                    "en-us");

                Assert.Equal(interactionName, interactionGetResult.TypeName);
                Assert.Equal(
                    interactionGetResult.Name,
                    HubName + "/" + interactionName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    interactionGetResult.Type,
                    "Microsoft.CustomerInsights/hubs/interactions",
                    StringComparer.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void ListInteractionTypesInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();
                var interactionName1 = TestUtilities.GenerateName("TestInteractionType1");
                var interactionResourceFormat1 = Helpers.GetTestInteraction(interactionName1, "profile1");
                var interactionName2 = TestUtilities.GenerateName("TestInteractionType2");
                var interactionResourceFormat2 = Helpers.GetTestInteraction(interactionName2, "profile2");

                //Create interaction and verify
                aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName1,
                    interactionResourceFormat1);
                aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName2,
                    interactionResourceFormat2);

                var interactionList = aciClient.Interactions.ListByHub(ResourceGroupName, HubName);

                Assert.True(interactionList.ToList().Count >= 2);
                Assert.True(
                    interactionList.ToList()
                        .Any(interactionReturned => interactionName1 == interactionReturned.TypeName)
                    && interactionList.ToList()
                        .Any(interactionReturned => interactionName1 == interactionReturned.TypeName));
            }
        }
    }
}