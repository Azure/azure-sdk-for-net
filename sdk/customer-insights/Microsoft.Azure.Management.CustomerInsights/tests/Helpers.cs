// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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