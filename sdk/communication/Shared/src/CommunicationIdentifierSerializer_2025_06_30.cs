// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation;
using System.Collections.Generic;
using System.Text.Json;

using Base = Azure.Communication.CommunicationIdentifierSerializer;

namespace Azure.Communication
{
    internal class CommunicationIdentifierSerializer_2025_06_30
    {
        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            string rawId = Base.AssertNotNull(identifier.RawId, nameof(identifier.RawId), nameof(CommunicationIdentifierModel));

            AssertMaximumOneNestedModel(identifier);

            var kind = identifier.Kind ?? GetKind_2025_06_30(identifier);

            if (kind == CommunicationIdentifierModelKind.TeamsExtensionUser
                 && identifier.TeamsExtensionUser is not null)
            {
                var teamsExtensionUser = identifier.TeamsExtensionUser;
                return new TeamsExtensionUserIdentifier(
                      Base.AssertNotNull(teamsExtensionUser.UserId, nameof(teamsExtensionUser.UserId), nameof(TeamsExtensionUserIdentifierModel)),
                      Base.AssertNotNull(teamsExtensionUser.TenantId, nameof(teamsExtensionUser.TenantId), nameof(TeamsExtensionUserIdentifierModel)),
                      Base.AssertNotNull(teamsExtensionUser.ResourceId, nameof(teamsExtensionUser.ResourceId), nameof(TeamsExtensionUserIdentifierModel)),
                      Base.Deserialize(Base.AssertNotNull(teamsExtensionUser.Cloud, nameof(teamsExtensionUser.Cloud), nameof(TeamsExtensionUserIdentifierModel))));
            }

            return Base.Deserialize(identifier);

            static void AssertMaximumOneNestedModel(CommunicationIdentifierModel identifier)
            {
                List<string> presentProperties = new();
                if (identifier.CommunicationUser is not null)
                    presentProperties.Add(nameof(identifier.CommunicationUser));
                if (identifier.PhoneNumber is not null)
                    presentProperties.Add(nameof(identifier.PhoneNumber));
                if (identifier.MicrosoftTeamsUser is not null)
                    presentProperties.Add(nameof(identifier.MicrosoftTeamsUser));
                if (identifier.MicrosoftTeamsApp is not null)
                    presentProperties.Add(nameof(identifier.MicrosoftTeamsApp));
                if (identifier.TeamsExtensionUser is not null)
                    presentProperties.Add(nameof(identifier.TeamsExtensionUser));

                if (presentProperties.Count > 1)
                    throw new JsonException($"Only one of the properties in {{{string.Join(", ", presentProperties)}}} should be present.");
            }
        }

        private static CommunicationIdentifierModelKind GetKind_2025_06_30(CommunicationIdentifierModel identifier)
        {
            if (identifier.TeamsExtensionUser is not null)
            {
                return CommunicationIdentifierModelKind.TeamsExtensionUser;
            }

            return Base.GetKind(identifier);
        }

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => identifier switch
            {
                PhoneNumberIdentifier p => new CommunicationIdentifierModel
                {
                    RawId = p.RawId,
                    PhoneNumber = new PhoneNumberIdentifierModel(p.PhoneNumber)
                    {
                        IsAnonymous = p.IsAnonymous,
                        AssertedId = p.AssertedId,
                    }
                },
                TeamsExtensionUserIdentifier user => new CommunicationIdentifierModel
                {
                    RawId = user.RawId,
                    TeamsExtensionUser = new TeamsExtensionUserIdentifierModel(user.UserId.ToString(), user.TenantId.ToString(), user.ResourceId.ToString())
                    {
                        Cloud = Base.Serialize(user.Cloud),
                    }
                },
                _ => Base.Serialize(identifier),
            };
    }
}
