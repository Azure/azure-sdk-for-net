// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class RelationshipLinkScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static RelationshipLinkScenarioTests()
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
        public void CrdRelationshipLinkFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName = TestUtilities.GenerateName("testProfile232");
                var relationshipName = TestUtilities.GenerateName("testRelationship232");
                var profileResourceFormat = Helpers.GetTestProfile(profileName);

                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName, profileResourceFormat);

                var relationshipResourceFormat = new RelationshipResourceFormat
                                                     {
                                                         ProfileType = profileName,
                                                         RelatedProfileType = profileName,
                                                         DisplayName =
                                                             new Dictionary<string, string>
                                                                 {
                                                                         { "en-us", "Relationship DisplayName" }
                                                                 },
                                                         Description =
                                                             new Dictionary<string, string>
                                                                 {
                                                                         { "en-us", "Relationship Description" }
                                                                 }
                                                     };

                aciClient.Relationships.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    relationshipName,
                    relationshipResourceFormat);

                var interactionName = TestUtilities.GenerateName("TestInteractionType");
                var interactionResourceFormat = Helpers.GetTestInteraction(interactionName, "profile1");

                //Create interaction and verify
                var interactionResult = aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName,
                    interactionResourceFormat);

                var relationshipLinkResourceFormat = new RelationshipLinkResourceFormat
                                                         {
                                                             InteractionType = interactionName,
                                                             RelationshipName = relationshipName,
                                                             DisplayName =
                                                                 new Dictionary<string, string>
                                                                     {
                                                                             { "en-us", "Link DisplayName" }
                                                                     },
                                                             Description =
                                                                 new Dictionary<string, string>
                                                                     {
                                                                             { "en-us", "Link Description" }
                                                                     },
                                                             ProfilePropertyReferences =
                                                                 new[]
                                                                     {
                                                                         new ParticipantPropertyReference
                                                                             {
                                                                                 InteractionPropertyName = "profile1",
                                                                                 ProfilePropertyName = "ProfileId"
                                                                             }
                                                                     },
                                                             RelatedProfilePropertyReferences =
                                                                 new[]
                                                                     {
                                                                         new ParticipantPropertyReference
                                                                             {
                                                                                 InteractionPropertyName = "profile1",
                                                                                 ProfilePropertyName = "ProfileId"
                                                                             }
                                                                     }
                                                         };

                var relationshipLinkName = TestUtilities.GenerateName("testRelationshipLink232");
                var relationshipLink = aciClient.RelationshipLinks.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    relationshipLinkName,
                    relationshipLinkResourceFormat);

                Assert.Equal(relationshipLinkName, relationshipLink.LinkName);
                Assert.Equal(
                    relationshipLink.Name,
                    HubName + "/" + relationshipLinkName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/relationshipLinks",
                    relationshipLink.Type, StringComparer.OrdinalIgnoreCase);

                relationshipLink = aciClient.RelationshipLinks.Get(ResourceGroupName, HubName, relationshipLinkName);
                Assert.Equal(relationshipLinkName, relationshipLink.LinkName);
                Assert.Equal(
                    relationshipLink.Name,
                    HubName + "/" + relationshipLinkName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/relationshipLinks",
                    relationshipLink.Type, StringComparer.OrdinalIgnoreCase);

                var relationshipLinks = aciClient.RelationshipLinks.ListByHub(ResourceGroupName, HubName);
                Assert.True(relationshipLinks.Any());
                Assert.Contains(relationshipLinks.ToList(), item => relationshipLinkName == item.LinkName);

                var deleteRelationshipResult =
                    aciClient.RelationshipLinks.DeleteWithHttpMessagesAsync(
                        ResourceGroupName,
                        HubName,
                        relationshipLinkName).Result;
                Assert.Equal(HttpStatusCode.OK, deleteRelationshipResult.Response.StatusCode);
            }
        }
    }
}