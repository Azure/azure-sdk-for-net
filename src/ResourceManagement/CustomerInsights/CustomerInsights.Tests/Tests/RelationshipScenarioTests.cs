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
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

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
                var profileResourceFormat = new ProfileResourceFormat
                                                {
                                                    ApiEntitySetName = profileName,
                                                    Fields =
                                                        new[]
                                                            {
                                                                new PropertyDefinition
                                                                    {
                                                                        FieldName = "Id",
                                                                        FieldType = "Edm.String",
                                                                        IsArray = false,
                                                                        IsRequired = true
                                                                    },
                                                                new PropertyDefinition
                                                                    {
                                                                        FieldName = "ProfileId",
                                                                        FieldType = "Edm.String",
                                                                        IsArray = false,
                                                                        IsRequired = true
                                                                    },
                                                                new PropertyDefinition
                                                                    {
                                                                        FieldName = "LastName",
                                                                        FieldType = "Edm.String",
                                                                        IsArray = false,
                                                                        IsRequired = true
                                                                    },
                                                                new PropertyDefinition
                                                                    {
                                                                        FieldName = profileName,
                                                                        FieldType = "Edm.String",
                                                                        IsArray = false,
                                                                        IsRequired = true
                                                                    },
                                                                new PropertyDefinition
                                                                    {
                                                                        FieldName = "SavingAccountBalance",
                                                                        FieldType = "Edm.Int32",
                                                                        IsArray = false,
                                                                        IsRequired = true
                                                                    }
                                                            },
                                                    StrongIds =
                                                        new List<StrongId>
                                                            {
                                                                new StrongId
                                                                    {
                                                                        StrongIdName = "Id",
                                                                        Description = null,
                                                                        DisplayName = null,
                                                                        KeyPropertyNames =
                                                                            new List<string> { "Id", "SavingAccountBalance" }
                                                                    },
                                                                new StrongId
                                                                    {
                                                                        StrongIdName = "ProfileId",
                                                                        Description = null,
                                                                        DisplayName = null,
                                                                        KeyPropertyNames =
                                                                            new List<string> { "ProfileId", "LastName" }
                                                                    }
                                                            },
                                                    DisplayName = null,
                                                    Description = null,
                                                    Attributes = null,
                                                    SchemaItemTypeLink = "SchemaItemTypeLink",
                                                    LocalizedAttributes = null,
                                                    SmallImage = "\\Images\\smallImage",
                                                    MediumImage = "\\Images\\MediumImage",
                                                    LargeImage = "\\Images\\LargeImage"
                                                };

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
                                                         //Fields = new PropertyDefinition[] { }
                                                     };

                var relationship = aciClient.Relationships.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    relationshipName,
                    relationshipResourceFormat);

                Assert.Equal(relationshipName, relationship.RelationshipName);
                Assert.Equal(relationship.Name, HubName + "/" + relationshipName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    relationship.Type,
                    "Microsoft.CustomerInsights/hubs/relationships",
                    StringComparer.OrdinalIgnoreCase);

                relationship = aciClient.Relationships.Get(ResourceGroupName, HubName, relationshipName);
                Assert.Equal(relationshipName, relationship.RelationshipName);
                Assert.Equal(relationship.Name, HubName + "/" + relationshipName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    relationship.Type,
                    "Microsoft.CustomerInsights/hubs/relationships",
                    StringComparer.OrdinalIgnoreCase);

                var relationships = aciClient.Relationships.ListByHub(ResourceGroupName, HubName);

                Assert.True(relationships.Any());
                Assert.True(relationships.ToList().Any(item => relationshipName == item.RelationshipName));

                var deleteRelationshipResult =
                    aciClient.Relationships.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, relationshipName)
                        .Result;

                Assert.Equal(HttpStatusCode.OK, deleteRelationshipResult.Response.StatusCode);
            }
        }
    }
}