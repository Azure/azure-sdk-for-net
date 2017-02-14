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

namespace CustomerInsights.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Azure.Management.CustomerInsights.Models;

    public class Helpers
    {
        public static ProfileResourceFormat GetTestProfile(string profileName)
        {
            return new ProfileResourceFormat
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
                                               KeyPropertyNames = new List<string> { "Id", "SavingAccountBalance" }
                                           },
                                       new StrongId
                                           {
                                               StrongIdName = "ProfileId",
                                               Description = null,
                                               DisplayName = null,
                                               KeyPropertyNames = new List<string> { "ProfileId", "LastName" }
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
        }

        public static InteractionResourceFormat GetTestInteraction(string interactionName, string profileName)
        {
            return new InteractionResourceFormat
            {
                ApiEntitySetName = interactionName,
                PrimaryParticipantProfilePropertyName = profileName,
                IdPropertyNames = new[] { interactionName },
                Fields =
                               new[]
                                   {
                                       new PropertyDefinition
                                           {
                                               FieldName = interactionName,
                                               FieldType = "Edm.String",
                                               IsArray = false,
                                               IsRequired = true
                                           },
                                       new PropertyDefinition { FieldName = profileName, FieldType = "Edm.String" }
                                   },
                SmallImage = "\\Images\\smallImage",
                MediumImage = "\\Images\\MediumImage",
                LargeImage = "\\Images\\LargeImage"
            };
        }

        public static ConnectorResourceFormat GetTestConnector(string connectorName, string description)
        {
            return new ConnectorResourceFormat
            {
                DisplayName = connectorName,
                Description = description,
                ConnectorType = ConnectorTypes.AzureBlob,
                ConnectorProperties =
                               new Dictionary<string, object>
                                   {
                                           {
                                               "connectionKeyVaultUrl",
                                               $"vault=off;DefaultEndpointsProtocol=https;AccountName=XXX;AccountKey=XXX"
                                           }
                                   }
            };
        }

        public static RoleAssignmentResourceFormat GetTestRoleAssignment(RoleTypes roleType, int principalCount)
        {
            var roleAssignment = new RoleAssignmentResourceFormat
            {
                Role = roleType,
                Principals = new List<AssignmentPrincipal>()
            };

            for (var i = 0; i < principalCount; ++i)
            {
                roleAssignment.Principals.Add(
                    new AssignmentPrincipal { PrincipalType = "User", PrincipalId = Guid.NewGuid().ToString("N") });
            }

            return roleAssignment;
        }

    }
}