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
                Assert.Equal("Microsoft.CustomerInsights/hubs/interactions", interactionResult.Type);

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
                    "Microsoft.CustomerInsights/hubs/interactions",
                    interactionGetResult.Type, StringComparer.OrdinalIgnoreCase);
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

        [Fact]
        public void SuggestRelationshipLinks()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var profileName1 = TestUtilities.GenerateName("testProfile");
                var profileName2 = TestUtilities.GenerateName("testProfile");
                var interactionName1 = TestUtilities.GenerateName("testInteraction");

                var profileResourceFormat1 = new ProfileResourceFormat
                                                 {
                                                     ApiEntitySetName = profileName1,
                                                     Fields =
                                                         new[]
                                                             {
                                                                 new PropertyDefinition
                                                                     {
                                                                         FieldName = "ContactId",
                                                                         FieldType = "Edm.String",
                                                                         IsArray = false,
                                                                         IsRequired = true
                                                                     }
                                                             },
                                                     StrongIds =
                                                         new List<StrongId>
                                                             {
                                                                 new StrongId
                                                                     {
                                                                         StrongIdName = "ContactId",
                                                                         KeyPropertyNames = new List<string> { "ContactId" }
                                                                     }
                                                             }
                                                 };

                var profileResourceFormat2 = new ProfileResourceFormat
                                                 {
                                                     ApiEntitySetName = profileName2,
                                                     Fields =
                                                         new[]
                                                             {
                                                                 new PropertyDefinition
                                                                     {
                                                                         FieldName = "BranchId",
                                                                         FieldType = "Edm.String",
                                                                         IsArray = false,
                                                                         IsRequired = true
                                                                     }
                                                             },
                                                     StrongIds =
                                                         new List<StrongId>
                                                             {
                                                                 new StrongId
                                                                     {
                                                                         StrongIdName = "BranchId",
                                                                         KeyPropertyNames = new List<string> { "BranchId" }
                                                                     }
                                                             }
                                                 };

                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName1, profileResourceFormat1);
                aciClient.Profiles.CreateOrUpdate(ResourceGroupName, HubName, profileName2, profileResourceFormat2);

                var interactionResourceFormat = new InteractionResourceFormat
                                                    {
                                                        ApiEntitySetName = interactionName1,
                                                        Fields =
                                                            new[]
                                                                {
                                                                    new PropertyDefinition
                                                                        {
                                                                            FieldName = "ContactId",
                                                                            FieldType = "Edm.String"
                                                                        },
                                                                    new PropertyDefinition
                                                                        {
                                                                            FieldName = "BranchId",
                                                                            FieldType = "Edm.String"
                                                                        }
                                                                }
                                                    };

                aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName1,
                    interactionResourceFormat);

                var linkName1 = TestUtilities.GenerateName("linkTest");
                var linkName2 = TestUtilities.GenerateName("linkTest");

                var linkResourceFormat1 = new LinkResourceFormat
                                              {
                                                  TargetProfileType = profileName1,
                                                  SourceInteractionType = interactionName1,
                                                  ParticipantPropertyReferences =
                                                      new[]
                                                          {
                                                              new ParticipantPropertyReference
                                                                  {
                                                                      ProfilePropertyName = "ContactId",
                                                                      InteractionPropertyName = "ContactId"
                                                                  }
                                                          }
                                              };
                var link1 = aciClient.Links.CreateOrUpdate(ResourceGroupName, HubName, linkName1, linkResourceFormat1);

                var linkResourceFormat2 = new LinkResourceFormat
                                              {
                                                  TargetProfileType = profileName2,
                                                  SourceInteractionType = interactionName1,
                                                  ParticipantPropertyReferences =
                                                      new[]
                                                          {
                                                              new ParticipantPropertyReference
                                                                  {
                                                                      ProfilePropertyName = "BranchId",
                                                                      InteractionPropertyName = "BranchId"
                                                                  }
                                                          }
                                              };
                var link2 = aciClient.Links.CreateOrUpdate(ResourceGroupName, HubName, linkName2, linkResourceFormat2);

                TestUtilities.Wait(5000);

                var suggestedRelationshipLinks = aciClient.Interactions.SuggestRelationshipLinks(
                    ResourceGroupName,
                    HubName,
                    interactionName1);

                Assert.Equal(2, suggestedRelationshipLinks.SuggestedRelationships.Count);
                Assert.Equal(interactionName1, suggestedRelationshipLinks.InteractionName);
                Assert.True(
                    ((suggestedRelationshipLinks.SuggestedRelationships[0].ProfileName == profileName1)
                     && (suggestedRelationshipLinks.SuggestedRelationships[0].RelatedProfileName == profileName2))
                    || ((suggestedRelationshipLinks.SuggestedRelationships[0].ProfileName == profileName2)
                        && (suggestedRelationshipLinks.SuggestedRelationships[0].RelatedProfileName == profileName1)));
            }
        }
    }
}