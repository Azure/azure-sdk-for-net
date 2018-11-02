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

    public class RelationshipScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static RelationshipScenarioTests()
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
        public void CrdRelationshipFullCycle()
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
                                                                 },
                                                         Cardinality = CardinalityTypes.OneToOne
                                                     };

                var relationship = aciClient.Relationships.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    relationshipName,
                    relationshipResourceFormat);

                Assert.Equal(relationshipName, relationship.RelationshipName);
                Assert.Equal(relationship.Name, HubName + "/" + relationshipName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/relationships",
                    relationship.Type, StringComparer.OrdinalIgnoreCase);

                relationship = aciClient.Relationships.Get(ResourceGroupName, HubName, relationshipName);
                Assert.Equal(relationshipName, relationship.RelationshipName);
                Assert.Equal(relationship.Name, HubName + "/" + relationshipName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/relationships",
                    relationship.Type, StringComparer.OrdinalIgnoreCase);

                var relationships = aciClient.Relationships.ListByHub(ResourceGroupName, HubName);

                Assert.True(relationships.Any());
                Assert.Contains(relationships.ToList(), item => relationshipName == item.RelationshipName);

                var deleteRelationshipResult =
                    aciClient.Relationships.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, relationshipName)
                        .Result;

                Assert.Equal(HttpStatusCode.OK, deleteRelationshipResult.Response.StatusCode);
            }
        }
    }
}